Imports System.Runtime.Serialization


'<DataContract()>
Public Class CatalogoProducto
    '<DataMember()>
    Public Property IdProducto As String
    '<DataMember()>
    Public Property IdAlterno As String
    '<DataMember()>
    Public Property IdOriginal As String
    '<DataMember()>
    Public Property Descripcion As String
    '<DataMember()>
    Public Property Marca As String
    '<DataMember()>
    Public Property Modelo As String
    '<DataMember()>
    Public Property Aplicacion As String
    '<DataMember()>
    Public Property Observacion As String
    '<DataMember()>
    Public Property UnidadDeMedida As String
    '<DataMember()>
    Public Property Contiene As Decimal
    '<DataMember()>
    Public Property Presentacion As String
    '<DataMember()>
    Public Property Laboratorio As String
    '<DataMember()>
    Public Property Precio1 As Decimal
    '<DataMember()>
    Public Property Precio2 As Decimal
    '<DataMember()>
    Public Property Precio3 As Decimal
    '<DataMember()>
    Public Property Precio4 As Decimal
    '<DataMember()>
    Public Property ImageName As String
    '<DataMember()>
    Public Property Iva As Boolean
End Class