Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
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

End Namespace
