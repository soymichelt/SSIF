Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' Empresa
    ''' </summary>
    ''' <remarks>Información de la Empresa</remarks>
    Public Class Empresa

        <Key()>
        Public Property IdEmpresa As Guid

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property Nombre As String

        Public Property RUC As String

        Public Property Telefono1 As String

        Public Property Telefono2 As String

        Public Property Direccion As String

        Public Property MonedaInventario As String

    End Class

End Namespace
