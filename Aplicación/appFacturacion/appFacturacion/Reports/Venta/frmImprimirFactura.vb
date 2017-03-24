Public Class frmImprimirFactura
    Public idventa As String
    Sub MostrarInforme()
        Try
            Using db As New CodeFirst
                Dim rpt As New rptImprimirFactura
                rpt.SetDataSource((From ven In db.VENTAS Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals ven.IDEMPLEADO Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join det In db.DETALLES_VENTAS On ven.IDVENTA Equals det.IDVENTA Join exi In db.EXISTENCIAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join pro In db.PRODUCTOS On exi.IDPRODUCTO Equals pro.IDPRODUCTO Where ven.IDVENTA = Me.idventa And ven.ANULADO = "N" Select IDFACTURA = ven.IDVENTA, BODEGA = ser.BODEGA.N_BODEGA & " | " & ser.BODEGA.DESCRIPCION, SERIE = ser.NOMBRE, N_VENDEDOR = tra.N_TRABAJADOR, VENDEDOR = tra.NOMBRES & " " & tra.APELLIDOS, N_CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.CLIENTE.N_CLIENTE, ""), CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS, ven.CLIENTECONTADO), N_FACTURA = ven.CONSECUTIVO, FECHA = ven.FECHAFACTURA, CONDICION = If(ven.CREDITO, "Crédito", "Contado"), MARCA = pro.MARCA.DESCRIPCION, ALTERNO = pro.IDALTERNO, ORIGINAL = pro.IDORIGINAL, pro.DESCRIPCION, det.CANTIDAD, PRECIO = det.PRECIOUNITARIO_C, SUBTOTAL_DETALLE = det.TOTAL_C, SUBTOTAL_FACTURA = ven.SUBTOTAL_C, DESCUENTO = ven.DESCUENTO_DIN_C, IVA = ven.IVA_DIN_C, ven.TOTAL_C).ToList())
                CrystalReportViewer1.ReportSource = rpt
                rpt = Nothing
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