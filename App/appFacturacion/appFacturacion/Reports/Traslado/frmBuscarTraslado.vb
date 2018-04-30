Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmBuscarTraslado

    Public idserie As String = ""

    Sub llenar(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime)
        Try
            Using db As New CodeFirst
                lvRegistro.Items.Clear()
                Dim item As New ListViewItem
                For Each traslado In From tra In db.Traslados Join ser In db.Series On tra.IDSERIE Equals ser.IDSERIE Join bod In db.Bodegas On tra.IDBODEGA Equals bod.IDBODEGA Where tra.ANULADO = "N" And tra.IDSERIE = Me.idserie And tra.FECHATRASLADO >= fecha1 And tra.FECHATRASLADO <= fecha2 Select ser, tra, bod Order By tra.FECHATRASLADO
                    item = lvRegistro.Items.Add(traslado.tra.IDTRASLADO)
                    item.SubItems.Add(traslado.ser.NOMBRE)
                    item.SubItems.Add(traslado.tra.CONSECUTIVO)
                    item.SubItems.Add(traslado.tra.FECHATRASLADO.ToString(Config.dateFormat))
                    item.SubItems.Add(traslado.bod.DESCRIPCION)
                    item.SubItems.Add(traslado.tra.CONCEPTO)
                    item.SubItems.Add(traslado.tra.REFERENCIA)
                    item.SubItems.Add(traslado.tra.TOTAL.ToString(Config.f_m))
                Next
                item = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarTraslados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59")
    End Sub

    Private Sub lvRegistro_DoubleClick(sender As Object, e As EventArgs) Handles lvRegistro.DoubleClick
        Try
            Using db As New CodeFirst
                Dim idtraslado As String = lvRegistro.SelectedItems(0).Text
                Dim traslado = db.Traslados.Where(Function(f) f.IDTRASLADO = idtraslado).FirstOrDefault()
                If Not traslado Is Nothing Then
                    If traslado.ANULADO = "N" Then
                        frmTraslado.txtCodigo.Text = traslado.CONSECUTIVO
                        frmTraslado.dtpFecha.Text = traslado.FECHATRASLADO.ToShortDateString()
                        frmTraslado.txtConcepto.Text = traslado.CONCEPTO
                        frmTraslado.txtReferTraslado.Text = traslado.REFERENCIA
                        frmTraslado.cmbBodegaSale.Text = traslado.Bodega.DESCRIPCION
                        frmTraslado.cmbBodegaSale.Enabled = False
                        frmTraslado.cmbBodegaEntra.Text = traslado.TrasladosDetalles.FirstOrDefault().Existencia.Bodega.DESCRIPCION
                        Dim item As New ListViewItem
                        frmTraslado.lvRegistro.Items.Clear()
                        For Each detalle In traslado.TrasladosDetalles
                            item = frmTraslado.lvRegistro.Items.Add(detalle.IDEXISTENCIA)
                            item.SubItems.Add(detalle.Existencia.Producto.IDALTERNO)
                            item.SubItems.Add(detalle.Existencia.Producto.IDORIGINAL)
                            item.SubItems.Add(detalle.Existencia.Producto.DESCRIPCION)
                            item.SubItems.Add(detalle.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                            item.SubItems.Add(detalle.CANTIDAD.ToString(Config.f_m))
                            item.SubItems.Add(detalle.COSTO.ToString(Config.f_m))
                            item.SubItems.Add(detalle.TOTAL.ToString(Config.f_m))

                        Next
                        item = Nothing
                        frmTraslado.txtTotal.Text = traslado.TOTAL.ToString(Config.f_m)
                        frmTraslado.lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()
                        frmTraslado.btGuardar.Enabled = False
                    Else
                        MessageBox.Show("Esta entrada esta anulada")
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta entrada o ha sido eliminada")
                End If
                idtraslado = Nothing
                traslado = Nothing

                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
End Class