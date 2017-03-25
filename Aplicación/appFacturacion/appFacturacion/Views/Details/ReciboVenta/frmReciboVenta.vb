Public Class frmReciboVenta

    'factura seleccionada
    Public Id As String = ""

    Dim cod As String = ""

    Public detalles As New List(Of LST_DETALLE_RECIBO)

    Dim FormLoad As Boolean = False

    Sub limpiar()
        Try
            If txtIdSerie.Text <> "" Then
                txtSerie.Enabled = True
                btActualizarSerie.Enabled = True
                detalles.RemoveAll(Function(f) True)
                Grid()
                lblContador.Text = "N° ITEM: 0"
                txtTotalImporte.Value = 0 : txtTotalDescuento.Value = 0 : txtTotalNuevoSaldo.Value = 0
                txtCodigo.Enabled = True
                txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                dtpFecha.Value = DateTime.Now
                txtIdCliente.Clear()
                txtNCliente.Clear()
                txtNombreCliente.Clear()
                txtObservacion.Clear()
                txtMontoTotal.Value = 0
                txtSobrantedeCaja.Value = 0

                btGuardar.Enabled = True : btAnular.Enabled = False : btImprimir.Enabled = True
                txtCodigo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

#Region "Grid View"
    Public Sub Grid()
        If detalles.Count > 0 Then
            If rdCordoba.Checked Then
                txtTotalImporte.Value = detalles.Sum(Function(f) f.IMPORTE_C)
                txtDescuento.Value = detalles.Sum(Function(f) f.DESCUENTO_C)
                txtTotalNuevoSaldo.Value = detalles.Sum(Function(f) f.NUEVO_SALDO_C)
            Else
                txtTotalImporte.Value = detalles.Sum(Function(f) f.IMPORTE_D)
                txtTotalDescuento.Value = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D)
                txtTotalNuevoSaldo.Value = detalles.Sum(Function(f) f.NUEVO_SALDO_D)
            End If
        Else
            txtTotalImporte.Value = 0
            txtTotalDescuento.Value = 0
            txtTotalNuevoSaldo.Value = 0
        End If
        If rdCordoba.Checked Then
            dtRegistro.DataSource = (From det In detalles Select det.IDVENTA, det.SERIE, det.CONSECUTIVO, det.FECHA, MONEDA = If(det.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), det.TAZA, SUBTOTAL = If(det.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, det.SUBTOTAL_D), DESCUENTO = If(det.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D), IVA = If(det.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D), TOTAL = If(det.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D), det.SALDOCREDITO, det.OPERACION, det.IMPORTE_C, det.DESCUENTO_C, det.NUEVO_SALDO_C).ToList()
        Else
            dtRegistro.DataSource = (From det In detalles Select det.IDVENTA, det.SERIE, det.CONSECUTIVO, det.FECHA, MONEDA = If(det.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), det.TAZA, SUBTOTAL = If(det.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, det.SUBTOTAL_D), DESCUENTO = If(det.MONEDA.Equals(Config.cordoba), det.DESCUENTO_DIN_TOTAL_C, det.DESCUENTO_DIN_TOTAL_D), IVA = If(det.MONEDA.Equals(Config.cordoba), det.IVA_DIN_TOTAL_C, det.IVA_DIN_TOTAL_D), TOTAL = If(det.MONEDA.Equals(Config.cordoba), det.TOTAL_C, det.TOTAL_D), det.SALDOCREDITO, det.OPERACION, det.IMPORTE_D, det.DESCUENTO_D, det.NUEVO_SALDO_D).ToList()
        End If
        If dtRegistro.Columns.Count > 0 Then
            dtRegistro.Columns(0).Visible = False
            dtRegistro.Columns(1).HeaderText = vbNewLine & "SERIE" & vbNewLine : dtRegistro.Columns(1).Width = 120
            dtRegistro.Columns(2).HeaderText = "N° FACTURA" : dtRegistro.Columns(2).Width = 120
            dtRegistro.Columns(3).HeaderText = "FECHA" : dtRegistro.Columns(3).Width = 120
            dtRegistro.Columns(4).HeaderText = "MONEDA" : dtRegistro.Columns(4).Width = 120
            dtRegistro.Columns(5).HeaderText = "T. / CAMBIO" : dtRegistro.Columns(5).Width = 120 : dtRegistro.Columns(5).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(6).HeaderText = "SUBTOTAL" : dtRegistro.Columns(6).Width = 120 : dtRegistro.Columns(6).Visible = False
            dtRegistro.Columns(7).HeaderText = "DESCUENTO" : dtRegistro.Columns(7).Width = 120 : dtRegistro.Columns(7).Visible = False
            dtRegistro.Columns(8).HeaderText = "IVA" : dtRegistro.Columns(8).Width = 120 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(9).HeaderText = "TOTAL" : dtRegistro.Columns(9).Width = 120 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(10).HeaderText = "SALDO" : dtRegistro.Columns(10).Width = 120 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m_r : dtRegistro.Columns(10).DefaultCellStyle.ForeColor = Color.Red : dtRegistro.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(11).HeaderText = "OPER." : dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(12).HeaderText = "IMPORTE" : dtRegistro.Columns(12).Width = 120 : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(12).DefaultCellStyle.ForeColor = Color.Blue : dtRegistro.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(13).HeaderText = "DESCUENTO" : dtRegistro.Columns(13).Width = 120 : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(13).DefaultCellStyle.ForeColor = Color.Brown : dtRegistro.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(14).HeaderText = "N. SALDO" : dtRegistro.Columns(14).Width = 120 : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(14).DefaultCellStyle.ForeColor = Color.Green : dtRegistro.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            For Each c As DataGridViewColumn In dtRegistro.Columns
                c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
            Next
        End If
    End Sub
#End Region

    Function generarCodigo(ByVal serie As String) As String
        Try
            Using db As New CodeFirst
                Dim recibo = db.VentasRecibos.Where(Function(f) f.IDSERIE = serie).OrderBy(Function(f) f.CONSECUTIVO).ToList().LastOrDefault()
                If Not recibo Is Nothing Then
                    cod = recibo.CONSECUTIVO
                    If Not cod.Trim = "" Then
                        cod = (Convert.ToInt32(cod) + 1).ToString
                        Dim longitud As Integer = cod.Length
                        For i As Integer = 0 To 9 - longitud
                            cod = "0" & cod
                        Next
                        Return cod
                    Else
                        Return "0000000001"
                    End If
                Else
                    Return "0000000001"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            Return ""
        End Try
    End Function

    Private Sub frmReciboVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.frmReciboVenta_Resize(Nothing, Nothing)
        Try
            txtTazaCambio.DisplayFormat = Config.f_m
            txtMontoTotal.DisplayFormat = Config.f_m
            txtSobrantedeCaja.DisplayFormat = Config.f_m
            txtAplicable.DisplayFormat = Config.f_m
            txtMonto.DisplayFormat = Config.f_m
            txtDescuento.DisplayFormat = Config.f_m
            txtTotalImporte.DisplayFormat = Config.f_m
            txtTotalDescuento.DisplayFormat = Config.f_m
            txtTotalNuevoSaldo.DisplayFormat = Config.f_m

            dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
            Using db As New CodeFirst
                Config._Taza = db.Tazas.OrderByDescending(Function(f) f.FECHA).FirstOrDefault()
                If Not Config._Taza Is Nothing Then
                    Config.tazadecambio = Config._Taza.CAMBIO
                Else
                    Config.tazadecambio = 0
                    MessageBox.Show("Error, No existe Taza de Cambio")
                End If
            End Using
            txtTazaCambio.Value = Config.tazadecambio
            frmPrincipal.lblTaza.Text = "T. / Cambio: $ 1 = C$ " & Config.tazadecambio.ToString(Config.f_m)
            txtTotalImporte.Value = 0 : txtTotalDescuento.Value = 0 : txtTotalNuevoSaldo.Value = 0
            If Not Config._Periodo Is Nothing Then
                If Config._Periodo.ACTUAL.Equals(Config.vTrue) Then
                    dtpFecha.MinDate = Config._Periodo.INICIO
                    dtpFecha.MaxDate = Config._Periodo.FINAL
                Else
                    dtpFecha.MinDate = "01/01/" & DateTime.Now.Year
                    dtpFecha.MaxDate = "31/12/" & DateTime.Now.Year
                End If
            Else
                Config.MsgErr("Seleccionar un Período Contable.")
                Exit Sub
            End If
            dtpFecha.Value = DateTime.Now
            cmbOperacion.Text = "C"
            Grid()
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        frmSeleccionarSerie.operacion = "RECIBO DE VENTA"
        frmSeleccionarSerie.ShowDialog()
        If Not frmSeleccionarSerie.serie Is Nothing Then
            With frmSeleccionarSerie.serie
                txtIdSerie.Text = .IDSERIE : txtSerie.Text = .NOMBRE : txtReferencia.Text = .DESCRIPCION
                txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                txtCodigo.Focus()
            End With
        Else
            txtSerie.Focus()
        End If
    End Sub

    Private Sub txtNCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If txtIdSerie.Text <> "" Then
                    If Not txtNCliente.Text.Trim() = "" Then
                        Using db As New CodeFirst
                            Dim cliente = db.Clientes.Where(Function(f) f.N_CLIENTE = txtNCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                            If Not cliente Is Nothing Then
                                'cargar otros datos del cliente
                                If cliente.LIMITECREDITO <= 0 Then
                                    MessageBox.Show("Error, Este cliente no tiene crédito.")
                                    txtIdCliente.Clear()
                                    txtNombreCliente.Clear()
                                    txtNCliente.Focus()
                                    Exit Sub
                                End If
                                txtIdCliente.Text = cliente.IDCLIENTE
                                txtNombreCliente.Text = cliente.N_CLIENTE & " | " & cliente.NOMBRES & " " & cliente.APELLIDOS

                                txtNCliente.Clear()
                                txtObservacion.Focus()

                                cliente = Nothing
                            Else
                                MessageBox.Show("Error, No se encuentra este cliente.")
                                txtNCliente.Focus()
                            End If
                        End Using
                    Else
                        If txtIdCliente.Text.Trim() = "" Then
                            frmBuscarClientes.frm_return = 15 'retornar el valor aqui
                            frmBuscarClientes.ShowDialog()
                            If Not txtIdCliente.Text.Trim() = "" Then
                                Using db As New CodeFirst
                                    Dim cliente = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                                    If Not cliente Is Nothing Then
                                        'cargar otros datos del cliente
                                        If cliente.LIMITECREDITO <= 0 Then
                                            MessageBox.Show("Error, Este cliente no tiene crédito.")
                                            Exit Sub
                                        End If

                                        txtNCliente.Clear()
                                        txtObservacion.Focus()

                                        cliente = Nothing
                                    Else
                                        MessageBox.Show("Error, No se encuentra este cliente.")
                                        txtNCliente.Focus()
                                    End If
                                End Using
                            Else
                                txtNCliente.Focus()
                            End If
                        Else
                            txtObservacion.Focus()
                        End If
                    End If
                Else
                    MessageBox.Show("Error, Seleccione una serie.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btCliente_Click(sender As Object, e As EventArgs) Handles btCliente.Click
        Try
            If txtIdSerie.Text <> "" Then
                frmBuscarClientes.frm_return = 15 'retornar el valor aqui
                frmBuscarClientes.ShowDialog()
                If Not txtIdCliente.Text.Trim() = "" Then
                    Using db As New CodeFirst
                        Dim cliente = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not cliente Is Nothing Then
                            'cargar otros datos del cliente
                            If cliente.LIMITECREDITO <= 0 Then
                                MessageBox.Show("Error, Este cliente no tiene crédito.")
                                txtIdCliente.Clear()
                                txtNombreCliente.Clear()
                                txtNCliente.Focus()
                                Exit Sub
                            End If

                            txtNCliente.Clear()
                            txtObservacion.Focus()

                            cliente = Nothing
                        Else
                            MessageBox.Show("Error, No se encuentra este cliente. Probablemente alla sido eliminado.")
                        End If
                    End Using
                Else
                    txtNCliente.Focus()
                End If
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            txtIdCliente.Clear()
            txtNombreCliente.Clear()
            txtNCliente.Focus()
        End Try
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                txtMontoTotal.Focus()
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub btFacturas_Click(sender As Object, e As EventArgs) Handles btFacturas.Click
        If txtIdSerie.Text <> "" Then
            If Not txtIdCliente.Text.Trim() = "" Then
                frmDocumentosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                frmDocumentosPendientes.IdCliente = txtIdCliente.Text
                frmDocumentosPendientes.ShowDialog()
                If Not txtIdFactura.Text.Trim = "" Then
                    cmbOperacion.Focus()
                End If
            Else
                MessageBox.Show("Error, Seleccione un cliente.")
            End If
        Else
            MessageBox.Show("Error, Seleccione una serie.")
        End If
    End Sub

    Private Sub txtFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFactura.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtIdCliente.Text.Trim() = "" Then
                    If Not txtIdFactura.Text.Trim = "" Then
                        cmbOperacion.Focus()
                    Else
                        frmDocumentosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                        frmDocumentosPendientes.IdCliente = txtIdCliente.Text
                        frmDocumentosPendientes.ShowDialog()
                        If Not txtIdFactura.Text.Trim = "" Then
                            cmbOperacion.Focus()
                        End If
                    End If
                Else
                    MessageBox.Show("Error, Seleccione un cliente.")
                End If
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
        End If
    End Sub

    Private Sub cmbOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperacion.SelectedIndexChanged
        txtMonto.Focus()
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtIdCliente.Text.Trim() = "" Then
                    If Not txtIdFactura.Text.Trim = "" Then
                        Using db As New CodeFirst
                            Dim v = (From ven In db.Ventas Join ser In db.Series On ven.IDSERIE Equals ser.IDSERIE Where ven.ANULADO = "N" And ven.IDVENTA = txtIdFactura.Text Select ven, ser).FirstOrDefault()
                            If Not v Is Nothing Then
                                If v.ven.SALDOCREDITO >= If(v.ven.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, (txtMonto.Value + txtDescuento.Value), (txtMonto.Value + txtDescuento.Value) * txtTazaCambio.Value), If(rdDolar.Checked, (txtMonto.Value + txtDescuento.Value), (txtMonto.Value + txtDescuento.Value) / txtTazaCambio.Value)) Then
                                    Dim d = detalles.Where(Function(f) f.IDVENTA = v.ven.IDVENTA).FirstOrDefault()
                                    Dim nuevo As Boolean = False
                                    If d Is Nothing Then
                                        d = New LST_DETALLE_RECIBO : nuevo = True
                                    End If
                                    With d
                                        d.IDVENTA = v.ven.IDVENTA
                                        d.SERIE = v.ser.NOMBRE
                                        d.CONSECUTIVO = v.ven.CONSECUTIVO
                                        d.FECHA = v.ven.FECHAFACTURA
                                        d.MONEDA = v.ven.MONEDA
                                        d.TAZA = v.ven.TAZACAMBIO
                                        d.DESCUENTO_DIN_TOTAL_C = v.ven.DESCUENTO_DIN_C : d.DESCUENTO_DIN_TOTAL_D = v.ven.DESCUENTO_DIN_D
                                        d.IVA_DIN_TOTAL_C = v.ven.IVA_DIN_C : d.IVA_DIN_TOTAL_D = v.ven.IVA_DIN_D
                                        d.TOTAL_C = v.ven.TOTAL_C : d.TOTAL_D = v.ven.TOTAL_D
                                        d.SALDOCREDITO = v.ven.SALDOCREDITO
                                        d.OPERACION = cmbOperacion.Text
                                        If rdCordoba.Checked Then
                                            .IMPORTE_C = txtMonto.Value : .IMPORTE_D = txtMonto.Value / txtTazaCambio.Value
                                            .DESCUENTO_C = txtDescuento.Value : .DESCUENTO_D = txtDescuento.Value / txtTazaCambio.Value
                                        Else
                                            .IMPORTE_C = txtMonto.Value * txtTazaCambio.Value : .IMPORTE_D = txtMonto.Value
                                            .DESCUENTO_C = txtDescuento.Value * txtTazaCambio.Value : .DESCUENTO_D = txtDescuento.Value
                                        End If
                                        If cmbOperacion.Text = "C" Then
                                            If txtMonto.Value + txtDescuento.Value < If(v.ven.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, v.ven.SALDOCREDITO, v.ven.SALDOCREDITO / txtTazaCambio.Value), If(rdDolar.Checked, v.ven.SALDOCREDITO, v.ven.SALDOCREDITO * txtTazaCambio.Value)) Then
                                                .OPERACION = "A"
                                                .NUEVO_SALDO_C = If(v.ven.MONEDA.Equals(Config.cordoba), v.ven.SALDOCREDITO, v.ven.SALDOCREDITO * txtTazaCambio.Value) - .IMPORTE_C - .DESCUENTO_C : .NUEVO_SALDO_D = If(v.ven.MONEDA.Equals(Config.dolar), v.ven.SALDOCREDITO, v.ven.SALDOCREDITO / txtTazaCambio.Value) - .IMPORTE_D - .DESCUENTO_D
                                            Else
                                                .NUEVO_SALDO_C = 0.0 : .NUEVO_SALDO_D = 0.0
                                            End If
                                        Else
                                            If txtMonto.Value + txtDescuento.Value < If(v.ven.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, v.ven.SALDOCREDITO, v.ven.SALDOCREDITO * txtTazaCambio.Value), If(rdDolar.Checked, v.ven.SALDOCREDITO, v.ven.SALDOCREDITO / txtTazaCambio.Value)) Then
                                                .NUEVO_SALDO_C = If(v.ven.MONEDA.Equals(Config.cordoba), v.ven.SALDOCREDITO, v.ven.SALDOCREDITO * txtTazaCambio.Value) - .IMPORTE_C - .DESCUENTO_C : .NUEVO_SALDO_D = If(v.ven.MONEDA.Equals(Config.dolar), v.ven.SALDOCREDITO, v.ven.SALDOCREDITO / txtTazaCambio.Value) - .IMPORTE_D - .DESCUENTO_D
                                            Else
                                                .NUEVO_SALDO_C = 0.0 : .NUEVO_SALDO_D = 0.0
                                                .OPERACION = "C"
                                            End If
                                        End If
                                    End With
                                    If nuevo Then
                                        detalles.Add(d)
                                    End If
                                    Grid()
                                    txtIdFactura.Clear()
                                    txtFactura.Clear()
                                    cmbOperacion.Text = "C"
                                    txtMonto.Text = Nothing
                                    txtDescuento.Text = Nothing
                                    txtFactura.Focus()
                                Else
                                    MessageBox.Show("Error, El monto ingresado es mayor al de la factura.")
                                End If
                            Else
                                MessageBox.Show("Error, No se encuentra esta Venta. Probablemente alla sido eliminada.")
                            End If
                            v = Nothing
                        End Using
                    Else
                        frmDocumentosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                        frmDocumentosPendientes.IdCliente = txtIdCliente.Text
                        frmDocumentosPendientes.ShowDialog()
                        If Not txtIdFactura.Text.Trim = "" Then
                            cmbOperacion.Focus()
                        End If
                    End If
                Else
                    MessageBox.Show("Error, Seleccione un cliente.")
                End If
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
        End If
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtMonto.Focus()
        End If
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub txtMontoTotal_ValueChanged(sender As Object, e As EventArgs) Handles txtMontoTotal.ValueChanged
        txtAplicable.Value = txtMontoTotal.Value.ToString(Config.f_m) - txtTotalImporte.Value.ToString(Config.f_m) - txtTotalDescuento.Value.ToString(Config.f_m) - txtSobrantedeCaja.Value.ToString(Config.f_m)
    End Sub

    Private Sub txtSobrantedeCaja_ValueChanged(sender As Object, e As EventArgs) Handles txtSobrantedeCaja.ValueChanged
        txtAplicable.Value = txtMontoTotal.Value.ToString(Config.f_m) - txtTotalImporte.Value.ToString(Config.f_m) - txtTotalDescuento.Value.ToString(Config.f_m) - txtSobrantedeCaja.Value.ToString(Config.f_m)
    End Sub

    Private Sub txtTotalImporte_TextChanged(sender As Object, e As EventArgs)
        txtAplicable.Value = txtMontoTotal.Value - txtTotalImporte.Value - txtTotalDescuento.Value - txtSobrantedeCaja.Value
    End Sub

    Private Sub txtMontoTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoTotal.KeyPress
        If txtIdSerie.Text <> "" Then
            If e.KeyChar = ChrW(13) Then
                txtFactura.Focus()
            End If
        Else
            MessageBox.Show("Error, Seleccione una serie.")
        End If
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If Config.ValidarPeriodo(dtpFecha.Value) Then
            Try
                If txtIdSerie.Text <> "" And Not txtIdCliente.Text.Trim() = "" And detalles.Count > 0 Then
                    If Math.Round(txtAplicable.Value, 2) = 0.0 Then
                        Using db As New CodeFirst
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            If Not txtCodigo.Text.Trim() = "" Then
                                If dtpFecha.Text = DateTime.Now.ToShortDateString() Then
                                    dtpFecha.Value = DateTime.Now
                                Else
                                    dtpFecha.Value = DateTime.Parse(dtpFecha.Text & " " & DateTime.Now.ToString("HH:mm:ss"))
                                End If
                                Dim recibo As New VentaRecibo : recibo.Reg = DateTime.Now : recibo.IDRECIBO = Guid.NewGuid.ToString() : recibo.IDSERIE = txtIdSerie.Text : recibo.CONSECUTIVO = txtCodigo.Text : recibo.FECHARECIBO = dtpFecha.Value : recibo.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : recibo.TAZACAMBIO = txtTazaCambio.Value : recibo.FORMADEPAGO = "Sin Especificar" : recibo.N_PAGO = "" : recibo.CONCEPTO = txtObservacion.Text : recibo.IMPORTETOTAL_C = detalles.Sum(Function(f) f.IMPORTE_C) : recibo.IMPORTETOTAL_D = detalles.Sum(Function(f) f.IMPORTE_D) : recibo.DESCUENTOTOTAL_C = detalles.Sum(Function(f) f.DESCUENTO_C) : recibo.DESCUENTOTOTAL_D = detalles.Sum(Function(f) f.DESCUENTO_D) : recibo.SOBRANTEDECAJA_C = txtSobrantedeCaja.Value : recibo.MONTOTOTAL_C = txtMontoTotal.Value : recibo.IDEMPLEADO = txtIdVendedor.Text : recibo.IDCLIENTE = txtIdCliente.Text : recibo.REIMPRESION = "N" : recibo.ANULADO = "N" : db.VentasRecibos.Add(recibo)
                                Dim cont As Integer = 0 : Dim v As Venta

                                '******************Ciclo para recorrer el detalle*******************
                                For Each i In Me.detalles
                                    v = db.Ventas.Where(Function(f) f.ANULADO = "N" And f.IDVENTA = i.IDVENTA).FirstOrDefault
                                    If Not v Is Nothing Then
                                        If v.SALDOCREDITO > 0 Then
                                            If v.SALDOCREDITO >= If(v.MONEDA.Equals(Config.cordoba), i.IMPORTE_C + i.DESCUENTO_C, i.IMPORTE_D + i.DESCUENTO_D) Then
                                                Dim d As New VentaReciboDetalle : d.IDDETALLERECIBO = Guid.NewGuid.ToString() : d.IDVENTA = v.IDVENTA : d.SALDOCREDITO = v.SALDOCREDITO : d.OPERACION = i.OPERACION : d.IMPORTE_C = i.IMPORTE_C : d.IMPORTE_D = i.IMPORTE_D : d.DESCUENTO_C = i.DESCUENTO_C : d.DESCUENTO_D = i.DESCUENTO_D : d.NUEVO_SALDO_C = If(v.MONEDA.Equals(Config.cordoba), v.SALDOCREDITO, v.SALDOCREDITO * txtTazaCambio.Value) - i.IMPORTE_C - i.DESCUENTO_C : d.NUEVO_SALDO_D = If(v.MONEDA.Equals(Config.cordoba), v.SALDOCREDITO / txtTazaCambio.Value, v.SALDOCREDITO) - i.IMPORTE_D - i.DESCUENTO_D : d.IDRECIBO = recibo.IDRECIBO : db.VentasRecibosDetalles.Add(d)
                                                v.SALDOCREDITO = If(v.MONEDA.Equals(Config.cordoba), d.NUEVO_SALDO_C, d.NUEVO_SALDO_D)
                                                db.Entry(v).State = EntityState.Modified
                                                If v.SALDOCREDITO <= 0 Then
                                                    d.OPERACION = "C" : v.SALDOCREDITO = 0
                                                Else
                                                    d.OPERACION = "A"
                                                End If
                                                If v.MONEDA.Equals(Config.cordoba) Then
                                                    v.Cliente.FACTURADO_C = v.Cliente.FACTURADO_C - d.IMPORTE_C - d.DESCUENTO_C
                                                Else
                                                    v.Cliente.FACTURADO_D = v.Cliente.FACTURADO_D - d.IMPORTE_D - d.DESCUENTO_D
                                                End If
                                                db.Entry(v.Cliente).State = EntityState.Modified
                                                Dim estado As New VentaEstadoCuenta : estado.IDESTADO = Guid.NewGuid.ToString() : estado.IDSERIE = recibo.IDSERIE : estado.N_DOCUMENTO = recibo.CONSECUTIVO : estado.OPERACION = "R/C" : estado.FECHA = recibo.FECHARECIBO : estado.PLAZO = 0 : estado.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : estado.TAZACAMBIO = txtTazaCambio.Value : estado.DEBE_C = 0.0 : estado.DEBE_D = 0.0 : estado.HABER_C = d.IMPORTE_C + d.DESCUENTO_C : estado.HABER_D = d.IMPORTE_D + d.DESCUENTO_D : estado.ACTIVO = "S" : estado.IDVENTA = v.IDVENTA : estado.IDRECIBO = recibo.IDRECIBO : db.VentasEstadosCuentas.Add(estado) : estado = Nothing
                                                d = Nothing
                                                cont = cont + 1 'incrementar contador
                                            Else
                                                MessageBox.Show("El monto de la Factura '" & i.SERIE & " | " & i.CONSECUTIVO & "' es menor que el ingresado.")
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("Parece que la Factura '" & i.SERIE & " | " & i.CONSECUTIVO & "' ya ha sido cancelada.")
                                            Exit Sub
                                        End If
                                    Else
                                        MessageBox.Show("Error, No se encuentra la Factura '" & i.SERIE & " | " & i.CONSECUTIVO & "'. Probablemente ha sido anulada o no existe.")
                                        Exit Sub
                                    End If
                                Next
                                '****************Fin Ciclo para recorrer el detalle*****************
                                If cont > 0 Then
                                    db.SaveChanges()
                                    Me.Id = recibo.IDRECIBO
                                    txtSerie.Enabled = False : btActualizarSerie.Enabled = False : txtCodigo.Enabled = False : btGuardar.Enabled = False : btAnular.Enabled = True : btImprimir.Enabled = True
                                Else
                                    MessageBox.Show("Error, No se puede guardar 'Recibo' si detalle.")
                                End If
                                cont = Nothing : v = Nothing
                            Else
                                MessageBox.Show("Error, No se ha podido generar el nuevo código. Intente mas tarde, si el problema persiste contacte con el administrador.")
                            End If
                        End Using
                    Else
                        MessageBox.Show("Error, Para guardar el 'Recibo' el aplicable debe ser 0")
                    End If
                Else
                    MessageBox.Show("Error, Faltan datos.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub LoadMov(ByVal v As VentaRecibo)
        Try
            Me.FormLoad = False
            Me.Id = v.IDRECIBO
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            txtCodigo.Enabled = False
            dtpFecha.Text = v.FECHARECIBO.ToShortDateString()
            txtIdVendedor.Text = v.Empleado.IDEMPLEADO
            txtNombreVendedor.Text = v.Empleado.N_TRABAJADOR & " | " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS
            If v.VentasRecibosDetalles.Count > 0 Then
                txtIdCliente.Text = v.VentasRecibosDetalles(0).Venta.Cliente.IDCLIENTE
                txtNombreCliente.Text = v.VentasRecibosDetalles(0).Venta.Cliente.N_CLIENTE & " | " & v.VentasRecibosDetalles(0).Venta.Cliente.NOMBRES & " " & v.VentasRecibosDetalles(0).Venta.Cliente.APELLIDOS
            End If
            txtObservacion.Text = v.CONCEPTO
            txtMontoTotal.Text = v.MONTOTOTAL_C
            txtSobrantedeCaja.Text = v.SOBRANTEDECAJA_C

            'cargar detalle
            detalles.RemoveAll(Function(f) True)
            txtTazaCambio.Value = v.TAZACAMBIO
            If v.MONEDA = Config.cordoba Then
                rdCordoba.Checked = True
            Else
                rdDolar.Checked = True
            End If
            Dim item As LST_DETALLE_RECIBO
            For Each d In v.VentasRecibosDetalles
                item = New LST_DETALLE_RECIBO
                item.IDVENTA = d.Venta.IDVENTA
                item.SERIE = d.Venta.Serie.NOMBRE
                item.CONSECUTIVO = d.Venta.CONSECUTIVO
                item.FECHA = d.Venta.FECHAFACTURA
                item.MONEDA = d.Venta.MONEDA
                item.SUBTOTAL_C = d.Venta.SUBTOTAL_C : item.SUBTOTAL_D = d.Venta.SUBTOTAL_D
                item.DESCUENTO_DIN_TOTAL_C = d.Venta.DESCUENTO_DIN_C : item.DESCUENTO_DIN_TOTAL_D = d.Venta.DESCUENTO_DIN_D
                item.IVA_DIN_TOTAL_C = d.Venta.IVA_DIN_C : item.IVA_DIN_TOTAL_D = d.Venta.IVA_DIN_D
                item.TOTAL_C = d.Venta.TOTAL_C : item.TOTAL_D = d.Venta.TOTAL_D
                item.SALDOCREDITO = d.SALDOCREDITO

                item.OPERACION = d.OPERACION
                item.IMPORTE_C = d.IMPORTE_C : item.IMPORTE_D = d.IMPORTE_D
                item.DESCUENTO_C = d.DESCUENTO_C : item.DESCUENTO_D = d.DESCUENTO_D
                item.NUEVO_SALDO_C = d.NUEVO_SALDO_C : item.NUEVO_SALDO_D = d.NUEVO_SALDO_D
                detalles.Add(item) : item = Nothing
            Next
            Grid()
            lblContador.Text = "N° ITEM: " & dtRegistro.Rows.Count

            btGuardar.Enabled = False
            If Config._Periodo.ACTUAL.Equals(Config.vTrue) And Config._Periodo.APERTURA IsNot Nothing And Config._Periodo.CIERRE Is Nothing Then
                btAnular.Enabled = True
            End If
            btImprimir.Enabled = True
            Me.FormLoad = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub LoadInfo(Optional ByVal vInt As VentaRecibo = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            If txtIdSerie.Text <> "" Then
                If Not ByInt Then
                    Using db As New CodeFirst
                        Dim v = db.VentasRecibos.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                        If Not v Is Nothing Then
                            If v.ANULADO = "N" Then
                                Me.LoadMov(v)
                            Else
                                MessageBox.Show("Recibo anulado")
                            End If
                        Else
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            txtNVendedor.Focus()
                        End If
                    End Using
                Else
                    Me.LoadMov(vInt)
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            Me.LoadInfo()
        End If
    End Sub

    Private Sub btAnular_Click(sender As Object, e As EventArgs) Handles btAnular.Click
        Try
            If MessageBox.Show("¿Desea anular esta Recibo?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                If Not Me.Id.Trim = "" Then
                    Using db As New CodeFirst
                        Dim r = db.VentasRecibos.Where(Function(f) f.IDRECIBO = Me.Id And f.ANULADO = "N").FirstOrDefault()
                        If Not r Is Nothing Then
                            If Config.ValidarPeriodo(r.FECHARECIBO) Then
                                r.ANULADO = "S" : db.Entry(r).State = EntityState.Modified
                                For Each est In db.VentasEstadosCuentas.Where(Function(f) f.IDRECIBO IsNot Nothing).Where(Function(f) f.IDRECIBO = r.IDRECIBO)
                                    est.ACTIVO = "N" : db.Entry(est).State = EntityState.Modified
                                Next
                                For Each d_r In r.VentasRecibosDetalles
                                    Dim v = db.Ventas.Where(Function(f) f.IDVENTA = d_r.IDVENTA).FirstOrDefault()
                                    If Not v Is Nothing Then
                                        If v.MONEDA.Equals(Config.cordoba) Then
                                            v.Cliente.FACTURADO_C = v.Cliente.FACTURADO_C + d_r.IMPORTE_C + d_r.DESCUENTO_C
                                            v.SALDOCREDITO = v.SALDOCREDITO + d_r.IMPORTE_C + d_r.DESCUENTO_C
                                        Else
                                            v.Cliente.FACTURADO_D = v.Cliente.FACTURADO_D + d_r.IMPORTE_D + d_r.DESCUENTO_D
                                            v.SALDOCREDITO = v.SALDOCREDITO + d_r.IMPORTE_D + d_r.DESCUENTO_D
                                        End If
                                        db.Entry(v.Cliente).State = EntityState.Modified : db.Entry(v).State = EntityState.Modified
                                    End If
                                Next
                                db.SaveChanges() : limpiar() : MessageBox.Show("Recibo Anulado")
                            End If
                            r = Nothing
                        Else
                            MessageBox.Show("Error, No se encuentra este recibo o ya ha sido anulado.")
                        End If
                        r = Nothing
                    End Using
                Else
                    MessageBox.Show("Error, Seleccione un recibo")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmReciboVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    btNuevo_Click(Nothing, Nothing)
                Case Keys.G
                    If btGuardar.Enabled Then
                        btGuardar_Click(Nothing, Nothing)
                    End If
                Case Keys.Delete
                    If btAnular.Enabled Then
                        btAnular_Click(Nothing, Nothing)
                    End If
                Case Keys.P
                    If btImprimir.Enabled Then
                        btImprimir_Click(Nothing, Nothing)
                    End If
            End Select
        End If
        Select Case e.KeyData
            Case Keys.F1
                txtFactura.Focus()
            Case Keys.F2
                cmbOperacion.Focus()
            Case Keys.F4
                txtMonto.Focus()
            Case Keys.F5
                txtDescuento.Focus()
            Case Keys.F3
                If txtCodigo.Focused Then
                    frmBReciboVenta.ShowDialog()
                End If
            Case Keys.F12
                btEstadoCliente_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        Try
            Using db As New CodeFirst
                Dim v = db.VentasRecibos.Where(Function(f) f.IDRECIBO = Me.Id).FirstOrDefault
                If Not v Is Nothing Then
                    If v.ANULADO = "N" Then
                        Dim t As TicketClass = New TicketClass
                        If t.ImpresoraExistente(Config.PrintName) Then
                            t.EncabezadoPredefinido("RECIBO DE VENTA", If(v.REIMPRESION.Equals("S"), "REIMPRESIÓN", "ORIGINAL"))

                            t.AnadirLineaSubcabeza(t.AlinearElementos("N° RECIBO: " & v.CONSECUTIVO, v.Serie.NOMBRE))
                            t.AnadirLineaSubcabeza("FECHA:   " & v.FECHARECIBO.ToShortDateString())
                            t.AnadirLineaSubcabeza("CÓDIGO:  " & If(v.Cliente IsNot Nothing, v.Cliente.N_CLIENTE, ""))
                            t.AnadirLineaSubcabeza("CLIENTE: " & v.Cliente.NOMBRES & " " & v.Cliente.APELLIDOS)
                            t.AnadirLineaSubcabeza("R. SOC.: " & v.Cliente.RAZONSOCIAL)
                            t.AnadirLineaSubcabeza("ATENDIÓ: " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS)
                            t.AnadirEspacio()
                            t.AnadirElemento(t.Linea5())
                            t.AnadirElemento("FACT.     SALDO     IMPOR     DESC")
                            t.AnadirElemento(t.Linea5())
                            t.AnadirEspacio()

                            t.DetalleSeparador()
                            For Each i In From ven In db.Ventas Join det In db.VentasRecibosDetalles On ven.IDVENTA Equals det.IDVENTA Where det.IDRECIBO = v.IDRECIBO Select SERIE = ven.Serie.NOMBRE, ven.CONSECUTIVO, ven.FECHAFACTURA, ven.MONEDA, TOTAL = If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D), det.SALDOCREDITO, OPERACION = If(det.OPERACION.Equals("C"), "Cancelar", "Abonar"), IMPORTE = If(v.MONEDA.Equals(Config.cordoba), det.IMPORTE_C, det.IMPORTE_D), DESCUENTO = If(v.MONEDA.Equals(Config.cordoba), det.DESCUENTO_C, det.DESCUENTO_D), NUEVO_SALDO = If(v.MONEDA.Equals(Config.cordoba), det.NUEVO_SALDO_C, det.NUEVO_SALDO_D)
                                t.AnadirElemento(i.SERIE & " - " & i.CONSECUTIVO)
                                t.AnadirElementoTotales(i.SALDOCREDITO.ToString(Config.f_m), i.IMPORTE.ToString(Config.f_m), i.DESCUENTO.ToString(Config.f_m))
                                t.AnadirEspacio()
                            Next
                            t.AnadirEspacio()
                            t.AnadirElemento(t.Linea5())
                            t.AnadirTotal("   IMPORTE " & If(v.MONEDA.Equals(Config.cordoba), "C$", " $"), If(v.MONEDA.Equals(Config.cordoba), v.IMPORTETOTAL_C, v.IMPORTETOTAL_D))
                            t.AnadirTotal(" DESCUENTO " & If(v.MONEDA.Equals(Config.cordoba), "C$", " $"), If(v.MONEDA.Equals(Config.cordoba), v.DESCUENTOTOTAL_C, v.DESCUENTOTOTAL_D))
                            t.AnadirTotal("     TOTAL " & If(v.MONEDA.Equals(Config.cordoba), "C$", " $"), If(v.MONEDA.Equals(Config.cordoba), v.MONTOTOTAL_C, v.MONTOTOTAL_D))
                            t.AnadirEspacio()
                            t.AnadeLineaAlPie(NumeroALetra.Letras(If(v.MONEDA.Equals(Config.cordoba), v.MONTOTOTAL_C.ToString(), v.MONTOTOTAL_D.ToString())))
                            t.AnadirEspacio()
                            t.AnadirEspacio()
                            t.AnadirEspacio()

                            '//firma del cliente
                            t.AnadeLineaAlPie("__________________________________")
                            t.AnadeLineaAlPie("           FIRMA DEL CLIENTE")
                            '//El metodo AddFooterLine funciona igual que la cabecera 
                            t.AnadeLineaAlPie("*******GRACIAS POR TU VISITA******")
                            t.AnadeLineaAlPie(t.Centrar(v.Serie.Bodega.DESCRIPCION, "", ""))

                            '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                            '//parametro de tipo string que debe de ser el nombre de la impresora. 
                            t.ImprimeTicket(Config.PrintName)

                            'reimpresión
                            v.REIMPRESION = "S"
                            db.Entry(v).State = EntityState.Modified
                            db.SaveChanges()
                        Else
                            MessageBox.Show("No se encuentra la impresora '" & Config.PrintName & "'")
                        End If
                    Else
                        MessageBox.Show("Esta 'Recibo de Venta' esta anulado")
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta 'Recibo de Venta'. Problemente ha sido eliminada.")
                End If
                v = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmReciboVenta_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ElGroupBox3.Left = Me.PanelEx3.Width - ElGroupBox3.Width - 7
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress
        If e.KeyChar = ChrW(13) Then
            btActualizarSerie_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtTotalImporte_ValueChanged(sender As Object, e As EventArgs) Handles txtTotalImporte.ValueChanged
        txtAplicable.Value = txtMontoTotal.Value.ToString(Config.f_m) - txtTotalImporte.Value.ToString(Config.f_m) - txtTotalDescuento.Value.ToString(Config.f_m) - txtSobrantedeCaja.Value.ToString(Config.f_m)
    End Sub

    Private Sub txtTotalDescuento_ValueChanged(sender As Object, e As EventArgs) Handles txtTotalDescuento.ValueChanged
        txtAplicable.Value = txtMontoTotal.Value.ToString(Config.f_m) - txtTotalImporte.Value.ToString(Config.f_m) - txtTotalDescuento.Value.ToString(Config.f_m) - txtSobrantedeCaja.Value.ToString(Config.f_m)
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Dim d = detalles.Where(Function(f) f.IDVENTA = dtRegistro.SelectedRows(0).Cells(0).Value).FirstOrDefault
            If Not d Is Nothing Then
                txtIdFactura.Text = d.IDVENTA
                txtFactura.Text = d.SERIE & " | " & d.CONSECUTIVO
                txtMonto.Text = If(rdCordoba.Checked, d.IMPORTE_C, d.IMPORTE_D)
                txtDescuento.Text = If(rdCordoba.Checked, d.DESCUENTO_C, d.DESCUENTO_D)
                cmbOperacion.Text = d.OPERACION
                d = Nothing
            End If
            txtMonto.Focus()
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dtRegistro.SelectedRows.Count > 0 Then
                detalles.Remove(detalles.Where(Function(f) f.IDVENTA = dtRegistro.SelectedRows(0).Cells(0).Value).FirstOrDefault())
                Grid()
                lblContador.Text = "N° ITEM: " & dtRegistro.Rows.Count
                txtMonto.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub rdCordoba_CheckedChanged(sender As Object, e As EventArgs) Handles rdCordoba.CheckedChanged
        If FormLoad Then
            If rdCordoba.Checked Then
                Grid()
                txtFactura.Focus()
            End If
        End If
    End Sub

    Private Sub rdDolar_CheckedChanged(sender As Object, e As EventArgs) Handles rdDolar.CheckedChanged
        If FormLoad Then
            If rdDolar.Checked Then
                Grid()
                txtFactura.Focus()
            End If
        End If
    End Sub

    Private Sub btEstadoCliente_Click(sender As Object, e As EventArgs) Handles btEstadoCliente.Click
        If txtIdCliente.Text <> "" Then
            frmEstado.frm_return = 0
            frmEstado.id = txtIdCliente.Text
            frmEstado.ShowDialog()
        Else
            MessageBox.Show("Seleccionar un 'Cliente' que este registrado.")
        End If
    End Sub

    Private Sub txtSobrantedeCaja_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSobrantedeCaja.KeyDown
        If e.KeyData = Keys.Enter Then
            txtFactura.Focus()
        End If
    End Sub

    Private Sub frmReciboVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub txtNVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNVendedor.KeyDown
        If e.KeyData = Keys.Enter Then
            Try
                If txtIdSerie.Text <> "" Then
                    Using db As New CodeFirst
                        If Not txtNVendedor.Text.Trim() = "" Then
                            Dim vendedor = db.Empleados.Where(Function(f) f.N_TRABAJADOR = txtNVendedor.Text And f.CONTABILIDAD And f.ACTIVO = "S").FirstOrDefault()
                            If Not vendedor Is Nothing Then
                                txtIdVendedor.Text = vendedor.IDEMPLEADO
                                txtNombreVendedor.Text = vendedor.N_TRABAJADOR & " | " & vendedor.NOMBRES & " " & vendedor.APELLIDOS
                                txtNVendedor.Clear()
                                txtNCliente.Focus()
                            Else
                                MessageBox.Show("Error, Debe ingresar un 'Cajero'")
                            End If
                            vendedor = Nothing
                        Else
                            If Not txtIdVendedor.Text.Trim = "" Then
                                txtNCliente.Focus()
                            Else
                                frmBuscarEmpleado.LaborPre = 4
                                frmBuscarEmpleado.frm_return = 15
                                frmBuscarEmpleado.ShowDialog()
                                If Not txtIdVendedor.Text.Trim = "" Then
                                    txtNCliente.Focus()
                                End If
                            End If
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Seleccione un serie.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btVendedor_Click(sender As Object, e As EventArgs) Handles btVendedor.Click
        frmBuscarEmpleado.LaborPre = 4
        frmBuscarEmpleado.frm_return = 15
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text.Trim() = "" Then
            txtNCliente.Focus()
        Else
            txtNVendedor.Focus()
        End If
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyData = Keys.Enter Then
            txtNVendedor.Focus()
        End If
    End Sub
End Class