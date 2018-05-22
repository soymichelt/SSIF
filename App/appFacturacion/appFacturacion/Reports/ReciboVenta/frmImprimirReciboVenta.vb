Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmImprimirReciboVenta
    Public idrecibo As String
    Private Sub frmImprimirReciboVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "SaleReceiptPrintReport",
            "Load",
            "Load SaleReceiptPrintReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Try
            Using db As New CodeFirst
                Dim recibo = db.VentasRecibos.Where(Function(f) f.IDRECIBO = Me.idrecibo).FirstOrDefault
                If Not recibo Is Nothing Then
                    If recibo.ANULADO = "N" Then
                        Dim rpt As New rptReciboVenta
                        rpt.SetDataSource((From rec In db.VentasRecibos Join ser In db.Series On ser.IDSERIE Equals rec.IDSERIE Join det In db.VentasRecibosDetalles On rec.IDRECIBO Equals det.IDRECIBO Join ven In db.Ventas On det.IDVENTA Equals ven.IDVENTA Join ser_com In db.Series On ven.IDSERIE Equals ser_com.IDSERIE Where rec.IDRECIBO = Me.idrecibo Select rec.Cliente.IDCLIENTE, N_CLIENTE = rec.Cliente.N_CLIENTE, CLIENTE = rec.Cliente.NOMBRES & " " & rec.Cliente.APELLIDOS, rec.IDRECIBO, ser.Bodega.IDBODEGA, BODEGA = ser.Bodega.N_BODEGA & " - " & ser.Bodega.DESCRIPCION, SERIE = ser.NOMBRE, rec.CONSECUTIVO, rec.FECHARECIBO, OBSERVACION = rec.CONCEPTO, IMPORTE = rec.IMPORTETOTAL_C, DESCUENTO = rec.DESCUENTOTOTAL_C, SOBRANTE = rec.SOBRANTEDECAJA_C, TOTAL = rec.MONTOTOTAL_C, FACTURA = ser_com.NOMBRE & " - " & ven.CONSECUTIVO, FECHA = ven.FECHAFACTURA, TOTAL_DETALLE = ven.TOTAL_C, det.SALDOCREDITO, det.OPERACION, IMPORTE_DETALLE = det.IMPORTE_C, DESCUENTO_DETALLE = det.DESCUENTO_C, det.NUEVO_SALDO_C, TOTALIZAR_IMPORTE = rec.IMPORTETOTAL_C, TOTALIZAR_DESCUENTO = rec.DESCUENTOTOTAL_C, TOTALIZAR_SOBRANTE = rec.SOBRANTEDECAJA_C, TOTALIZAR_NETO = rec.MONTOTOTAL_C, REIMPRESION = If(rec.REIMPRESION.Equals("N"), "ORIGINAL", "COPIA")).ToList)
                        CrystalReportViewer1.ReportSource = rpt
                        If recibo.REIMPRESION <> "S" Then
                            recibo.REIMPRESION = "S" : db.Entry(recibo).State = EntityState.Modified : db.SaveChanges()
                        End If
                    Else
                        MessageBox.Show("Error, No se puede imprimir este Recibo de Venta por que ha sido Anulado.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra este Recibo de Venta.")
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub frmImprimirReciboVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(source As Object, e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        Me.frmImprimirReciboVenta_Load(Nothing, Nothing)
    End Sub
End Class