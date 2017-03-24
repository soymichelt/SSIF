Module License

    Private StrPass As String

    Public Function LicenseValidateIlimit() As Boolean
        If Not Config.Key Is Nothing And Config.DateLimite Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetTemp() As Object
        Try
            Config.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\KeyClientSystemApp\\App\\v1.0", False)
            If Not Config.RegistryKey Is Nothing Then
                Config.Key = Config.RegistryKey.GetValue("KeyTemp")
                If Not Config.Key Is Nothing Then
                    Try
                        Config.DateLimite = DateTime.Parse(Config.Key.ToString()).ToShortDateString()
                        Return Config.Key
                    Catch ex As Exception
                        Return Nothing
                    End Try
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetIlimit() As Object
        Try
            Config.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\KeyClientSystemApp\\App\\v1.0", False)
            If Not Config.RegistryKey Is Nothing Then
                Config.Key = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\KeyClientSystemApp\\App\\v1.0", "KeyValue", Nothing)
                If Not Config.Key Is Nothing Then
                    If CryptoSecurity.Decoding(Config.Key.ToString()) = "Licencia" Then
                        Config.DateLimite = Nothing
                        Return Config.Key
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub KeyTemp()
        Config.Key = License.GetIlimit()
        If Not License.LicenseValidateIlimit Then
            Config.Key = License.GetTemp()
            If Config.Key Is Nothing Then
                Config.DateLimite = DateTime.Now.AddDays(30)
                Config.Key = CryptoSecurity.Encoding(Config.DateLimite.Value.ToShortDateString)
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\KeyClientSystemApp\\App\\v1.0")
                Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\KeyClientSystemApp\\App\\v1.0", "KeyTemp", Config.Key)
            End If
        End If
    End Sub

    Public Sub KeyLicense()
        Config.Key = License.GetIlimit
        If Not License.LicenseValidateIlimit Then
            Config.Key = CryptoSecurity.Encoding("Licencia")
            If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\KeyClientSystemApp\\App\\v1.0") Is Nothing Then
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\KeyClientSystemApp\\App\\v1.0")
            End If
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\KeyClientSystemApp\\App\\v1.0", "KeyValue", Config.Key)
        End If
    End Sub

End Module
