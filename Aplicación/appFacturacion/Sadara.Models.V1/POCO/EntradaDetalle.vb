Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class EntradaDetalle
        <Key()>
        Public Property IDDETALLEENTRADA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property EXISTENCIA_PRODUCTO As Decimal

        Public Property CANTIDAD As Decimal

        Public Property CMONEDA As String

        Public Property COSTO As Decimal

        Public Property TOTAL As Decimal

        Public Property IDEXISTENCIA As String

        Public Property IDENTRADA As String


        Public Overridable Property Entrada As Entrada

        Public Overridable Property Existencia As Existencia

    End Class

End Namespace
