Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmNotaDevolucionCompra

    Dim bandDescFact As Boolean = False
    Dim bandDescProd As Boolean = False

    'factura seleccionada
    Public Id As String = ""

    Public detalles As New List(Of LST_DETALLE_DEVOLUCION_COMPRA)

    Dim cod As String = ""

    Dim ExistenciaController As New Capadenegocio.Controller.ExistenciaController

    Dim FormLoad As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Sub limpiar()
        Try
            If txtIdSerie.Text <> "" Then
                detalles.RemoveAll(Function(f) True)
                Grid()
                lblContador.Text = "N° ITEM: 0"
                txtTotalDescuento.Value = 0.0 : txtTotalIva.Value = 0.0 : txtTotalSubtotal.Value = 0.0 : txtTotal.Value = 0.0
                txtCodigo.Enabled = True
                txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                txtNDevolucion.Clear()
                dtpFecha.Value = DateTime.Now
                txtIdVendedor.Clear() : txtNVendedor.Clear() : txtNombreVendedor.Clear()
                txtIdProveedor.Clear() : txtNCliente.Clear() : txtNombreProveedor.Clear()
                txtObservacion.Clear()
                If Not rdSindescuento.Checked Then
                    rdSindescuento.Checked = True
                End If
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
                Dim compra = ((From com In db.Compras Where com.IDSERIE = serie Select com.IDSERIE, com.CONSECUTIVO).Union(From dev In db.ComprasDevoluciones Where dev.IDSERIE = serie Select dev.IDSERIE, dev.CONSECUTIVO)).OrderBy(Function(f) f.CONSECUTIVO).ToList.LastOrDefault
                If Not compra Is Nothing Then
                    cod = compra.CONSECUTIVO
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

    Private Async Sub frmNotaDevolucionCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Await Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "ReturnPurchase",
            "Load",
            "Load ReturnPurchase",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Me.frmNotaDevolucionCompra_Resize(Nothing, Nothing)
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
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Using db As New CodeFirst
                        Dim producto = db.Productos.Where(Function(f) f.IDALTERNO = txtCodigoAlterno.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not producto Is Nothing Then
                            txtPrecio.Value = If(rdCordoba.Checked, producto.COSTO * txtTazaCambio.Value, producto.COSTO)
                            txtCantidad.Focus()
                        Else
                            frmBuscarProductos.frm_return = 16 'retornar el valor aqui
                            frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                            frmBuscarProductos.ShowDialog()
                        End If
                        producto = Nothing
                    End Using
                Else
                    frmBuscarProductos.frm_return = 16 'retornar el valor aqui
                    frmBuscarProductos.ShowDialog()
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Try
                        Using db As New CodeFirst
                            Dim producto = ExistenciaController.BuscarProductoPorCodigo(txtCodigoAlterno.Text.Trim, Config.warehouseId)
                            If Not producto Is Nothing Then
                                If Not txtCantidad.Text.Trim = "" And txtPrecio.Text.Trim = "" Then
                                    txtPrecio.Value = If(rdCordoba.Checked, producto.Producto.COSTO * txtTazaCambio.Value, producto.Producto.COSTO)
                                    txtPrecio.Focus()
                                ElseIf Not txtCantidad.Text.Trim = "" And Not txtPrecio.Text.Trim = "" Then
                                    If producto.CANTIDAD < txtCantidad.Value Then
                                        If Not producto.Producto.FACTURAR_NEGATIVO Then
                                            MessageBox.Show("La cantidad solicitada es mayor a la existente. No se puede devolver este producto en negativo.")
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
                                    'agregar detalle
                                    If rdCredito.Checked Then
                                        Dim Compra = db.Compras.Where(Function(f) f.IDCOMPRA = txtIdFactura.Text And f.ANULADO.Equals(Config.vFalse)).FirstOrDefault
                                        If Not Compra Is Nothing Then
                                            If Compra.ComprasDetalles.Where(Function(f) f.Existencia.Producto.IDALTERNO = txtCodigoAlterno.Text).FirstOrDefault Is Nothing Then
                                                Config.MsgErr("Ningún Producto con ID Alerno: '" & txtCodigoAlterno.Text & "' pertenece a esta Compra (" & Compra.Serie.NOMBRE & " - " & Compra.CONSECUTIVO & ").")
                                                txtCodigoAlterno.Focus()
                                                Exit Sub
                                            End If
                                        Else
                                            Config.MsgErr("No se encuentra esta Compra. Probablemente ha sido anulada.")
                                            txtFactura.Focus()
                                            Exit Sub
                                        End If
                                    End If
                                    Dim detalle = detalles.Where(Function(f) f.IDALTERNO = producto.Producto.IDALTERNO).FirstOrDefault()
                                    Dim nuevo As Boolean = False
                                    If detalle Is Nothing Then
                                        detalle = New LST_DETALLE_DEVOLUCION_COMPRA : nuevo = True
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

    Private Sub btProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCliente.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarProveedor.frm_return = 5 'retornar el valor aqui
            frmBuscarProveedor.ShowDialog()
            If Not txtIdProveedor.Text.Trim = "" Then
                txtCodigoAlterno.Focus()
            Else
                txtNCliente.Focus()
            End If
        Else
            MessageBox.Show("Error, Seleccione la serie")
        End If
    End Sub

    Private Sub btProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProducto.Click
        If txtIdSerie.Text <> "" Then
            frmBuscarProductos.frm_return = 16 'retornar el valor aqui
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
                If txtIdSerie.Text <> "" And txtNDevolucion.Text.Trim <> "" And txtObservacion.Text.Trim <> "" And Not dtRegistro.Rows.Count = 0 Then
                    Using db As New CodeFirst
                        txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                        If Not txtCodigo.Text.Trim() = "" Then
                            dtpFecha.Value = If(dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString(), DateTime.Now, DateTime.Parse(dtpFecha.Value.ToShortDateString() & " " & DateTime.Now.ToString("HH:mm:ss")))
                            Dim v As New CompraDevolucion
                            v.Reg = DateTime.Now

                            Dim Compra As Compra = Nothing

                            If rdContado.Checked Then
                                If Not txtIdProveedor.Text.Trim() = "" Then
                                    v.IDDEVOLUCION = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.N_DEVOLUCION = txtNDevolucion.Text : v.FECHADEVOLUCION = dtpFecha.Value : v.EXONERADO = chkExonerado.Checked : v.PROVEEDORCONTADO = "" : v.CREDITO = False : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.IDPROVEEDOR = txtIdProveedor.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                    db.ComprasDevoluciones.Add(v)
                                Else
                                    v.IDDEVOLUCION = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.N_DEVOLUCION = txtNDevolucion.Text : v.FECHADEVOLUCION = dtpFecha.Value : v.EXONERADO = chkExonerado.Checked : v.PROVEEDORCONTADO = txtNombreProveedor.Text : v.CREDITO = False : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                    db.ComprasDevoluciones.Add(v)
                                End If
                            Else
                                If txtIdProveedor.Text.Trim() <> "" Then
                                    Dim c = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtIdProveedor.Text And f.ACTIVO.Equals(Config.vTrue)).FirstOrDefault()
                                    If Not c Is Nothing Then
                                        Compra = db.Compras.Where(Function(f) f.IDCOMPRA = txtIdFactura.Text).FirstOrDefault
                                        If Not Compra Is Nothing Then
                                            If Compra.SALDOCREDITO >= If(Compra.MONEDA.Equals(cordoba), If(rdCordoba.Checked, txtTotal.Value, txtTotal.Value * txtTazaCambio.Value), If(rdCordoba.Checked, txtTotal.Value / txtTazaCambio.Value, txtTotal.Value)) Then
                                                v.IDDEVOLUCION = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.N_DEVOLUCION = txtNDevolucion.Text : v.FECHADEVOLUCION = dtpFecha.Value : v.EXONERADO = chkExonerado.Checked : v.PROVEEDORCONTADO = "" : v.CREDITO = True : v.IDCOMPRA = Compra.IDCOMPRA : v.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : v.TAZACAMBIO = txtTazaCambio.Value : v.CONCEPTO = txtObservacion.Text : v.DESCUENTO_POR_FACT = If(rdDescuentoPorFactura.Checked, Decimal.Parse(lblDescuentoPorFactura.Text), 0) : v.DESCUENTO_DIN_FACT_C = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_C), 0) : v.DESCUENTO_DIN_FACT_D = If(rdDescuentoPorFactura.Checked, detalles.Sum(Function(f) f.DESCUENTO_DIN_TOTAL_D), 0) : v.DESCUENTO_DIN_C = detalles.Sum(Function(f) f.DESCUENTO_DIN_C) : v.DESCUENTO_DIN_D = detalles.Sum(Function(f) f.DESCUENTO_DIN_D) : v.TIPODESCUENTO = If(v.DESCUENTO_DIN_D > 0, If(rdDescuentoPorProducto.Checked, "POR PRODUCTO", "POR FACTURA"), "SIN DESCUENTO") : v.SUBTOTAL_C = detalles.Sum(Function(f) f.SUBTOTAL_C) : v.SUBTOTAL_D = detalles.Sum(Function(f) f.SUBTOTAL_D) : v.IVA_POR = If(v.EXONERADO, 0, Config.iva) : v.IVA_DIN_C = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_C)) : v.IVA_DIN_D = If(v.EXONERADO, 0, detalles.Sum(Function(f) f.IVA_DIN_TOTAL_D)) : v.TOTAL_C = detalles.Sum(Function(f) f.TOTAL_C) : v.TOTAL_D = detalles.Sum(Function(f) f.TOTAL_D) : v.IDEMPLEADO = txtIdVendedor.Text : v.IDPROVEEDOR = txtIdProveedor.Text : v.REIMPRESION = "N" : v.ANULADO = "N"
                                                If rdCordoba.Checked Then
                                                    Compra.SALDOCREDITO = Compra.SALDOCREDITO - If(Compra.MONEDA.Equals(Config.cordoba), v.TOTAL_C, v.TOTAL_D)
                                                    c.FACTURADO_C = c.FACTURADO_C - v.TOTAL_C
                                                Else
                                                    Compra.SALDOCREDITO = Compra.SALDOCREDITO - If(Compra.MONEDA.Equals(Config.cordoba), v.TOTAL_C, v.TOTAL_D)
                                                    c.FACTURADO_D = c.FACTURADO_D - v.TOTAL_D
                                                End If

                                                db.Entry(Compra).State = EntityState.Modified
                                                db.Entry(c).State = EntityState.Modified

                                                Dim est As New CompraEstadoCuenta
                                                est.IDESTADO = Guid.NewGuid.ToString()
                                                est.IDSERIE = v.IDSERIE
                                                est.N_DOCUMENTO = v.CONSECUTIVO
                                                est.N_COMPRA = v.N_DEVOLUCION
                                                est.OPERACION = "Devol"
                                                est.FECHA = v.FECHADEVOLUCION
                                                est.FORMADEPAGO = v.FORMADEPAGO
                                                est.N_PAGO = v.N_PAGO
                                                est.PLAZO = 0
                                                est.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                                est.TAZACAMBIO = txtTazaCambio.Value
                                                est.HABER_C = 0.0
                                                est.HABER_D = 0.0
                                                est.DEBE_C = v.TOTAL_C
                                                est.DEBE_D = v.TOTAL_D
                                                est.ACTIVO = "S"
                                                est.IDCOMPRA = Compra.IDCOMPRA
                                                est.IDDEVOLUCION = v.IDDEVOLUCION
                                                db.ComprasEstadosCuentas.Add(est)
                                                est = Nothing

                                                db.ComprasDevoluciones.Add(v)
                                            Else
                                                Config.MsgErr("El Saldo(" & Compra.SALDOCREDITO.ToString(Config.f_m) & ") de la venta '" & Compra.Serie.NOMBRE & " - " & Compra.CONSECUTIVO & "' es " _
                                                              & "menor que el total que intentas devolver.")
                                                Exit Sub
                                            End If
                                        Else
                                            Config.MsgErr("La Compra que desea cargar una devolución no se encuentra. Probablemente ha sido eliminada o anulada.")
                                            Exit Sub
                                        End If
                                    Else
                                        Config.MsgErr("No se encuentra este proveedor en la base de datos. Probablemente ha sido eliminado.")
                                        Exit Sub
                                    End If
                                Else
                                    Config.MsgErr("Para crear una Devolución de Crédito tiene que seleccionar un proveedor que este registrado.")
                                    Exit Sub
                                End If
                            End If
                            Dim producto As Existencia : Dim cont As Integer = 0 : Dim d As CompraDevolucionDetalle
                            For Each item In detalles
                                producto = db.Existencias.Where(Function(f) f.IDEXISTENCIA = item.IDEXISTENCIA And f.Producto.ACTIVO = "S").FirstOrDefault()

                                If Not producto Is Nothing Then

                                    If Not Compra Is Nothing Then
                                        If Compra.ComprasDetalles.Where(Function(f) f.Existencia.Producto.IDALTERNO = item.IDALTERNO).FirstOrDefault Is Nothing Then
                                            Config.MsgErr("Ningún Producto con ID Alerno: '" & item.IDALTERNO & "' pertenece a esta Compra (" & Compra.Serie.NOMBRE & " - " & Compra.CONSECUTIVO & ").")
                                            Exit Sub
                                        End If
                                    End If

                                    If producto.CANTIDAD < item.CANTIDAD Then
                                        If Not producto.Producto.FACTURAR_NEGATIVO Then
                                            MessageBox.Show("La cantidad solicitada del producto '" & item.IDALTERNO & " - " & item.DESCRIPCION & "' es mayor a la existente.")
                                            Exit Sub
                                        End If
                                    End If
                                    d = New CompraDevolucionDetalle
                                    d.IDDETALLEDEVOLUCION = Guid.NewGuid.ToString()
                                    d.CMONEDA = producto.Producto.CMONEDA
                                    d.COSTO = producto.Producto.COSTO
                                    d.EXISTENCIA_PRODUCTO = producto.CANTIDAD
                                    d.CANTIDAD_DEVUELTA = item.CANTIDAD
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
                                    db.ComprasDevolucionesDetalles.Add(d)
                                    Dim k As New Kardex
                                    k.IDKARDEX = Guid.NewGuid.ToString()
                                    k.IDEXISTENCIA = producto.IDEXISTENCIA
                                    k.IDSERIE = txtIdSerie.Text
                                    k.N_DOCUMENTO = txtCodigo.Text
                                    k.FECHADOCUMENTO = dtpFecha.Value
                                    k.EXISTENCIA_ANTERIOR = producto.CANTIDAD
                                    producto.CANTIDAD = producto.CANTIDAD - item.CANTIDAD
                                    db.Entry(producto).State = EntityState.Modified
                                    k.OPERACION = "DEVOLUCION COMPRA"
                                    k.EXISTENCIA_ALMACEN = producto.CANTIDAD
                                    k.DESCRIPCION = txtObservacion.Text
                                    k.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                    k.TAZACAMBIO = txtTazaCambio.Value
                                    k.ENTRADA = 0
                                    k.SALIDA = d.CANTIDAD_DEVUELTA
                                    k.CMONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                                    k.COSTO = d.COSTO
                                    k.DEBER = 0
                                    k.HABER = (k.SALIDA * k.COSTO)
                                    k.PRECIO_C = d.PRECIONETO_C
                                    k.PRECIO_D = d.PRECIONETO_D
                                    producto.Producto.CANTIDAD = producto.Producto.CANTIDAD - d.CANTIDAD_DEVUELTA
                                    producto.Producto.SALDO = producto.Producto.SALDO - (d.COSTO * d.CANTIDAD_DEVUELTA)
                                    If producto.Producto.CANTIDAD <> 0 Then
                                        'producto.PRODUCTO.COSTO = (producto.PRODUCTO.SALDO / producto.PRODUCTO.CANTIDAD)
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

    Private Sub btAgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmProveedor.MdiParent = frmPrincipal
        frmProveedor.Show()
        frmProveedor.BringToFront()
    End Sub

    Private Sub btAgregarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarProducto.Click
        frmProducto.ShowDialog()
        txtCodigoAlterno.Focus()
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Using db As New CodeFirst
                        Dim p = db.Productos.Where(Function(f) f.IDALTERNO = txtCodigoAlterno.Text And f.ACTIVO = "S" And f.Marca.ACTIVO = "S").FirstOrDefault()
                        If Not p Is Nothing Then
                            If txtPrecio.Text.Trim() <> "" Then
                                txtCantidad.Focus()
                            Else
                                txtPrecio.Value = If(rdCordoba.Checked, p.COSTO * txtTazaCambio.Value, p.COSTO)
                            End If
                        Else
                            MessageBox.Show("Error, no se encuentra ningun producto con este código alterno.")
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
        If e.KeyChar = ChrW(13) Then
            Try
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
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub LoadMov(ByVal v As CompraDevolucion)
        Try
            Me.FormLoad = False
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            Me.Id = v.IDDEVOLUCION
            txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
            txtNDevolucion.Text = v.N_DEVOLUCION
            dtpFecha.Text = v.FECHADEVOLUCION.ToShortDateString()
            If Not v.IDPROVEEDOR Is Nothing Then
                txtIdProveedor.Text = v.Proveedor.IDPROVEEDOR
                txtNombreProveedor.Text = v.Proveedor.N_PROVEEDOR & " | " & v.Proveedor.NOMBRES & " " & v.Proveedor.APELLIDOS & If(v.Proveedor.RAZONSOCIAL <> "", " // " & v.Proveedor.RAZONSOCIAL, "")
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
                    lblDescuentoPorFactura.Text = v.DESCUENTO_POR_FACT
                    rdDescuentoPorFactura.Checked = True
            End Select
            If v.EXONERADO Then
                chkExonerado.Checked = True
            Else
                chkExonerado.Checked = False
            End If
            txtTazaCambio.Text = v.TAZACAMBIO
            If v.MONEDA = Config.cordoba Then
                rdCordoba.Checked = True
            Else
                rdDolar.Checked = True
            End If
            detalles.RemoveAll(Function(f) True)
            Dim item As LST_DETALLE_DEVOLUCION_COMPRA
            For Each d In v.ComprasDevolucionesDetalles
                item = New LST_DETALLE_DEVOLUCION_COMPRA
                item.IDEXISTENCIA = d.Existencia.IDEXISTENCIA
                item.IDALTERNO = d.Existencia.Producto.IDALTERNO
                item.DESCRIPCION = d.Existencia.Producto.DESCRIPCION
                item.MARCA = If(d.Existencia.Producto.Marca.ACTIVO = "S", d.Existencia.Producto.Marca.DESCRIPCION, "")
                item.UNIDAD_DE_MEDIDA = If(d.Existencia.Producto.UnidadMedida.ACTIVO = "S", d.Existencia.Producto.UnidadMedida.DESCRIPCION, "")
                item.PRESENTACION = If(d.Existencia.Producto.Presentacion.ACTIVO = "S", d.Existencia.Producto.Presentacion.DESCRIPCION, "")
                item.EXISTENCIA = d.EXISTENCIA_PRODUCTO
                item.CANTIDAD = d.CANTIDAD_DEVUELTA
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

    Public Sub LoadInfo(Optional ByVal vInt As CompraDevolucion = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            If txtIdSerie.Text <> "" Then
                If Not ByInt Then
                    Using db As New CodeFirst
                        Dim v = db.ComprasDevoluciones.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                        If Not v Is Nothing Then
                            If v.ANULADO = "N" Then
                                Me.LoadMov(v)
                            Else
                                MessageBox.Show("Devolución de Compra anulada")
                            End If
                            v = Nothing
                        Else
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            txtNDevolucion.Focus()
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

            'Restricción, solo el admin puede anular documentos
            If Not Config.currentUser.Administrador Then 'se evalua si not tiene permiso de administrador

                'mensaje que no puede anular
                Config.MsgErr("Solo el administrador tiene permiso para anular un documento.")

                'si no tiene permiso debe salir
                Exit Sub

            End If
            'Fin

            'Evaluar si desea realmente anular
            If MessageBox.Show("¿Desea anular esta devolución?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

                'Evaluar si hay una devolución seleccionada
                If Not Me.Id.Trim() = "" Then

                    Using db As New CodeFirst

                        'Seleccionando devolución
                        Dim v = db.ComprasDevoluciones.Where(Function(f) f.IDDEVOLUCION = Me.Id And f.ANULADO = "N").FirstOrDefault()

                        'Evaluar si existe la devolución
                        If Not v Is Nothing Then

                            'Validando el período
                            If Config.ValidateLapse(v.FECHADEVOLUCION) Then

                                'Evaluar si la devolución es de al crédito
                                'Registrar la anulación de dinero
                                If v.CREDITO Then
                                    If v.CREDITO And Not v.IDPROVEEDOR Is Nothing Then
                                        If v.MONEDA.Equals(Config.cordoba) Then
                                            v.Proveedor.FACTURADO_C = v.Proveedor.FACTURADO_C + v.TOTAL_C
                                        Else
                                            v.Proveedor.FACTURADO_D = v.Proveedor.FACTURADO_D + v.TOTAL_D
                                        End If
                                        db.Entry(v.Proveedor).State = EntityState.Modified
                                        If v.Compra.MONEDA.Equals(Config.cordoba) Then
                                            v.Compra.SALDOCREDITO = v.Compra.SALDOCREDITO + v.TOTAL_C
                                        Else
                                            v.Compra.SALDOCREDITO = v.Compra.SALDOCREDITO + v.TOTAL_D
                                        End If
                                        db.Entry(v.Compra).State = EntityState.Modified
                                    End If
                                End If

                                'Anular devolución
                                v.ANULADO = "S"
                                db.Entry(v).State = EntityState.Modified

                                'Anular movimientos en estado de cuenta
                                For Each estado In db.ComprasEstadosCuentas.Where(Function(f) f.IDDEVOLUCION = v.IDDEVOLUCION)
                                    estado.ACTIVO = "N"
                                    db.Entry(estado).State = EntityState.Modified
                                Next

                                'Metiendo productos del inventario
                                For Each item In v.ComprasDevolucionesDetalles

                                    item.Existencia.CANTIDAD = item.Existencia.CANTIDAD + item.CANTIDAD_DEVUELTA
                                    item.Existencia.Producto.CANTIDAD = item.Existencia.Producto.CANTIDAD + item.CANTIDAD_DEVUELTA

                                    If item.Existencia.Producto.CANTIDAD = 0 Then
                                        item.Existencia.Producto.SALDO = 0
                                    Else
                                        If item.CMONEDA.Equals(item.Existencia.Producto.CMONEDA) Then
                                            item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO + (item.CANTIDAD_DEVUELTA * item.COSTO)
                                        Else
                                            If item.CMONEDA.Equals(Config.cordoba) Then
                                                item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO + (item.CANTIDAD_DEVUELTA * item.COSTO / Config.exchangeRate)
                                            Else
                                                item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO + (item.CANTIDAD_DEVUELTA * item.COSTO * Config.exchangeRate)
                                            End If
                                        End If
                                    End If

                                    If item.Existencia.Producto.CANTIDAD <> 0 Then
                                        If item.Existencia.Producto.COSTO <> item.COSTO Then
                                            item.Existencia.Producto.COSTO = item.Existencia.Producto.SALDO / item.Existencia.Producto.CANTIDAD
                                        End If
                                    End If

                                    db.Entry(item.Existencia.Producto).State = EntityState.Modified
                                    db.Entry(item.Existencia).State = EntityState.Modified

                                Next

                                'Anulando Kardex
                                Using dbk As New CodeFirst
                                    Dim ik As Boolean = False
                                    For Each kardex In db.Kardexs.Where(Function(f) f.IDSERIE = v.IDSERIE And f.N_DOCUMENTO = txtCodigo.Text)
                                        For Each k In dbk.Kardexs.Where(Function(f) f.N > kardex.N And f.IDEXISTENCIA = kardex.IDEXISTENCIA)
                                            k.EXISTENCIA_ANTERIOR = k.EXISTENCIA_ANTERIOR + kardex.SALIDA
                                            k.EXISTENCIA_ALMACEN = k.EXISTENCIA_ALMACEN + kardex.SALIDA

                                            If k.EXISTENCIA_ALMACEN = 0 Then
                                                k.SALDO = 0
                                            Else
                                                If k.CMONEDA.Equals(kardex.CMONEDA) Then
                                                    k.SALDO = k.SALDO + kardex.HABER
                                                Else
                                                    If kardex.CMONEDA.Equals(Config.cordoba) Then
                                                        k.SALDO = k.SALDO + (kardex.HABER / kardex.TAZACAMBIO)
                                                    Else
                                                        k.SALDO = k.SALDO + (kardex.HABER * kardex.TAZACAMBIO)
                                                    End If
                                                End If
                                            End If

                                            If k.EXISTENCIA_ALMACEN <> 0 Then
                                                k.COSTO_PROMEDIO = k.SALDO / k.EXISTENCIA_ALMACEN
                                            End If

                                            dbk.Entry(k).State = EntityState.Modified
                                            ik = True

                                        Next
                                        kardex.ACTIVO = "N" : db.Entry(kardex).State = EntityState.Modified
                                    Next
                                    If ik Then
                                        dbk.SaveChanges()
                                    End If
                                    db.SaveChanges() : MessageBox.Show("Devolución de Compra Anulada") : limpiar()
                                End Using
                            End If

                            'Se elimina el objeto
                            v = Nothing

                        Else
                            MessageBox.Show("Error, No se encuentra esta devolución. Probablemente ha sido eliminada o anulada.")
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
                    frmBDevolucionCompra.ShowDialog()
                End If
        End Select
    End Sub

    Private Sub txtNProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If txtIdSerie.Text <> "" Then
                    Using db As New CodeFirst
                        If Not txtNCliente.Text.Trim() = "" Then
                            Dim proveedor = db.Proveedores.Where(Function(f) f.N_PROVEEDOR = txtNCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                            If Not proveedor Is Nothing Then
                                txtIdProveedor.Text = proveedor.IDPROVEEDOR
                                txtNombreProveedor.Text = If(proveedor.TIPOPERSONA = "Natural", proveedor.N_PROVEEDOR & " " & proveedor.NOMBRES & " " & proveedor.APELLIDOS & If(proveedor.RAZONSOCIAL.Trim() <> "", " // " & proveedor.N_PROVEEDOR & " " & proveedor.RAZONSOCIAL, ""), proveedor.N_PROVEEDOR & " " & proveedor.RAZONSOCIAL)
                                txtNCliente.Clear()
                                txtObservacion.Focus()
                            Else
                                If MessageBox.Show("Proveedor no registrado. ¿Desea realizar devolución con este nombre?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    txtIdProveedor.Clear()
                                    txtNombreProveedor.Text = txtNCliente.Text
                                    txtNCliente.Clear()
                                    txtObservacion.Focus()
                                End If
                            End If
                            proveedor = Nothing
                        Else
                            If Not txtIdProveedor.Text.Trim = "" Then
                                txtObservacion.Focus()
                            Else
                                frmBuscarProveedor.frm_return = 5 'retornar el valor aqui
                                frmBuscarProveedor.ShowDialog()
                                If Not txtIdProveedor.Text.Trim = "" Then
                                    txtObservacion.Focus()
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

    Private Sub txtIva_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(13) Then
            txtCantidad.Focus()
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

    Private Sub frmNotaDevolucionCompra_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ElGroupBox5.Left = Me.PanelEx3.Width - ElGroupBox5.Width - 7
    End Sub

    Private Sub txtNDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNDevolucion.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If txtNDevolucion.Text.Trim <> "" Then
                    txtNVendedor.Focus()
                Else
                    MessageBox.Show("Ingresar el Nº de Devolución de Compra.")
                End If
            Else
                MessageBox.Show("Error, Seleccione una serie.")
            End If
        End If
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress
        If e.KeyChar = ChrW(13) Then
            btActualizarSerie_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        If MessageBox.Show("¿Imprimir como ticket?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Using db As New CodeFirst
                    Dim devolucion = db.ComprasDevoluciones.Where(Function(f) f.IDDEVOLUCION = Me.Id).FirstOrDefault
                    If Not devolucion Is Nothing Then
                        If devolucion.ANULADO = "N" Then
                            Dim tick As TicketClass = New TicketClass
                            If tick.ImpresoraExistente(Config.PrinterName) Then
                                tick.AnadirLineaCabeza(" DOCUMENTO DE DEVOLUCIÓN DE COMPRA ")
                                tick.AnadirLineaCabeza(Config.businessName)
                                tick.AnadirLineaCabeza("Dir.: " & Config.businessAddress)
                                tick.AnadirLineaCabeza("RUC:  " & Config.businessRUC)
                                tick.AnadirLineaCabeza("Tel.: " & Config.businessPhone1)
                                tick.AnadirLineaCabeza("Fax:  " & Config.businessPhone2)
                                tick.AnadirLineaCabeza(If(devolucion.REIMPRESION.Equals("S"), "****************COPIA***************", "**************ORIGINAL**************"))
                                tick.AnadirLineaSubcabeza("Sucursal: " & devolucion.Serie.Bodega.N_BODEGA & " | " & devolucion.Serie.Bodega.DESCRIPCION)
                                tick.AnadirLineaSubcabeza("Serie: " & devolucion.Serie.NOMBRE)
                                tick.AnadirLineaSubcabeza("No. Requisa: " & devolucion.CONSECUTIVO)
                                tick.AnadirLineaSubcabeza("No. Devolución: " & devolucion.N_DEVOLUCION)
                                tick.AnadirLineaSubcabeza("Fecha: " & DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
                                tick.AnadirLineaSubcabeza("Proveedor: " & If(Not devolucion.IDPROVEEDOR Is Nothing, devolucion.Proveedor.N_PROVEEDOR & " | " & devolucion.Proveedor.NOMBRES & " " & devolucion.Proveedor.APELLIDOS, devolucion.PROVEEDORCONTADO))
                                'tick.AnadirLineaSubcabeza(If(devolucion.CREDITO, "DEVOLUCIÓN DE CRÉDITO", "DEVOLUCIÓN DE CONTADO"))
                                If devolucion.EXONERADO Then
                                    tick.AnadirLineaSubcabeza("DOCUMENTO EXENTO DE IMPUESTO (I.V.A)")
                                End If
                                For Each detalle In From pro In db.Productos Join exi In db.Existencias On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.ComprasDevolucionesDetalles On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Where det.IDDEVOLUCION = devolucion.IDDEVOLUCION Select pro.IDALTERNO, pro.IDORIGINAL, PRODUCTO = pro.DESCRIPCION, pro.MODELO, pro.UnidadMedida, det.CANTIDAD_DEVUELTA, det.PRECIOUNITARIO_C, det.SUBTOTAL_C
                                    tick.AnadirElemento("Nº Producto.:")
                                    tick.AnadirElemento(detalle.IDALTERNO)
                                    tick.AnadirElemento("Descripción:")
                                    tick.AnadirElemento(detalle.PRODUCTO)
                                    tick.AnadirElemento("CANT.: " & detalle.CANTIDAD_DEVUELTA.ToString(Config.f_m))
                                    tick.AnadirElemento("P / U: " & detalle.PRECIOUNITARIO_C.ToString(Config.f_m))
                                    tick.AnadirElemento("TOTAL: " & detalle.SUBTOTAL_C.ToString(Config.f_m))
                                    tick.AnadirElemento("")
                                    tick.PaperHeight = tick.PaperHeight + 80
                                Next
                                tick.AnadirTotal("DESCUENTO", devolucion.DESCUENTO_DIN_C.ToString(Config.f_m))
                                tick.AnadirTotal("SUBTOTAL", devolucion.SUBTOTAL_C.ToString(Config.f_m))
                                tick.AnadirTotal("IVA", devolucion.IVA_DIN_C.ToString(Config.f_m))
                                tick.AnadirTotal("TOTAL", devolucion.TOTAL_C.ToString(Config.f_m))
                                tick.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio

                                '//El metodo AddFooterLine funciona igual que la cabecera 
                                tick.AnadeLineaAlPie("************************************")

                                '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                                '//parametro de tipo string que debe de ser el nombre de la impresora. 
                                tick.ImprimeTicket(Config.PrinterName)
                            Else
                                MessageBox.Show("No se encuentra la impresora '" & Config.PrinterName & "'")
                            End If
                        Else
                            MessageBox.Show("Esta 'Devolución de Compra' esta anulada")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra 'Devolución de Compra' problemente ha sido eliminada.")
                    End If
                    devolucion = Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        Else
            frmImprimirDevolucionCompra.iddevolucion = Me.Id
            frmImprimirDevolucionCompra.ShowDialog()
        End If
    End Sub

    Private Sub rdCordoba_CheckedChanged(sender As Object, e As EventArgs) Handles rdCordoba.CheckedChanged
        If Me.FormLoad Then
            Me.Grid()
        End If
    End Sub

    Private Sub rdDolar_CheckedChanged(sender As Object, e As EventArgs) Handles rdDolar.CheckedChanged
        If Me.FormLoad Then
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
                                frmBuscarEmpleado.frm_return = 14
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
        frmBuscarEmpleado.frm_return = 14
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text.Trim() = "" Then
            txtNCliente.Focus()
        Else
            txtNVendedor.Focus()
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

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If Me.FormLoad Then
            If rdCredito.Checked Then
                If txtIdSerie.Text <> "" Then
                    If txtIdProveedor.Text.Trim() <> "" Then
                        Using db As New CodeFirst
                            Dim p = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtIdProveedor.Text And f.ACTIVO.Equals(Config.vTrue)).FirstOrDefault
                            If Not p Is Nothing Then
                                If p.PLAZO > 0 Then
                                    txtFactura.Focus()
                                    txtFactura.Enabled = True
                                    btBuscarFactura.Enabled = True
                                    txtFactura.Focus()
                                Else
                                    Config.MsgErr("Este proveedor no tiene plazo para crédito.")
                                    rdContado.Checked = True
                                    Exit Sub
                                End If
                            Else
                                Config.MsgErr("No se encuentra este proveedor.")
                            End If
                        End Using
                    Else
                        If rdCredito.Checked Then
                            Config.MsgErr("Seleccione el proveedor.")
                            rdContado.Checked = True
                            frmBuscarProveedor.frm_return = 5 'retornar el valor aqui
                            frmBuscarProveedor.ShowDialog()
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

    Private Sub btBuscarFactura_Click(sender As Object, e As EventArgs) Handles btBuscarFactura.Click
        If txtIdSerie.Text <> "" Then
            If Not txtIdProveedor.Text.Trim() = "" Then
                frmPagosPendientes.Moneda = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                frmPagosPendientes.IdProveedor = txtIdProveedor.Text
                frmPagosPendientes.Frm = 1
                frmPagosPendientes.Taza = txtTazaCambio.Value
                frmPagosPendientes.ShowDialog()
                If Not txtIdFactura.Text.Trim = "" Then
                    txtCodigoAlterno.Focus()
                Else
                    txtFactura.Focus()
                End If
            Else
                Config.MsgErr("Seleccione un proveedor.")
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