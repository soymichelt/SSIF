Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class ConsignacionDetalle

        <Key()>
        Public Property IDDETALLECONSIGNACION As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property EXISTENCIA_PRODUCTO As Decimal

        Public Property EXISTENCIA_SIN_CONSIGNAR As Decimal

        Public Property EXISTENCIA_CONSIGNADA As Decimal

        Public Property CANTIDAD As Decimal

        Public Property IDEXISTENCIA As String

        Public Property IDCONSIGNACION As String


        Public Overridable Property Consignacion As Consignacion

        Public Overridable Property Existencia As Existencia

    End Class

End Namespace
