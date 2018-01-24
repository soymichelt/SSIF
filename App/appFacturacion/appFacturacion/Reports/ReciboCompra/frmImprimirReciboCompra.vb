Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmImprimirReciboCompra
    Public IdRecibo As String
    Private Sub frmImprimirReciboCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                Dim recibo = db.ComprasRecibos.Where(Function(f) f.IDRECIBO = Me.IdRecibo).FirstOrDefault
                If Not recibo Is Nothing Then
                    If recibo.ANULADO = "N" Then
                        Dim rpt As New rptReciboCompra
                        Config.CrystalTitle("RECIBO DE COMPRA", rpt)
                        rpt.SetDataSource((From rec In db.ComprasRecibos Join ser In db.Series On ser.IDSERIE Equals rec.IDSERIE Join det In db.ComprasRecibosDetalles On rec.IDRECIBO Equals det.IDRECIBO Join com In db.Compras On det.IDCOMPRA Equals com.IDCOMPRA Join ser_com In db.Series On com.IDSERIE Equals ser_com.IDSERIE Where rec.IDRECIBO = Me.IdRecibo Select N_EMPLEADO = rec.Empleado.N_TRABAJADOR, EMPLEADO = rec.Empleado.NOMBRES & " " & rec.Empleado.APELLIDOS, IDCLIENTE = rec.Proveedor.IDPROVEEDOR, N_CLIENTE = rec.Proveedor.N_PROVEEDOR, CLIENTE = rec.Proveedor.NOMBRES & " " & rec.Proveedor.APELLIDOS, rec.IDRECIBO, ser.Bodega.IDBODEGA, BODEGA = ser.Bodega.N_BODEGA & " - " & ser.Bodega.DESCRIPCION, SERIE = ser.NOMBRE, rec.CONSECUTIVO, N_RECIBO = rec.N_DOCUMENTO, rec.FORMADEPAGO, rec.N_PAGO, rec.FECHARECIBO, MONEDA = If(rec.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), OBSERVACION = rec.CONCEPTO, IMPORTE = rec.IMPORTETOTAL_C, DESCUENTO = rec.DESCUENTOTOTAL_C, SOBRANTE = rec.SOBRANTEDECAJA_C, TOTAL = rec.MONTOTOTAL_C, FACTURA = ser_com.NOMBRE & " - " & com.CONSECUTIVO, FECHA = com.FECHACOMPRA, TOTAL_DETALLE = com.TOTAL_C, det.SALDOCREDITO, det.OPERACION, IMPORTE_DETALLE = det.IMPORTE_C, DESCUENTO_DETALLE = det.DESCUENTO_C, det.NUEVO_SALDO_C, TOTALIZAR_IMPORTE = rec.IMPORTETOTAL_C, TOTALIZAR_DESCUENTO = rec.DESCUENTOTOTAL_C, TOTALIZAR_SOBRANTE = rec.SOBRANTEDECAJA_C, TOTALIZAR_NETO = rec.MONTOTOTAL_C, REIMPRESION = If(rec.REIMPRESION.Equals("N"), "ORIGINAL", "COPIA")).ToList)
                        CrystalReportViewer1.ReportSource = rpt
                        If recibo.REIMPRESION <> "S" Then
                            recibo.REIMPRESION = "S" : db.Entry(recibo).State = EntityState.Modified : db.SaveChanges()
                        End If
                    Else
                        MessageBox.Show("Error, No se puede imprimir este Recibo de Compra por que ha sido Anulado.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra este Recibo de Compra.")
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub frmImprimirReciboCompra_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class