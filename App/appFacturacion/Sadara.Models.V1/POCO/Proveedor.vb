Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
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

End Namespace
