Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class SalidaDetalle
        <Key()>
        Public Property IDDETALLESALIDA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property EXISTENCIA_PRODUCTO As Decimal

        Public Property CANTIDAD As Decimal

        Public Property CMONEDA As String

        Public Property COSTO As Decimal

        Public Property TOTAL As Decimal

        Public Property IDEXISTENCIA As String

        Public Property IDSALIDA As String


        Public Overridable Property Existencia As Existencia

        Public Overridable Property Salida As Salida

    End Class

End Namespace
