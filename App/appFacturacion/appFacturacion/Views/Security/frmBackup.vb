Public Class frmBackup

    Private Sub btExamine_Click(sender As Object, e As EventArgs) Handles btExamine.Click

        Me.SelectPath()

    End Sub

    Private Sub btBackup_Click(sender As Object, e As EventArgs) Handles btBackup.Click

        Me.CreateBackup()

    End Sub

    Private Sub SelectPath()

        If fbdExamine.ShowDialog() = Windows.Forms.DialogResult.OK Then

            txtPath.Text = fbdExamine.SelectedPath

        End If

    End Sub

    Private Function ValidatePath() As Boolean

        If txtPath.Text.Trim = "" Then

            Config.MsgErr("Seleccione un directorio")

            Return False

        Else

            Return True

        End If

    End Function

    Private Sub CreateBackup()

        Try

            If Me.ValidatePath() Then

                Dim security As New Sadara.BusinessLayer.Security

                security.CreateBackupOfDbAsync(txtPath.Text)

                Config.MsgInfo("Respaldo creado correctamente.")

            End If

        Catch ex As Exception

            Config.MsgErr(ex.Message)

        End Try

    End Sub


End Class