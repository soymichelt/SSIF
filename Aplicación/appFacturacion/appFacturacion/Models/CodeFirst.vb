#Region "Nombres de Espacio"
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Data.Entity
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
#End Region

#Region "Modelo POCO"
'MÓDULO DE INVENTARIO
Public Class Empresa
    <Key()>
    Public Property IdEmpresa As Guid
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property Nombre As String
    Public Property RUC As String
    Public Property Telefono1 As String
    Public Property Telefono2 As String
    Public Property Direccion As String
    Public Property MonedaInventario As String
End Class

Public Class Bodega
    <Key()>
    Public Property IDBODEGA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property N_BODEGA As String
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property Series As ICollection(Of Serie) = New HashSet(Of Serie)
    Public Overridable Property Existencias As ICollection(Of Existencia) = New HashSet(Of Existencia)
    Public Overridable Property Traslados As ICollection(Of Traslado) = New HashSet(Of Traslado)

End Class

Partial Public Class Cliente
    <Key()>
    Public Property IDCLIENTE As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property N_CLIENTE As String
    Public Property IDENTIFICACION As String
    Public Property TIPOPERSONA As String
    Public Property NOMBRES As String
    Public Property APELLIDOS As String
    Public Property RAZONSOCIAL As String
    Public Property TELEFONO As String
    Public Property DOMICILIO As String
    Public Property SEXO As String
    Public Property CORREO As String
    Public Property MONEDA As String
    Public Property LIMITECREDITO As Decimal
    Public Property PLAZO As Integer
    Public Property FACTURADO_C As Decimal
    Public Property FACTURADO_D As Decimal
    Public Property ACTIVO As String
    'Public Property IDCIUDAD As String

    Public Overridable Property Cotizaciones As ICollection(Of Cotizacion) = New HashSet(Of Cotizacion)
    Public Overridable Property Ventas As ICollection(Of Venta) = New HashSet(Of Venta)
    Public Overridable Property Consignaciones As ICollection(Of Consignacion) = New HashSet(Of Consignacion)
    Public Overridable Property Desconsignaciones As ICollection(Of Desconsignacion) = New HashSet(Of Desconsignacion)
    Public Overridable Property Recibos As ICollection(Of VentaRecibo) = New HashSet(Of VentaRecibo)

    'Public Overridable Property CIUDAD As CIUDAD
End Class

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

Partial Public Class CompraDevolucion
    <Key()>
    Public Property IDDEVOLUCION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property N_DEVOLUCION As String
    Public Property FORMADEPAGO As String
    Public Property N_PAGO As String
    Public Property FECHADEVOLUCION As Date
    Public Property EXONERADO As Boolean
    Public Property PROVEEDORCONTADO As String
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
    Public Property IDPROVEEDOR As String
    Public Property IDCOMPRA As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property Serie As Serie
    Public Overridable Property ComprasDevolucionesDetalles As ICollection(Of CompraDevolucionDetalle) = New HashSet(Of CompraDevolucionDetalle)
    Public Overridable Property Compra As Compra
    Public Overridable Property Proveedor As Proveedor
    Public Overridable Property Empleado As Empleado

End Class

Partial Public Class CompraDevolucionDetalle
    <Key()>
    Public Property IDDETALLEDEVOLUCION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property CMONEDA As String
    Public Property COSTO As Decimal
    Public Property EXISTENCIA_PRODUCTO As Decimal
    Public Property CANTIDAD_DEVUELTA As Decimal
    Public Property PRECIOMONEDAORIGINAL As Decimal
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
    Public Property IDDEVOLUCION As String

    Public Overridable Property Existencia As Existencia
    Public Overridable Property CompraDevolucion As CompraDevolucion

End Class

Partial Public Class CompraEstadoCuenta

    <Key()>
    Public Property IDESTADO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property N_DOCUMENTO As String
    Public Property N_COMPRA As String
    Public Property FORMADEPAGO As String
    Public Property N_PAGO As String
    Public Property OPERACION As String
    Public Property FECHA As DateTime
    Public Property PLAZO As Integer
    Public Property FECHAVENCIMIENTO As Nullable(Of DateTime)
    Public Property MONEDA As String
    Public Property TAZACAMBIO As Decimal
    Public Property DEBE_C As Decimal
    Public Property DEBE_D As Decimal
    Public Property HABER_C As Decimal
    Public Property HABER_D As Decimal
    Public Property IDCOMPRA As String
    Public Property IDRECIBO As String
    Public Property IDDEVOLUCION As String
    Public Property ACTIVO As String

    Public Overridable Property Serie As Serie
    Public Property Compra As Compra
    Public Property CompraRecibo As CompraRecibo

End Class

Partial Public Class CompraRecibo
    <Key()>
    Public Property IDRECIBO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property N_DOCUMENTO As String
    Public Property FORMADEPAGO As String
    Public Property N_PAGO As String
    Public Property FECHARECIBO As Date
    Public Property MONEDA As String
    Public Property TAZACAMBIO As Decimal
    Public Property CONCEPTO As String
    Public Property IMPORTETOTAL_C As Decimal
    Public Property IMPORTETOTAL_D As Decimal
    Public Property DESCUENTOTOTAL_C As Decimal
    Public Property DESCUENTOTOTAL_D As Decimal
    Public Property SOBRANTEDECAJA_C As Decimal
    Public Property SOBRANTEDECAJA_D As Decimal
    Public Property MONTOTOTAL_C As Decimal
    Public Property MONTOTOTAL_D As Decimal
    Public Property REIMPRESION As String
    Public Property IDEMPLEADO As String
    Public Property IDPROVEEDOR As String
    Public Property ANULADO As String

    Public Overridable Property Serie As Serie
    Public Overridable Property ComprasRecibosDetalles As ICollection(Of CompraReciboDetalle) = New HashSet(Of CompraReciboDetalle)
    Public Overridable Property ComprasEstadosCuentas As ICollection(Of CompraEstadoCuenta) = New HashSet(Of CompraEstadoCuenta)
    Public Overridable Property Empleado As Empleado
    Public Overridable Property Proveedor As Proveedor
End Class

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

Partial Public Class Consignacion
    <Key()>
    Public Property IDCONSIGNACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHACONSIGNACION As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property IDEMPLEADO As String
    Public Property IDCLIENTE As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property Serie As Serie
    Public Overridable Property Cliente As Cliente
    Public Overridable Property DetallesConsignaciones As ICollection(Of DesconsignacionDetalle) = New HashSet(Of DesconsignacionDetalle)
    Public Overridable Property Empleados As Empleado
End Class

Partial Public Class Cotizacion
    <Key()>
    Public Property IDCOTIZACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FORMADEPAGO As String
    Public Property N_PAGO As String
    Public Property FECHACOTIZACION As Date
    Public Property EXONERADO As Boolean
    Public Property CLIENTECONTADO As String
    Public Property CREDITO As Boolean
    Public Property FECHACREDITOVENCIMIENTO As Date
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
    Public Property IDTAZA As String
    Public Property ANULADO As String

    Public Overridable Property Taza As Taza
    Public Overridable Property Serie As Serie
    Public Overridable Property Cliente As Cliente
    Public Overridable Property CotizacionesDetalles As ICollection(Of CotizacionDetalle) = New HashSet(Of CotizacionDetalle)
    Public Overridable Property Empleado As Empleado

End Class

Partial Public Class Desconsignacion
    <Key()>
    Public Property IDDESCONSIGNACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHACONSIGNACION As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property IDEMPLEADO As String
    Public Property IDCLIENTE As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property Serie As Serie
    Public Overridable Property Cliente As Cliente
    Public Overridable Property DesconsignacionesDetalles As ICollection(Of DesconsignacionDetalle) = New HashSet(Of DesconsignacionDetalle)
    Public Overridable Property Empleado As Empleado
End Class

Partial Public Class CompraDetalle
    <Key()>
    Public Property IDDETALLECOMPRA As String
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
    Public Property IDCOMPRA As String

    Public Overridable Property Compra As Compra
    Public Overridable Property Existencia As Existencia

End Class

Partial Public Class ConsignacionDetalle
    <Key()>
    Public Property IDDETALLECONSIGNACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property EXISTENCIA_PRODUCTO As Decimal
    Public Property EXISTENCIA_SIN_CONSIGNAR As Decimal
    Public Property EXISTENCIA_CONSIGNADA As Decimal
    Public Property CANTIDAD As Decimal
    Public Property IDEXISTENCIA As String
    Public Property IDCONSIGNACION As String

    Public Overridable Property Consignacion As Consignacion
    Public Overridable Property Existencia As Existencia
End Class

Partial Public Class CotizacionDetalle
    <Key()>
    Public Property IDDETALLECOTIZACION As String
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
    Public Property IDCOTIZACION As String

    Public Overridable Property Cotizacion As Cotizacion
    Public Overridable Property Existencia As Existencia
End Class

Partial Public Class DesconsignacionDetalle
    <Key()>
    Public Property IDDETALLEDESCONSIGNACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property EXISTENCIA_PRODUCTO As Decimal
    Public Property EXISTENCIA_SIN_CONSIGNAR As Decimal
    Public Property EXISTENCIA_CONSIGNADA As Decimal
    Public Property CANTIDAD As Decimal
    Public Property IDEXISTENCIA As String
    Public Property IDDESCONSIGNACION As String

    Public Overridable Property Desconsignacion As Desconsignacion
    Public Overridable Property Existencia As Existencia
End Class

Partial Public Class VentaDevolucionDetalle
    <Key()>
    Public Property IDDETALLEDEVOLUCION As String
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
    Public Property IDDEVOLUCION As String

    Public Overridable Property Existencia As Existencia
    Public Overridable Property VentaDevolucion As VentaDevolucion

End Class

Partial Public Class EntradaDetalle
    <Key()>
    Public Property IDDETALLEENTRADA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property EXISTENCIA_PRODUCTO As Decimal
    Public Property CANTIDAD As Decimal
    Public Property CMONEDA As String
    Public Property COSTO As Decimal
    Public Property TOTAL As Decimal
    Public Property IDEXISTENCIA As String
    Public Property IDENTRADA As String

    Public Overridable Property Entrada As Entrada
    Public Overridable Property Existencia As Existencia

End Class

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

Partial Public Class SalidaDetalle
    <Key()>
    Public Property IDDETALLESALIDA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property EXISTENCIA_PRODUCTO As Decimal
    Public Property CANTIDAD As Decimal
    Public Property CMONEDA As String
    Public Property COSTO As Decimal
    Public Property TOTAL As Decimal
    Public Property IDEXISTENCIA As String
    Public Property IDSALIDA As String

    Public Overridable Property Existencia As Existencia
    Public Overridable Property Salida As Salida

End Class

Partial Public Class TrasladoDetalle
    <Key()>
    Public Property IDDETALLETRASLADO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property EXISTENCIA_PRODUCTO As Decimal
    Public Property EXISTENCIAEXTERNA As Decimal
    Public Property CANTIDAD As Decimal
    Public Property CMONEDA As String
    Public Property COSTO As Decimal
    Public Property TOTAL As Decimal
    Public Property IDEXISTENCIA As String
    Public Property IDTRASLADO As String

    Public Overridable Property Existencia As Existencia
    Public Overridable Property Traslado As Traslado

End Class

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

Partial Public Class Entrada
    <Key()>
    Public Property IDENTRADA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHAENTRADA As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property IDEMPLEADO As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property Serie As Serie
    Public Overridable Property EntradasDetalles As ICollection(Of EntradaDetalle) = New HashSet(Of EntradaDetalle)
    Public Overridable Property Empleado As Empleado
End Class

Partial Public Class VentaEstadoCuenta
    <Key()>
    Public Property IDESTADO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property N_DOCUMENTO As String
    Public Property FORMADEPAGO As String
    Public Property N_PAGO As String
    Public Property OPERACION As String
    Public Property FECHA As DateTime
    Public Property PLAZO As Integer
    Public Property FECHAVENCIMIENTO As Nullable(Of DateTime)
    Public Property MONEDA As String
    Public Property TAZACAMBIO As Decimal
    Public Property DEBE_C As Decimal
    Public Property DEBE_D As Decimal
    Public Property HABER_C As Decimal
    Public Property HABER_D As Decimal
    Public Property IDVENTA As String
    Public Property IDRECIBO As String
    Public Property IDDEVOLUCION As String
    Public Property ACTIVO As String
    Public Property IDTAZA As String

    Public Overridable Property Taza As Taza
    Public Overridable Property Serie As Serie
    Public Overridable Property Venta As Venta
    Public Overridable Property Recibo As VentaRecibo
    Public Overridable Property VentaDevolucion As VentaDevolucion
End Class

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

Partial Public Class Kardex
    <Key()>
    Public Property IDKARDEX As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDEXISTENCIA As String
    Public Property IDSERIE As String
    Public Property N_DOCUMENTO As String
    Public Property FECHADOCUMENTO As Date
    Public Property OPERACION As String
    Public Property DESCRIPCION As String
    Public Property MONEDA As String
    Public Property TAZACAMBIO As Decimal
    Public Property ENTRADA As Decimal
    Public Property SALIDA As Decimal
    Public Property EXISTENCIA_ANTERIOR As Decimal
    Public Property EXISTENCIA_ALMACEN As Decimal
    Public Property CMONEDA As String
    Public Property COSTO As Decimal
    Public Property COSTO_PROMEDIO As Decimal
    Public Property PRECIO_C As Decimal
    Public Property PRECIO_D As Decimal
    Public Property DEBER As Decimal
    Public Property HABER As Decimal
    Public Property SALDO As Decimal
    Public Property ACTIVO As String

    Public Overridable Property Existencia As Existencia
    Public Overridable Property Serie As Serie

End Class

Partial Public Class Marca

    <Key()>
    Public Property IDMARCA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property Productos As ICollection(Of Producto) = New HashSet(Of Producto)

End Class

Public Class Promocion

    <Key()>
    Public Property PromocionID As Guid

    Public Property DescripcionPromocion As String

    Public Property FechaInicioPromocion As DateTime

    Public Property FechaFinalPromocion As DateTime

    Public Overridable Property PromocionesExistencias As ICollection(Of PromocionExistencia)

End Class

Public Class PromocionExistencia

    <Key()>
    Public Property PromocionExistenciaID As Guid

    Public Property Descuento As Decimal

    Public Property Cantidad As Decimal

    Public Property PromocionID As Guid

    Public Property IDEXISTENCIA As String

    Public Property Promocion As Promocion

    Public Property Existencia As Existencia

End Class


Partial Public Class Producto
    <Key()>
    Public Property IDPRODUCTO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDALTERNO As String
    Public Property IDORIGINAL As String
    Public Property IDMARCA As String
    Public Property DESCRIPCION As String
    Public Property MODELO As String
    Public Property APLICACION As String
    Public Property OBSERVACION As String
    Public Property COSTO As Decimal
    Public Property IDUNIDAD As String
    Public Property CONTIENE As Decimal
    Public Property MARGEN As Boolean
    Public Property CMONEDA As String
    Public Property PRECIO1 As Decimal
    Public Property PRECIO2 As Decimal
    Public Property PRECIO3 As Decimal
    Public Property PRECIO4 As Decimal
    Public Property FACTURAR_PRECIO As Short
    Public Property IVA As Boolean
    Public Property FACTURAR_NEGATIVO As Boolean
    Public Property CANTIDAD_MINIMA As Decimal
    Public Property CANTIDAD_MAXIMA As Decimal


    Public Property PromocionInicio As Nullable(Of DateTime)
    Public Property PromocionFinal As Nullable(Of DateTime)
    Public Property Descuento As Decimal

    Public Property IDPRESENTACION As String
    Public Property IDLABORATORIO As String
    Public Property IDPROVEEDOR As String
    Public Property IMAGENAME As String
    Public Property UBICACIONFISICA As String
    Public Property CANTIDAD As Decimal
    Public Property SALDO As Decimal
    Public Property ACTIVO As String

    Public Overridable Property Existencias As ICollection(Of Existencia) = New HashSet(Of Existencia)
    Public Overridable Property Marca As Marca
    Public Overridable Property Presentacion As Presentacion
    Public Overridable Property UnidadMedida As UnidadMedida
    Public Overridable Property Laboratorio As Laboratorio
    Public Overridable Property Proveedor As Proveedor
End Class

Public Class Presentacion
    <Key()>
    Public Property IDPRESENTACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property Productos As ICollection(Of Producto) = New HashSet(Of Producto)
End Class

Public Class Laboratorio
    <Key()>
    Public Property IDLABORATORIO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property Productos As ICollection(Of Producto) = New HashSet(Of Producto)
End Class

Public Class UnidadMedida
    <Key()>
    Public Property IDUNIDAD As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property Productos As ICollection(Of Producto) = New HashSet(Of Producto)
End Class

Partial Public Class Proveedor
    <Key()>
    Public Property IDPROVEEDOR As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property N_PROVEEDOR As String
    Public Property IDENTIFICACION As String
    Public Property TIPOPERSONA As String
    Public Property NOMBRES As String
    Public Property APELLIDOS As String
    Public Property RAZONSOCIAL As String
    Public Property TELEFONO As String
    Public Property DOMICILIO As String
    Public Property SEXO As String
    Public Property CORREO As String
    Public Property MONEDA As String
    Public Property LIMITECREDITO As Decimal
    Public Property PLAZO As Integer
    Public Property FACTURADO_C As Decimal
    Public Property FACTURADO_D As Decimal
    Public Property ACTIVO As String
    'Public Property IDCIUDAD As String

    'Public Overridable Property CIUDAD As CIUDAD
    Public Overridable Property Compras As ICollection(Of Compra) = New HashSet(Of Compra)
    Public Overridable Property ComprasRecibos As ICollection(Of CompraRecibo) = New HashSet(Of CompraRecibo)
End Class

Partial Public Class VentaRecibo
    <Key()>
    Public Property IDRECIBO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FORMADEPAGO As String
    Public Property N_PAGO As String
    Public Property FECHARECIBO As Date
    Public Property MONEDA As String
    Public Property TAZACAMBIO As Decimal
    Public Property CONCEPTO As String
    Public Property IMPORTETOTAL_C As Decimal
    Public Property IMPORTETOTAL_D As Decimal
    Public Property DESCUENTOTOTAL_C As Decimal
    Public Property DESCUENTOTOTAL_D As Decimal
    Public Property SOBRANTEDECAJA_C As Decimal
    Public Property SOBRANTEDECAJA_D As Decimal
    Public Property MONTOTOTAL_C As Decimal
    Public Property MONTOTOTAL_D As Decimal
    Public Property REIMPRESION As String
    Public Property IDEMPLEADO As String
    Public Property IDCLIENTE As String
    Public Property ANULADO As String
    Public Property IDTAZA As String

    Public Overridable Property Taza As Taza
    Public Overridable Property Serie As Serie
    Public Overridable Property Empleado As Empleado
    Public Overridable Property Cliente As Cliente
    Public Overridable Property VentasRecibosDetalles As ICollection(Of VentaReciboDetalle) = New HashSet(Of VentaReciboDetalle)
    Public Overridable Property VentasEstadosCuentas As ICollection(Of VentaEstadoCuenta) = New HashSet(Of VentaEstadoCuenta)
End Class

Partial Public Class Salida
    <Key()>
    Public Property IDSALIDA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHASALIDA As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property IDEMPLEADO As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property Serie As Serie
    Public Overridable Property SalidasDetalles As ICollection(Of SalidaDetalle) = New HashSet(Of SalidaDetalle)
    Public Overridable Property Empleado As Empleado
End Class

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

Partial Public Class ImpuestoValorAgregado
    <Key()>
    Public Property IDIVA As String
    Public Property FECHA As Date
    Public Property PORCENTAJE As Decimal
End Class

'Partial Public Class PAIS
'    <Key()>
'    Public Property IDPAIS As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property N_PAIS As String
'    Public Property ABREVIATURA1 As String
'    Public Property ABREVIATURA2 As String
'    Public Property NOMBRE As String
'    Public Property ACTIVO As String

'    Public Overridable Property CIUDADES As ICollection(Of CIUDAD) = New HashSet(Of CIUDAD)
'End Class

'Partial Public Class CIUDAD
'    <Key()>
'    Public Property IDCIUDAD As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property N_CIUDAD As String
'    Public Property NOMBRE As String
'    Public Property IDPAIS As String
'    Public Property ACTIVO As String

'    Public Overridable Property PAIS As PAIS
'    Public Overridable Property TRABAJADORES As ICollection(Of TRABAJADOR) = New HashSet(Of TRABAJADOR)
'    Public Overridable Property CLIENTES As ICollection(Of CLIENTE) = New HashSet(Of CLIENTE)
'    Public Overridable Property PROVEEDORES As ICollection(Of PROVEEDOR) = New HashSet(Of PROVEEDOR)
'End Class

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
    'Public Property ESTADO_CIVIL As String
    'Public Property N_INSS As String
    'Public Property N_RUC As String
    'Public Property IDENTIFICACION_CONYUGUE As String
    'Public Property NOMBRE_CONYUGUE As String
    'Public Property IDENTIFICACION_MADRE As String
    'Public Property NOMBRE_MADRE As String
    'Public Property IDENTIFICACION_PADRE As String
    'Public Property NOMBRE_PADRE As String
    'Public Property MONEDA As String
    'Public Property SUELDO_BASE_HORA As Boolean
    'Public Property SUELDO As Decimal
    'Public Property COMISION_POR As Decimal
    Public Property OBSERVACION As String
    'Public Property IMAGENAME As String
    'Public Property FILENAME As String
    'Public Property USUARIO As Boolean
    'Public Property NOMBREUSUARIO As String
    'Public Property CONTRASEÑA As String
    Public Property ACTIVO As String
    'Public Property IDPUESTO As String
    'Public Property IDAREA As String
    'Public Property IDCIUDAD As String

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
    'Public Overridable Property POLIZAS As ICollection(Of POLIZA) = New HashSet(Of POLIZA)

    'Public Overridable Property TRABAJADOR_PUESTO As TRABAJADOR_PUESTO
    'Public Overridable Property TRABAJADOR_AREA As TRABAJADOR_AREA
    'Public Overridable Property CIUDAD As CIUDAD
    'Public Overridable Property TRABAJADOR_PLANILLA_DETALLE As ICollection(Of TRABAJADOR_PLANILLA_DETALLE) = New HashSet(Of TRABAJADOR_PLANILLA_DETALLE)
End Class

'Partial Public Class TRABAJADOR_AREA
'    <Key()>
'    Public Property IDAREA As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property NOMBRE_AREA As String
'    Public Property DESCRIPCION As String
'    Public Property ACTIVO As String

'    Public Overridable Property TRABAJADORES As ICollection(Of TRABAJADOR) = New HashSet(Of TRABAJADOR)
'End Class

'Partial Public Class TRABAJADOR_PUESTO
'    <Key()>
'    Public Property IDPUESTO As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property NOMBRE_PUESTO As String
'    Public Property DESCRIPCION As String
'    Public Property CONTADOR As Boolean
'    Public Property VENDEDOR As Boolean
'    Public Property INVENTARISTA As Boolean
'    Public Property CAJERO As Boolean
'    Public Property MANTENIMIENTO As Boolean
'    Public Property ADMINISTRADOR_EMPRESA As Boolean
'    Public Property MARKETING As Boolean
'    Public Property RRHH As Boolean
'    Public Property INFORMATICO As Boolean
'    Public Property GERENTE As Boolean
'    Public Property ASEO As Boolean
'    Public Property CONSERJE As Boolean
'    Public Property SECRETARIO As Boolean
'    Public Property SOPORTE_TECNICO As Boolean
'    Public Property ATENCION_CLIENTE As Boolean
'    Public Property DISEÑADOR As Boolean
'    Public Property OTRO As String
'    Public Property ACTIVO As String

'    Public Overridable Property TRABAJADORES As ICollection(Of TRABAJADOR) = New HashSet(Of TRABAJADOR)
'End Class

'Partial Public Class TRABAJADOR_PLANILLA
'    <Key()>
'    Public Property IDPLANILLA As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property FECHA1 As Date
'    Public Property FECHA2 As Date
'    Public Property OBSERVACION As String
'    Public Property TOTAL_SUELDO_BASE As Decimal
'    Public Property TOTAL_SUELDO_HORA_NORMAL As Decimal
'    Public Property TOTAL_SUELDO_HORA_EXTRA As Decimal
'    Public Property TOTAL_COMISION As Decimal
'    Public Property TOTAL_SALARIO_BRUTO As Decimal
'    Public Property TOTAL_DEDUCCION As Decimal
'    Public Property TOTAL_SALARIO_NETO As Decimal
'    Public Property ANULADO As String

'    Public Overridable Property TRABAJADORES_PLANILLAS_DETALLES As ICollection(Of TRABAJADOR_PLANILLA_DETALLE) = New HashSet(Of TRABAJADOR_PLANILLA_DETALLE)
'End Class

'Partial Public Class TRABAJADOR_PLANILLA_DETALLE
'    <Key()>
'    Public Property IDPLANILLADETALLE As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property IDPLANILLA As String
'    Public Property IDTRABAJADOR As String
'    Public Property SUELDO_BASE As Decimal
'    Public Property HORA_NORMAL As Decimal
'    Public Property HORA_NORMAL_TARIFA As Decimal
'    Public Property HORA_NORMAL_TOTAL As Decimal
'    Public Property HORA_EXTRA As Decimal
'    Public Property HORA_EXTRA_TARIFA As Decimal
'    Public Property HORA_EXTRA_TOTAL As Decimal
'    Public Property COMISION As Decimal
'    Public Property SALARIO_BRUTO As Decimal
'    Public Property SALARIO_NETO As Decimal

'    Public Overridable Property TRABAJADOR_PLANILLA As TRABAJADOR_PLANILLA
'    Public Overridable Property TRABAJADOR As TRABAJADOR
'End Class

Partial Public Class Traslado
    <Key()>
    Public Property IDTRASLADO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHATRASLADO As Date
    Public Property IDBODEGA As String
    Public Property CONCEPTO As String
    Public Property REFERENCIA As String
    Public Property TOTAL As Decimal
    Public Property IDEMPLEADO As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property Serie As Serie
    Public Overridable Property Bodega As Bodega
    Public Overridable Property TrasladosDetalles As ICollection(Of TrasladoDetalle) = New HashSet(Of TrasladoDetalle)
    Public Overridable Property Empleado As Empleado
End Class

Partial Public Class Usuario
    <Key()>
    Public Property IDUsuario As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property Nombres As String
    Public Property Apellidos As String
    Public Property NombreCuenta As String
    Public Property Contraseña As String
    Public Property ImageName As String
    Public Property Observacion As String

    'LABORES
    Public Property Administrador As Boolean
    Public Property CAdministrador As Boolean
    Public Property Venta As Boolean
    Public Property VenderNegativo As Boolean
    Public Property CVenta As Boolean
    Public Property Compra As Boolean
    Public Property CCompra As Boolean
    Public Property Inventario As Boolean
    Public Property CInventario As Boolean
    Public Property Contabilidad As Boolean
    Public Property CContabilidad As Boolean
    Public Property Promocion As Boolean
    Public Property CPromocion As Boolean
    Public Property SalesPriceChange As Boolean

    Public Property Activo As String
End Class

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

'MÓDULO DE CONTABILIDAD
Partial Public Class Periodo
    <Key()>
    Public Property IDPERIODO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property INICIO As DateTime
    Public Property FINAL As DateTime
    Public Property APERTURA As Nullable(Of DateTime)
    Public Property CIERRE As Nullable(Of DateTime)
    Public Property ACTUAL As String

    Public Property ACTIVO As String
End Class

'Public Class CUENTA
'    <Key()>
'    Public Property IDCUENTA As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property CUENTA_SUPERIOR As String
'    Public Property CODIGO_CUENTA_SUPERIOR As String
'    Public Property NIVEL As Integer
'    Public Property CODIGO_CUENTA As String
'    Public Property CONCEPTO As String
'    Public Property NATURALEZA As String
'    Public Property DEBER_C As Decimal
'    Public Property DEBER_D As Decimal
'    Public Property HABER_C As Decimal
'    Public Property HABER_D As Decimal
'    Public Property SALDO_C As Decimal
'    Public Property SALDO_D As Decimal
'    Public Property ACTIVO As String

'    Public Overridable Property POLIZAS_DETALLES As ICollection(Of POLIZA_DETALLE) = New HashSet(Of POLIZA_DETALLE)
'End Class

'Public Class POLIZA
'    <Key()>
'    Public Property IDPOLIZA As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property IDSERIE As String
'    Public Property CONSECUTIVO As String
'    Public Property TIPO As String
'    Public Property FECHAPOLIZA As DateTime
'    Public Property CONCEPTO As String
'    Public Property TOTAL As Decimal
'    Public Property IDTRABAJADOR As String

'    Public Overridable Property POLIZAS_DETALLES As ICollection(Of POLIZA_DETALLE) = New HashSet(Of POLIZA_DETALLE)
'    Public Overridable Property SERIE As SERIE
'    Public Overridable Property TRABAJADOR As TRABAJADOR
'End Class

'Public Class POLIZA_DETALLE
'    <Key>
'    Public Property IDPOLIZADETALLE As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
'    Public Property N As Long
'    Public Property DEBER_C As Decimal
'    Public Property DEBER_D As Decimal
'    Public Property HABER_C As Decimal
'    Public Property HABER_D As Decimal
'    Public Property IDPOLIZA As String
'    Public Property IDCUENTA As String

'    Public Overridable Property CUENTA As CUENTA
'    Public Overridable Property POLIZA As POLIZA
'End Class

#End Region
#Region "CONTEXTO DEL SISTEMA"
'MODELO DE DATOS EN VB.NET
Public Class CodeFirst
    Inherits DbContext
    Public Sub New()
        MyBase.New("Data Source=" & Config.SQLServerName & ";Initial Catalog=" & Config.InitialCatalog & ";" & If(Config.SQLUser = "" Or Config.SQLPass = "", "Integrated Security=True;", "User ID=" & Config.SQLUser & "; Password=" & Config.SQLPass & ";"))
    End Sub

    'MODELO DE CONTEXTO
    'VARIABLES DE NAVEGACION
    Public Property Empresas() As DbSet(Of Empresa)
    Public Property Bodegas() As DbSet(Of Bodega)
    'Public Property CIUDADES() As DbSet(Of CIUDAD)
    Public Property Clientes() As DbSet(Of Cliente)
    Public Property Compras() As DbSet(Of Compra)
    Public Property ComprasDevoluciones As DbSet(Of CompraDevolucion)
    Public Property ComprasDevolucionesDetalles As DbSet(Of CompraDevolucionDetalle)
    Public Property ComprasRecibos As DbSet(Of CompraRecibo)
    Public Property ComprasRecibosDetalles As DbSet(Of CompraReciboDetalle)
    Public Property ComprasEstadosCuentas As DbSet(Of CompraEstadoCuenta)
    Public Property Consignaciones() As DbSet(Of Consignacion)
    Public Property Cotizaciones() As DbSet(Of Cotizacion)
    'Public Property CUENTAS As DbSet(Of CUENTA)
    Public Property Desconsignaciones() As DbSet(Of Desconsignacion)
    Public Property ComprasDetalles() As DbSet(Of CompraDetalle)
    Public Property ConsignacionesDetalles() As DbSet(Of ConsignacionDetalle)
    Public Property CotizacionesDetalles() As DbSet(Of CotizacionDetalle)
    Public Property DesconsignacionesDetalles() As DbSet(Of DesconsignacionDetalle)
    Public Property VentasDevolucionesDetalles() As DbSet(Of VentaDevolucionDetalle)
    Public Property EntradasDetalles() As DbSet(Of EntradaDetalle)
    Public Property VentasRecibosDetalles() As DbSet(Of VentaReciboDetalle)
    Public Property SalidasDetalles() As DbSet(Of SalidaDetalle)
    Public Property TrasladosDetalles() As DbSet(Of TrasladoDetalle)
    Public Property VentasDetalles() As DbSet(Of VentaDetalle)
    Public Property VentasDevoluciones() As DbSet(Of VentaDevolucion)
    Public Property Entradas() As DbSet(Of Entrada)
    Public Property VentasEstadosCuentas As DbSet(Of VentaEstadoCuenta)
    Public Property Existencias() As DbSet(Of Existencia)
    Public Property Kardexs() As DbSet(Of Kardex)
    Public Property Laboratorios() As DbSet(Of Laboratorio)
    Public Property Marcas() As DbSet(Of Marca)
    'Public Property PAISES() As DbSet(Of PAIS)
    Public Property Periodos() As DbSet(Of Periodo)
    'Public Property POLIZAS() As DbSet(Of POLIZA)
    'Public Property POLIZAS_DETALLES() As DbSet(Of POLIZA_DETALLE)
    Public Property Presentaciones() As DbSet(Of Presentacion)
    Public Property Productos() As DbSet(Of Producto)
    Public Property Promociones() As DbSet(Of Promocion)
    Public Property PromocionesExistencias() As DbSet(Of PromocionExistencia)
    Public Property Proveedores() As DbSet(Of Proveedor)
    Public Property VentasRecibos() As DbSet(Of VentaRecibo)
    Public Property Salidas() As DbSet(Of Salida)
    Public Property Series() As DbSet(Of Serie)
    Public Property Tazas() As DbSet(Of Taza)
    Public Property ImpuestosValoresAgregados() As DbSet(Of ImpuestoValorAgregado)
    Public Property Empleados() As DbSet(Of Empleado)
    'Public Property TRABAJADORES_AREAS() As DbSet(Of TRABAJADOR_AREA)
    'Public Property TRABAJADORES_PLANILLAS() As DbSet(Of TRABAJADOR_PLANILLA)
    'Public Property TRABAJADORES_PLANILLAS_DETALLES() As DbSet(Of TRABAJADOR_PLANILLA_DETALLE)
    'Public Property TRABAJADORES_PUESTOS() As DbSet(Of TRABAJADOR_PUESTO)
    Public Property Traslados() As DbSet(Of Traslado)
    Public Property UnidadesMedidas() As DbSet(Of UnidadMedida)
    Public Property Usuarios() As DbSet(Of Usuario)
    Public Property Ventas() As DbSet(Of Venta)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention)()

        'DECIMALES EN CLIENTE
        modelBuilder.Entity(Of Cliente).Property(Function(f) f.LIMITECREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cliente).Property(Function(f) f.FACTURADO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cliente).Property(Function(f) f.FACTURADO_D).HasPrecision(18, 4)

        'DECIMALES EN COMPRA
        modelBuilder.Entity(Of Compra).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Compra).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DEVOLUCION DE COMPRA
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DEVOLUCION DE COMPRA DETALLE
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.CANTIDAD_DEVUELTA).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.PRECIOMONEDAORIGINAL).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES COMPRA PAGO PROVEEDOR
        modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.DEBE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.DEBE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

        'DECIMALES COMPRA RECIBO
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.IMPORTETOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.IMPORTETOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.DESCUENTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.DESCUENTOTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.SOBRANTEDECAJA_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.SOBRANTEDECAJA_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.MONTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.MONTOTOTAL_D).HasPrecision(18, 4)

        'DETALLE COMPRA RECIBO DETALLE
        modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.IMPORTE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.IMPORTE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.DESCUENTO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.DESCUENTO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.NUEVO_SALDO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.NUEVO_SALDO_D).HasPrecision(18, 4)

        'DECIMALES EN COTIZACION
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE COMPRA
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE COTIZACION
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE DEVOLUCION
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE ENTRADA
        modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DETALLE VENTA RECIBO DETALLE
        modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.IMPORTE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.IMPORTE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.DESCUENTO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.DESCUENTO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.NUEVO_SALDO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.NUEVO_SALDO_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE SALIDA
        modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN DETALLE TRASLADO
        modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.EXISTENCIAEXTERNA).HasPrecision(18, 4)
        modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN DETALLE VENTA
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DEVOLUCION VENTA
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN ENTRADA
        modelBuilder.Entity(Of Entrada).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES ESTADO DE CUENTA
        modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.DEBE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.DEBE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

        'DECIMALES EN EXISTENCIA
        modelBuilder.Entity(Of Existencia).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of Existencia).Property(Function(f) f.CONSIGNADO).HasPrecision(18, 4)

        'DECIMALES EN KARDEX
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.ENTRADA).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.SALIDA).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.EXISTENCIA_ANTERIOR).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.EXISTENCIA_ALMACEN).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.COSTO_PROMEDIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.PRECIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.PRECIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.DEBER).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.HABER).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.SALDO).HasPrecision(18, 4)

        'DECIMALES EN PRODUCTO
        modelBuilder.Entity(Of Producto).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.CONTIENE).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO1).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO2).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO3).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO4).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.CANTIDAD_MAXIMA).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.CANTIDAD_MINIMA).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.Descuento).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of Producto).Property(Function(f) f.SALDO).HasPrecision(18, 4)

        'DECIMALES EN PROMOCIONES
        modelBuilder.Entity(Of PromocionExistencia).Property(Function(f) f.Descuento).HasPrecision(18, 4)

        'DECIMALES EN PROVEEDOR
        modelBuilder.Entity(Of Proveedor).Property(Function(f) f.LIMITECREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Proveedor).Property(Function(f) f.FACTURADO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Proveedor).Property(Function(f) f.FACTURADO_D).HasPrecision(18, 4)

        'DECIMALES VENTA RECIBO
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.IMPORTETOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.IMPORTETOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.DESCUENTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.DESCUENTOTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.SOBRANTEDECAJA_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.SOBRANTEDECAJA_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.MONTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.MONTOTOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN SALIDA
        modelBuilder.Entity(Of Salida).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN TAZA
        modelBuilder.Entity(Of Taza).Property(Function(f) f.CAMBIO).HasPrecision(18, 4)

        'DECIMALES EN IVA
        modelBuilder.Entity(Of ImpuestoValorAgregado).Property(Function(f) f.PORCENTAJE).HasPrecision(18, 4)

        ''DECIMALES EN TRABAJADOR
        'modelBuilder.Entity(Of TRABAJADOR).Property(Function(f) f.SUELDO).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR).Property(Function(f) f.COMISION_POR).HasPrecision(18, 4)

        ''DECIMALES EN PLANILLA
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SUELDO_BASE).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SUELDO_HORA_NORMAL).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SUELDO_HORA_EXTRA).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_COMISION).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SALARIO_BRUTO).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_DEDUCCION).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SALARIO_NETO).HasPrecision(18, 4)

        ''DECIMALES EN DETALLE PLANILLA
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.SUELDO_BASE).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_NORMAL).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_NORMAL_TARIFA).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_NORMAL_TOTAL).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_EXTRA).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_EXTRA_TARIFA).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_EXTRA_TOTAL).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.COMISION).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.SALARIO_BRUTO).HasPrecision(18, 4)
        'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.SALARIO_NETO).HasPrecision(18, 4)

        'DECIMALES EN TRASLADO
        modelBuilder.Entity(Of Traslado).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN VENTA
        modelBuilder.Entity(Of Venta).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.COSTO_TOTAL).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of Venta).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        ''DECIMALES EN CUENTA
        'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.DEBER_C).HasPrecision(18, 4)
        'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.DEBER_D).HasPrecision(18, 4)
        'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
        'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.HABER_D).HasPrecision(18, 4)
        'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.SALDO_C).HasPrecision(18, 4)
        'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.SALDO_D).HasPrecision(18, 4)

        ''DECIMALES EN POLIZA
        'modelBuilder.Entity(Of POLIZA).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        ''DECIMALES EN DETALLE POLIZA
        'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.DEBER_C).HasPrecision(18, 4)
        'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.DEBER_D).HasPrecision(18, 4)
        'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
        'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

        MyBase.OnModelCreating(modelBuilder)
    End Sub
End Class

Public Class fecha
    Inherits DataContext
    Sub New()
        MyBase.New(Config.SQLConecction)
    End Sub
    <System.Data.Linq.Mapping.FunctionAttribute(Name:="GetDate", IsComposable:=True)>
    Public Function GetDate() As DateTime
        Try
            Dim m As Reflection.MethodInfo = Reflection.MethodBase.GetCurrentMethod()
            Return Convert.ToDateTime(Me.ExecuteMethodCall(Me, m, New Object() {}).ReturnValue)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
#End Region