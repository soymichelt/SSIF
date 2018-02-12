Imports System.Security.Cryptography
Imports System.Text
Friend Class CryptoSecurity

    Public Shared ReadOnly Property KeyProp() As String
        Get
            Return KeyConfig.KeyRSA
        End Get
    End Property

    Public Shared UTF8 As UTF8Encoding
    Private Shared Converter As New UnicodeEncoding

    Public Shared Function Encoding(ByVal ValText As String) As String
        Using RSA As New RSACryptoServiceProvider
            RSA.FromXmlString(KeyConfig.KeyPublic)
            Return Convert.ToBase64String(RSA.Encrypt(CryptoSecurity.Converter.GetBytes(ValText), False))
        End Using
    End Function

    Public Shared Function Decoding(ByVal ValText As String) As String
        Using RSA As New RSACryptoServiceProvider
            RSA.FromXmlString(KeyConfig.KeyPrivate)
            Return Converter.GetString(RSA.Decrypt(Convert.FromBase64String(ValText), False))
        End Using
    End Function
End Class