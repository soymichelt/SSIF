Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Traslado

        <Key()>
        Public Property IDTRASLADO As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDSERIE As String

        Public Property CONSECUTIVO As String

        Public Property FECHATRASLADO As Date

        Public Property IDBODEGA As String

        Public Property CONCEPTO As String

        Public Property REFERENCIA As String

        Public Property TOTAL As Decimal

        Public Property IDEMPLEADO As String

        Public Property REIMPRESION As String

        Public Property ANULADO As String


        Public Overridable Property Serie As Serie

        Public Overridable Property Bodega As Bodega

        Public Overridable Property TrasladosDetalles As ICollection(Of TrasladoDetalle) = New HashSet(Of TrasladoDetalle)

        Public Overridable Property Empleado As Empleado

    End Class

End Namespace
