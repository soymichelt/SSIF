Public Class INFORMECONSIGNACION
    Public IDCLIENTE As String
    Public N_CLIENTE As String
    Public NOMBRECLIENTE As String
    Public RAZONSOCIAL As String
    Public MARCA As String
    Public IDALTERNO As String
    Public IDORIGINAL As String
    Public NOMBREPRODUCTO As String
    Public UNIDAD_DE_MEDIDA As String
    Public CONSIGNADO As Decimal
End Class

Public Class ESTADODECUENTA
    Public N As Long
    Public SERIE As String
    Public N_DOCUMENTO As String
    Public N_COMPRA As String
    Public FORMADEPAGO As String
    Public N_PAGO As String
    Public OPERACION As String
    Public FECHA As Date
    Public PLAZO As String
    Public MONEDA As String
    Public TAZA As Decimal
    Public FECHAVENCIMIENTO As String
    Public DEBE As Decimal
    Public HABER As Decimal
    Public SALDO As Decimal

    'Dias vencidos
    Public FV_1_30 As Decimal
    Public FV_31_60 As Decimal
    Public FV_61_90 As Decimal

    Public ID As String
End Class

Public Class ESTADODERESULTADOS
    Public CUENTA As String
    Public COLUMNA1 As String
    Public COLUMNA2 As String
    Public COLUMNA3 As String
    Public COLUMNA4 As String
    Public TOTAL As String
End Class

Public Class LST_DETALLE_VENTA
    Public IDEXISTENCIA As String
    Public IDALTERNO As String
    Public DESCRIPCION As String
    Public IVA As Boolean
    Public MARCA As String
    Public UNIDAD_DE_MEDIDA As String
    Public PRESENTACION As String
    Public EXISTENCIA As Decimal
    Public CANTIDAD As Decimal
    Public PRECIOUNITARIO_C As Decimal
    Public PRECIOUNITARIO_D As Decimal
    Public DESCUENTO_POR As Decimal
    Public DESCUENTO_DIN_C As Decimal
    Public DESCUENTO_DIN_D As Decimal
    Public IVA_POR As Decimal
    Public IVA_DIN_C As Decimal
    Public IVA_DIN_D As Decimal
    Public PRECIONETO_C As Decimal
    Public PRECIONETO_D As Decimal
    Public SUBTOTAL_C As Decimal
    Public SUBTOTAL_D As Decimal
    Public DESCUENTO_DIN_TOTAL_C As Decimal
    Public DESCUENTO_DIN_TOTAL_D As Decimal
    Public IVA_DIN_TOTAL_C As Decimal
    Public IVA_DIN_TOTAL_D As Decimal
    Public TOTAL_C As Decimal
    Public TOTAL_D As Decimal
End Class

Public Class LST_DETALLE_COMPRA
    Public IDEXISTENCIA As String
    Public IDALTERNO As String
    Public DESCRIPCION As String
    Public IVA As Boolean
    Public MARCA As String
    Public UNIDAD_DE_MEDIDA As String
    Public PRESENTACION As String
    Public EXISTENCIA As Decimal
    Public CANTIDAD As Decimal
    Public PRECIOUNITARIO_C As Decimal
    Public PRECIOUNITARIO_D As Decimal
    Public DESCUENTO_POR As Decimal
    Public DESCUENTO_DIN_C As Decimal
    Public DESCUENTO_DIN_D As Decimal
    Public IVA_POR As Decimal
    Public IVA_DIN_C As Decimal
    Public IVA_DIN_D As Decimal
    Public PRECIONETO_C As Decimal
    Public PRECIONETO_D As Decimal
    Public SUBTOTAL_C As Decimal
    Public SUBTOTAL_D As Decimal
    Public DESCUENTO_DIN_TOTAL_C As Decimal
    Public DESCUENTO_DIN_TOTAL_D As Decimal
    Public IVA_DIN_TOTAL_C As Decimal
    Public IVA_DIN_TOTAL_D As Decimal
    Public TOTAL_C As Decimal
    Public TOTAL_D As Decimal
End Class

Public Class LST_DETALLE_DEVOLUCION_VENTA
    Public IDEXISTENCIA As String
    Public IDALTERNO As String
    Public DESCRIPCION As String
    Public IVA As Boolean
    Public MARCA As String
    Public UNIDAD_DE_MEDIDA As String
    Public PRESENTACION As String
    Public EXISTENCIA As Decimal
    Public CANTIDAD As Decimal
    Public PRECIOUNITARIO_C As Decimal
    Public PRECIOUNITARIO_D As Decimal
    Public DESCUENTO_POR As Decimal
    Public DESCUENTO_DIN_C As Decimal
    Public DESCUENTO_DIN_D As Decimal
    Public IVA_POR As Decimal
    Public IVA_DIN_C As Decimal
    Public IVA_DIN_D As Decimal
    Public PRECIONETO_C As Decimal
    Public PRECIONETO_D As Decimal
    Public SUBTOTAL_C As Decimal
    Public SUBTOTAL_D As Decimal
    Public DESCUENTO_DIN_TOTAL_C As Decimal
    Public DESCUENTO_DIN_TOTAL_D As Decimal
    Public IVA_DIN_TOTAL_C As Decimal
    Public IVA_DIN_TOTAL_D As Decimal
    Public TOTAL_C As Decimal
    Public TOTAL_D As Decimal
End Class

Public Class LST_DETALLE_DEVOLUCION_COMPRA
    Public IDEXISTENCIA As String
    Public IDALTERNO As String
    Public DESCRIPCION As String
    Public IVA As Boolean
    Public MARCA As String
    Public UNIDAD_DE_MEDIDA As String
    Public PRESENTACION As String
    Public EXISTENCIA As Decimal
    Public CANTIDAD As Decimal
    Public PRECIOUNITARIO_C As Decimal
    Public PRECIOUNITARIO_D As Decimal
    Public DESCUENTO_POR As Decimal
    Public DESCUENTO_DIN_C As Decimal
    Public DESCUENTO_DIN_D As Decimal
    Public IVA_POR As Decimal
    Public IVA_DIN_C As Decimal
    Public IVA_DIN_D As Decimal
    Public PRECIONETO_C As Decimal
    Public PRECIONETO_D As Decimal
    Public SUBTOTAL_C As Decimal
    Public SUBTOTAL_D As Decimal
    Public DESCUENTO_DIN_TOTAL_C As Decimal
    Public DESCUENTO_DIN_TOTAL_D As Decimal
    Public IVA_DIN_TOTAL_C As Decimal
    Public IVA_DIN_TOTAL_D As Decimal
    Public TOTAL_C As Decimal
    Public TOTAL_D As Decimal
End Class

Public Class LST_DETALLE_RECIBO
    Public IDVENTA As String
    Public SERIE As String
    Public CONSECUTIVO As String
    Public FECHA As DateTime
    Public MONEDA As String
    Public TAZA As Decimal
    Public SUBTOTAL_C As Decimal
    Public SUBTOTAL_D As Decimal
    Public DESCUENTO_DIN_TOTAL_C As Decimal
    Public DESCUENTO_DIN_TOTAL_D As Decimal
    Public IVA_DIN_TOTAL_C As Decimal
    Public IVA_DIN_TOTAL_D As Decimal
    Public TOTAL_C As Decimal
    Public TOTAL_D As Decimal


    Public SALDOCREDITO As Decimal
    Public OPERACION As String
    Public IMPORTE_C As Decimal
    Public IMPORTE_D As Decimal
    Public DESCUENTO_C As Decimal
    Public DESCUENTO_D As Decimal
    Public NUEVO_SALDO_C As Decimal
    Public NUEVO_SALDO_D As Decimal

End Class

Public Class LST_VENTA_DETALLADA
    Public Property IDALTERNO As String
    Public Property DESCRIPCION As String
    Public Property CANTIDAD As Decimal
    Public Property DEVOLUCION As Decimal
    Public Property PRECIO_PROMEDIO As Decimal
    Public Property SUBTOTAL As Decimal
    Public Property COSTO_PROMEDIO As Decimal
    Public Property COSTO_TOTAL As Decimal
    Public Property UTILIDAD As Decimal
    Public Property IVA As Decimal
    Public Property TOTAL As Decimal


End Class

Public Class lstProductosVendidos
    Public Property IDAlterno As String
    Public Property Descripcion As String
    Public Property Cantidad As Decimal
    Public Property CostoPromedio As Decimal
    Public Property CostoTotal As Decimal
    Public Property PrecioPromedio As Decimal
    Public Property Descuento As Decimal
    Public Property SubTotal As Decimal
    Public Property Utilidad As Decimal
    Public Property Iva As Decimal
    Public Property Total As Decimal
End Class