Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Promocion

        <Key()>
        Public Property PromocionID As Guid

        Public Property DescripcionPromocion As String

        Public Property FechaInicioPromocion As DateTime

        Public Property FechaFinalPromocion As DateTime


        Public Overridable Property PromocionesExistencias As ICollection(Of PromocionExistencia)

    End Class

End Namespace
