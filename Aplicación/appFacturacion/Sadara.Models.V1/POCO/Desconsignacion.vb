Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Desconsignacion
        <Key()>
        Public Property IDDESCONSIGNACION As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDSERIE As String

        Public Property CONSECUTIVO As String

        Public Property FECHACONSIGNACION As Date

        Public Property OBSERVACION As String

        Public Property TOTAL As Decimal

        Public Property IDEMPLEADO As String

        Public Property IDCLIENTE As String

        Public Property REIMPRESION As String

        Public Property ANULADO As String


        Public Overridable Property Serie As Serie

        Public Overridable Property Cliente As Cliente

        Public Overridable Property DesconsignacionesDetalles As ICollection(Of DesconsignacionDetalle) = New HashSet(Of DesconsignacionDetalle)

        Public Overridable Property Empleado As Empleado

    End Class

End Namespace
