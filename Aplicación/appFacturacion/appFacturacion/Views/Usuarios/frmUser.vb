Public Class frmUser
    Public ID As String
    Sub Limpiar()
        txtNombres.Clear()
        txtApellidos.Clear()
        txtUsuario.Clear()
        txtContraseña.Clear()
        chkMostrar.Checked = False
        txtObservacion.Clear()

        chkAdministrador.Checked = False
        chkConsultasAdministrador.Checked = False
        chkVenta.Checked = False
        chkConsultasVenta.Checked = False
        chkCompra.Checked = False
        chkConsultasCompra.Checked = False
        chkInventario.Checked = False
        chkConsultasInventario.Checked = False
        chkContabilidad.Checked = False
        chkConsultasContabilidad.Checked = False

        btGuardar.Enabled = True
        btEditar.Enabled = False
        btEliminar.Enabled = False
    End Sub

    Public Sub cargarImagen(ByVal fileName As String)
        txtImagen.Text = fileName
        Dim fs As New System.IO.FileStream(fileName, IO.FileMode.Open, IO.FileAccess.Read)
        pnImagen.Style.BackgroundImage = Image.FromStream(fs)
        fs.Close()
        fs.Dispose()
    End Sub

    Private Sub frmUser_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        txtImagen.Width = pnContImage.Width - btImagen.Width - (txtImagen.Location.X * 2)
        btImagen.Left = txtImagen.Location.X + txtImagen.Width - 1
        pnImagen.Width = pnContImage.Width - (pnImagen.Location.X * 2)
        pnImagen.Height = pnContImage.Height - pnImagen.Location.X - 31
    End Sub

    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        Limpiar()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" And txtUsuario.Text.Trim <> "" And txtContraseña.Text.Trim <> "" Then
            If chkAdministrador.Checked Or chkConsultasAdministrador.Checked Or chkVenta.Checked Or chkConsultasVenta.Checked Or chkCompra.Checked Or chkConsultasCompra.Checked Or chkInventario.Checked Or chkConsultasInventario.Checked Or chkContabilidad.Checked Or chkConsultasContabilidad.Checked Or chkSalesPriceChange.Checked Then
                Try
                    Using db As New CodeFirst
                        Dim u As New Usuario
                        u.IDUsuario = Guid.NewGuid.ToString
                        Me.ID = u.IDUsuario
                        u.Reg = DateTime.Now
                        u.Nombres = txtNombres.Text
                        u.Apellidos = txtApellidos.Text
                        u.NombreCuenta = txtUsuario.Text
                        u.Contraseña = txtContraseña.Text
                        u.Observacion = txtObservacion.Text

                        Try
                            If Not txtImagen.Text.Trim() = "" And pnImagen.Style.BackgroundImage Is Nothing Then
                                If System.IO.Directory.Exists(My.Application.Info.DirectoryPath) = False Then
                                    'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath)
                                    Throw New Exception("No se encuentra el directorio de almacen para las Imágenes.")
                                End If
                                Dim path As String = Config.DirectoryPathImageProducts & u.IDUsuario & Config.ImageExtension
                                System.IO.File.Delete(path)
                                Dim bmp As New Bitmap(pnImagen.Style.BackgroundImage)
                                bmp.Save(path, pnImagen.Style.BackgroundImage.RawFormat)
                                bmp.Dispose()
                                u.ImageName = u.IDUsuario
                                path = Nothing
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar la imagen. Descripción: " & ex.Message)
                        End Try

                        u.Administrador = chkAdministrador.Checked
                        u.CAdministrador = chkConsultasAdministrador.Checked
                        u.Venta = chkVenta.Checked
                        u.CVenta = chkConsultasVenta.Checked
                        u.Compra = chkCompra.Checked
                        u.CCompra = chkConsultasCompra.Checked
                        u.Inventario = chkInventario.Checked
                        u.CInventario = chkConsultasInventario.Checked
                        u.Contabilidad = chkContabilidad.Checked
                        u.CContabilidad = chkConsultasContabilidad.Checked
                        u.SalesPriceChange = chkSalesPriceChange.Checked

                        u.Activo = "S"
                        db.Usuarios.Add(u)
                        db.SaveChanges()
                        u = Nothing

                        btGuardar.Enabled = False : btEditar.Enabled = True : btEliminar.Enabled = True
                        txtNombres.Focus()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Seleccionar al menos una labor a desempeñar")
            End If
        Else
            MessageBox.Show("Ingresar los campos de orden obligatorio (*).")
        End If
    End Sub

    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        If txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" And txtUsuario.Text.Trim <> "" Then
            If chkAdministrador.Checked Or chkConsultasAdministrador.Checked Or chkVenta.Checked Or chkConsultasVenta.Checked Or chkCompra.Checked Or chkConsultasCompra.Checked Or chkInventario.Checked Or chkConsultasInventario.Checked Or chkContabilidad.Checked Or chkConsultasContabilidad.Checked Or chkSalesPriceChange.Checked Then
                Try
                    Using db As New CodeFirst
                        Dim u = db.Usuarios.Where(Function(f) f.IDUsuario = Me.txtCodigo.Text).FirstOrDefault
                        If Not u Is Nothing Then
                            u.Nombres = txtNombres.Text
                            u.Apellidos = txtApellidos.Text
                            u.NombreCuenta = txtUsuario.Text
                            If txtContraseña.Text.Trim <> "" Then
                                u.Contraseña = txtContraseña.Text
                            End If
                            u.Observacion = txtObservacion.Text

                            Try
                                If Not txtImagen.Text.Trim() = "" And pnImagen.Style.BackgroundImage Is Nothing Then
                                    If System.IO.Directory.Exists(Config.DirectoryPathImageUsers) = False Then
                                        'System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath)
                                        Throw New Exception("No se encuentra el directorio de almacen para las Imágenes.")
                                    End If
                                    Dim path As String = Config.DirectoryPathImageProducts & u.IDUsuario & Config.ImageExtension
                                    System.IO.File.Delete(path)
                                    Dim bmp As New Bitmap(pnImagen.Style.BackgroundImage)
                                    bmp.Save(path, pnImagen.Style.BackgroundImage.RawFormat)
                                    bmp.Dispose()
                                    u.ImageName = u.IDUsuario
                                    path = Nothing
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar la imagen. Descripción: " & ex.Message)
                            End Try

                            u.Administrador = chkAdministrador.Checked
                            u.CAdministrador = chkConsultasAdministrador.Checked
                            u.Venta = chkVenta.Checked
                            u.CVenta = chkConsultasVenta.Checked
                            u.Compra = chkCompra.Checked
                            u.CCompra = chkConsultasCompra.Checked
                            u.Inventario = chkInventario.Checked
                            u.CInventario = chkConsultasInventario.Checked
                            u.Contabilidad = chkContabilidad.Checked
                            u.CContabilidad = chkConsultasContabilidad.Checked
                            u.SalesPriceChange = chkSalesPriceChange.Checked

                            u.Activo = "S"
                            db.Entry(u).State = EntityState.Modified
                            db.SaveChanges()
                            u = Nothing

                            Limpiar()
                        Else
                            MessageBox.Show("No se encuentra este 'Usuario'. Problablemente ha sido eliminado.")
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Seleccionar al menos una labor a desempeñar")
            End If
        Else
            MessageBox.Show("Ingresar los campos de orden obligatorio (*).")
        End If
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        If MessageBox.Show("¿Desea eliminar este 'Usuario'?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Using db As New CodeFirst
                    Dim u = db.Usuarios.Where(Function(f) f.IDUsuario = Me.txtCodigo.Text).FirstOrDefault
                    If Not u Is Nothing Then
                        u.Activo = "N"
                        db.Entry(u).State = EntityState.Modified
                        db.SaveChanges()
                        u = Nothing
                        Limpiar()
                    Else
                        MessageBox.Show("No se encuentra este 'Usuario'. Problablemente ha sido eliminado.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        frmBuscarUsuario.frm_return = 1
        frmBuscarUsuario.ShowDialog()
    End Sub

    Private Sub frmUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
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
        End If
    End Sub

    Private Sub btImagen_Click(sender As Object, e As EventArgs) Handles btImagen.Click
        Try
            If opArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.cargarImagen(fileName:=opArchivo.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub chkMostrar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrar.CheckedChanged
        If chkMostrar.Checked Then
            txtContraseña.UseSystemPasswordChar = False
        Else
            txtContraseña.UseSystemPasswordChar = True
        End If
    End Sub
End Class