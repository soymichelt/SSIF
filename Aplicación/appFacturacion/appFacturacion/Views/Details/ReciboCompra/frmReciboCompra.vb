Public Class frmReciboCompra

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
                txtIdProveedor.Clear()
                txtNProveedor.Clear()
                txtNombreProveedor.Clear()
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
            txtDescuento.Value = 0
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
                Dim recibo = db.ComprasRecibos.Where(Function(f) f.IDSERIE = serie).OrderBy(Function(f) f.CONSECUTIVO).ToList().LastOrDefault()
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
        frmSeleccionarSerie.operacion = "RECIBO DE COMPRA"
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

    Private Sub txtNProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNProveedor.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If txtIdSerie.Text <> "" Then
                    If Not txtNProveedor.Text.Trim() = "" Then
                        Using db As New CodeFirst
                            Dim proveedor = db.Proveedores.Where(Function(f) f.N_PROVEEDOR = txtNProveedor.Text And f.ACTIVO = "S").FirstOrDefault()
                            If Not proveedor Is Nothing Then
                                'cargar otros datos del proveedor
                                If proveedor.LIMITECREDITO <= 0 Then
                                    MessageBox.Show("Error, Este 'Proveedor' no tiene crédito.")
                                    txtIdProveedor.Clear()
                                    txtNombreProveedor.Clear()
                                    txtNProveedor.Focus()
                                    Exit Sub
                                End If
                                txtIdProveedor.Text = proveedor.IDPROVEEDOR
                                txtNombreProveedor.Text = If(proveedor.TIPOPERSONA = "Natural", proveedor.N_PROVEEDOR & " " & proveedor.NOMBRES & " " & proveedor.APELLIDOS & If(proveedor.RAZONSOCIAL.Trim() <> "", " // " & proveedor.N_PROVEEDOR & " " & proveedor.RAZONSOCIAL, ""), proveedor.N_PROVEEDOR & " " & proveedor.RAZONSOCIAL)

                                txtNProveedor.Clear()
                                txtObservacion.Focus()

                                proveedor = Nothing
                            Else
                                MessageBox.Show("Error, No se encuentra este 'Proveedor'.")
                                txtNProveedor.Focus()
                            End If
                        End Using
                    Else
                        If txtIdProveedor.Text.Trim() = "" Then
                            frmBuscarProveedor.frm_return = 3 'retornar el valor aqui
                            frmBuscarProveedor.ShowDialog()
                            If Not txtIdProveedor.Text.Trim() = "" Then
                                Using db As New CodeFirst
                                    Dim proveedor = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtIdProveedor.Text And f.ACTIVO = "S").FirstOrDefault()
                                    If Not proveedor Is Nothing Then
                                        'cargar otros datos del proveedor
                                        If proveedor.LIMITECREDITO <= 0 Then
                                            MessageBox.Show("Error, Este 'Proveedor' no tiene crédito.")
                                            Exit Sub
                                        End If

                                        txtNProveedor.Clear()
                                        txtObservacion.Focus()

                                        proveedor = Nothing
                                    Else
                                        MessageBox.Show("Error, No se encuentra este 'Proveedor'.")
                                        txtNProveedor.Focus()
                                    End If
                                End Using
                            Else
                                txtNProveedor.Focus()
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
                frmBuscarProveedor.frm_return = 3 'retornar el valor aqui
                frmBuscarProveedor.ShowDialog()
                If Not txtIdProveedor.Text.Trim() = "" Then
                    Using db As New CodeFirst
                        Dim p = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtIdProveedor.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not p Is Nothing Then
                            'cargar otros datos del cliente
                            If p.LIMITECREDITO <= 0 Then
                                MessageBox.Show("Error, Este 'Proveedor' no tiene crédito.")
                                txtIdProveedor.Clear()
                                txtNombreProveedor.Clear()
                                txtNProveedor.Focus()
                                Exit Sub
                            End If

                            txtNProveedor.Clear()
                            txtObservacion.Focus()

                            p = Nothing
                        Else
                            MessageBox.Show("Error, No se encuentra este 'Proveedor'. Probablemente alla sido eliminado.")
                        End If
                    End Using
                Else
                    txtNProveedor.Focus()
                End If
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            txtIdProveedor.Clear()
            txtNombreProveedor.Clear()
            txtNProveedor.Focus()
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
            If Not txtIdProveedor.Text.Trim() = "" Then
                frmPagosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                frmPagosPendientes.IdProveedor = txtIdProveedor.Text
                frmPagosPendientes.ShowDialog()
                If Not txtIdFactura.Text.Trim = "" Then
                    cmbOperacion.Focus()
                End If
            Else
                MessageBox.Show("Error, Seleccione un proveedor.")
            End If
        Else
            MessageBox.Show("Error, Seleccione una serie.")
        End If
    End Sub

    Private Sub txtFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFactura.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtIdProveedor.Text.Trim() = "" Then
                    If Not txtIdFactura.Text.Trim = "" Then
                        cmbOperacion.Focus()
                    Else
                        frmPagosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                        frmPagosPendientes.IdProveedor = txtIdProveedor.Text
                        frmPagosPendientes.ShowDialog()
                        If Not txtIdFactura.Text.Trim = "" Then
                            cmbOperacion.Focus()
                        End If
                    End If
                Else
                    MessageBox.Show("Error, Seleccione un proveedor.")
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
                If Not txtIdProveedor.Text.Trim() = "" Then
                    If Not txtIdFactura.Text.Trim = "" Then
                        Using db As New CodeFirst
                            Dim v = (From com In db.Compras Join ser In db.SERIES On com.IDSERIE Equals ser.IDSERIE Where com.ANULADO = "N" And com.IDCOMPRA = txtIdFactura.Text Select com, ser).FirstOrDefault()
                            If Not v Is Nothing Then
                                If v.com.SALDOCREDITO >= If(v.com.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, (txtMonto.Value + txtDescuento.Value), (txtMonto.Value + txtDescuento.Value) * txtTazaCambio.Value), If(rdDolar.Checked, (txtMonto.Value + txtDescuento.Value), (txtMonto.Value + txtDescuento.Value) / txtTazaCambio.Value)) Then
                                    Dim d = detalles.Where(Function(f) f.IDVENTA = v.com.IDCOMPRA).FirstOrDefault()
                                    Dim nuevo As Boolean = False
                                    If d Is Nothing Then
                                        d = New LST_DETALLE_RECIBO : nuevo = True
                                    End If
                                    With d
                                        d.IDVENTA = v.com.IDCOMPRA
                                        d.SERIE = v.ser.NOMBRE
                                        d.CONSECUTIVO = v.com.CONSECUTIVO
                                        d.FECHA = v.com.FECHACOMPRA
                                        d.MONEDA = v.com.MONEDA
                                        d.TAZA = v.com.TAZACAMBIO
                                        d.DESCUENTO_DIN_TOTAL_C = v.com.DESCUENTO_DIN_C
                                        d.DESCUENTO_DIN_TOTAL_D = v.com.DESCUENTO_DIN_D
                                        d.IVA_DIN_TOTAL_C = v.com.IVA_DIN_C
                                        d.IVA_DIN_TOTAL_D = v.com.IVA_DIN_D
                                        d.TOTAL_C = v.com.TOTAL_C
                                        d.TOTAL_D = v.com.TOTAL_D
                                        d.SALDOCREDITO = v.com.SALDOCREDITO
                                        d.OPERACION = cmbOperacion.Text
                                        If rdCordoba.Checked Then
                                            .IMPORTE_C = txtMonto.Value : .IMPORTE_D = txtMonto.Value / txtTazaCambio.Value
                                            .DESCUENTO_C = txtDescuento.Value : .DESCUENTO_D = txtDescuento.Value / txtTazaCambio.Value
                                        Else
                                            .IMPORTE_C = txtMonto.Value * txtTazaCambio.Value : .IMPORTE_D = txtMonto.Value
                                            .DESCUENTO_C = txtDescuento.Value * txtTazaCambio.Value : .DESCUENTO_D = txtDescuento.Value
                                        End If
                                        If cmbOperacion.Text = "C" Then
                                            If txtMonto.Value + txtDescuento.Value < If(v.com.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, v.com.SALDOCREDITO, v.com.SALDOCREDITO / txtTazaCambio.Value), If(rdDolar.Checked, v.com.SALDOCREDITO, v.com.SALDOCREDITO * txtTazaCambio.Value)) Then
                                                .OPERACION = "A"
                                                .NUEVO_SALDO_C = If(v.com.MONEDA.Equals(Config.cordoba), v.com.SALDOCREDITO, v.com.SALDOCREDITO * txtTazaCambio.Value) - .IMPORTE_C - .DESCUENTO_C : .NUEVO_SALDO_D = If(v.com.MONEDA.Equals(Config.dolar), v.com.SALDOCREDITO, v.com.SALDOCREDITO / txtTazaCambio.Value) - .IMPORTE_D - .DESCUENTO_D
                                            Else
                                                .NUEVO_SALDO_C = 0.0 : .NUEVO_SALDO_D = 0.0
                                            End If
                                        Else
                                            If txtMonto.Value + txtDescuento.Value < If(v.com.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, v.com.SALDOCREDITO, v.com.SALDOCREDITO * txtTazaCambio.Value), If(rdDolar.Checked, v.com.SALDOCREDITO, v.com.SALDOCREDITO / txtTazaCambio.Value)) Then
                                                .NUEVO_SALDO_C = If(v.com.MONEDA.Equals(Config.cordoba), v.com.SALDOCREDITO, v.com.SALDOCREDITO * txtTazaCambio.Value) - .IMPORTE_C - .DESCUENTO_C : .NUEVO_SALDO_D = If(v.com.MONEDA.Equals(Config.dolar), v.com.SALDOCREDITO, v.com.SALDOCREDITO / txtTazaCambio.Value) - .IMPORTE_D - .DESCUENTO_D
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
                                    MessageBox.Show("Error, El monto ingresado es mayor al de la 'Compra'.")
                                End If
                            Else
                                MessageBox.Show("Error, No se encuentra esta 'Compra'. Probablemente alla sido eliminada.")
                            End If
                            v = Nothing
                        End Using
                    Else
                        frmDocumentosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                        frmDocumentosPendientes.IdCliente = txtIdProveedor.Text
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
                If txtIdSerie.Text <> "" And Not txtIdProveedor.Text.Trim() = "" And detalles.Count > 0 Then
                    If Math.Round(txtAplicable.Value, 2) = 0.0 Then
                        Using db As New CodeFirst
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            If Not txtCodigo.Text.Trim() = "" Then
                                If dtpFecha.Text = DateTime.Now.ToShortDateString() Then
                                    dtpFecha.Value = DateTime.Now
                                Else
                                    dtpFecha.Value = DateTime.Parse(dtpFecha.Text & " " & DateTime.Now.ToString("HH:mm:ss"))
                                End If
                                Dim recibo As New CompraRecibo : recibo.Reg = DateTime.Now : recibo.IDRECIBO = Guid.NewGuid.ToString() : recibo.IDSERIE = txtIdSerie.Text : recibo.CONSECUTIVO = txtCodigo.Text : recibo.N_DOCUMENTO = txtNRecibo.Text : recibo.FECHARECIBO = dtpFecha.Value : recibo.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : recibo.TAZACAMBIO = txtTazaCambio.Value : recibo.FORMADEPAGO = "Sin Especificar" : recibo.N_PAGO = "" : recibo.CONCEPTO = txtObservacion.Text : recibo.IMPORTETOTAL_C = detalles.Sum(Function(f) f.IMPORTE_C) : recibo.IMPORTETOTAL_D = detalles.Sum(Function(f) f.IMPORTE_D) : recibo.DESCUENTOTOTAL_C = detalles.Sum(Function(f) f.DESCUENTO_C) : recibo.DESCUENTOTOTAL_D = detalles.Sum(Function(f) f.DESCUENTO_D) : recibo.SOBRANTEDECAJA_C = txtSobrantedeCaja.Value : recibo.MONTOTOTAL_C = txtMontoTotal.Value : recibo.IDEMPLEADO = txtIdVendedor.Text : recibo.IDPROVEEDOR = txtIdProveedor.Text : recibo.REIMPRESION = "N" : recibo.ANULADO = "N" : db.ComprasRecibos.Add(recibo)
                                Dim cont As Integer = 0 : Dim v As Compra

                                '******************Ciclo para recorrer el detalle*******************
                                For Each i In Me.detalles
                                    v = db.Compras.Where(Function(f) f.ANULADO = "N" And f.IDCOMPRA = i.IDVENTA).FirstOrDefault
                                    If Not v Is Nothing Then
                                        If v.SALDOCREDITO > 0 Then
                                            If v.SALDOCREDITO >= If(v.MONEDA.Equals(Config.cordoba), i.IMPORTE_C + i.DESCUENTO_C, i.IMPORTE_D + i.DESCUENTO_D) Then
                                                Dim d As New CompraReciboDetalle
                                                d.IDDETALLERECIBO = Guid.NewGuid.ToString()
                                                d.IDCOMPRA = v.IDCOMPRA
                                                d.SALDOCREDITO = v.SALDOCREDITO
                                                d.OPERACION = i.OPERACION
                                                d.IMPORTE_C = i.IMPORTE_C
                                                d.IMPORTE_D = i.IMPORTE_D
                                                d.DESCUENTO_C = i.DESCUENTO_C
                                                d.DESCUENTO_D = i.DESCUENTO_D
                                                d.NUEVO_SALDO_C = If(v.MONEDA.Equals(Config.cordoba), v.SALDOCREDITO, v.SALDOCREDITO * txtTazaCambio.Value) - i.IMPORTE_C - i.DESCUENTO_C
                                                d.NUEVO_SALDO_D = If(v.MONEDA.Equals(Config.cordoba), v.SALDOCREDITO / txtTazaCambio.Value, v.SALDOCREDITO) - i.IMPORTE_D - i.DESCUENTO_D
                                                d.IDRECIBO = recibo.IDRECIBO
                                                db.ComprasRecibosDetalles.Add(d)
                                                v.SALDOCREDITO = If(v.MONEDA.Equals(Config.cordoba), d.NUEVO_SALDO_C, d.NUEVO_SALDO_D)
                                                db.Entry(v).State = EntityState.Modified
                                                If v.SALDOCREDITO <= 0 Then
                                                    d.OPERACION = "C" : v.SALDOCREDITO = 0
                                                Else
                                                    d.OPERACION = "A"
                                                End If
                                                If v.MONEDA.Equals(Config.cordoba) Then
                                                    v.PROVEEDOR.FACTURADO_C = v.PROVEEDOR.FACTURADO_C - d.IMPORTE_C - d.DESCUENTO_C
                                                Else
                                                    v.PROVEEDOR.FACTURADO_D = v.PROVEEDOR.FACTURADO_D - d.IMPORTE_D - d.DESCUENTO_D
                                                End If
                                                db.Entry(v.PROVEEDOR).State = EntityState.Modified
                                                Dim estado As New CompraEstadoCuenta
                                                estado.IDESTADO = Guid.NewGuid.ToString()
                                                estado.IDSERIE = recibo.IDSERIE
                                                estado.N_DOCUMENTO = recibo.CONSECUTIVO
                                                estado.N_COMPRA = recibo.N_DOCUMENTO
                                                estado.OPERACION = "R/C"
                                                estado.FECHA = recibo.FECHARECIBO
                                                estado.FORMADEPAGO = recibo.FORMADEPAGO
                                                estado.N_PAGO = recibo.N_PAGO
                                                estado.PLAZO = 0
                                                estado.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                                estado.TAZACAMBIO = txtTazaCambio.Value
                                                estado.HABER_C = 0.0
                                                estado.HABER_D = 0.0
                                                estado.DEBE_C = d.IMPORTE_C + d.DESCUENTO_C
                                                estado.DEBE_D = d.IMPORTE_D + d.DESCUENTO_D
                                                estado.ACTIVO = "S" : estado.IDCOMPRA = v.IDCOMPRA
                                                estado.IDRECIBO = recibo.IDRECIBO
                                                db.ComprasEstadosCuentas.Add(estado)
                                                estado = Nothing
                                                d = Nothing
                                                cont = cont + 1 'incrementar contador
                                            Else
                                                MessageBox.Show("El monto de la Factura de Compra '" & v.Serie.NOMBRE & " | " & v.CONSECUTIVO & " (" & v.N_COMPRA & ")" & "' es menor que el ingresado.")
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("Parece que la Factura de Compra '" & i.SERIE & " | " & i.CONSECUTIVO & " (" & v.N_COMPRA & ")" & "' ya ha sido cancelada.")
                                            Exit Sub
                                        End If
                                    Else
                                        MessageBox.Show("Error, No se encuentra la Factura de Compra '" & i.SERIE & " | " & i.CONSECUTIVO & "'. Probablemente ha sido anulada o no existe.")
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

    Private Sub LoadMov(ByVal v As CompraRecibo)
        Try
            Me.FormLoad = False
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            Me.Id = v.IDRECIBO
            txtCodigo.Enabled = False
            dtpFecha.Text = v.FECHARECIBO.ToShortDateString()
            If v.ComprasRecibosDetalles.Count > 0 Then
                txtIdProveedor.Text = v.ComprasRecibosDetalles(0).Compra.PROVEEDOR.IDPROVEEDOR
                txtNombreProveedor.Text = v.ComprasRecibosDetalles(0).Compra.PROVEEDOR.N_PROVEEDOR & " | " & v.ComprasRecibosDetalles(0).Compra.PROVEEDOR.NOMBRES & " " & v.ComprasRecibosDetalles(0).Compra.PROVEEDOR.APELLIDOS
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
            For Each d In v.ComprasRecibosDetalles
                item = New LST_DETALLE_RECIBO
                item.IDVENTA = d.Compra.IDCOMPRA
                item.SERIE = d.Compra.Serie.NOMBRE
                item.CONSECUTIVO = d.Compra.CONSECUTIVO
                item.FECHA = d.Compra.FECHACOMPRA
                item.MONEDA = d.Compra.MONEDA
                item.SUBTOTAL_C = d.Compra.SUBTOTAL_C : item.SUBTOTAL_D = d.Compra.SUBTOTAL_D
                item.DESCUENTO_DIN_TOTAL_C = d.Compra.DESCUENTO_DIN_C : item.DESCUENTO_DIN_TOTAL_D = d.Compra.DESCUENTO_DIN_D
                item.IVA_DIN_TOTAL_C = d.Compra.IVA_DIN_C : item.IVA_DIN_TOTAL_D = d.Compra.IVA_DIN_D
                item.TOTAL_C = d.Compra.TOTAL_C : item.TOTAL_D = d.Compra.TOTAL_D
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

    Public Sub LoadInfo(Optional ByVal vInt As CompraRecibo = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            If txtIdSerie.Text <> "" Then
                If Not ByInt Then
                    Using db As New CodeFirst
                        Dim v = db.ComprasRecibos.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                        If Not v Is Nothing Then
                            If v.ANULADO = "N" Then
                                Me.LoadMov(v)
                            Else
                                MessageBox.Show("Recibo anulado")
                            End If
                        Else
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            txtNRecibo.Focus()
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
            Try
                Me.LoadInfo()
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btAnular_Click(sender As Object, e As EventArgs) Handles btAnular.Click
        Try
            If MessageBox.Show("¿Desea anular esta Recibo?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                If Not Me.Id.Trim = "" Then
                    Using db As New CodeFirst
                        Dim r = db.ComprasRecibos.Where(Function(f) f.IDRECIBO = Me.Id And f.ANULADO = "N").FirstOrDefault()
                        If Not r Is Nothing Then
                            If Config.ValidarPeriodo(r.FECHARECIBO) Then
                                r.ANULADO = "S" : db.Entry(r).State = EntityState.Modified
                                For Each est In db.VentasEstadosCuentas.Where(Function(f) f.IDRECIBO IsNot Nothing).Where(Function(f) f.IDRECIBO = r.IDRECIBO)
                                    est.ACTIVO = "N" : db.Entry(est).State = EntityState.Modified
                                Next
                                For Each d_r In r.ComprasRecibosDetalles
                                    Dim v = db.Compras.Where(Function(f) f.IDCOMPRA = d_r.IDCOMPRA).FirstOrDefault()
                                    If Not v Is Nothing Then
                                        If v.MONEDA.Equals(Config.cordoba) Then
                                            v.PROVEEDOR.FACTURADO_C = v.PROVEEDOR.FACTURADO_C + d_r.IMPORTE_C + d_r.DESCUENTO_C
                                            v.SALDOCREDITO = v.SALDOCREDITO + d_r.IMPORTE_C + d_r.DESCUENTO_C
                                        Else
                                            v.PROVEEDOR.FACTURADO_D = v.PROVEEDOR.FACTURADO_D + d_r.IMPORTE_D + d_r.DESCUENTO_D
                                            v.SALDOCREDITO = v.SALDOCREDITO + d_r.IMPORTE_D + d_r.DESCUENTO_D
                                        End If
                                        db.Entry(v.PROVEEDOR).State = EntityState.Modified : db.Entry(v).State = EntityState.Modified
                                    End If
                                Next
                                db.SaveChanges() : limpiar() : MessageBox.Show("Recibo Anulado")
                            End If
                            r = Nothing
                        Else
                            MessageBox.Show("Error, No se encuentra este 'Recibo'. Probablemente halla sido eliminado.")
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
        frmImprimirReciboCompra.IdRecibo = Me.Id
        frmImprimirReciboCompra.ShowDialog()
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
        If txtIdProveedor.Text <> "" Then
            frmEstado.frm_return = 1
            frmEstado.id = txtIdProveedor.Text
            frmEstado.ShowDialog()
        Else
            MessageBox.Show("Seleccionar un 'Proveedor' que este registrado.")
        End If
    End Sub

    Private Sub txtSobrantedeCaja_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSobrantedeCaja.KeyDown
        If e.KeyData = Keys.Enter Then
            txtFactura.Focus()
        End If
    End Sub

    Private Sub frmReciboVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub


    Private Sub txtTazaCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTazaCambio.ValueChanged
        If Me.FormLoad Then
            Try
                For Each d In Me.detalles
                    With d
                        If rdCordoba.Checked Then
                            .IMPORTE_D = txtMonto.Value / txtTazaCambio.Value
                            .DESCUENTO_D = txtDescuento.Value / txtTazaCambio.Value
                        Else
                            .IMPORTE_C = txtMonto.Value * txtTazaCambio.Value
                            .DESCUENTO_C = txtDescuento.Value * txtTazaCambio.Value
                        End If
                        If cmbOperacion.Text = "C" Then
                            If If(rdDolar.Checked, d.IMPORTE_C + d.DESCUENTO_C, d.IMPORTE_D + d.DESCUENTO_D) < If(d.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, d.SALDOCREDITO, d.SALDOCREDITO / txtTazaCambio.Value), If(rdDolar.Checked, d.SALDOCREDITO, d.SALDOCREDITO * txtTazaCambio.Value)) Then
                                .OPERACION = "A"
                                .NUEVO_SALDO_C = If(d.MONEDA.Equals(Config.cordoba), d.SALDOCREDITO, d.SALDOCREDITO * txtTazaCambio.Value) - .IMPORTE_C - .DESCUENTO_C : .NUEVO_SALDO_D = If(d.MONEDA.Equals(Config.dolar), d.SALDOCREDITO, d.SALDOCREDITO / txtTazaCambio.Value) - .IMPORTE_D - .DESCUENTO_D
                            Else
                                .NUEVO_SALDO_C = 0.0 : .NUEVO_SALDO_D = 0.0
                            End If
                        Else
                            If If(rdDolar.Checked, d.IMPORTE_C + d.DESCUENTO_C, d.IMPORTE_D + d.DESCUENTO_D) < If(d.MONEDA.Equals(Config.cordoba), If(rdCordoba.Checked, d.SALDOCREDITO, d.SALDOCREDITO * txtTazaCambio.Value), If(rdDolar.Checked, d.SALDOCREDITO, d.SALDOCREDITO / txtTazaCambio.Value)) Then
                                .NUEVO_SALDO_C = If(d.MONEDA.Equals(Config.cordoba), d.SALDOCREDITO, d.SALDOCREDITO * txtTazaCambio.Value) - .IMPORTE_C - .DESCUENTO_C : .NUEVO_SALDO_D = If(d.MONEDA.Equals(Config.dolar), d.SALDOCREDITO, d.SALDOCREDITO / txtTazaCambio.Value) - .IMPORTE_D - .DESCUENTO_D
                            Else
                                .NUEVO_SALDO_C = 0.0 : .NUEVO_SALDO_D = 0.0
                                .OPERACION = "C"
                            End If
                        End If
                    End With
                Next
                Me.Grid()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtNRecibo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNRecibo.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtIdSerie.Text <> "" Then
                If txtNRecibo.Text.Trim <> "" Then
                    txtNProveedor.Focus()
                Else
                    MessageBox.Show("Ingresar el Nº de Recibo.")
                End If
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
        End If
    End Sub

    Private Sub txtNVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNVendedor.KeyDown
        If e.KeyData = Keys.Enter Then
            Try
                If txtIdSerie.Text <> "" Then
                    Using db As New CodeFirst
                        If Not txtNVendedor.Text.Trim() = "" Then
                            Dim vendedor = db.EMPLEADOS.Where(Function(f) f.N_TRABAJADOR = txtNVendedor.Text And f.CONTABILIDAD And f.ACTIVO = "S").FirstOrDefault()
                            If Not vendedor Is Nothing Then
                                txtIdVendedor.Text = vendedor.IDEMPLEADO
                                txtNombreVendedor.Text = vendedor.N_TRABAJADOR & " | " & vendedor.NOMBRES & " " & vendedor.APELLIDOS
                                txtNVendedor.Clear()
                                txtNProveedor.Focus()
                            Else
                                MessageBox.Show("Error, Debe ingresar un 'Cajero'")
                            End If
                            vendedor = Nothing
                        Else
                            If Not txtIdVendedor.Text.Trim = "" Then
                                txtNProveedor.Focus()
                            Else
                                frmBuscarEmpleado.LaborPre = 4
                                frmBuscarEmpleado.frm_return = 16
                                frmBuscarEmpleado.ShowDialog()
                                If Not txtIdVendedor.Text.Trim = "" Then
                                    txtNProveedor.Focus()
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
        frmBuscarEmpleado.frm_return = 16
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text.Trim() = "" Then
            txtNProveedor.Focus()
        Else
            txtNVendedor.Focus()
        End If
    End Sub
End Class