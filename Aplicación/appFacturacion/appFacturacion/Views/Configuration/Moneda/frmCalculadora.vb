Public Class frmCalculadora
    Public retornar As String
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        retornar = ""
    End Sub

    Private Sub calculadora_CancelButtonClick(sender As Object, e As EventArgs) Handles calculadora.CancelButtonClick
        Me.Close()
    End Sub

    Private Sub calculadora_OkButtonClick(sender As Object, e As EventArgs) Handles calculadora.OkButtonClick
        retornar = calculadora.Value.ToString(Config.f_m)
        Me.Close()
    End Sub

    Private Sub frmCalculadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class