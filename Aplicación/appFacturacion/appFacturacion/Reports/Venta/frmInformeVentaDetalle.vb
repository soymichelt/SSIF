Public Class frmInformeVentaDetalle

    Dim FormLoad As Boolean = False

    Sub Lista(ByVal Fecha1 As DateTime, ByVal Fecha2 As DateTime, Optional ByVal IDBodega As String = "", Optional ByVal IDSerie As String = "", Optional ByVal NEmpleado As String = "", Optional ByVal Empleado As String = "", Optional ByVal NCliente As String = "", Optional ByVal Cliente As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (((From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE IsNot Nothing And ven.CLIENTE.N_CLIENTE.Contains(NCliente) And (ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS).Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, (det.SUBTOTAL_D * Config.tazadecambio))), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D * Config.tazadecambio)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D * Config.tazadecambio)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL - DESCUENTO).ToList).Union((From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE Is Nothing And NCliente = "" And ven.CLIENTECONTADO.Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C + det.DESCUENTO_DIN_TOTAL_C, (det.SUBTOTAL_D * Config.tazadecambio) + (det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio))), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D * Config.tazadecambio)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D * Config.tazadecambio)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).ToList)).ToList
                If Config.Empresa.MonedaInventario.Equals(Config.cordoba) Then
                    If rdContado.Checked Then
                        consulta = (From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And Not ven.CREDITO And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE IsNot Nothing And ven.CLIENTE.N_CLIENTE.Contains(NCliente) And (ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS).Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, (det.SUBTOTAL_D * Config.tazadecambio))), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D * Config.tazadecambio)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D * Config.tazadecambio)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).Union(From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And Not ven.CREDITO And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE Is Nothing And NCliente = "" And ven.CLIENTECONTADO.Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C + det.DESCUENTO_DIN_TOTAL_C, (det.SUBTOTAL_D * Config.tazadecambio) + (det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio))), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D * Config.tazadecambio)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D * Config.tazadecambio)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).ToList
                    ElseIf rdCredito.Checked Then
                        consulta = (From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And ven.CREDITO And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE IsNot Nothing And ven.CLIENTE.N_CLIENTE.Contains(NCliente) And (ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS).Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, (det.SUBTOTAL_D * Config.tazadecambio))), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D * Config.tazadecambio)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D * Config.tazadecambio)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).ToList
                    End If
                Else
                    consulta = (From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE IsNot Nothing And ven.CLIENTE.N_CLIENTE.Contains(NCliente) And (ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS).Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C / Config.tazadecambio, det.DESCUENTO_DIN_TOTAL_D)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), (det.SUBTOTAL_C / Config.tazadecambio), det.SUBTOTAL_D)), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C / Config.tazadecambio, det.IVA_DIN_TOTAL_D)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C / Config.tazadecambio, det.TOTAL_D)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL - DESCUENTO).Union(From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE Is Nothing And NCliente = "" And ven.CLIENTECONTADO.Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C + det.DESCUENTO_DIN_TOTAL_C, (det.SUBTOTAL_D * Config.tazadecambio) + (det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio))), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D * Config.tazadecambio)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D * Config.tazadecambio)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).ToList
                    If rdContado.Checked Then
                        consulta = (From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And Not ven.CREDITO And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE IsNot Nothing And ven.CLIENTE.N_CLIENTE.Contains(NCliente) And (ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS).Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), (det.SUBTOTAL_C / Config.tazadecambio), det.SUBTOTAL_D)), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C / Config.tazadecambio, det.IVA_DIN_TOTAL_D)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C / Config.tazadecambio, det.TOTAL_D)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).Union(From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And Not ven.CREDITO And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE Is Nothing And NCliente = "" And ven.CLIENTECONTADO.Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C + det.DESCUENTO_DIN_TOTAL_C, (det.SUBTOTAL_D * Config.tazadecambio) + (det.DESCUENTO_DIN_TOTAL_D * Config.tazadecambio))), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D * Config.tazadecambio)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D * Config.tazadecambio)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).ToList
                    ElseIf rdCredito.Checked Then
                        consulta = (From pro In db.PRODUCTOS Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_VENTAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join ven In db.VENTAS On ven.IDVENTA Equals det.IDVENTA Join ser In db.SERIES On ven.IDSERIE Equals ser.IDSERIE Join bod In db.BODEGAS On ser.IDBODEGA Equals bod.IDBODEGA Where ven.ANULADO = "N" And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And bod.IDBODEGA.Contains(IDBodega) And ser.IDSERIE.Contains(IDSerie) And ven.CREDITO And ven.EMPLEADO.N_TRABAJADOR.Contains(NEmpleado) And (ven.EMPLEADO.NOMBRES & " " & ven.EMPLEADO.APELLIDOS).Contains(Empleado) And ven.IDCLIENTE IsNot Nothing And ven.CLIENTE.N_CLIENTE.Contains(NCliente) And (ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS).Contains(Cliente) Group By pro.IDALTERNO, pro.DESCRIPCION Into COSTOTOTAL = Sum(det.COSTO * det.CANTIDAD), CANTIDAD = Sum(det.CANTIDAD), DESCUENTO = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D)), SUBTOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), (det.SUBTOTAL_C / Config.tazadecambio), det.SUBTOTAL_D)), IVA = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C / Config.tazadecambio, det.IVA_DIN_TOTAL_D)), TOTAL = Sum(If(ven.MONEDA.Equals(Config.cordoba), det.TOTAL_C / Config.tazadecambio, det.TOTAL_D)) Select IDALTERNO, DESCRIPCION, COSTOPROMEDIO = COSTOTOTAL / CANTIDAD, COSTOTOTAL, PRECIOPROMEDIO = SUBTOTAL / CANTIDAD, CANTIDAD, DESCUENTO, SUBTOTAL, IVA, TOTAL, UTILIDAD = SUBTOTAL - COSTOTOTAL).ToList
                    End If
                End If
                'Dim sAgg = (Aggregate agg In consulta Into DESCUENTO = Sum(agg.DESCUENTO), COSTOTOTAL = Sum(agg.COSTOTOTAL), SUBTOTAL = Sum(agg.SUBTOTAL), IVA = Sum(agg.IVA), TOTAL = Sum(agg.TOTAL), UTILIDAD = Sum(agg.UTILIDAD))

                txtDescuento.Value = consulta.Sum(Function(f) f.DESCUENTO)
                txtCostoTotal.Value = consulta.Sum(Function(f) f.COSTOTOTAL)
                txtSubtotal.Value = consulta.Sum(Function(f) f.SUBTOTAL)
                txtIva.Value = consulta.Sum(Function(f) f.IVA)
                txtTotal.Value = consulta.Sum(Function(f) f.TOTAL)
                txtUtilidad.Value = consulta.Sum(Function(f) f.UTILIDAD)
                If dtRegistro.Visible Then
                    dtRegistro.DataSource = consulta.ToList
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).HeaderText = vbNewLine & "ID ALTERNO" & vbNewLine : dtRegistro.Columns(0).Width = 145
                        dtRegistro.Columns(1).HeaderText = "DESCRIPCIÓN DEL PRODUCTO" : dtRegistro.Columns(1).Width = 250
                        dtRegistro.Columns(2).HeaderText = "COSTO PROMEDIO" : dtRegistro.Columns(2).Width = 145 : dtRegistro.Columns(2).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(3).HeaderText = "COSTO TOTAL" : dtRegistro.Columns(3).Width = 145 : dtRegistro.Columns(3).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(4).HeaderText = "PRECIO PROMEDIO" : dtRegistro.Columns(4).Width = 145 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(5).Width = 145 : dtRegistro.Columns(5).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(6).Width = 145 : dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(7).Width = 145 : dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(8).Width = 145 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(9).Width = 145 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(10).Width = 145 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                        Next
                    End If
                Else
                    Dim rpt As New rptInformeVentaDetalle
                    Config.CrystalTitle("VENTA DETALLADA", rpt)
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    band = rpt.Section2.ReportObjects("txtFecha1") : band.Text = dtpFechaInicial.Value.ToLongDateString()
                    band = rpt.Section2.ReportObjects("txtFecha2") : band.Text = dtpFechaFinal.Value.ToLongDateString()
                    If IDBodega <> "" Then
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = cmbBodega.Text
                    Else
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = "%Todos%"
                    End If
                    If IDSerie <> "" Then
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = cmbSerie.Text
                    Else
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = "%Todos%"
                    End If
                    If NEmpleado <> "" Then
                        band = rpt.Section2.ReportObjects("txtVendedor") : band.Text = txtNombreVendedor.Text
                    Else
                        band = rpt.Section2.ReportObjects("txtVendedor") : band.Text = "%Todos%"
                    End If
                    If rdContado.Checked Then
                        band = rpt.Section2.ReportObjects("txtTipoFactura") : band.Text = "Contado"
                    ElseIf rdCredito.Checked Then
                        band = rpt.Section2.ReportObjects("txtTipoFactura") : band.Text = "Crédito"
                    Else
                        band = rpt.Section2.ReportObjects("txtTipoFactura") : band.Text = "%Todos%"
                    End If
                    If NCliente <> "" Then
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = NCliente
                    Else
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = "%Todos%"
                    End If
                    If NCliente <> "" Then
                        band = rpt.Section2.ReportObjects("txtNombreCliente") : band.Text = Cliente
                    Else
                        band = rpt.Section2.ReportObjects("txtNombreCliente") : band.Text = "%Todos%"
                    End If
                    rpt.SetDataSource(consulta.ToList)
                    CrystalReportViewer1.ReportSource = rpt
                    rpt = Nothing : band = Nothing
                End If
                consulta = Nothing ': sAgg = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Sub Filtrar()
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString(), txtIdVendedor.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
            Else
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), , txtIdVendedor.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        Else
            Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", , , txtIdVendedor.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
        End If
    End Sub

    Private Sub frmInformeVentaDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            frmInformeVentaDetalle_Resize(Nothing, Nothing)
            txtDescuento.Value = 0.0
            txtCostoTotal.Value = 0.0
            txtSubtotal.Value = 0.0
            txtIva.Value = 0.0
            txtTotal.Value = 0.0
            txtUtilidad.Value = 0.0

            dtpFechaInicial.Value = DateTime.Now
            dtpFechaFinal.Value = DateTime.Now
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.BODEGAS Select bod.IDBODEGA, NOMBRE = bod.N_BODEGA & " - " & bod.DESCRIPCION).ToList() : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.DisplayMember = "NOMBRE" : cmbBodega.SelectedIndex = -1
                cmbSerie.DataSource = Nothing
            End Using

            'Lista(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Sub llenarserie(ByVal bodega As String)
        Try
            Using db As New CodeFirst
                cmbSerie.DataSource = db.SERIES.Where(Function(f) f.ACTIVO = "S" And f.OPERACION = "VENTA" And f.IDBODEGA = bodega).ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                llenarserie(cmbBodega.SelectedValue.ToString())
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), , txtIdVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                cmbSerie.Focus()
            Else
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", , txtIdVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Private Sub cmbBodega_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                llenarserie(cmbBodega.SelectedValue.ToString())
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), , txtIdVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                cmbSerie.Focus()
            Else
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", , txtIdVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                If cmbBodega.Text.Trim = "" Then
                    txtIdVendedor.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString(), txtIdVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                txtIdVendedor.Focus()
            End If
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        CrystalReportViewer1.Visible = False
        Me.Filtrar()
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        If Me.FormLoad Then
            'cargar
            Me.Filtrar()
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If Me.FormLoad Then
            'cargar
            Me.Filtrar()
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        dtpFechaInicial.Value = DateTime.Now
        dtpFechaFinal.Value = DateTime.Now
        cmbBodega.SelectedIndex = -1
        cmbSerie.SelectedIndex = -1
        txtIdVendedor.Clear()
        txtIdVendedor.Clear()
        txtNombreVendedor.Clear()
        txtNCliente.Clear()
        txtNombreCliente.Clear()
        Lista(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        CrystalReportViewer1.Visible = True
        'cargar
        Me.Filtrar()
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If Me.FormLoad Then
            If rdContado.Checked Then
                'cargar
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If Me.FormLoad Then
            If rdCredito.Checked Then
                'cargar
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        If Me.FormLoad Then
            If rdTodos.Checked Then
                'cargar
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub frmInformeVentaDetalle_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        gbTipoVenta.Left = PanelEx4.Width - gbTipoVenta.Width - 4
    End Sub

    Private Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        If tbFiltros.Visible Then
            TabControl1.SelectedTabIndex = 0
            tbFiltros.Visible = False
            tcpFiltros.Visible = False
            Me.FormLoad = False
            cmbBodega.SelectedIndex = -1
            cmbSerie.SelectedIndex = -1
            txtNCliente.Clear()
            txtNombreCliente.Clear()
            txtIdVendedor.Clear()
            txtNombreVendedor.Clear()
            Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59")
            Me.FormLoad = True
        Else
            tbFiltros.Visible = True
            tcpFiltros.Visible = True
            TabControl1.SelectedTabIndex = 1
            cmbBodega.Focus()
        End If
    End Sub

    Private Sub txtNCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNCliente.KeyDown, txtNombreVendedor.KeyDown, txtNombreCliente.KeyDown, txtIdVendedor.KeyDown
        If e.KeyData = Keys.Enter Then
            If dtRegistro.Visible Then
                Me.Filtrar()
            Else
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub frmInformeVentaDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.B : btBuscar_Click(Nothing, Nothing)
                Case Keys.Delete : btLimpiar_Click(Nothing, Nothing)
                Case Keys.A : btBusqueda_Click(Nothing, Nothing)
                Case Keys.P : btImprimir_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

End Class