Public Class frmBCotizacion
    Public frm_return As Integer = 0
    Dim LoadForm As Boolean = False
    ' Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "")
    Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "", Optional ByVal pcodigocliente As String = "", Optional ByVal pnombrecliente As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join bod In db.BODEGAS On bod.IDBODEGA Equals ser.IDBODEGA Join tra In db.EMPLEADOS On cot.IDEMPLEADO Equals tra.IDEMPLEADO Where ser.IDSERIE.Contains(pserie) And cot.FECHACOTIZACION >= finicio And cot.FECHACOTIZACION <= ffin Select ANULADO = If(cot.ANULADO.Equals("S"), "Anulado", ""), cot.IDCOTIZACION, SERIE = ser.NOMBRE, cot.CONSECUTIVO, cot.FECHACOTIZACION, N_CLIENTE = If(cot.ANULADO.Equals("N"), If(Not cot.IDCLIENTE Is Nothing, cot.CLIENTE.N_CLIENTE, ""), ""), CLIENTE = If(cot.ANULADO.Equals("N"), If(Not cot.IDCLIENTE Is Nothing, cot.CLIENTE.NOMBRES & " " & cot.CLIENTE.APELLIDOS, cot.CLIENTECONTADO), ""), N_VENDEDOR = If(cot.ANULADO.Equals("N"), tra.N_TRABAJADOR, ""), VENDEDOR = If(cot.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), CONDICIÓN = If(cot.ANULADO.Equals("N"), If(cot.CREDITO, "Crédito", "Contado"), ""), MONEDA = If(cot.ANULADO.Equals("N"), If(cot.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), ""), TAZACAMBIO = If(cot.ANULADO.Equals(Config.vFalse), cot.TAZACAMBIO, Nothing), DESCUENTO = If(cot.ANULADO.Equals("N"), If(cot.MONEDA.Equals(Config.cordoba), cot.DESCUENTO_DIN_C, cot.DESCUENTO_DIN_D), Nothing), SUBTOTAL = If(cot.ANULADO.Equals("N"), If(cot.MONEDA.Equals(Config.cordoba), cot.SUBTOTAL_C, cot.SUBTOTAL_D), Nothing), IVA = If(cot.ANULADO.Equals("N"), If(cot.MONEDA.Equals(Config.cordoba), cot.IVA_DIN_C, cot.IVA_DIN_D), Nothing), TOTAL = If(cot.ANULADO.Equals("N"), If(cot.MONEDA.Equals(Config.cordoba), cot.TOTAL_C, cot.TOTAL_D), Nothing), cot.CREDITO).ToList
                If rdContado.Checked Then
                    consulta = consulta.Where(Function(f) f.CREDITO = False And f.ANULADO.Equals("")).ToList
                ElseIf rdCredito.Checked Then
                    consulta = consulta.Where(Function(f) f.CREDITO And f.ANULADO.Equals("")).ToList
                End If
                If pcodigocliente.Trim <> "" Then
                    consulta = consulta.Where(Function(f) f.N_CLIENTE.ToLower.Contains(pcodigocliente.ToLower) And f.ANULADO.Equals("")).ToList
                End If
                If pnombrecliente.Trim <> "" Then
                    consulta = consulta.Where(Function(f) f.CLIENTE.ToLower.Contains(pnombrecliente.ToLower) And f.ANULADO.Equals("")).ToList
                End If
                dtRegistro.DataSource = consulta.ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = vbNewLine & "" & vbNewLine
                    dtRegistro.Columns(1).Visible = False
                    dtRegistro.Columns(2).Width = 55
                    dtRegistro.Columns(3).Width = 120 : dtRegistro.Columns(3).HeaderText = "Nº COTIZACIÓN"
                    dtRegistro.Columns(4).Width = 80 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(4).HeaderText = "FECHA"
                    dtRegistro.Columns(7).Width = 80 : dtRegistro.Columns(5).HeaderText = "Nº CLIENTE"
                    dtRegistro.Columns(8).Width = 250 : dtRegistro.Columns(6).HeaderText = "NOMBRES Y APELLIDOS DEL CLIENTE"
                    dtRegistro.Columns(5).Width = 80 : dtRegistro.Columns(7).HeaderText = "Nº EMPLEADO"
                    dtRegistro.Columns(6).Width = 250 : dtRegistro.Columns(8).HeaderText = "NOMBRES Y APELLIDOS DEL EMPLEADO"
                    dtRegistro.Columns(9).Width = 70 : dtRegistro.Columns(9).HeaderText = "CONDICIÓN"
                    dtRegistro.Columns(10).Width = 100 : dtRegistro.Columns(10).HeaderText = "MONEDA"
                    dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).HeaderText = "T / Z" : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).HeaderText = "DESCUENTO" : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).HeaderText = "SUB-TOTAL" : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(14).Width = 100 : dtRegistro.Columns(14).HeaderText = "IVA" : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(15).Width = 100 : dtRegistro.Columns(15).HeaderText = "TOTAL" : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(16).Visible = False
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim servicio As ServiceReference1
        Try
            dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
            Using db As New CodeFirst
                'llenar series
                cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                dtpFechaInicial.Value = DateTime.Now
                dtpFechaFinal.Value = DateTime.Now
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.LoadForm = True
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        Try
            Using db As New CodeFirst
                If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                    Dim serie As String = cmbSerie.Text
                    'llenar series
                    cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "COTIZACION").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    'llenar series
                    cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "COTIZACION").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
        Else
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        cmbSerie.SelectedIndex = -1
        dtpFechaInicial.Value = DateTime.Now
        dtpFechaFinal.Value = DateTime.Now
        llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim idcotizacion As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString() : Dim cotizacion = db.COTIZACIONES.Where(Function(f) f.IDCOTIZACION = idcotizacion).FirstOrDefault()
                    If Not cotizacion Is Nothing Then
                        If cotizacion.ANULADO = "N" Then
                            Select Case frm_return
                                Case 0
                                    frmCotizacion.LoadInfo(vInt:=cotizacion, ByInt:=True)
                                    Me.Close()
                                Case 1
                                    frmVenta.txtSerie.Enabled = True : frmVenta.btActualizarSerie.Enabled = True
                                    frmVenta.txtCodigo.Enabled = True : frmVenta.Id = ""
                                    frmVenta.dtpFecha.Value = DateTime.Now
                                    frmVenta.chkExonerado.Checked = cotizacion.EXONERADO
                                    frmVenta.txtTazaCambio.Value = cotizacion.TAZACAMBIO
                                    frmVenta.txtIdVendedor.Text = cotizacion.TRABAJADOR.IDEMPLEADO
                                    txtNombreCliente.Text = If(cotizacion.CLIENTE.TIPOPERSONA = "Natural", cotizacion.CLIENTE.N_CLIENTE & " " & cotizacion.CLIENTE.NOMBRES & " " & cotizacion.CLIENTE.APELLIDOS & If(cotizacion.CLIENTE.RAZONSOCIAL.Trim() <> "", " // " & cotizacion.CLIENTE.RAZONSOCIAL, ""), cotizacion.CLIENTE.N_CLIENTE & " " & cotizacion.CLIENTE.RAZONSOCIAL)
                                    If Not cotizacion.IDCLIENTE Is Nothing Then
                                        frmVenta.txtIdCliente.Text = cotizacion.CLIENTE.IDCLIENTE
                                        frmVenta.txtNombreCliente.Text = cotizacion.CLIENTE.N_CLIENTE & " | " & cotizacion.CLIENTE.NOMBRES & " " & cotizacion.CLIENTE.APELLIDOS
                                        If cotizacion.CREDITO Then
                                            frmVenta.rdCredito.Checked = True
                                        Else
                                            frmVenta.rdContado.Checked = True
                                        End If
                                    Else
                                        frmVenta.rdContado.Checked = True
                                        frmVenta.txtIdCliente.Text = ""
                                        frmVenta.txtNombreCliente.Text = cotizacion.CLIENTECONTADO
                                    End If
                                    If cotizacion.TIPODESCUENTO = "POR PRODUCTO" Then
                                        frmVenta.rdDescuentoPorProducto.Checked = True
                                    ElseIf cotizacion.TIPODESCUENTO = "POR FACTURA" Then
                                        frmVenta.rdDescuentoPorFactura.Checked = True
                                    Else
                                        frmVenta.rdSindescuento.Checked = True
                                    End If
                                    Dim item As LST_DETALLE_VENTA
                                    frmVenta.detalles.RemoveAll(Function(f) True)
                                    For Each detalle In cotizacion.DETALLES_COTIZACIONES
                                        item = New LST_DETALLE_VENTA()
                                        item.IDEXISTENCIA = detalle.IDEXISTENCIA
                                        item.IDALTERNO = detalle.EXISTENCIA.PRODUCTO.IDALTERNO
                                        item.DESCRIPCION = detalle.EXISTENCIA.PRODUCTO.DESCRIPCION
                                        item.IVA = detalle.EXISTENCIA.PRODUCTO.IVA
                                        item.MARCA = If(detalle.EXISTENCIA.PRODUCTO.MARCA.ACTIVO.Equals("S"), detalle.EXISTENCIA.PRODUCTO.MARCA.DESCRIPCION, "")
                                        item.UNIDAD_DE_MEDIDA = If(detalle.EXISTENCIA.PRODUCTO.UNIDAD_DE_MEDIDA.ACTIVO.Equals("S"), detalle.EXISTENCIA.PRODUCTO.UNIDAD_DE_MEDIDA.DESCRIPCION, "")
                                        item.PRESENTACION = If(detalle.EXISTENCIA.PRODUCTO.PRESENTACION.ACTIVO.Equals("S"), detalle.EXISTENCIA.PRODUCTO.PRESENTACION.DESCRIPCION, "")
                                        item.EXISTENCIA = detalle.EXISTENCIA_PRODUCTO
                                        item.CANTIDAD = detalle.CANTIDAD
                                        item.PRECIOUNITARIO_C = detalle.PRECIOUNITARIO_C : item.PRECIOUNITARIO_D = detalle.PRECIOUNITARIO_D
                                        item.DESCUENTO_POR = detalle.DESCUENTO_POR
                                        item.DESCUENTO_DIN_C = detalle.DESCUENTO_DIN_C : item.DESCUENTO_DIN_D = detalle.DESCUENTO_DIN_D
                                        item.DESCUENTO_DIN_TOTAL_C = detalle.DESCUENTO_DIN_TOTAL_C : item.DESCUENTO_DIN_TOTAL_D = detalle.DESCUENTO_DIN_TOTAL_D
                                        item.PRECIONETO_C = detalle.PRECIONETO_C : item.PRECIONETO_D = detalle.PRECIONETO_D
                                        item.SUBTOTAL_C = detalle.SUBTOTAL_C : item.SUBTOTAL_D = detalle.SUBTOTAL_D
                                        item.IVA_POR = detalle.IVA_POR
                                        item.IVA_DIN_C = detalle.IVA_DIN_C : item.IVA_DIN_D = detalle.IVA_DIN_D
                                        item.IVA_DIN_TOTAL_C = detalle.IVA_DIN_TOTAL_C : item.IVA_DIN_TOTAL_D = detalle.IVA_DIN_TOTAL_D
                                        item.TOTAL_C = detalle.TOTAL_C : item.TOTAL_D = detalle.TOTAL_D
                                        frmVenta.detalles.Add(item)
                                        item = Nothing
                                    Next
                                    frmVenta.Grid()
                                    frmVenta.lblContador.Text = "N° ITEM: " & frmVenta.dtRegistro.Rows.Count.ToString()
                                    frmVenta.btGuardar.Enabled = True
                                    frmVenta.btAnular.Enabled = False
                                    frmVenta.btImprimir.Enabled = False
                                    Me.Close()
                            End Select
                        Else
                            MessageBox.Show("Esta 'Cotización' esta anulado")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra esta 'Cotización' o ha sido eliminada")
                    End If
                    idcotizacion = Nothing : cotizacion = Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Me.LoadForm Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        If Me.LoadForm Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If Me.LoadForm Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If Me.LoadForm Then
            If rdContado.Checked Then
                If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
                Else
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
                End If
            End If
        End If
    End Sub

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If Me.LoadForm Then
            If rdCredito.Checked Then
                If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
                Else
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
                End If
            End If
        End If
    End Sub

    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        If Me.LoadForm Then
            If rdTodos.Checked Then
                If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
                Else
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
                End If
            End If
        End If
    End Sub

    Private Sub txtNombreCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreCliente.KeyDown
        If e.KeyData = Keys.Enter Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCliente.KeyDown
        If e.KeyData = Keys.Enter Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmBCotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.B
                    btBuscar_Click(Nothing, Nothing)
                Case Keys.Delete
                    btLimpiar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub
End Class