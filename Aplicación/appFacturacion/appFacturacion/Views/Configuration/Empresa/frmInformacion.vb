Public Class frmInformacion

    Private Sub frmInformacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmInformacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                Dim emp = db.Empresas.OrderBy(Function(f) f.N).ToList().LastOrDefault()
                If Not emp Is Nothing Then
                    txtNombre.Text = emp.Nombre
                    txtRuc.Text = emp.RUC
                    txtTelefono1.Text = emp.Telefono1
                    txtTelefono2.Text = emp.Telefono2
                    txtDireccion.Text = emp.Direccion
                    If emp.MonedaInventario.Equals(Config.cordoba) Then
                        rdCordoba.Checked = True
                    Else
                        rdDolar.Checked = True
                    End If
                    rdCordoba.Enabled = False
                    rdDolar.Enabled = False
                    txtNombre.Focus()
                Else
                    rdCordoba.Enabled = True
                    rdDolar.Enabled = True
                    txtNombre.Focus()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Try
            If txtNombre.Text.Trim <> "" Then
                Using db As New CodeFirst
                    Dim emp = New Empresa
                    With emp
                        .IdEmpresa = Guid.NewGuid
                        .Reg = DateTime.Now
                        .Nombre = txtNombre.Text
                        .RUC = txtRuc.Text
                        .Telefono1 = txtTelefono1.Text
                        .Telefono2 = txtTelefono2.Text
                        .Direccion = txtDireccion.Text
                        .MonedaInventario = If(rdCordoba.Checked, Config.cordoba, Config.dolar)
                        db.Empresas.Add(emp)
                        db.SaveChanges()
                        rdCordoba.Enabled = False
                        rdDolar.Enabled = False
                        Config.Empresa = emp
                        frmPrincipal.cargarPrivilegios()
                        emp = Nothing
                        MessageBox.Show("Guardado!!")
                        txtNombre.Focus()
                    End With
                End Using
            Else
                MessageBox.Show("Ingresar los campos de orden obligatorio (*)")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtNombre.Text.Trim <> "" Then
                txtRuc.Focus()
            Else
                Config.MsgErr("Ingresar el Nombre de la Empresa.")
            End If
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        If e.KeyData = Keys.Enter Then
            txtTelefono1.Focus()
        End If
    End Sub


    Private Sub txtTelefono1_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono1.TextChanged
        If txtTelefono1.Text.Trim.Length = 9 Then
            txtTelefono2.Focus()
        End If
    End Sub

    Private Sub txtTelefono2_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono2.TextChanged
        If txtTelefono2.Text.Trim.Length = 9 Then
            txtDireccion.Focus()
        End If
    End Sub

    Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccion.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            rdCordoba.Focus()
        End If
    End Sub
End Class