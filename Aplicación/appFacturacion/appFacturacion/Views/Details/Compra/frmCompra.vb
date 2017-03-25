Public Class frmCompra
    Dim bandDescFact As Boolean = False
    Dim bandDescProd As Boolean = False

    'factura seleccionada
    Public Id As String = ""

    Public detalles As New List(Of LST_DETALLE_COMPRA)

    Dim cod As String = ""

    Dim ExistenciaController As New Capadenegocio.Controller.ExistenciaController

    Dim FormLoad As Boolean = False

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
                txtNCompra.Clear()
                dtpFecha.Value = DateTime.Now
                dtpCaducidad.Value = DateTime.Now
                txtIdVendedor.Clear() : txtNVendedor.Clear() : txtNombreVendedor.Clear()
                txtIdProveedor.Clear() : txtNCliente.Clear() : txtNombreProveedor.Clear()
                txtObservacion.Clear()
                chkExonerado.Checked = False
                rdCordoba.Checked = True
                txtTazaCambio.Value = Config.tazadecambio
                rdContado.Checked = True
                txtPlazo.Clear()
                txtFechaVencimiento.Clear()
                rdSindescuento.Checked = True
                btGuardar.Enabled = True : btAnular.Enabled = False : btImprimir.Enabled = False
                txtCodigo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Function generarCodigo(ByVal serie As String) As String
        Try
            Using db As New CodeFirst
                Dim venta = ((From ven In db.Compras Where ven.IDSERIE = serie Select ven.IDSERIE, ven.CONSECUTIVO).Union(From dev In db.ComprasDevoluciones Where dev.IDSERIE = serie Select dev.IDSERIE, dev.CONSECUTIVO)).OrderBy(Function(f) f.CONSECUTIVO).ToList.LastOrDefault
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

    Private Sub frmCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.frmCompra_Resize(Nothing, Nothing)
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
            dtpCaducidad.Value = dtpFecha.Value
            Grid()
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        FormLoad = True
    End Sub

    Private Sub btProveedor_Click(sender As Object, e As EventArgs) Handles btProveedor.Click
        frmBuscarProveedor.frm_return = 2
        frmBuscarProveedor.ShowDialog()
        If Not txtIdProveedor.Text.Trim = "" Then
            txtCodigoAlterno.Focus()
        Else
            txtNCliente.Focus()
        End If
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        frmSeleccionarSerie.operacion = "COMPRA"
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

    Private Sub txtNProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If txtIdSerie.Text <> "" Then
                    If Not txtNCliente.Text.Trim() = "" Then
                        Using db As New CodeFirst
                            Dim proveedor = db.Proveedores.Where(Function(f) f.N_PROVEEDOR = txtNCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                            If Not proveedor Is Nothing Then
                                txtIdProveedor.Text = proveedor.IDPROVEEDOR
                                txtNombreProveedor.Text = If(proveedor.TIPOPERSONA = "Natural", proveedor.N_PROVEEDOR & " " & proveedor.NOMBRES & " " & proveedor.APELLIDOS & If(proveedor.RAZONSOCIAL.Trim() <> "", " // " & proveedor.N_PROVEEDOR & " " & proveedor.RAZONSOCIAL, ""), proveedor.N_PROVEEDOR & " " & proveedor.RAZONSOCIAL)
                                txtNCliente.Clear()
                                txtObservacion.Focus()
                            Else
                                If MessageBox.Show("Proveedor no registrado. ¿Desea registrar compra con este nombre?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    txtIdProveedor.Clear()
                                    txtNombreProveedor.Text = txtNCliente.Text
                                    txtNCliente.Clear()
                                    txtObservacion.Focus()
                                End If
                            End If
                            proveedor = Nothing
                            If rdCredito.Checked Then
                                rdContado.Checked = True
                            End If
                        End Using
                    Else
                        frmBuscarProveedor.frm_return = 2 'retornar el valor aqui
                        frmBuscarProveedor.ShowDialog()
                        If Not txtIdProveedor.Text.Trim = "" Then
                            txtObservacion.Focus()
                        Else
                            txtNCliente.Focus()
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

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        Try
            If rdCredito.Checked Then
                If txtIdSerie.Text <> "" Then
                    If Not txtIdProveedor.Text.Trim() = "" Then
                        Using db As New CodeFirst
                            Dim proveedor = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtIdProveedor.Text And f.ACTIVO = "S").FirstOrDefault()
                            If Not proveedor Is Nothing Then
                                If proveedor.PLAZO > 0 Then
                                    txtPlazo.Text = proveedor.PLAZO.ToString()
                                    txtFechaVencimiento.Text = DateTime.Parse(dtpFecha.Text).AddDays(proveedor.PLAZO).ToString(Config.formato_fecha)
                                Else
                                    MessageBox.Show("Error, Este 'Proveedor' no tiene plazo para crédito.")
                                    rdContado.Checked = True
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("Error, No se encuentra este 'Proveedor'.")
                            End If
                            proveedor = Nothing
                        End Using
                    Else
                        If rdCredito.Checked Then
                            MessageBox.Show("Error, Seleccione el 'Proveedor'.")
                            rdContado.Checked = True
                            frmBuscarProveedor.frm_return = 2 'retornar el valor aqui
                            frmBuscarProveedor.ShowDialog()
                            frmBuscarProveedor.Dispose()
                        End If
                    End If
                Else
                    If rdCredito.Checked Then
                        MessageBox.Show("Error, Seleccione la serie")
                        rdContado.Checked = True
                        txtSerie.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        txtPlazo.Clear()
        txtFechaVencimiento.Clear()
    End Sub

    Private Sub btProducto_Click(sender As Object, e As EventArgs) Handles btProducto.Click
        frmBuscarProductos.frm_return = 15 'retornar el valor aqui
        frmBuscarProductos.ShowDialog()
        txtCodigoAlterno.Focus()
    End Sub

    Private Sub txtCodigoAlterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoAlterno.KeyPress
        Try
            If e.KeyChar = ChrW(13) Then
                If txtIdSerie.Text <> "" Then
                    If Not txtCodigoAlterno.Text.Trim = "" Then
                        Using db As New CodeFirst
                            Dim producto = db.Productos.Where(Function(f) f.IDALTERNO = txtCodigoAlterno.Text And f.ACTIVO = "S" And f.Marca.ACTIVO = "S").FirstOrDefault()
                            If Not producto Is Nothing Then
                                If producto.CMONEDA.Equals(Config.cordoba) Then
                                    txtPrecio.Value = If(rdCordoba.Checked, producto.COSTO, producto.COSTO / txtTazaCambio.Value)
                                Else
                                    txtPrecio.Value = If(rdCordoba.Checked, producto.COSTO * txtTazaCambio.Value, producto.COSTO)
                                End If
                                txtCantidad.Focus()
                            Else
                                frmBuscarProductos.frm_return = 15 'retornar el valor aqui
                                frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                                frmBuscarProductos.ShowDialog()
                            End If
                            producto = Nothing
                        End Using
                    Else
                        frmBuscarProductos.frm_return = 15 'retornar el valor aqui
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

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCodigoAlterno.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btAgregarProducto_Click(sender As Object, e As EventArgs) Handles btAgregarProducto.Click
        frmProducto.MdiParent = frmPrincipal
        frmProducto.BringToFront()
        frmProducto.Show()
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If txtCodigoAlterno.Text.Trim() <> "" Then
                    Try
                        Using db As New CodeFirst
                            Dim producto = ExistenciaController.BuscarProductoPorCodigo(txtCodigoAlterno.Text.Trim, Config.bodega)
                            If Not producto Is Nothing Then
                                If txtPrecio.Text = "" Then
                                    If producto.Producto.CMONEDA.Equals(Config.cordoba) Then
                                        txtPrecio.Value = If(rdCordoba.Checked, producto.Producto.COSTO, producto.Producto.COSTO / txtTazaCambio.Value)
                                    Else
                                        txtPrecio.Value = If(rdCordoba.Checked, producto.Producto.COSTO * txtTazaCambio.Value, producto.Producto.COSTO)
                                    End If
                                    txtPrecio.Focus()
                                ElseIf Not txtCantidad.Text.Trim = "" And Not txtPrecio.Text.Trim = "" Then
                                    Dim precioN As Decimal = Decimal.Parse(txtPrecio.Value.ToString())
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
                                    Dim detalle = detalles.Where(Function(f) f.IDALTERNO = producto.Producto.IDALTERNO).FirstOrDefault()
                                    Dim nuevo As Boolean = False
                                    If detalle Is Nothing Then
                                        detalle = New LST_DETALLE_COMPRA : nuevo = True
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
                                            .PRECIOUNITARIO_C = txtPrecio.Value
                                            .PRECIOUNITARIO_D = txtPrecio.Value / txtTazaCambio.Value
                                        Else
                                            .PRECIOUNITARIO_C = txtPrecio.Value * txtTazaCambio.Value
                                            .PRECIOUNITARIO_D = txtPrecio.Value
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
                                MessageBox.Show("Error, no se encuentra ningun producto con este código alterno.")
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

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Using db As New CodeFirst
                        Dim p = db.Productos.Where(Function(f) f.IDALTERNO = txtCodigoAlterno.Text And f.ACTIVO = "S" And f.Marca.ACTIVO = "S").FirstOrDefault()
                        If Not p Is Nothing Then
                            If txtPrecio.Text.Trim() <> "" Then
                                txtCantidad.Focus()
                            Else
                                If p.CMONEDA.Equals(Config.cordoba) Then
                                    txtPrecio.Value = If(rdCordoba.Checked, p.COSTO, p.COSTO / txtTazaCambio.Value)
                                Else
                                    txtPrecio.Value = If(rdCordoba.Checked, p.COSTO * txtTazaCambio.Value, p.COSTO)
                                End If
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

    Private Sub txtDescuentoPorProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoPorProducto.KeyPress
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

    Private Sub txtIva_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(13) Then
            txtCantidad.Focus()
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

    Private Sub rdSindescuento_CheckedChanged(sender As Object, e As EventArgs) Handles rdSindescuento.CheckedChanged
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

    Private Sub rdDescuentoPorProducto_CheckedChanged(sender As Object, e As EventArgs) Handles rdDescuentoPorProducto.CheckedChanged
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

    Private Sub rdDescuentoPorFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rdDescuentoPorFactura.CheckedChanged
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

    Private Sub txtDescuentoPorFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoPorFactura.KeyPress
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

    Private Sub LoadMov(ByVal v As Compra)
        Try
            Me.FormLoad = False
            Me.Id = v.IDCOMPRA
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
            txtNCompra.Text = v.N_COMPRA
            dtpFecha.Value = v.FECHACOMPRA
            dtpCaducidad.Value = v.FECHADEVOLUCION
            txtIdVendedor.Text = v.Empleado.IDEMPLEADO
            txtNombreVendedor.Text = v.Empleado.N_TRABAJADOR & " | " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS
            If Not v.IDPROVEEDOR Is Nothing Then
                txtIdProveedor.Text = v.Proveedor.IDPROVEEDOR
                txtNombreProveedor.Text = v.Proveedor.N_PROVEEDOR & " | " & v.Proveedor.NOMBRES & " " & v.Proveedor.APELLIDOS & If(v.Proveedor.RAZONSOCIAL <> "", " // " & v.Proveedor.RAZONSOCIAL, "")
                If v.CREDITO Then
                    rdCredito.Checked = True
                    txtFechaVencimiento.Text = v.FECHACREDITOVENCIMIENTO.ToString()
                    txtPlazo.Text = v.Proveedor.PLAZO.ToString()
                Else
                    rdContado.Checked = True
                End If
            Else
                txtNombreProveedor.Text = v.PROVEEDORCONTADO
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
            txtTazaCambio.Text = v.TAZACAMBIO
            If v.MONEDA = Config.cordoba Then
                rdCordoba.Checked = True
            Else
                rdDolar.Checked = True
            End If
            Dim item As LST_DETALLE_COMPRA
            'For Each d In From pro In db.PRODUCTOS Join mar In db.MARCAS On pro.IDMARCA Equals mar.IDMARCA Join pre In db.PRESENTACIONES On pro.IDPRESENTACION Equals pre.IDPRESENTACION Join uni In db.UNIDADES_DE_MEDIDAS On pro.IDUNIDAD Equals uni.IDUNIDAD Join exi In db.EXISTENCIAS On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DETALLES_COMPRAS On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Where det.IDCOMPRA = v.IDCOMPRA Select pro, mar, uni, pre, exi, det
            For Each d In v.ComprasDetalles
                item = New LST_DETALLE_COMPRA
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
            'If v.MONEDA = "C" Then
            '    txtTotalDescuento.Value = v.DESCUENTO_DIN_C : txtTotalSubtotal.Value = v.SUBTOTAL_C : txtTotalIva.Value = v.IVA_DIN_C : txtTotal.Value = v.TOTAL_C
            'Else
            '    txtTotalDescuento.Value = v.DESCUENTO_DIN_D : txtTotalSubtotal.Value = v.SUBTOTAL_D : txtTotalIva.Value = v.IVA_DIN_D : txtTotal.Value = v.TOTAL_D
            'End If
            If Config._Periodo.ACTUAL.Equals(Config.vTrue) And Config._Periodo.APERTURA IsNot Nothing And Config._Periodo.CIERRE Is Nothing Then
                btAnular.Enabled = True
            End If
            btImprimir.Enabled = True
            btGuardar.Enabled = False
            Me.FormLoad = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub LoadInfo(Optional ByVal vInt As Compra = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            If txtIdSerie.Text <> "" Then
                If Not ByInt Then
                    Using db As New CodeFirst
                        Dim v = db.Compras.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                        If Not v Is Nothing Then
                            If v.ANULADO = "N" Then
                                Me.LoadMov(v)
                            Else
                                MessageBox.Show("Compra anulada")
                            End If
                            v = Nothing
                        Else
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            txtNCompra.Focus()
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

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If Config.ValidarPeriodo(dtpFecha.Value) Then
            Try
                If txtIdSerie.Text <> "" And Not txtObservacion.Text.Trim() = "" And txtNCompra.Text.Trim() <> "" And dtRegistro.Rows.Count > 0 Then
                    Using db As New CodeFirst
                        txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                        If Not txtCodigo.Text.Trim() = "" Then
                            Dim tipodescuento As String = If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", If(rdDescuentoPorFactura.Checked, "POR FACTURA", "SIN DESCUENTO"))
                            Dim descuentoporfactura As Decimal = If(rdDescuentoPorFactura.Checked, txtTotalDescuento.Value, 0)
                            dtpFecha.Value = If(dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString(), DateTime.Now, DateTime.Parse(dtpFecha.Value.ToShortDateString() & " " & DateTime.Now.ToString("HH:mm:ss")))
                            Dim v As New Compra
                            If rdContado.Checked Then
                                If Not txtIdProveedor.Text.Trim() = "" Then
                                    v.IDCOMPRA = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.N_COMPRA = txtNCompra.Text : v.FECHACOMPRA = dtpFecha.Value : v.FECHADEVOLUCION = dtpCaducidad.Value : v.FORMADEPAGO = "" : v.N_PAGO = "" : v.EXONERADO = chkExonerado.Checked : v.PROVEEDORCONTADO = "" : v.CREDITO = False : v.FECHACREDITOVENCIMIENTO = dtpFecha.Value : v.SALDOCREDITO = 0.0 : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.IDPROVEEDOR = txtIdProveedor.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                    db.Compras.Add(v)
                                ElseIf txtNombreProveedor.Text.Trim() <> "" Then
                                    v.IDCOMPRA = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.N_COMPRA = txtNCompra.Text : v.FECHACOMPRA = dtpFecha.Value : v.FECHADEVOLUCION = dtpCaducidad.Value : v.FORMADEPAGO = "" : v.N_PAGO = "" : v.EXONERADO = chkExonerado.Checked : v.PROVEEDORCONTADO = txtNombreProveedor.Text : v.CREDITO = False : v.FECHACREDITOVENCIMIENTO = dtpFecha.Value : v.SALDOCREDITO = 0.0 : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                    db.Compras.Add(v)
                                Else
                                    MessageBox.Show("Ingresar un proveedor")
                                    Exit Sub
                                End If
                            ElseIf rdCredito.Checked Then
                                Dim p = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtIdProveedor.Text).FirstOrDefault()
                                If Not p Is Nothing Then
                                    Dim saldo As Decimal
                                    Dim cs = From com In db.Compras Where com.ANULADO = "N" And com.IDPROVEEDOR = txtIdProveedor.Text And com.CREDITO = True Select com.MONEDA, com.SALDOCREDITO
                                    Dim compras = (From com In db.Compras Where com.ANULADO = "N" And com.IDPROVEEDOR = txtIdProveedor.Text And com.CREDITO = True And com.MONEDA = Config.dolar Select If(p.MONEDA.Equals(Config.cordoba), com.SALDOCREDITO * Config.tazadecambio, com.SALDOCREDITO)).Union(From ven In db.Ventas Where ven.ANULADO = "N" And ven.IDCLIENTE = txtIdProveedor.Text And ven.CREDITO = True And ven.MONEDA = Config.cordoba Select If(p.MONEDA.Equals(Config.cordoba), ven.SALDOCREDITO, ven.SALDOCREDITO / Config.tazadecambio))
                                    If Not cs Is Nothing Then
                                        If p.MONEDA.Equals(Config.cordoba) Then
                                            saldo = If(cs.Where(Function(f) f.MONEDA.Equals(Config.cordoba)).Count() > 0, cs.Where(Function(f) f.MONEDA.Equals(Config.cordoba)).Sum(Function(f) f.SALDOCREDITO), 0) + If(cs.Where(Function(f) f.MONEDA.Equals(Config.dolar)).Count() > 0, cs.Where(Function(f) f.MONEDA.Equals(Config.dolar)).Sum(Function(f) f.SALDOCREDITO) * txtTazaCambio.Value, 0)
                                        Else
                                            saldo = If(cs.Where(Function(f) f.MONEDA.Equals(Config.cordoba)).Count() > 0, cs.Where(Function(f) f.MONEDA.Equals(Config.cordoba)).Sum(Function(f) f.SALDOCREDITO) / txtTazaCambio.Value, 0) + If(cs.Where(Function(f) f.MONEDA.Equals(Config.dolar)).Count() > 0, cs.Where(Function(f) f.MONEDA.Equals(Config.dolar)).Sum(Function(f) f.SALDOCREDITO), 0)
                                        End If
                                    End If
                                    saldo = p.LIMITECREDITO - saldo
                                    If saldo >= If(p.MONEDA.Equals(Config.cordoba), detalles.Sum(Function(f) f.TOTAL_C), detalles.Sum(Function(f) f.TOTAL_D)) Then
                                        v.IDCOMPRA = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.N_COMPRA = txtNCompra.Text : v.FECHACOMPRA = dtpFecha.Value : v.FECHADEVOLUCION = dtpCaducidad.Value : v.FORMADEPAGO = "Sin Especificar" : v.N_PAGO = "" : v.EXONERADO = chkExonerado.Checked : v.PROVEEDORCONTADO = "" : v.CREDITO = True : v.FECHACREDITOVENCIMIENTO = dtpFecha.Value.AddDays(p.PLAZO) : v.SALDOCREDITO = txtTotal.Value : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.IDPROVEEDOR = txtIdProveedor.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                        If rdCordoba.Checked Then
                                            p.FACTURADO_C = p.FACTURADO_C + v.TOTAL_C
                                        Else
                                            p.FACTURADO_D = p.FACTURADO_D + v.TOTAL_D
                                        End If
                                        Dim est As New CompraEstadoCuenta : est.IDESTADO = Guid.NewGuid.ToString() : est.IDSERIE = v.IDSERIE : est.N_DOCUMENTO = v.CONSECUTIVO : est.N_COMPRA = v.N_COMPRA : est.OPERACION = "Compra" : est.FECHA = v.FECHACOMPRA : est.FORMADEPAGO = v.FORMADEPAGO : est.N_PAGO = v.N_PAGO : est.PLAZO = p.PLAZO : est.FECHAVENCIMIENTO = v.FECHACREDITOVENCIMIENTO : est.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : est.TAZACAMBIO = txtTazaCambio.Value : est.HABER_C = v.TOTAL_C : est.HABER_D = v.TOTAL_D : est.DEBE_C = 0.0 : est.DEBE_D = 0.0 : est.ACTIVO = "S" : est.IDCOMPRA = v.IDCOMPRA : db.ComprasEstadosCuentas.Add(est) : est = Nothing
                                        db.Compras.Add(v)
                                    Else
                                        MessageBox.Show("Error, La empresa no tiene no tiene limite de crédito disponible con este proveedor para registrar compra de crécito: C$ " & txtTotal.Text)
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Error, No se encuentra este proveedor en la base de datos. Probablemente ha sido eliminado.")
                                    Exit Sub
                                End If
                                p = Nothing
                            End If
                            Dim producto As Existencia : Dim cont As Integer = 0 : Dim d As CompraDetalle
                            For Each det In detalles
                                producto = db.Existencias.Where(Function(f) f.IDEXISTENCIA = det.IDEXISTENCIA And f.Producto.ACTIVO = "S").FirstOrDefault()
                                If Not producto Is Nothing Then
                                    d = New CompraDetalle
                                    d.IDDETALLECOMPRA = Guid.NewGuid.ToString()
                                    d.CMONEDA = producto.Producto.CMONEDA
                                    d.COSTO = producto.Producto.COSTO
                                    d.EXISTENCIA_PRODUCTO = producto.CANTIDAD
                                    d.CANTIDAD = det.CANTIDAD
                                    d.PRECIOUNITARIO_C = det.PRECIOUNITARIO_C
                                    d.PRECIOUNITARIO_D = det.PRECIOUNITARIO_D
                                    d.DESCUENTO_POR = det.DESCUENTO_POR
                                    d.DESCUENTO_DIN_C = det.DESCUENTO_DIN_C
                                    d.DESCUENTO_DIN_D = det.DESCUENTO_DIN_D
                                    d.DESCUENTO_DIN_TOTAL_C = det.DESCUENTO_DIN_TOTAL_C
                                    d.DESCUENTO_DIN_TOTAL_D = det.DESCUENTO_DIN_TOTAL_D
                                    d.PRECIONETO_C = det.PRECIONETO_C
                                    d.PRECIONETO_D = det.PRECIONETO_D
                                    d.SUBTOTAL_C = det.SUBTOTAL_C
                                    d.SUBTOTAL_D = det.SUBTOTAL_D
                                    d.IVA_POR = det.IVA_POR
                                    d.IVA_DIN_C = det.IVA_DIN_C
                                    d.IVA_DIN_D = det.IVA_DIN_D
                                    d.IVA_DIN_TOTAL_C = det.IVA_DIN_TOTAL_C
                                    d.IVA_DIN_TOTAL_D = det.IVA_DIN_TOTAL_D
                                    d.TOTAL_C = det.TOTAL_C
                                    d.TOTAL_D = det.TOTAL_D
                                    d.IDEXISTENCIA = det.IDEXISTENCIA
                                    d.IDCOMPRA = v.IDCOMPRA
                                    db.ComprasDetalles.Add(d)
                                    Dim k As New Kardex
                                    k.IDKARDEX = Guid.NewGuid.ToString()
                                    k.IDEXISTENCIA = producto.IDEXISTENCIA
                                    k.IDSERIE = txtIdSerie.Text
                                    k.N_DOCUMENTO = txtCodigo.Text
                                    k.FECHADOCUMENTO = dtpFecha.Value
                                    k.EXISTENCIA_ANTERIOR = producto.CANTIDAD
                                    producto.CANTIDAD = producto.CANTIDAD + det.CANTIDAD
                                    db.Entry(producto).State = EntityState.Modified
                                    k.OPERACION = If(rdContado.Checked, "COMPRA CONTADO", "COMPRA CREDITO")
                                    k.EXISTENCIA_ALMACEN = producto.CANTIDAD
                                    k.DESCRIPCION = "[" & txtNombreProveedor.Text & "] " & txtObservacion.Text
                                    k.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                    k.TAZACAMBIO = txtTazaCambio.Value
                                    k.ENTRADA = d.CANTIDAD
                                    k.SALIDA = 0
                                    k.CMONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                    k.COSTO = If(rdCordoba.Checked, d.PRECIONETO_C, d.PRECIONETO_D)
                                    k.DEBER = (k.ENTRADA * k.COSTO)
                                    k.HABER = 0
                                    k.PRECIO_C = 0
                                    k.PRECIO_D = 0
                                    producto.Producto.CANTIDAD = producto.Producto.CANTIDAD + d.CANTIDAD
                                    producto.Producto.SALDO = producto.Producto.SALDO + If(producto.Producto.CMONEDA.Equals(Config.cordoba), d.PRECIONETO_C * d.CANTIDAD, d.PRECIONETO_D * d.CANTIDAD)
                                    If producto.Producto.CANTIDAD <> 0 Then
                                        If If(rdCordoba.Checked, d.PRECIONETO_C, d.PRECIONETO_D) <> d.COSTO Then
                                            producto.Producto.COSTO = (producto.Producto.SALDO / producto.Producto.CANTIDAD)
                                        End If
                                        k.COSTO_PROMEDIO = producto.Producto.COSTO
                                        If producto.CANTIDAD = 0 Then
                                            k.SALDO = 0
                                        Else
                                            k.SALDO = k.EXISTENCIA_ALMACEN * k.COSTO_PROMEDIO
                                        End If
                                    Else
                                        k.COSTO_PROMEDIO = producto.Producto.COSTO
                                        producto.Producto.SALDO = 0
                                        k.SALDO = 0
                                    End If
                                    db.Entry(producto.Producto).State = EntityState.Modified
                                    k.ACTIVO = "S" : db.Kardexs.Add(k)
                                    'destruccion
                                    d = Nothing : k = Nothing
                                    cont = cont + 1 'incrementar contador
                                Else
                                    MessageBox.Show("Error, No se encuentra el producto '" & det.IDALTERNO & " - " & det.DESCRIPCION & "'. Probablemente ha sido eliminado.")
                                    Exit Sub
                                End If
                            Next
                            If cont > 0 Then
                                db.SaveChanges()
                                Me.Id = v.IDCOMPRA
                                txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
                                btGuardar.Enabled = False : btAnular.Enabled = True : btImprimir.Enabled = True
                            Else
                                MessageBox.Show("Error, No se puede guardar 'Compra' si detalle.")
                            End If
                            cont = Nothing : producto = Nothing : v = Nothing
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

    Private Sub btAnular_Click(sender As Object, e As EventArgs) Handles btAnular.Click
        Try
            If MessageBox.Show("¿Desea anular esta compra?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                If Not Me.Id.Trim() = "" Then
                    Using db As New CodeFirst
                        Dim v = db.Compras.Where(Function(f) f.IDCOMPRA = Me.Id And f.ANULADO = "N").FirstOrDefault()
                        If Not v Is Nothing Then
                            If Config.ValidarPeriodo(v.FECHACOMPRA) Then
                                If v.CREDITO Then
                                    If v.SALDOCREDITO <> If(v.MONEDA.Equals(Config.cordoba), v.TOTAL_C, v.TOTAL_D) Then
                                        MessageBox.Show("Error, esta compra de crédito tiene recibos y/o devoluciones realizados para anularla debe anular primero los recibos y/o devoluciones.")
                                        Exit Sub
                                    End If
                                    If v.CREDITO And Not v.IDPROVEEDOR Is Nothing Then
                                        If v.MONEDA.Equals(Config.cordoba) Then
                                            v.Proveedor.FACTURADO_C = v.Proveedor.FACTURADO_C - v.TOTAL_C
                                        Else
                                            v.Proveedor.FACTURADO_D = v.Proveedor.FACTURADO_D - v.TOTAL_D
                                        End If
                                        db.Entry(v.Proveedor).State = EntityState.Modified
                                    End If
                                End If

                                v.ANULADO = "S" : db.Entry(v).State = EntityState.Modified

                                For Each estado In db.ComprasEstadosCuentas.Where(Function(f) f.IDCOMPRA = v.IDCOMPRA)
                                    estado.ACTIVO = "N" : db.Entry(estado).State = EntityState.Modified
                                Next

                                For Each item In v.ComprasDetalles
                                    item.Existencia.CANTIDAD = item.Existencia.CANTIDAD - item.CANTIDAD
                                    item.Existencia.Producto.CANTIDAD = item.Existencia.Producto.CANTIDAD - item.CANTIDAD
                                    If item.Existencia.CANTIDAD < 0 Then
                                        If Not item.Existencia.Producto.FACTURAR_NEGATIVO Then
                                            Config.MsgErr("No se puede anular esta Compra. Ya que la existencia del producto '" & item.Existencia.Producto.IDALTERNO & " - " & item.Existencia.Producto.DESCRIPCION & "' quedaría en negativo.")
                                            Exit Sub
                                        End If
                                    End If
                                    If item.Existencia.Producto.CANTIDAD = 0 Then
                                        item.Existencia.Producto.SALDO = 0
                                    Else
                                        If item.CMONEDA.Equals(item.Existencia.Producto.CMONEDA) Then
                                            item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * If(item.CMONEDA.Equals(Config.cordoba), item.PRECIOUNITARIO_C, item.PRECIOUNITARIO_D))
                                        Else
                                            If item.CMONEDA.Equals(Config.cordoba) Then
                                                item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.PRECIOUNITARIO_D)
                                            Else
                                                item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.PRECIOUNITARIO_C)
                                            End If
                                        End If
                                    End If
                                    If item.Existencia.Producto.CANTIDAD <> 0 Then
                                        If item.Existencia.Producto.COSTO <> item.COSTO Then
                                            item.Existencia.Producto.COSTO = item.Existencia.Producto.SALDO / item.Existencia.Producto.CANTIDAD
                                        End If
                                    End If

                                    db.Entry(item.Existencia.Producto).State = EntityState.Modified
                                    db.Entry(item).State = EntityState.Modified
                                Next

                                Using dbk As New CodeFirst
                                    Dim ik As Boolean = False
                                    For Each kardex In db.Kardexs.Where(Function(f) f.IDSERIE = v.IDSERIE And f.N_DOCUMENTO = txtCodigo.Text)
                                        For Each k In dbk.Kardexs.Where(Function(f) f.N > kardex.N And f.IDEXISTENCIA = kardex.IDEXISTENCIA)
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


                                            k.COSTO_PROMEDIO = k.SALDO / k.EXISTENCIA_ALMACEN

                                            dbk.Entry(k).State = EntityState.Modified
                                            ik = True
                                        Next
                                        kardex.ACTIVO = "N" : db.Entry(kardex).State = EntityState.Modified
                                    Next
                                    If ik Then
                                        dbk.SaveChanges()
                                    End If
                                    db.SaveChanges() : MessageBox.Show("Compra Anulada") : limpiar()
                                End Using

                                v = Nothing
                            End If
                        Else
                            MessageBox.Show("Error, No se encuentra esta compra. Probablemente ha sido eliminada o anulada.")
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Seleccione una compra")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtNCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCompra.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If txtNCompra.Text.Trim <> "" Then
                    txtNVendedor.Focus()
                Else
                    MessageBox.Show("Ingresar el Nº de Factura de Compra.")
                End If
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
        End If
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

    Private Sub frmCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    btNuevo_Click(Nothing, Nothing)
                    Exit Sub
                Case Keys.G
                    If btGuardar.Enabled Then
                        btGuardar_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                Case Keys.Delete
                    If btAnular.Enabled Then
                        btAnular_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                Case Keys.P
                    If btImprimir.Enabled Then
                        btImprimir_Click(Nothing, Nothing)
                        Exit Sub
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
                    frmBCompra.ShowDialog()
                End If
        End Select
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dtRegistro.SelectedRows.Count > 0 Then
                'descargar precios del total
                'If bandDescFact Then
                '    txtTotalSubtotal.Value = txtTotalSubtotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(14).Value.ToString())
                '    txtTotalDescuento.Value = txtTotalDescuento.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(15).Value.ToString())
                '    txtTotalIva.Text = txtTotalIva.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(16).Value.ToString())
                '    txtTotal.Text = txtTotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(17).Value.ToString())
                'Else
                '    txtTotalSubtotal.Value = txtTotalSubtotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(14).Value.ToString())
                '    If rdDescuentoPorProducto.Checked Then
                '        txtTotalDescuento.Value = txtTotalDescuento.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(15).Value.ToString())
                '    End If
                '    txtTotalIva.Text = txtTotalIva.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(16).Value.ToString())
                '    txtTotal.Text = txtTotal.Value - Decimal.Parse(dtRegistro.SelectedRows(0).Cells(17).Value.ToString())
                'End If
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

    Private Sub frmCompra_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ElGroupBox5.Left = Me.PanelEx3.Width - ElGroupBox5.Width - 7
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress
        If e.KeyChar = ChrW(13) Then
            btActualizarSerie_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        frmImprimirCompra.idcompra = Me.Id
        frmImprimirCompra.ShowDialog()
    End Sub

    Private Sub rdCordoba_CheckedChanged(sender As Object, e As EventArgs) Handles rdCordoba.CheckedChanged
        If Me.FormLoad Then
            Me.Grid()
        End If
    End Sub

    Private Sub rdDolar_CheckedChanged(sender As Object, e As EventArgs) Handles rdDolar.CheckedChanged
        If FormLoad Then
            Me.Grid()
        End If
    End Sub

    Private Sub txtTazaCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTazaCambio.ValueChanged
        If Me.FormLoad Then
            Try
                Dim iva As Decimal
                For Each d In Me.detalles
                    If chkExonerado.Checked = False Then : iva = Config.iva : Else : iva = (txtIva.Value / 100) : End If
                    If d.IVA = False Then : iva = 0 : End If
                    With d
                        .CANTIDAD = txtCantidad.Value
                        If rdCordoba.Checked Then
                            .PRECIOUNITARIO_D = .PRECIOUNITARIO_C / txtTazaCambio.Value
                        Else
                            .PRECIOUNITARIO_C = .PRECIOUNITARIO_D * txtTazaCambio.Value
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
                        .SUBTOTAL_C = (.PRECIONETO_C * .CANTIDAD) : .SUBTOTAL_D = (.PRECIONETO_D * .CANTIDAD)
                        .IVA_POR = iva * 100
                        .IVA_DIN_C = .PRECIONETO_C * iva : .IVA_DIN_D = .PRECIONETO_D * iva
                        .IVA_DIN_TOTAL_C = .SUBTOTAL_C * iva : .IVA_DIN_TOTAL_D = .SUBTOTAL_D * iva
                        .TOTAL_C = (.SUBTOTAL_C + .IVA_DIN_TOTAL_C) : .TOTAL_D = (.SUBTOTAL_D + .IVA_DIN_TOTAL_D)
                    End With
                Next
                Me.Grid()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtTazaCambio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTazaCambio.KeyDown
        If e.KeyData = Keys.Enter Then
            txtTazaCambio_ValueChanged(Nothing, Nothing)
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub btEstadoProveedor_Click(sender As Object, e As EventArgs) Handles btEstadoProveedor.Click
        If txtIdProveedor.Text <> "" Then
            frmEstado.frm_return = 1
            frmEstado.id = txtIdProveedor.Text
            frmEstado.ShowDialog()
        Else
            MessageBox.Show("Seleccionar un 'Proveedor' que este registrado.")
        End If
    End Sub

    Private Sub txtNVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNVendedor.KeyDown
        If e.KeyData = Keys.Enter Then
            Try
                If txtIdSerie.Text <> "" Then
                    Using db As New CodeFirst
                        If Not txtNVendedor.Text.Trim() = "" Then
                            Dim vendedor = db.Empleados.Where(Function(f) f.N_TRABAJADOR = txtNVendedor.Text And f.COMPRA And f.ACTIVO = "S").FirstOrDefault()
                            If Not vendedor Is Nothing Then
                                txtIdVendedor.Text = vendedor.IDEMPLEADO
                                txtNombreVendedor.Text = vendedor.N_TRABAJADOR & " | " & vendedor.NOMBRES & " " & vendedor.APELLIDOS
                                txtNVendedor.Clear()
                                txtNCliente.Focus()
                            Else
                                MessageBox.Show("Error, Debe ingresar un 'Comprador'")
                            End If
                            vendedor = Nothing
                        Else
                            If Not txtIdVendedor.Text.Trim = "" Then
                                txtNCliente.Focus()
                            Else
                                frmBuscarEmpleado.LaborPre = 2
                                frmBuscarEmpleado.frm_return = 13
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
        frmBuscarEmpleado.LaborPre = 2
        frmBuscarEmpleado.frm_return = 13
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text.Trim() = "" Then
            txtNCliente.Focus()
        Else
            txtNVendedor.Focus()
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        If rdCredito.Checked Then
            txtFechaVencimiento.Text = DateTime.Parse(dtpFecha.Text).AddDays(txtPlazo.Text).ToString(Config.formato_fecha)
        End If
        dtpCaducidad.MinDate = dtpFecha.Value
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyData = Keys.Enter Then
            dtpCaducidad.Focus()
        End If
    End Sub

    Private Sub dtpCaducidad_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCaducidad.KeyDown
        If e.KeyData = Keys.Enter Then
            txtNVendedor.Focus()
        End If
    End Sub
End Class