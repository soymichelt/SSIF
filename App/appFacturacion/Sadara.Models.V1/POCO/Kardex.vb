Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class Kardex

        <Key()>
        Public Property IDKARDEX As String

        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
        Public Property N As Long

        Public Property Reg As Nullable(Of DateTime)

        Public Property DetailId As Nullable(Of Guid)

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

        Public Overridable Property Existencia As Existencia

        Public Overridable Property Serie As Serie

    End Class

End Namespace
