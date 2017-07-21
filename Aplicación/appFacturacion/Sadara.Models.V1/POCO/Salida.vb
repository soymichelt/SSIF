Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Salida

        <Key()>
        Public Property IDSALIDA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDSERIE As String

        Public Property CONSECUTIVO As String

        Public Property FECHASALIDA As Date

        Public Property OBSERVACION As String

        Public Property TOTAL As Decimal

        Public Property IDEMPLEADO As String

        Public Property REIMPRESION As String

        Public Property ANULADO As String


        Public Overridable Property Serie As Serie

        Public Overridable Property SalidasDetalles As ICollection(Of SalidaDetalle) = New HashSet(Of SalidaDetalle)

        Public Overridable Property Empleado As Empleado

    End Class

End Namespace

