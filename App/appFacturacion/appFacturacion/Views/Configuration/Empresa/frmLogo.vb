Public Class frmLogo
    Dim direccion As String = ""
    Private Sub btExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExaminar.Click
        If opAbrir.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.direccion = opAbrir.FileName
            Dim img As Image = Image.FromFile(Me.direccion)
            If img.Width <= 300 And img.Height <= 200 Then
                PictureBox1.Image = img
            Else
                MessageBox.Show("Error, La dimensiones de la imagen no deben exceder 300x200")
            End If
        End If
    End Sub

    Private Sub frmLogo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class