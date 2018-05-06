Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmProveedor
    Sub limpiar()
        txtCodigo.Clear()
        txtCodProveedor.Clear()
        rdNatural.Checked = True
        txtNombres.Clear()
        txtApellidos.Clear()
        txtTelefono.Text = ""
        txtDomicilio.Clear()
        txtCedula.Text = ""
        txtDomicilio.Clear()
        txtLimite.Value = 0
        txtPlazo.Value = 0
        txtRazonSocial.Clear()
        rdMasculino.Checked = True
        txtCorreo.Clear()
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtCodProveedor.Focus()
    End Sub

    Private Async Sub frmProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Await Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "Provider",
            "Load",
            "Load Provider",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If txtCodProveedor.Text.Trim <> "" And txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" Then
                If txtLimite.Value > 0 Then
                    If Not txtPlazo.Value > 0 Then
                        MessageBox.Show("Error, Si el límite de crédito es mayor que 0 debe tener un plazo")
                        Exit Sub
                    End If
                Else
                    If txtPlazo.Value > 0 Then
                        MessageBox.Show("Error, Si el plazo es mayor que 0 debe tener un límite de crédito")
                        Exit Sub
                    End If
                End If
                Using db As New CodeFirst
                    If db.Proveedores.Where(Function(f) f.N_PROVEEDOR = txtCodProveedor.Text.Trim).Count() = 0 Then
                        If txtCedula.Text.Length = 16 Then
                            If db.Proveedores.Where(Function(f) f.IDENTIFICACION = txtCedula.Text.Trim).Count() > 0 Then
                                MessageBox.Show("Error, Ya existe un proveedor con esta cédula.")
                                Exit Sub
                            End If
                        ElseIf txtCedula.Text.Length > 0 Then
                            'MessageBox.Show("Formato de cédula incorrecto")
                            'Exit Sub
                        End If
                        Dim proveedor As New Proveedor : proveedor.Reg = DateTime.Now : proveedor.IDPROVEEDOR = Guid.NewGuid.ToString : proveedor.N_PROVEEDOR = txtCodProveedor.Text : proveedor.IDENTIFICACION = txtCedula.Text : proveedor.TIPOPERSONA = If(rdNatural.Checked, "Natural", "Jurídica") : proveedor.NOMBRES = txtNombres.Text : proveedor.APELLIDOS = txtApellidos.Text : proveedor.SEXO = If(rdMasculino.Checked, "Masculino", "Femenino") : proveedor.CORREO = txtCorreo.Text : proveedor.TELEFONO = txtTelefono.Text : proveedor.DOMICILIO = txtDomicilio.Text : proveedor.PLAZO = txtPlazo.Value : proveedor.LIMITECREDITO = txtLimite.Value : proveedor.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : proveedor.FACTURADO_C = 0.0 : proveedor.FACTURADO_D = 0.0 : proveedor.RAZONSOCIAL = txtRazonSocial.Text : proveedor.ACTIVO = "S"
                        db.Proveedores.Add(proveedor)
                        db.SaveChanges() : limpiar() : MessageBox.Show("Proveedor guardado")
                    Else
                        MessageBox.Show("Error, Ya existe un proveedor con este código.")
                    End If
                End Using
            Else
                MessageBox.Show("Error, Faltan datos.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        Try
            If txtCodProveedor.Text.Trim <> "" And txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" Then
                If txtLimite.Value > 0 Then
                    If Not txtPlazo.Value > 0 Then
                        MessageBox.Show("Error, Si el límite de crédito es mayor que 0 debe tener un plazo")
                        Exit Sub
                    End If
                Else
                    If txtPlazo.Value > 0 Then
                        MessageBox.Show("Error, Si el plazo es mayor que 0 debe tener un límite de crédito")
                        Exit Sub
                    End If
                End If
                Using db As New CodeFirst
                    If db.Proveedores.Where(Function(f) Not f.IDPROVEEDOR = txtCodigo.Text And f.N_PROVEEDOR = txtCodProveedor.Text).Count() = 0 Then
                        If txtCedula.Text.Length = 16 Then
                            If db.Proveedores.Where(Function(f) Not f.IDPROVEEDOR = txtCodigo.Text And f.IDENTIFICACION = txtCedula.Text.Trim).Count() > 0 Then
                                MessageBox.Show("Error, Ya existe un proveedor con esta cédula.")
                                Exit Sub
                            End If
                        ElseIf txtCedula.Text.Length > 0 Then
                            'MessageBox.Show("Formato de cédula incorrecto")
                            'Exit Sub
                        End If
                        Dim proveedor = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not proveedor Is Nothing Then
                            If rdCordoba.Checked Then
                                If proveedor.FACTURADO_C > txtLimite.Value Then
                                    MessageBox.Show("Este 'Proveedor' tiene una deuda mayor al límite de crédito que se intenta establecer.")
                                    Exit Sub
                                End If
                            Else
                                If proveedor.FACTURADO_D > txtLimite.Value Then
                                    MessageBox.Show("Este 'Proveedor' tiene una deuda mayor al límite de crédito que se intenta establecer.")
                                    Exit Sub
                                End If
                            End If
                            proveedor.N_PROVEEDOR = txtCodProveedor.Text : proveedor.IDENTIFICACION = txtCedula.Text : proveedor.TIPOPERSONA = If(rdNatural.Checked, "Natural", "Jurídica") : proveedor.NOMBRES = txtNombres.Text : proveedor.APELLIDOS = txtApellidos.Text : proveedor.SEXO = If(rdMasculino.Checked, "Masculino", "Femenino") : proveedor.CORREO = txtCorreo.Text : proveedor.TELEFONO = txtTelefono.Text : proveedor.DOMICILIO = txtDomicilio.Text : proveedor.PLAZO = txtPlazo.Value : proveedor.LIMITECREDITO = txtLimite.Value : proveedor.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : proveedor.RAZONSOCIAL = txtRazonSocial.Text
                            db.Entry(proveedor).State = EntityState.Modified
                            db.SaveChanges() : limpiar() : MessageBox.Show("Proveedor editado")
                        Else
                            MessageBox.Show("Error, No se encuentra esta proveedor. Probablemente alla sido eliminada.")
                        End If
                    Else
                        MessageBox.Show("Error, Ya existe un proveedor con este código.")
                    End If
                End Using
            Else
                MessageBox.Show("Error, Faltan datos.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        Try
            Using db As New CodeFirst
                Dim proveedor = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                If Not proveedor Is Nothing Then
                    proveedor.ACTIVO = "N"
                    db.Entry(proveedor).State = EntityState.Modified
                    db.SaveChanges() : limpiar() : MessageBox.Show("Proveedor eliminado")
                Else
                    MessageBox.Show("Error, No se encuentra esta proveedor. Probablemente alla sido eliminada.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmProveedor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        frmBuscarProveedor.frm_return = 1
        frmBuscarProveedor.ShowDialog()
    End Sub

    Private Sub txtCodProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodProveedor.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCodProveedor.Text.Trim() <> "" Then
                Using db As New CodeFirst
                    Dim r = db.Proveedores.Where(Function(f) f.N_PROVEEDOR = txtCodProveedor.Text).FirstOrDefault()
                    If r Is Nothing Then
                        txtNombres.Focus()
                    Else
                        txtCodigo.Text = r.IDPROVEEDOR
                        If r.TIPOPERSONA = "Natural" Then
                            rdNatural.Checked = True
                        ElseIf r.TIPOPERSONA = "Jurídica" Then
                            rdJuridica.Checked = True
                        End If
                        txtNombres.Text = r.NOMBRES
                        txtApellidos.Text = r.APELLIDOS
                        txtTelefono.Text = r.TELEFONO
                        txtCedula.Text = r.IDENTIFICACION
                        txtDomicilio.Text = r.DOMICILIO
                        txtLimite.Value = r.LIMITECREDITO
                        If r.MONEDA.Equals(Config.cordoba) Then
                            rdCordoba.Checked = True
                        Else
                            rdDolar.Checked = True
                        End If
                        txtPlazo.Value = r.PLAZO
                        txtRazonSocial.Text = r.RAZONSOCIAL
                        If r.SEXO.Equals("Masculino") Then
                            rdMasculino.Checked = True
                        Else
                            rdFemenino.Checked = True
                        End If
                        txtCorreo.Text = r.CORREO

                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                        txtNombres.Focus()
                    End If
                    r = Nothing
                End Using
            Else
                MessageBox.Show("Ingresar el Código del Proveedor")
            End If
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtNombres.Text.Trim <> "" Then
                txtApellidos.Focus()
            Else
                MessageBox.Show("Ingresar el Nombre del Proveedor")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtCodProveedor.Focus()
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtTelefono.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtApellidos.Focus()
        End If
    End Sub

    Private Sub txtDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDomicilio.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            txtLimite.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtTelefono.Focus()
        End If
    End Sub

    Private Sub txtPlazo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlazo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtPlazo.Text.Trim <> "" Then
                txtRazonSocial.Focus()
            Else
                MessageBox.Show("Ingresar el Plazo del Crédito del Proveedor")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtPlazo.Focus()
        End If
    End Sub

    Private Sub txtLimite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimite.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtLimite.Text.Trim <> "" Then
                txtPlazo.Focus()
            Else
                MessageBox.Show("Ingresar el Limite del Crédito del Proveedor")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtDomicilio.Focus()
        End If
    End Sub


    Private Sub txtRazonSocial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRazonSocial.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCorreo.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtPlazo.Focus()
        End If
    End Sub

    Private Sub txtApellidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidos.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtApellidos.Text.Trim <> "" Then
                txtTelefono.Focus()
            Else
                MessageBox.Show("Ingresar los Apellidos del Proveedor")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtNombres.Focus()
        End If
    End Sub

    Private Sub txtCorreo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorreo.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtCodigo.Text.Trim <> "" Then
                btEditar_Click(Nothing, Nothing)
            Else
                btGuardar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtRazonSocial.Focus()
        End If
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
        If txtTelefono.Text.Trim.Length = 9 Then
            txtCedula.Focus()
        End If
    End Sub

    Private Sub txtCedula_TextChanged(sender As Object, e As EventArgs) Handles txtCedula.TextChanged
        If txtCedula.Text.Trim.Length = 16 Then
            txtDomicilio.Focus()
        End If
    End Sub

    Private Sub frmProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                    If btEliminar.Enabled Then
                        btEliminar_Click(Nothing, Nothing)
                    End If
                Case Keys.B
                    btBuscar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub
End Class