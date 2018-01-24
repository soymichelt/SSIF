Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmBuscarEntrada

    Public idserie As String = ""

    Sub llenar(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime)
        Try
            Using db As New CodeFirst
                lvRegistro.Items.Clear()
                Dim item As New ListViewItem
                For Each entrada In From ent In db.Entradas Join ser In db.Series On ent.IDSERIE Equals ser.IDSERIE Where ent.ANULADO = "N" And ent.IDSERIE = Me.idserie And ent.FECHAENTRADA >= fecha1 And ent.FECHAENTRADA <= fecha2 Select ser, ent Order By ent.FECHAENTRADA
                    item = lvRegistro.Items.Add(entrada.ent.IDENTRADA)
                    item.SubItems.Add(entrada.ser.NOMBRE)
                    item.SubItems.Add(entrada.ent.CONSECUTIVO)
                    item.SubItems.Add(entrada.ent.FECHAENTRADA.ToShortDateString())
                    item.SubItems.Add(entrada.ent.OBSERVACION)
                    item.SubItems.Add(entrada.ent.TOTAL.ToString(Config.f_m))
                Next
                item = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
    Private Sub frmBuscarEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs)
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59")
    End Sub

    Private Sub lvRegistro_DoubleClick(sender As Object, e As EventArgs) Handles lvRegistro.DoubleClick
        If lvRegistro.SelectedItems.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim identrada As String = lvRegistro.SelectedItems(0).Text
                    Dim entrada = db.Entradas.Where(Function(f) f.IDENTRADA = identrada).FirstOrDefault()
                    If Not entrada Is Nothing Then
                        If entrada.ANULADO = "N" Then
                            frmEntrada.txtCodigo.Text = entrada.CONSECUTIVO
                            frmEntrada.dtpFecha.Text = entrada.FECHAENTRADA.ToShortDateString()
                            frmEntrada.txtConcepto.Text = entrada.OBSERVACION
                            Dim item As New ListViewItem
                            frmEntrada.lvRegistro.Items.Clear()
                            For Each detalle In entrada.EntradasDetalles
                                item = frmEntrada.lvRegistro.Items.Add(detalle.IDEXISTENCIA)
                                item.SubItems.Add(detalle.Existencia.Producto.IDALTERNO)
                                item.SubItems.Add(detalle.Existencia.Producto.IDORIGINAL)
                                item.SubItems.Add(detalle.Existencia.Producto.DESCRIPCION)
                                item.SubItems.Add(detalle.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                                item.SubItems.Add(detalle.CANTIDAD.ToString(Config.f_m))
                                item.SubItems.Add(detalle.COSTO.ToString(Config.f_m))
                                item.SubItems.Add(detalle.TOTAL.ToString(Config.f_m))
                            Next
                            item = Nothing
                            frmEntrada.txtTotal.Text = entrada.TOTAL.ToString(Config.f_m)
                            frmEntrada.lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()
                            frmEntrada.btGuardar.Enabled = False
                        Else
                            MessageBox.Show("Esta entrada esta anulada")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra esta entrada o ha sido eliminada")
                    End If
                    identrada = Nothing
                    entrada = Nothing

                    Me.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59")
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59")
    End Sub
End Class