Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmEmpleado

    Sub limpiar()
        txtCodigo.Clear()
        txtCodTrabajador.Clear()
        rdMasculino.Checked = True
        txtNombres.Clear()
        txtApellidos.Clear()
        txtTelefono.Text = ""
        txtDomicilio.Clear()
        txtObservacion.Clear()
        txtCedula.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Clear()
        chkVentas.Checked = False
        chkCompras.Checked = False
        chkInventario.Checked = False
        chkContabilidad.Checked = False
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtCodTrabajador.Focus()
    End Sub

    Private Sub frmEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "Employee",
            "Load",
            "Load Employee",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Try
            If txtCodTrabajador.Text.Trim = "" Or txtNombres.Text.Trim = "" Or txtApellidos.Text.Trim = "" Then
                MessageBox.Show("Ingresar los datos obligatorios (*).")
                Exit Sub
            End If
            If Not chkVentas.Checked And Not chkCompras.Checked And Not chkInventario.Checked And Not chkContabilidad.Checked Then
                MessageBox.Show("Seleccionar al menos una labor empresarial.")
                Exit Sub
            End If
            Using db As New CodeFirst
                If Not db.Empleados.Where(Function(f) f.N_TRABAJADOR = txtCodTrabajador.Text.Trim).Count() = 0 Then
                    MessageBox.Show("Ya existe un empleado con este Código.")
                    txtCodTrabajador.Focus()
                    Exit Sub
                End If
                If Not db.Empleados.Where(Function(f) f.IDENTIFICACION = txtCedula.Text.Trim).Count() = 0 Then
                    MessageBox.Show("Ya existe un empleado con esta Cédula.")
                    txtCedula.Focus()
                    Exit Sub
                End If
                db.Empleados.Add(New Empleado With {.Reg = DateTime.Now, .IDEMPLEADO = Guid.NewGuid.ToString, .N_TRABAJADOR = txtCodTrabajador.Text, .SEXO = If(rdMasculino.Checked, "Masculino", "Femenino"), .NOMBRES = txtNombres.Text, .APELLIDOS = txtApellidos.Text, .TELEFONO = txtTelefono.Text, .IDENTIFICACION = txtCedula.Text, .DOMICILIO = txtDomicilio.Text, .OBSERVACION = txtObservacion.Text, .CORREO = txtCorreo.Text, .VENTA = chkVentas.Checked, .COMPRA = chkCompras.Checked, .INVENTARIO = chkInventario.Checked, .CONTABILIDAD = chkContabilidad.Checked, .ACTIVO = "S"})
                db.SaveChanges()
            End Using
            limpiar()
            MessageBox.Show("Guardado Satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        Try
            If txtCodigo.Text.Trim = "" Then
                limpiar()
                Exit Sub
            End If
            If txtCodTrabajador.Text.Trim = "" Or txtNombres.Text.Trim = "" Or txtApellidos.Text.Trim = "" Then
                MessageBox.Show("Ingresar los datos obligatorios (*).")
                Exit Sub
            End If
            If Not chkVentas.Checked And Not chkCompras.Checked And Not chkInventario.Checked And Not chkContabilidad.Checked Then
                MessageBox.Show("Seleccionar al menos una labor empresarial.")
                Exit Sub
            End If
            Using db As New CodeFirst
                If Not db.Empleados.Where(Function(f) f.IDEMPLEADO <> txtCodigo.Text And f.N_TRABAJADOR = txtCodTrabajador.Text.Trim).Count() = 0 Then
                    MessageBox.Show("Ya existe un empleado con este Código.")
                    txtCodTrabajador.Focus()
                    Exit Sub
                End If
                If Not db.Empleados.Where(Function(f) f.IDEMPLEADO <> txtCodigo.Text And f.IDENTIFICACION = txtCedula.Text.Trim).Count() = 0 Then
                    MessageBox.Show("Ya existe un empleado con esta Cédula.")
                    txtCedula.Focus()
                    Exit Sub
                End If
                Dim t = db.Empleados.Where(Function(f) f.IDEMPLEADO = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault
                If Not t Is Nothing Then
                    With t
                        .N_TRABAJADOR = txtCodTrabajador.Text
                        .SEXO = If(rdMasculino.Checked, "Masculino", "Femenino")
                        .NOMBRES = txtNombres.Text
                        .APELLIDOS = txtApellidos.Text
                        .TELEFONO = txtTelefono.Text
                        .IDENTIFICACION = txtCedula.Text
                        .DOMICILIO = txtDomicilio.Text
                        .OBSERVACION = txtObservacion.Text
                        .CORREO = txtCorreo.Text
                        .VENTA = chkVentas.Checked
                        .COMPRA = chkCompras.Checked
                        .INVENTARIO = chkInventario.Checked
                        .CONTABILIDAD = chkContabilidad.Checked
                    End With
                    db.Entry(t).State = EntityState.Modified
                    db.SaveChanges()
                Else
                    MessageBox.Show("No se cuentra este trabajador, probablemente ya ha sido eliminado.")
                    Exit Sub
                End If
            End Using
            limpiar()
            MessageBox.Show("Editado Satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        If MessageBox.Show("¿Desea eliminar este empleado?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then
            Try
                Using db As New CodeFirst
                    Dim t = db.Empleados.Where(Function(f) f.IDEMPLEADO = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                    If Not t Is Nothing Then
                        t.ACTIVO = "N"
                        db.Entry(t).State = EntityState.Modified
                        db.SaveChanges() : limpiar()
                        MessageBox.Show("Eliminado Satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error, No se encuentra este vendedor. Probablemente ha sido eliminado.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        frmBuscarEmpleado.frm_return = 12
        frmBuscarEmpleado.ShowDialog()
    End Sub

    Private Sub frmEmpleado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub txtCodTrabajador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodTrabajador.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtCodTrabajador.Text.Trim() <> "" Then
                Using db As New CodeFirst
                    Dim t = db.Empleados.Where(Function(f) f.N_TRABAJADOR = txtCodTrabajador.Text).FirstOrDefault()
                    If t Is Nothing Then
                        txtNombres.Focus()
                    Else
                        txtCodigo.Text = t.IDEMPLEADO
                        If t.SEXO = "Masculino" Then
                            rdMasculino.Checked = True
                        ElseIf t.SEXO = "Femenino" Then
                            rdFemenino.Checked = True
                        End If
                        txtNombres.Text = t.NOMBRES
                        txtApellidos.Text = t.APELLIDOS
                        txtTelefono.Text = t.TELEFONO
                        txtCedula.Text = t.IDENTIFICACION
                        txtDomicilio.Text = t.DOMICILIO
                        txtObservacion.Text = t.OBSERVACION
                        txtCorreo.Text = t.CORREO
                        'txtIdCiudad.Text = t.IDCIUDAD.ToString
                        'txtCiudad.Text = t.CIUDAD.NOMBRE
                        chkVentas.Checked = t.VENTA
                        chkCompras.Checked = t.COMPRA
                        chkInventario.Checked = t.INVENTARIO
                        chkContabilidad.Checked = t.CONTABILIDAD

                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                        txtNombres.Focus()
                    End If
                    t = Nothing
                End Using
            Else
                MessageBox.Show("Ingresar el código del vendedor")
            End If
        End If
    End Sub

    Private Sub txtNombres_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtNombres.Text.Trim <> "" Then
                txtApellidos.Focus()
            Else
                MessageBox.Show("Ingresar nombres del empleado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtApellidos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApellidos.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtApellidos.Text.Trim <> "" Then
                txtTelefono.Focus()
            Else
                MessageBox.Show("Ingresar apellidos del empleado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
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

    Private Sub txtDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDomicilio.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDomicilio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDomicilio.KeyDown
        If e.KeyData = Keys.Enter Then
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyData = Keys.Enter Then
            txtCorreo.Focus()
        End If
    End Sub

    Private Sub txtCorreo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorreo.KeyDown
        If e.KeyData = Keys.Enter Then
            If btGuardar.Enabled Then
                btGuardar_Click(Nothing, Nothing)
            Else
                If btEditar.Enabled Then
                    btEditar_Click(Nothing, Nothing)
                End If
            End If
        End If
    End Sub


End Class