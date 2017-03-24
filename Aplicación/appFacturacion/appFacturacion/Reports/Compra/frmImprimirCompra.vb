Public Class frmImprimirCompra
    Public idcompra As String
    Private Sub frmImprimirEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                Dim compra = db.COMPRAS.Where(Function(f) f.IDCOMPRA = Me.idcompra).FirstOrDefault
                If Not compra Is Nothing Then
                    If compra.ANULADO = "N" Then
                        Dim rpt As New rptImprimirCompra
                        Config.CrystalTitle("COMPRA DE MERCANCÍA", rpt)
                        rpt.SetDataSource((From com In db.COMPRAS Join det In db.DETALLES_COMPRAS On com.IDCOMPRA Equals det.IDCOMPRA Join ser In db.SERIES On com.IDSERIE Equals ser.IDSERIE Join exi In db.EXISTENCIAS On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.PRODUCTOS On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.BODEGAS On exi.IDBODEGA Equals bod.IDBODEGA Where com.IDCOMPRA = Me.idcompra Select bod, com, det, exi, pro, ser, _N_PROVEEDOR = If(Not com.IDPROVEEDOR Is Nothing, com.PROVEEDOR.N_PROVEEDOR, ""), _PROVEEDOR = If(Not com.IDPROVEEDOR Is Nothing, com.PROVEEDOR.NOMBRES & " " & com.PROVEEDOR.APELLIDOS, com.PROVEEDORCONTADO) Select com.IDCOMPRA, BODEGA = bod.N_BODEGA & " | " & bod.DESCRIPCION, SERIE = ser.NOMBRE, com.CONSECUTIVO, com.N_COMPRA, PROVEEDOR = If(_N_PROVEEDOR <> "", _N_PROVEEDOR & " " & _PROVEEDOR, _PROVEEDOR), FECHA = com.FECHACOMPRA, com.FECHADEVOLUCION, N_EMPLEADO = com.EMPLEADO.N_TRABAJADOR, EMPLEADO = com.EMPLEADO.NOMBRES & " " & com.EMPLEADO.APELLIDOS, CONDICION = If(com.CREDITO, "Crédito", "Contado"), MONEDA = If(com.MONEDA.Equals(Config.cordoba), "Cordoba", "Dolar"), com.CONCEPTO, pro.IDALTERNO, pro.DESCRIPCION, det.CANTIDAD, PRECIO = If(com.MONEDA.Equals(Config.cordoba), det.PRECIOUNITARIO_C, det.PRECIOUNITARIO_D), DESCUENTO = If(com.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D), SUBTOTAL = If(com.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, det.SUBTOTAL_D), IVA = If(com.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D), TOTAL = If(com.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D), DESCUENTO_NETO = If(com.MONEDA.Equals(Config.cordoba), com.DESCUENTO_DIN_C, com.DESCUENTO_DIN_D), SUBTOTAL_NETO = If(com.MONEDA.Equals(Config.cordoba), com.SUBTOTAL_C, com.SUBTOTAL_D), IVA_NETO = If(com.MONEDA.Equals(Config.cordoba), com.IVA_DIN_C, com.IVA_DIN_D), TOTAL_NETO = If(com.MONEDA.Equals(Config.cordoba), com.TOTAL_C, com.TOTAL_D), REIMPRESION = If(com.REIMPRESION.Equals("S"), "COPIA", "ORIGINAL")).ToList())
                        CrystalReportViewer1.ReportSource = rpt
                        If compra.REIMPRESION <> "S" Then
                            compra.REIMPRESION = "S" : db.Entry(compra).State = EntityState.Modified : db.SaveChanges()
                        End If
                    Else
                        MessageBox.Show("Error, No se puede imprimir esta Requisa de Compra por que ha sido Anulada.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta Requisa de Compra.")
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