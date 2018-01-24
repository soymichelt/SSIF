Public Class frmRegister
    Dim StrPass = ""
    Private Sub frmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Config.Key = License.GetIlimit()
            If License.LicenseValidateIlimit Then
                txtClaveEncriptada.Text = Config.Key
                lblVence.Text = "LICENCIA ILIMITADA"
                txtClave.Enabled = False
                btRegistrar.Enabled = False
            Else
                Config.Key = License.GetTemp()
                If Not Config.Key Is Nothing Then
                    txtClaveEncriptada.Text = Config.Key
                    lblVence.Text = "VENCE: " & Config.DateLimite.Value.ToShortDateString()
                Else
                    License.KeyTemp()
                    txtClaveEncriptada.Text = Config.Key
                    lblVence.Text = "VENCE: " & Config.DateLimite.Value.ToShortDateString()
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btRegistrar_Click(sender As Object, e As EventArgs) Handles btRegistrar.Click
        Try
            If txtClave.Text = CryptoSecurity.KeyProp Then
                License.KeyLicense()
                lblVence.Text = "LICENCIA ILIMITADA"
                txtClave.Clear()
                txtClaveEncriptada.Text = Config.Key
                txtClave.Enabled = False
                btRegistrar.Enabled = False
            Else                Config.MsgErr("Clave de registro incorrecta")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try

        'Try
        '    'Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\KeyClientSystemApp\\App\\v1.0", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        '    'Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\KeyClientSystemApp\\App\\v1.0", "Michel", "8339-1048")
        '    Dim c As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\KeyClientSystemApp\\App\\v1.0", True)
        '    Config.MsgInfo(c.GetValue("Michel"))
        'Catch ex As Exception
        '    Config.MsgErr(ex.Message)
        'End Try
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtClave.Text.Trim <> "" Then
                btRegistrar_Click(Nothing, Nothing)
            Else
                Config.MsgErr("Ingresar la clave de registro")
            End If
        End If
    End Sub
End Class