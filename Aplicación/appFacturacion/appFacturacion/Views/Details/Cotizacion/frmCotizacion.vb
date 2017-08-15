Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmCotizacion

    Dim bandDescFact As Boolean = False
    Dim bandDescProd As Boolean = False

    'factura seleccionada
    Public Id As String = ""

    Public detalles As New List(Of LST_DETALLE_VENTA)

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
                txtNombreCliente.Text = "CLIENTES VARIOS"
                rdContado.Checked = True
                txtPlazo.Clear()
                txtFechaVencimiento.Clear()
                rdSindescuento.Checked = True
                chkIncluyeIVA.Checked = False
                chkExonerado.Checked = False
                'OBTENER TAZA DE CAMBIO
                'Using db As New MODELODEDATOS
                '    SESION._Taza = db.TAZAS.OrderByDescending(Function(f) f.FECHA).FirstOrDefault()
                '    If Not SESION._Taza Is Nothing Then
                '        SESION.tazadecambio = SESION._Taza.CAMBIO
                '    Else
                '        SESION.tazadecambio = 0
                '        MessageBox.Show("Error, No existe Taza de Cambio")
                '    End If
                'End Using
                'txtTazaCambio.Value = SESION.tazadecambio
                'FIN TAZA DE CAMBIO
                btGuardar.Enabled = True : btEditar.Enabled = False : btAnular.Enabled = False : btImprimir.Enabled = False
                txtCodigo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            txtCodigo.Focus()
        End Try
    End Sub

    Function generarCodigo(ByVal serie As String) As String
        Try
            Using db As New CodeFirst
                Dim cotizacion = (From cot In db.Cotizaciones Where cot.IDSERIE = serie Select cot.IDSERIE, cot.CONSECUTIVO).OrderBy(Function(f) f.CONSECUTIVO).ToList.LastOrDefault
                If Not cotizacion Is Nothing Then
                    cod = cotizacion.CONSECUTIVO
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
        Me.frmFacturacion_Resize(Nothing, Nothing)
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
            txtTotalSubtotal.Value = 0 : txtTotalDescuento.Value = 0 : txtTotalIva.Value = 0 : txtTotal.Value = 0
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
                            Dim producto = ExistenciaController.BuscarProductoPorCodigo(txtCodigoAlterno.Text.Trim(), Config.bodega)
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
                                frmBuscarProductos.frm_return = 5 'retornar el valor aqui
                                frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                                frmBuscarProductos.ShowDialog()
                            End If
                        End Using
                    Else
                        frmBuscarProductos.frm_return = 5 'retornar el valor aqui
                        frmBuscarProductos.ShowDialog()
                    End If
                Else
                    MessageBox.Show("Seleccione una serie.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If txtCodigoAlterno.Text.Trim() <> "" Then
                    Try
                        Using db As New CodeFirst
                            Dim producto = ExistenciaController.BuscarProductoPorCodigo(txtCodigoAlterno.Text.Trim, Config.bodega)
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
                                        frmBuscarPrecio.frm_return = 2
                                        frmBuscarPrecio.idproducto = producto.IDPRODUCTO
                                        frmBuscarPrecio.ShowDialog()
                                        frmBuscarPrecio.Dispose()
                                    End If
                                ElseIf Not txtCantidad.Text.Trim = "" And Not txtPrecio.Text.Trim = "" Then
                                    If producto.CANTIDAD < txtCantidad.Value Then
                                        If Not producto.Producto.FACTURAR_NEGATIVO Then
                                            MessageBox.Show("La cantidad solicitada es mayor a la existente. No se puede facturar este producto en negativo.")
                                            Exit Sub
                                        End If
                                    End If
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
                                    'validar costo
                                    Dim Costo As Decimal = If(rdCordoba.Checked, If(producto.Producto.CMONEDA.Equals(Config.cordoba), producto.Producto.COSTO, producto.Producto.COSTO * txtTazaCambio.Value), If(producto.Producto.CMONEDA.Equals(Config.cordoba), producto.Producto.COSTO / txtTazaCambio.Value, producto.Producto.COSTO))
                                    If Costo > precioN Then
                                        Config.MsgErr("Error, No se puede facturar producto por debajo del costo.")
                                        Exit Sub
                                    End If
                                    If rdDescuentoPorFactura.Checked Then
                                        If producto.Producto.Descuento < Decimal.Parse(lblDescuentoPorFactura.Text) Then
                                            Config.MsgErr("No se puede aplicar este descuento por que el máximo de descuento permitido para este producto es: " & producto.Producto.Descuento.ToString(Config.f_m))
                                            Exit Sub
                                        End If
                                    ElseIf rdDescuentoPorProducto.Checked Then
                                        If producto.Producto.Descuento < txtDescuentoPorProducto.Value Then
                                            Config.MsgErr("No se puede aplicar este descuento por que el máximo de descuento permitido para este producto es: " & producto.Producto.Descuento.ToString(Config.f_m))
                                            Exit Sub
                                        End If
                                    End If
                                    'fin validar costo
                                    Dim detalle = detalles.Where(Function(f) f.IDALTERNO = producto.Producto.IDALTERNO).FirstOrDefault() : Dim nuevo As Boolean = False
                                    If detalle Is Nothing Then
                                        detalle = New LST_DETALLE_VENTA : nuevo = True
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
                                        .CANTIDAD = txtCantidad.Value
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
                                        '.SUBTOTAL_C = (.PRECIONETO_C * .CANTIDAD).ToString(SESION.formato_moneda) : .SUBTOTAL_D = (.PRECIONETO_D * .CANTIDAD).ToString(SESION.formato_moneda)
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
                MessageBox.Show("Seleccione una serie.")
            End If
        End If
    End Sub

    Private Sub btCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCliente.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarClientes.frm_return = 2 'retornar el valor aqui
            frmBuscarClientes.ShowDialog()
            If Not txtIdCliente.Text.Trim() = "" Then
                txtCodigoAlterno.Focus()
            Else
                txtNCliente.Focus()
            End If
        Else
            MessageBox.Show("Seleccione una serie.")
        End If
    End Sub

    Private Sub btVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVendedor.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarEmpleado.frm_return = 2
            frmBuscarEmpleado.ShowDialog()
            If Not txtIdVendedor.Text.Trim() = "" Then
                txtNCliente.Focus()
            Else
                txtNVendedor.Focus()
            End If
        Else
            MessageBox.Show("Seleccione una serie.")
        End If
    End Sub

    Private Sub btProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProducto.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarProductos.frm_return = 5 'retornar el valor aqui
            frmBuscarProductos.ShowDialog()
            Me.txtCodigoAlterno.Focus()
        Else
            MessageBox.Show("Seleccione una serie.")
        End If
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If txtIdSerie.Text <> "" And Not txtIdVendedor.Text.Trim() = "" And Not dtRegistro.Rows.Count = 0 Then
                Using db As New CodeFirst
                    txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                    If Not txtCodigo.Text.Trim() = "" Then
                        dtpFecha.Value = If(dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString(), DateTime.Now, DateTime.Parse(dtpFecha.Value.ToShortDateString() & " " & DateTime.Now.ToString("HH:mm:ss")))
                        Dim cotizacion As New Cotizacion
                        cotizacion.Reg = DateTime.Now
                        If rdContado.Checked Then
                            If Not txtIdCliente.Text.Trim() = "" Then
                                cotizacion.IDCOTIZACION = Guid.NewGuid.ToString() : cotizacion.IDSERIE = txtIdSerie.Text : cotizacion.CONSECUTIVO = txtCodigo.Text : cotizacion.FECHACOTIZACION = dtpFecha.Value : cotizacion.FORMADEPAGO = "Sin Especificar" : cotizacion.N_PAGO = "" : cotizacion.EXONERADO = chkIncluyeIVA.Checked : cotizacion.CLIENTECONTADO = "" : cotizacion.CREDITO = False : cotizacion.FECHACREDITOVENCIMIENTO = dtpFecha.Value : cotizacion.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cotizacion.TAZACAMBIO = txtTazaCambio.Value : cotizacion.CONCEPTO = txtNombreCliente.Text : cotizacion.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : cotizacion.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : cotizacion.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : cotizacion.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : cotizacion.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : cotizacion.TIPODESCUENTO = If(cotizacion.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : cotizacion.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : cotizacion.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : cotizacion.IVA_POR = If(cotizacion.EXONERADO, 0, Config.iva) : cotizacion.IVA_DIN_C = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : cotizacion.IVA_DIN_D = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : cotizacion.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : cotizacion.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : cotizacion.IDEMPLEADO = txtIdVendedor.Text : cotizacion.IDCLIENTE = txtIdCliente.Text : cotizacion.ANULADO = "N"
                                db.Cotizaciones.Add(cotizacion)
                            Else
                                cotizacion.IDCOTIZACION = Guid.NewGuid.ToString() : cotizacion.IDSERIE = txtIdSerie.Text : cotizacion.CONSECUTIVO = txtCodigo.Text : cotizacion.FECHACOTIZACION = dtpFecha.Value : cotizacion.FORMADEPAGO = "Sin Especificar" : cotizacion.N_PAGO = "" : cotizacion.EXONERADO = chkIncluyeIVA.Checked : cotizacion.CLIENTECONTADO = txtNombreCliente.Text : cotizacion.CREDITO = False : cotizacion.FECHACREDITOVENCIMIENTO = dtpFecha.Value : cotizacion.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cotizacion.TAZACAMBIO = txtTazaCambio.Value : cotizacion.CONCEPTO = txtNombreCliente.Text : cotizacion.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : cotizacion.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : cotizacion.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : cotizacion.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : cotizacion.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : cotizacion.TIPODESCUENTO = If(cotizacion.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : cotizacion.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : cotizacion.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : cotizacion.IVA_POR = If(cotizacion.EXONERADO, 0, Config.iva) : cotizacion.IVA_DIN_C = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : cotizacion.IVA_DIN_D = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : cotizacion.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : cotizacion.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : cotizacion.IDEMPLEADO = txtIdVendedor.Text : cotizacion.ANULADO = "N"
                                db.Cotizaciones.Add(cotizacion)
                            End If
                        ElseIf rdCredito.Checked Then
                            Dim c = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text).FirstOrDefault()
                            If Not c Is Nothing Then
                                cotizacion.IDCOTIZACION = Guid.NewGuid.ToString() : cotizacion.IDSERIE = txtIdSerie.Text : cotizacion.CONSECUTIVO = txtCodigo.Text : cotizacion.FECHACOTIZACION = dtpFecha.Value : cotizacion.FORMADEPAGO = "Sin Especificar" : cotizacion.N_PAGO = "" : cotizacion.EXONERADO = chkIncluyeIVA.Checked : cotizacion.CLIENTECONTADO = "" : cotizacion.CREDITO = True : cotizacion.FECHACREDITOVENCIMIENTO = dtpFecha.Value.AddDays(c.PLAZO) : cotizacion.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cotizacion.TAZACAMBIO = txtTazaCambio.Value : cotizacion.CONCEPTO = txtNombreCliente.Text : cotizacion.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : cotizacion.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : cotizacion.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : cotizacion.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C) : cotizacion.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D) : cotizacion.TIPODESCUENTO = If(cotizacion.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : cotizacion.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : cotizacion.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : cotizacion.IVA_POR = If(cotizacion.EXONERADO, 0, Config.iva) : cotizacion.IVA_DIN_C = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : cotizacion.IVA_DIN_D = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : cotizacion.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : cotizacion.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : cotizacion.IDEMPLEADO = txtIdVendedor.Text : cotizacion.IDCLIENTE = txtIdCliente.Text : cotizacion.ANULADO = "N"
                                db.Cotizaciones.Add(cotizacion)
                            Else
                                MessageBox.Show("Error, No se encuentra este cliente en la base de datos. Probablemente ha sido eliminado.")
                                Exit Sub
                            End If
                            c = Nothing
                        End If
                        Dim producto As Existencia : Dim cont As Integer = 0 : Dim d As CotizacionDetalle
                        For Each item In detalles
                            producto = db.Existencias.Where(Function(f) f.IDEXISTENCIA = item.IDEXISTENCIA And f.Producto.ACTIVO = "S").FirstOrDefault()
                            If Not producto Is Nothing Then
                                If producto.CANTIDAD < item.CANTIDAD Then
                                    If Not producto.Producto.FACTURAR_NEGATIVO Then
                                        Config.MsgErr("No se puede guardar esta Venta. Ya que la existencia del producto '" & producto.Producto.IDALTERNO & " - " & producto.Producto.DESCRIPCION & "' quedaría en negativo.")
                                        Exit Sub
                                    End If
                                End If
                                'Validar Costo
                                If producto.Producto.COSTO > If(producto.Producto.CMONEDA.Equals(Config.cordoba), item.PRECIOUNITARIO_C, item.PRECIOUNITARIO_D) Then
                                    MessageBox.Show("El precio del producto '" & item.IDALTERNO & "' debe ser menor que el costo.")
                                    Exit Sub
                                End If
                                'Descuento costo
                                If rdDescuentoPorFactura.Checked Then
                                    If producto.Producto.Descuento < item.DESCUENTO_POR Then
                                        Config.MsgErr("No se puede aplicar este descuento por que el máximo de descuento permitido para el producto '" & producto.Producto.IDALTERNO & " - " & producto.Producto.DESCRIPCION & "' es: " & producto.Producto.Descuento.ToString(Config.f_m))
                                        Exit Sub
                                    End If
                                ElseIf rdDescuentoPorProducto.Checked Then
                                    If producto.Producto.Descuento < item.DESCUENTO_POR Then
                                        Config.MsgErr("No se puede aplicar este descuento por que el máximo de descuento permitido para el producto '" & producto.Producto.IDALTERNO & " - " & producto.Producto.DESCRIPCION & "' es: " & producto.Producto.Descuento.ToString(Config.f_m))
                                        Exit Sub
                                    End If
                                End If
                                'fin validar costo
                                d = New CotizacionDetalle : d.IDDETALLECOTIZACION = Guid.NewGuid.ToString() : d.CMONEDA = producto.Producto.CMONEDA : d.COSTO = producto.Producto.COSTO : d.EXISTENCIA_PRODUCTO = producto.CANTIDAD : d.CANTIDAD = item.CANTIDAD : d.PRECIOUNITARIO_D = item.PRECIOUNITARIO_D : d.PRECIOUNITARIO_C = item.PRECIOUNITARIO_C : d.DESCUENTO_POR = item.DESCUENTO_POR : d.DESCUENTO_DIN_C = item.DESCUENTO_DIN_C : d.DESCUENTO_DIN_D = item.DESCUENTO_DIN_D : d.DESCUENTO_DIN_TOTAL_C = item.DESCUENTO_DIN_TOTAL_C : d.DESCUENTO_DIN_TOTAL_D = item.DESCUENTO_DIN_TOTAL_D : d.PRECIONETO_C = item.PRECIONETO_C : d.PRECIONETO_D = item.PRECIONETO_D : d.SUBTOTAL_C = item.SUBTOTAL_C : d.SUBTOTAL_D = item.SUBTOTAL_D : d.IVA_POR = item.IVA_POR : d.IVA_DIN_C = item.IVA_DIN_C : d.IVA_DIN_D = item.IVA_DIN_D : d.IVA_DIN_TOTAL_C = item.IVA_DIN_TOTAL_C : d.IVA_DIN_TOTAL_D = item.IVA_DIN_TOTAL_D : d.TOTAL_C = item.TOTAL_C : d.TOTAL_D = item.TOTAL_D : d.IDEXISTENCIA = item.IDEXISTENCIA : d.IDCOTIZACION = cotizacion.IDCOTIZACION
                                db.CotizacionesDetalles.Add(d)
                                'destrucción
                                d = Nothing
                                cont = cont + 1 'incrementar contador
                            Else
                                MessageBox.Show("Error, No se encuentra el producto '" & item.IDALTERNO & "'. Probablemente ha sido eliminado.")
                                Exit Sub
                            End If
                        Next
                        If cont > 0 Then
                            db.SaveChanges()
                            Me.Id = cotizacion.IDCOTIZACION
                            txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
                            btGuardar.Enabled = False : btEditar.Enabled = True : btAnular.Enabled = True : btImprimir.Enabled = True
                        Else
                            MessageBox.Show("Error, No se puede guardar 'Cotización' sin detalle.")
                        End If
                        cont = Nothing : producto = Nothing : cotizacion = Nothing
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
    End Sub

    Private Sub btAgregarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarProducto.Click
        frmProducto.MdiParent = frmPrincipal
        frmProducto.Show()
        frmProducto.BringToFront()
        Me.txtCodigoAlterno.Focus()
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If txtIdSerie.Text <> "" Then
                Using db As New CodeFirst
                    Dim serie = db.SERIES.Where(Function(f) f.ACTIVO = "S" And f.IDSERIE = txtIdSerie.Text).FirstOrDefault()
                    If Not serie Is Nothing Then
                        txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                        txtReferencia.Text = serie.DESCRIPCION
                        txtCodigo.Focus()
                    End If
                    serie = Nothing
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
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
                                frmBuscarPrecio.frm_return = 2
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
                MessageBox.Show("Seleccione una serie.")
            End If
        End If
    End Sub

    Private Sub rdCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCredito.CheckedChanged
        If Me.FormLoad Then
            Try
                If rdCredito.Checked Then
                    If txtIdSerie.Text <> "" Then
                        If Not txtIdCliente.Text.Trim() = "" Then
                            Using db As New CodeFirst
                                Dim cliente = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                                If Not cliente Is Nothing Then
                                    If cliente.PLAZO > 0 Then
                                        txtPlazo.Text = cliente.PLAZO.ToString()
                                        txtFechaVencimiento.Text = DateTime.Parse(dtpFecha.Text).AddDays(cliente.PLAZO).ToString(Config.formato_fecha)
                                    Else
                                        MessageBox.Show("Error, Este cliente no tiene plazo para crédito.")
                                        rdContado.Checked = True
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Error, No se encuentra este cliente.")
                                End If
                                cliente = Nothing
                            End Using
                        Else
                            If rdCredito.Checked Then
                                MessageBox.Show("Error, Seleccione el cliente.")
                                rdContado.Checked = True
                                frmBuscarClientes.frm_return = 1 'retornar el valor aqui
                                frmBuscarClientes.ShowDialog()
                                frmBuscarClientes.Dispose()
                            End If
                        End If
                    Else
                        If rdCredito.Checked Then
                            MessageBox.Show("Seleccione una serie.")
                            rdContado.Checked = True
                            txtSerie.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rdCredito.Checked Then
            txtFechaVencimiento.Text = DateTime.Parse(dtpFecha.Text).AddDays(txtPlazo.Text).ToString(Config.formato_fecha)
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

    Private Sub rdDescuentoPorProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDescuentoPorProducto.CheckedChanged
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

    Private Sub rdDescuentoPorFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDescuentoPorFactura.CheckedChanged
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
                MessageBox.Show("Seleccione una serie.")
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
                    MessageBox.Show("Seleccione una serie.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMov(ByVal v As Cotizacion)
        Try
            Me.FormLoad = False
            Me.Id = v.IDCOTIZACION
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            txtCodigo.Enabled = False
            dtpFecha.Text = v.FECHACOTIZACION.ToShortDateString()
            txtIdVendedor.Text = v.Empleado.IDEMPLEADO
            txtNombreVendedor.Text = v.Empleado.N_TRABAJADOR & " | " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS
            If Not v.IDCLIENTE Is Nothing Then

                txtIdCliente.Text = v.Cliente.IDCLIENTE

                If v.Cliente.TIPOPERSONA = "Natural" Or v.Cliente.RAZONSOCIAL.Trim() = "" Then

                    txtNombreCliente.Text = v.Cliente.N_CLIENTE & " " & v.Cliente.NOMBRES & " " & v.Cliente.APELLIDOS

                Else

                    txtNombreCliente.Text = v.Cliente.RAZONSOCIAL

                End If

                If v.CREDITO Then
                    rdCredito.Checked = True
                    txtFechaVencimiento.Text = v.FECHACREDITOVENCIMIENTO.ToString()
                    txtPlazo.Text = v.Cliente.PLAZO.ToString()
                Else
                    rdContado.Checked = True
                End If
            Else
                txtNombreCliente.Text = v.CLIENTECONTADO
            End If
            Select Case v.TIPODESCUENTO
                Case "SINDESCUENTO"
                    rdSindescuento.Checked = True
                Case "POR PRODUCTO"
                    rdDescuentoPorProducto.Checked = True
                Case "POR FACTURA"
                    lblDescuentoPorFactura.Text = v.DESCUENTO_POR_FACT
                    rdDescuentoPorFactura.Checked = True
            End Select
            If v.EXONERADO Then
                chkIncluyeIVA.Checked = True
            Else
                chkIncluyeIVA.Checked = False
            End If
            detalles.RemoveAll(Function(f) True)
            If v.MONEDA = "C" Then
                rdCordoba.Checked = True
            Else
                rdDolar.Checked = True
            End If
            Dim item As LST_DETALLE_VENTA
            For Each d In v.CotizacionesDetalles
                item = New LST_DETALLE_VENTA
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
            btAnular.Enabled = True
            btEditar.Enabled = True
            btImprimir.Enabled = True
            btGuardar.Enabled = False
            Me.FormLoad = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub LoadInfo(Optional ByVal vInt As Cotizacion = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            If txtIdSerie.Text <> "" Then
                If Not ByInt Then
                    Using db As New CodeFirst
                        Dim v = db.Cotizaciones.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                        If Not v Is Nothing Then
                            If v.ANULADO = "N" Then
                                Me.LoadMov(v)
                            Else
                                MessageBox.Show("Cotización anulada")
                            End If
                        Else
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            txtNVendedor.Focus()
                        End If
                        v = Nothing
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
            If MessageBox.Show("¿Desea anular esta factura?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                If Not Me.Id.Trim() = "" Then
                    Using db As New CodeFirst
                        Dim v = db.Cotizaciones.Where(Function(f) f.IDCOTIZACION = Me.Id And f.ANULADO = "N").FirstOrDefault()
                        If Not v Is Nothing Then
                            v.ANULADO = "S" : db.Entry(v).State = EntityState.Modified
                            db.SaveChanges()
                            Config.MsgInfo("Cotización Anulada")
                            limpiar()
                            v = Nothing
                        Else
                            MessageBox.Show("Error, No se encuentra esta Cotización o ya ha sido anulada.")
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Seleccione una factura")
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
                Case Keys.E
                    If btEditar.Enabled Then
                        btEditar_Click(Nothing, Nothing)
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
                    frmBCotizacion.frm_return = 0
                    frmBCotizacion.ShowDialog()
                End If
            Case Keys.F12
                btEstadoCliente_Click(Nothing, Nothing)
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

                                txtNombreCliente.Text = If(cliente.TIPOPERSONA = "Natural" Or cliente.RAZONSOCIAL.Trim() = "", cliente.N_CLIENTE & " " & cliente.NOMBRES & " " & cliente.APELLIDOS, cliente.N_CLIENTE & " " & cliente.RAZONSOCIAL)
                                txtNCliente.Clear()
                                txtCodigoAlterno.Focus()
                            Else
                                If MessageBox.Show("Cliente no registrado. ¿Desea facturar con este nombre?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    txtIdCliente.Clear()
                                    txtNombreCliente.Text = txtNCliente.Text
                                    txtNCliente.Clear()
                                    txtCodigoAlterno.Focus()
                                End If
                            End If
                            cliente = Nothing
                            If rdCredito.Checked Then
                                rdContado.Checked = True
                            End If
                        Else
                            If txtNombreCliente.Text.Trim = "" Then
                                frmBuscarClientes.frm_return = 2 'retornar el valor aqui
                                frmBuscarClientes.ShowDialog()
                                If Not txtNombreCliente.Text.Trim = "" Then
                                    txtCodigoAlterno.Focus()
                                End If
                            Else
                                txtCodigoAlterno.Focus()
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
                            Dim vendedor = db.EMPLEADOS.Where(Function(f) f.N_TRABAJADOR = txtNVendedor.Text).FirstOrDefault()
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
                            If Not txtIdVendedor.Text.Trim = "" Then
                                txtNCliente.Focus()
                            Else
                                frmBuscarEmpleado.frm_return = 2
                                frmBuscarEmpleado.ShowDialog()
                                If Not txtIdVendedor.Text.Trim = "" Then
                                    txtNCliente.Focus()
                                End If
                            End If
                        End If
                    End Using
                Else
                    MessageBox.Show("Seleccione una serie.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub chkExonerado_CheckedChanged(sender As Object, e As EventArgs) Handles chkExonerado.CheckedChanged
        Try
            If chkExonerado.Checked Then
                For Each det In detalles
                    det.IVA_POR = 0
                    det.IVA_DIN_C = 0 : det.IVA_DIN_D = 0
                    det.IVA_DIN_TOTAL_C = 0 : det.IVA_DIN_TOTAL_D = 0
                    det.TOTAL_C = det.SUBTOTAL_C : det.TOTAL_D = det.SUBTOTAL_D
                Next
            Else
                For Each det In detalles
                    If det.IVA Then
                        det.IVA_POR = Config.iva * 100
                        det.IVA_DIN_C = det.PRECIONETO_C * det.IVA_POR / 100 : det.IVA_DIN_D = det.PRECIONETO_D * det.IVA_POR / 100
                        det.IVA_DIN_TOTAL_C = det.IVA_DIN_C * det.CANTIDAD : det.IVA_DIN_TOTAL_D = det.IVA_DIN_D * det.CANTIDAD
                    Else
                        det.IVA_POR = 0
                        det.IVA_DIN_C = 0 : det.IVA_DIN_D = 0
                        det.IVA_DIN_TOTAL_C = 0 : det.IVA_DIN_TOTAL_D = 0
                    End If
                    det.TOTAL_C = det.SUBTOTAL_C + det.IVA_DIN_TOTAL_C : det.TOTAL_D = det.SUBTOTAL_D + det.IVA_DIN_TOTAL_D
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
        frmSeleccionarSerie.operacion = "COTIZACION"
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

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        frmImprimirCotizacion.ID = Me.Id
        frmImprimirCotizacion.ShowDialog()
    End Sub

    Private Sub frmFacturacion_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ElGroupBox5.Left = Me.PanelEx3.Width - ElGroupBox5.Width - 7
    End Sub

#Region "Grid View"
    Public Sub Grid()
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
            dtRegistro.DataSource = (From det In detalles Select det.IDEXISTENCIA, det.IDALTERNO, det.DESCRIPCION, det.MARCA, det.UNIDAD_DE_MEDIDA, det.PRESENTACION, det.EXISTENCIA, det.CANTIDAD, det.PRECIOUNITARIO_C, det.DESCUENTO_POR, det.DESCUENTO_DIN_C, det.DESCUENTO_DIN_TOTAL_C, det.PRECIONETO_C, det.IVA_POR, det.IVA_DIN_C, det.SUBTOTAL_C, det.IVA_DIN_TOTAL_C, det.TOTAL_C).ToList()
        Else
            dtRegistro.DataSource = (From det In detalles Select det.IDEXISTENCIA, det.IDALTERNO, det.DESCRIPCION, det.MARCA, det.UNIDAD_DE_MEDIDA, det.PRESENTACION, det.EXISTENCIA, det.CANTIDAD, det.PRECIOUNITARIO_D, det.DESCUENTO_POR, det.DESCUENTO_DIN_D, det.DESCUENTO_DIN_TOTAL_D, det.PRECIONETO_D, det.IVA_POR, det.IVA_DIN_D, det.SUBTOTAL_D, det.IVA_DIN_TOTAL_D, det.TOTAL_D).ToList()
        End If
        If dtRegistro.Columns.Count > 0 Then
            dtRegistro.Columns(0).Visible = False
            dtRegistro.Columns(1).HeaderText = vbNewLine & "N° PRODUCTO" & vbNewLine : dtRegistro.Columns(1).Width = 120
            dtRegistro.Columns(2).HeaderText = "DESCRIPCIÓN DEL PRODUCTO" : dtRegistro.Columns(2).Width = 266
            dtRegistro.Columns(3).HeaderText = "MARCA" : dtRegistro.Columns(3).Width = 120 : dtRegistro.Columns(3).Visible = False
            dtRegistro.Columns(4).HeaderText = "U / M" : dtRegistro.Columns(4).Width = 120 : dtRegistro.Columns(4).Visible = False
            dtRegistro.Columns(5).HeaderText = "PRESENTACIÓN" : dtRegistro.Columns(5).Width = 120 : dtRegistro.Columns(5).Visible = False
            dtRegistro.Columns(6).HeaderText = "EXI." : dtRegistro.Columns(6).Width = 60 : dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(7).HeaderText = "CANT." : dtRegistro.Columns(7).Width = 60 : dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(8).HeaderText = "P./ U." : dtRegistro.Columns(8).Width = 60 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(9).HeaderText = "DESC. %" : dtRegistro.Columns(9).Width = 100 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(9).Visible = False
            dtRegistro.Columns(10).HeaderText = "DESC. UNI." : dtRegistro.Columns(10).Width = 100 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(10).Visible = False
            dtRegistro.Columns(12).HeaderText = "P./ N." : dtRegistro.Columns(12).Width = 60 : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
            dtRegistro.Columns(14).HeaderText = "IVA %" : dtRegistro.Columns(14).Width = 100 : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(14).Visible = False
            dtRegistro.Columns(13).HeaderText = "IVA UNI." : dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(13).Visible = False
            dtRegistro.Columns(11).HeaderText = "DESC." : dtRegistro.Columns(11).Width = 75 : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m_r : dtRegistro.Columns(11).DefaultCellStyle.ForeColor = Color.Red : dtRegistro.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(15).HeaderText = "SUBTOTAL" : dtRegistro.Columns(15).Width = 75 : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(15).DefaultCellStyle.ForeColor = Color.Blue : dtRegistro.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(16).HeaderText = "IVA" : dtRegistro.Columns(16).Width = 75 : dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(16).DefaultCellStyle.ForeColor = Color.Brown : dtRegistro.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(16).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dtRegistro.Columns(17).HeaderText = "TOTAL" : dtRegistro.Columns(17).Width = 75 : dtRegistro.Columns(17).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(17).DefaultCellStyle.ForeColor = Color.Green : dtRegistro.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : dtRegistro.Columns(17).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
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

    Private Sub rdCordoba_CheckedChanged(sender As Object, e As EventArgs) Handles rdCordoba.CheckedChanged
        If FormLoad Then
            If rdCordoba.Checked Then
                Grid()
            End If
        End If
    End Sub

    Private Sub rdDolar_CheckedChanged(sender As Object, e As EventArgs) Handles rdDolar.CheckedChanged
        If FormLoad Then
            If rdDolar.Checked Then
                Grid()
            End If
        End If
    End Sub

    Private Sub txtTazaCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTazaCambio.ValueChanged
        rdCordoba_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub btEstadoCliente_Click(sender As Object, e As EventArgs) Handles btEstadoCliente.Click
        If txtIdCliente.Text <> "" Then
            frmEstado.frm_return = 0
            frmEstado.id = txtIdCliente.Text
            frmEstado.ShowDialog()
        Else
            MessageBox.Show("Seleccionar un cliente que este registrado.")
        End If
    End Sub

    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        Try
            If txtIdSerie.Text <> "" And Not txtIdVendedor.Text.Trim() = "" And Not dtRegistro.Rows.Count = 0 Then
                Using db As New CodeFirst
                    dtpFecha.Value = If(dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString(), DateTime.Now, DateTime.Parse(dtpFecha.Value.ToShortDateString() & " " & DateTime.Now.ToString("HH:mm:ss")))
                    Dim cotizacion = db.Cotizaciones.Where(Function(f) f.IDCOTIZACION = Me.Id And f.ANULADO = "N").FirstOrDefault
                    If Not cotizacion Is Nothing Then
                        If rdContado.Checked Then
                            If Not txtIdCliente.Text.Trim() = "" Then
                                cotizacion.FECHACOTIZACION = dtpFecha.Value : cotizacion.FORMADEPAGO = "Sin Especificar" : cotizacion.N_PAGO = "" : cotizacion.EXONERADO = chkIncluyeIVA.Checked : cotizacion.CLIENTECONTADO = "" : cotizacion.CREDITO = False : cotizacion.FECHACREDITOVENCIMIENTO = dtpFecha.Value : cotizacion.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cotizacion.TAZACAMBIO = txtTazaCambio.Value : cotizacion.CONCEPTO = txtNombreCliente.Text : cotizacion.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : cotizacion.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : cotizacion.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : cotizacion.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : cotizacion.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : cotizacion.TIPODESCUENTO = If(cotizacion.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : cotizacion.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : cotizacion.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : cotizacion.IVA_POR = If(cotizacion.EXONERADO, 0, Config.iva) : cotizacion.IVA_DIN_C = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : cotizacion.IVA_DIN_D = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : cotizacion.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : cotizacion.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : cotizacion.IDEMPLEADO = txtIdVendedor.Text : cotizacion.IDCLIENTE = txtIdCliente.Text : cotizacion.ANULADO = "N"
                            Else
                                cotizacion.FECHACOTIZACION = dtpFecha.Value : cotizacion.FORMADEPAGO = "Sin Especificar" : cotizacion.N_PAGO = "" : cotizacion.EXONERADO = chkIncluyeIVA.Checked : cotizacion.CLIENTECONTADO = txtNombreCliente.Text : cotizacion.CREDITO = False : cotizacion.FECHACREDITOVENCIMIENTO = dtpFecha.Value : cotizacion.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cotizacion.TAZACAMBIO = txtTazaCambio.Value : cotizacion.CONCEPTO = txtNombreCliente.Text : cotizacion.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : cotizacion.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : cotizacion.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : cotizacion.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : cotizacion.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : cotizacion.TIPODESCUENTO = If(cotizacion.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : cotizacion.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : cotizacion.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : cotizacion.IVA_POR = If(cotizacion.EXONERADO, 0, Config.iva) : cotizacion.IVA_DIN_C = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : cotizacion.IVA_DIN_D = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : cotizacion.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : cotizacion.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : cotizacion.IDEMPLEADO = txtIdVendedor.Text : cotizacion.ANULADO = "N"
                            End If
                        ElseIf rdCredito.Checked Then
                            Dim c = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text).FirstOrDefault()
                            If Not c Is Nothing Then
                                cotizacion.FECHACOTIZACION = dtpFecha.Value : cotizacion.FORMADEPAGO = "Sin Especificar" : cotizacion.N_PAGO = "" : cotizacion.EXONERADO = chkIncluyeIVA.Checked : cotizacion.CLIENTECONTADO = "" : cotizacion.CREDITO = True : cotizacion.FECHACREDITOVENCIMIENTO = dtpFecha.Value.AddDays(c.PLAZO) : cotizacion.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cotizacion.TAZACAMBIO = txtTazaCambio.Value : cotizacion.CONCEPTO = txtNombreCliente.Text : cotizacion.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : cotizacion.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : cotizacion.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : cotizacion.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C) : cotizacion.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D) : cotizacion.TIPODESCUENTO = If(cotizacion.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : cotizacion.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : cotizacion.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : cotizacion.IVA_POR = If(cotizacion.EXONERADO, 0, Config.iva) : cotizacion.IVA_DIN_C = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : cotizacion.IVA_DIN_D = If(cotizacion.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : cotizacion.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : cotizacion.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : cotizacion.IDEMPLEADO = txtIdVendedor.Text : cotizacion.IDCLIENTE = txtIdCliente.Text : cotizacion.ANULADO = "N"
                            Else
                                MessageBox.Show("Error, No se encuentra este cliente en la base de datos. Probablemente ha sido eliminado.")
                                Exit Sub
                            End If
                            c = Nothing
                        End If
                        db.Entry(cotizacion).State = EntityState.Modified
                        For Each det In db.CotizacionesDetalles.Where(Function(f) f.IDCOTIZACION = cotizacion.IDCOTIZACION)
                            db.CotizacionesDetalles.Remove(det)
                        Next
                        Dim producto As Existencia : Dim cont As Integer = 0 : Dim detalle As CotizacionDetalle
                        For Each item In detalles
                            producto = db.Existencias.Where(Function(f) f.IDEXISTENCIA = item.IDEXISTENCIA And f.Producto.ACTIVO = "S").FirstOrDefault()
                            If Not producto Is Nothing Then
                                If producto.CANTIDAD < item.CANTIDAD Then
                                    If Not producto.Producto.FACTURAR_NEGATIVO Then
                                        Config.MsgErr("No se puede guardar esta Venta. Ya que la existencia del producto '" & producto.Producto.IDALTERNO & " - " & producto.Producto.DESCRIPCION & "' quedaría en negativo.")
                                        Exit Sub
                                    End If
                                End If
                                'validar costo
                                If producto.Producto.COSTO > item.PRECIONETO_D Then
                                    MessageBox.Show("El precio neto del producto '" & item.IDALTERNO & "' debe ser menor que el costo.")
                                    Exit Sub
                                End If
                                'fin validar costo
                                detalle = New CotizacionDetalle : detalle.IDDETALLECOTIZACION = Guid.NewGuid.ToString() : detalle.COSTO = producto.Producto.COSTO : detalle.EXISTENCIA_PRODUCTO = producto.CANTIDAD : detalle.CANTIDAD = item.CANTIDAD : detalle.PRECIOUNITARIO_D = item.PRECIOUNITARIO_D : detalle.PRECIOUNITARIO_C = item.PRECIOUNITARIO_C : detalle.DESCUENTO_POR = item.DESCUENTO_POR : detalle.DESCUENTO_DIN_C = item.DESCUENTO_DIN_C : detalle.DESCUENTO_DIN_D = item.DESCUENTO_DIN_D : detalle.DESCUENTO_DIN_TOTAL_C = item.DESCUENTO_DIN_TOTAL_C : detalle.DESCUENTO_DIN_TOTAL_D = item.DESCUENTO_DIN_TOTAL_D : detalle.PRECIONETO_C = item.PRECIONETO_C : detalle.PRECIONETO_D = item.PRECIONETO_D : detalle.SUBTOTAL_C = item.SUBTOTAL_C : detalle.SUBTOTAL_D = item.SUBTOTAL_D : detalle.IVA_POR = item.IVA_POR : detalle.IVA_DIN_C = item.IVA_DIN_C : detalle.IVA_DIN_D = item.IVA_DIN_D : detalle.IVA_DIN_TOTAL_C = item.IVA_DIN_TOTAL_C : detalle.IVA_DIN_TOTAL_D = detalle.IVA_DIN_TOTAL_D : detalle.TOTAL_C = item.TOTAL_C : detalle.TOTAL_D = item.TOTAL_D : detalle.IDEXISTENCIA = item.IDEXISTENCIA : detalle.IDCOTIZACION = cotizacion.IDCOTIZACION
                                db.CotizacionesDetalles.Add(detalle)
                                'destrucción
                                detalle = Nothing
                                cont = cont + 1 'incrementar contador
                            Else
                                MessageBox.Show("Error, No se encuentra el producto '" & item.IDALTERNO & "'. Probablemente ha sido eliminado.")
                                Exit Sub
                            End If
                        Next
                        If cont > 0 Then
                            db.SaveChanges()
                            MessageBox.Show("Cotización editada")
                        Else
                            MessageBox.Show("Error, No se puede guardar 'Cotización' sin detalle.")
                        End If
                        cont = Nothing : producto = Nothing
                    Else
                        MessageBox.Show("Error, No se encuentra esta cotización. Probablemente ha sido eliminada o anulada.")
                    End If
                End Using
            Else
                MessageBox.Show("Error, Faltan datos.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If Me.FormLoad Then
            If rdContado.Checked Then
                txtPlazo.Clear()
                txtFechaVencimiento.Clear()
                txtCodigoAlterno.Focus()
            End If
        End If
    End Sub
End Class