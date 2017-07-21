Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Marca

        <Key()>
        Public Property IDMARCA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property DESCRIPCION As String

        Public Property ACTIVO As String


        Public Overridable Property Productos As ICollection(Of Producto) = New HashSet(Of Producto)

    End Class

End Namespace
