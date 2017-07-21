Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class DesconsignacionDetalle
        <Key()>
        Public Property IDDETALLEDESCONSIGNACION As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property EXISTENCIA_PRODUCTO As Decimal

        Public Property EXISTENCIA_SIN_CONSIGNAR As Decimal

        Public Property EXISTENCIA_CONSIGNADA As Decimal

        Public Property CANTIDAD As Decimal

        Public Property IDEXISTENCIA As String

        Public Property IDDESCONSIGNACION As String


        Public Overridable Property Desconsignacion As Desconsignacion

        Public Overridable Property Existencia As Existencia

    End Class

End Namespace
