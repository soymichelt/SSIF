Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class VentaDetalle
        <Key()>
        Public Property IDDETALLEVENTA As String

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

        Public Property IDVENTA As String

        Public Property PromocionID As Nullable(Of Guid)


        Public Overridable Property Existencia As Existencia

        Public Overridable Property Venta As Venta

        'Public Overridable Property VENTAS_VENCIMIENTOS As ICollection(Of VENTA_VENCIMIENTO)

    End Class

End Namespace
