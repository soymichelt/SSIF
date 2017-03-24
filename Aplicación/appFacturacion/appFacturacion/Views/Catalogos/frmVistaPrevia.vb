Public Class frmVistaPrevia
    Private Sub frmVistaPrevia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmVistaPrevia_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnImagen.Width = Me.Width - 76
        pnImagen.Height = Me.Height - 96
        pnImagen.Left = (Me.Width / 2) - (pnImagen.Width / 2) - 9
        pnImagen.Top = (Me.Height / 2) - (pnImagen.Height / 2) - 17
    End Sub

    Private Sub frmVistaPrevia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class