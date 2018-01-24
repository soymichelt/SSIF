Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>Información de la Empresa</remarks>
    Partial Public Class Consignacion
        <Key()>
        Public Property IDCONSIGNACION As String

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

        Public Overridable Property DetallesConsignaciones As ICollection(Of DesconsignacionDetalle) = New HashSet(Of DesconsignacionDetalle)

        Public Overridable Property Empleados As Empleado

    End Class

End Namespace
