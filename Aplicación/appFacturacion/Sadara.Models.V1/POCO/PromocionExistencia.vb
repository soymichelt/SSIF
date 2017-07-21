Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PromocionExistencia

        <Key()>
        Public Property PromocionExistenciaID As Guid

        Public Property Descuento As Decimal

        Public Property Cantidad As Decimal

        Public Property PromocionID As Guid

        Public Property IDEXISTENCIA As String


        Public Property Promocion As Promocion

        Public Property Existencia As Existencia

    End Class

End Namespace
