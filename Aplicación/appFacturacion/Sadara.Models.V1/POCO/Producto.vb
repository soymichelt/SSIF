Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
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

End Namespace
