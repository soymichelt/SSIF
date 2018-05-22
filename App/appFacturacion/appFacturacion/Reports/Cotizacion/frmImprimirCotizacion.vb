Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmImprimirCotizacion
    Public ID As String
    Private Sub frmImprimirEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "QuotationPrintReport",
            "Load",
            "Load QuotationPrintReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Try
            Using db As New CodeFirst
                Dim cotizacion = db.Cotizaciones.Where(Function(f) f.IDCOTIZACION = Me.ID).FirstOrDefault
                If Not cotizacion Is Nothing Then
                    If cotizacion.ANULADO = "N" Then
                        Dim rpt As New rptImprimirCotizacion
                        Config.CrystalTitle("COTIZACIÓN", rpt)
                        rpt.SetDataSource((From cot In db.Cotizaciones Join det In db.CotizacionesDetalles On cot.IDCOTIZACION Equals det.IDCOTIZACION Join ser In db.Series On cot.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where cot.IDCOTIZACION = Me.ID Select bod, det, cot, exi, pro, ser, _N_VENDEDOR = cot.Empleado.N_TRABAJADOR, _VENDEDOR = cot.Empleado.NOMBRES & " " & cot.Empleado.APELLIDOS, _N_CLIENTE = If(Not cot.IDCLIENTE Is Nothing, cot.Cliente.N_CLIENTE, ""), _CLIENTE = If(Not cot.IDCLIENTE Is Nothing, cot.Cliente.NOMBRES & " " & cot.Cliente.APELLIDOS, cot.CLIENTECONTADO) Select IDCOMPRA = cot.IDCOTIZACION, BODEGA = bod.N_BODEGA & " " & bod.DESCRIPCION, SERIE = ser.NOMBRE, cot.CONSECUTIVO, FECHA = cot.FECHACOTIZACION, VENDEDOR = _N_VENDEDOR & " " & _VENDEDOR, CLIENTE = If(_N_CLIENTE <> "", _N_CLIENTE & " " & _CLIENTE, _CLIENTE), CONDICION = If(cot.CREDITO, "CRÉDITO", "CONTADO"), MONEDA = If(cot.MONEDA.Equals(Config.cordoba), "CÓRDOBA(C$)", If(cot.MONEDA.Equals(Config.dolar), "DÓLAR($)", "")), cot.CONCEPTO, pro.IDALTERNO, pro.DESCRIPCION, CANTIDAD = det.CANTIDAD, PRECIO = det.PRECIOUNITARIO_C, DESCUENTO = det.DESCUENTO_DIN_TOTAL_C, SUBTOTAL = det.SUBTOTAL_C, IVA = det.IVA_DIN_TOTAL_C, TOTAL = det.TOTAL_C, DESCUENTO_NETO = cot.DESCUENTO_DIN_C, SUBTOTAL_NETO = cot.SUBTOTAL_C, IVA_NETO = cot.IVA_DIN_C, TOTAL_NETO = cot.TOTAL_C).ToList())
                        CrystalReportViewer1.ReportSource = rpt
                        'If cotizacion.REIMPRESION <> "S" Then
                        '    cotizacion.REIMPRESION = "S" : db.Entry(cotizacion).State = EntityState.Modified : db.SaveChanges()
                        'End If
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

    Private Sub frmImprimirEntrada_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class