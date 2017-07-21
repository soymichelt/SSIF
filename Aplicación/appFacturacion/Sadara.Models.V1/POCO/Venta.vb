Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Venta

        <Key()>
        Public Property IDVENTA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDSERIE As String

        Public Property CONSECUTIVO As String

        Public Property FORMADEPAGO As String

        Public Property N_PAGO As String

        Public Property EXONERADO As Boolean

        Public Property FECHAFACTURA As Date

        Public Property CLIENTECONTADO As String

        Public Property CREDITO As Boolean

        Public Property FECHACREDITOVENCIMIENTO As Date

        Public Property SALDOCREDITO As Decimal

        Public Property MONEDA As String

        Public Property TAZACAMBIO As Decimal

        Public Property CONCEPTO As String

        Public Property TIPODESCUENTO As String

        Public Property DESCUENTO_POR_FACT As Decimal

        Public Property DESCUENTO_DIN_FACT_C As Decimal

        Public Property DESCUENTO_DIN_FACT_D As Decimal

        Public Property DESCUENTO_DIN_C As Decimal

        Public Property DESCUENTO_DIN_D As Decimal

        Public Property COSTO_TOTAL As Decimal

        Public Property SUBTOTAL_C As Decimal

        Public Property SUBTOTAL_D As Decimal

        Public Property IVA_POR As Decimal

        Public Property IVA_DIN_C As Decimal

        Public Property IVA_DIN_D As Decimal

        Public Property TOTAL_C As Decimal

        Public Property TOTAL_D As Decimal

        Public Property IDEMPLEADO As String

        Public Property IDCLIENTE As String

        Public Property REIMPRESION As String

        Public Property ANULADO As String

        Public Property IDTAZA As String


        Public Overridable Property Taza As Taza

        Public Overridable Property Serie As Serie

        Public Overridable Property Cliente As Cliente

        Public Overridable Property VentasDetalles As ICollection(Of VentaDetalle) = New HashSet(Of VentaDetalle)

        Public Overridable Property Empleado As Empleado

        Public Overridable Property VentasRecibosDetalles As ICollection(Of VentaReciboDetalle) = New HashSet(Of VentaReciboDetalle)

        Public Overridable Property VentasDevoluciones As ICollection(Of VentaDevolucion) = New HashSet(Of VentaDevolucion)

        Public Overridable Property VentasEstadosCuentas As ICollection(Of VentaEstadoCuenta) = New HashSet(Of VentaEstadoCuenta)

    End Class

End Namespace
