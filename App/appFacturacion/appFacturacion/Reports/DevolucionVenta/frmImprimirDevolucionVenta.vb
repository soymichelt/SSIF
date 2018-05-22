Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmImprimirDevolucionVenta
    Public iddevolucion As String
    Private Sub frmImprimirDevolucionVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "ReturnSalePrintReport",
            "Load",
            "Load ReturnSalePrintReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Try
            Using db As New CodeFirst
                Dim devolucion = db.VentasDevoluciones.Where(Function(f) f.IDDEVOLUCION = Me.iddevolucion).FirstOrDefault
                If Not devolucion Is Nothing Then
                    If devolucion.ANULADO = "N" Then
                        Dim rpt As New rptImprimirDevolucionVenta
                        Config.CrystalTitle("DEVOLUCIÓN DE VENTA", rpt)
                        rpt.SetDataSource((From dev In db.VentasDevoluciones Join det In db.VentasDevolucionesDetalles On dev.IDDEVOLUCION Equals det.IDDEVOLUCION Join ser In db.Series On dev.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where dev.IDDEVOLUCION = Me.iddevolucion Select bod, det, dev, exi, pro, ser, _N_VENDEDOR = dev.Empleado.N_TRABAJADOR, _VENDEDOR = dev.Empleado.NOMBRES & " " & dev.Empleado.APELLIDOS, _N_CLIENTE = If(Not dev.IDCLIENTE Is Nothing, dev.Cliente.N_CLIENTE, ""), _CLIENTE = If(Not dev.IDCLIENTE Is Nothing, dev.Cliente.NOMBRES & " " & dev.Cliente.APELLIDOS, dev.CLIENTECONTADO) Select IDCOMPRA = dev.IDDEVOLUCION, BODEGA = bod.N_BODEGA & " | " & bod.DESCRIPCION, SERIE = ser.NOMBRE, dev.CONSECUTIVO, FECHA = dev.FECHADEVOLUCION, VENDEDOR = _N_VENDEDOR & " " & _VENDEDOR, CLIENTE = _N_CLIENTE & " " & _CLIENTE, CONDICION = If(dev.CREDITO, "Crédito", "Contado"), MONEDA = If(dev.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), dev.CONCEPTO, pro.IDALTERNO, pro.DESCRIPCION, CANTIDAD = det.CANTIDAD, PRECIO = det.PRECIOUNITARIO_C, DESCUENTO = det.DESCUENTO_DIN_TOTAL_C, det.SUBTOTAL_C, IVA = det.IVA_DIN_TOTAL_C, det.TOTAL_C, DESCUENTO_NETO = dev.DESCUENTO_DIN_C, SUBTOTAL_NETO = dev.SUBTOTAL_C, IVA_NETO = dev.IVA_DIN_C, TOTAL_NETO = dev.TOTAL_C, REIMPRESION = If(dev.REIMPRESION.Equals("S"), "COPIA", "ORIGINAL")).ToList())
                        CrystalReportViewer1.ReportSource = rpt
                        If devolucion.REIMPRESION <> "S" Then
                            devolucion.REIMPRESION = "S" : db.Entry(devolucion).State = EntityState.Modified : db.SaveChanges()
                        End If
                    Else
                        MessageBox.Show("Error, No se puede imprimir esta Devolución de Venta por que ha sido Anulada.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta Devolución de Venta.")
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