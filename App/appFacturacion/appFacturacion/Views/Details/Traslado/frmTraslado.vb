Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmTraslado
    'Dim operacion As New TRANSACCION
    Public ID As String = ""
    Dim cod As String = ""
    Sub limpiar()
        txtConcepto.Clear()
        If txtIdSerie.Text <> "" Then
            txtSerie.Enabled = True
            btActualizarSerie.Enabled = True
            txtCodigo.Enabled = True
            txtCodigo.Text = generarCodigo(txtIdSerie.Text)
        End If
        txtReferTraslado.Clear()
        dtpFecha.Value = DateTime.Now
        lvRegistro.Items.Clear()
        cmbBodegaSale.Enabled = True
        cmbBodegaSale.SelectedIndex = -1
        txtTotal.Value = 0
        lblContador.Text = "Nº ITEM: 0"
        btGuardar.Enabled = True : btAnular.Enabled = False : btImprimir.Enabled = False
        txtCodigo.Focus()
    End Sub

    Function generarCodigo(ByVal serie As String) As String
        Try
            Using db As New CodeFirst
                Dim traslado = db.Traslados.Where(Function(f) f.IDSERIE = serie).OrderBy(Function(f) f.CONSECUTIVO).ToList().LastOrDefault()
                If Not traslado Is Nothing Then
                    cod = traslado.CONSECUTIVO
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

    Private Sub frmTraslado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "ProductTransfer",
            "Load",
            "Load ProductTransfer",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Me.frmTraslado_Resize(Nothing, Nothing)
        Try
            txtCantidad.DisplayFormat = Config.f_c
            txtTotal.DisplayFormat = Config.f_m
            txtTotal.Value = 0
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
            Using db As New CodeFirst
                'llenar bodegas
                cmbBodegaEntra.DataSource = (From bod In db.Bodegas Where bod.ACTIVO = "S" And bod.IDBODEGA = Config.warehouseId Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodegaEntra.ValueMember = "IDBODEGA" : cmbBodegaEntra.DisplayMember = "DESCRIPCION" : cmbBodegaEntra.Text = Config.warehouseName
                cmbBodegaSale.DataSource = (From bod In db.Bodegas Where bod.ACTIVO = "S" And Not bod.IDBODEGA = Config.warehouseId Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodegaSale.ValueMember = "IDBODEGA" : cmbBodegaSale.DisplayMember = "DESCRIPCION" : cmbBodegaSale.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub txtCodigoAlterno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoAlterno.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Using db As New CodeFirst
                        If db.Productos.Where(Function(f) f.ACTIVO = "S" And f.IDALTERNO = txtCodigoAlterno.Text).Count() > 0 Then
                            txtCantidad.Focus()
                        Else
                            frmBuscarProductos.frm_return = 4 'retornar el valor aqui
                            frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                            frmBuscarProductos.ShowDialog()
                        End If
                    End Using
                Else
                    frmBuscarProductos.frm_return = 4 'retornar el valor aqui
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
                If Not cmbBodegaEntra.SelectedValue Is Nothing And Not cmbBodegaSale.SelectedValue Is Nothing Then
                    Try
                        If Not txtCodigoAlterno.Text.Trim = "" And Not txtCantidad.Text.Trim = "" Then
                            ''''''''''''''''''''''''''''''''''''
                            If txtCantidad.Value >= 0 Then
                                Using db As New CodeFirst
                                    Dim producto = db.Productos.Where(Function(f) f.ACTIVO = "S" And f.IDALTERNO = txtCodigoAlterno.Text).FirstOrDefault()
                                    If Not producto Is Nothing Then
                                        Dim idbodegasale As String = cmbBodegaSale.SelectedValue.ToString()
                                        Dim productosale = producto.Existencias.Where(Function(f) f.IDBODEGA = idbodegasale).FirstOrDefault()
                                        If Not productosale Is Nothing Then
                                            If productosale.CANTIDAD < Decimal.Parse(txtCantidad.Text) Then
                                                If Not productosale.Producto.FACTURAR_NEGATIVO Then
                                                    MessageBox.Show("Error, La cantidad en existencia de la bodega que sale es menor que la solicitada.")
                                                    Exit Sub
                                                End If
                                            End If

                                            For i As Integer = 0 To lvRegistro.Items.Count - 1
                                                If txtCodigoAlterno.Text = lvRegistro.Items(i).SubItems(1).Text Then
                                                    'datos basicos
                                                    lvRegistro.Items(i).SubItems(5).Text = Decimal.Parse(txtCantidad.Text).ToString(Config.f_m)
                                                    lvRegistro.Items(i).SubItems(6).Text = (producto.COSTO).ToString(Config.f_m)

                                                    'descargar precios del total
                                                    txtTotal.Value = txtTotal.Value - Decimal.Parse(lvRegistro.Items(i).SubItems(7).Text)

                                                    'actualizo
                                                    lvRegistro.Items(i).SubItems(7).Text = (producto.COSTO * Decimal.Parse(txtCantidad.Text)).ToString(Config.f_m)

                                                    'totalizar
                                                    txtTotal.Value = txtTotal.Value + Decimal.Parse(lvRegistro.Items(i).SubItems(7).Text)

                                                    'limpiar
                                                    txtCodigoAlterno.Clear()
                                                    txtCantidad.Value = 1
                                                    txtCodigoAlterno.Focus()

                                                    'salir
                                                    Exit Sub
                                                End If
                                            Next
                                            Dim item As New ListViewItem
                                            item = lvRegistro.Items.Add(producto.Existencias.Where(Function(f) f.IDBODEGA = Config.warehouseId).FirstOrDefault().IDEXISTENCIA)
                                            item.SubItems.Add(producto.IDALTERNO)
                                            item.SubItems.Add(producto.IDORIGINAL)
                                            item.SubItems.Add(producto.DESCRIPCION)
                                            item.SubItems.Add(producto.Existencias.Where(Function(f) f.IDBODEGA = Config.warehouseId).FirstOrDefault().CANTIDAD.ToString(Config.f_m))
                                            item.SubItems.Add(Decimal.Parse(txtCantidad.Text).ToString(Config.f_m))
                                            item.SubItems.Add((producto.COSTO).ToString(Config.f_m))
                                            item.SubItems.Add((producto.COSTO * Decimal.Parse(txtCantidad.Text)).ToString(Config.f_m))
                                            item.SubItems.Add(producto.Existencias.Where(Function(f) f.IDBODEGA = idbodegasale).FirstOrDefault().IDEXISTENCIA)

                                            'totalizar
                                            txtTotal.Value = txtTotal.Value + Decimal.Parse(item.SubItems(7).Text)

                                            'bloquear bodega de salida
                                            If lvRegistro.Items.Count > 0 Then
                                                cmbBodegaSale.Enabled = False
                                            End If
                                            item = Nothing
                                            idbodegasale = Nothing

                                            'limpiar
                                            txtCodigoAlterno.Clear()
                                            txtCantidad.Value = 1
                                            txtCodigoAlterno.Focus()

                                            'agregar al contador
                                            lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count
                                        Else
                                            MessageBox.Show("Error, Por alguna razón no existe el producto dentro de la bodega de salida. Contacte con el administrador.")
                                        End If
                                    Else
                                        MessageBox.Show("Error, no se encuentra ningun producto con este codigo alterno.")
                                    End If
                                    producto = Nothing
                                End Using
                            Else
                                MessageBox.Show("El precio y la cantidad no pueden ser negativos.")
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error, " & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Error, Seleccione las bodegas del traslado.")
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub lvRegistro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvRegistro.KeyDown
        If e.KeyCode = Keys.Delete And Not lvRegistro.SelectedItems Is Nothing Then
            'descargar precios del total
            txtTotal.Value = txtTotal.Value - Decimal.Parse(lvRegistro.SelectedItems(0).SubItems(7).Text)

            'quitar item
            lvRegistro.SelectedItems(0).Remove()
            txtCodigoAlterno.Focus()

            'agregar al contador
            lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count

            'bloquear bodega de salida
            If lvRegistro.Items.Count = 0 Then
                cmbBodegaSale.Enabled = True
                cmbBodegaSale.SelectedIndex = -1
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            lvRegistro_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub lvRegistro_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRegistro.DoubleClick
        txtCodigoAlterno.Text = lvRegistro.SelectedItems(0).SubItems(1).Text
        txtCantidad.Text = lvRegistro.SelectedItems(0).SubItems(5).Text
        txtCantidad.Focus()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        If Config.ValidateLapse(dtpFecha.Value) Then
            Try
                If txtIdSerie.Text <> "" And Not txtCodigo.Text.Trim = "" And Not txtConcepto.Text.Trim = "" And lvRegistro.Items.Count > 0 Then
                    Using db As New CodeFirst
                        txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                        If Not txtCodigo.Text.Trim() = "" Then
                            If dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString() Then
                                dtpFecha.Value = DateTime.Now
                            Else
                                dtpFecha.Value = DateTime.Parse(dtpFecha.Text & " " & DateTime.Now.ToString("HH:mm:ss"))
                            End If
                            Dim traslado As New Traslado : traslado.Reg = DateTime.Now : traslado.IDTRASLADO = Guid.NewGuid.ToString() : traslado.IDSERIE = txtIdSerie.Text : traslado.CONSECUTIVO = txtCodigo.Text : traslado.FECHATRASLADO = dtpFecha.Value : traslado.IDEMPLEADO = txtIdVendedor.Text : traslado.IDBODEGA = cmbBodegaSale.SelectedValue.ToString() : traslado.CONCEPTO = txtConcepto.Text : traslado.REFERENCIA = txtReferTraslado.Text : traslado.TOTAL = 0 : traslado.REIMPRESION = Config.vFalse : traslado.ANULADO = Config.vFalse
                            db.Traslados.Add(traslado)

                            Dim idexistencia As String
                            Dim idexistencia_s As String
                            Dim cont As Integer = 0
                            For i As Integer = 0 To lvRegistro.Items.Count - 1
                                idexistencia = lvRegistro.Items(i).Text
                                Dim existencia = db.Existencias.Where(Function(f) f.IDEXISTENCIA = idexistencia And f.Producto.ACTIVO = "S" And f.Bodega.ACTIVO = "S").FirstOrDefault()
                                If Not existencia Is Nothing Then
                                    idexistencia_s = lvRegistro.Items(i).SubItems(8).Text
                                    Dim existencia_s = db.Existencias.Where(Function(f) f.IDEXISTENCIA = idexistencia_s And f.Producto.ACTIVO = "S" And f.Bodega.ACTIVO = "S").FirstOrDefault()
                                    If Not existencia_s Is Nothing Then
                                        If existencia_s.CANTIDAD >= Decimal.Parse(lvRegistro.Items(i).SubItems(5).Text) Then
                                            Dim detalle As New TrasladoDetalle
                                            detalle.IDDETALLETRASLADO = Guid.NewGuid.ToString()
                                            detalle.EXISTENCIA_PRODUCTO = existencia.CANTIDAD
                                            detalle.EXISTENCIAEXTERNA = existencia_s.CANTIDAD
                                            detalle.CANTIDAD = Decimal.Parse(lvRegistro.Items(i).SubItems(5).Text)
                                            detalle.CMONEDA = existencia.Producto.CMONEDA
                                            detalle.COSTO = existencia.Producto.COSTO
                                            detalle.TOTAL = detalle.COSTO * detalle.CANTIDAD
                                            traslado.TOTAL = traslado.TOTAL + detalle.TOTAL
                                            detalle.IDEXISTENCIA = existencia.IDEXISTENCIA
                                            detalle.IDTRASLADO = traslado.IDTRASLADO
                                            db.TrasladosDetalles.Add(detalle)

                                            Dim kardex As New Kardex
                                            kardex.IDKARDEX = Guid.NewGuid.ToString()
                                            kardex.IDEXISTENCIA = existencia.IDEXISTENCIA
                                            kardex.IDSERIE = txtIdSerie.Text
                                            kardex.N_DOCUMENTO = txtCodigo.Text
                                            kardex.FECHADOCUMENTO = dtpFecha.Value
                                            kardex.OPERACION = "TRASLADO"
                                            kardex.DESCRIPCION = txtReferTraslado.Text
                                            kardex.TAZACAMBIO = Config.exchangeRate
                                            kardex.ENTRADA = detalle.CANTIDAD
                                            kardex.SALIDA = 0
                                            kardex.EXISTENCIA_ANTERIOR = existencia.CANTIDAD
                                            existencia.CANTIDAD = existencia.CANTIDAD + Decimal.Parse(lvRegistro.Items(i).SubItems(5).Text)
                                            db.Entry(existencia).State = EntityState.Modified
                                            kardex.EXISTENCIA_ALMACEN = existencia.CANTIDAD
                                            kardex.CMONEDA = detalle.CMONEDA
                                            kardex.COSTO = detalle.COSTO
                                            kardex.DEBER = detalle.TOTAL
                                            kardex.HABER = 0
                                            kardex.PRECIO_C = 0
                                            kardex.COSTO_PROMEDIO = existencia.Producto.COSTO
                                            If existencia.CANTIDAD = 0 Then
                                                kardex.SALDO = 0
                                            Else
                                                kardex.SALDO = kardex.EXISTENCIA_ALMACEN * kardex.COSTO_PROMEDIO
                                            End If
                                            kardex.ACTIVO = "S"
                                            db.Kardexs.Add(kardex)

                                            Dim kardex_s As New Kardex
                                            kardex_s.IDKARDEX = Guid.NewGuid.ToString()
                                            kardex_s.IDEXISTENCIA = existencia_s.IDEXISTENCIA
                                            kardex_s.IDSERIE = txtIdSerie.Text
                                            kardex_s.N_DOCUMENTO = txtCodigo.Text
                                            kardex_s.FECHADOCUMENTO = dtpFecha.Value
                                            kardex_s.OPERACION = "TRASLADO"
                                            kardex_s.DESCRIPCION = txtReferTraslado.Text
                                            kardex_s.TAZACAMBIO = Config.exchangeRate
                                            kardex_s.ENTRADA = 0
                                            kardex_s.SALIDA = detalle.CANTIDAD
                                            kardex_s.EXISTENCIA_ANTERIOR = existencia_s.CANTIDAD
                                            existencia_s.CANTIDAD = existencia_s.CANTIDAD - Decimal.Parse(lvRegistro.Items(i).SubItems(5).Text) : db.Entry(existencia_s).State = EntityState.Modified
                                            kardex_s.EXISTENCIA_ALMACEN = existencia_s.CANTIDAD
                                            kardex_s.CMONEDA = detalle.CMONEDA
                                            kardex_s.COSTO = detalle.COSTO
                                            kardex_s.DEBER = 0
                                            kardex_s.HABER = detalle.TOTAL
                                            kardex_s.PRECIO_C = 0
                                            kardex_s.COSTO_PROMEDIO = existencia.Producto.COSTO
                                            kardex_s.SALDO = kardex_s.EXISTENCIA_ALMACEN * kardex_s.COSTO_PROMEDIO
                                            If existencia_s.CANTIDAD = 0 Then
                                                kardex_s.SALDO = 0
                                            Else
                                                kardex_s.SALDO = kardex_s.EXISTENCIA_ALMACEN * kardex_s.COSTO_PROMEDIO
                                            End If
                                            kardex_s.ACTIVO = "S"

                                            If existencia_s.CANTIDAD < 0 Then
                                                If Not existencia_s.Producto.FACTURAR_NEGATIVO Then
                                                    Config.MsgErr("No se puede guardar esta Salida. Ya que la existencia del producto '" & existencia_s.Producto.IDALTERNO & " - " & existencia_s.Producto.DESCRIPCION & "' quedaría en negativo.")
                                                    Exit Sub
                                                End If
                                            End If
                                            db.Kardexs.Add(kardex_s)

                                            'destruccion
                                            detalle = Nothing : kardex = Nothing : kardex_s = Nothing

                                            'incrementar contador
                                            cont = cont + 1
                                        Else
                                            MessageBox.Show("Error, La cantidad en existencia de la bodega que sale del producto '" & lvRegistro.Items(i).SubItems(1).Text & "' es menor que la solicitada.")
                                            Exit Sub
                                        End If
                                    Else
                                        MessageBox.Show("Error, No se encuentra el producto '" & lvRegistro.Items(i).SubItems(1).Text & "' en la bódega que sale. Probablemente ha sido eliminado.")
                                    End If
                                    existencia_s = Nothing
                                Else
                                    MessageBox.Show("Error, No se encuentra el producto '" & lvRegistro.Items(i).SubItems(1).Text & "'. Probablemente ha sido eliminado.")
                                    Exit Sub
                                End If
                                existencia = Nothing
                            Next
                            idexistencia = Nothing
                            idexistencia_s = Nothing

                            If cont > 0 Then
                                db.SaveChanges()
                                txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
                                btGuardar.Enabled = False : btAnular.Enabled = True : btImprimir.Enabled = True
                                Me.ID = traslado.IDTRASLADO
                            Else
                                MessageBox.Show("Error, No se puede guardar 'Traslado' si detalle.")
                            End If
                            cont = Nothing : traslado = Nothing
                        Else
                            MessageBox.Show("Error, No se ha podido generar el nuevo código. Intente mas tarde, si el problema persiste contacte con el administrador.")
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Debe ingresar Serie, N° Dococumento, Concepto, Lista de Productos.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProducto.Click
        frmBuscarProductos.frm_return = 4 'retornar el valor aqui
        frmBuscarProductos.ShowDialog()
        txtCodigoAlterno.Focus()
    End Sub

    Private Sub cmbBodegaSale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBodegaSale.SelectedIndexChanged
        txtCodigoAlterno.Focus()
    End Sub

    Private Sub txtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConcepto.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            If txtIdSerie.Text <> "" Then
                If Not txtConcepto.Text.Trim() = "" Then
                    txtReferTraslado.Focus()
                Else
                    MessageBox.Show("Error, Debe ingresar el concepto")
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub txtReferTraslado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferTraslado.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text <> "" Then
                If Not txtReferTraslado.Text.Trim() = "" Then
                    cmbBodegaSale.Focus()
                Else
                    MessageBox.Show("Error, Debe ingresar el concepto")
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub btAgregarProducto_Click(sender As Object, e As EventArgs) Handles btAgregarProducto.Click
        frmProducto.MdiParent = frmPrincipal
        frmProducto.Show()
        frmProducto.BringToFront()
    End Sub

    Private Sub LoadMov(ByVal v As Traslado)
        Try
            Me.ID = v.IDTRASLADO
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            txtCodigo.Enabled = False
            dtpFecha.Text = v.FECHATRASLADO.ToShortDateString()
            txtIdVendedor.Text = v.Empleado.IDEMPLEADO
            txtNombreVendedor.Text = v.Empleado.N_TRABAJADOR & " | " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS
            txtConcepto.Text = v.CONCEPTO
            txtReferTraslado.Text = v.REFERENCIA
            cmbBodegaSale.Text = v.Bodega.N_BODEGA & " | " & v.Bodega.DESCRIPCION
            cmbBodegaSale.Enabled = False
            cmbBodegaEntra.Text = v.TrasladosDetalles.FirstOrDefault().Existencia.Bodega.N_BODEGA & " | " & v.TrasladosDetalles.FirstOrDefault().Existencia.Bodega.DESCRIPCION
            Dim item As New ListViewItem
            lvRegistro.Items.Clear()
            For Each detalle In v.TrasladosDetalles
                item = lvRegistro.Items.Add(detalle.IDEXISTENCIA)
                item.SubItems.Add(detalle.Existencia.Producto.IDALTERNO)
                item.SubItems.Add(detalle.Existencia.Producto.IDORIGINAL)
                item.SubItems.Add(detalle.Existencia.Producto.DESCRIPCION)
                item.SubItems.Add(detalle.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                item.SubItems.Add(detalle.CANTIDAD.ToString(Config.f_m))
                item.SubItems.Add(detalle.COSTO.ToString(Config.f_m))
                item.SubItems.Add(detalle.TOTAL.ToString(Config.f_m))
                item.SubItems.Add("")
            Next
            item = Nothing
            txtTotal.Text = v.TOTAL.ToString(Config.f_m)
            lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()
            btGuardar.Enabled = False
            btAnular.Enabled = True
            btImprimir.Enabled = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub LoadInfo(Optional ByVal vInt As Traslado = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            If Not ByInt Then
                Using db As New CodeFirst
                    If txtIdSerie.Text <> "" Then
                        Dim v = db.Traslados.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                        If Not v Is Nothing Then
                            If v.ANULADO = "N" Then
                                Me.LoadMov(v)
                            Else
                                MessageBox.Show("Traslado anulada")
                            End If
                        Else
                            txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                            txtNVendedor.Focus()
                        End If
                    Else
                        MessageBox.Show("Error, Seleccione la serie")
                    End If
                End Using
            Else
                Me.LoadMov(vInt)
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

    Private Sub frmTraslado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
            Case Keys.F3
                If txtCodigo.Focused Then
                    If txtIdSerie.Text <> "" Then
                        frmBTraslado.ShowDialog()
                        'frmBuscarTraslado.idserie = cmbSerie.SelectedValue.ToString()
                        'frmBuscarTraslado.ShowDialog()
                    Else
                        MessageBox.Show("Error, Seleccione un serie.")
                    End If
                End If
        End Select
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        frmSeleccionarSerie.operacion = "TRASLADO"
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

    Private Sub btActualizarBodegaEntra_Click(sender As Object, e As EventArgs) Handles btActualizarBodegaEntra.Click
        Try
            If txtIdSerie.Text <> "" Then
                Using db As New CodeFirst
                    'llenar bodegas
                    cmbBodegaEntra.DataSource = (From bod In db.Bodegas Where bod.ACTIVO = "S" And bod.IDBODEGA = Config.warehouseId Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodegaEntra.ValueMember = "IDBODEGA" : cmbBodegaEntra.DisplayMember = "DESCRIPCION" : cmbBodegaEntra.Text = Config.warehouseName
                End Using
                cmbBodegaEntra.Focus()
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btActualizarBodegaSale_Click(sender As Object, e As EventArgs) Handles btActualizarBodegaSale.Click
        Try
            If txtIdSerie.Text <> "" Then
                Using db As New CodeFirst
                    'llenar bodegas
                    cmbBodegaSale.DataSource = (From bod In db.Bodegas Where bod.ACTIVO = "S" And Not bod.IDBODEGA = Config.warehouseId Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodegaSale.ValueMember = "IDBODEGA" : cmbBodegaSale.DisplayMember = "DESCRIPCION" : cmbBodegaSale.SelectedIndex = -1
                End Using
                cmbBodegaSale.Focus()
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If

        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        frmImprimirTraslado.ID = Me.ID
        frmImprimirTraslado.ShowDialog()
    End Sub

    Private Sub cmbBodegaEntra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodegaEntra.SelectedIndexChanged
        cmbBodegaSale.Focus()
    End Sub

    Private Sub frmTraslado_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ElGroupBox3.Left = Me.PanelEx1.Width - ElGroupBox3.Width - 7
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress
        If e.KeyChar = ChrW(13) Then
            btActualizarSerie_Click(Nothing, Nothing)
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
                                txtConcepto.Focus()
                            Else
                                MessageBox.Show("Error, Debe ingresar un 'Inventarista'")
                            End If
                            vendedor = Nothing
                        Else
                            If Not txtIdVendedor.Text.Trim = "" Then
                                txtConcepto.Focus()
                            Else
                                frmBuscarEmpleado.LaborPre = 3
                                frmBuscarEmpleado.frm_return = 19
                                frmBuscarEmpleado.ShowDialog()
                                If Not txtIdVendedor.Text.Trim = "" Then
                                    txtConcepto.Focus()
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
        frmBuscarEmpleado.LaborPre = 3
        frmBuscarEmpleado.frm_return = 19
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text.Trim() = "" Then
            txtConcepto.Focus()
        Else
            txtNVendedor.Focus()
        End If
    End Sub

    Private Sub btAnular_Click(sender As Object, e As EventArgs) Handles btAnular.Click
        Try
            If MessageBox.Show("¿Desea anular este Traslado?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                If Not Me.ID.Trim() = "" Then
                    Using db As New CodeFirst
                        Dim v = db.Traslados.Where(Function(f) f.IDTRASLADO = Me.ID And f.ANULADO = "N").FirstOrDefault()
                        If Not v Is Nothing Then
                            If Config.ValidateLapse(v.FECHATRASLADO) Then
                                v.ANULADO = "S" : db.Entry(v).State = EntityState.Modified

                                'For Each item In v.TrasladosDetalles
                                '    Dim ExiS = db.Existencias.Where(Function(f) f.IDBODEGA = v.IDBODEGA And f.IDPRODUCTO = item.Existencia.IDPRODUCTO).FirstOrDefault
                                '    If ExiS Is Nothing Then
                                '        Config.MsgErr("No se puede anular este Traslado por que no se encuentra el producto '" & item.Existencia.Producto.IDALTERNO & " - " & item.Existencia.Producto.DESCRIPCION & "' no se encuentra en la bodega que salio.")
                                '        Exit Sub
                                '    End If

                                '    item.Existencia.CANTIDAD = item.Existencia.CANTIDAD - item.CANTIDAD
                                '    If item.Existencia.CANTIDAD < 0 Then
                                '        If Not item.Existencia.Producto.FACTURAR_NEGATIVO Then
                                '            Config.MsgErr("No se puede anular esta Traslado. Ya que la existencia del producto '" & item.Existencia.Producto.IDALTERNO & " - " & item.Existencia.Producto.DESCRIPCION & "' quedaría en negativo.")
                                '            Exit Sub
                                '        End If
                                '    End If

                                '    db.Entry(item.Existencia).State = EntityState.Modified
                                '    ExiS.CANTIDAD = ExiS.CANTIDAD + item.CANTIDAD
                                '    db.Entry(ExiS).State = EntityState.Modified
                                'Next

                                'Using db_a As New CodeFirst
                                '    Dim band As Boolean = False
                                '    Using db_exi As New CodeFirst
                                '        For Each kardex In db.Kardexs.Where(Function(f) f.IDSERIE = v.IDSERIE And f.N_DOCUMENTO = txtCodigo.Text)
                                '            For Each k In db_a.Kardexs.Where(Function(f) f.N > kardex.N And f.Existencia.IDPRODUCTO = kardex.Existencia.IDPRODUCTO)
                                '                Dim s = db_exi.Series.Where(Function(f) f.IDSERIE = k.IDSERIE).FirstOrDefault
                                '                Dim ExiS = db_exi.Existencias.Where(Function(f) f.IDEXISTENCIA = k.IDEXISTENCIA).FirstOrDefault

                                '                If ExiS.IDBODEGA = s.IDBODEGA Then
                                '                    k.EXISTENCIA_ANTERIOR = k.EXISTENCIA_ANTERIOR - kardex.ENTRADA
                                '                    k.EXISTENCIA_ALMACEN = k.EXISTENCIA_ALMACEN - kardex.ENTRADA

                                '                    If k.EXISTENCIA_ALMACEN = 0 Then
                                '                        k.SALDO = 0
                                '                    Else
                                '                        If k.CMONEDA.Equals(kardex.CMONEDA) Then
                                '                            k.SALDO = k.SALDO - kardex.DEBER
                                '                        Else
                                '                            If kardex.CMONEDA.Equals(Config.cordoba) Then
                                '                                k.SALDO = k.SALDO - (kardex.DEBER / Config.exchangeRate)
                                '                            Else
                                '                                k.SALDO = k.SALDO - (kardex.DEBER * Config.exchangeRate)
                                '                            End If
                                '                        End If
                                '                    End If
                                '                ElseIf ExiS.IDBODEGA = v.IDBODEGA Then
                                '                    k.EXISTENCIA_ANTERIOR = k.EXISTENCIA_ANTERIOR + kardex.SALIDA
                                '                    k.EXISTENCIA_ALMACEN = k.EXISTENCIA_ALMACEN + kardex.SALIDA

                                '                    If k.EXISTENCIA_ALMACEN = 0 Then
                                '                        k.SALDO = 0
                                '                    Else
                                '                        If k.CMONEDA.Equals(kardex.CMONEDA) Then
                                '                            k.SALDO = k.SALDO + kardex.HABER
                                '                        Else
                                '                            If kardex.CMONEDA.Equals(Config.cordoba) Then
                                '                                k.SALDO = k.SALDO + (kardex.HABER / Config.exchangeRate)
                                '                            Else
                                '                                k.SALDO = k.SALDO + (kardex.HABER * Config.exchangeRate)
                                '                            End If
                                '                        End If
                                '                    End If
                                '                End If


                                '                db_a.Entry(k).State = EntityState.Modified
                                '                band = True
                                '            Next
                                '            kardex.ACTIVO = "N" : db.Entry(kardex).State = EntityState.Modified
                                '        Next
                                '    End Using

                                '    If band Then
                                '        db_a.SaveChanges()
                                '    End If
                                '    db.SaveChanges() : MessageBox.Show("Traslado Anulada") : limpiar()
                                'End Using


                                'Recorrer listado de productos de kardexs de esta Entrada
                                For Each kardexItemForThisTransfer In db.Kardexs.Where(Function(f) f.IDSERIE = v.IDSERIE And f.N_DOCUMENTO = txtCodigo.Text).ToList()

                                    'acumuladores de costos
                                    Dim accumulatedCostToDebit = 0, accumulatedCostToAcredit As Decimal = 0

                                    'item actual
                                    Dim kardexSelectedForThisTransfer = db.Kardexs.Where(Function(f) f.IDKARDEX = kardexItemForThisTransfer.IDKARDEX).Include(Function(f) f.Existencia).First()

                                    Dim postKardexs = db.Kardexs.Where(Function(f) f.N > kardexSelectedForThisTransfer.N And f.IDEXISTENCIA = kardexSelectedForThisTransfer.IDEXISTENCIA).OrderBy(Function(f) f.N).ToList()

                                    For Each postItemKardex In postKardexs

                                        Dim currentPostItemKardex = db.Kardexs.Where(Function(f) f.IDKARDEX = postItemKardex.IDKARDEX).FirstOrDefault()

                                        If kardexSelectedForThisTransfer.ENTRADA > 0 Then

                                            currentPostItemKardex.EXISTENCIA_ANTERIOR = currentPostItemKardex.EXISTENCIA_ANTERIOR - kardexSelectedForThisTransfer.ENTRADA
                                            currentPostItemKardex.EXISTENCIA_ALMACEN = currentPostItemKardex.EXISTENCIA_ALMACEN - kardexSelectedForThisTransfer.ENTRADA

                                        Else

                                            currentPostItemKardex.EXISTENCIA_ANTERIOR = currentPostItemKardex.EXISTENCIA_ANTERIOR + kardexSelectedForThisTransfer.SALIDA
                                            currentPostItemKardex.EXISTENCIA_ALMACEN = currentPostItemKardex.EXISTENCIA_ALMACEN + kardexSelectedForThisTransfer.SALIDA

                                        End If

                                        'Recalculando Costo
                                        Sadara.BusinessLayer.Inventory.Instance.CurrencyOfProducts = Config.currentBusiness.MonedaInventario
                                        Sadara.BusinessLayer.Inventory.Instance.RecalculateCostByNullification(
                                            currentPostItemKardex,
                                            kardexSelectedForThisTransfer,
                                            db,
                                            accumulatedCostToDebit,
                                            accumulatedCostToAcredit
                                        )
                                        'Fin Recalcular Costo







                                        db.Entry(currentPostItemKardex).State = EntityState.Modified

                                    Next

                                    Dim productForKardexItem = kardexSelectedForThisTransfer.Existencia.Producto

                                    productForKardexItem.SALDO += (accumulatedCostToDebit - accumulatedCostToAcredit)

                                    kardexSelectedForThisTransfer.ACTIVO = "N"

                                    db.Entry(kardexSelectedForThisTransfer).State = EntityState.Modified

                                Next



                                'Costo General
                                'Sacando productos del inventario
                                For Each transfer In v.TrasladosDetalles.ToList()

                                    'Obteniendo objeto DetalleTraslado
                                    Dim item = db.TrasladosDetalles.Find(transfer.IDDETALLETRASLADO)

                                    'Obteniendo objeto Existencia de la bodega donde salió el producto
                                    Dim itemReturn = db.Existencias.Where(Function(f) f.IDBODEGA = v.IDBODEGA And f.IDPRODUCTO = item.Existencia.IDPRODUCTO).FirstOrDefault()

                                    'Validando que el objeto Existencia en bodega anterior sea válido
                                    If itemReturn Is Nothing Then
                                        Config.MsgErr("No se puede anular este Traslado por que no se encuentra el producto '" & item.Existencia.Producto.IDALTERNO & " - " & item.Existencia.Producto.DESCRIPCION & "' no se encuentra en la bodega que salio.")
                                        Exit Sub
                                    End If

                                    'Quitando existencia de la bodega a la que había ingresado
                                    item.Existencia.CANTIDAD = item.Existencia.CANTIDAD - item.CANTIDAD

                                    'Validando si puede quedar en negativo
                                    If item.Existencia.CANTIDAD < 0 Then
                                        If Not item.Existencia.Producto.FACTURAR_NEGATIVO Then
                                            Config.MsgErr("No se puede anular este Traslado. Ya que la existencia del producto '" & item.Existencia.Producto.IDALTERNO & " - " & item.Existencia.Producto.DESCRIPCION & "' quedaría en negativo.")
                                            Exit Sub
                                        End If
                                    End If

                                    db.Entry(item.Existencia.Producto).State = EntityState.Modified
                                    db.Entry(item).State = EntityState.Modified

                                Next
                                'Final Costo General


                                db.SaveChanges()
                                MessageBox.Show("Traslado Anulado")
                                limpiar()






                            End If

                            v = Nothing

                        Else
                            MessageBox.Show("Error, No se encuentra esta Traslado. Probablemente ha sido eliminada o anulada.")
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Seleccione una Traslado.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
End Class