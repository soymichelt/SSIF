Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace POCO

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Partial Public Class ImpuestoValorAgregado

        <Key()>
        Public Property IDIVA As String

        Public Property FECHA As Date

        Public Property PORCENTAJE As Decimal

    End Class

End Namespace
