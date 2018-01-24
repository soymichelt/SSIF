Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Entrada
        <Key()>
        Public Property IDENTRADA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDSERIE As String

        Public Property CONSECUTIVO As String

        Public Property FECHAENTRADA As Date

        Public Property OBSERVACION As String

        Public Property TOTAL As Decimal

        Public Property IDEMPLEADO As String

        Public Property REIMPRESION As String

        Public Property ANULADO As String

        Public Overridable Property Serie As Serie

        Public Overridable Property EntradasDetalles As ICollection(Of EntradaDetalle) = New HashSet(Of EntradaDetalle)

        Public Overridable Property Empleado As Empleado

    End Class

End Namespace
