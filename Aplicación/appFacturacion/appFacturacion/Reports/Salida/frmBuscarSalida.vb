Public Class frmBuscarSalida

    Public idserie As String = ""

    Sub llenar(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime)
        Try
            Using db As New CodeFirst
                lvRegistro.Items.Clear()
                Dim item As New ListViewItem
                For Each salida In From sal In db.Salidas Join ser In db.Series On sal.IDSERIE Equals ser.IDSERIE Where sal.ANULADO = "N" And sal.IDSERIE = Me.idserie And sal.FECHASALIDA >= fecha1 And sal.FECHASALIDA <= fecha2 Select ser, sal Order By sal.FECHASALIDA
                    item = lvRegistro.Items.Add(salida.sal.IDSALIDA)
                    item.SubItems.Add(salida.ser.NOMBRE)
                    item.SubItems.Add(salida.sal.CONSECUTIVO)
                    item.SubItems.Add(salida.sal.FECHASALIDA.ToShortDateString())
                    item.SubItems.Add(salida.sal.OBSERVACION)
                    item.SubItems.Add(salida.sal.TOTAL.ToString(Config.f_m))
                Next
                item = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarSalidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59")
    End Sub

    Private Sub lvRegistro_DoubleClick(sender As Object, e As EventArgs) Handles lvRegistro.DoubleClick
        Try
            Using db As New CodeFirst
                Dim idsalida As String = lvRegistro.SelectedItems(0).Text
                Dim salida = db.Salidas.Where(Function(f) f.IDSALIDA = idsalida).FirstOrDefault()
                If Not salida Is Nothing Then
                    If salida.ANULADO = "N" Then
                        frmSalida.txtCodigo.Text = salida.CONSECUTIVO
                        frmSalida.dtpFecha.Text = salida.FECHASALIDA.ToShortDateString()
                        frmSalida.txtConcepto.Text = salida.OBSERVACION
                        Dim item As New ListViewItem
                        frmSalida.lvRegistro.Items.Clear()
                        For Each detalle In salida.SalidasDetalles
                            item = frmSalida.lvRegistro.Items.Add(detalle.IDEXISTENCIA)
                            item.SubItems.Add(detalle.Existencia.Producto.IDALTERNO)
                            item.SubItems.Add(detalle.Existencia.Producto.IDORIGINAL)
                            item.SubItems.Add(detalle.Existencia.Producto.DESCRIPCION)
                            item.SubItems.Add(detalle.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                            item.SubItems.Add(detalle.CANTIDAD.ToString(Config.f_m))
                            item.SubItems.Add(detalle.COSTO.ToString(Config.f_m))
                            item.SubItems.Add(detalle.TOTAL.ToString(Config.f_m))
                        Next
                        item = Nothing
                        frmSalida.txtTotal.Text = salida.TOTAL.ToString(Config.f_m)
                        frmSalida.lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()
                        frmSalida.btGuardar.Enabled = False
                    Else
                        MessageBox.Show("Esta entrada esta anulada")
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta entrada o ha sido eliminada")
                End If
                idsalida = Nothing
                salida = Nothing

                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
End Class