Public Class Log

    Private Shared _instance As Log

    Private WithEvents backgroundWorker As System.ComponentModel.BackgroundWorker

    Private Shared Function InstanceIsInitialized() As Boolean

        Return If(_instance IsNot Nothing, True, False)

    End Function

    Private Shared Sub InstanceInitialize()

        _instance = New Log()

    End Sub

    Private Sub BackgroundWorkerInitialize()

        Me.backgroundWorker = New System.ComponentModel.BackgroundWorker()

    End Sub

    Public Shared ReadOnly Property Instance As Log

        Get

            If (Not InstanceIsInitialized()) Then
                InstanceInitialize()
            End If

            Return _instance

        End Get

    End Property

    Protected Sub New()

    End Sub

    Public Sub RegisterActivity(ByVal businessId As Guid, ByVal type As String, ByVal tag As String, ByVal activityValue As String, Optional ByVal optionalMessage As String = Nothing, Optional ByVal userId As Guid = Nothing)

        Try

            'Dim isActivitySave As Boolean = False

            'Do

            '    If Not backgroundWorker.IsBusy Then

            '        Dim activity = New Sadara.Models.V2.POCO.ActivityEntity() With {
            '            .BusinessId = businessId,
            '            .Type = type,
            '            .Tag = tag,
            '            .ActivityValue = activityValue,
            '            .OptionalMessage = optionalMessage,
            '            .UserId = userId
            '        }

            '        backgroundWorker.RunWorkerAsync(activity)

            '        isActivitySave = True

            '    End If

            'Loop While Not isActivitySave

            Me.BackgroundWorkerInitialize()

            Dim activity = New Sadara.Models.V2.POCO.ActivityEntity() With {
                .BusinessId = businessId,
                .Type = type,
                .Tag = tag,
                .ActivityValue = activityValue,
                .OptionalMessage = optionalMessage,
                .UserId = userId
            }

            backgroundWorker.RunWorkerAsync(activity)

        Catch ex As Exception

            Config.MsgErr(ex.Message)

        End Try

    End Sub

    Private Async Sub Save(ByVal activity As Sadara.Models.V2.POCO.ActivityEntity)

        Await Sadara.BusinessLayer.Activity.Instance.AddAsync(activity)

    End Sub

    Private Sub BackgroundWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker.DoWork

        Save(e.Argument)

        e.Result = True

    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted

    End Sub

End Class
