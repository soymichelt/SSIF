Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmImprimirVenta

    Public idventa As String

    Private Sub frmImprimirEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "SalePrintReport",
            "Load",
            "Load SalePrintReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Try
            Using db As New CodeFirst
                Dim v = db.Ventas.Where(Function(f) f.IDVENTA = Me.idventa).FirstOrDefault
                If Not v Is Nothing Then
                    If v.ANULADO = "N" Then
                        Dim rpt As New rptImprimirVenta
                        Config.CrystalTitle("FACTURA N° " & v.Serie.NOMBRE & " " & v.CONSECUTIVO, rpt)
                        rpt.SetDataSource((From ven In db.Ventas Join det In db.VentasDetalles On ven.IDVENTA Equals det.IDVENTA Join ser In db.Series On ven.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where ven.IDVENTA = Me.idventa Select bod, det, ven, exi, pro, ser, _N_VENDEDOR = ven.Empleado.N_TRABAJADOR, _VENDEDOR = ven.Empleado.NOMBRES & " " & ven.Empleado.APELLIDOS, _N_CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.Cliente.N_CLIENTE, ""), _CLIENTE = If(Not ven.IDCLIENTE Is Nothing, ven.Cliente.NOMBRES & " " & ven.Cliente.APELLIDOS, ven.CLIENTECONTADO) Select IDCOMPRA = ven.IDVENTA, BODEGA = bod.N_BODEGA & " | " & bod.DESCRIPCION, SERIE = ser.NOMBRE, ven.CONSECUTIVO, FECHA = ven.FECHAFACTURA, VENDEDOR = _N_VENDEDOR & " " & _VENDEDOR, CLIENTE = If(_N_CLIENTE <> "", _N_CLIENTE & " " & _CLIENTE, _CLIENTE), CONDICION = If(ven.CREDITO, "CRÉDITO", "CONTADO"), MONEDA = If(ven.MONEDA.Equals(Config.cordoba), "CÓRDOBA(C$)", If(ven.MONEDA.Equals(Config.dolar), "DÓLAR($)", "")), ven.CONCEPTO, pro.IDALTERNO, pro.DESCRIPCION, CANTIDAD = det.CANTIDAD, PRECIO = det.PRECIOUNITARIO_C, DESCUENTO = det.DESCUENTO_DIN_TOTAL_C, SUBTOTAL = det.SUBTOTAL_C, IVA = det.IVA_DIN_TOTAL_C, TOTAL = det.TOTAL_C, DESCUENTO_NETO = ven.DESCUENTO_DIN_C, SUBTOTAL_NETO = ven.SUBTOTAL_C, IVA_NETO = ven.IVA_DIN_C, TOTAL_NETO = ven.TOTAL_C, REIMPRESION = If(ven.REIMPRESION.Equals("S"), "COPIA", "ORIGINAL")).ToList())
                        CrystalReportViewer1.ReportSource = rpt

                        v.REIMPRESION = "S"
                        db.Entry(v).State = Entity.EntityState.Modified
                        db.SaveChanges()

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