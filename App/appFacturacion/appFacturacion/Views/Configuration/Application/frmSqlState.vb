Imports System.ServiceProcess

Public Class frmSqlState
    Public SQLState As Short = 0
    Function Exist() As Boolean
        Try
            Dim c = ServiceController.GetServices.Where(Function(f) f.ServiceName.Equals(Config.SQLServicesName)).FirstOrDefault
            If c IsNot Nothing Then
                If c.Status = ServiceControllerStatus.Running Then
                    lblEstado.Text = "Iniciado"
                    btIniciar.Enabled = False
                    lblEstado.ForeColor = Color.FromArgb(73, 177, 101)
                    Me.picState.Image = Global.appFacturacion.My.Resources.Resources.stIniciado
                    Me.SQLState = 1
                    Return True
                ElseIf c.Status = ServiceControllerStatus.Stopped Or c.Status = ServiceControllerStatus.StopPending Or c.Status = ServiceControllerStatus.Paused Or c.Status = ServiceControllerStatus.PausePending Or c.Status = ServiceControllerStatus.ContinuePending Then
                    lblEstado.Text = "Detenido"
                    btIniciar.Enabled = True
                    lblEstado.ForeColor = Color.FromArgb(234, 67, 53)
                    Me.picState.Image = Global.appFacturacion.My.Resources.Resources.stDetenido
                    Me.SQLState = 2
                Else
                    lblEstado.Text = "No Iniciado"
                    btIniciar.Enabled = False
                    lblEstado.ForeColor = Color.FromArgb(251, 188, 5)
                    Me.picState.Image = Global.appFacturacion.My.Resources.Resources.stDetenido
                    Me.SQLState = 3
                End If
            Else
                lblEstado.Text = "No encontrado"
                lblEstado.ForeColor = Color.FromArgb(251, 188, 5)
                btIniciar.Enabled = False
                lblEstado.ForeColor = Color.FromArgb(234, 67, 53)
                Me.picState.Image = Global.appFacturacion.My.Resources.Resources.stDetenido
                Me.SQLState = 4
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
            lblEstado.Text = "Error"
            lblEstado.ForeColor = Color.FromArgb(251, 188, 5)
            btIniciar.Enabled = False
            Me.picState.Image = Global.appFacturacion.My.Resources.Resources.stDetenido
            Me.SQLState = 5
        End Try
        Return False
    End Function

    Private Sub btIniciar_Click(sender As Object, e As EventArgs) Handles btIniciar.Click
        Try
            If Not Me.Exist() Then
                Dim c = ServiceController.GetServices.Where(Function(f) f.ServiceName.Equals(Config.SQLServicesName)).FirstOrDefault
                If c.Status <> ServiceControllerStatus.Running Then
                    c.Start()
                    Me.Exist()
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmSqlState_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Exist()
    End Sub

    Private Sub btActualizar_Click(sender As Object, e As EventArgs) Handles btActualizar.Click
        Me.Exist()
    End Sub
End Class