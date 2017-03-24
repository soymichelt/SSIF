Imports System.Security.Cryptography
Imports System.Text
Friend Class CryptoSecurity

    Private Shared KeyValue As String = "5483*+/-"

    Public Shared ReadOnly Property KeyProp() As String
        Get
            Return CryptoSecurity.KeyValue
        End Get
    End Property


    Public Shared UTF8 As UTF8Encoding
    Private Shared Converter As New UnicodeEncoding

    Private Shared KeyPublic As String = "<RSAKeyValue><Modulus>ttY+aX9GRyQ64/nX4nKrdq2gtm+bR6gXokKmpUzVxqNgM7wG3APQKyceXQKb9v4FkC4tNsvj8UhzoIULG5/iiWGVsBV9Yl63u5rm/epMxHLpEc5Z/8ALnwUgWS5d9pnLzMbjoptAho6g7D98RMxrti1HvJ+HitfSLHQUh3sYH8M=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
    Private Shared KeyPrivate As String = "<RSAKeyValue><Modulus>ttY+aX9GRyQ64/nX4nKrdq2gtm+bR6gXokKmpUzVxqNgM7wG3APQKyceXQKb9v4FkC4tNsvj8UhzoIULG5/iiWGVsBV9Yl63u5rm/epMxHLpEc5Z/8ALnwUgWS5d9pnLzMbjoptAho6g7D98RMxrti1HvJ+HitfSLHQUh3sYH8M=</Modulus><Exponent>AQAB</Exponent><P>84uIbWIhgXAmKoSLm15cGrXl3yrwuZmUc7VhCWe7Kz5dSFz+N+i6FH4b54JTTFZAnRfiL7rHlBv8DaWiN0neUQ==</P><Q>wC/tAUx3vHEYISvdcft1WaV2eyzxB44hvTiOG0mAbLQ6n+rsL1abEK1jvAXHoiADeH1HjOnJE3BYRhpGMX/z0w==</Q><DP>6e17dD1Om4qCTlKT2f9vjoRrMMmJAW0AB4gPlb4aLLYxWYFg+YjDu01KNjubEPbEB2BadKf+bUfX+a+/uUVtkQ==</DP><DQ>s7NcWc2FW9cnp8SbP/vO427alRwVl2nn1EUwYwVcJshy1JrWEwFY5sQpsGJ7IvXqKNyDbZgf4qQ2df4VSi2I7w==</DQ><InverseQ>pDKz330t+pVCf5/a3JBMsG5rnjDehuo8oSQWrc6PIdisaG8rg6MkbNdPKakd28axdZW3//DyA7cduUqauuXfYA==</InverseQ><D>nF30eKM6BoPMvcaiRG+PhusNZJlkss7mj4XzIbHprn1xPC2VrDqyoQVOqXseygkL1vg3AQM1CdjN0r2V92UxBpq/5aNdfJPR/M9vPbcNLJZZuZLicKbaYfiAuUFW8YSuL9ImWU5Yqtqna2ChW+ERFieAOLFEL3ZzdViJJpYwU6E=</D></RSAKeyValue>"

    Public Shared Function Encoding(ByVal ValText As String) As String
        'Using EncripSha1 As New SHA1CryptoServiceProvider
        '    'Return Convert.ToBase64String(EncripSha1.ComputeHash((New UnicodeEncoding).GetBytes(strPass)))
        'End Using
        'Using varRSA As New RSACryptoServiceProvider
        '    Return Convert.ToBase64String(varRSA.Encrypt(HashSecurity.UTF8.GetBytes(strPass), False))
        'End Using

        'Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("7361*/-+") 'La clave debe ser de 8 caracteres
        'Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        'Dim buffer() As Byte = Encoding.UTF8.GetBytes(ValText)
        'Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        'des.Key = EncryptionKey
        'des.IV = IV
        'Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

        Using RSA As New RSACryptoServiceProvider
            RSA.FromXmlString(CryptoSecurity.KeyPublic)
            Return Convert.ToBase64String(RSA.Encrypt(CryptoSecurity.Converter.GetBytes(ValText), False))
        End Using
    End Function

    Public Shared Function Decoding(ByVal ValText As String) As String
        'Using varRSA As New RSACryptoServiceProvider
        '    Return HashSecurity.UTF8.GetString(varRSA.Decrypt(Convert.FromBase64String(strPassEncode), False))
        'End Using

        'Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("7361*/-+") 'La clave debe ser de 8 caracteres
        'Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        'Dim buffer() As Byte = Convert.FromBase64String(ValText)
        'Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        'des.Key = EncryptionKey
        'des.IV = IV
        'Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

        Using RSA As New RSACryptoServiceProvider
            RSA.FromXmlString(CryptoSecurity.KeyPrivate)
            Return Converter.GetString(RSA.Decrypt(Convert.FromBase64String(ValText), False))
        End Using
    End Function
End Class