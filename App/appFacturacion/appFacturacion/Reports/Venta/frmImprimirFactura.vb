Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmImprimirFactura
    Public idventa As String
    Sub MostrarInforme()
        Try
            Using db As New CodeFirst
                Dim rpt As New rptImprimirFactura
                rpt.SetDataSource((From ven In db.Ventas Join tra In db.Empleados On tra.IDEMPLEADO Equals ven.IDEMPLEADO Join ser In db.Series On ven.IDSERIE Equals ser.IDSERIE Join det In db.VentasDetalles On ven.IDVENTA Equals det.IDVENTA Join exi In db.Existencias On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Where ven.IDVENTA = Me.idventa And ven.ANULADO = "N" Select IDFACTURA = ven.IDVENTA, BODEGA = ser.Bodega.N_BODEGA & " | " & ser.Bodega.DESCRIPCION, SERIE = ser.NOMBRE, N_VENDEDOR = tra.N_TRABAJADOR, VENDEDOR = tra.NOMBRES & " " & tra.APELLIDOS, N_CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.Cliente.N_CLIENTE, ""), CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.Cliente.NOMBRES & " " & ven.Cliente.APELLIDOS, ven.CLIENTECONTADO), N_FACTURA = ven.CONSECUTIVO, FECHA = ven.FECHAFACTURA, CONDICION = If(ven.CREDITO, "Crédito", "Contado"), MARCA = pro.Marca.DESCRIPCION, ALTERNO = pro.IDALTERNO, ORIGINAL = pro.IDORIGINAL, pro.DESCRIPCION, det.CANTIDAD, PRECIO = If(ven.MONEDA.Equals(Config.cordoba), det.PRECIOUNITARIO_C, det.PRECIOUNITARIO_D), SUBTOTAL_DETALLE = If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D), SUBTOTAL_FACTURA = If(ven.MONEDA.Equals(Config.cordoba), ven.SUBTOTAL_C, ven.SUBTOTAL_D), DESCUENTO = If(ven.MONEDA.Equals(Config.cordoba), ven.DESCUENTO_DIN_C, ven.DESCUENTO_DIN_D), IVA = If(ven.MONEDA.Equals(Config.cordoba), ven.IVA_DIN_C, ven.IVA_DIN_D), TOTAL = If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D)).ToList())
                Dim titleReport As TextObject = rpt.Section1.ReportObjects("TitleReport")
                titleReport.Text = Config.businessName & vbNewLine & Config.businessAddress & vbNewLine & Config.businessRUC & vbNewLine & Config.businessPhone1 & "/" & Config.businessPhone2
                rpt.PrintOptions.PrinterName = Config.PrinterName
                rpt.PrintToPrinter(1, False, 0, 0)
                'CrystalReportViewer1.ReportSource = rpt
                'rpt = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmImprimirFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInforme()
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(source As Object, e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        MostrarInforme()
    End Sub

End Class