Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmDesconsignacion
    'consignacion seleccionada
    Public iddesconsignacion As String = ""

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
                Dim desconsignacion = db.Desconsignaciones.Where(Function(f) f.IDSERIE = serie).OrderBy(Function(f) f.CONSECUTIVO).ToList().LastOrDefault()
                If Not desconsignacion Is Nothing Then
                    cod = desconsignacion.CONSECUTIVO
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

    Private Sub frmDesconsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFecha.Value = DateTime.Now
            Using db As New CodeFirst
                cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "DESCONSIGNACION").ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1 : txtCodigo.Clear() : cmbSerie.Focus()
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
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "DESCONSIGNACION").ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1 : txtCodigo.Clear() : cmbSerie.Focus()
                    txtReferencia.Clear()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "DESCONSIGNACION").ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1 : txtCodigo.Clear() : cmbSerie.Focus()
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
                            frmBuscarEmpleado.frm_return = 9
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
                            frmBuscarClientes.frm_return = 9
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
                            frmBuscarProductos.frm_return = 8 'retornar el valor aqui
                            frmBuscarProductos.txtIdAlterno.Text = txtCodigoAlterno.Text
                            frmBuscarProductos.ShowDialog()
                        End If
                    End Using
                Else
                    frmBuscarProductos.frm_return = 8 'retornar el valor aqui
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
                        If Convert.ToSingle(txtCantidad.Text) >= 0 Then
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

                                    If sum_consig - sum_desconsig >= txtCantidad.Value Then
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
                                        MessageBox.Show("Error, La cantidad consignada de este producto a este cliente es menor que la solicitada.")
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

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If Not cmbSerie.SelectedValue Is Nothing And Not txtIdVendedor.Text.Trim() = "" And Not txtIdCliente.Text.Trim() = "" And Not lvRegistro.Items.Count = 0 Then
                Using db As New CodeFirst
                    txtCodigo.Text = Me.generarCodigo(cmbSerie.SelectedValue.ToString())
                    If Not txtCodigo.Text.Trim() Then
                        Dim desconsignacion As New Desconsignacion : desconsignacion.IDDESCONSIGNACION = Guid.NewGuid.ToString() : desconsignacion.IDSERIE = cmbSerie.SelectedValue.ToString() : desconsignacion.CONSECUTIVO = txtCodigo.Text : desconsignacion.FECHACONSIGNACION = dtpFecha.Value : desconsignacion.OBSERVACION = txtConcepto.Text : desconsignacion.TOTAL = Decimal.Parse(txtTotal.Text) : desconsignacion.IDCLIENTE = txtIdCliente.Text : desconsignacion.IDEMPLEADO = txtIdVendedor.Text : desconsignacion.ANULADO = "N"
                        db.Desconsignaciones.Add(desconsignacion)

                        Dim idexistencia As String : Dim cont As Integer = 0 : Dim existencia As Existencia
                        For i As Integer = 0 To lvRegistro.Items.Count - 1
                            idexistencia = lvRegistro.Items(i).Text
                            existencia = db.Existencias.Where(Function(f) f.IDEXISTENCIA = idexistencia And f.Producto.ACTIVO = "S" And f.Bodega.ACTIVO = "S").FirstOrDefault()
                            If Not existencia Is Nothing Then
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
                                If sum_consig - sum_desconsig >= Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text) Then
                                    Dim detalle As New DesconsignacionDetalle : detalle.IDDETALLEDESCONSIGNACION = Guid.NewGuid.ToString() : detalle.EXISTENCIA_PRODUCTO = existencia.CANTIDAD : detalle.EXISTENCIA_SIN_CONSIGNAR = existencia.CANTIDAD - existencia.CONSIGNADO : detalle.EXISTENCIA_CONSIGNADA = sum_consig - sum_desconsig : detalle.CANTIDAD = Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text) : detalle.IDEXISTENCIA = existencia.IDEXISTENCIA : detalle.IDDESCONSIGNACION = desconsignacion.IDDESCONSIGNACION : db.DesconsignacionesDetalles.Add(detalle)
                                    existencia.CONSIGNADO = existencia.CONSIGNADO - Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text) : db.Entry(existencia).State = EntityState.Modified
                                    detalle = Nothing

                                    'incrementar contador
                                    cont = cont + 1
                                Else
                                    MessageBox.Show("Error, La cantidad consignada del producto '" & lvRegistro.Items(i).SubItems(1).Text & "' a este cliente es menor que la solicitada.")
                                    txtTotal.Text = (Decimal.Parse(txtTotal.Text) - Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text)).ToString(Config.f_m)
                                End If
                            Else
                                If MessageBox.Show("Error, No se encuentra el producto '" & lvRegistro.Items(i).SubItems(1).Text & "'. Probablemente se elimino o se ha cerrado la conexión a la red. ¿Desea cancelar este movimiento?", "Pregunta de seguridad.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    Exit Sub
                                Else
                                    desconsignacion.TOTAL = Decimal.Parse(txtTotal.Text) - Decimal.Parse(lvRegistro.Items(i).SubItems(6).Text)
                                End If
                            End If
                        Next

                        If cont > 0 Then
                            db.SaveChanges() : limpiar() : MessageBox.Show("Desconsignacion guardada")
                        Else
                            MessageBox.Show("Error, No se puede guardar 'Desconsignacion' si detalle.")
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

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub lvRegistro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvRegistro.KeyDown
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

    Private Sub lvRegistro_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRegistro.DoubleClick
        If lvRegistro.SelectedItems.Count > 0 Then
            txtCodigoAlterno.Text = lvRegistro.SelectedItems(0).SubItems(1).Text
            txtCantidad.Text = lvRegistro.SelectedItems(0).SubItems(6).Text
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub frmDesconsignacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                txtCodigoAlterno.Focus()
            Case Keys.F2
                txtCantidad.Focus()
            Case Keys.F3
                If txtCodigo.Focused Then
                    If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                        frmBuscarDesconsignacion.idserie = cmbSerie.SelectedValue.ToString()
                        frmBuscarDesconsignacion.ShowDialog()
                    Else
                        MessageBox.Show("Error, Seleccione un serie.")
                    End If
                End If
        End Select
    End Sub

    Private Sub frmDesconsignacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If e.KeyChar = ChrW(13) Then
                Try
                    If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                        Using db As New CodeFirst
                            Dim idserie As String = cmbSerie.SelectedValue.ToString()
                            Dim desconsignacion = db.Desconsignaciones.Where(Function(f) f.IDSERIE = idserie And f.CONSECUTIVO = txtCodigo.Text).FirstOrDefault()
                            If Not desconsignacion Is Nothing Then
                                If desconsignacion.ANULADO = "N" Then
                                    Me.iddesconsignacion = desconsignacion.IDDESCONSIGNACION
                                    txtCodigo.Enabled = False
                                    dtpFecha.Text = desconsignacion.FECHACONSIGNACION.ToShortDateString()
                                    txtIdVendedor.Text = desconsignacion.Empleado.IDEMPLEADO
                                    txtNombreVendedor.Text = desconsignacion.Empleado.N_TRABAJADOR & " | " & desconsignacion.Empleado.NOMBRES & " " & desconsignacion.Empleado.APELLIDOS
                                    txtIdCliente.Text = desconsignacion.Cliente.IDCLIENTE
                                    txtNombreCliente.Text = desconsignacion.Cliente.N_CLIENTE & " | " & desconsignacion.Cliente.NOMBRES & " " & desconsignacion.Cliente.APELLIDOS
                                    txtConcepto.Text = desconsignacion.OBSERVACION

                                    lvRegistro.Items.Clear()
                                    Dim item As New ListViewItem
                                    For Each detalle In From pro In db.Productos Join exi In db.Existencias On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DesconsignacionesDetalles On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Where det.IDDESCONSIGNACION = desconsignacion.IDDESCONSIGNACION Select pro, exi, det
                                        item = lvRegistro.Items.Add(detalle.exi.IDEXISTENCIA)
                                        item.SubItems.Add(detalle.pro.IDALTERNO)
                                        item.SubItems.Add(detalle.pro.DESCRIPCION)
                                        item.SubItems.Add(detalle.det.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                                        item.SubItems.Add((detalle.det.EXISTENCIA_SIN_CONSIGNAR).ToString(Config.f_m))
                                        item.SubItems.Add(detalle.det.EXISTENCIA_CONSIGNADA.ToString(Config.f_m))
                                        item.SubItems.Add(detalle.det.CANTIDAD.ToString(Config.f_m))
                                    Next
                                    item = Nothing
                                    lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()

                                    txtTotal.Text = desconsignacion.TOTAL.ToString(Config.f_m)
                                    btGuardar.Enabled = False
                                Else
                                    MessageBox.Show("Consignación anulada")
                                End If
                            Else
                                txtCodigo.Text = Me.generarCodigo(cmbSerie.SelectedValue.ToString())
                                txtNVendedor.Focus()
                            End If
                            idserie = Nothing : desconsignacion = Nothing
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error, " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub btVendedor_Click(sender As Object, e As EventArgs)
        frmBuscarEmpleado.frm_return = 8
        frmBuscarEmpleado.ShowDialog()
        If Not txtIdVendedor.Text = "" Then
            txtNCliente.Focus()
        Else
            txtNVendedor.Focus()
        End If
    End Sub

    Private Sub btCliente_Click(sender As Object, e As EventArgs)
        frmBuscarClientes.frm_return = 8 'retornar el valor aqui
        frmBuscarClientes.ShowDialog()
        If Not txtNCliente.Text = "" Then
            txtCodigoAlterno.Focus()
        Else
            txtNCliente.Focus()
        End If
    End Sub

    Private Sub btAgregarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmEmpleado.MdiParent = frmPrincipal
        frmEmpleado.Show()
        frmEmpleado.BringToFront()
    End Sub

    Private Sub btAgregarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCliente.MdiParent = frmPrincipal
        frmCliente.Show()
        frmCliente.BringToFront()
    End Sub

    Private Sub btProducto_Click(sender As Object, e As EventArgs) Handles btProducto.Click
        frmBuscarProductos.frm_return = 8 'retornar el valor aqui
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