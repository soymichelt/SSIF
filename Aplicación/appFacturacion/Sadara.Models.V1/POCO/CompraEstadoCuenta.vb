Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
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

End Namespace
