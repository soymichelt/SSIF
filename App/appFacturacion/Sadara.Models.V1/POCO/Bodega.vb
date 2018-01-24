Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' Bodega
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Bodega

        <Key()>
        Public Property IDBODEGA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property N_BODEGA As String

        Public Property DESCRIPCION As String

        Public Property ACTIVO As String


        Public Overridable Property Series As ICollection(Of Serie) = New HashSet(Of Serie)

        Public Overridable Property Existencias As ICollection(Of Existencia) = New HashSet(Of Existencia)

        Public Overridable Property Traslados As ICollection(Of Traslado) = New HashSet(Of Traslado)

    End Class

End Namespace
