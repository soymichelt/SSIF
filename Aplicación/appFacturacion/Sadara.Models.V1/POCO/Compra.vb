Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Compra

        <Key()>
        Public Property IDCOMPRA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property IDSERIE As String

        Public Property CONSECUTIVO As String

        Public Property N_COMPRA As String

        Public Property FORMADEPAGO As String

        Public Property N_PAGO As String

        Public Property EXONERADO As Boolean

        Public Property FECHACOMPRA As Date

        Public Property FECHADEVOLUCION As Date

        Public Property PROVEEDORCONTADO As String

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

        Public Property SUBTOTAL_C As Decimal

        Public Property SUBTOTAL_D As Decimal

        Public Property IVA_POR As Decimal

        Public Property IVA_DIN_C As Decimal

        Public Property IVA_DIN_D As Decimal

        Public Property TOTAL_C As Decimal

        Public Property TOTAL_D As Decimal

        Public Property IDEMPLEADO As String

        Public Property IDPROVEEDOR As String

        Public Property REIMPRESION As String

        Public Property ANULADO As String

        Public Overridable Property Serie As Serie

        Public Overridable Property ComprasDetalles As ICollection(Of CompraDetalle) = New HashSet(Of CompraDetalle)

        Public Overridable Property Empleado As Empleado

        Public Overridable Property Proveedor As Proveedor

        Public Overridable Property ComprasRecibosDetalles As ICollection(Of CompraReciboDetalle) = New HashSet(Of CompraReciboDetalle)

        Public Overridable Property ComprasDevoluciones As ICollection(Of CompraDevolucion) = New HashSet(Of CompraDevolucion)

        Public Overridable Property ComprasPagosProveedores As ICollection(Of CompraEstadoCuenta) = New HashSet(Of CompraEstadoCuenta)

    End Class

End Namespace
