Public Class Log

    Private Shared _instance As Log

    Private Shared Function InstanceIsInitialized() As Boolean

        Return If(_instance IsNot Nothing, True, False)

    End Function

    Private Shared Sub InstanceInitialize()

        _instance = New Log()

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

    Public Async Function RegisterActivity(ByVal businessId As Guid, ByVal type As String, ByVal tag As String, ByVal activityValue As String, Optional ByVal optionalMessage As String = Nothing, Optional ByVal userId As Guid = Nothing) As Threading.Tasks.Task(Of Sadara.Models.V2.POCO.ActivityEntity)

        Try

            Return Await Sadara.BusinessLayer.Activity.Instance.AddAsync(New Sadara.Models.V2.POCO.ActivityEntity() With {
                .BusinessId = businessId,
                .Type = type,
                .Tag = tag,
                .ActivityValue = activityValue,
                .OptionalMessage = optionalMessage,
                .UserId = userId
            })

        Catch ex As Exception

            Config.MsgErr(" - michel - " & userId.ToString() & activityValue & ex.ToString())

        End Try

        Return Nothing

    End Function

End Class
