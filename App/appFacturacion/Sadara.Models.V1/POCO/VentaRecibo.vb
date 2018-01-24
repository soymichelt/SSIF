Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
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

End Namespace
