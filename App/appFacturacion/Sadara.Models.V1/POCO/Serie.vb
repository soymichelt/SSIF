Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Serie

        <Key()>
        Public Property IDSERIE As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property NOMBRE As String

        Public Property DESCRIPCION As String

        Public Property OPERACION As String

        Public Property FACTURA_MANUAL As String

        Public Property TICKET As String

        Public Property IDBODEGA As String

        Public Property ACTIVO As String


        Public Overridable Property Bodega As Bodega

        Public Overridable Property Kardexs As ICollection(Of Kardex) = New HashSet(Of Kardex)

        Public Overridable Property Compras As ICollection(Of Compra) = New HashSet(Of Compra)

        Public Overridable Property ComprasDevoluciones As ICollection(Of CompraDevolucion) = New HashSet(Of CompraDevolucion)

        Public Overridable Property ComprasEstadosCuentas As ICollection(Of CompraEstadoCuenta) = New HashSet(Of CompraEstadoCuenta)

        Public Overridable Property ComprasRecibos As ICollection(Of CompraRecibo) = New HashSet(Of CompraRecibo)

        Public Overridable Property Consignaciones As ICollection(Of Consignacion) = New HashSet(Of Consignacion)

        Public Overridable Property Cotizaciones As ICollection(Of Cotizacion) = New HashSet(Of Cotizacion)

        Public Overridable Property Desconsignaciones As ICollection(Of Desconsignacion) = New HashSet(Of Desconsignacion)

        Public Overridable Property VentasDevoluciones As ICollection(Of VentaDevolucion) = New HashSet(Of VentaDevolucion)

        Public Overridable Property Entradas As ICollection(Of Entrada) = New HashSet(Of Entrada)

        Public Overridable Property VentasEstadosCuentas As ICollection(Of VentaEstadoCuenta) = New HashSet(Of VentaEstadoCuenta)

        Public Overridable Property VentasRecibos As ICollection(Of VentaRecibo) = New HashSet(Of VentaRecibo)

        Public Overridable Property Salidas As ICollection(Of Salida) = New HashSet(Of Salida)

        Public Overridable Property Traslados As ICollection(Of Traslado) = New HashSet(Of Traslado)

        Public Overridable Property Ventas As ICollection(Of Venta) = New HashSet(Of Venta)

    End Class

End Namespace
