Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmEntrada
    'Dim operacion As New TRANSACCION
    Public ID As String = ""
    Dim cod As String = ""

    Sub Limpiar()
        If txtIdSerie.Text <> "" Then
            txtSerie.Enabled = True
            btActualizarSerie.Enabled = True
            txtCodigo.Enabled = True
            txtCodigo.Text = generarCodigo(txtIdSerie.Text)
        End If
        txtConcepto.Clear()
        dtpFecha.Value = DateTime.Now
        txtIdVendedor.Clear()
        txtNVendedor.Clear()
        txtNombreVendedor.Clear()
        lvRegistro.Items.Clear()
        txtTotal.Value = 0
        lblContador.Text = "Nº ITEM: 0"
        btGuardar.Enabled = True : btAnular.Enabled = False : btImprimir.Enabled = False
        txtCodigo.Focus()
    End Sub

    Function generarCodigo(ByVal serie As String) As String
        Try
            Using db As New CodeFirst
                Dim entrada = db.Entradas.Where(Function(f) f.IDSERIE = serie).OrderBy(Function(f) f.CONSECUTIVO).ToList().LastOrDefault()
                If Not entrada Is Nothing Then
                    cod = entrada.CONSECUTIVO
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

    Private Sub frmEntrada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "ProductEntry",
            "Load",
            "Load ProductEntry",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Me.frmEntrada_Resize(Nothing, Nothing)
        Try
            txtCantidad.DisplayFormat = Config.f_c
            txtTotal.DisplayFormat = Config.f_m
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
            txtTotal.Value = 0
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    'Private Sub cmbSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
    '            Using db As New MODELODEDATOS
    '                Dim idserie As String = cmbSerie.SelectedValue.ToString()
    '                Dim serie = db.SERIES.Where(Function(f) f.ACTIVO = "S" And f.IDSERIE = idserie).FirstOrDefault()
    '                If Not serie Is Nothing Then
    '                    txtCodigo.Text = generarCodigo(cmbSerie.SelectedValue.ToString())
    '                    txtReferencia.Text = serie.DESCRIPCION
    '                    txtConcepto.Focus()
    '                End If
    '                serie = Nothing : idserie = Nothing
    '            End Using
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Error, " & ex.Message)
    '    End Try
    'End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Limpiar()
    End Sub

    Private Sub txtCodigoAlterno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoAlterno.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text.Trim <> "" Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Using db As New CodeFirst
                        If db.Productos.Where(Function(f) f.ACTIVO = "S" And f.IDALTERNO = txtCodigoAlterno.Text).Count() > 0 Then
                            txtCantidad.Focus()
                        Else
                            frmBuscarProductos.frm_return = 2 'retornar el valor aqui
                            frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                            frmBuscarProductos.ShowDialog()
                        End If
                    End Using
                Else
                    frmBuscarProductos.frm_return = 2 'retornar el valor aqui
                    frmBuscarProductos.ShowDialog()
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdSerie.Text.Trim <> "" Then
                Try
                    If Not txtCodigoAlterno.Text.Trim = "" And Not txtCantidad.Text.Trim = "" Then
                        ''''''''''''''''''''''''''''''''''''
                        If txtCantidad.Value > 0 Then
                            Using db As New CodeFirst
                                Dim producto = (From prod In db.Productos Join exi In db.Existencias On prod.IDPRODUCTO Equals exi.IDPRODUCTO Where exi.IDBODEGA = Config.warehouseId And prod.IDALTERNO = txtCodigoAlterno.Text Select prod, exi).FirstOrDefault()
                                For i As Integer = 0 To lvRegistro.Items.Count - 1
                                    If txtCodigoAlterno.Text = lvRegistro.Items(i).SubItems(1).Text Then
                                        If Not producto Is Nothing Then
                                            'datos basicos
                                            lvRegistro.Items(i).SubItems(4).Text = producto.exi.CANTIDAD.ToString(Config.f_m)
                                            lvRegistro.Items(i).SubItems(5).Text = Decimal.Parse(txtCantidad.Text).ToString(Config.f_m)
                                            lvRegistro.Items(i).SubItems(6).Text = (producto.prod.COSTO).ToString(Config.f_m)

                                            'descargar precios del total
                                            txtTotal.Value = (txtTotal.Value - Decimal.Parse(lvRegistro.Items(i).SubItems(7).Text)).ToString(Config.f_m)

                                            'actualizo
                                            lvRegistro.Items(i).SubItems(7).Text = (Decimal.Parse(producto.prod.COSTO) * Decimal.Parse(txtCantidad.Text)).ToString(Config.f_m)

                                            'totalizar
                                            txtTotal.Value = (txtTotal.Value + Decimal.Parse(lvRegistro.Items(i).SubItems(7).Text)).ToString(Config.f_m)

                                            'limpiar
                                            txtCodigoAlterno.Clear()
                                            txtCantidad.Value = 1
                                            txtCodigoAlterno.Focus()
                                        Else
                                            MessageBox.Show("Error, No se encuentra este producto. Probablemente alla sido eliminado.")
                                        End If
                                        'salir
                                        Exit Sub
                                    End If
                                Next

                                If Not producto Is Nothing Then
                                    Dim item = lvRegistro.Items.Add(producto.exi.IDEXISTENCIA)
                                    item.SubItems.Add(producto.prod.IDALTERNO)
                                    item.SubItems.Add(producto.prod.IDORIGINAL)
                                    item.SubItems.Add(producto.prod.DESCRIPCION)
                                    item.SubItems.Add(producto.exi.CANTIDAD.ToString(Config.f_m))
                                    item.SubItems.Add(Decimal.Parse(txtCantidad.Text).ToString(Config.f_m))
                                    item.SubItems.Add((producto.prod.COSTO).ToString(Config.f_m))
                                    item.SubItems.Add((producto.prod.COSTO * Decimal.Parse(txtCantidad.Text)).ToString(Config.f_m))

                                    'totalizar
                                    txtTotal.Value = (Decimal.Parse(txtTotal.Value) + Decimal.Parse(item.SubItems(7).Text)).ToString(Config.f_m)

                                    'limpiar
                                    txtCodigoAlterno.Clear()
                                    txtCantidad.Value = 1
                                    lblContador.Text = "Nº ITEM: " & lvRegistro.Items.Count
                                    txtCodigoAlterno.Focus()
                                    item = Nothing
                                Else
                                    MessageBox.Show("Error, no se encuentra ningun producto con este codigo alterno.")
                                End If
                            End Using
                        Else
                            MessageBox.Show("La cantidad no pueden ser negativos.")
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error, " & ex.Message)
                End Try
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub lvRegistro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvRegistro.KeyDown
        If e.KeyCode = Keys.Delete And Not lvRegistro.SelectedItems Is Nothing Then
            'descargar precios del total
            txtTotal.Value = (txtTotal.Value - Decimal.Parse(lvRegistro.SelectedItems(0).SubItems(7).Text)).ToString(Config.f_m)

            'quitar item
            lvRegistro.SelectedItems(0).Remove()
            txtCodigoAlterno.Focus()

            'agregar al contador
            lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count
        ElseIf e.KeyCode = Keys.Enter Then
            lvRegistro_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub lvRegistro_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRegistro.DoubleClick
        If lvRegistro.SelectedItems.Count > 0 Then
            txtCodigoAlterno.Text = lvRegistro.SelectedItems(0).SubItems(1).Text
            txtCantidad.Text = lvRegistro.SelectedItems(0).SubItems(5).Text
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        If Config.ValidateLapse(dtpFecha.Value) Then
            Try
                If txtIdSerie.Text.Trim <> "" And Not txtCodigo.Text.Trim = "" And Not txtConcepto.Text.Trim = "" And lvRegistro.Items.Count > 0 Then
                    Using db As New CodeFirst
                        txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text.Trim)
                        If Not txtCodigo.Text.Trim() = "" Then
                            If dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString() Then
                                dtpFecha.Value = DateTime.Now
                            Else
                                dtpFecha.Value = DateTime.Parse(dtpFecha.Text & " " & DateTime.Now.ToString("HH:mm:ss"))
                            End If
                            Dim v As New Entrada : v.Reg = DateTime.Now : v.IDENTRADA = Guid.NewGuid.ToString() : v.IDSERIE = txtIdSerie.Text : v.CONSECUTIVO = txtCodigo.Text : v.FECHAENTRADA = dtpFecha.Value : v.IDEMPLEADO = txtIdVendedor.Text : v.OBSERVACION = txtConcepto.Text : v.TOTAL = 0 : v.ANULADO = "N" : v.REIMPRESION = "N"
                            db.Entradas.Add(v)

                            Dim idexistencia As String : Dim cont As Integer = 0 : Dim producto As Existencia
                            For i As Integer = 0 To lvRegistro.Items.Count - 1
                                idexistencia = lvRegistro.Items(i).Text
                                producto = db.Existencias.Where(Function(f) f.IDEXISTENCIA = idexistencia And f.Producto.ACTIVO = "S" And f.Bodega.ACTIVO = "S").FirstOrDefault()
                                If Not producto Is Nothing Then
                                    Dim d As New EntradaDetalle : d.IDDETALLEENTRADA = Guid.NewGuid.ToString() : d.EXISTENCIA_PRODUCTO = producto.CANTIDAD : d.CANTIDAD = Decimal.Parse(lvRegistro.Items(i).SubItems(5).Text) : d.CMONEDA = producto.Producto.CMONEDA : d.COSTO = producto.Producto.COSTO : d.TOTAL = d.CANTIDAD * d.COSTO : v.TOTAL = v.TOTAL + d.TOTAL : d.IDEXISTENCIA = producto.IDEXISTENCIA : d.IDENTRADA = v.IDENTRADA : db.EntradasDetalles.Add(d)
                                    Dim k As New Kardex
                                    k.IDKARDEX = Guid.NewGuid.ToString()
                                    k.IDEXISTENCIA = producto.IDEXISTENCIA
                                    k.IDSERIE = txtIdSerie.Text
                                    k.N_DOCUMENTO = txtCodigo.Text
                                    k.FECHADOCUMENTO = dtpFecha.Value
                                    k.OPERACION = "ENTRADA"
                                    k.DESCRIPCION = txtConcepto.Text
                                    k.ENTRADA = d.CANTIDAD
                                    k.SALIDA = 0
                                    k.EXISTENCIA_ANTERIOR = producto.CANTIDAD
                                    producto.CANTIDAD = producto.CANTIDAD + Decimal.Parse(lvRegistro.Items(i).SubItems(5).Text)
                                    db.Entry(producto).State = EntityState.Modified
                                    k.EXISTENCIA_ALMACEN = producto.CANTIDAD
                                    k.CMONEDA = d.CMONEDA
                                    k.TAZACAMBIO = Config.exchangeRate
                                    k.COSTO = d.COSTO
                                    k.COSTO_PROMEDIO = d.COSTO
                                    k.DEBER = d.TOTAL
                                    k.HABER = 0
                                    k.PRECIO_C = 0
                                    k.ACTIVO = "S"
                                    producto.Producto.CANTIDAD = producto.Producto.CANTIDAD + d.CANTIDAD
                                    If producto.Producto.CANTIDAD = 0 Then
                                        k.COSTO_PROMEDIO = producto.Producto.COSTO
                                        producto.Producto.SALDO = 0
                                        k.SALDO = 0
                                    Else
                                        k.COSTO_PROMEDIO = producto.Producto.COSTO
                                        producto.Producto.SALDO = producto.Producto.SALDO + d.TOTAL
                                        If producto.CANTIDAD = 0 Then
                                            k.SALDO = 0
                                        Else
                                            k.SALDO = k.EXISTENCIA_ALMACEN * k.COSTO_PROMEDIO
                                        End If
                                    End If
                                    db.Entry(producto.Producto).State = EntityState.Modified
                                    db.Kardexs.Add(k)
                                    'destruccion
                                    d = Nothing : k = Nothing
                                    'incrementar contador
                                    cont = cont + 1
                                Else
                                    MessageBox.Show("Error, No se encuentra el producto '" & lvRegistro.Items(i).SubItems(1).Text & "'. Probablemente ha sido eliminado.")
                                    Exit Sub
                                End If
                            Next

                            If cont > 0 Then
                                db.SaveChanges()
                                txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
                                btGuardar.Enabled = False : btAnular.Enabled = True : btImprimir.Enabled = True
                                Me.ID = v.IDENTRADA
                            Else
                                MessageBox.Show("Error, No se puede guardar 'Entrada' si detalle.")
                            End If
                            idexistencia = Nothing : cont = Nothing : producto = Nothing : v = Nothing
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
        frmBuscarProductos.frm_return = 2 'retornar el valor aqui
        frmBuscarProductos.ShowDialog()
        txtCodigoAlterno.Focus()
    End Sub

    Private Sub btAgregarProducto_Click(sender As Object, e As EventArgs) Handles btAgregarProducto.Click
        frmProducto.MdiParent = frmPrincipal
        frmProducto.Show()
        frmProducto.BringToFront()
    End Sub

    Private Sub LoadMov(ByVal v As Entrada)
        Try
            Me.ID = v.IDENTRADA
            txtIdSerie.Text = v.IDSERIE
            txtSerie.Text = v.Serie.NOMBRE
            txtCodigo.Text = v.CONSECUTIVO
            txtCodigo.Enabled = False : txtSerie.Enabled = False : btActualizarSerie.Enabled = False
            dtpFecha.Text = v.FECHAENTRADA.ToShortDateString()
            txtConcepto.Text = v.OBSERVACION
            txtIdVendedor.Text = v.Empleado.IDEMPLEADO
            txtNombreVendedor.Text = v.Empleado.N_TRABAJADOR & " | " & v.Empleado.NOMBRES & " " & v.Empleado.APELLIDOS
            Dim item As New ListViewItem
            lvRegistro.Items.Clear()
            For Each detalle In v.EntradasDetalles
                item = lvRegistro.Items.Add(detalle.IDEXISTENCIA)
                item.SubItems.Add(detalle.Existencia.Producto.IDALTERNO)
                item.SubItems.Add(detalle.Existencia.Producto.IDORIGINAL)
                item.SubItems.Add(detalle.Existencia.Producto.DESCRIPCION)
                item.SubItems.Add(detalle.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                item.SubItems.Add(detalle.CANTIDAD.ToString(Config.f_m))
                item.SubItems.Add(detalle.COSTO.ToString(Config.f_m))
                item.SubItems.Add(detalle.TOTAL.ToString(Config.f_m))
            Next
            item = Nothing
            txtTotal.Text = v.TOTAL.ToString(Config.f_m)
            lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()
            btGuardar.Enabled = False
            If Config._lapse.ACTUAL.Equals(Config.vTrue) And Config._lapse.APERTURA IsNot Nothing And Config._lapse.CIERRE Is Nothing Then
                btAnular.Enabled = True
            End If
            btImprimir.Enabled = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub LoadInfo(Optional ByVal vInt As Entrada = Nothing, Optional ByVal ByInt As Boolean = False)
        Try
            Try
                Using db As New CodeFirst
                    If txtIdSerie.Text.Trim <> "" Then
                        If Not ByInt Then
                            Dim v = db.Entradas.Where(Function(f) f.IDSERIE = txtIdSerie.Text And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                            If Not v Is Nothing Then
                                If v.ANULADO = "N" Then
                                    Me.LoadMov(v)
                                Else
                                    MessageBox.Show("Entrada anulada")
                                End If
                            Else
                                txtCodigo.Text = Me.generarCodigo(txtIdSerie.Text)
                                txtNVendedor.Focus()
                            End If
                            v = Nothing
                        Else
                            Me.LoadMov(vInt)
                        End If
                    Else
                        MessageBox.Show("Error, Seleccione la serie")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            Me.LoadInfo()
        End If
    End Sub

    Private Sub txtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConcepto.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            If txtIdSerie.Text <> "" Then
                If Not txtConcepto.Text.Trim() = "" Then
                    txtCodigoAlterno.Focus()
                Else
                    MessageBox.Show("Error, Debe ingresar el concepto")
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub frmEntrada_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                    frmBEntrada.ShowDialog()
                End If
        End Select
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        frmSeleccionarSerie.operacion = "ENTRADA"
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
        frmImprimirEntrada.identrada = Me.ID
        frmImprimirEntrada.ShowDialog()
    End Sub

    Private Sub frmEntrada_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ElGroupBox3.Left = Me.PanelEx3.Width - ElGroupBox3.Width - 7
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
                                frmBuscarEmpleado.frm_return = 17
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
        frmBuscarEmpleado.frm_return = 17
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text.Trim() = "" Then
            txtConcepto.Focus()
        Else
            txtNVendedor.Focus()
        End If
    End Sub

    Private Sub btAnular_Click(sender As Object, e As EventArgs) Handles btAnular.Click
        Try
            If MessageBox.Show("¿Desea anular esta Entrada?", "Pregunta de seguridad", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                If Not Me.ID.Trim() = "" Then
                    Using db As New CodeFirst
                        Dim v = db.Entradas.Where(Function(f) f.IDENTRADA = Me.ID And f.ANULADO = "N").FirstOrDefault()
                        If Not v Is Nothing Then
                            If Config.ValidateLapse(v.FECHAENTRADA) Then
                                v.ANULADO = "S" : db.Entry(v).State = EntityState.Modified

                                For Each item In v.EntradasDetalles
                                    item.Existencia.CANTIDAD = item.Existencia.CANTIDAD - item.CANTIDAD
                                    item.Existencia.Producto.CANTIDAD = item.Existencia.Producto.CANTIDAD - item.CANTIDAD
                                    If item.Existencia.CANTIDAD < 0 Then
                                        If Not item.Existencia.Producto.FACTURAR_NEGATIVO Then
                                            Config.MsgErr("No se puede anular esta Entrada. Ya que la existencia del producto '" & item.Existencia.Producto.IDALTERNO & " - " & item.Existencia.Producto.DESCRIPCION & "' quedaría en negativo.")
                                            Exit Sub
                                        End If
                                    End If
                                    If item.Existencia.Producto.CANTIDAD = 0 Then
                                        item.Existencia.Producto.SALDO = 0
                                    Else
                                        If item.CMONEDA.Equals(item.Existencia.Producto.CMONEDA) Then
                                            item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.COSTO)
                                        Else
                                            If item.CMONEDA.Equals(Config.cordoba) Then
                                                item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.COSTO / Config.exchangeRate)
                                            Else
                                                item.Existencia.Producto.SALDO = item.Existencia.Producto.SALDO - (item.CANTIDAD * item.COSTO * Config.exchangeRate)
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
                                                        k.SALDO = k.SALDO - (kardex.DEBER / Config.exchangeRate)
                                                    Else
                                                        k.SALDO = k.SALDO - (kardex.DEBER * Config.exchangeRate)
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
                                    db.SaveChanges() : MessageBox.Show("Entrada Anulada") : Limpiar()
                                End Using
                            End If
                            v = Nothing
                        Else
                            MessageBox.Show("Error, No se encuentra esta Entrada. Probablemente ha sido eliminada o anulada.")
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Seleccione una Entrada")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
End Class