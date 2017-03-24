Public Class frmConsignacion
    'consignacion seleccionada
    Public idconsignacion As String = ""

    Dim cod As String = ""

    'variables de uso
    Dim sum_consig As Decimal = 0
    Dim sum_desconsig As Decimal = 0

    Sub limpiar()
        Try
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                txtCodigo.Enabled = True
                txtCodigo.Text = Me.generarCodigo(cmbSerie.SelectedValue.ToString())
                dtpFecha.Value = DateTime.Now
                txtIdVendedor.Clear()
                txtNVendedor.Clear()
                txtNombreVendedor.Clear()
                txtIdCliente.Clear()
                txtNCliente.Clear()
                txtNombreCliente.Clear()
                lvRegistro.Items.Clear()
                btGuardar.Enabled = True
                txtCodigo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Function generarCodigo(ByVal serie As String) As String
        Try
            Using db As New CodeFirst
                Dim consignacion = db.Consignaciones.Where(Function(f) f.IDSERIE = serie).OrderBy(Function(f) f.CONSECUTIVO).ToList().LastOrDefault()
                If Not consignacion Is Nothing Then
                    cod = consignacion.CONSECUTIVO
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
    Private Sub frmConsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFecha.Value = DateTime.Now
            Using db As New CodeFirst
                cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "CONSIGNACION").ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1 : txtCodigo.Clear() : cmbSerie.Focus()
                txtReferencia.Clear()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        Try
            Using db As New CodeFirst
                If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                    Dim serie As String = cmbSerie.Text
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "CONSIGNACION").ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1 : txtCodigo.Clear() : cmbSerie.Focus()
                    txtReferencia.Clear()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "CONSIGNACION").ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1 : txtCodigo.Clear() : cmbSerie.Focus()
                    txtReferencia.Clear()
                End If
                txtCodigo.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtNVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNVendedor.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If Not cmbSerie.SelectedValue Is Nothing Then
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
                            frmBuscarEmpleado.frm_return = 8
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

    Private Sub txtNCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                If Not cmbSerie.SelectedValue Is Nothing Then
                    Using db As New CodeFirst
                        If Not txtNCliente.Text.Trim() = "" Then
                            Dim cliente = db.Clientes.Where(Function(f) f.N_CLIENTE = txtNCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                            If Not cliente Is Nothing Then
                                txtIdCliente.Text = cliente.IDCLIENTE
                                txtNombreCliente.Text = cliente.N_CLIENTE & " | " & cliente.NOMBRES & " " & cliente.APELLIDOS
                                txtNCliente.Clear()
                                lvRegistro.Items.Clear()
                                txtCodigoAlterno.Focus()
                            Else
                                MessageBox.Show("Error, Debe ingresar el cliente")
                            End If
                            cliente = Nothing
                        Else
                            frmBuscarClientes.frm_return = 8
                            frmBuscarClientes.ShowDialog()
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

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        Try
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                Using db As New CodeFirst
                    Dim idserie As String = cmbSerie.SelectedValue.ToString()
                    Dim serie = db.Series.Where(Function(f) f.ACTIVO = "S" And f.IDSERIE = idserie).FirstOrDefault()
                    If Not serie Is Nothing Then
                        txtCodigo.Text = Me.generarCodigo(cmbSerie.SelectedValue.ToString())
                        txtReferencia.Text = serie.DESCRIPCION
                        txtCodigo.Focus()
                    End If
                    idserie = Nothing : serie = Nothing
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtCodigoAlterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoAlterno.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                If Not txtCodigoAlterno.Text.Trim = "" Then
                    Using db As New CodeFirst
                        If db.Productos.Where(Function(f) f.ACTIVO = "S" And f.IDALTERNO = txtCodigoAlterno.Text).Count() > 0 Then
                            txtCantidad.Focus()
                        Else
                            frmBuscarProductos.frm_return = 7 'retornar el valor aqui
                            frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                            frmBuscarProductos.ShowDialog()
                        End If
                    End Using
                Else
                    frmBuscarProductos.frm_return = 7 'retornar el valor aqui
                    frmBuscarProductos.ShowDialog()
                End If
            Else
                MessageBox.Show("Error, Seleccione la serie")
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not cmbSerie.SelectedValue Is Nothing Then
                Try
                    If Not txtCodigoAlterno.Text.Trim = "" And Not txtCantidad.Text.Trim = "" Then
                        ''''''''''''''''''''''''''''''''''''
                        If Convert.ToSingle(txtCantidad.Text) > 0 Then
                            Using db As New CodeFirst
                                Dim producto = (From prod In db.Productos Join exi In db.Existencias On prod.IDPRODUCTO Equals exi.IDPRODUCTO Where exi.IDBODEGA = Config.bodega And prod.IDALTERNO = txtCodigoAlterno.Text Select prod, exi).FirstOrDefault()
                                If Not producto Is Nothing Then

                                    Dim consignaciones = From consig In db.Consignaciones Join det In db.ConsignacionesDetalles On consig.IDCONSIGNACION Equals det.IDCONSIGNACION Where consig.ANULADO = "N" And consig.IDCLIENTE = txtIdCliente.Text And det.Existencia.Producto.IDALTERNO = producto.prod.IDALTERNO Select det.CANTIDAD
                                    sum_consig = 0
                                    If Not consignaciones Is Nothing Then
                                        If consignaciones.Count() > 0 Then
                                            sum_consig = consignaciones.Sum()
                                        End If
                                    End If
                                    Dim desconsignaciones = From desconsig In db.Desconsignaciones Join det In db.DesconsignacionesDetalles On desconsig.IDDESCONSIGNACION Equals det.IDDESCONSIGNACION Where desconsig.ANULADO = "N" And desconsig.IDCLIENTE = txtIdCliente.Text And det.Existencia.Producto.IDALTERNO = producto.prod.IDALTERNO Select det.CANTIDAD
                                    sum_desconsig = 0
                                    If Not desconsignaciones Is Nothing Then
                                        If desconsignaciones.Count() > 0 Then
                                            sum_desconsig = desconsignaciones.Sum()
                                        End If
                                    End If

                                    If producto.exi.CANTIDAD - producto.exi.CONSIGNADO >= Decimal.Parse(txtCantidad.Text) Then
                                        For i As Integer = 0 To lvRegistro.Items.Count - 1
                                            If txtCodigoAlterno.Text = lvRegistro.Items(i).SubItems(1).Text Then
                                                'datos basicos
                                                lvRegistro.Items(i).SubItems(3).Text = producto.exi.CANTIDAD.ToString(Config.f_m)
                                                lvRegistro.Items(i).SubItems(4).Text = (producto.exi.CANTIDAD - producto.exi.CONSIGNADO).ToString(Config.f_m)
                                                lvRegistro.Items(i).SubItems(5).Text = (sum_consig - sum_desconsig).ToString(Config.f_m)

                                                'descargar precios del total
                                                txtTotal.Text = (Decimal.Parse(txtTotal.Text) - Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text)).ToString(Config.f_m)

                                                'actualizo
                                                lvRegistro.Items(i).SubItems(6).Text = Decimal.Parse(txtCantidad.Text).ToString(Config.f_m)

                                                'totalizar
                                                txtTotal.Text = (Decimal.Parse(txtTotal.Text) + Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text)).ToString(Config.f_m)

                                                'limpiar
                                                txtCodigoAlterno.Clear()
                                                txtCantidad.Text = Nothing
                                                txtCodigoAlterno.Focus()

                                                'salir
                                                Exit Sub
                                            End If
                                        Next
                                        Dim item As New ListViewItem
                                        item = lvRegistro.Items.Add(producto.exi.IDEXISTENCIA)
                                        item.SubItems.Add(producto.prod.IDALTERNO)
                                        item.SubItems.Add(producto.prod.DESCRIPCION)
                                        item.SubItems.Add(producto.exi.CANTIDAD.ToString(Config.f_m))
                                        item.SubItems.Add((producto.exi.CANTIDAD - producto.exi.CONSIGNADO).ToString(Config.f_m))
                                        item.SubItems.Add((sum_consig - sum_desconsig).ToString(Config.f_m))
                                        item.SubItems.Add(Decimal.Parse(txtCantidad.Text).ToString(Config.f_m))

                                        'totalizar
                                        txtTotal.Text = (Decimal.Parse(txtTotal.Text) + Decimal.Parse(item.SubItems(6).Text)).ToString(Config.f_m)

                                        'limpiar
                                        txtCodigoAlterno.Clear()
                                        txtCantidad.Text = Nothing
                                        txtCodigoAlterno.Focus()

                                        'agregar al contador
                                        lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count

                                        item = Nothing
                                    Else
                                        MessageBox.Show("Error, La cantidad en existencia de la bodega es menor que la solicitada.")
                                    End If
                                Else
                                    MessageBox.Show("Error, no se encuentra ningun producto con este codigo alterno.")
                                End If
                                producto = Nothing
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

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub lvRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles lvRegistro.KeyDown
        If e.KeyCode = Keys.Delete And Not lvRegistro.SelectedItems Is Nothing Then
            'descargar precios del total
            txtTotal.Text = (Decimal.Parse(txtTotal.Text) - Decimal.Parse(lvRegistro.SelectedItems(0).SubItems(6).Text)).ToString(Config.f_m)

            'quitar item
            lvRegistro.SelectedItems(0).Remove()
            txtCodigoAlterno.Focus()

            'agregar al contador
            lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count
        ElseIf e.KeyCode = Keys.Enter Then
            lvRegistro_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub lvRegistro_DoubleClick(sender As Object, e As EventArgs) Handles lvRegistro.DoubleClick
        If lvRegistro.SelectedItems.Count > 0 Then
            txtCodigoAlterno.Text = lvRegistro.SelectedItems(0).SubItems(1).Text
            txtCantidad.Text = lvRegistro.SelectedItems(0).SubItems(6).Text
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Try
            If Not cmbSerie.SelectedValue Is Nothing And Not txtIdVendedor.Text.Trim() = "" And Not txtIdCliente.Text.Trim() = "" And Not lvRegistro.Items.Count = 0 Then
                Using db As New CodeFirst
                    txtCodigo.Text = Me.generarCodigo(cmbSerie.SelectedValue.ToString())
                    If Not txtCodigo.Text.Trim() = "" Then
                        If dtpFecha.Value.ToShortDateString() = DateTime.Now.ToShortDateString() Then
                            dtpFecha.Value = DateTime.Now
                        Else
                            dtpFecha.Value = DateTime.Parse(dtpFecha.Text & " " & DateTime.Now.ToString("HH:mm:ss"))
                        End If
                        Dim consignacion As New Consignacion : consignacion.IDCONSIGNACION = Guid.NewGuid.ToString() : consignacion.IDSERIE = cmbSerie.SelectedValue.ToString() : consignacion.CONSECUTIVO = txtCodigo.Text : consignacion.FECHACONSIGNACION = dtpFecha.Value : consignacion.OBSERVACION = txtConcepto.Text : consignacion.TOTAL = Decimal.Parse(txtTotal.Text) : consignacion.IDCLIENTE = txtIdCliente.Text : consignacion.IDEMPLEADO = txtIdVendedor.Text : consignacion.ANULADO = "N"
                        db.Consignaciones.Add(consignacion)

                        Dim idexistencia As String : Dim cont As Integer = 0 : Dim existencia As Existencia
                        For i As Integer = 0 To lvRegistro.Items.Count - 1
                            idexistencia = lvRegistro.Items(i).Text
                            existencia = db.Existencias.Where(Function(f) f.IDEXISTENCIA = idexistencia And f.Producto.ACTIVO = "S" And f.Bodega.ACTIVO = "S").FirstOrDefault()
                            If Not existencia Is Nothing Then
                                If existencia.CANTIDAD >= Decimal.Parse(lvRegistro.Items(i).SubItems(5).Text) Then
                                    Dim consignaciones = From consig In db.Consignaciones Join det In db.ConsignacionesDetalles On consig.IDCONSIGNACION Equals det.IDCONSIGNACION Where consig.ANULADO = "N" And consig.IDCLIENTE = txtIdCliente.Text And det.Existencia.Producto.IDALTERNO = existencia.Producto.IDALTERNO Select det.CANTIDAD
                                    sum_consig = 0
                                    If Not consignaciones Is Nothing Then
                                        If consignaciones.Count() > 0 Then
                                            sum_consig = consignaciones.Sum()
                                        End If
                                    End If
                                    Dim desconsignaciones = From desconsig In db.Desconsignaciones Join det In db.DesconsignacionesDetalles On desconsig.IDDESCONSIGNACION Equals det.IDDESCONSIGNACION Where desconsig.ANULADO = "N" And desconsig.IDCLIENTE = txtIdCliente.Text And det.Existencia.Producto.IDALTERNO = existencia.Producto.IDALTERNO Select det.CANTIDAD
                                    sum_desconsig = 0
                                    If Not desconsignaciones Is Nothing Then
                                        If desconsignaciones.Count() > 0 Then
                                            sum_desconsig = desconsignaciones.Sum()
                                        End If
                                    End If

                                    Dim detalle As New ConsignacionDetalle : detalle.IDDETALLECONSIGNACION = Guid.NewGuid.ToString() : detalle.EXISTENCIA_PRODUCTO = existencia.CANTIDAD : detalle.EXISTENCIA_SIN_CONSIGNAR = existencia.CANTIDAD - existencia.CONSIGNADO : detalle.EXISTENCIA_CONSIGNADA = sum_consig - sum_desconsig : detalle.CANTIDAD = Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text) : detalle.IDEXISTENCIA = existencia.IDEXISTENCIA : detalle.IDCONSIGNACION = consignacion.IDCONSIGNACION : db.ConsignacionesDetalles.Add(detalle)
                                    existencia.CONSIGNADO = existencia.CONSIGNADO + Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text) : db.Entry(existencia).State = EntityState.Modified
                                    detalle = Nothing

                                    'incrementar contador
                                    cont = cont + 1
                                Else
                                    If MessageBox.Show("Error, La cantidad en existencia de la bodega del producto '" & lvRegistro.Items(i).SubItems(1).Text & "' es menor que la solicitada. ¿Desea cancelar este movimiento?", "Pregunta de seguridad.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        Exit Sub
                                    Else
                                        consignacion.TOTAL = Decimal.Parse(txtTotal.Text) - Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text)
                                    End If
                                End If
                            Else
                                If MessageBox.Show("Error, No se encuentra el producto '" & lvRegistro.Items(i).SubItems(1).Text & "'. Probablemente se elimino o se ha cerrado la conexión a la red. ¿Desea cancelar este movimiento?", "Pregunta de seguridad.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    Exit Sub
                                Else
                                    consignacion.TOTAL = Decimal.Parse(txtTotal.Text) - Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text)
                                End If
                            End If
                        Next

                        If cont > 0 Then
                            db.SaveChanges() : limpiar() : MessageBox.Show("Consignacion guardada")
                        Else
                            MessageBox.Show("Error, No se puede guardar 'Consignacion' si detalle.")
                        End If
                        idexistencia = Nothing : cont = Nothing : existencia = Nothing
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
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If e.KeyChar = ChrW(13) Then
                Try
                    If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                        Using db As New CodeFirst
                            Dim idserie As String = cmbSerie.SelectedValue.ToString()
                            Dim consignacion = db.Consignaciones.Where(Function(f) f.IDSERIE = idserie And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                            If Not consignacion Is Nothing Then
                                If consignacion.ANULADO = "N" Then
                                    Me.idconsignacion = consignacion.IDCONSIGNACION
                                    txtCodigo.Enabled = False
                                    dtpFecha.Text = consignacion.FECHACONSIGNACION.ToShortDateString()
                                    txtIdVendedor.Text = consignacion.Empleados.IDEMPLEADO
                                    txtNombreVendedor.Text = consignacion.Empleados.N_TRABAJADOR & " | " & consignacion.Empleados.NOMBRES & " " & consignacion.Empleados.APELLIDOS
                                    txtIdCliente.Text = consignacion.Cliente.IDCLIENTE
                                    txtNombreCliente.Text = consignacion.Cliente.N_CLIENTE & " | " & consignacion.Cliente.NOMBRES & " " & consignacion.Cliente.APELLIDOS
                                    txtConcepto.Text = consignacion.OBSERVACION

                                    lvRegistro.Items.Clear()
                                    Dim item As New ListViewItem
                                    For Each detalle In From pro In db.Productos Join exi In db.Existencias On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.ConsignacionesDetalles On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Where det.IDCONSIGNACION = consignacion.IDCONSIGNACION Select pro, exi, det
                                        item = lvRegistro.Items.Add(detalle.exi.IDEXISTENCIA)
                                        item.SubItems.Add(detalle.pro.IDALTERNO)
                                        item.SubItems.Add(detalle.pro.DESCRIPCION)
                                        item.SubItems.Add(detalle.det.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                                        item.SubItems.Add((detalle.det.EXISTENCIA_PRODUCTO - detalle.det.EXISTENCIA_CONSIGNADA).ToString(Config.f_m))
                                        item.SubItems.Add(detalle.det.EXISTENCIA_CONSIGNADA.ToString(Config.f_m))
                                        item.SubItems.Add(detalle.det.CANTIDAD.ToString(Config.f_m))
                                    Next
                                    item = Nothing
                                    lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()

                                    txtTotal.Text = consignacion.TOTAL.ToString(Config.f_m)
                                    btGuardar.Enabled = False
                                Else
                                    MessageBox.Show("Consignación anulada")
                                End If
                            Else
                                txtCodigo.Text = Me.generarCodigo(cmbSerie.SelectedValue.ToString())
                                txtNVendedor.Focus()
                            End If
                            idserie = Nothing : consignacion = Nothing
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error, " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub frmConsignacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                txtCodigoAlterno.Focus()
            Case Keys.F2
                txtCantidad.Focus()
            Case Keys.F3
                If txtCodigo.Focused Then
                    If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                        frmBuscarConsignacion.idserie = cmbSerie.SelectedValue.ToString()
                        frmBuscarConsignacion.ShowDialog()
                    Else
                        MessageBox.Show("Error, Seleccione un serie.")
                    End If
                End If
        End Select
    End Sub

    Private Sub frmConsignacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btVendedor_Click(sender As Object, e As EventArgs) Handles btVendedor.Click
        frmBuscarEmpleado.frm_return = 8
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text = "" Then
            txtNCliente.Focus()
        Else
            txtNVendedor.Focus()
        End If
    End Sub

    Private Sub btCliente_Click(sender As Object, e As EventArgs) Handles btCliente.Click
        frmBuscarClientes.frm_return = 8 'retornar el valor aqui
        frmBuscarClientes.ShowDialog()
        If Not txtNCliente.Text = "" Then
            txtCodigoAlterno.Focus()
        Else
            txtNCliente.Focus()
        End If
    End Sub

    Private Sub btAgregarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarVendedor.Click
        frmEmpleado.MdiParent = frmPrincipal
        frmEmpleado.Show()
        frmEmpleado.BringToFront()
    End Sub

    Private Sub btAgregarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAgregarCliente.Click
        frmCliente.MdiParent = frmPrincipal
        frmCliente.Show()
        frmCliente.BringToFront()
    End Sub

    Private Sub btProducto_Click(sender As Object, e As EventArgs) Handles btProducto.Click
        frmBuscarProductos.frm_return = 7 'retornar el valor aqui
        frmBuscarProductos.ShowDialog()
        txtCodigoAlterno.Focus()
    End Sub

    Private Sub btAgregarProducto_Click(sender As Object, e As EventArgs) Handles btAgregarProducto.Click
        frmProducto.MdiParent = frmPrincipal
        frmProducto.Show()
        frmProducto.BringToFront()
    End Sub

    Private Sub txtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConcepto.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            txtCodigoAlterno.Focus()
        End If
    End Sub
End Class