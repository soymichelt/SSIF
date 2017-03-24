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

Public Class BODEGA
    <Key()>
    Public Property IDBODEGA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property N_BODEGA As String
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property SERIES As ICollection(Of SERIE) = New HashSet(Of SERIE)
    Public Overridable Property EXISTENCIAS As ICollection(Of EXISTENCIA) = New HashSet(Of EXISTENCIA)
    Public Overridable Property TRASLADOS As ICollection(Of TRASLADO) = New HashSet(Of TRASLADO)

End Class

Partial Public Class CLIENTE
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

    Public Overridable Property COTIZACIONES As ICollection(Of COTIZACION) = New HashSet(Of COTIZACION)
    Public Overridable Property VENTAS As ICollection(Of VENTA) = New HashSet(Of VENTA)
    Public Overridable Property CONSIGNACIONES As ICollection(Of CONSIGNACION) = New HashSet(Of CONSIGNACION)
    Public Overridable Property DESCONSIGNACIONES As ICollection(Of DESCONSIGNACION) = New HashSet(Of DESCONSIGNACION)
    Public Overridable Property RECIBOS As ICollection(Of RECIBO) = New HashSet(Of RECIBO)

    'Public Overridable Property CIUDAD As CIUDAD
End Class

Partial Public Class COMPRA

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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_COMPRAS As ICollection(Of DETALLE_COMPRA) = New HashSet(Of DETALLE_COMPRA)
    Public Overridable Property EMPLEADO As EMPLEADO
    Public Overridable Property PROVEEDOR As PROVEEDOR
    Public Overridable Property COMPRAS_RECIBOS_DETALLES As ICollection(Of COMPRA_RECIBO_DETALLE) = New HashSet(Of COMPRA_RECIBO_DETALLE)
    Public Overridable Property COMPRAS_DEVOLUCIONES As ICollection(Of COMPRA_DEVOLUCION) = New HashSet(Of COMPRA_DEVOLUCION)
    Public Overridable Property COMPRAS_PAGOS_PROVEEDORES As ICollection(Of COMPRA_PAGO_PROVEEDOR) = New HashSet(Of COMPRA_PAGO_PROVEEDOR)

End Class

Partial Public Class COMPRA_DEVOLUCION
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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property COMPRAS_DEVOLUCIONES_DETALLES As ICollection(Of COMPRA_DEVOLUCION_DETALLE) = New HashSet(Of COMPRA_DEVOLUCION_DETALLE)
    Public Overridable Property COMPRA As COMPRA
    Public Overridable Property PROVEEDOR As PROVEEDOR
    Public Overridable Property EMPLEADO As EMPLEADO

End Class

Partial Public Class COMPRA_DEVOLUCION_DETALLE
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

    Public Overridable Property EXISTENCIA As EXISTENCIA
    Public Overridable Property COMPRA_DEVOLUCION As COMPRA_DEVOLUCION

End Class

Partial Public Class COMPRA_PAGO_PROVEEDOR
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

    Public Overridable Property SERIE As SERIE
    Public Property COMPRA As COMPRA
    Public Property COMPRA_RECIBO As COMPRA_RECIBO
End Class

Partial Public Class COMPRA_RECIBO
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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property COMPRAS_RECIBOS_DETALLES As ICollection(Of COMPRA_RECIBO_DETALLE) = New HashSet(Of COMPRA_RECIBO_DETALLE)
    Public Overridable Property COMPRAS_PAGOS_PROVEEDORES As ICollection(Of COMPRA_PAGO_PROVEEDOR) = New HashSet(Of COMPRA_PAGO_PROVEEDOR)
    Public Overridable Property EMPLEADO As EMPLEADO
    Public Overridable Property PROVEEDOR As PROVEEDOR
End Class

Partial Public Class COMPRA_RECIBO_DETALLE
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

    Public Overridable Property COMPRA As COMPRA
    Public Overridable Property COMPRA_RECIBO As COMPRA_RECIBO
End Class

Partial Public Class CONSIGNACION
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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_CONSIGNACIONES As ICollection(Of DETALLE_DESCONSIGNACION) = New HashSet(Of DETALLE_DESCONSIGNACION)
    Public Overridable Property EMPLEADO As EMPLEADO
End Class

Partial Public Class COTIZACION
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

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_COTIZACIONES As ICollection(Of DETALLE_COTIZACION) = New HashSet(Of DETALLE_COTIZACION)
    Public Overridable Property TRABAJADOR As EMPLEADO

End Class

Partial Public Class DESCONSIGNACION
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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_DESCONSIGNACIONES As ICollection(Of DETALLE_DESCONSIGNACION) = New HashSet(Of DETALLE_DESCONSIGNACION)
    Public Overridable Property EMPLEADO As EMPLEADO
End Class

Partial Public Class DETALLE_COMPRA
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

    Public Overridable Property COMPRA As COMPRA
    Public Overridable Property EXISTENCIA As EXISTENCIA

End Class

Partial Public Class DETALLE_CONSIGNACION
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

    Public Overridable Property CONSIGNACION As CONSIGNACION
    Public Overridable Property EXISTENCIA As EXISTENCIA
End Class

Partial Public Class DETALLE_COTIZACION
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

    Public Overridable Property COTIZACION As COTIZACION
    Public Overridable Property EXISTENCIA As EXISTENCIA
End Class

Partial Public Class DETALLE_DESCONSIGNACION
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

    Public Overridable Property DESCONSIGNACION As DESCONSIGNACION
    Public Overridable Property EXISTENCIA As EXISTENCIA
End Class

Partial Public Class DETALLE_DEVOLUCION
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

    Public Overridable Property EXISTENCIA As EXISTENCIA
    Public Overridable Property DEVOLUCION_CLIENTE As DEVOLUCION_CLIENTE

End Class

Partial Public Class DETALLE_ENTRADA
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

    Public Overridable Property ENTRADA As ENTRADA
    Public Overridable Property EXISTENCIA As EXISTENCIA

End Class

Partial Public Class DETALLE_RECIBO
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

    Public Overridable Property VENTA As VENTA
    Public Overridable Property RECIBO As RECIBO
End Class

Partial Public Class DETALLE_SALIDA
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

    Public Overridable Property EXISTENCIA As EXISTENCIA
    Public Overridable Property SALIDA As SALIDA

End Class

Partial Public Class DETALLE_TRASLADO
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

    Public Overridable Property EXISTENCIA As EXISTENCIA
    Public Overridable Property TRASLADO As TRASLADO

End Class

Partial Public Class DETALLE_VENTA
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

    Public Overridable Property EXISTENCIA As EXISTENCIA
    Public Overridable Property VENTA As VENTA
    'Public Overridable Property VENTAS_VENCIMIENTOS As ICollection(Of VENTA_VENCIMIENTO)
End Class

Partial Public Class DEVOLUCION_CLIENTE
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

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_DEVOLUCIONES As ICollection(Of DETALLE_DEVOLUCION) = New HashSet(Of DETALLE_DEVOLUCION)
    Public Overridable Property VENTA As VENTA
    Public Overridable Property EMPLEADO As EMPLEADO
    Public Overridable Property CLIENTE As CLIENTE

End Class

Partial Public Class ENTRADA
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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_ENTRADAS As ICollection(Of DETALLE_ENTRADA) = New HashSet(Of DETALLE_ENTRADA)
    Public Overridable Property EMPLEADO As EMPLEADO
End Class

Partial Public Class ESTADO_DE_CUENTA
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

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property VENTA As VENTA
    Public Overridable Property RECIBO As RECIBO
    Public Overridable Property Devolucion_Cliente As DEVOLUCION_CLIENTE
End Class

Partial Public Class EXISTENCIA
    <Key()>
    Public Property IDEXISTENCIA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property CANTIDAD As Decimal
    Public Property CONSIGNADO As Decimal
    Public Property IDBODEGA As String
    Public Property IDPRODUCTO As String

    Public Overridable Property BODEGA As BODEGA
    Public Overridable Property DETALLES_COMPRAS As ICollection(Of DETALLE_COMPRA) = New HashSet(Of DETALLE_COMPRA)
    Public Overridable Property DETALLES_CONSIGNACIONES As ICollection(Of DETALLE_CONSIGNACION) = New HashSet(Of DETALLE_CONSIGNACION)
    Public Overridable Property DETALLES_COTIZACIONES As ICollection(Of DETALLE_COTIZACION) = New HashSet(Of DETALLE_COTIZACION)
    Public Overridable Property DETALLES_DESCONSIGNACIONES As ICollection(Of DETALLE_DESCONSIGNACION) = New HashSet(Of DETALLE_DESCONSIGNACION)
    Public Overridable Property DETALLES_DEVOLUCIONES As ICollection(Of DETALLE_DEVOLUCION) = New HashSet(Of DETALLE_DEVOLUCION)
    Public Overridable Property DETALLES_ENTRADAS As ICollection(Of DETALLE_ENTRADA) = New HashSet(Of DETALLE_ENTRADA)
    Public Overridable Property DETALLES_SALIDAS As ICollection(Of DETALLE_SALIDA) = New HashSet(Of DETALLE_SALIDA)
    Public Overridable Property DETALLES_TRASLADOS As ICollection(Of DETALLE_TRASLADO) = New HashSet(Of DETALLE_TRASLADO)
    Public Overridable Property DETALLES_VENTAS As ICollection(Of DETALLE_VENTA) = New HashSet(Of DETALLE_VENTA)
    Public Overridable Property KARDEXS As ICollection(Of KARDEX) = New HashSet(Of KARDEX)
    Public Overridable Property PRODUCTO As PRODUCTO
    Public Overridable Property COMPRAS_DEVOLUCIONES_DETALLES As ICollection(Of COMPRA_DEVOLUCION_DETALLE) = New HashSet(Of COMPRA_DEVOLUCION_DETALLE)

    'Promociones
    Public Overridable Property PromocionesExistencias As ICollection(Of PromocionExistencia)

End Class

Partial Public Class KARDEX
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

    Public Overridable Property EXISTENCIA As EXISTENCIA
    Public Overridable Property SERIE As SERIE

End Class

Partial Public Class MARCA
    <Key()>
    Public Property IDMARCA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)

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

    Public Property PromocionID As Guid

    Public Property IDEXISTENCIA As String

    Public Property Promocion As Promocion

    Public Property EXISTENCIA As EXISTENCIA

End Class

Partial Public Class PRODUCTO
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
    Public Property DESCUENTO_MAXIMO As Decimal
    Public Property IDPRESENTACION As String
    Public Property IDLABORATORIO As String
    Public Property IDPROVEEDOR As String
    Public Property IMAGENAME As String
    Public Property UBICACIONFISICA As String
    Public Property CANTIDAD As Decimal
    Public Property SALDO As Decimal
    Public Property ACTIVO As String

    Public Overridable Property EXISTENCIAS As ICollection(Of EXISTENCIA) = New HashSet(Of EXISTENCIA)
    Public Overridable Property MARCA As MARCA
    Public Overridable Property PRESENTACION As PRESENTACION
    Public Overridable Property UNIDAD_DE_MEDIDA As UNIDAD_DE_MEDIDA
    Public Overridable Property LABORATORIO As LABORATORIO
    Public Overridable Property PROVEEDOR As PROVEEDOR
End Class

Public Class PRESENTACION
    <Key()>
    Public Property IDPRESENTACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)
End Class
Public Class LABORATORIO
    <Key()>
    Public Property IDLABORATORIO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)
End Class
Public Class UNIDAD_DE_MEDIDA
    <Key()>
    Public Property IDUNIDAD As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As Nullable(Of DateTime)
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)
End Class

Partial Public Class PROVEEDOR
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
    Public Overridable Property COMPRAS As ICollection(Of COMPRA) = New HashSet(Of COMPRA)
    Public Overridable Property COMPRAS_RECIBOS As ICollection(Of COMPRA_RECIBO) = New HashSet(Of COMPRA_RECIBO)
End Class

Partial Public Class RECIBO
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

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property EMPLEADO As EMPLEADO
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_RECIBOS As ICollection(Of DETALLE_RECIBO) = New HashSet(Of DETALLE_RECIBO)
    Public Overridable Property ESTADOS_DE_CUENTAS As ICollection(Of ESTADO_DE_CUENTA) = New HashSet(Of ESTADO_DE_CUENTA)
End Class

Partial Public Class SALIDA
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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_SALIDAS As ICollection(Of DETALLE_SALIDA) = New HashSet(Of DETALLE_SALIDA)
    Public Overridable Property EMPLEADO As EMPLEADO
End Class

Partial Public Class SERIE
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

    Public Overridable Property BODEGA As BODEGA
    Public Overridable Property KARDEX As ICollection(Of KARDEX) = New HashSet(Of KARDEX)
    Public Overridable Property COMPRAS As ICollection(Of COMPRA) = New HashSet(Of COMPRA)
    Public Overridable Property COMPRAS_DEVOLUCIONES As ICollection(Of COMPRA_DEVOLUCION) = New HashSet(Of COMPRA_DEVOLUCION)
    Public Overridable Property COMPRAS_PAGOS_PROVEEDORES As ICollection(Of COMPRA_PAGO_PROVEEDOR) = New HashSet(Of COMPRA_PAGO_PROVEEDOR)
    Public Overridable Property COMPRAS_RECIBOS As ICollection(Of COMPRA_RECIBO) = New HashSet(Of COMPRA_RECIBO)
    Public Overridable Property CONSIGNACIONES As ICollection(Of CONSIGNACION) = New HashSet(Of CONSIGNACION)
    Public Overridable Property COTIZACIONES As ICollection(Of COTIZACION) = New HashSet(Of COTIZACION)
    Public Overridable Property DESCONSIGNACIONES As ICollection(Of DESCONSIGNACION) = New HashSet(Of DESCONSIGNACION)
    Public Overridable Property DEVOLUCIONES_CLIENTES As ICollection(Of DEVOLUCION_CLIENTE) = New HashSet(Of DEVOLUCION_CLIENTE)
    Public Overridable Property ENTRADA As ICollection(Of ENTRADA) = New HashSet(Of ENTRADA)
    Public Overridable Property ESTADOS_DE_CUENTAS As ICollection(Of ESTADO_DE_CUENTA) = New HashSet(Of ESTADO_DE_CUENTA)
    Public Overridable Property RECIBOS As ICollection(Of RECIBO) = New HashSet(Of RECIBO)
    Public Overridable Property SALIDAS As ICollection(Of SALIDA) = New HashSet(Of SALIDA)
    Public Overridable Property TRASLADOS As ICollection(Of TRASLADO) = New HashSet(Of TRASLADO)
    Public Overridable Property VENTAS As ICollection(Of VENTA) = New HashSet(Of VENTA)

End Class

Partial Public Class TAZA
    <Key()>
    Public Property IDTAZA As String
    Public Property FECHA As DateTime
    Public Property CAMBIO As Decimal

    Public Overridable Property COMPRAS As ICollection(Of COMPRA)
    Public Overridable Property VENTAS As ICollection(Of VENTA)
    Public Overridable Property DEVOLUCIONES_CLIENTES As ICollection(Of DEVOLUCION_CLIENTE)
    Public Overridable Property COMPRAS_DEVOLUCIONES As ICollection(Of COMPRA_DEVOLUCION)
    Public Overridable Property RECIBOS As ICollection(Of RECIBO)
    Public Overridable Property COMPRAS_RECIBOS As ICollection(Of COMPRA_RECIBO)
    Public Overridable Property COTIZACIONES As ICollection(Of COTIZACION)
End Class

Partial Public Class IVA
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

Partial Public Class EMPLEADO
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

    Public Overridable Property COTIZACIONES As ICollection(Of COTIZACION) = New HashSet(Of COTIZACION)
    Public Overridable Property VENTAS As ICollection(Of VENTA) = New HashSet(Of VENTA)
    Public Overridable Property DEVOLUCIONES_CLIENTES As ICollection(Of DEVOLUCION_CLIENTE) = New HashSet(Of DEVOLUCION_CLIENTE)
    Public Overridable Property CONSIGNACIONES As ICollection(Of CONSIGNACION) = New HashSet(Of CONSIGNACION)
    Public Overridable Property DESCONSIGNACIONES As ICollection(Of DESCONSIGNACION) = New HashSet(Of DESCONSIGNACION)
    Public Overridable Property COMPRAS As ICollection(Of COMPRA) = New HashSet(Of COMPRA)
    Public Overridable Property COMPRAS_DEVOLUCIONES As ICollection(Of COMPRA_DEVOLUCION) = New HashSet(Of COMPRA_DEVOLUCION)
    Public Overridable Property ENTRADAS As ICollection(Of ENTRADA) = New HashSet(Of ENTRADA)
    Public Overridable Property SALIDAS As ICollection(Of SALIDA) = New HashSet(Of SALIDA)
    Public Overridable Property TRASLADOS As ICollection(Of TRASLADO) = New HashSet(Of TRASLADO)
    Public Overridable Property RECIBOS As ICollection(Of RECIBO) = New HashSet(Of RECIBO)
    Public Overridable Property COMPRAS_RECIBOS As ICollection(Of COMPRA_RECIBO) = New HashSet(Of COMPRA_RECIBO)
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

Partial Public Class TRASLADO
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

    Public Overridable Property SERIE As SERIE
    Public Overridable Property BODEGA As BODEGA
    Public Overridable Property DETALLES_TRASLADOS As ICollection(Of DETALLE_TRASLADO) = New HashSet(Of DETALLE_TRASLADO)
    Public Overridable Property EMPLEADO As EMPLEADO
End Class

Partial Public Class USUARIO
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

    Public Property Activo As String
End Class

Partial Public Class VENTA
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

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_VENTAS As ICollection(Of DETALLE_VENTA) = New HashSet(Of DETALLE_VENTA)
    Public Overridable Property EMPLEADO As EMPLEADO
    Public Overridable Property DETALLES_RECIBOS As ICollection(Of DETALLE_RECIBO) = New HashSet(Of DETALLE_RECIBO)
    Public Overridable Property DEVOLUCIONES_CLIENTES As ICollection(Of DEVOLUCION_CLIENTE) = New HashSet(Of DEVOLUCION_CLIENTE)
    Public Overridable Property ESTADOS_DE_CUENTAS As ICollection(Of ESTADO_DE_CUENTA) = New HashSet(Of ESTADO_DE_CUENTA)
End Class

'MÓDULO DE CONTABILIDAD
Partial Public Class PERIODO
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
    Public Property BODEGAS() As DbSet(Of BODEGA)
    'Public Property CIUDADES() As DbSet(Of CIUDAD)
    Public Property CLIENTES() As DbSet(Of CLIENTE)
    Public Property COMPRAS() As DbSet(Of COMPRA)
    Public Property COMPRAS_DEVOLUCIONES As DbSet(Of COMPRA_DEVOLUCION)
    Public Property COMPRAS_DEVOLUCIONES_DETALLES As DbSet(Of COMPRA_DEVOLUCION_DETALLE)
    Public Property COMPRAS_RECIBOS As DbSet(Of COMPRA_RECIBO)
    Public Property COMPRAS_RECIBOS_DETALLES As DbSet(Of COMPRA_RECIBO_DETALLE)
    Public Property COMPRAS_PAGOS_PROVEEDORES As DbSet(Of COMPRA_PAGO_PROVEEDOR)
    Public Property CONSIGNACIONES() As DbSet(Of CONSIGNACION)
    Public Property COTIZACIONES() As DbSet(Of COTIZACION)
    'Public Property CUENTAS As DbSet(Of CUENTA)
    Public Property DESCONSIGNACIONES() As DbSet(Of DESCONSIGNACION)
    Public Property DETALLES_COMPRAS() As DbSet(Of DETALLE_COMPRA)
    Public Property DETALLES_CONSIGNACIONES() As DbSet(Of DETALLE_CONSIGNACION)
    Public Property DETALLES_COTIZACIONES() As DbSet(Of DETALLE_COTIZACION)
    Public Property DETALLES_DESCONSIGNACIONES() As DbSet(Of DETALLE_DESCONSIGNACION)
    Public Property DETALLES_DEVOLUCIONES() As DbSet(Of DETALLE_DEVOLUCION)
    Public Property DETALLES_ENTRADAS() As DbSet(Of DETALLE_ENTRADA)
    Public Property DETALLES_RECIBOS() As DbSet(Of DETALLE_RECIBO)
    Public Property DETALLES_SALIDAS() As DbSet(Of DETALLE_SALIDA)
    Public Property DETALLES_TRASLADOS() As DbSet(Of DETALLE_TRASLADO)
    Public Property DETALLES_VENTAS() As DbSet(Of DETALLE_VENTA)
    Public Property DEVOLUCIONES_CLIENTES() As DbSet(Of DEVOLUCION_CLIENTE)
    Public Property ENTRADAS() As DbSet(Of ENTRADA)
    Public Property ESTADOS_DE_CUENTAS As DbSet(Of ESTADO_DE_CUENTA)
    Public Property EXISTENCIAS() As DbSet(Of EXISTENCIA)
    Public Property KARDEXS() As DbSet(Of KARDEX)
    Public Property LABORATORIOS() As DbSet(Of LABORATORIO)
    Public Property MARCAS() As DbSet(Of MARCA)
    'Public Property PAISES() As DbSet(Of PAIS)
    Public Property PERIODOS() As DbSet(Of PERIODO)
    'Public Property POLIZAS() As DbSet(Of POLIZA)
    'Public Property POLIZAS_DETALLES() As DbSet(Of POLIZA_DETALLE)
    Public Property PRESENTACIONES() As DbSet(Of PRESENTACION)
    Public Property PRODUCTOS() As DbSet(Of PRODUCTO)
    Public Property Promociones() As DbSet(Of Promocion)
    Public Property PromocionesExistencias() As DbSet(Of PromocionExistencia)
    Public Property PROVEEDORES() As DbSet(Of PROVEEDOR)
    Public Property RECIBOS() As DbSet(Of RECIBO)
    Public Property SALIDAS() As DbSet(Of SALIDA)
    Public Property SERIES() As DbSet(Of SERIE)
    Public Property TAZAS() As DbSet(Of TAZA)
    Public Property IVAS() As DbSet(Of IVA)
    Public Property EMPLEADOS() As DbSet(Of EMPLEADO)
    'Public Property TRABAJADORES_AREAS() As DbSet(Of TRABAJADOR_AREA)
    'Public Property TRABAJADORES_PLANILLAS() As DbSet(Of TRABAJADOR_PLANILLA)
    'Public Property TRABAJADORES_PLANILLAS_DETALLES() As DbSet(Of TRABAJADOR_PLANILLA_DETALLE)
    'Public Property TRABAJADORES_PUESTOS() As DbSet(Of TRABAJADOR_PUESTO)
    Public Property TRASLADOS() As DbSet(Of TRASLADO)
    Public Property UNIDADES_DE_MEDIDAS() As DbSet(Of UNIDAD_DE_MEDIDA)
    Public Property USUARIOS() As DbSet(Of USUARIO)
    Public Property VENTAS() As DbSet(Of VENTA)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention)()

        'DECIMALES EN CLIENTE
        modelBuilder.Entity(Of CLIENTE).Property(Function(f) f.LIMITECREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of CLIENTE).Property(Function(f) f.FACTURADO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of CLIENTE).Property(Function(f) f.FACTURADO_D).HasPrecision(18, 4)

        'DECIMALES EN COMPRA
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DEVOLUCION DE COMPRA
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DEVOLUCION DE COMPRA DETALLE
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.CANTIDAD_DEVUELTA).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.PRECIOMONEDAORIGINAL).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_DEVOLUCION_DETALLE).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES COMPRA PAGO PROVEEDOR
        modelBuilder.Entity(Of COMPRA_PAGO_PROVEEDOR).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_PAGO_PROVEEDOR).Property(Function(f) f.DEBE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_PAGO_PROVEEDOR).Property(Function(f) f.DEBE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_PAGO_PROVEEDOR).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_PAGO_PROVEEDOR).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

        'DECIMALES COMPRA RECIBO
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.IMPORTETOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.IMPORTETOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.DESCUENTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.DESCUENTOTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.SOBRANTEDECAJA_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.SOBRANTEDECAJA_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.MONTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO).Property(Function(f) f.MONTOTOTAL_D).HasPrecision(18, 4)

        'DETALLE COMPRA RECIBO DETALLE
        modelBuilder.Entity(Of COMPRA_RECIBO_DETALLE).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO_DETALLE).Property(Function(f) f.IMPORTE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO_DETALLE).Property(Function(f) f.IMPORTE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO_DETALLE).Property(Function(f) f.DESCUENTO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO_DETALLE).Property(Function(f) f.DESCUENTO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO_DETALLE).Property(Function(f) f.NUEVO_SALDO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COMPRA_RECIBO_DETALLE).Property(Function(f) f.NUEVO_SALDO_D).HasPrecision(18, 4)

        'DECIMALES EN COTIZACION
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of COTIZACION).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE COMPRA
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COMPRA).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE COTIZACION
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_COTIZACION).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE DEVOLUCION
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_DEVOLUCION).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE ENTRADA
        modelBuilder.Entity(Of DETALLE_ENTRADA).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_ENTRADA).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_ENTRADA).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_ENTRADA).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DETALLE VENTA RECIBO DETALLE
        modelBuilder.Entity(Of DETALLE_RECIBO).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_RECIBO).Property(Function(f) f.IMPORTE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_RECIBO).Property(Function(f) f.IMPORTE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_RECIBO).Property(Function(f) f.DESCUENTO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_RECIBO).Property(Function(f) f.DESCUENTO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_RECIBO).Property(Function(f) f.NUEVO_SALDO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_RECIBO).Property(Function(f) f.NUEVO_SALDO_D).HasPrecision(18, 4)

        'DECIMALES EN DETALLE SALIDA
        modelBuilder.Entity(Of DETALLE_SALIDA).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_SALIDA).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_SALIDA).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_SALIDA).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN DETALLE TRASLADO
        modelBuilder.Entity(Of DETALLE_TRASLADO).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_TRASLADO).Property(Function(f) f.EXISTENCIAEXTERNA).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_TRASLADO).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_TRASLADO).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_TRASLADO).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN DETALLE VENTA
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DETALLE_VENTA).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN DEVOLUCION VENTA
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of DEVOLUCION_CLIENTE).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN ENTRADA
        modelBuilder.Entity(Of ENTRADA).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES ESTADO DE CUENTA
        modelBuilder.Entity(Of ESTADO_DE_CUENTA).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of ESTADO_DE_CUENTA).Property(Function(f) f.DEBE_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of ESTADO_DE_CUENTA).Property(Function(f) f.DEBE_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of ESTADO_DE_CUENTA).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of ESTADO_DE_CUENTA).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

        'DECIMALES EN EXISTENCIA
        modelBuilder.Entity(Of EXISTENCIA).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of EXISTENCIA).Property(Function(f) f.CONSIGNADO).HasPrecision(18, 4)

        'DECIMALES EN KARDEX
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.ENTRADA).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.SALIDA).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.EXISTENCIA_ANTERIOR).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.EXISTENCIA_ALMACEN).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.COSTO_PROMEDIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.PRECIO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.PRECIO_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.DEBER).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.HABER).HasPrecision(18, 4)
        modelBuilder.Entity(Of KARDEX).Property(Function(f) f.SALDO).HasPrecision(18, 4)

        'DECIMALES EN PRODUCTO
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.COSTO).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.CONTIENE).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.PRECIO1).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.PRECIO2).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.PRECIO3).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.PRECIO4).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.CANTIDAD_MAXIMA).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.CANTIDAD_MINIMA).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.DESCUENTO_MAXIMO).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
        modelBuilder.Entity(Of PRODUCTO).Property(Function(f) f.SALDO).HasPrecision(18, 4)

        'DECIMALES EN PROMOCIONES
        modelBuilder.Entity(Of PromocionExistencia).Property(Function(f) f.Descuento).HasPrecision(18, 4)

        'DECIMALES EN PROVEEDOR
        modelBuilder.Entity(Of PROVEEDOR).Property(Function(f) f.LIMITECREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of PROVEEDOR).Property(Function(f) f.FACTURADO_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of PROVEEDOR).Property(Function(f) f.FACTURADO_D).HasPrecision(18, 4)

        'DECIMALES VENTA RECIBO
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.IMPORTETOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.IMPORTETOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.DESCUENTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.DESCUENTOTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.SOBRANTEDECAJA_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.SOBRANTEDECAJA_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.MONTOTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of RECIBO).Property(Function(f) f.MONTOTOTAL_D).HasPrecision(18, 4)

        'DECIMALES EN SALIDA
        modelBuilder.Entity(Of SALIDA).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN TAZA
        modelBuilder.Entity(Of TAZA).Property(Function(f) f.CAMBIO).HasPrecision(18, 4)

        'DECIMALES EN IVA
        modelBuilder.Entity(Of IVA).Property(Function(f) f.PORCENTAJE).HasPrecision(18, 4)

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
        modelBuilder.Entity(Of TRASLADO).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

        'DECIMALES EN VENTA
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.COSTO_TOTAL).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
        modelBuilder.Entity(Of VENTA).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

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