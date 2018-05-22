Imports Sadara.Models.V1.Database

Public Class frmImprimirVentaFormatoCarta

    Public idventa As String

    Private Sub frmImprimirVentaFormatoCarta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "SaleLetterFormatPrintReport",
            "Load",
            "Load SaleLetterFormatPrintReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Try
            Using db As New CodeFirst
                Dim v = db.Ventas.Where(Function(f) f.IDVENTA = Me.idventa).FirstOrDefault
                If Not v Is Nothing Then
                    If v.ANULADO = "N" Then
                        Dim rpt As New rptImprimirFacturaFormatoCarta
                        'Config.CrystalTitle("FACTURA N° " & v.Serie.NOMBRE & " " & v.CONSECUTIVO, rpt)
                        rpt.SetDataSource((From ven In db.Ventas Join det In db.VentasDetalles On ven.IDVENTA Equals det.IDVENTA Join ser In db.Series On ven.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where ven.IDVENTA = Me.idventa Select bod, det, ven, exi, pro, ser, _N_VENDEDOR = ven.Empleado.N_TRABAJADOR, _VENDEDOR = ven.Empleado.NOMBRES & " " & ven.Empleado.APELLIDOS, _N_CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.Cliente.N_CLIENTE, ""), _CLIENTE = If(Not ven.IDCLIENTE Is Nothing, If(ven.Cliente.TIPOPERSONA = "Natural" Or ven.Cliente.RAZONSOCIAL.Trim() <> "", ven.Cliente.NOMBRES & " " & ven.Cliente.APELLIDOS, ven.Cliente.RAZONSOCIAL), ven.CLIENTECONTADO) Select Dia = ven.FECHAFACTURA.Day, Mes = ven.FECHAFACTURA.Month, Año = ven.FECHAFACTURA.Year, Contado = If(ven.CREDITO, "", "x"), Credito = If(ven.CREDITO, "x", ""), Cliente = _N_CLIENTE & " " & _CLIENTE, Direccion = If(ven.Cliente IsNot Nothing, ven.Cliente.DOMICILIO, ""), Vendedor = _N_VENDEDOR & " " & _VENDEDOR, Codigo = pro.IDALTERNO, UnidadMedida = If(pro.UnidadMedida IsNot Nothing, pro.UnidadMedida.DESCRIPCION, ""), Cantidad = det.CANTIDAD, Descripcion = pro.DESCRIPCION, PrecioUnitario = If(ven.MONEDA.Equals(Config.cordoba), det.PRECIOUNITARIO_C, det.PRECIOUNITARIO_D), PrecioTotal = If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, det.SUBTOTAL_D), SubTotal = If(ven.MONEDA.Equals(Config.cordoba), ven.SUBTOTAL_C, ven.SUBTOTAL_D), DescuentoPorcentaje = ven.DESCUENTO_POR_FACT, DescuentoTotal = If(ven.MONEDA.Equals(Config.cordoba), ven.DESCUENTO_DIN_C, ven.DESCUENTO_DIN_D), IVA = If(ven.MONEDA.Equals(Config.cordoba), ven.IVA_DIN_C, ven.IVA_DIN_D), Total = If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D)).ToList())
                        CrystalReportViewer1.ReportSource = rpt
                    Else
                        MessageBox.Show("Error, No se puede imprimir esta Venta por que ha sido Anulada.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta Venta.")
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            Me.Close()
        End Try

    End Sub
End Class