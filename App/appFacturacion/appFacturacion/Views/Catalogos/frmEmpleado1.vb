Public Class frmEmpleado1

    Sub limpiar()
        'txtCodigo.Text = operacion.GenerarCodigo("IDTRABAJADOR", "TRABAJADOR")
        txtCodigo.Clear()
        txtCodTrabajador.Clear()
        txtNombres.Clear()
        txtApellidos.Clear()
        txtTelefono.Text = ""
        txtDomicilio.Clear()
        txtObservacion.Clear()
        txtCedula.Text = ""
        rdMasculino.Checked = True
        txtTelefono.Text = ""
        txtCedulaPadre.Text = ""
        txtNombrePadre.Clear()
        txtCedulaMadre.Text = ""
        txtNombreMadre.Clear()
        txtCedulaConyugue.Text = ""
        txtNombreConyugue.Clear()
        txtCorreo.Clear()
        cmbEstadoCivil.SelectedIndex = -1
        txtRuc.Clear()
        txtInss.Clear()
        rdSueldoHoras.Checked = True
        rdCordoba.Checked = True
        txtSueldo.Value = 1
        txtComision.Value = 0
        txtImagen.Clear()
        pnImagen.Style.BackgroundImage = Nothing
        txtArchivo.Clear()
        txtIdPuesto.Clear()
        txtPuesto.Clear()
        txtIdArea.Clear()
        txtArea.Clear()
        txtIdCiudad.Clear()
        txtCiudad.Clear()
        txtNombreUsuario.Clear()
        txtContraseña.Clear()
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtCodTrabajador.Focus()
    End Sub

    Public Sub cargarImagen(ByVal fileName As String, Optional ByVal tipo As Integer = 0)
        txtImagen.Text = fileName
        Dim fs As New System.IO.FileStream(If(tipo.Equals(0), fileName, ""), IO.FileMode.Open, IO.FileAccess.Read)
        pnImagen.Style.BackgroundImage = Image.FromStream(fs)
        fs.Close()
        fs.Dispose()
    End Sub



    Public Sub cargarArchivo(ByVal fileName As String)
        txtArchivo.Text = fileName
        Dim fs As New System.IO.FileStream(fileName, IO.FileMode.Open, IO.FileAccess.Read)
        pnImagen.Style.BackgroundImage = Image.FromStream(fs)
        fs.Close()
        fs.Dispose()
    End Sub

    Public Function pathEmpleados() As String
        Return My.Application.Info.DirectoryPath & "\imagenesdetrabajadores\"
    End Function

    Private Sub frmEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If Not txtCodTrabajador.Text.Trim = "" And Not txtNombres.Text.Trim = "" And Not txtApellidos.Text.Trim = "" And txtIdCiudad.Text.Trim <> "" And txtIdArea.Text.Trim <> "" And txtIdPuesto.Text.Trim <> "" Then
                Using db As New MODELODEDATOS
                    If db.TRABAJADORES.Where(Function(f) f.N_TRABAJADOR = txtCodTrabajador.Text.Trim).Count() = 0 Then
                        If db.TRABAJADORES.Where(Function(f) f.IDENTIFICACION = txtCedula.Text.Trim).Count() = 0 Then
                            'Dim empleado As New TRABAJADOR : empleado.IDTRABAJADOR = Guid.NewGuid.ToString : empleado.N_TRABAJADOR = txtCodTrabajador.Text : empleado.IDENTIFICACION = txtCedula.Text : empleado.NOMBRES = txtNombres.Text : empleado.APELLIDOS = txtApellidos.Text : empleado.TELEFONO = txtTelefono.Text : empleado.DOMICILIO = txtDomicilio.Text : empleado.OBSERVACION = txtObservacion.Text : empleado.SEXO = If(rdMasculino.Checked, "Masculino", "Femenino") : empleado.CORREO = txtCorreo.Text : empleado.IDCIUDAD = txtIdCiudad.Text : empleado.ESTADO_CIVIL = cmbEstadoCivil.Text : empleado.N_INSS = txtInss.Text : empleado.N_RUC = txtRuc.Text : empleado.IDENTIFICACION_CONYUGUE = txtCedulaConyugue.Text : empleado.NOMBRE_CONYUGUE = txtNombreConyugue.Text : empleado.IDENTIFICACION_MADRE = txtCedulaMadre.Text : empleado.NOMBRE_MADRE = txtNombreMadre.Text : empleado.IDENTIFICACION_PADRE = txtCedulaPadre.Text : empleado.NOMBRE_PADRE = txtNombrePadre.Text : empleado.SUELDO_BASE_HORA = rdSueldoHoras.Checked : empleado.MONEDA = If(rdCordoba.Checked, "Córdoba", "Dólar") : empleado.SUELDO = txtSueldo.Value : empleado.COMISION_POR = txtComision.Value : empleado.IDPUESTO = txtIdPuesto.Text : empleado.IDAREA = txtIdArea.Text : empleado.USUARIO = chkUsuario.Checked : empleado.NOMBREUSUARIO = If(chkUsuario.Checked, txtNombreUsuario.Text, "") : empleado.CONTRASEÑA = If(chkUsuario.Checked, txtContraseña.Text, "") : empleado.ACTIVO = "S"
                            'db.TRABAJADORES.Add(empleado)
                            'Try
                            '    If Not txtImagen.Text.Trim() = "" Then
                            '        If System.IO.Directory.Exists(Me.pathEmpleados) = False Then
                            '            System.IO.Directory.CreateDirectory(Me.pathEmpleados)
                            '        End If
                            '        Dim path As String = Me.pathEmpleados & empleado.IDTRABAJADOR & System.IO.Path.GetExtension(txtImagen.Text)
                            '        System.IO.File.Delete(path)
                            '        Dim bmp As New Bitmap(pnImagen.Style.BackgroundImage)
                            '        bmp.Save(path, pnImagen.Style.BackgroundImage.RawFormat)
                            '        bmp.Dispose()
                            '        empleado.IMAGENAME = empleado.IDTRABAJADOR & System.IO.Path.GetExtension(txtImagen.Text)
                            '        path = Nothing
                            '    End If
                            'Catch ex As Exception
                            '    MessageBox.Show("Error al guardar la imagen. Error, " & ex.Message)
                            'End Try
                            'db.SaveChanges() : limpiar() : MessageBox.Show("Empleado guardado")
                        Else
                            MessageBox.Show("Error, Ya existe un Empleado con esta cédula.")
                        End If
                    Else
                        MessageBox.Show("Error, Ya existe un Empleado con este código.")
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
            If Not txtCodTrabajador.Text.Trim = "" And Not txtNombres.Text.Trim = "" And Not txtApellidos.Text.Trim = "" Then
                Using db As New MODELODEDATOS
                    If db.TRABAJADORES.Where(Function(f) Not f.IDTRABAJADOR = txtCodigo.Text And f.N_TRABAJADOR = txtCodTrabajador.Text.Trim).Count() = 0 Then
                        If db.TRABAJADORES.Where(Function(f) Not f.IDTRABAJADOR = txtCodigo.Text And f.IDENTIFICACION = txtCedula.Text.Trim).Count() = 0 Then
                            'Dim empleado = db.TRABAJADORES.Where(Function(f) f.IDTRABAJADOR = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                            'If Not empleado Is Nothing Then
                            '    empleado.N_TRABAJADOR = txtCodTrabajador.Text : empleado.IDENTIFICACION = txtCedula.Text : empleado.NOMBRES = txtNombres.Text : empleado.APELLIDOS = txtApellidos.Text : empleado.TELEFONO = txtTelefono.Text : empleado.DOMICILIO = txtDomicilio.Text : empleado.OBSERVACION = txtObservacion.Text : empleado.SEXO = If(rdMasculino.Checked, "Masculino", "Femenino") : empleado.CORREO = txtCorreo.Text : empleado.IDCIUDAD = txtIdCiudad.Text : empleado.ESTADO_CIVIL = cmbEstadoCivil.Text : empleado.N_INSS = txtInss.Text : empleado.N_RUC = txtRuc.Text : empleado.IDENTIFICACION_CONYUGUE = txtCedulaConyugue.Text : empleado.NOMBRE_CONYUGUE = txtNombreConyugue.Text : empleado.IDENTIFICACION_MADRE = txtCedulaMadre.Text : empleado.NOMBRE_MADRE = txtNombreMadre.Text : empleado.IDENTIFICACION_PADRE = txtCedulaPadre.Text : empleado.NOMBRE_PADRE = txtNombrePadre.Text : empleado.SUELDO_BASE_HORA = rdSueldoHoras.Checked : empleado.MONEDA = If(rdCordoba.Checked, "Córdoba", "Dólar") : empleado.SUELDO = txtSueldo.Value : empleado.COMISION_POR = txtComision.Value : empleado.IDPUESTO = txtIdPuesto.Text : empleado.IDAREA = txtIdArea.Text : empleado.USUARIO = chkUsuario.Checked : empleado.NOMBREUSUARIO = If(chkUsuario.Checked, txtNombreUsuario.Text, "") : empleado.CONTRASEÑA = If(chkUsuario.Checked, txtContraseña.Text, "")
                            '    Try
                            '        If Not txtImagen.Text.Trim() = "" Then
                            '            If System.IO.Directory.Exists(Me.pathEmpleados) = False Then
                            '                System.IO.Directory.CreateDirectory(Me.pathEmpleados)
                            '            End If
                            '            Dim path As String = Me.pathEmpleados & empleado.IDTRABAJADOR & System.IO.Path.GetExtension(txtImagen.Text)
                            '            System.IO.File.Delete(path)
                            '            Dim bmp As New Bitmap(pnImagen.Style.BackgroundImage)
                            '            bmp.Save(path, pnImagen.Style.BackgroundImage.RawFormat)
                            '            bmp.Dispose()
                            '            empleado.IMAGENAME = empleado.IDTRABAJADOR & System.IO.Path.GetExtension(txtImagen.Text)
                            '            path = Nothing
                            '        End If
                            '    Catch ex As Exception
                            '        MessageBox.Show("Error al guardar la imagen. Error, " & ex.Message)
                            '    End Try
                            '    db.Entry(empleado).State = EntityState.Modified
                            '    db.SaveChanges() : limpiar() : MessageBox.Show("Empleado editado")
                            'Else
                            '    MessageBox.Show("Error, No se encuentra este Empleado. Probablemente ha sido eliminado.")
                            'End If
                        Else
                            MessageBox.Show("Error, Ya existe un Empleado con esta cédula.")
                        End If
                    Else
                        MessageBox.Show("Error, Ya existe un Empleado con este código.")
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
            Using db As New MODELODEDATOS
                Dim vendedor = db.TRABAJADORES.Where(Function(f) f.IDTRABAJADOR = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                If Not vendedor Is Nothing Then
                    vendedor.ACTIVO = "N"
                    db.Entry(vendedor).State = EntityState.Modified
                    db.SaveChanges() : limpiar() : MessageBox.Show("Vendedor eliminado")
                Else
                    MessageBox.Show("Error, No se encuentra este vendedor. Probablemente ha sido eliminado.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmVendedor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        frmBuscarVendedor.frm_return = 12
        frmBuscarVendedor.ShowDialog()
    End Sub

    Private Sub txtCodVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodTrabajador.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCodTrabajador.Text.Trim() <> "" Then
                Using db As New MODELODEDATOS
                    Dim vendedor = db.TRABAJADORES.Where(Function(f) f.N_TRABAJADOR = txtCodTrabajador.Text).FirstOrDefault()
                    If vendedor Is Nothing Then
                        txtNombres.Focus()
                    Else
                        txtCodigo.Text = vendedor.IDTRABAJADOR
                        txtNombres.Text = vendedor.NOMBRES
                        txtApellidos.Text = vendedor.APELLIDOS
                        txtTelefono.Text = vendedor.TELEFONO
                        txtDomicilio.Text = vendedor.DOMICILIO
                        txtObservacion.Text = vendedor.OBSERVACION
                        txtCedula.Text = vendedor.IDENTIFICACION

                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                        txtNombres.Focus()
                    End If
                    vendedor = Nothing
                End Using
            Else
                MessageBox.Show("Ingresar el código del vendedor")
            End If
        End If
    End Sub


    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtNombres.Text.Trim <> "" Then
                txtApellidos.Focus()
            Else
                MessageBox.Show("Ingresar los nombres del vendedor")
            End If
        End If
    End Sub

    Private Sub txtApellidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidos.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtApellidos.Text.Trim <> "" Then
                txtTelefono.Focus()
            Else
                MessageBox.Show("Ingresar los apellidos del vendedor")
            End If
        End If
    End Sub

    Private Sub txtTelefono_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            txtCedula.Focus()
        End If
    End Sub

    Private Sub txtDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDomicilio.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
            cmbEstadoCivil.Focus()
        End If
    End Sub

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtDomicilio.Focus()
        End If
    End Sub

    Private Sub btImagen_Click(sender As Object, e As EventArgs) Handles btImagen.Click
        Try
            opArchivo.Filter = "Imagenes (.jpg, .jpeg, .png, .gif)|*.jpg;*.jpeg;*.png;*.gif"
            If opArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.cargarImagen(fileName:=opArchivo.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btArchivo_Click(sender As Object, e As EventArgs) Handles btArchivo.Click
        Try
            opArchivo.Filter = "Archivos del Trabajador (.jpg, .jpeg, .png, .gif, .rar, .zip, .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf)|*.jpg;*.jpeg;*.png;*.gif;*.rar;*.zip;*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx;*.pdf;"
            If opArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.cargarImagen(fileName:=opArchivo.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btCargarPuesto_Click(sender As Object, e As EventArgs) Handles btCargarPuesto.Click
        frmBuscarTrabajadorPuesto.frm_return = 2
        frmBuscarTrabajadorPuesto.ShowDialog()
    End Sub

    Private Sub btCargarArea_Click(sender As Object, e As EventArgs) Handles btCargarArea.Click
        frmBuscarTrabajadorArea.frm_return = 2
        frmBuscarTrabajadorArea.ShowDialog()
    End Sub

    Private Sub txtPuesto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPuesto.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdPuesto.Text.Trim <> "" Then
                txtArea.Focus()
            Else
                btCargarPuesto_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtArea.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdArea.Text.Trim <> "" Then
                chkUsuario.Focus()
            Else
                btCargarArea_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub rdMasculino_CheckedChanged(sender As Object, e As EventArgs) Handles rdMasculino.CheckedChanged
        txtNombres.Focus()
    End Sub

    Private Sub rdFemenino_CheckedChanged(sender As Object, e As EventArgs) Handles rdFemenino.CheckedChanged
        txtNombres.Focus()
    End Sub

    Private Sub frmTrabajador_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtTelefono.Focused Then
                txtCedula.Focus()
            ElseIf txtCedula.Focused Then
                txtCorreo.Focus()
            ElseIf txtCedulaConyugue.Focused Then
                txtNombreConyugue.Focus()
            ElseIf txtCedulaMadre.Focused Then
                txtNombreMadre.Focus()
            ElseIf txtCedulaPadre.Focused Then
                txtNombrePadre.Focus()
            End If
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtDomicilio.Focus()
        End If
    End Sub

    Private Sub txtNombreConyugue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreConyugue.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCedulaMadre.Focus()
        End If
    End Sub

    Private Sub txtNombreMadre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreMadre.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCedulaPadre.Focus()
        End If
    End Sub

    Private Sub txtNombrePadre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombrePadre.KeyPress
        If e.KeyChar = ChrW(13) Then
            rdSueldoHoras.Focus()
        End If
    End Sub

    Private Sub cmbEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoCivil.SelectedIndexChanged
        txtInss.Focus()
    End Sub

    Private Sub txtRuc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRuc.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtCiudad.Focus()
        End If
    End Sub

    Private Sub txtCiudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCiudad.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdCiudad.Text.Trim <> "" Then
                txtCedulaConyugue.Focus()
            Else
                btCiudad_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub btCiudad_Click(sender As Object, e As EventArgs) Handles btCiudad.Click
        frmBuscarCiudades.frm_return = 2
        frmBuscarCiudades.ShowDialog()
    End Sub

    Private Sub chkUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsuario.CheckedChanged
        If chkUsuario.Checked Then
            txtNombreUsuario.Enabled = True
            txtContraseña.Enabled = True
            txtNombreUsuario.Focus()
        Else
            txtNombreUsuario.Enabled = False
            txtContraseña.Enabled = False
        End If
    End Sub

    Private Sub txtSueldo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSueldo.KeyDown
        If e.KeyData = Keys.Enter Then
            txtComision.Focus()
        End If
    End Sub

    Private Sub txtComision_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComision.KeyDown
        If e.KeyData = Keys.Enter Then
            txtPuesto.Focus()
        End If
    End Sub


End Class