Public Class frmInformeVentas
    Dim FormLoad As Boolean

    'variables totales
    Dim dc As Decimal : Dim dd As Decimal
    Dim sc As Decimal : Dim sd As Decimal
    Dim ic As Decimal : Dim id As Decimal
    Dim tc As Decimal : Dim td As Decimal
    'fin variables totales

    Sub Lista(ByVal Fecha1 As DateTime, ByVal Fecha2 As DateTime, Optional ByVal bodegap As String = "", Optional ByVal seriep As String = "", Optional ByVal IdEmpleadoP As String = "", Optional ByVal EmpleadoP As String = "", Optional ByVal IdClienteP As String = "", Optional ByVal ClienteP As String = "")
        Try
            Using db As New CodeFirst
                If dtRegistro.Visible Then
                    Dim consulta = ((From ven In db.Ventas Join ser In db.Series On ser.IDSERIE Equals ven.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals ven.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals ven.IDEMPLEADO Where ven.IDCLIENTE IsNot Nothing And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) And tra.N_TRABAJADOR.Contains(IdEmpleadoP) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(EmpleadoP) Select ANULADO = If(ven.ANULADO.Equals("S"), "Anulado", ""), ven.IDVENTA, SERIE = ser.NOMBRE, ven.CONSECUTIVO, ven.FECHAFACTURA, N_CLIENTE = If(ven.ANULADO.Equals("N"), cli.N_CLIENTE, ""), CLIENTE = If(ven.ANULADO.Equals("N"), cli.NOMBRES & " " & cli.APELLIDOS, ""), N_VENDEDOR = If(ven.ANULADO.Equals("N"), tra.N_TRABAJADOR, ""), VENDEDOR = If(ven.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), CONDICION = If(ven.ANULADO.Equals("N"), If(ven.CREDITO, "Crédito", "Contado"), ""), FECHA_VENCIMIENTO = If(ven.ANULADO.Equals("N"), ven.FECHACREDITOVENCIMIENTO, Nothing), MÓNEDA = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.dolar), "Dólar", "Córdoba"), ""), TAZACAMBIO = If(ven.ANULADO.Equals("N"), ven.TAZACAMBIO, Nothing), DESCUENTO_DIN = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.DESCUENTO_DIN_C, ven.DESCUENTO_DIN_D), Nothing), SUBTOTAL = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.SUBTOTAL_C, ven.SUBTOTAL_D), Nothing), IVA_DIN = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.IVA_DIN_C, ven.IVA_DIN_D), Nothing), TOTAL = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D), Nothing), ven.N, ven.CREDITO, MON = ven.MONEDA) _
                                   .Union _
                                   (From ven In db.Ventas Join ser In db.Series On ser.IDSERIE Equals ven.IDSERIE Join tra In db.Empleados On tra.IDEMPLEADO Equals ven.IDEMPLEADO Where ven.IDCLIENTE Is Nothing Where ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) And tra.N_TRABAJADOR.Contains(IdEmpleadoP) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(EmpleadoP) Select ANULADO = If(ven.ANULADO.Equals("S"), "Anulado", ""), ven.IDVENTA, SERIE = ser.NOMBRE, ven.CONSECUTIVO, ven.FECHAFACTURA, N_CLIENTE = "", CLIENTE = If(ven.ANULADO.Equals("N"), ven.CLIENTECONTADO, ""), N_VENDEDOR = If(ven.ANULADO.Equals("N"), tra.N_TRABAJADOR, ""), VENDEDOR = If(ven.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), CONDICION = If(ven.ANULADO.Equals("N"), If(ven.CREDITO, "Crédito", "Contado"), ""), FECHA_VENCIMIENTO = If(ven.ANULADO.Equals("N"), ven.FECHACREDITOVENCIMIENTO, Nothing), MÓNEDA = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), ""), TAZACAMBIO = If(ven.ANULADO.Equals("N"), ven.TAZACAMBIO, Nothing), DESCUENTO_DIN = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.DESCUENTO_DIN_C, ven.DESCUENTO_DIN_D), Nothing), SUBTOTAL = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.SUBTOTAL_C, ven.SUBTOTAL_D), Nothing), IVA_DIN = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.IVA_DIN_C, ven.IVA_DIN_D), Nothing), TOTAL = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D), Nothing), ven.N, ven.CREDITO, MON = ven.MONEDA))

                    If rdMCordoba.Checked Then 'moneda
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.cordoba) And f.ANULADO.Equals(""))
                    ElseIf rdMDolar.Checked Then
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.dolar) And f.ANULADO.Equals(""))
                    End If
                    If rdContado.Checked Then 'condicion de pago
                        consulta = consulta.Where(Function(f) f.CREDITO = False And f.ANULADO.Equals(""))
                    ElseIf rdCredito.Checked Then
                        consulta = consulta.Where(Function(f) f.CREDITO And f.ANULADO.Equals(""))
                    End If
                    If IdClienteP.Trim <> "" Then 'filtro cliente
                        consulta = consulta.Where(Function(f) f.N_CLIENTE.Contains(IdClienteP) And f.ANULADO.Equals(""))
                    End If
                    If ClienteP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.CLIENTE.Contains(ClienteP) And f.ANULADO.Equals(""))
                    End If
                    If IdEmpleadoP.Trim <> "" Then 'filtro vendedor
                        consulta = consulta.Where(Function(f) f.N_VENDEDOR.Contains(IdEmpleadoP) And f.ANULADO.Equals(""))
                    End If
                    If EmpleadoP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.VENDEDOR.Contains(EmpleadoP) And f.ANULADO.Equals(""))
                    End If

                    dtRegistro.DataSource = consulta.OrderBy(Function(f) f.N).ToList
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = ""
                        dtRegistro.Columns(1).Visible = False : dtRegistro.Columns(1).DefaultCellStyle.ForeColor = Color.White
                        dtRegistro.Columns(3).HeaderText = vbNewLine & "Nº FACTURA" & vbNewLine
                        dtRegistro.Columns(4).HeaderText = "FECHA"
                        dtRegistro.Columns(5).HeaderText = "Nº CLIENTE" : dtRegistro.Columns(5).Width = 110
                        dtRegistro.Columns(6).HeaderText = "NOMBRES Y APELLIDOS DEL CLIENTE" : dtRegistro.Columns(6).Width = 250
                        dtRegistro.Columns(7).HeaderText = "Nº VENDEDOR" : dtRegistro.Columns(7).Width = 110
                        dtRegistro.Columns(8).HeaderText = "NOMBRES Y APELLIDOS DEL VENDEDOR" : dtRegistro.Columns(8).Width = 250
                        dtRegistro.Columns(9).HeaderText = "CONDICIÓN" : dtRegistro.Columns(9).Width = 110
                        dtRegistro.Columns(10).HeaderText = "VENCE"
                        dtRegistro.Columns(11).HeaderText = "MÓNEDA"
                        dtRegistro.Columns(12).HeaderText = "T / C"
                        dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(13).HeaderText = "DESCUENTO"
                        dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(14).HeaderText = "SUB-TOTAL"
                        dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(15).HeaderText = "IVA"
                        dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(17).Visible = False
                        dtRegistro.Columns(18).Visible = False
                        dtRegistro.Columns(19).Visible = False
                    End If
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                    Next
                    If consulta.Count() > 0 Then
                        Dim cordoba = consulta.Where(Function(f) f.MON = Config.cordoba) : Dim dolar = consulta.Where(Function(f) f.MON = Config.dolar)
                        Me.dc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.DESCUENTO_DIN), 0.0) : Me.sc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.SUBTOTAL), 0.0) : Me.ic = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.IVA_DIN), 0.0) : Me.tc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.TOTAL), 0.0)
                        Me.dd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.DESCUENTO_DIN), 0.0) : Me.sd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.SUBTOTAL), 0.0) : Me.id = If(dolar.Count() > 0, dolar.Sum(Function(f) f.IVA_DIN), 0.0) : Me.td = If(dolar.Count() > 0, dolar.Sum(Function(f) f.TOTAL), 0.0)
                        'cordoba
                        txtDescuento.Value = Me.dc : txtSubtotal.Value = Me.sc : txtIva.Value = Me.ic : txtTotal.Value = Me.tc
                        'dolar
                        txtDescuentoDolar.Value = Me.dd : txtSubTotalDolar.Value = Me.sd : txtIvaDolar.Value = Me.id : txtTotalDolar.Value = Me.td
                        cordoba = Nothing : dolar = Nothing
                    Else
                        txtDescuento.Value = 0 : txtSubtotal.Value = 0 : txtIva.Value = 0 : txtTotal.Value = 0
                        txtDescuentoDolar.Value = 0 : txtSubTotalDolar.Value = 0 : txtIvaDolar.Value = 0 : txtTotalDolar.Value = 0
                    End If
                    If dtRegistro.Rows.Count = 0 Then
                        dtDetalle.DataSource = Nothing
                        expDetalle.TitleText = "Mostrar detalle de la factura seleccionada"
                    End If
                Else
                    Dim consulta = (From ven In db.Ventas Join ser In db.Series On ser.IDSERIE Equals ven.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals ven.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals ven.IDEMPLEADO Where ven.IDCLIENTE IsNot Nothing And ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) And tra.N_TRABAJADOR.Contains(IdEmpleadoP) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(EmpleadoP) Select IDBodega = ser.IDBODEGA, Bodega = ser.Bodega.N_BODEGA & " - " & ser.Bodega.DESCRIPCION, ID = ven.IDVENTA, Serie = ser.NOMBRE, ven.CONSECUTIVO, Fecha = ven.FECHAFACTURA, N_Cliente = cli.N_CLIENTE, Cliente = cli.NOMBRES & " " & cli.APELLIDOS, N_Vendedor = tra.N_TRABAJADOR, Vendedor = If(ven.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), Condicion = If(ven.CREDITO, "Crédito", "Contado"), FechaCreditoVencimiento = ven.FECHACREDITOVENCIMIENTO, Moneda = If(ven.MONEDA.Equals(Config.cordoba), "C$", "$"), TazaCambio = ven.TAZACAMBIO, Descuento = If(ven.MONEDA.Equals(Config.cordoba), ven.DESCUENTO_DIN_C, ven.DESCUENTO_DIN_D), SubTotal = If(ven.MONEDA.Equals(Config.cordoba), ven.SUBTOTAL_C, ven.SUBTOTAL_D), IVA = If(ven.MONEDA.Equals(Config.cordoba), ven.IVA_DIN_C, ven.IVA_DIN_D), Total = If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D), ven.N, ven.CREDITO, MON = ven.MONEDA) _
                                   .Union _
                                   (From ven In db.Ventas Join ser In db.Series On ser.IDSERIE Equals ven.IDSERIE Join tra In db.Empleados On tra.IDEMPLEADO Equals ven.IDEMPLEADO Where ven.IDCLIENTE Is Nothing Where ven.FECHAFACTURA >= Fecha1 And ven.FECHAFACTURA <= Fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) And tra.N_TRABAJADOR.Contains(IdEmpleadoP) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(EmpleadoP) Select IDBodega = ser.IDBODEGA, Bodega = ser.Bodega.N_BODEGA & " - " & ser.Bodega.DESCRIPCION, ID = ven.IDVENTA, Serie = ser.NOMBRE, ven.CONSECUTIVO, Fecha = ven.FECHAFACTURA, N_Cliente = "", Cliente = ven.CLIENTECONTADO, N_Vendedor = tra.N_TRABAJADOR, Vendedor = tra.NOMBRES & " " & tra.APELLIDOS, Condicion = If(ven.CREDITO, "Crédito", "Contado"), FechaCreditoVencimiento = ven.FECHACREDITOVENCIMIENTO, Moneda = If(ven.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), TazaCambio = ven.TAZACAMBIO, Descuento = If(ven.MONEDA.Equals(Config.cordoba), ven.DESCUENTO_DIN_C, ven.DESCUENTO_DIN_D), SubTotal = If(ven.MONEDA.Equals(Config.cordoba), ven.SUBTOTAL_C, ven.SUBTOTAL_D), IVA = If(ven.MONEDA.Equals(Config.cordoba), ven.IVA_DIN_C, ven.IVA_DIN_D), TOTAL = If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D), ven.N, ven.CREDITO, MON = ven.MONEDA)

                    If rdMCordoba.Checked Then 'moneda
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.cordoba))
                    ElseIf rdMDolar.Checked Then
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.dolar))
                    End If
                    If rdContado.Checked Then 'condicion de pago
                        consulta = consulta.Where(Function(f) f.CREDITO = False)
                    ElseIf rdCredito.Checked Then
                        consulta = consulta.Where(Function(f) f.CREDITO)
                    End If
                    If IdClienteP.Trim <> "" Then 'filtro cliente
                        consulta = consulta.Where(Function(f) f.N_Cliente.Contains(IdClienteP))
                    End If
                    If ClienteP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.Cliente.Contains(ClienteP))
                    End If
                    If IdEmpleadoP.Trim <> "" Then 'filtro vendedor
                        consulta = consulta.Where(Function(f) f.N_Vendedor.Contains(IdEmpleadoP))
                    End If
                    If EmpleadoP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.Vendedor.Contains(EmpleadoP))
                    End If
                    If consulta.Count() > 0 Then
                        Dim cordoba = consulta.Where(Function(f) f.MON = Config.cordoba) : Dim dolar = consulta.Where(Function(f) f.MON = Config.dolar)
                        Me.dc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.Descuento), 0.0) : Me.sc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.SubTotal), 0.0) : Me.ic = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.IVA), 0.0) : Me.tc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.Total), 0.0)
                        Me.dd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.Descuento), 0.0) : Me.sd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.SubTotal), 0.0) : Me.id = If(dolar.Count() > 0, dolar.Sum(Function(f) f.IVA), 0.0) : Me.td = If(dolar.Count() > 0, dolar.Sum(Function(f) f.Total), 0.0)
                        'cordoba
                        txtDescuento.Value = Me.dc : txtSubtotal.Value = Me.sc : txtIva.Value = Me.ic : txtTotal.Value = Me.tc
                        'dolar
                        txtDescuentoDolar.Value = Me.dd : txtSubTotalDolar.Value = Me.sd : txtIvaDolar.Value = Me.id : txtTotalDolar.Value = Me.td
                        cordoba = Nothing : dolar = Nothing
                    Else
                        txtDescuento.Value = 0 : txtSubtotal.Value = 0 : txtIva.Value = 0 : txtTotal.Value = 0
                        txtDescuentoDolar.Value = 0 : txtSubTotalDolar.Value = 0 : txtIvaDolar.Value = 0 : txtTotalDolar.Value = 0
                    End If
                    Dim rpt As New rptInformeFactura
                    Config.CrystalTitle("INFORME DE FACTURAS", rpt)
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    band = rpt.Section2.ReportObjects("txtFecha1") : band.Text = Fecha1.ToLongDateString()
                    band = rpt.Section2.ReportObjects("txtFecha2") : band.Text = Fecha2.ToLongDateString()
                    If bodegap <> "" Then
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = bodegap
                    Else
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = "%Todos%"
                    End If
                    If seriep <> "" Then
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = seriep
                    Else
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = "%Todos%"
                    End If
                    If IdEmpleadoP <> "" Then
                        band = rpt.Section2.ReportObjects("txtNEmpleado") : band.Text = IdEmpleadoP
                    Else
                        band = rpt.Section2.ReportObjects("txtNEmpleado") : band.Text = "%Todos%"
                    End If
                    If EmpleadoP <> "" Then
                        band = rpt.Section2.ReportObjects("txtEmpleado") : band.Text = EmpleadoP
                    Else
                        band = rpt.Section2.ReportObjects("txtEmpleado") : band.Text = "%Todos%"
                    End If
                    If IdClienteP <> "" Then
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = IdClienteP
                    Else
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = "%Todos%"
                    End If
                    If EmpleadoP <> "" Then
                        band = rpt.Section2.ReportObjects("txtCliente") : band.Text = EmpleadoP
                    Else
                        band = rpt.Section2.ReportObjects("txtCliente") : band.Text = "%Todos%"
                    End If
                    band = rpt.Section2.ReportObjects("txtFactura")
                    If rdContado.Checked Then
                        band.Text = "(FACTURAS DE CONTADO)"
                    ElseIf rdCredito.Checked Then
                        band.Text = "(FACTURAS DE CRÉDITO)"
                    Else
                        band.Text = "(TODAS LAS FACTURAS)"
                    End If

                    'totales en cordobas
                    band = rpt.Section5.ReportObjects("txtDescuentoC") : band.Text = dc.ToString(Config.f_m)
                    band = rpt.Section5.ReportObjects("txtSubTotalC") : band.Text = sc.ToString(Config.f_m)
                    band = rpt.Section5.ReportObjects("txtIvaC") : band.Text = ic.ToString(Config.f_m)
                    band = rpt.Section5.ReportObjects("txtTotalC") : band.Text = tc.ToString(Config.f_m)

                    'totales en cordobas
                    band = rpt.Section5.ReportObjects("txtDescuentoD") : band.Text = dd.ToString(Config.f_m)
                    band = rpt.Section5.ReportObjects("txtSubTotalD") : band.Text = sd.ToString(Config.f_m)
                    band = rpt.Section5.ReportObjects("txtIvaD") : band.Text = id.ToString(Config.f_m)
                    band = rpt.Section5.ReportObjects("txtTotalD") : band.Text = td.ToString(Config.f_m)


                    rpt.SetDataSource(consulta.ToList)
                    CrystalReportViewer1.ReportSource = rpt
                    CrystalReportViewer1.Zoom(75)
                    rpt = Nothing : band = Nothing : consulta = Nothing
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Sub ListaDetalle(ByVal id As String)
        Try
            Using db As New CodeFirst
                Dim v = (From ven In db.Ventas Join ser In db.Series On ven.IDSERIE Equals ser.IDSERIE Where ven.IDVENTA = id Select ven.IDVENTA, ven.ANULADO, SERIE = ser.NOMBRE, ven.CONSECUTIVO, ven.MONEDA).FirstOrDefault()
                If Not v Is Nothing Then
                    If v.ANULADO = "N" Then
                        expDetalle.TitleText = "Mostrar detalle de la factura '" & v.SERIE & " - " & v.CONSECUTIVO & "'"
                        dtDetalle.DataSource = (From mar In db.Marcas Join pro In db.Productos On mar.IDMARCA Equals pro.IDMARCA Join exi In db.Existencias On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.VentasDetalles On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Where det.IDVENTA = id Select pro.IDALTERNO, pro.IDORIGINAL, pro.DESCRIPCION, MARCA = If(pro.Marca.ACTIVO.Equals("S"), mar.DESCRIPCION, "SIN ESPECIFICAR"), pro.MODELO, UNIDAD_DE_MEDIDA = If(pro.UnidadMedida.ACTIVO.Equals("S"), pro.UnidadMedida.DESCRIPCION, "SIN ESPECIFICAR"), pro.CONTIENE, PRESENTACIÓN = If(pro.Presentacion.ACTIVO.Equals("S"), pro.Presentacion.DESCRIPCION, "SIN ESPECIFICAR"), LABORATORIO = If(pro.Laboratorio.ACTIVO.Equals("S"), pro.Laboratorio.DESCRIPCION, "SIN ESPECIFICAR"), det.CANTIDAD, PRECIOUNITARIO = If(v.MONEDA.Equals(Config.cordoba), det.PRECIOUNITARIO_C, det.PRECIOUNITARIO_D), DESCUENTO = If(v.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D), SUBTOTAL = If(v.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, det.SUBTOTAL_D), IVA = If(v.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D), TOTAL = If(v.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D)).ToList
                        If dtDetalle.Columns.Count > 0 Then
                            dtDetalle.Columns(0).HeaderText = vbNewLine & "Nº PRODUCTO" & vbNewLine : dtDetalle.Columns(0).Width = 120
                            dtDetalle.Columns(1).HeaderText = "ID ORIGINAL"
                            dtDetalle.Columns(2).HeaderText = "DESCRIPCIÓN DEL PRODUCTO" : dtDetalle.Columns(2).Width = 250
                            dtDetalle.Columns(3).HeaderText = "MARCA"
                            dtDetalle.Columns(4).HeaderText = "MODELO"
                            dtDetalle.Columns(5).HeaderText = "U / M"
                            dtDetalle.Columns(6).HeaderText = "CONT. X UNI."
                            dtDetalle.Columns(7).HeaderText = "PRESENTACIÓN"
                            dtDetalle.Columns(8).HeaderText = "LABORATORIO"
                            dtDetalle.Columns(9).HeaderText = "CANTIDAD" : dtDetalle.Columns(9).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(10).HeaderText = "P / U" : dtDetalle.Columns(10).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(11).HeaderText = "DESCUENTO" : dtDetalle.Columns(11).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(12).HeaderText = "SUB-TOTAL" : dtDetalle.Columns(12).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(13).HeaderText = "IVA" : dtDetalle.Columns(13).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(14).HeaderText = "TOTAL" : dtDetalle.Columns(14).DefaultCellStyle.Format = Config.f_m
                        End If
                        For Each c As DataGridViewColumn In dtDetalle.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                        Next
                    Else
                        expDetalle.TitleText = "Mostrar detalle de la factura seleccionada"
                        dtDetalle.DataSource = Nothing
                        expDetalle.TitleText = "No se puede mostrar detalle de la factura '" & v.SERIE & " - " & v.CONSECUTIVO & "' por que está anulada."
                    End If
                Else
                    dtDetalle.DataSource = Nothing
                    MessageBox.Show("No se encuentra esta factura")
                End If
                v = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Sub CargarLista()
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                    Lista(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString(), txtNVendedor.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                Else
                    Lista(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), , txtNVendedor.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                End If
            Else
                Lista(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", , , txtNVendedor.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Sub ListaSerie(ByVal bodega As String)
        Me.FormLoad = False
        Try
            Using db As New CodeFirst
                cmbSerie.DataSource = db.Series.Where(Function(f) f.ACTIVO = "S" And f.OPERACION = "VENTA" And f.IDBODEGA = bodega).ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Private Sub frmInformeVentas_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'If Me.LoadForm Then
        '    If expDetalle.Expanded Then
        '        expDetalle.Height = dtRegistro.Height / 2
        '        dtRegistro.Height = expDetalle.Height
        '    End If
        'End If
        gbMoneda.Left = (PanelEx4.Width / 2) - (gbMoneda.Width / 2) + 4
        gbTipoVenta.Left = PanelEx4.Width - gbTipoVenta.Width - 4
    End Sub

    Private Sub frmInformeVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmInformeVentas_Resize(Nothing, Nothing)
        Me.FormLoad = False
        'Formatos de Totales
        txtDescuento.DisplayFormat = Config.f_m : txtDescuentoDolar.DisplayFormat = Config.f_m
        txtIva.DisplayFormat = Config.f_m : txtIvaDolar.DisplayFormat = Config.f_m
        txtSubtotal.DisplayFormat = Config.f_m : txtSubTotalDolar.DisplayFormat = Config.f_m
        txtTotal.DisplayFormat = Config.f_m : txtTotalDolar.DisplayFormat = Config.f_m

        txtDescuento.Value = 0.0 : txtDescuentoDolar.Value = 0.0
        txtIva.Value = 0.0 : txtIvaDolar.Value = 0.0
        txtSubtotal.Value = 0.0 : txtSubTotalDolar.Value = 0.0
        txtTotal.Value = 0.0 : txtTotalDolar.Value = 0.0
        'Fin Formatos

        Try
            dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
            dtDetalle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
            dtpFechaInicial.Value = DateTime.Now : dtpFechaFinal.Value = DateTime.Now
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.Bodegas Where bod.ACTIVO = "S" Select bod.IDBODEGA, NOMBRE = bod.N_BODEGA & " - " & bod.DESCRIPCION).ToList() : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.DisplayMember = "NOMBRE" : cmbBodega.SelectedIndex = -1
                Config._Taza = db.Tazas.OrderByDescending(Function(f) f.FECHA).FirstOrDefault()
                If Not Config._Taza Is Nothing Then
                    Config.tazadecambio = Config._Taza.CAMBIO
                Else
                    Config.tazadecambio = 0
                    MessageBox.Show("Error, No existe Taza de Cambio")
                End If
            End Using

            Lista(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Private Sub expDetalle_ExpandedChanging(sender As Object, e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expDetalle.ExpandedChanging
        If Me.FormLoad Then
            If Not expDetalle.Expanded Then
                expDetalle.Height = dtRegistro.Height / 2
                dtRegistro.Height = expDetalle.Height
            End If
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        expDetalle.Visible = True
        CrystalReportViewer1.Visible = False
        Me.CargarLista()
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        Me.FormLoad = False
        dtpFechaInicial.Value = DateTime.Now
        dtpFechaFinal.Value = DateTime.Now
        cmbBodega.SelectedIndex = -1
        cmbSerie.SelectedIndex = -1
        txtNCliente.Clear()
        txtNombreCliente.Clear()
        txtNVendedor.Clear()
        txtNombreVendedor.Clear()
        rdMTodos.Checked = True
        rdTodos.Checked = True
        Lista(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
        Me.FormLoad = True
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        expDetalle.Visible = False
        CrystalReportViewer1.Visible = True
        'cargar
        Me.CargarLista()
    End Sub

    Private Sub dtRegistro_SelectionChanged(sender As Object, e As EventArgs) Handles dtRegistro.SelectionChanged
        If Me.FormLoad Then
            Try
                If dtRegistro.SelectedRows.Count > 0 Then
                    ListaDetalle(dtRegistro.SelectedRows(0).Cells(1).Value.ToString)
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
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
            txtNVendedor.Clear()
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

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged, dtpFechaFinal.ValueChanged
        Me.CargarLista()
    End Sub

    Private Sub rdMTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdMTodos.CheckedChanged
        If rdMTodos.Checked Then
            Me.CargarLista()
        End If
    End Sub

    Private Sub rdMCordoba_CheckedChanged(sender As Object, e As EventArgs) Handles rdMCordoba.CheckedChanged
        If rdMCordoba.Checked Then
            Me.CargarLista()
        End If
    End Sub

    Private Sub rdMDolar_CheckedChanged(sender As Object, e As EventArgs) Handles rdMDolar.CheckedChanged
        If rdMDolar.Checked Then
            Me.CargarLista()
        End If
    End Sub


    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        If rdTodos.Checked Then
            Me.CargarLista()
        End If
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If rdContado.Checked Then
            Me.CargarLista()
        End If
    End Sub

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If rdCredito.Checked Then
            Me.CargarLista()
        End If
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                ListaSerie(cmbBodega.SelectedValue.ToString())
                Me.CargarLista()
                cmbSerie.Focus()
            Else
                Me.CargarLista()
            End If
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                Me.CargarLista()
            End If
        End If
    End Sub

    Private Sub txtNCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNCliente.KeyDown, txtNVendedor.KeyDown, txtNombreVendedor.KeyDown, txtNombreCliente.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.CargarLista()
        End If
    End Sub

    Private Sub frmInformeVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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