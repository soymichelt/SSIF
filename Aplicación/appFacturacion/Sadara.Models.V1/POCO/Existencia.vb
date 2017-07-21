Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Existencia

        <Key()>
        Public Property IDEXISTENCIA As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property CANTIDAD As Decimal

        Public Property CONSIGNADO As Decimal

        Public Property IDBODEGA As String

        Public Property IDPRODUCTO As String


        Public Overridable Property Bodega As Bodega

        Public Overridable Property ComprasDetalles As ICollection(Of CompraDetalle) = New HashSet(Of CompraDetalle)

        Public Overridable Property ConsignacionesDetalles As ICollection(Of ConsignacionDetalle) = New HashSet(Of ConsignacionDetalle)

        Public Overridable Property CotizacionesDetalles As ICollection(Of CotizacionDetalle) = New HashSet(Of CotizacionDetalle)

        Public Overridable Property DesconsignacionesDetalles As ICollection(Of DesconsignacionDetalle) = New HashSet(Of DesconsignacionDetalle)

        Public Overridable Property VentasDevolucionesDetalles As ICollection(Of VentaDevolucionDetalle) = New HashSet(Of VentaDevolucionDetalle)

        Public Overridable Property EntradasDetalles As ICollection(Of EntradaDetalle) = New HashSet(Of EntradaDetalle)

        Public Overridable Property SalidasDetalles As ICollection(Of SalidaDetalle) = New HashSet(Of SalidaDetalle)

        Public Overridable Property TrasladosDetalles As ICollection(Of TrasladoDetalle) = New HashSet(Of TrasladoDetalle)

        Public Overridable Property VentasDetalles As ICollection(Of VentaDetalle) = New HashSet(Of VentaDetalle)

        Public Overridable Property Kardexs As ICollection(Of Kardex) = New HashSet(Of Kardex)

        Public Overridable Property Producto As Producto

        Public Overridable Property ComprasDevolucionesDetalles As ICollection(Of CompraDevolucionDetalle) = New HashSet(Of CompraDevolucionDetalle)

        'Promociones
        Public Overridable Property PromocionesExistencias As ICollection(Of PromocionExistencia)

    End Class

End Namespace
