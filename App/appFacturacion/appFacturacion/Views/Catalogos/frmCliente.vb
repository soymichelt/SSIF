Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmCliente

    Sub limpiar()
        txtCodigo.Clear()
        txtCodCliente.Clear()
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
        rdMasculino.Focus()
        txtCorreo.Clear()
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtCodCliente.Focus()
    End Sub

    Private Async Sub frmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Await Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "Customer",
            "Load",
            "Load Customer",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If Not txtCodCliente.Text.Trim = "" And Not txtNombres.Text.Trim = "" And Not txtApellidos.Text.Trim = "" Then
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
                    If db.Clientes.Where(Function(f) f.N_CLIENTE = txtCodCliente.Text.Trim).Count() = 0 Then
                        If txtCedula.Text.Length = 16 Then
                            If db.Clientes.Where(Function(f) f.IDENTIFICACION = txtCedula.Text.Trim).Count() > 0 Then
                                MessageBox.Show("Error, Ya existe un cliente con esta cédula.")
                                Exit Sub
                            End If
                        ElseIf txtCedula.Text.Length > 0 Then
                            'MessageBox.Show("Formato de cédula incorrecto")
                            'Exit Sub
                        End If
                        Dim cliente As New Cliente : cliente.Reg = DateTime.Now : cliente.IDCLIENTE = Guid.NewGuid.ToString : cliente.N_CLIENTE = txtCodCliente.Text : cliente.IDENTIFICACION = txtCedula.Text : cliente.TIPOPERSONA = If(rdNatural.Checked, "Natural", "Jurídica") : cliente.NOMBRES = txtNombres.Text : cliente.APELLIDOS = txtApellidos.Text : cliente.RAZONSOCIAL = txtRazonSocial.Text : cliente.TELEFONO = txtTelefono.Text : cliente.DOMICILIO = txtDomicilio.Text : cliente.LIMITECREDITO = txtLimite.Value : cliente.PLAZO = txtPlazo.Value : cliente.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cliente.SEXO = If(rdMasculino.Checked, "Masculino", "Femenino") : cliente.CORREO = txtCorreo.Text : cliente.FACTURADO_C = 0 : cliente.FACTURADO_D = 0 : cliente.ACTIVO = "S"
                        db.Clientes.Add(cliente)
                        db.SaveChanges() : limpiar() : MessageBox.Show("Cliente guardado")
                    Else
                        MessageBox.Show("Error, Ya existe un cliente con este código.")
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
            If Not txtCodCliente.Text.Trim = "" And Not txtNombres.Text.Trim = "" And Not txtApellidos.Text.Trim = "" And Not txtPlazo.Text.Trim = "" And Not txtLimite.Text.Trim = "" Then
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
                    If db.Clientes.Where(Function(f) Not f.IDCLIENTE = txtCodigo.Text And f.N_CLIENTE = txtCodCliente.Text.Trim).Count() = 0 Then
                        If txtCedula.Text.Length = 16 Then
                            If db.Clientes.Where(Function(f) Not f.IDCLIENTE = txtCodigo.Text And f.IDENTIFICACION = txtCedula.Text.Trim).Count() > 0 Then
                                MessageBox.Show("Error, Ya existe un cliente con esta cédula.")
                                Exit Sub
                            End If
                        ElseIf txtCedula.Text.Length > 0 Then
                            'MessageBox.Show("Formato de cédula incorrecto")
                            'Exit Sub
                        End If
                        Dim cliente = db.Clientes.Where(Function(f) f.IDCLIENTE = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not cliente Is Nothing Then
                            If rdCordoba.Checked Then
                                If cliente.FACTURADO_C > txtLimite.Value Then
                                    MessageBox.Show("Este 'Cliente' tiene una deuda mayor al límite de crédito que se intenta establecer.")
                                    Exit Sub
                                End If
                            Else
                                If cliente.FACTURADO_D > txtLimite.Value Then
                                    MessageBox.Show("Este 'Cliente' tiene una deuda mayor al límite de crédito que se intenta establecer.")
                                    Exit Sub
                                End If
                            End If
                            cliente.N_CLIENTE = txtCodCliente.Text : cliente.IDENTIFICACION = txtCedula.Text : cliente.TIPOPERSONA = If(rdNatural.Checked, "Natural", "Jurídica") : cliente.NOMBRES = txtNombres.Text : cliente.APELLIDOS = txtApellidos.Text : cliente.RAZONSOCIAL = txtRazonSocial.Text : cliente.TELEFONO = txtTelefono.Text : cliente.DOMICILIO = txtDomicilio.Text : cliente.LIMITECREDITO = txtLimite.Value : cliente.PLAZO = txtPlazo.Value : cliente.MONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : cliente.SEXO = If(rdMasculino.Checked, "Masculino", "Femenino") : cliente.CORREO = txtCorreo.Text : cliente.FACTURADO_C = 0 : cliente.FACTURADO_D = 0
                            db.Entry(cliente).State = EntityState.Modified
                            db.SaveChanges() : limpiar() : MessageBox.Show("Cliente editado")
                        Else
                            MessageBox.Show("Error, No se encuentra este cliente. Probablemente ha sido eliminado.")
                        End If
                    Else
                        MessageBox.Show("Error, Ya existe un cliente con este código.")
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
                Dim cliente = db.Clientes.Where(Function(f) f.IDCLIENTE = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                If Not cliente Is Nothing Then
                    If cliente.FACTURADO_C <= 0 Then
                        cliente.ACTIVO = "N"
                        db.Entry(cliente).State = EntityState.Modified
                        db.SaveChanges() : limpiar() : MessageBox.Show("Cliente eliminado")
                    Else
                        MessageBox.Show("Error, Este cliente tiene cuentas pendientes con la empresa por lo que no puede ser eliminado.")
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra este cliente. Probablemente ha sido eliminado.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmCliente_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        frmBuscarClientes.frm_return = 16
        frmBuscarClientes.ShowDialog()
    End Sub

    Private Sub txtCodCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCodCliente.Text.Trim() <> "" Then
                Using db As New CodeFirst
                    Dim r = db.Clientes.Where(Function(f) f.N_CLIENTE = txtCodCliente.Text).FirstOrDefault()
                    If r Is Nothing Then
                        txtNombres.Focus()
                    Else
                        txtCodigo.Text = r.IDCLIENTE
                        If r.TIPOPERSONA = "Natural" Then
                            rdNatural.Checked = True
                        ElseIf r.TIPOPERSONA = "Jurídica" Then
                            rdJuridica.Checked = True
                        End If
                        txtNombres.Text = r.NOMBRES
                        txtApellidos.Text = r.APELLIDOS
                        txtTelefono.Text = r.TELEFONO
                        txtDomicilio.Text = r.DOMICILIO
                        txtCedula.Text = r.IDENTIFICACION
                        txtLimite.Value = r.LIMITECREDITO
                        If r.MONEDA.Equals(Config.cordoba) Then
                            rdCordoba.Checked = True
                        Else
                            rdCordoba.Checked = True
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
                MessageBox.Show("Ingresar el código del cliente")
            End If
        End If
    End Sub

    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtNombres.Text.Trim <> "" Then
                txtApellidos.Focus()
            Else
                MessageBox.Show("Ingresar los nombres del cliente.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtCodCliente.Focus()
        End If
    End Sub

    Private Sub txtApellidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidos.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtApellidos.Text.Trim <> "" Then
                txtTelefono.Focus()
            Else
                MessageBox.Show("Ingresar apellidos del cliente.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtNombres.Focus()
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCedula.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtApellidos.Focus()
        End If
    End Sub

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtDomicilio.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtCedula.Focus()
        End If
    End Sub

    Private Sub txtDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDomicilio.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            txtLimite.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtCedula.Focus()
        End If
    End Sub

    Private Sub txtLimite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimite.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtPlazo.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtDomicilio.Focus()
        End If
    End Sub

    Private Sub txtPlazo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlazo.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtRazonSocial.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtLimite.Focus()
        End If
    End Sub

    Private Sub txtRazonSocial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRazonSocial.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCorreo.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtPlazo.Focus()
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If btGuardar.Enabled Then
                btGuardar_Click(Nothing, Nothing)
            ElseIf btEditar.Enabled Then
                btEditar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtRazonSocial.Focus()
        End If
    End Sub

    Private Sub rdMasculino_CheckedChanged(sender As Object, e As EventArgs) Handles rdMasculino.CheckedChanged
        If rdMasculino.Checked Then
            txtCorreo.Focus()
        End If
    End Sub

    Private Sub rdFemenino_CheckedChanged(sender As Object, e As EventArgs) Handles rdFemenino.CheckedChanged
        If rdFemenino.Checked Then
            txtCorreo.Focus()
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

    Private Sub frmCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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