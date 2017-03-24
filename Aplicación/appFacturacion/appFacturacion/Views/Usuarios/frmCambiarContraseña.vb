Public Class frmCambiarContraseña

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Try
            If Not txtActual.Text.Trim = "" And Not txtNueva.Text.Trim = "" And Not txtConfirmar.Text.Trim = "" Then
                Using db As New CodeFirst
                    Config.Usuario = db.Usuarios.Where(Function(f) f.NombreCuenta = Config.Usuario.NombreCuenta And f.Activo = "S").FirstOrDefault
                    If Not Config.Usuario Is Nothing Then
                        If Config.Usuario.Contraseña = txtActual.Text Then
                            If txtNueva.Text = txtConfirmar.Text Then
                                Config.Usuario.Contraseña = txtNueva.Text
                                db.Entry(Config.Usuario).State = EntityState.Modified
                                db.SaveChanges()
                                MessageBox.Show("Contraseña guardada correctamente")
                                Me.Close()
                            Else
                                MessageBox.Show("Las contraseñas no coinciden")
                            End If
                        Else
                            MessageBox.Show("Contraseña incorrecta")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra este usuario")
                        frmLogin.Show()
                        frmPrincipal.forzarcierre = True
                        frmPrincipal.Close()
                    End If
                End Using
            Else
                MessageBox.Show("Ninguna de las contraseñas puede contener cadena vacia")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmCambiarContraseña_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        Me.Close()
    End Sub

    Private Sub txtActual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtActual.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtActual.Text.Trim() = "" Then
                txtNueva.Focus()
            Else
                MessageBox.Show("La contraseña actual no puede ser una cadena vacía")
            End If
        End If
    End Sub

    Private Sub txtNueva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNueva.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtNueva.Text.Trim() = "" Then
                txtConfirmar.Focus()
            Else
                MessageBox.Show("La contraseña nueva no puede ser una cadena vacía")
            End If
        End If
    End Sub

    Private Sub txtConfirmar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConfirmar.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtConfirmar.Text.Trim() = "" Then
                btGuardar.Focus()
            Else
                MessageBox.Show("La contraseña confirmada no puede ser una cadena vacía")
            End If
        End If
    End Sub
End Class