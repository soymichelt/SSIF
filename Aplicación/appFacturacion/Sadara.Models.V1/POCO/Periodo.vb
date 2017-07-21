Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Periodo

        <Key()>
        Public Property IDPERIODO As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property INICIO As DateTime

        Public Property FINAL As DateTime

        Public Property APERTURA As Nullable(Of DateTime)

        Public Property CIERRE As Nullable(Of DateTime)

        Public Property ACTUAL As String

        Public Property ACTIVO As String

    End Class

End Namespace
