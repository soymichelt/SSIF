Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Taza

        <Key()>
        Public Property IDTAZA As String

        Public Property FECHA As DateTime

        Public Property CAMBIO As Decimal


        Public Overridable Property Compras As ICollection(Of Compra)

        Public Overridable Property Ventas As ICollection(Of Venta)

        Public Overridable Property VentasDevoluciones As ICollection(Of VentaDevolucion)

        Public Overridable Property ComprasDevoluciones As ICollection(Of CompraDevolucion)

        Public Overridable Property VentasRecibos As ICollection(Of VentaRecibo)

        Public Overridable Property ComprasRecibos As ICollection(Of CompraRecibo)

        Public Overridable Property Cotizaciones As ICollection(Of Cotizacion)

    End Class

End Namespace
