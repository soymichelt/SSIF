Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' Empresa
    ''' </summary>
    ''' <remarks>Información de la Empresa</remarks>
    Partial Public Class CompraReciboDetalle
        <Key()>
        Public Property IDDETALLERECIBO As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDCOMPRA As String

        Public Property SALDOCREDITO As Decimal

        Public Property OPERACION As String

        Public Property IMPORTE_C As Decimal

        Public Property IMPORTE_D As Decimal

        Public Property DESCUENTO_C As Decimal

        Public Property DESCUENTO_D As Decimal

        Public Property NUEVO_SALDO_C As Decimal

        Public Property NUEVO_SALDO_D As Decimal

        Public Property IDRECIBO As String

        Public Overridable Property Compra As Compra

        Public Overridable Property CompraRecibo As CompraRecibo
    End Class

End Namespace
