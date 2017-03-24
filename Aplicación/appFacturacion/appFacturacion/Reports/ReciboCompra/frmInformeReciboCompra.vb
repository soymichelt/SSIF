Public Class frmInformeReciboCompra
    Dim FormLoad As Boolean

    'variables totales
    Dim dc As Decimal : Dim dd As Decimal
    Dim sc As Decimal : Dim sd As Decimal
    Dim ic As Decimal : Dim id As Decimal
    Dim tc As Decimal : Dim td As Decimal
    'fin variables totales

    Sub Lista(ByVal Fecha1 As DateTime, ByVal Fecha2 As DateTime, Optional ByVal bodegap As String = "", Optional ByVal seriep As String = "", Optional ByVal IdEmpleadoP As String = "", Optional ByVal EmpleadoP As String = "", Optional ByVal IdProveedorP As String = "", Optional ByVal ProveedorP As String = "")
        Try
            Using db As New CodeFirst
                If dtRegistro.Visible Then
                    Dim consulta = (From rec In db.ComprasRecibos Join ser In db.Series On ser.IDSERIE Equals rec.IDSERIE Join prv In db.Proveedores On prv.IDPROVEEDOR Equals rec.IDPROVEEDOR Join tra In db.Empleados On tra.IDEMPLEADO Equals rec.IDEMPLEADO Where rec.IDPROVEEDOR IsNot Nothing And rec.FECHARECIBO >= Fecha1 And rec.FECHARECIBO <= Fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) And tra.N_TRABAJADOR.Contains(IdEmpleadoP) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(EmpleadoP) Select ANULADO = If(rec.ANULADO.Equals("S"), "Anulado", ""), rec.IDRECIBO, SERIE = ser.NOMBRE, rec.CONSECUTIVO, rec.N_DOCUMENTO, rec.FECHARECIBO, NProveedor = If(rec.ANULADO.Equals("N"), prv.N_PROVEEDOR, ""), Proveedor = If(rec.ANULADO.Equals("N"), prv.NOMBRES & " " & prv.APELLIDOS, ""), NEmpleado = If(rec.ANULADO.Equals("N"), tra.N_TRABAJADOR, ""), Empleado = If(rec.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), rec.CONCEPTO, Móneda = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.dolar), "Dólar", "Córdoba"), ""), TazaCambio = If(rec.ANULADO.Equals("N"), rec.TAZACAMBIO, Nothing), ImporteTotal = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.IMPORTETOTAL_C, rec.IMPORTETOTAL_D), Nothing), Descuento = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.DESCUENTOTOTAL_C, rec.DESCUENTOTOTAL_D), Nothing), Sobrante = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.SOBRANTEDECAJA_C, rec.SOBRANTEDECAJA_D), Nothing), MontoTotal = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.MONTOTOTAL_C, rec.MONTOTOTAL_D), Nothing), rec.N, MON = rec.MONEDA)

                    If rdMCordoba.Checked Then 'moneda
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.cordoba) And f.ANULADO.Equals(""))
                    ElseIf rdMDolar.Checked Then
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.dolar) And f.ANULADO.Equals(""))
                    End If
                    If IdProveedorP.Trim <> "" Then 'filtro cliente
                        consulta = consulta.Where(Function(f) f.NProveedor.Contains(IdProveedorP) And f.ANULADO.Equals(""))
                    End If
                    If ProveedorP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.Proveedor.Contains(ProveedorP) And f.ANULADO.Equals(""))
                    End If
                    If IdEmpleadoP.Trim <> "" Then 'filtro vendedor
                        consulta = consulta.Where(Function(f) f.NEmpleado.Contains(IdEmpleadoP) And f.ANULADO.Equals(""))
                    End If
                    If EmpleadoP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.Empleado.Contains(EmpleadoP) And f.ANULADO.Equals(""))
                    End If

                    dtRegistro.DataSource = consulta.OrderBy(Function(f) f.N).ToList
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = ""
                        dtRegistro.Columns(1).Visible = False
                        dtRegistro.Columns(2).Width = 55
                        dtRegistro.Columns(3).Width = 150 : dtRegistro.Columns(3).HeaderText = "Nº DOCUMENTO"
                        dtRegistro.Columns(4).Width = 150 : dtRegistro.Columns(4).HeaderText = "Nº RECIBO"
                        dtRegistro.Columns(5).Width = 150 : dtRegistro.Columns(5).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(5).HeaderText = "FECHA"
                        dtRegistro.Columns(6).Width = 150 : dtRegistro.Columns(6).HeaderText = "N° PROVEEDOR"
                        dtRegistro.Columns(7).Width = 250 : dtRegistro.Columns(7).HeaderText = "NOMBRES Y APELLIDOS DEL PROVEEDOR"
                        dtRegistro.Columns(8).Width = 120 : dtRegistro.Columns(8).HeaderText = "Nº EMPLEADO"
                        dtRegistro.Columns(9).Width = 250 : dtRegistro.Columns(9).HeaderText = "NOMBRES Y APELLIDOS DEL EMPLEADO"
                        dtRegistro.Columns(10).Width = 350 : dtRegistro.Columns(10).HeaderText = "CONCEPTO"
                        dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).HeaderText = "MONEDA"
                        dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).HeaderText = "T / Z" : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).HeaderText = "T. IMPORTE" : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(14).Width = 100 : dtRegistro.Columns(14).HeaderText = "T. DESCUENTO" : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(15).Width = 100 : dtRegistro.Columns(15).HeaderText = "T. SOBRANTE" : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(16).Width = 100 : dtRegistro.Columns(16).HeaderText = "T. MONTO" : dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(17).Visible = False
                        dtRegistro.Columns(18).Visible = False
                    End If
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                    Next
                    If consulta.Count() > 0 Then
                        Dim cordoba = consulta.Where(Function(f) f.MON = Config.cordoba) : Dim dolar = consulta.Where(Function(f) f.MON = Config.dolar)
                        Me.dc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.ImporteTotal), 0.0) : Me.sc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.Descuento), 0.0) : Me.ic = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.Sobrante), 0.0) : Me.tc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.MontoTotal), 0.0)
                        Me.dd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.ImporteTotal), 0.0) : Me.sd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.Descuento), 0.0) : Me.id = If(dolar.Count() > 0, dolar.Sum(Function(f) f.Sobrante), 0.0) : Me.td = If(dolar.Count() > 0, dolar.Sum(Function(f) f.MontoTotal), 0.0)
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
                        expDetalle.TitleText = "MOSTRAR DETALLE DEL RECIBO DE COMPRA SELECCIONADO"
                    End If
                Else
                    Dim consulta = (From rec In db.ComprasRecibos Join ser In db.Series On ser.IDSERIE Equals rec.IDSERIE Join prv In db.Proveedores On prv.IDPROVEEDOR Equals rec.IDPROVEEDOR Join tra In db.Empleados On tra.IDEMPLEADO Equals rec.IDEMPLEADO Where rec.IDPROVEEDOR IsNot Nothing And rec.FECHARECIBO >= Fecha1 And rec.FECHARECIBO <= Fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) And tra.N_TRABAJADOR.Contains(IdEmpleadoP) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(EmpleadoP) Select ANULADO = If(rec.ANULADO.Equals("S"), "Anulado", ""), rec.IDRECIBO, SERIE = ser.NOMBRE, rec.CONSECUTIVO, rec.FECHARECIBO, NProveedor = If(rec.ANULADO.Equals("N"), prv.N_PROVEEDOR, ""), Proveedor = If(rec.ANULADO.Equals("N"), prv.NOMBRES & " " & prv.APELLIDOS, ""), NEmpleado = If(rec.ANULADO.Equals("N"), tra.N_TRABAJADOR, ""), Empleado = If(rec.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), Móneda = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.dolar), "Dólar", "Córdoba"), ""), TazaCambio = If(rec.ANULADO.Equals("N"), rec.TAZACAMBIO, Nothing), ImporteTotal = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.IMPORTETOTAL_C, rec.IMPORTETOTAL_D), Nothing), Descuento = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.DESCUENTOTOTAL_C, rec.DESCUENTOTOTAL_D), Nothing), Sobrante = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.SOBRANTEDECAJA_C, rec.SOBRANTEDECAJA_D), Nothing), MontoTotal = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.MONTOTOTAL_C, rec.MONTOTOTAL_D), Nothing), rec.N, MON = rec.MONEDA)

                    If rdMCordoba.Checked Then 'moneda
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.cordoba) And f.ANULADO.Equals(""))
                    ElseIf rdMDolar.Checked Then
                        consulta = consulta.Where(Function(f) f.MON.Equals(Config.dolar) And f.ANULADO.Equals(""))
                    End If
                    If IdProveedorP.Trim <> "" Then 'filtro cliente
                        consulta = consulta.Where(Function(f) f.NProveedor.Contains(IdProveedorP) And f.ANULADO.Equals(""))
                    End If
                    If ProveedorP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.Proveedor.Contains(ProveedorP) And f.ANULADO.Equals(""))
                    End If
                    If IdEmpleadoP.Trim <> "" Then 'filtro vendedor
                        consulta = consulta.Where(Function(f) f.NEmpleado.Contains(IdEmpleadoP) And f.ANULADO.Equals(""))
                    End If
                    If EmpleadoP.Trim <> "" Then
                        consulta = consulta.Where(Function(f) f.Empleado.Contains(EmpleadoP) And f.ANULADO.Equals(""))
                    End If

                    If consulta.Count() > 0 Then
                        Dim cordoba = consulta.Where(Function(f) f.MON = Config.cordoba) : Dim dolar = consulta.Where(Function(f) f.MON = Config.dolar)
                        Me.dc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.ImporteTotal), 0.0) : Me.sc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.Descuento), 0.0) : Me.ic = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.Sobrante), 0.0) : Me.tc = If(cordoba.Count() > 0, cordoba.Sum(Function(f) f.MontoTotal), 0.0)
                        Me.dd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.ImporteTotal), 0.0) : Me.sd = If(dolar.Count() > 0, dolar.Sum(Function(f) f.Descuento), 0.0) : Me.id = If(dolar.Count() > 0, dolar.Sum(Function(f) f.Sobrante), 0.0) : Me.td = If(dolar.Count() > 0, dolar.Sum(Function(f) f.MontoTotal), 0.0)
                        'cordoba
                        txtDescuento.Value = Me.dc : txtSubtotal.Value = Me.sc : txtIva.Value = Me.ic : txtTotal.Value = Me.tc
                        'dolar
                        txtDescuentoDolar.Value = Me.dd : txtSubTotalDolar.Value = Me.sd : txtIvaDolar.Value = Me.id : txtTotalDolar.Value = Me.td
                        cordoba = Nothing : dolar = Nothing
                    Else
                        txtDescuento.Value = 0 : txtSubtotal.Value = 0 : txtIva.Value = 0 : txtTotal.Value = 0
                        txtDescuentoDolar.Value = 0 : txtSubTotalDolar.Value = 0 : txtIvaDolar.Value = 0 : txtTotalDolar.Value = 0
                    End If
                    Dim rpt As New rptInformeReciboCompraList
                    Config.CrystalTitle("INFORME DE RECIBOS DE COMPRA", rpt)
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
                    If IdProveedorP <> "" Then
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = IdProveedorP
                    Else
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = "%Todos%"
                    End If
                    If EmpleadoP <> "" Then
                        band = rpt.Section2.ReportObjects("txtCliente") : band.Text = EmpleadoP
                    Else
                        band = rpt.Section2.ReportObjects("txtCliente") : band.Text = "%Todos%"
                    End If
                    band = rpt.Section2.ReportObjects("txtMoneda")
                    If rdMCordoba.Checked Then
                        band.Text = "(DOCUMENTOS EN CÓRDOBAS)"
                    ElseIf rdMDolar.Checked Then
                        band.Text = "(DOCUMENTOS EN DÓLAR)"
                    Else
                        band.Text = "(DOCUMENTOS EN CÓRDOBAS Y DÓLAR)"
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
                Dim v = (From rec In db.ComprasRecibos Join ser In db.Series On rec.IDSERIE Equals ser.IDSERIE Where rec.IDRECIBO = id Select rec.IDRECIBO, rec.ANULADO, SERIE = ser.NOMBRE, rec.CONSECUTIVO, rec.MONEDA).FirstOrDefault()
                If Not v Is Nothing Then
                    If v.ANULADO = "N" Then
                        expDetalle.TitleText = "MOSTRAR DETALLE DEL RECIBO DE COMPRA '" & v.SERIE & " - " & v.CONSECUTIVO & "'"
                        dtDetalle.DataSource = (From com In db.Compras Join ser In db.Series On com.IDSERIE Equals ser.IDSERIE Join det In db.ComprasRecibosDetalles On com.IDCOMPRA Equals det.IDCOMPRA Where det.IDRECIBO = id _
                                   Select com.IDCOMPRA, SERIE = ser.NOMBRE, com.CONSECUTIVO, FECHA = com.FECHACOMPRA, MÓNEDA = If(com.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), com.TAZACAMBIO, DESCUENTO = If(com.MONEDA.Equals(Config.cordoba), com.DESCUENTO_DIN_C, com.DESCUENTO_DIN_D), SUBTOTAL = If(com.MONEDA.Equals(Config.cordoba), com.SUBTOTAL_C, com.SUBTOTAL_D), IVA = If(com.MONEDA.Equals(Config.cordoba), com.IVA_DIN_C, com.IVA_DIN_D), TOTAL = If(com.MONEDA.Equals(Config.cordoba), com.TOTAL_C, com.TOTAL_D), det.SALDOCREDITO, OPERACION = If(det.OPERACION.Equals("A"), "ABONO", "CANCELACIÓN"), IMPORTE = If(v.MONEDA.Equals(Config.cordoba), det.IMPORTE_C, det.IMPORTE_D), DESCUENTO_REC = If(v.MONEDA.Equals(Config.cordoba), det.DESCUENTO_C, det.DESCUENTO_D), NUEVO_SALDO = If(v.MONEDA.Equals(Config.cordoba), det.NUEVO_SALDO_C, det.NUEVO_SALDO_D)).ToList
                        If dtDetalle.Columns.Count > 0 Then
                            dtDetalle.Columns(0).Visible = False
                            dtDetalle.Columns(1).HeaderText = vbNewLine & "SERIE" & vbNewLine : dtDetalle.Columns(1).Width = 80
                            dtDetalle.Columns(2).HeaderText = "N° COMPRA" : dtDetalle.Columns(2).Width = 100
                            dtDetalle.Columns(3).HeaderText = "FECHA" : dtDetalle.Columns(3).Width = 120
                            dtDetalle.Columns(4).HeaderText = "MÓNEDA" : dtDetalle.Columns(4).Width = 120
                            dtDetalle.Columns(5).HeaderText = "T / C" : dtDetalle.Columns(5).Width = 120 : dtDetalle.Columns(5).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(6).HeaderText = "DESC. COM" : dtDetalle.Columns(6).Width = 120 : dtDetalle.Columns(6).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(7).HeaderText = "SUB-TOTAL" : dtDetalle.Columns(7).Width = 120 : dtDetalle.Columns(7).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(8).HeaderText = "IVA" : dtDetalle.Columns(8).Width = 120 : dtDetalle.Columns(8).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(9).HeaderText = "TOTAL" : dtDetalle.Columns(9).Width = 120 : dtDetalle.Columns(9).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(10).HeaderText = "SALDO" : dtDetalle.Columns(10).Width = 120 : dtDetalle.Columns(10).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(11).HeaderText = "OPERACIÓN" : dtDetalle.Columns(11).Width = 120
                            dtDetalle.Columns(12).HeaderText = "IMPORTE" : dtDetalle.Columns(12).Width = 120 : dtDetalle.Columns(12).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(13).HeaderText = "DESCUENTO" : dtDetalle.Columns(13).Width = 120 : dtDetalle.Columns(13).DefaultCellStyle.Format = Config.f_m
                            dtDetalle.Columns(14).HeaderText = "NUEVO SALDO" : dtDetalle.Columns(14).Width = 120 : dtDetalle.Columns(14).DefaultCellStyle.Format = Config.f_m
                        End If
                        For Each c As DataGridViewColumn In dtDetalle.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                        Next
                    Else
                        dtDetalle.DataSource = Nothing
                        expDetalle.TitleText = "NO SE PUEDE MOSTRAR DETALLE DEL RECIBO DE COMPRA '" & v.SERIE & " - " & v.CONSECUTIVO & "' POR QUE ESTÁ ANULADO."
                    End If
                Else
                    dtDetalle.DataSource = Nothing
                    MessageBox.Show("No se encuentra este Recibo de Compra")
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
                cmbSerie.DataSource = db.Series.Where(Function(f) f.ACTIVO = "S" And f.OPERACION = "RECIBO COMPRA" And f.IDBODEGA = bodega).ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Private Sub frmInformeReciboCompra_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'If Me.LoadForm Then
        '    If expDetalle.Expanded Then
        '        expDetalle.Height = dtRegistro.Height / 2
        '        dtRegistro.Height = expDetalle.Height
        '    End If
        'End If
        gbMoneda.Left = PanelEx4.Width - gbMoneda.Width - 4
    End Sub

    Private Sub frmInformeReciboCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmInformeReciboCompra_Resize(Nothing, Nothing)
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