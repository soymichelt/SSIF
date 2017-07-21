Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
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

End Namespace
