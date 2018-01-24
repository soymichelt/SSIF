Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Empleado
        <Key()>
        Public Property IDEMPLEADO As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property N_TRABAJADOR As String

        Public Property IDENTIFICACION As String

        Public Property NOMBRES As String

        Public Property APELLIDOS As String

        Public Property TELEFONO As String

        Public Property CORREO As String

        Public Property DOMICILIO As String

        Public Property SEXO As String

        Public Property VENTA As Boolean

        Public Property COMPRA As Boolean

        Public Property CONTABILIDAD As Boolean

        Public Property INVENTARIO As Boolean

        Public Property OBSERVACION As String

        Public Property ACTIVO As String


        Public Overridable Property Cotizaciones As ICollection(Of Cotizacion) = New HashSet(Of Cotizacion)

        Public Overridable Property Ventas As ICollection(Of Venta) = New HashSet(Of Venta)

        Public Overridable Property VentasDevoluciones As ICollection(Of VentaDevolucion) = New HashSet(Of VentaDevolucion)

        Public Overridable Property Consignaciones As ICollection(Of Consignacion) = New HashSet(Of Consignacion)

        Public Overridable Property Desconsignaciones As ICollection(Of Desconsignacion) = New HashSet(Of Desconsignacion)

        Public Overridable Property Compras As ICollection(Of Compra) = New HashSet(Of Compra)

        Public Overridable Property ComprasDevoluciones As ICollection(Of CompraDevolucion) = New HashSet(Of CompraDevolucion)

        Public Overridable Property Entradas As ICollection(Of Entrada) = New HashSet(Of Entrada)

        Public Overridable Property Salidas As ICollection(Of Salida) = New HashSet(Of Salida)

        Public Overridable Property Traslados As ICollection(Of Traslado) = New HashSet(Of Traslado)

        Public Overridable Property VentasRecibos As ICollection(Of VentaRecibo) = New HashSet(Of VentaRecibo)

        Public Overridable Property ComprasRecibos As ICollection(Of CompraRecibo) = New HashSet(Of CompraRecibo)

    End Class

End Namespace
