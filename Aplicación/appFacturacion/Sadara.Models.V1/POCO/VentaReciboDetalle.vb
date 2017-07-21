Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class VentaReciboDetalle
        <Key()>
        Public Property IDDETALLERECIBO As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property IDVENTA As String

        Public Property SALDOCREDITO As Decimal

        Public Property OPERACION As String

        Public Property IMPORTE_C As Decimal

        Public Property IMPORTE_D As Decimal

        Public Property DESCUENTO_C As Decimal

        Public Property DESCUENTO_D As Decimal

        Public Property NUEVO_SALDO_C As Decimal

        Public Property NUEVO_SALDO_D As Decimal

        Public Property IDRECIBO As String


        Public Overridable Property Venta As Venta

        Public Overridable Property Recibo As VentaRecibo
    End Class

End Namespace
