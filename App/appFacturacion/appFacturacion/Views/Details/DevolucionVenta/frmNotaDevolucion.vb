Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmNotaDevolucion

    Dim bandDescFact As Boolean = False
    Dim bandDescProd As Boolean = False

    'factura seleccionada
    Public Id As String = ""

    Public detalles As New List(Of LST_DETALLE_DEVOLUCION_VENTA)

    Dim cod As String = ""

    Dim ExistenciaController As New Capadenegocio.Controller.ExistenciaController

    Dim FormLoad As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Sub limpiar()
        Try
            If txtIdSerie.Text <> "" Then
                txtSerie.Enabled = True
                btActualizarSerie.Enabled = True
                detalles.RemoveAll(Function(f) True)
                Grid()
                lblContador.Text = "N° ITEM: 0"
                txtTotalDescuento.Value = 0.0 : txtTotalIva.Value = 0.0 : txtTotalSubtotal.Value = 0.0 : txtTotal.Value = 0.0
                txtCodigo.Enabled = True
                txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                dtpFecha.Value = DateTime.Now
                txtIdVendedor.Clear()
                txtNVendedor.Clear()
                txtNombreVendedor.Clear()
                txtIdCliente.Clear()
                txtNCliente.Clear()
                txtNombreCliente.Clear()
                rdSindescuento.Checked = True
                chkExonerado.Checked = False
                btGuardar.Enabled = True : btAnular.Enabled = False
                txtCodigo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Function generarCodigo(ByVal serie As String) As String
        Try
            Using db As New CodeFirst
                Dim venta = ((From ven In db.Ventas Where ven.IDSERIE = serie Select ven.IDSERIE, ven.CONSECUTIVO).Union(From dev In db.VentasDevoluciones Where dev.IDSERIE = serie Select dev.IDSERIE, dev.CONSECUTIVO)).OrderBy(Function(f) f.CONSECUTIVO).ToList.LastOrDefault
                If Not venta Is Nothing Then
                    cod = venta.CONSECUTIVO
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

    Private Sub frmFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.WindowState = FormWindowState.Maximized Then
            Me.Width = Me.Parent.Width
        End If
        Me.frmNotaDevolucion_Resize(Nothing, Nothing)
        Try
            txtTazaCambio.DisplayFormat = Config.f_m
            txtDescuentoPorFactura.DisplayFormat = Config.f_m
            txtCantidad.DisplayFormat = Config.f_c
            txtPrecio.DisplayFormat = Config.f_m
            txtDescuentoPorProducto.DisplayFormat = Config.f_m
            txtTotalDescuento.DisplayFormat = Config.f_m
            txtTotalSubtotal.DisplayFormat = Config.f_m
            txtTotalIva.DisplayFormat = Config.f_m
            txtTotal.DisplayFormat = Config.f_m

            dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
            Using db As New CodeFirst
                Config._exchangeRate = db.Tazas.OrderByDescending(Function(f) f.FECHA).FirstOrDefault()
                If Not Config._exchangeRate Is Nothing Then
                    Config.exchangeRate = Config._exchangeRate.CAMBIO
                Else
                    Config.exchangeRate = 0
                    MessageBox.Show("Error, No existe Taza de Cambio")
                End If
            End Using
            txtTazaCambio.Value = Config.exchangeRate
            frmPrincipal.lblTaza.Text = "T. / Cambio: $ 1 = C$ " & Config.exchangeRate.ToString(Config.f_m)
            txtTotalSubtotal.Value = 0 : txtTotalDescuento.Value = 0 : txtTotalIva.Value = 0 : txtTotal.Value = 0
            If Not Config._lapse Is Nothing Then
                If Config._lapse.ACTUAL.Equals(Config.vTrue) Then
                    dtpFecha.MinDate = Config._lapse.INICIO
                    dtpFecha.MaxDate = Config._lapse.FINAL
                Else
                    dtpFecha.MinDate = "01/01/" & DateTime.Now.Year
                    dtpFecha.MaxDate = "31/12/" & DateTime.Now.Year
                End If
            Else
                Config.MsgErr("Seleccionar un Período Contable.")
                Exit Sub
            End If
            dtpFecha.Value = DateTime.Now
            Grid()
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        FormLoad = True
    End Sub

    Private Sub txtCodigoAlterno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoAlterno.KeyPress
        Try
            If e.KeyChar = ChrW(13) Then
                If txtIdSerie.Text <> "" Then
                    If Not txtCodigoAlterno.Text.Trim = "" Then
                        Using db As New CodeFirst
                            Dim producto = ExistenciaController.BuscarProductoPorCodigo(txtCodigoAlterno.Text.Trim(), Config.warehouseId)
                            If Not producto Is Nothing Then
                                If producto.Producto.FACTURAR_PRECIO >= 1 And producto.Producto.FACTURAR_PRECIO <= 4 Then
                                    With producto.Producto
                                        If .MARGEN Then
                                            Select Case .FACTURAR_PRECIO
                                                Case 1
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO1 / 100), (.COSTO + (.COSTO * .PRECIO1 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO1 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO1 / 100)).ToString(Config.f_m)
                                                    End If
                                                Case 2
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO2 / 100), (.COSTO + (.COSTO * .PRECIO2 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO2 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO2 / 100)).ToString(Config.f_m)
                                                    End If
                                                Case 3
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO3 / 100), (.COSTO + (.COSTO * .PRECIO3 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO3 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO3 / 100)).ToString(Config.f_m)
                                                    End If
                                                Case 4
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO4 / 100), (.COSTO + (.COSTO * .PRECIO4 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO4 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO4 / 100)).ToString(Config.f_m)
                                                    End If
                                            End Select
                                        Else
                                            Select Case .FACTURAR_PRECIO
                                                Case 1
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO1, .PRECIO1 / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO1 * txtTazaCambio.Value, .PRECIO1).ToString(Config.f_m)
                                                    End If
                                                Case 2
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO2, .PRECIO2 / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO2 * txtTazaCambio.Value, .PRECIO2).ToString(Config.f_m)
                                                    End If
                                                Case 3
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO3, .PRECIO3 / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO3 * txtTazaCambio.Value, .PRECIO3).ToString(Config.f_m)
                                                    End If
                                                Case 4
                                                    If .CMONEDA.Equals(Config.cordoba) Then
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO4, .PRECIO4 / txtTazaCambio.Value).ToString(Config.f_m)
                                                    Else
                                                        txtPrecio.Text = If(rdCordoba.Checked, .PRECIO4 * txtTazaCambio.Value, .PRECIO4).ToString(Config.f_m)
                                                    End If
                                            End Select
                                        End If
                                    End With
                                End If
                                txtCantidad.Focus()
                            Else
                                frmBuscarProductos.frm_return = 3 'retornar el valor aqui
                                frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                                frmBuscarProductos.ShowDialog()
                            End If
                        End Using
                    Else
                        frmBuscarProductos.frm_return = 11 'retornar el valor aqui
                        frmBuscarProductos.ShowDialog()
                    End If
                Else
                    MessageBox.Show("Error, Seleccione la serie")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Try
                        Using db As New CodeFirst
                            Dim producto = ExistenciaController.BuscarProductoPorCodigo(txtCodigoAlterno.Text.Trim, Config.warehouseId)
                            If Not producto Is Nothing Then
                                If txtPrecio.Text.Trim = "" Then
                                    If producto.Producto.FACTURAR_PRECIO >= 1 And producto.Producto.FACTURAR_PRECIO <= 4 Then
                                        With producto.Producto
                                            If .MARGEN Then
                                                Select Case .FACTURAR_PRECIO
                                                    Case 1
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO1 / 100), (.COSTO + (.COSTO * .PRECIO1 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO1 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO1 / 100)).ToString(Config.f_m)
                                                        End If
                                                    Case 2
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO2 / 100), (.COSTO + (.COSTO * .PRECIO2 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO2 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO2 / 100)).ToString(Config.f_m)
                                                        End If
                                                    Case 3
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO3 / 100), (.COSTO + (.COSTO * .PRECIO3 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO3 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO3 / 100)).ToString(Config.f_m)
                                                        End If
                                                    Case 4
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .COSTO + (.COSTO * .PRECIO4 / 100), (.COSTO + (.COSTO * .PRECIO4 / 100)) / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, (.COSTO + (.COSTO * .PRECIO4 / 100)) * txtTazaCambio.Value, .COSTO + (.COSTO * .PRECIO4 / 100)).ToString(Config.f_m)
                                                        End If
                                                End Select
                                            Else
                                                Select Case .FACTURAR_PRECIO
                                                    Case 1
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO1, .PRECIO1 / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO1 * txtTazaCambio.Value, .PRECIO1).ToString(Config.f_m)
                                                        End If
                                                    Case 2
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO2, .PRECIO2 / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO2 * txtTazaCambio.Value, .PRECIO2).ToString(Config.f_m)
                                                        End If
                                                    Case 3
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO3, .PRECIO3 / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO3 * txtTazaCambio.Value, .PRECIO3).ToString(Config.f_m)
                                                        End If
                                                    Case 4
                                                        If .CMONEDA.Equals(Config.cordoba) Then
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO4, .PRECIO4 / txtTazaCambio.Value).ToString(Config.f_m)
                                                        Else
                                                            txtPrecio.Text = If(rdCordoba.Checked, .PRECIO4 * txtTazaCambio.Value, .PRECIO4).ToString(Config.f_m)
                                                        End If
                                                End Select
                                            End If
                                        End With
                                    Else
                                        frmBuscarPrecio.taza = txtTazaCambio.Value
                                        frmBuscarPrecio.frm_return = 3
                                        frmBuscarPrecio.idproducto = producto.IDPRODUCTO
                                        frmBuscarPrecio.ShowDialog()
                                        frmBuscarPrecio.Dispose()
                                    End If
                                ElseIf Not txtCantidad.Text.Trim = "" And Not txtPrecio.Text.Trim = "" Then
                                    Dim precioN As Decimal = txtPrecio.Value
                                    Dim iva As Decimal
                                    If chkExonerado.Checked = False Then
                                        iva = Config.iva
                                    Else
                                        iva = (txtIva.Value / 100)
                                    End If
                                    If producto.Producto.IVA = False Then
                                        iva = 0
                                    End If
                                    'agregar detalle
                                    If rdCredito.Checked Then
                                        Dim Fact = db.Ventas.Where(Function(f) f.IDVENTA = txtIdFactura.Text And f.ANULADO.Equals(Config.vFalse)).FirstOrDefault
                                        If Not Fact Is Nothing Then
                                            If Fact.VentasDetalles.Where(Function(f) f.Existencia.Producto.IDALTERNO = txtCodigoAlterno.Text).FirstOrDefault Is Nothing Then
                                                Config.MsgErr("Ningún Producto con ID Alerno: '" & txtCodigoAlterno.Text & "' pertenece a esta Venta (" & Fact.Serie.NOMBRE & " - " & Fact.CONSECUTIVO & ").")
                                                txtCodigoAlterno.Focus()
                                                Exit Sub
                                            End If
                                        Else
                                            Config.MsgErr("No se encuentra esta Venta. Probablemente ha sido anulada.")
                                            txtFactura.Focus()
                                            Exit Sub
                                        End If
                                    End If
                                    Dim detalle = detalles.Where(Function(f) f.IDALTERNO = producto.Producto.IDALTERNO).FirstOrDefault()
                                    Dim nuevo As Boolean = False
                                    If detalle Is Nothing Then
                                        detalle = New LST_DETALLE_DEVOLUCION_VENTA : nuevo = True
                                    End If
                                    With detalle
                                        .IDEXISTENCIA = producto.IDEXISTENCIA
                                        .IDALTERNO = producto.Producto.IDALTERNO
                                        .DESCRIPCION = producto.Producto.DESCRIPCION
                                        .IVA = producto.Producto.IVA
                                        .MARCA = producto.Producto.Marca.DESCRIPCION
                                        .UNIDAD_DE_MEDIDA = producto.Producto.UnidadMedida.DESCRIPCION
                                        .PRESENTACION = producto.Producto.Presentacion.DESCRIPCION
                                        .EXISTENCIA = producto.CANTIDAD
                                        .CANTIDAD = Decimal.Parse(txtCantidad.Value.ToString())
                                        If rdCordoba.Checked Then
                                            .PRECIOUNITARIO_C = precioN
                                            .PRECIOUNITARIO_D = precioN / txtTazaCambio.Value '().ToString(SESION.formato_moneda)
                                        Else
                                            .PRECIOUNITARIO_C = precioN * txtTazaCambio.Value '().ToString(SESION.formato_moneda)
                                            .PRECIOUNITARIO_D = precioN
                                        End If
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''
                                        If rdSindescuento.Checked Then
                                            .DESCUENTO_POR = 0
                                            .DESCUENTO_DIN_C = 0 : .DESCUENTO_DIN_D = 0
                                            .DESCUENTO_DIN_TOTAL_C = 0 : .DESCUENTO_DIN_TOTAL_D = 0
                                            .PRECIONETO_C = .PRECIOUNITARIO_C : .PRECIONETO_D = .PRECIOUNITARIO_D
                                        ElseIf rdDescuentoPorProducto.Checked Then
                                            If txtDescuentoPorProducto.Value > 0 Then
                                                .DESCUENTO_POR = txtDescuentoPorProducto.Value.ToString(Config.f_m)
                                                .DESCUENTO_DIN_C = (.PRECIOUNITARIO_C * .DESCUENTO_POR / 100).ToString(Config.f_m) : .DESCUENTO_DIN_D = (.PRECIOUNITARIO_D * .DESCUENTO_POR / 100).ToString(Config.f_m)
                                                .DESCUENTO_DIN_TOTAL_C = (.DESCUENTO_DIN_C * .CANTIDAD).ToString(Config.f_m) : .DESCUENTO_DIN_TOTAL_D = (.DESCUENTO_DIN_D * .CANTIDAD).ToString(Config.f_m)
                                                txtDescuentoPorProducto.Text = Nothing
                                            Else
                                                .DESCUENTO_POR = 0
                                                .DESCUENTO_DIN_C = 0 : .DESCUENTO_DIN_D = 0
                                                .DESCUENTO_DIN_TOTAL_C = 0 : .DESCUENTO_DIN_D = 0
                                            End If
                                            .PRECIONETO_C = .PRECIOUNITARIO_C - .DESCUENTO_DIN_C : .PRECIONETO_D = .PRECIOUNITARIO_D - .DESCUENTO_DIN_D
                                        ElseIf rdDescuentoPorFactura.Checked Then
                                            .DESCUENTO_POR = lblDescuentoPorFactura.Text
                                            .DESCUENTO_DIN_C = (.PRECIOUNITARIO_C * .DESCUENTO_POR / 100).ToString(Config.f_m) : .DESCUENTO_DIN_D = (.PRECIOUNITARIO_D * .DESCUENTO_POR / 100).ToString(Config.f_m)
                                            .DESCUENTO_DIN_TOTAL_C = (.DESCUENTO_DIN_C * .CANTIDAD).ToString(Config.f_m) : .DESCUENTO_DIN_TOTAL_D = (.DESCUENTO_DIN_D * .CANTIDAD).ToString(Config.f_m)
                                            .PRECIONETO_C = .PRECIOUNITARIO_C - .DESCUENTO_DIN_C : .PRECIONETO_D = .PRECIOUNITARIO_D - .DESCUENTO_DIN_D
                                        End If
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''
                                        'actualizo
                                        .SUBTOTAL_C = .PRECIONETO_C * .CANTIDAD
                                        .IVA_POR = iva * 100
                                        .IVA_DIN_C = detalle.PRECIONETO_C * iva
                                        .IVA_DIN_TOTAL_C = detalle.IVA_DIN_C * detalle.CANTIDAD
                                        .TOTAL_C = .SUBTOTAL_C + .IVA_DIN_TOTAL_C
                                        'totalizar
                                        If bandDescFact Then
                                            txtTotalSubtotal.Value = txtTotalSubtotal.Value + .SUBTOTAL_C
                                            txtTotalDescuento.Value = txtTotalDescuento.Value + .DESCUENTO_DIN_TOTAL_C
                                            txtTotalIva.Value = txtTotalIva.Value + .IVA_DIN_TOTAL_C
                                            txtTotal.Value = txtTotal.Value + .TOTAL_C
                                        Else
                                            txtTotalSubtotal.Value = txtTotalSubtotal.Value + .SUBTOTAL_C
                                            If rdDescuentoPorProducto.Checked Then
                                                txtTotalDescuento.Value = txtTotalDescuento.Value + .DESCUENTO_DIN_TOTAL_C
                                            End If
                                            txtTotalIva.Value = txtTotalIva.Value + .IVA_DIN_TOTAL_C
                                            txtTotal.Value = txtTotal.Value + .TOTAL_C
                                        End If
                                        .SUBTOTAL_C = (.PRECIONETO_C * .CANTIDAD) : .SUBTOTAL_D = (.PRECIONETO_D * .CANTIDAD)
                                        .IVA_POR = iva * 100
                                        .IVA_DIN_C = .PRECIONETO_C * iva : .IVA_DIN_D = .PRECIONETO_D * iva
                                        .IVA_DIN_TOTAL_C = .SUBTOTAL_C * iva : .IVA_DIN_TOTAL_D = .SUBTOTAL_D * iva
                                        .TOTAL_C = (.SUBTOTAL_C + .IVA_DIN_TOTAL_C) : .TOTAL_D = (.SUBTOTAL_D + .IVA_DIN_TOTAL_D)
                                    End With
                                    If nuevo Then
                                        detalles.Add(detalle)
                                    End If
                                    Grid()
                                    txtCodigoAlterno.Clear()
                                    txtCantidad.Value = 1
                                    txtPrecio.Text = Nothing
                                    txtCodigoAlterno.Focus()
                                    lblContador.Text = "N° ITEM: " & dtRegistro.Rows.Count
                                End If
                            Else
                                MessageBox.Show("Error, no se encuentra ningun producto con este codigo alterno.")
                                txtCodigoAlterno.Focus()
                            End If
                            producto = Nothing
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error, " & ex.Message)
                    End Try
                Else
                    txtCodigoAlterno.Focus()
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub btCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCliente.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarClientes.frm_return = 10 'retornar el valor aqui
            frmBuscarClientes.ShowDialog()
        Else
            MessageBox.Show("Error, Seleccione la serie")
        End If
    End Sub

    Private Sub btVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVendedor.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarEmpleado.frm_return = 3
            frmBuscarEmpleado.ShowDialog()
        Else
            MessageBox.Show("Error, Seleccione la serie")
        End If
    End Sub

    Private Sub btProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProducto.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarProductos.frm_return = 11 'retornar el valor aqui
            frmBuscarProductos.ShowDialog()
            txtCodigoAlterno.Focus()
        Else
            MessageBox.Show("Error, Seleccione la serie")
        End If
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        If Config.ValidateLapse(dtpFecha.Value) Then
            Try
                If txtIdSerie.Text <> "" And Not txtIdVendedor.Text.Trim() = "" And txtObservacion.Text.Trim <> "" And dtRegistro.Rows.Count > 0 Then
                    Using db As New CodeFirst
                        txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                        If Not txtCodigo.Text.Trim() = "" Then
                            dtpFecha.Value = If(dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString(), DateTime.Now, DateTime.Parse(dtpFecha.Value.ToShortDateString() & " " & DateTime.Now.ToString("HH:mm:ss")))
                            Dim v As New VentaDevolucion
                            v.Reg = DateTime.Now

                            Dim Fact As Venta = Nothing

                            If rdContado.Checked Then
                                If Not txtIdCliente.Text.Trim() = "" Then
                                    v.IDDEVOLUCION = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.FECHADEVOLUCION = dtpFecha.Value : v.EXONERADO = chkExonerado.Checked : v.CLIENTECONTADO = "" : v.CREDITO = False : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.IDCLIENTE = txtIdCliente.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                    db.VentasDevoluciones.Add(v)
                                Else
                                    v.IDDEVOLUCION = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.FECHADEVOLUCION = dtpFecha.Value : v.EXONERADO = chkExonerado.Checked : v.CLIENTECONTADO = txtNombreCliente.Text : v.CREDITO = False : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                    db.VentasDevoluciones.Add(v)
                                End If
                            Else
                                If txtIdCliente.Text.Trim <> "" Then
                                    Dim c = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text And f.ACTIVO.Equals(Config.vTrue)).FirstOrDefault()
                                    If Not c Is Nothing Then
                                        Fact = db.Ventas.Where(Function(f) f.IDVENTA = txtIdFactura.Text).FirstOrDefault
                                        If Not Fact Is Nothing Then
                                            If Fact.SALDOCREDITO >= If(Fact.MONEDA.Equals(cordoba), If(rdCordoba.Checked, txtTotal.Value, txtTotal.Value * txtTazaCambio.Value), If(rdCordoba.Checked, txtTotal.Value / txtTazaCambio.Value, txtTotal.Value)) Then

                                                v.IDDEVOLUCION = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.FECHADEVOLUCION = dtpFecha.Value : v.EXONERADO = chkExonerado.Checked : v.CLIENTECONTADO = "" : v.CREDITO = True : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.IDCLIENTE = txtIdCliente.Text : v.IDVENTA = Fact.IDVENTA : v.REIMPRESION = "N" : v.ANULADO = "N"
                                                If rdCordoba.Checked Then
                                                    Fact.SALDOCREDITO = Fact.SALDOCREDITO - If(Fact.MONEDA.Equals(Config.cordoba), v.TOTAL_C, v.TOTAL_D)
                                                    c.FACTURADO_C = c.FACTURADO_C - v.TOTAL_C
                                                Else
                                                    Fact.SALDOCREDITO = Fact.SALDOCREDITO - If(Fact.MONEDA.Equals(Config.cordoba), v.TOTAL_C, v.TOTAL_D)
                                                    c.FACTURADO_D = c.FACTURADO_D - v.TOTAL_D
                                                End If
                                                db.Entry(Fact).State = EntityState.Modified
                                                db.Entry(c).State = EntityState.Modified

                                                Dim est As New VentaEstadoCuenta
                                                est.IDESTADO = Guid.NewGuid.ToString()
                                                est.IDSERIE = v.IDSERIE
                                                est.N_DOCUMENTO = v.CONSECUTIVO
                                                est.OPERACION = "Devol"
                                                est.FECHA = v.FECHADEVOLUCION
                                                est.FORMADEPAGO = v.FORMADEPAGO
                                                est.N_PAGO = v.N_PAGO
                                                est.PLAZO = c.PLAZO
                                                est.FECHAVENCIMIENTO = v.FECHADEVOLUCION
                                                est.MONEDA = v.MONEDA
                                                est.TAZACAMBIO = v.TAZACAMBIO
                                                est.DEBE_C = 0.0
                                                est.DEBE_D = 0.0
                                                est.HABER_C = v.TOTAL_C
                                                est.HABER_D = v.TOTAL_D
                                                est.ACTIVO = "S"
                                                est.IDVENTA = Fact.IDVENTA
                                                est.IDDEVOLUCION = v.IDDEVOLUCION
                                                db.VentasEstadosCuentas.Add(est)
                                                est = Nothing
                                                db.VentasDevoluciones.Add(v)
                                            Else
                                                Config.MsgErr("El Saldo(" & Fact.SALDOCREDITO.ToString(Config.f_m) & ") de la venta '" & Fact.Serie.NOMBRE & " - " & Fact.CONSECUTIVO & "' es " _
                                                              & "menor que el total que intentas devolver.")
                                                Exit Sub
                                            End If
                                        Else
                                            Config.MsgErr("La venta que desea cargar una devolución no se encuentra. Probablemente ha sido eliminada o anulada.")
                                            Exit Sub
                                        End If
                                    Else
                                        Config.MsgErr("No se encuentra este cliente en la base de datos. Probablemente ha sido eliminado.")
                                        Exit Sub
                                    End If
                                Else
                                    Config.MsgErr("Para crear una Devolución de Crédito tiene que seleccionar un cliente que este registrado.")
                                    Exit Sub
                                End If
                            End If

                            Dim producto As Existencia : Dim cont As Integer = 0 : Dim d As VentaDevolucionDetalle
                            For Each item In detalles
                                producto = db.Existencias.Where(Function(f) f.IDEXISTENCIA = item.IDEXISTENCIA And f.Producto.ACTIVO = "S").FirstOrDefault()
                                If Not producto Is Nothing Then
                                    If Not Fact Is Nothing Then
                                        If Fact.VentasDetalles.Where(Function(f) f.Existencia.Producto.IDALTERNO = item.IDALTERNO).FirstOrDefault Is Nothing Then
                                            Config.MsgErr("Ningún Producto con ID Alerno: '" & item.IDALTERNO & "' pertenece a esta Venta (" & Fact.Serie.NOMBRE & " - " & Fact.CONSECUTIVO & ").")
                                            Exit Sub
                                        End If
                                    End If

                                    d = New VentaDevolucionDetalle
                                    d.IDDETALLEDEVOLUCION = Guid.NewGuid.ToString()
                                    d.CMONEDA = producto.Producto.CMONEDA
                                    d.COSTO = producto.Producto.COSTO
                                    d.EXISTENCIA_PRODUCTO = producto.CANTIDAD
                                    d.CANTIDAD = item.CANTIDAD
                                    d.PRECIOUNITARIO_D = item.PRECIOUNITARIO_D
                                    d.PRECIOUNITARIO_C = item.PRECIOUNITARIO_C
                                    d.DESCUENTO_POR = item.DESCUENTO_POR
                                    d.DESCUENTO_DIN_C = item.DESCUENTO_DIN_C
                                    d.DESCUENTO_DIN_D = item.DESCUENTO_DIN_D
                                    d.DESCUENTO_DIN_TOTAL_C = item.DESCUENTO_DIN_TOTAL_C
                                    d.DESCUENTO_DIN_TOTAL_D = item.DESCUENTO_DIN_TOTAL_D
                                    d.PRECIONETO_C = item.PRECIONETO_C
                                    d.PRECIONETO_D = item.PRECIONETO_D
                                    d.SUBTOTAL_C = item.SUBTOTAL_C
                                    d.SUBTOTAL_D = item.SUBTOTAL_D
                                    d.IVA_POR = item.IVA_POR
                                    d.IVA_DIN_C = item.IVA_DIN_C
                                    d.IVA_DIN_D = item.IVA_DIN_D
                                    d.IVA_DIN_TOTAL_C = item.IVA_DIN_TOTAL_C
                                    d.IVA_DIN_TOTAL_D = item.IVA_DIN_TOTAL_D
                                    d.TOTAL_C = item.TOTAL_C
                                    d.TOTAL_D = item.TOTAL_D
                                    d.IDEXISTENCIA = item.IDEXISTENCIA
                                    d.IDDEVOLUCION = v.IDDEVOLUCION
                                    db.VentasDevolucionesDetalles.Add(d)
                                    Dim k As New Kardex
                                    k.IDKARDEX = Guid.NewGuid.ToString()
                                    k.IDEXISTENCIA = producto.IDEXISTENCIA
                                    k.IDSERIE = txtIdSerie.Text
                                    k.N_DOCUMENTO = txtCodigo.Text
                                    k.FECHADOCUMENTO = dtpFecha.Value
                                    k.EXISTENCIA_ANTERIOR = producto.CANTIDAD
                                    producto.CANTIDAD = producto.CANTIDAD + item.CANTIDAD
                                    db.Entry(producto).State = EntityState.Modified
                                    k.OPERACION = "DEVOLUCION VENTA"
                                    k.EXISTENCIA_ALMACEN = producto.CANTIDAD
                                    k.DESCRIPCION = txtObservacion.Text
                                    k.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                    k.TAZACAMBIO = txtTazaCambio.Value
                                    k.ENTRADA = d.CANTIDAD
                                    k.SALIDA = 0
                                    k.CMONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                    k.COSTO = d.COSTO
                                    k.DEBER = (k.ENTRADA * k.COSTO)
                                    k.HABER = 0
                                    k.PRECIO_C = d.PRECIONETO_C
                                    k.PRECIO_D = d.PRECIONETO_D
                                    producto.Producto.CANTIDAD = producto.Producto.CANTIDAD + d.CANTIDAD
                                    producto.Producto.SALDO = producto.Producto.SALDO + (d.COSTO * d.CANTIDAD)
                                    k.COSTO_PROMEDIO = producto.Producto.COSTO
                                    If producto.Producto.CANTIDAD <> 0 Then
                                        'producto.PRODUCTO.COSTO = (producto.PRODUCTO.SALDO / producto.PRODUCTO.CANTIDAD)
                                        If producto.CANTIDAD = 0 Then
                                            k.SALDO = 0
                                        Else
                                            k.SALDO = k.EXISTENCIA_ALMACEN * k.COSTO_PROMEDIO
                                        End If
                                    Else
                                        producto.Producto.SALDO = 0
                                        k.SALDO = 0
                                    End If
                                    db.Entry(producto.Producto).State = EntityState.Modified
                                    k.COSTO_PROMEDIO = producto.Producto.COSTO
                                    k.SALDO = k.EXISTENCIA_ALMACEN * k.COSTO_PROMEDIO
                                    k.ACTIVO = "S"
                                    db.Kardexs.Add(k)
                                    'destruccion
                                    d = Nothing : k = Nothing
                                    cont = cont + 1 'incrementar contador
                                Else
                                    MessageBox.Show("Error, No se encuentra el producto '" & item.IDALTERNO & "'. Probablemente ha sido eliminado.")
                                    Exit Sub
                                End If
                            Next
                            If cont > 0 Then
                                db.SaveChanges()
                                Me.Id = v.IDDEVOLUCION
                                txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
                                btGuardar.Enabled = False : btAnular.Enabled = True : btImprimir.Enabled = True
                            Else
                                MessageBox.Show("Error, No se puede guardar 'Devolución' sin detalle.")
                            End If
                            cont = Nothing : producto = Nothing
                        Else
                            MessageBox.Show("Error, No se ha podido generar el nuevo código. Intente mas tarde, si el problema persiste contacte con el administrador.")
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Faltan datos.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btAgregarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarProducto.Click
        txtCodigoAlterno.Focus()
        frmProducto.MdiParent = frmPrincipal
        frmProducto.BringToFront()
        frmProducto.Show()
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Using db As New CodeFirst
                        Dim producto = db.Productos.Where(Function(f) f.IDALTERNO = txtCodigoAlterno.Text And f.ACTIVO = "S" And f.Marca.ACTIVO = "S").FirstOrDefault()
                        If Not producto Is Nothing Then
                            If txtPrecio.Text.Trim() = "" Then
                                frmBuscarPrecio.taza = txtTazaCambio.Value
                                frmBuscarPrecio.frm_return = 3
                                frmBuscarPrecio.idproducto = producto.IDPRODUCTO
                                frmBuscarPrecio.ShowDialog()
                            Else
                                txtCantidad.Focus()
                            End If
                        Else
                            MessageBox.Show("Error, no se encuentra ningun producto con este codigo alterno.")
                            txtCodigoAlterno.Focus()
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Seleccione un producto.")
                    txtCodigoAlterno.Focus()
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub rdSindescuento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSindescuento.CheckedChanged
        Try
            If rdSindescuento.Checked Then
                For Each det In detalles
                    If det.DESCUENTO_POR > 0 Then
                        det.DESCUENTO_POR = 0
                        det.DESCUENTO_DIN_C = 0 : det.DESCUENTO_DIN_D = 0
                        det.DESCUENTO_DIN_TOTAL_C = 0 : det.DESCUENTO_DIN_TOTAL_D = 0
                        det.PRECIONETO_C = det.PRECIOUNITARIO_C : det.PRECIONETO_D = det.PRECIOUNITARIO_D
                        det.SUBTOTAL_C = (det.CANTIDAD * det.PRECIONETO_C).ToString(Config.f_m) : det.SUBTOTAL_D = (det.CANTIDAD * det.PRECIONETO_D).ToString(Config.f_m)
                        det.IVA_DIN_C = (det.PRECIONETO_C * det.IVA_POR / 100).ToString(Config.f_m) : det.IVA_DIN_D = (det.PRECIONETO_D * det.IVA_POR / 100).ToString(Config.f_m)
                        det.IVA_DIN_TOTAL_C = (det.IVA_DIN_C * det.CANTIDAD).ToString(Config.f_m) : det.IVA_DIN_TOTAL_D = (det.IVA_DIN_D * det.CANTIDAD).ToString(Config.f_m)
                        det.TOTAL_C = det.SUBTOTAL_C + det.IVA_DIN_TOTAL_C : det.TOTAL_D = det.SUBTOTAL_D + det.IVA_DIN_TOTAL_D
                    End If
                Next
                Grid()

                If bandDescProd Then
                    'cambiar bande de descuento por factura
                    bandDescProd = False
                ElseIf bandDescFact Then
                    'cambiar bande de descuento por factura
                    bandDescFact = False
                End If
                txtDescuentoPorFactura.Enabled = False
                txtDescuentoPorProducto.Enabled = False
                txtDescuentoPorProducto.Value = 0.0
                txtDescuentoPorFactura.Value = 0.0
                txtTotalDescuento.Value = 0.0
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub rdDescuentoPorProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDescuentoPorProducto.Click, rdDescuentoPorProducto.CheckedChanged
        Try
            If rdDescuentoPorProducto.Checked Then
                For Each det In detalles
                    If det.DESCUENTO_POR > 0 Then
                        det.DESCUENTO_POR = 0
                        det.DESCUENTO_DIN_C = 0 : det.DESCUENTO_DIN_D = 0
                        det.DESCUENTO_DIN_TOTAL_C = 0 : det.DESCUENTO_DIN_TOTAL_D = 0
                        det.PRECIONETO_C = det.PRECIOUNITARIO_C : det.PRECIONETO_D = det.PRECIOUNITARIO_D
                        det.SUBTOTAL_C = (det.CANTIDAD * det.PRECIONETO_C).ToString(Config.f_m) : det.SUBTOTAL_D = (det.CANTIDAD * det.PRECIONETO_D).ToString(Config.f_m)
                        det.IVA_DIN_C = (det.PRECIONETO_C * det.IVA_POR / 100).ToString(Config.f_m) : det.IVA_DIN_D = (det.PRECIONETO_D * det.IVA_POR / 100).ToString(Config.f_m)
                        det.IVA_DIN_TOTAL_C = (det.IVA_DIN_C * det.CANTIDAD).ToString(Config.f_m) : det.IVA_DIN_TOTAL_D = (det.IVA_DIN_D * det.CANTIDAD).ToString(Config.f_m)
                        det.TOTAL_C = det.SUBTOTAL_C + det.IVA_DIN_TOTAL_C : det.TOTAL_D = det.SUBTOTAL_D + det.IVA_DIN_TOTAL_D
                    End If
                Next
                Grid()

                If bandDescProd Then
                    'cambiar bande de descuento por factura
                    bandDescProd = False
                ElseIf bandDescFact Then
                    'cambiar bande de descuento por factura
                    bandDescFact = False
                End If
                txtDescuentoPorFactura.Enabled = False
                txtDescuentoPorProducto.Enabled = True
                txtDescuentoPorProducto.Value = 0.0
                txtDescuentoPorFactura.Value = 0.0
                txtTotalDescuento.Value = 0.0
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub rdDescuentoPorFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDescuentoPorFactura.Click, rdDescuentoPorFactura.CheckedChanged
        Try
            If rdDescuentoPorFactura.Checked Then
                For Each det In detalles
                    If det.DESCUENTO_POR > 0 Then
                        det.DESCUENTO_POR = 0
                        det.DESCUENTO_DIN_C = 0 : det.DESCUENTO_DIN_D = 0
                        det.DESCUENTO_DIN_TOTAL_C = 0 : det.DESCUENTO_DIN_TOTAL_D = 0
                        det.PRECIONETO_C = det.PRECIOUNITARIO_C : det.PRECIONETO_D = det.PRECIOUNITARIO_D
                        det.SUBTOTAL_C = (det.CANTIDAD * det.PRECIONETO_C).ToString(Config.f_m) : det.SUBTOTAL_D = (det.CANTIDAD * det.PRECIONETO_D).ToString(Config.f_m)
                        det.IVA_DIN_C = (det.PRECIONETO_C * det.IVA_POR / 100).ToString(Config.f_m) : det.IVA_DIN_D = (det.PRECIONETO_D * det.IVA_POR / 100).ToString(Config.f_m)
                        det.IVA_DIN_TOTAL_C = (det.IVA_DIN_C * det.CANTIDAD).ToString(Config.f_m) : det.IVA_DIN_TOTAL_D = (det.IVA_DIN_D * det.CANTIDAD).ToString(Config.f_m)
                        det.TOTAL_C = det.SUBTOTAL_C + det.IVA_DIN_TOTAL_C : det.TOTAL_D = det.SUBTOTAL_D + det.IVA_DIN_TOTAL_D
                    End If
                Next
                Grid()

                If bandDescProd Then
                    'cambiar bande de descuento por factura
                    bandDescProd = False
                ElseIf bandDescFact Then
                    'cambiar bande de descuento por factura
                    bandDescFact = False
                End If
                txtDescuentoPorProducto.Enabled = False
                txtDescuentoPorProducto.Value = 0.0
                txtDescuentoPorFactura.Value = 0.0
                txtTotalDescuento.Value = 0.0
                txtDescuentoPorFactura.Enabled = True : txtDescuentoPorFactura.Focus()
            Else
                lblDescuentoPorFactura.Text = Decimal.Parse("0").ToString(Config.f_m)
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtDescuentoPorProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuentoPorProducto.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtDescuentoPorProducto.Text.Trim = "" Then
                    txtCantidad.Focus()
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub txtDescuentoPorFactura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuentoPorFactura.KeyPress
        Try
            If e.KeyChar = ChrW(13) Then
                If txtIdSerie.Text <> "" Then
                    If Not txtDescuentoPorFactura.Text.Trim = "" Then
                        If txtDescuentoPorFactura.Value > 0 Then
                            lblDescuentoPorFactura.Text = Decimal.Parse(txtDescuentoPorFactura.Value.ToString()).ToString(Config.f_m)
                            For Each det In detalles
                                det.DESCUENTO_POR = txtDescuentoPorFactura.Text
                                det.DESCUENTO_DIN_C = (det.PRECIOUNITARIO_C * det.DESCUENTO_POR / 100).ToString(Config.f_m) : det.DESCUENTO_DIN_D = (det.PRECIOUNITARIO_D * det.DESCUENTO_POR / 100).ToString(Config.f_m)
                                det.DESCUENTO_DIN_TOTAL_C = (det.DESCUENTO_DIN_C * det.CANTIDAD).ToString(Config.f_m) : det.DESCUENTO_DIN_TOTAL_D = (det.DESCUENTO_DIN_D * det.CANTIDAD).ToString(Config.f_m)
                                det.PRECIONETO_C = det.PRECIOUNITARIO_C - det.DESCUENTO_DIN_C : det.PRECIONETO_D = det.PRECIOUNITARIO_D - det.DESCUENTO_DIN_D
                                det.SUBTOTAL_C = (det.PRECIONETO_C * det.CANTIDAD).ToString(Config.f_m) : det.SUBTOTAL_D = (det.PRECIONETO_D * det.CANTIDAD).ToString(Config.f_m)
                                det.IVA_DIN_C = (det.PRECIONETO_C * det.IVA_POR / 100).ToString(Config.f_m) : det.IVA_DIN_D = (det.PRECIONETO_D * det.IVA_POR / 100).ToString(Config.f_m)
                                det.IVA_DIN_TOTAL_C = (det.IVA_DIN_C * det.CANTIDAD).ToString(Config.f_m) : det.IVA_DIN_TOTAL_D = (det.IVA_DIN_D * det.CANTIDAD).ToString(Config.f_m)
                                det.TOTAL_C = det.IVA_DIN_TOTAL_C + det.SUBTOTAL_C : det.TOTAL_D = det.IVA_DIN_TOTAL_D + det.SUBTOTAL_D
                            Next
                            Grid()
                            txtDescuentoPorFactura.Text = Nothing
                            txtCodigoAlterno.Focus()

                            ''''''''bandera para saber que esta activado descuento por factura
                            bandDescFact = True
                        Else
                            MessageBox.Show("Error, Debe ingresar un valor mayor que 0.")
                        End If
                    End If
                Else
                    MessageBox.Show("Error, Seleccione la serie")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMov(ByVal v As VentaDevolucion)
        Try
            Me.FormLoad = False
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            Me.Id = v.IDDEVOLUCION
            txtCodigo.Enabled = False
            dtpFecha.Text = v.FECHADEVOLUCION.ToShortDateString()
            txtIdVendedor.Text = v.Empleado.IDEMPLEADO
            txtNombreVendedor.Text = v.Empleado.N_TRABAJADOR & " " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS
            If Not v.IDCLIENTE Is Nothing Then
                txtIdCliente.Text = v.Cliente.IDCLIENTE

                If v.Cliente.TIPOPERSONA = "Natural" Or v.Cliente.RAZONSOCIAL.Trim() = "" Then

                    txtNombreCliente.Text = v.Cliente.N_CLIENTE & " " & v.Cliente.NOMBRES & " " & v.Cliente.APELLIDOS

                Else

                    txtNombreCliente.Text = v.Cliente.RAZONSOCIAL

                End If

            Else
                txtNombreCliente.Text = v.CLIENTECONTADO
            End If
            txtObservacion.Text = v.CONCEPTO
            Select Case v.TIPODESCUENTO
                Case "SINDESCUENTO"
                    rdSindescuento.Checked = True
                Case "POR PRODUCTO"
                    rdDescuentoPorProducto.Checked = True
                Case "POR FACTURA"
                    lblDescuentoPorFactura.Text = v.DESCUENTO_POR_FACT.ToString(Config.f_m)
                    rdDescuentoPorFactura.Checked = True
            End Select
            If v.EXONERADO Then
                chkExonerado.Checked = True
            Else
                chkExonerado.Checked = False
            End If
            detalles.RemoveAll(Function(f) True)
            If v.MONEDA = "C" Then
                rdCordoba.Checked = True
            Else
                rdDolar.Checked = True
            End If
            Dim item As LST_DETALLE_DEVOLUCION_VENTA
            For Each d In v.VentasDevolucionesDetalles
                item = New LST_DETALLE_DEVOLUCION_VENTA
                item.IDEXISTENCIA = d.Existencia.IDEXISTENCIA
                item.IDALTERNO = d.Existencia.Producto.IDALTERNO
                item.DESCRIPCION = d.Existencia.Producto.DESCRIPCION
                item.MARCA = If(d.Existencia.Producto.Marca.ACTIVO = "S", d.Existencia.Producto.Marca.DESCRIPCION, "")
                item.UNIDAD_DE_MEDIDA = If(d.Existencia.Producto.UnidadMedida.ACTIVO = "S", d.Existencia.Producto.UnidadMedida.DESCRIPCION, "")
                item.PRESENTACION = If(d.Existencia.Producto.Presentacion.ACTIVO = "S", d.Existencia.Producto.Presentacion.DESCRIPCION, "")
                item.EXISTENCIA = d.EXISTENCIA_PRODUCTO
                item.CANTIDAD = d.CANTIDAD
                item.PRECIOUNITARIO_C = d.PRECIOUNITARIO_C : item.PRECIOUNITARIO_D = d.PRECIOUNITARIO_D
                item.DESCUENTO_POR = d.DESCUENTO_POR
                item.DESCUENTO_DIN_C = d.DESCUENTO_DIN_C : item.DESCUENTO_DIN_D = d.DESCUENTO_DIN_D
                item.DESCUENTO_DIN_TOTAL_C = d.DESCUENTO_DIN_TOTAL_C : item.DESCUENTO_DIN_TOTAL_D = d.DESCUENTO_DIN_TOTAL_D
                item.IVA_POR = d.IVA_POR
                item.IVA_DIN_C = d.IVA_DIN_C : item.IVA_DIN_D = d.IVA_DIN_D
                item.IVA_DIN_TOTAL_C = d.IVA_DIN_TOTAL_C : item.IVA_DIN_TOTAL_D = d.IVA_DIN_TOTAL_D
                item.PRECIONETO_C = d.PRECIONETO_C : item.PRECIONETO_D = d.PRECIONETO_D
                item.SUBTOTAL_C = d.SUBTOTAL_C : item.SUBTOTAL_D = d.SUBTOTAL_D
                item.TOTAL_C = d.TOTAL_C : item.TOTAL_D = d.TOTAL_D
                detalles.Add(item) : item = Nothing
            Next
            Grid()
            lblContador.Text = "N° ITEM: " & dtRegistro.Rows.Count
            If Config._lapse.ACTUAL.Equals(Config.vTrue) And Config._lapse.APERTURA IsNot Nothing And Config._lapse.CIERRE Is Nothing Then
                btAnular.Enabled = True
            End If
            btImprimir.Enabled = True
            btGuardar.Enabled = False
            Me.FormLoad = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub LoadInfo(Optional ByVal vInt As VentaDevolucion = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            If txtIdSerie.Text <> "" Then
                If Not ByInt Then
                    Using db As New CodeFirst
                        Dim v = db.VentasDevoluciones.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                        If Not v Is Nothing Then
                            If v.ANULADO = "N" Then
                                Me.LoadMov(v)
                            Else
                                MessageBox.Show("Devolución anulada")
                            End If
                            v = Nothing
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

    Private Sub txtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            Me.LoadInfo()
        End If
    End Sub

    Private Sub btAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnular.Click
        Try

            'restricción, solo el admin puede anular documentos
            If Not Config.currentUser.Administrador Then 'se evalua si not tiene permiso de administrador

                'mensaje que no puede anular
                Config.MsgErr("Solo el administrador tiene permiso para anular un documento.")

                'si no tiene permiso debe salir
                Exit Sub

            End If
            'fin

            'Evaluar si desea realmente anular
            If MessageBox.Show("¿Desea anular esta devolución?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

                'Evaluar si hay una devolución seleccionada
                If Not Me.Id.Trim() = "" Then

                    Using db As New CodeFirst

                        'Seleccionando devolución
                        Dim v = db.VentasDevoluciones.Where(Function(f) f.IDDEVOLUCION = Me.Id And f.ANULADO = "N").FirstOrDefault()

                        'Evaluar si existe la devolución
                        If Not v Is Nothing Then

                            'Validando el período
                            If Config.ValidateLapse(v.FECHADEVOLUCION) Then

                                'Evaluar si la devolución es de al crédito
                                'Registrar la anulación de dinero
                                If v.CREDITO Then
                                    If v.CREDITO And Not v.IDCLIENTE Is Nothing Then
                                        If v.MONEDA.Equals(Config.cordoba) Then
                                            v.Cliente.FACTURADO_C = v.Cliente.FACTURADO_C + v.TOTAL_C
                                        Else
                                            v.Cliente.FACTURADO_D = v.Cliente.FACTURADO_D + v.TOTAL_D
                                        End If
                                        db.Entry(v.Cliente).State = EntityState.Modified
                                        If v.Venta.MONEDA.Equals(Config.cordoba) Then
                                            v.Venta.SALDOCREDITO = v.Venta.SALDOCREDITO + v.TOTAL_C
                                        Else
                                            v.Venta.SALDOCREDITO = v.Venta.SALDOCREDITO + v.TOTAL_D
                                        End If
                                        db.Entry(v.Venta).State = EntityState.Modified
                                    End If
                                End If

                                'Anular devolución
                                v.ANULADO = "S"
                                db.Entry(v).State = EntityState.Modified

                                'Anular movimientos en estado de cuenta
                                For Each estado In db.VentasEstadosCuentas.Where(Function(f) f.IDDEVOLUCION = v.IDDEVOLUCION)
                                    estado.ACTIVO = "N"
                                    db.Entry(estado).State = EntityState.Modified
                                Next

                                'Metiendo productos del inventario
                                For Each item In v.VentasDevolucionesDetalles

                                    item.Existencia.CANTIDAD = item.Existencia.CANTIDAD - item.CANTIDAD
                                    item.Existencia.Producto.CANTIDAD = item.Existencia.Producto.CANTIDAD - item.CANTIDAD

                                    If item.Existencia.CANTIDAD < 0 Then
                                        If Not item.Existencia.Producto.FACTURAR_NEGATIVO Then
                                            Config.MsgErr("No se puede anular esta Devolución. Ya que la existencia del producto '" & item.Existencia.Producto.IDALTERNO & " - " & item.Existencia.Producto.DESCRIPCION & "' quedaría en negativo.")
                                            Exit Sub
                                        End If
                                    End If

                                    If item.CMONEDA.Equals(item.Existencia.Producto.CMONEDA) Then
                                        item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.COSTO)
                                    Else
                                        If item.CMONEDA.Equals(Config.cordoba) Then
                                            item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.COSTO / v.TAZACAMBIO)
                                        Else
                                            item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.COSTO * v.TAZACAMBIO)
                                        End If
                                    End If

                                    If item.Existencia.Producto.CANTIDAD <> 0 Then
                                        If item.Existencia.Producto.COSTO <> item.COSTO Then
                                            item.Existencia.Producto.COSTO = item.Existencia.Producto.SALDO / item.Existencia.Producto.CANTIDAD
                                        End If
                                    Else
                                        item.Existencia.Producto.SALDO = 0
                                    End If

                                    db.Entry(item.Existencia.Producto).State = EntityState.Modified
                                    db.Entry(item.Existencia).State = EntityState.Modified
                                Next

                                'Anulando Kardex
                                Using db_a As New CodeFirst
                                    Dim band As Boolean = False
                                    For Each kardex In db.Kardexs.Where(Function(f) f.IDSERIE = v.IDSERIE And f.N_DOCUMENTO = txtCodigo.Text)
                                        For Each k In db_a.Kardexs.Where(Function(f) f.N > kardex.N And f.IDEXISTENCIA = kardex.IDEXISTENCIA)
                                            k.EXISTENCIA_ANTERIOR = k.EXISTENCIA_ANTERIOR - kardex.ENTRADA
                                            k.EXISTENCIA_ALMACEN = k.EXISTENCIA_ALMACEN - kardex.ENTRADA

                                            If k.EXISTENCIA_ALMACEN = 0 Then
                                                k.SALDO = 0
                                            Else
                                                If k.CMONEDA.Equals(kardex.CMONEDA) Then
                                                    k.SALDO = k.SALDO - kardex.DEBER
                                                Else
                                                    If kardex.CMONEDA.Equals(Config.cordoba) Then
                                                        k.SALDO = k.SALDO - (kardex.DEBER / kardex.TAZACAMBIO)
                                                    Else
                                                        k.SALDO = k.SALDO - (kardex.DEBER * kardex.TAZACAMBIO)
                                                    End If
                                                End If
                                            End If

                                            db_a.Entry(k).State = EntityState.Modified
                                            band = True
                                        Next
                                        kardex.ACTIVO = "N" : db.Entry(kardex).State = EntityState.Modified
                                    Next
                                    If band Then
                                        db_a.SaveChanges()
                                    End If
                                    db.SaveChanges() : MessageBox.Show("Devolución de Venta Anulada") : limpiar()
                                End Using
                            End If

                            'Se elimina el objeto
                            v = Nothing

                        Else
                            MessageBox.Show("Error, No se encuentra esta devolución o ya ha sido anulada.")
                        End If

                    End Using

                Else
                    MessageBox.Show("Error, Seleccione una devolución")
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmFacturacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
                txtCodigoAlterno.Focus()
            Case Keys.F2
                txtCantidad.Focus()
            Case Keys.F4
                txtPrecio.Focus()
            Case Keys.F5
                txtDescuentoPorProducto.Focus()
            Case Keys.F3
                If txtCodigo.Focused Then
                    frmBDevolucionVenta.ShowDialog()
                End If
        End Select
    End Sub

    Private Sub txtNCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If txtIdSerie.Text <> "" Then
                    Using db As New CodeFirst
                        If Not txtNCliente.Text.Trim() = "" Then
                            Dim cliente = db.Clientes.Where(Function(f) f.N_CLIENTE = txtNCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                            If Not cliente Is Nothing Then

                                txtIdCliente.Text = cliente.IDCLIENTE

                                txtNombreCliente.Text = If(cliente.TIPOPERSONA = "Natural" Or cliente.RAZONSOCIAL.Trim() = "", cliente.N_CLIENTE & " " & cliente.NOMBRES & " " & cliente.APELLIDOS, cliente.N_CLIENTE & " " & cliente.RAZONSOCIAL)

                                txtNCliente.Clear()

                                txtObservacion.Focus()

                            Else
                                If MessageBox.Show("Cliente no registrado. ¿Desea realizar devolución con este nombre?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    txtIdCliente.Clear()
                                    txtNombreCliente.Text = txtNCliente.Text
                                    txtNCliente.Clear()
                                    txtObservacion.Focus()
                                End If
                            End If
                            cliente = Nothing
                        Else
                            If txtNombreCliente.Text.Trim = "" Then
                                frmBuscarClientes.frm_return = 10 'retornar el valor aqui
                                frmBuscarClientes.ShowDialog()
                                If Not txtIdCliente.Text.Trim = "" Then
                                    txtObservacion.Focus()
                                End If
                            Else
                                txtObservacion.Focus()
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

    Private Sub txtNVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNVendedor.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If txtIdSerie.Text <> "" Then
                    Using db As New CodeFirst
                        If Not txtNVendedor.Text.Trim() = "" Then
                            Dim vendedor = db.Empleados.Where(Function(f) f.N_TRABAJADOR = txtNVendedor.Text).FirstOrDefault()
                            If Not vendedor Is Nothing Then
                                txtIdVendedor.Text = vendedor.IDEMPLEADO
                                txtNombreVendedor.Text = vendedor.N_TRABAJADOR & " | " & vendedor.NOMBRES & " " & vendedor.APELLIDOS
                                txtNVendedor.Clear()
                                txtNCliente.Focus()
                            Else
                                MessageBox.Show("Error, Debe ingresar el vendedor")
                            End If
                            vendedor = Nothing
                        Else
                            frmBuscarEmpleado.frm_return = 3
                            frmBuscarEmpleado.ShowDialog()
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

    Private Sub chkExonerar_CheckedChanged(sender As Object, e As EventArgs) Handles chkExonerado.CheckedChanged
        Try
            If chkExonerado.Checked Then
                For Each det In detalles
                    txtTotalIva.Value = txtTotalIva.Value - det.IVA_DIN_TOTAL_C
                    txtTotal.Value = txtTotal.Value - det.TOTAL_C

                    det.IVA_POR = 0
                    det.IVA_DIN_C = 0
                    det.IVA_DIN_TOTAL_C = 0
                    det.TOTAL_C = det.SUBTOTAL_C

                    txtTotalIva.Value = txtTotalIva.Value + det.IVA_DIN_TOTAL_C
                    txtTotal.Value = txtTotal.Value + det.TOTAL_C
                Next
            Else
                For Each det In detalles
                    txtTotalIva.Value = txtTotalIva.Value - det.IVA_DIN_TOTAL_C
                    txtTotal.Value = txtTotal.Value - det.TOTAL_C

                    If det.IVA Then
                        det.IVA_POR = Config.iva * 100
                        det.IVA_DIN_C = det.PRECIONETO_C * det.IVA_POR / 100
                        det.IVA_DIN_TOTAL_C = det.IVA_DIN_C * det.CANTIDAD
                    Else
                        det.IVA_POR = 0
                        det.IVA_DIN_C = 0
                        det.IVA_DIN_TOTAL_C = 0
                    End If
                    det.TOTAL_C = det.SUBTOTAL_C + det.IVA_DIN_TOTAL_C

                    txtTotalIva.Value = txtTotalIva.Value + det.IVA_DIN_TOTAL_C
                    txtTotal.Value = txtTotal.Value + det.TOTAL_C
                Next
            End If
            Grid()
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtIva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIva.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        frmSeleccionarSerie.operacion = "VENTA"
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


    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            If txtIdSerie.Text <> "" Then
                If Not txtObservacion.Text.Trim() = "" Then
                    txtCodigoAlterno.Focus()
                Else
                    MessageBox.Show("Error, Debe ingresar la observación")
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub frmNotaDevolucion_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ElGroupBox5.Left = Me.PanelEx3.Width - ElGroupBox5.Width - 7
    End Sub

#Region "Grid View"
    Sub Grid()
        If detalles.Count > 0 Then
            If rdCordoba.Checked Then
                txtTotalDescuento.Value = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C)
                txtTotalSubtotal.Value = detalles.Sum(Function(f) f.SUBTOTAL_C)
                txtTotalIva.Value = detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)
                txtTotal.Value = detalles.Sum(Function(f) f.TOTAL_C)
            Else
                txtTotalDescuento.Value = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D)
                txtTotalSubtotal.Value = detalles.Sum(Function(f) f.SUBTOTAL_D)
                txtTotalIva.Value = detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)
                txtTotal.Value = detalles.Sum(Function(f) f.TOTAL_D)
            End If
        Else
            txtTotalDescuento.Value = 0
            txtTotalSubtotal.Value = 0
            txtTotalIva.Value = 0
            txtTotal.Value = 0
        End If
        If rdCordoba.Checked Then
            dtRegistro.DataSource = (From det In detalles Select det.IDEXISTENCIA, det.IDALTERNO, det.DESCRIPCION, det.MARCA, det.UNIDAD_DE_MEDIDA, det.PRESENTACION, det.EXISTENCIA, det.CANTIDAD, det.PRECIOUNITARIO_C, det.DESCUENTO_POR, det.DESCUENTO_DIN_C, det.PRECIONETO_C, det.IVA_POR, det.IVA_DIN_C, det.DESCUENTO_DIN_TOTAL_C, det.SUBTOTAL_C, det.IVA_DIN_TOTAL_C, det.TOTAL_C).ToList()
        Else
            dtRegistro.DataSource = (From det In detalles Select det.IDEXISTENCIA, det.IDALTERNO, det.DESCRIPCION, det.MARCA, det.UNIDAD_DE_MEDIDA, det.PRESENTACION, det.EXISTENCIA, det.CANTIDAD, det.PRECIOUNITARIO_D, det.DESCUENTO_POR, det.DESCUENTO_DIN_D, det.PRECIONETO_D, det.IVA_POR, det.IVA_DIN_D, det.DESCUENTO_DIN_TOTAL_D, det.SUBTOTAL_D, det.IVA_DIN_TOTAL_D, det.TOTAL_D).ToList()
        End If
        If dtRegistro.Columns.Count > 0 Then
            dtRegistro.Columns(0).Visible = False
            dtRegistro.Columns(1).HeaderText = vbNewLine & "N° PRODUCTO" & vbNewLine : dtRegistro.Columns(1).Width = 120
            dtRegistro.Columns(2).HeaderText = "DESCRIPCIÓN DEL PRODUCTO" : dtRegistro.Columns(2).Width = 300
            dtRegistro.Columns(3).HeaderText = "MARCA" : dtRegistro.Columns(3).Width = 120 : dtRegistro.Columns(3).Visible = False
            dtRegistro.Columns(4).HeaderText = "U / M" : dtRegistro.Columns(4).Width = 120 : dtRegistro.Columns(4).Visible = False
            dtRegistro.Columns(5).HeaderText = "PRESENTACIÓN" : dtRegistro.Columns(5).Width = 120 : dtRegistro.Columns(5).Visible = False
            dtRegistro.Columns(6).HeaderText = "EXI." : dtRegistro.Columns(6).Width = 60 : dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(7).HeaderText = "CANT." : dtRegistro.Columns(7).Width = 60 : dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(8).HeaderText = "P./ U." : dtRegistro.Columns(8).Width = 60 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(9).HeaderText = "DESC. %" : dtRegistro.Columns(9).Width = 100 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(9).Visible = False
            dtRegistro.Columns(10).HeaderText = "DESC. UNI." : dtRegistro.Columns(10).Width = 100 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(10).Visible = False
            dtRegistro.Columns(11).HeaderText = "P./ N." : dtRegistro.Columns(11).Width = 60 : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(12).HeaderText = "IVA %" : dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(12).Visible = False
            dtRegistro.Columns(13).HeaderText = "IVA UNI." : dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(13).Visible = False
            dtRegistro.Columns(14).HeaderText = "DESC." : dtRegistro.Columns(14).Width = 75 : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m_r : dtRegistro.Columns(14).DefaultCellStyle.ForeColor = Color.Red : dtRegistro.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(15).HeaderText = "SUBTOTAL" : dtRegistro.Columns(15).Width = 75 : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(15).DefaultCellStyle.ForeColor = Color.Blue : dtRegistro.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(16).HeaderText = "IVA" : dtRegistro.Columns(16).Width = 75 : dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(16).DefaultCellStyle.ForeColor = Color.Brown : dtRegistro.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(16).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(17).HeaderText = "TOTAL" : dtRegistro.Columns(17).Width = 75 : dtRegistro.Columns(17).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(17).DefaultCellStyle.ForeColor = Color.Green : dtRegistro.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(17).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        For Each c As DataGridViewColumn In dtRegistro.Columns
            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
            c.HeaderText = c.HeaderText.ToUpper
            c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
        Next
    End Sub
#End Region

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            txtCodigoAlterno.Text = dtRegistro.SelectedRows(0).Cells(1).Value.ToString()
            txtCantidad.Text = dtRegistro.SelectedRows(0).Cells(7).Value.ToString()
            txtPrecio.Text = dtRegistro.SelectedRows(0).Cells(8).Value.ToString()
            If rdDescuentoPorProducto.Checked Then
                If Decimal.Parse(dtRegistro.SelectedRows(0).Cells(9).Value.ToString()) > 0 Then
                    txtDescuentoPorProducto.Text = dtRegistro.SelectedRows(0).Cells(9).Value.ToString()
                End If
            End If
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dtRegistro.SelectedRows.Count > 0 Then
                'descargar precios del total
                If bandDescFact Then
                    txtTotalSubtotal.Value = txtTotalSubtotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(14).Value.ToString())
                    txtTotalDescuento.Value = txtTotalDescuento.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(15).Value.ToString())
                    txtTotalIva.Text = txtTotalIva.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(16).Value.ToString())
                    txtTotal.Text = txtTotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(17).Value.ToString())
                Else
                    txtTotalSubtotal.Value = txtTotalSubtotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(14).Value.ToString())
                    If rdDescuentoPorProducto.Checked Then
                        txtTotalDescuento.Value = txtTotalDescuento.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(15).Value.ToString())
                    End If
                    txtTotalIva.Text = txtTotalIva.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(16).Value.ToString())
                    txtTotal.Text = txtTotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(17).Value.ToString())
                End If
                'quitar item
                detalles.Remove(detalles.Where(Function(f) f.IDEXISTENCIA = dtRegistro.SelectedRows(0).Cells(0).Value).FirstOrDefault())
                Grid()
                txtCodigoAlterno.Focus()
                'agregar al contador
                lblContador.Text = "N° ITEM: " & dtRegistro.Rows.Count
                txtCodigoAlterno.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress
        If e.KeyChar = ChrW(13) Then
            btActualizarSerie_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        Try
            Using db As New CodeFirst
                Dim v = db.VentasDevoluciones.Where(Function(f) f.IDDEVOLUCION = Me.Id).FirstOrDefault
                If Not v Is Nothing Then
                    If v.ANULADO = "N" Then
                        Dim t As TicketClass = New TicketClass
                        If t.ImpresoraExistente(Config.PrinterName) Then
                            t.EncabezadoPredefinido("DEVOLUCIÓN DEL CLIENTE", If(v.REIMPRESION.Equals("S"), "REIMPRESIÓN", "ORIGINAL"))
                            t.AnadirLineaSubcabeza(t.AlinearElementos("N° DEVOL.: " & v.CONSECUTIVO, v.Serie.NOMBRE))
                            t.AnadirLineaSubcabeza("FECHA:   " & v.FECHADEVOLUCION.ToShortDateString())
                            t.AnadirLineaSubcabeza("CÓDIGO:  " & If(v.Cliente IsNot Nothing, v.Cliente.N_CLIENTE, ""))
                            t.AnadirLineaSubcabeza("CLIENTE: " & If(v.Cliente IsNot Nothing, v.Cliente.NOMBRES & " " & v.Cliente.APELLIDOS, v.CLIENTECONTADO))
                            t.AnadirLineaSubcabeza("R. SOC.: " & If(v.Cliente IsNot Nothing, v.Cliente.RAZONSOCIAL, ""))
                            t.AnadirLineaSubcabeza("ATENDIÓ: " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS)
                            t.AnadirEspacio()
                            If v.EXONERADO Then
                                t.AnadirLineaSubcabeza("FACTURA EXONERADO")
                                t.AnadirEspacio()
                            End If
                            t.AnadirElemento(t.Linea5())
                            t.AnadirElemento("DESC.       P/U     CANT     TOTAL")
                            t.AnadirElemento(t.Linea5())
                            t.AnadirEspacio()
                            For Each i In From pro In db.Productos Join exi In db.Existencias On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.VentasDevolucionesDetalles On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Where det.IDDEVOLUCION = v.IDVENTA Select pro.IDALTERNO, pro.IDORIGINAL, PRODUCTO = pro.DESCRIPCION, MARCA = If(pro.Marca IsNot Nothing, pro.Marca.DESCRIPCION, Config.textNull), FORMA = If(pro.Presentacion IsNot Nothing, pro.Presentacion.DESCRIPCION, Config.textNull), det.CANTIDAD, PRECIO = If(v.MONEDA.Equals(Config.cordoba), det.PRECIOUNITARIO_C, det.PRECIOUNITARIO_D), SUBTOTAL = If(v.MONEDA.Equals(Config.cordoba), det.SUBTOTAL_C, det.SUBTOTAL_D)
                                t.AnadirElemento(i.PRODUCTO)
                                t.AnadirElementoTotales(i.PRECIO.ToString(Config.f_m), i.CANTIDAD.ToString(Config.f_m), i.SUBTOTAL.ToString(Config.f_m))
                                t.AnadirEspacio()
                            Next
                            t.AnadirEspacio()
                            t.AnadirElemento(t.Linea5())
                            t.AnadirTotal(" DESCUENTO " & If(v.MONEDA.Equals(Config.cordoba), "C$", " $"), If(v.MONEDA.Equals(Config.cordoba), v.DESCUENTO_DIN_C, v.DESCUENTO_DIN_D))
                            t.AnadirTotal("  SUBTOTAL " & If(v.MONEDA.Equals(Config.cordoba), "C$", " $"), If(v.MONEDA.Equals(Config.cordoba), v.SUBTOTAL_C, v.SUBTOTAL_D))
                            t.AnadirTotal("       IVA " & If(v.MONEDA.Equals(Config.cordoba), "C$", " $"), If(v.MONEDA.Equals(Config.cordoba), v.IVA_DIN_C, v.IVA_DIN_D))
                            t.AnadirTotal("     TOTAL " & If(v.MONEDA.Equals(Config.cordoba), "C$", " $"), If(v.MONEDA.Equals(Config.cordoba), v.TOTAL_C, v.TOTAL_D))
                            t.AnadirEspacio()
                            t.AnadeLineaAlPie(NumeroALetra.Letras(If(v.MONEDA.Equals(Config.cordoba), v.TOTAL_C.ToString(), v.TOTAL_D.ToString())))
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
                            t.ImprimeTicket(Config.PrinterName)

                            'reimpresión
                            v.REIMPRESION = "S"
                            db.Entry(v).State = EntityState.Modified
                            db.SaveChanges()

                        Else
                            MessageBox.Show("No se encuentra la impresora '" & Config.PrinterName & "'")
                        End If
                    Else
                        MessageBox.Show("Esta 'Devolución de Cliente' esta anulado")
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta 'Devolución de Cliente'. Problemente ha sido eliminada.")
                End If
                v = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub rdCordoba_CheckedChanged(sender As Object, e As EventArgs) Handles rdCordoba.CheckedChanged
        If FormLoad Then
            Grid()
        End If
    End Sub

    Private Sub rdDolar_CheckedChanged(sender As Object, e As EventArgs) Handles rdDolar.CheckedChanged
        If FormLoad Then
            Grid()
        End If
    End Sub

    Private Sub txtTazaCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTazaCambio.ValueChanged
        rdCordoba_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If Me.FormLoad Then
            If rdCredito.Checked Then
                If txtIdSerie.Text <> "" Then
                    If txtIdCliente.Text.Trim() <> "" Then
                        Using db As New CodeFirst
                            Dim c = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text And f.ACTIVO.Equals(Config.vTrue)).FirstOrDefault
                            If Not c Is Nothing Then
                                If c.PLAZO > 0 Then
                                    txtFactura.Focus()
                                    txtFactura.Enabled = True
                                    btBuscarFactura.Enabled = True
                                    txtFactura.Focus()
                                Else
                                    Config.MsgErr("Este cliente no tiene plazo para crédito.")
                                    rdContado.Checked = True
                                    Exit Sub
                                End If
                            Else
                                Config.MsgErr("No se encuentra este cliente.")
                            End If
                        End Using
                    Else
                        If rdCredito.Checked Then
                            Config.MsgErr("Seleccione el cliente.")
                            rdContado.Checked = True
                            frmBuscarClientes.frm_return = 10 'retornar el valor aqui
                            frmBuscarClientes.ShowDialog()
                            frmBuscarClientes.Dispose()
                        End If
                    End If
                Else
                    If rdCredito.Checked Then
                        Config.MsgErr("Seleccione la serie")
                        rdContado.Checked = True
                        txtSerie.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If Me.FormLoad Then
            If rdContado.Checked Then
                txtFactura.Clear()
                txtSaldo.Value = 0.0
                btBuscarFactura.Enabled = False
            End If
        End If
    End Sub

    Private Sub btBuscarFactura_Click(sender As Object, e As EventArgs) Handles btBuscarFactura.Click
        If txtIdSerie.Text <> "" Then
            If Not txtIdCliente.Text.Trim() = "" Then
                frmDocumentosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                frmDocumentosPendientes.IdCliente = txtIdCliente.Text
                frmDocumentosPendientes.Frm = 1
                frmDocumentosPendientes.Taza = txtTazaCambio.Value
                frmDocumentosPendientes.ShowDialog()
                If Not txtIdFactura.Text.Trim = "" Then
                    txtCodigoAlterno.Focus()
                Else
                    txtFactura.Focus()
                End If
            Else
                Config.MsgErr("Seleccione un cliente.")
            End If
        Else
            Config.MsgErr("Seleccione una serie.")
        End If
    End Sub

    Private Sub txtFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFactura.KeyDown
        If e.KeyData = Keys.Enter Then
            btBuscarFactura_Click(Nothing, Nothing)
        End If
    End Sub
End Class