Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class VentaDevolucion
        <Key()>
        Public Property IDDEVOLUCION As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDSERIE As String

        Public Property CONSECUTIVO As String

        Public Property FORMADEPAGO As String

        Public Property N_PAGO As String

        Public Property FECHADEVOLUCION As Date

        Public Property EXONERADO As Boolean

        Public Property CLIENTECONTADO As String

        Public Property CREDITO As Boolean

        Public Property MONEDA As String

        Public Property TAZACAMBIO As Decimal

        Public Property CONCEPTO As String

        Public Property TIPODESCUENTO As String

        Public Property DESCUENTO_POR_FACT As Decimal

        Public Property DESCUENTO_DIN_FACT_C As Decimal

        Public Property DESCUENTO_DIN_FACT_D As Decimal

        Public Property DESCUENTO_DIN_C As Decimal

        Public Property DESCUENTO_DIN_D As Decimal

        Public Property SUBTOTAL_C As Decimal

        Public Property SUBTOTAL_D As Decimal

        Public Property IVA_POR As Decimal

        Public Property IVA_DIN_C As Decimal

        Public Property IVA_DIN_D As Decimal

        Public Property TOTAL_C As Decimal

        Public Property TOTAL_D As Decimal

        Public Property IDEMPLEADO As String

        Public Property IDCLIENTE As String

        Public Property IDVENTA As String

        Public Property REIMPRESION As String

        Public Property ANULADO As String

        Public Property IDTAZA As String


        Public Overridable Property Taza As Taza

        Public Overridable Property Serie As Serie

        Public Overridable Property VentasDevolucionesDetalles As ICollection(Of VentaDevolucionDetalle) = New HashSet(Of VentaDevolucionDetalle)

        Public Overridable Property Venta As Venta

        Public Overridable Property Empleado As Empleado

        Public Overridable Property Cliente As Cliente

    End Class

End Namespace
