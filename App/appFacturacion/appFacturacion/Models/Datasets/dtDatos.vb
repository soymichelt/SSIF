

Partial Public Class dtDatos
    Partial Class InformeReciboListDataTable

        Private Sub InformeReciboListDataTable_InformeReciboListRowChanging(sender As Object, e As InformeReciboListRowChangeEvent) Handles Me.InformeReciboListRowChanging

        End Sub

    End Class

    Partial Class IMPRIMIRCOMPRADataTable

        Private Sub IMPRIMIRCOMPRADataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.FECHADEVOLUCIONColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
