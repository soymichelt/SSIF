Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Data.Entity
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

'MÓDULO DE INVENTARIO
Partial Public Class BODEGA
    <Key()>
    Public Property IDBODEGA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property N_BODEGA As String
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property SERIES As ICollection(Of SERIE) = New HashSet(Of SERIE)
    Public Overridable Property EXISTENCIAS As ICollection(Of EXISTENCIA) = New HashSet(Of EXISTENCIA)
    Public Overridable Property TRASLADOS As ICollection(Of TRASLADO) = New HashSet(Of TRASLADO)
    Public Overridable Property USUARIOS_PRIVILEGIOS As ICollection(Of USUARIO_PRIVILEGIO) = New HashSet(Of USUARIO_PRIVILEGIO)

End Class

Partial Public Class CLIENTE
    <Key()>
    Public Property IDCLIENTE As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property N_CLIENTE As String
    Public Property IDENTIFICACION As String
    Public Property TIPOPERSONA As String
    Public Property NOMBRES As String
    Public Property APELLIDOS As String
    Public Property RAZONSOCIAL As String
    Public Property TELEFONO As String
    Public Property DOMICILIO As String
    Public Property CORREO As String
    Public Property MONEDA As String
    Public Property LIMITECREDITO As Decimal
    Public Property PLAZO As Integer
    Public Property FACTURADO_C As Decimal
    Public Property FACTURADO_D As Decimal
    Public Property ACTIVO As String
    Public Property IDCIUDAD As String

    Public Overridable Property COTIZACIONES As ICollection(Of COTIZACION) = New HashSet(Of COTIZACION)
    Public Overridable Property VENTAS As ICollection(Of VENTA) = New HashSet(Of VENTA)
    Public Overridable Property CONSIGNACIONES As ICollection(Of CONSIGNACION) = New HashSet(Of CONSIGNACION)
    Public Overridable Property DESCONSIGNACIONES As ICollection(Of DESCONSIGNACION) = New HashSet(Of DESCONSIGNACION)
    Public Overridable Property RECIBOS As ICollection(Of RECIBO) = New HashSet(Of RECIBO)

    Public Overridable Property CIUDAD As CIUDAD
End Class

Partial Public Class COMPRA

    <Key()>
    Public Property IDCOMPRA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property IDPROVEEDOR As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_COMPRAS As ICollection(Of DETALLE_COMPRA) = New HashSet(Of DETALLE_COMPRA)
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
    Public Property IDPROVEEDOR As String
    Public Property IDCOMPRA As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property COMPRAS_DEVOLUCIONES_DETALLES As ICollection(Of COMPRA_DEVOLUCION_DETALLE) = New HashSet(Of COMPRA_DEVOLUCION_DETALLE)
    Public Overridable Property COMPRA As COMPRA
    Public Overridable Property PROVEEDOR As PROVEEDOR

End Class

Partial Public Class COMPRA_DEVOLUCION_DETALLE
    <Key()>
    Public Property IDDETALLEDEVOLUCION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property IDPROVEEDOR As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property COMPRAS_RECIBOS_DETALLES As ICollection(Of COMPRA_RECIBO_DETALLE) = New HashSet(Of COMPRA_RECIBO_DETALLE)
    Public Overridable Property COMPRAS_PAGOS_PROVEEDORES As ICollection(Of COMPRA_PAGO_PROVEEDOR) = New HashSet(Of COMPRA_PAGO_PROVEEDOR)
    Public Overridable Property PROVEEDOR As PROVEEDOR
End Class

Partial Public Class COMPRA_RECIBO_DETALLE
    <Key()>
    Public Property IDDETALLERECIBO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHACONSIGNACION As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property IDTRABAJADOR As String
    Public Property IDCLIENTE As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_CONSIGNACIONES As ICollection(Of DETALLE_DESCONSIGNACION) = New HashSet(Of DETALLE_DESCONSIGNACION)
    Public Overridable Property TRABAJADOR As TRABAJADOR
End Class

Partial Public Class COTIZACION
    <Key()>
    Public Property IDCOTIZACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property IDTRABAJADOR As String
    Public Property IDCLIENTE As String
    Public Property IDTAZA As String
    Public Property ANULADO As String

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_COTIZACIONES As ICollection(Of DETALLE_COTIZACION) = New HashSet(Of DETALLE_COTIZACION)
    Public Overridable Property TRABAJADOR As TRABAJADOR

End Class


Partial Public Class DESCONSIGNACION
    <Key()>
    Public Property IDDESCONSIGNACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHACONSIGNACION As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property IDTRABAJADOR As String
    Public Property IDCLIENTE As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_DESCONSIGNACIONES As ICollection(Of DETALLE_DESCONSIGNACION) = New HashSet(Of DETALLE_DESCONSIGNACION)
    Public Overridable Property TRABAJADOR As TRABAJADOR
End Class

Partial Public Class DETALLE_COMPRA
    <Key()>
    Public Property IDDETALLECOMPRA As String

    Public Property EXISTENCIA_PRODUCTO As Decimal
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property CANTIDAD As Decimal
    Public Property COSTO As Decimal
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
    Public Property SALDOCREDITO_C As Decimal
    Public Property SALDOCREDITO_D As Decimal
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
    Public Property IDTRABAJADOR As String
    Public Property IDCLIENTE As String
    Public Property IDVENTA As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String
    Public Property IDTAZA As String

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_DEVOLUCIONES As ICollection(Of DETALLE_DEVOLUCION) = New HashSet(Of DETALLE_DEVOLUCION)
    Public Overridable Property VENTA As VENTA
    Public Overridable Property TRABAJADOR As TRABAJADOR
    Public Overridable Property CLIENTE As CLIENTE

End Class

Partial Public Class ENTRADA
    <Key()>
    Public Property IDENTRADA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHAENTRADA As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_ENTRADAS As ICollection(Of DETALLE_ENTRADA) = New HashSet(Of DETALLE_ENTRADA)

End Class

Partial Public Class ESTADO_DE_CUENTA
    <Key()>
    Public Property IDESTADO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property ACTIVO As String
    Public Property IDTAZA As String

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property VENTA As VENTA
    Public Overridable Property RECIBO As RECIBO
End Class

Partial Public Class EXISTENCIA
    <Key()>
    Public Property IDEXISTENCIA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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

End Class

Partial Public Class KARDEX
    <Key()>
    Public Property IDKARDEX As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)

End Class

Partial Public Class PRODUCTO
    <Key()>
    Public Property IDPRODUCTO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property IMAGENAME As String
    Public Property FECHAVENCIMIENTO As Nullable(Of DateTime)
    Public Property UBICACIONFISICA As String
    Public Property CANTIDAD As Decimal
    Public Property SALDO As Decimal
    Public Property ACTIVO As String

    Public Overridable Property EXISTENCIAS As ICollection(Of EXISTENCIA) = New HashSet(Of EXISTENCIA)
    Public Overridable Property MARCA As MARCA
    Public Overridable Property PRESENTACION As PRESENTACION
    Public Overridable Property UNIDAD_DE_MEDIDA As UNIDAD_DE_MEDIDA
    Public Overridable Property LABORATORIO As LABORATORIO
End Class

Public Class PRESENTACION
    <Key()>
    Public Property IDPRESENTACION As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)
End Class
Public Class LABORATORIO
    <Key()>
    Public Property IDLABORATORIO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)
End Class
Public Class UNIDAD_DE_MEDIDA
    <Key()>
    Public Property IDUNIDAD As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property PRODUCTOS As ICollection(Of PRODUCTO) = New HashSet(Of PRODUCTO)
End Class

Partial Public Class PERIODO
    <Key()>
    Public Property IDPERIODO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property AÑOLECTIVO As Short
    Public Property INICIO As DateTime
    Public Property FINAL As DateTime
    Public Property APERTURA As Nullable(Of DateTime)
    Public Property CIERRE As Nullable(Of DateTime)
    Public Property ACTUAL As String
    Public Property ACTIVO As String
End Class

Partial Public Class PROVEEDOR
    <Key()>
    Public Property IDPROVEEDOR As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property N_PROVEEDOR As String
    Public Property IDENTIFICACION As String
    Public Property TIPOPERSONA As String
    Public Property NOMBRES As String
    Public Property APELLIDOS As String
    Public Property RAZONSOCIAL As String
    Public Property TELEFONO As String
    Public Property DOMICILIO As String
    Public Property CORREO As String
    Public Property MONEDA As String
    Public Property LIMITECREDITO As Decimal
    Public Property PLAZO As Integer
    Public Property FACTURADO_C As Decimal
    Public Property FACTURADO_D As Decimal
    Public Property ACTIVO As String
    Public Property IDCIUDAD As String

    Public Overridable Property CIUDAD As CIUDAD
    Public Overridable Property COMPRAS As ICollection(Of COMPRA) = New HashSet(Of COMPRA)
    Public Overridable Property COMPRAS_RECIBOS As ICollection(Of COMPRA_RECIBO) = New HashSet(Of COMPRA_RECIBO)
End Class

Partial Public Class RECIBO
    <Key()>
    Public Property IDRECIBO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property IDCLIENTE As String
    Public Property ANULADO As String
    Public Property IDTAZA As String

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_RECIBOS As ICollection(Of DETALLE_RECIBO) = New HashSet(Of DETALLE_RECIBO)
    Public Overridable Property ESTADOS_DE_CUENTAS As ICollection(Of ESTADO_DE_CUENTA) = New HashSet(Of ESTADO_DE_CUENTA)
End Class

Partial Public Class SALIDA
    <Key()>
    Public Property IDSALIDA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHASALIDA As Date
    Public Property OBSERVACION As String
    Public Property TOTAL As Decimal
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property DETALLES_SALIDAS As ICollection(Of DETALLE_SALIDA) = New HashSet(Of DETALLE_SALIDA)
End Class

Partial Public Class SERIE
    <Key()>
    Public Property IDSERIE As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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

Partial Public Class PAIS
    <Key()>
    Public Property IDPAIS As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property N_PAIS As String
    Public Property ABREVIATURA1 As String
    Public Property ABREVIATURA2 As String
    Public Property NOMBRE As String
    Public Property ACTIVO As String

    Public Overridable Property CIUDADES As ICollection(Of CIUDAD) = New HashSet(Of CIUDAD)
End Class

Partial Public Class CIUDAD
    <Key()>
    Public Property IDCIUDAD As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property N_CIUDAD As String
    Public Property NOMBRE As String
    Public Property IDPAIS As String
    Public Property ACTIVO As String

    Public Overridable Property PAIS As PAIS
    Public Overridable Property TRABAJADORES As ICollection(Of TRABAJADOR) = New HashSet(Of TRABAJADOR)
    Public Overridable Property CLIENTES As ICollection(Of CLIENTE) = New HashSet(Of CLIENTE)
    Public Overridable Property PROVEEDORES As ICollection(Of PROVEEDOR) = New HashSet(Of PROVEEDOR)
End Class

Partial Public Class TRABAJADOR
    <Key()>
    Public Property IDTRABAJADOR As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property N_TRABAJADOR As String
    Public Property IDENTIFICACION As String
    Public Property NOMBRES As String
    Public Property APELLIDOS As String
    Public Property TELEFONO As String
    Public Property CORREO As String
    Public Property DOMICILIO As String
    Public Property SEXO As String
    Public Property ESTADO_CIVIL As String
    Public Property N_INSS As String
    Public Property N_RUC As String
    Public Property IDENTIFICACION_CONYUGUE As String
    Public Property NOMBRE_CONYUGUE As String
    Public Property IDENTIFICACION_MADRE As String
    Public Property NOMBRE_MADRE As String
    Public Property IDENTIFICACION_PADRE As String
    Public Property NOMBRE_PADRE As String
    Public Property MONEDA As String
    Public Property SUELDO_BASE_HORA As Boolean
    Public Property SUELDO As Decimal
    Public Property COMISION_POR As Decimal
    Public Property OBSERVACION As String
    Public Property IMAGENAME As String
    Public Property FILENAME As String
    Public Property USUARIO As Boolean
    Public Property NOMBREUSUARIO As String
    Public Property CONTRASEÑA As String
    Public Property ACTIVO As String
    Public Property IDPUESTO As String
    Public Property IDAREA As String
    Public Property IDCIUDAD As String

    Public Overridable Property COTIZACIONES As ICollection(Of COTIZACION) = New HashSet(Of COTIZACION)
    Public Overridable Property VENTAS As ICollection(Of VENTA) = New HashSet(Of VENTA)
    Public Overridable Property DEVOLUCIONES_CLIENTES As ICollection(Of DEVOLUCION_CLIENTE) = New HashSet(Of DEVOLUCION_CLIENTE)
    Public Overridable Property CONSIGNACIONES As ICollection(Of CONSIGNACION) = New HashSet(Of CONSIGNACION)
    Public Overridable Property DESCONSIGNACIONES As ICollection(Of DESCONSIGNACION) = New HashSet(Of DESCONSIGNACION)
    Public Overridable Property POLIZAS As ICollection(Of POLIZA) = New HashSet(Of POLIZA)

    Public Overridable Property TRABAJADOR_PUESTO As TRABAJADOR_PUESTO
    Public Overridable Property TRABAJADOR_AREA As TRABAJADOR_AREA
    Public Overridable Property CIUDAD As CIUDAD
    Public Overridable Property TRABAJADOR_PLANILLA_DETALLE As ICollection(Of TRABAJADOR_PLANILLA_DETALLE) = New HashSet(Of TRABAJADOR_PLANILLA_DETALLE)
End Class

Partial Public Class TRABAJADOR_AREA
    <Key()>
    Public Property IDAREA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property NOMBRE_AREA As String
    Public Property DESCRIPCION As String
    Public Property ACTIVO As String

    Public Overridable Property TRABAJADORES As ICollection(Of TRABAJADOR) = New HashSet(Of TRABAJADOR)
End Class

Partial Public Class TRABAJADOR_PUESTO
    <Key()>
    Public Property IDPUESTO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property NOMBRE_PUESTO As String
    Public Property DESCRIPCION As String
    Public Property CONTADOR As Boolean
    Public Property VENDEDOR As Boolean
    Public Property INVENTARISTA As Boolean
    Public Property CAJERO As Boolean
    Public Property MANTENIMIENTO As Boolean
    Public Property ADMINISTRADOR_EMPRESA As Boolean
    Public Property MARKETING As Boolean
    Public Property RRHH As Boolean
    Public Property INFORMATICO As Boolean
    Public Property GERENTE As Boolean
    Public Property ASEO As Boolean
    Public Property CONSERJE As Boolean
    Public Property SECRETARIO As Boolean
    Public Property SOPORTE_TECNICO As Boolean
    Public Property ATENCION_CLIENTE As Boolean
    Public Property DISEÑADOR As Boolean
    Public Property OTRO As String
    Public Property ACTIVO As String

    Public Overridable Property TRABAJADORES As ICollection(Of TRABAJADOR) = New HashSet(Of TRABAJADOR)
End Class

Partial Public Class TRABAJADOR_PLANILLA
    <Key()>
    Public Property IDPLANILLA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property FECHA1 As Date
    Public Property FECHA2 As Date
    Public Property OBSERVACION As String
    Public Property TOTAL_SUELDO_BASE As Decimal
    Public Property TOTAL_SUELDO_HORA_NORMAL As Decimal
    Public Property TOTAL_SUELDO_HORA_EXTRA As Decimal
    Public Property TOTAL_COMISION As Decimal
    Public Property TOTAL_SALARIO_BRUTO As Decimal
    Public Property TOTAL_DEDUCCION As Decimal
    Public Property TOTAL_SALARIO_NETO As Decimal
    Public Property ANULADO As String

    Public Overridable Property TRABAJADORES_PLANILLAS_DETALLES As ICollection(Of TRABAJADOR_PLANILLA_DETALLE) = New HashSet(Of TRABAJADOR_PLANILLA_DETALLE)
End Class

Partial Public Class TRABAJADOR_PLANILLA_DETALLE
    <Key()>
    Public Property IDPLANILLADETALLE As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property IDPLANILLA As String
    Public Property IDTRABAJADOR As String
    Public Property SUELDO_BASE As Decimal
    Public Property HORA_NORMAL As Decimal
    Public Property HORA_NORMAL_TARIFA As Decimal
    Public Property HORA_NORMAL_TOTAL As Decimal
    Public Property HORA_EXTRA As Decimal
    Public Property HORA_EXTRA_TARIFA As Decimal
    Public Property HORA_EXTRA_TOTAL As Decimal
    Public Property COMISION As Decimal
    Public Property SALARIO_BRUTO As Decimal
    Public Property SALARIO_NETO As Decimal

    Public Overridable Property TRABAJADOR_PLANILLA As TRABAJADOR_PLANILLA
    Public Overridable Property TRABAJADOR As TRABAJADOR
End Class

Partial Public Class TRASLADO
    <Key()>
    Public Property IDTRASLADO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property FECHATRASLADO As Date
    Public Property IDBODEGA As String
    Public Property CONCEPTO As String
    Public Property REFERENCIA As String
    Public Property TOTAL As Decimal
    Public Property REIMPRESION As String
    Public Property ANULADO As String

    Public Overridable Property SERIE As SERIE
    Public Overridable Property BODEGA As BODEGA
    Public Overridable Property DETALLES_TRASLADOS As ICollection(Of DETALLE_TRASLADO) = New HashSet(Of DETALLE_TRASLADO)

End Class

Partial Public Class USUARIO
    <Key()>
    Public Property IDUSUARIO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property N_USUARIO As String
    Public Property NOMBRES As String
    Public Property APELLIDOS As String
    Public Property NOMBRECUENTA As String
    Public Property CONTRASEÑA As String
    Public Property IMAGENAME As String
    Public Property OBSERVACION As String
    Public Property ACTIVO As String

    Public Overridable Property USUARIOS_PRIVILEGIOS As ICollection(Of USUARIO_PRIVILEGIO) = New HashSet(Of USUARIO_PRIVILEGIO)
End Class

'Partial Public Class USUARIO_ROL
'    <Key()>
'    Public Property IDROL As String
'    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>

'End Class

Partial Public Class USUARIO_PRIVILEGIO
    <Key()>
    Public Property IDPRIVILEGIO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property PERMISO As String
    Public Property IDUSUARIO As String
    Public Property IDBODEGA As String

    Public Overridable Property USUARIO As USUARIO
    Public Overridable Property BODEGA As BODEGA
End Class

Partial Public Class VENTA
    <Key()>
    Public Property IDVENTA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
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
    Public Property IDTRABAJADOR As String
    Public Property IDCLIENTE As String
    Public Property REIMPRESION As String
    Public Property ANULADO As String
    Public Property IDTAZA As String

    Public Overridable Property TAZA As TAZA
    Public Overridable Property SERIE As SERIE
    Public Overridable Property CLIENTE As CLIENTE
    Public Overridable Property DETALLES_VENTAS As ICollection(Of DETALLE_VENTA) = New HashSet(Of DETALLE_VENTA)
    Public Overridable Property TRABAJADOR As TRABAJADOR
    Public Overridable Property DETALLES_RECIBOS As ICollection(Of DETALLE_RECIBO) = New HashSet(Of DETALLE_RECIBO)
    Public Overridable Property DEVOLUCIONES_CLIENTES As ICollection(Of DEVOLUCION_CLIENTE) = New HashSet(Of DEVOLUCION_CLIENTE)
    Public Overridable Property ESTADOS_DE_CUENTAS As ICollection(Of ESTADO_DE_CUENTA) = New HashSet(Of ESTADO_DE_CUENTA)
End Class

'MÓDULO DE CONTABILIDAD
Public Class PERIODO_CONTABLE
    <Key()>
    Public Property IDPERIODO As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property INICIO As DateTime
    Public Property FINAL As DateTime
End Class

Public Class CUENTA
    <Key()>
    Public Property IDCUENTA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property CUENTA_SUPERIOR As String
    Public Property CODIGO_CUENTA_SUPERIOR As String
    Public Property NIVEL As Integer
    Public Property CODIGO_CUENTA As String
    Public Property CONCEPTO As String
    Public Property NATURALEZA As String
    Public Property DEBER_C As Decimal
    Public Property DEBER_D As Decimal
    Public Property HABER_C As Decimal
    Public Property HABER_D As Decimal
    Public Property SALDO_C As Decimal
    Public Property SALDO_D As Decimal
    Public Property ACTIVO As String

    Public Overridable Property POLIZAS_DETALLES As ICollection(Of POLIZA_DETALLE) = New HashSet(Of POLIZA_DETALLE)
End Class

Public Class POLIZA
    <Key()>
    Public Property IDPOLIZA As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property IDSERIE As String
    Public Property CONSECUTIVO As String
    Public Property TIPO As String
    Public Property FECHAPOLIZA As DateTime
    Public Property CONCEPTO As String
    Public Property TOTAL As Decimal
    Public Property IDTRABAJADOR As String

    Public Overridable Property POLIZAS_DETALLES As ICollection(Of POLIZA_DETALLE) = New HashSet(Of POLIZA_DETALLE)
    Public Overridable Property SERIE As SERIE
    Public Overridable Property TRABAJADOR As TRABAJADOR
End Class

Public Class POLIZA_DETALLE
    <Key>
    Public Property IDPOLIZADETALLE As String
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property DEBER_C As Decimal
    Public Property DEBER_D As Decimal
    Public Property HABER_C As Decimal
    Public Property HABER_D As Decimal
    Public Property IDPOLIZA As String
    Public Property IDCUENTA As String

    Public Overridable Property CUENTA As CUENTA
    Public Overridable Property POLIZA As POLIZA
End Class

'MODELO DE DATOS EN VB.NET
Public Class MODELODEDATOS
    Inherits DbContext
    Public Sub New()
        MyBase.New("name=appFacturacion.My.MySettings.CadenaConexion")
    End Sub

    'MODELO DE CONTEXTO
    'VARIABLES DE NAVEGACION

    Public Property BODEGAS() As DbSet(Of BODEGA)
    Public Property CIUDADES() As DbSet(Of CIUDAD)
    Public Property CLIENTES() As DbSet(Of CLIENTE)
    Public Property COMPRAS() As DbSet(Of COMPRA)
    Public Property COMPRAS_DEVOLUCIONES As DbSet(Of COMPRA_DEVOLUCION)
    Public Property COMPRAS_DEVOLUCIONES_DETALLES As DbSet(Of COMPRA_DEVOLUCION_DETALLE)
    Public Property COMPRAS_RECIBOS As DbSet(Of COMPRA_RECIBO)
    Public Property COMPRAS_RECIBOS_DETALLES As DbSet(Of COMPRA_RECIBO_DETALLE)
    Public Property COMPRAS_PAGOS_PROVEEDORES As DbSet(Of COMPRA_PAGO_PROVEEDOR)
    Public Property CONSIGNACIONES() As DbSet(Of CONSIGNACION)
    Public Property COTIZACIONES() As DbSet(Of COTIZACION)
    Public Property CUENTAS As DbSet(Of CUENTA)
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
    Public Property PAISES() As DbSet(Of PAIS)
    Public Property PERIODOS() As DbSet(Of PERIODO)
    Public Property POLIZAS() As DbSet(Of POLIZA)
    Public Property POLIZAS_DETALLES() As DbSet(Of POLIZA_DETALLE)
    Public Property PRESENTACIONES() As DbSet(Of PRESENTACION)
    Public Property PRODUCTOS() As DbSet(Of PRODUCTO)
    Public Property PROVEEDORES() As DbSet(Of PROVEEDOR)
    Public Property RECIBOS() As DbSet(Of RECIBO)
    Public Property SALIDAS() As DbSet(Of SALIDA)
    Public Property SERIES() As DbSet(Of SERIE)
    Public Property TAZAS() As DbSet(Of TAZA)
    Public Property IVAS() As DbSet(Of IVA)
    Public Property TRABAJADORES() As DbSet(Of TRABAJADOR)
    Public Property TRABAJADORES_AREAS() As DbSet(Of TRABAJADOR_AREA)
    Public Property TRABAJADORES_PLANILLAS() As DbSet(Of TRABAJADOR_PLANILLA)
    Public Property TRABAJADORES_PLANILLAS_DETALLES() As DbSet(Of TRABAJADOR_PLANILLA_DETALLE)
    Public Property TRABAJADORES_PUESTOS() As DbSet(Of TRABAJADOR_PUESTO)
    Public Property TRASLADOS() As DbSet(Of TRASLADO)
    Public Property UNIDADES_DE_MEDIDAS() As DbSet(Of UNIDAD_DE_MEDIDA)
    Public Property USUARIOS() As DbSet(Of USUARIO)
    Public Property USUARIOS_PRIVILEGIOS As DbSet(Of USUARIO_PRIVILEGIO)
    Public Property VENTAS() As DbSet(Of VENTA)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention)()
        MyBase.OnModelCreating(modelBuilder)
    End Sub
End Class

Public Class fecha
    Inherits DataContext
    Sub New()
        MyBase.New("Data Source=.\UNANFAREMCH;Initial Catalog=BDFACTURACION01;Integrated Security=True")
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