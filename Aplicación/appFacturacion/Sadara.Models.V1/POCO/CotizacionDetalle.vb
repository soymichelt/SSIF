Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class CotizacionDetalle
        <Key()>
        Public Property IDDETALLECOTIZACION As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property CMONEDA As String

        Public Property COSTO As Decimal

        Public Property EXISTENCIA_PRODUCTO As Decimal

        Public Property CANTIDAD As Decimal

        Public Property PRECIOUNITARIO_C As Decimal

        Public Property PRECIOUNITARIO_D As Decimal

        Public Property DESCUENTO_POR As Decimal

        Public Property DESCUENTO_DIN_C As Decimal

        Public Property DESCUENTO_DIN_D As Decimal

        Public Property DESCUENTO_DIN_TOTAL_C As Decimal

        Public Property DESCUENTO_DIN_TOTAL_D As Decimal

        Public Property PRECIONETO_C As Decimal

        Public Property PRECIONETO_D As Decimal

        Public Property SUBTOTAL_C As Decimal

        Public Property SUBTOTAL_D As Decimal

        Public Property IVA_POR As Decimal

        Public Property IVA_DIN_C As Decimal

        Public Property IVA_DIN_D As Decimal

        Public Property IVA_DIN_TOTAL_C As Decimal

        Public Property IVA_DIN_TOTAL_D As Decimal

        Public Property TOTAL_C As Decimal

        Public Property TOTAL_D As Decimal

        Public Property IDEXISTENCIA As String

        Public Property IDCOTIZACION As String


        Public Overridable Property Cotizacion As Cotizacion

        Public Overridable Property Existencia As Existencia

    End Class

End Namespace
