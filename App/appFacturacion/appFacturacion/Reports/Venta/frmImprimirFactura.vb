Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmImprimirFactura
    Public idventa As String
    Sub MostrarInforme()
        Try
            Using db As New CodeFirst
                Dim rpt As New rptImprimirFactura
                rpt.SetDataSource((From ven In db.Ventas Join tra In db.Empleados On tra.IDEMPLEADO Equals ven.IDEMPLEADO Join ser In db.Series On ven.IDSERIE Equals ser.IDSERIE Join det In db.VentasDetalles On ven.IDVENTA Equals det.IDVENTA Join exi In db.Existencias On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Where ven.IDVENTA = Me.idventa And ven.ANULADO = "N" Select IDFACTURA = ven.IDVENTA, BODEGA = ser.Bodega.N_BODEGA & " | " & ser.Bodega.DESCRIPCION, SERIE = ser.NOMBRE, N_VENDEDOR = tra.N_TRABAJADOR, VENDEDOR = tra.NOMBRES & " " & tra.APELLIDOS, N_CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.Cliente.N_CLIENTE, ""), CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.Cliente.NOMBRES & " " & ven.Cliente.APELLIDOS, ven.CLIENTECONTADO), N_FACTURA = ven.CONSECUTIVO, FECHA = ven.FECHAFACTURA, CONDICION = If(ven.CREDITO, "Crédito", "Contado"), MARCA = pro.Marca.DESCRIPCION, ALTERNO = pro.IDALTERNO, ORIGINAL = pro.IDORIGINAL, pro.DESCRIPCION, det.CANTIDAD, PRECIO = det.PRECIOUNITARIO_C, SUBTOTAL_DETALLE = det.TOTAL_C, SUBTOTAL_FACTURA = ven.SUBTOTAL_C, DESCUENTO = ven.DESCUENTO_DIN_C, IVA = ven.IVA_DIN_C, ven.TOTAL_C).ToList())
                CrystalReportViewer1.ReportSource = rpt
                rpt = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmImprimirFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "SalePrintReport",
            "Load",
            "Load SalePrintReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        MostrarInforme()
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(source As Object, e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        MostrarInforme()
    End Sub

End Class