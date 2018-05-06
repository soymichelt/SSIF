Imports System.IO

Public Class frmVistaPrevia

    Private Sub frmVistaPrevia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Dispose()

    End Sub

    Public Sub SelectImage(ByVal path As String)

        Try

            If Me.ExistsImage(path) Then

                Me.pnImagen.Style.BackgroundImage = Me.GetImage(path)

            Else
                Config.MsgErr("No se encuentra la imagen")
                Me.Close()
            End If

        Catch ex As Exception
            Config.MsgErr("Ha ocurrido un error inesperado. Descripción: " & ex.Message)
        End Try

    End Sub

    Private Function GetImage(ByVal path As String) As Image

        Return Image.FromFile(path)

    End Function

    Private Function ExistsImage(ByVal path As String) As Boolean

        Return File.Exists(path)

    End Function

    Private Sub frmVistaPrevia_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnImagen.Width = Me.Width - 76
        pnImagen.Height = Me.Height - 96
        pnImagen.Left = (Me.Width / 2) - (pnImagen.Width / 2) - 9
        pnImagen.Top = (Me.Height / 2) - (pnImagen.Height / 2) - 17
    End Sub

    Private Async Sub frmVistaPrevia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Await Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "PreviewImage",
            "Load",
            "Load PreviewImage",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

    End Sub

End Class