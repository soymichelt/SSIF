Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmSeleccionarSerie
    Public operacion As String
    Public serie As Serie
    Sub llenar(Optional ByVal descripcion As String = "")
        Try
            Using db As New CodeFirst
                dtRegistro.DataSource = (From ser In db.Series Where ser.IDBODEGA = Config.bodega And ser.OPERACION = Me.operacion And ser.DESCRIPCION.Contains(descripcion) Select ser.IDSERIE, ser.NOMBRE, SERIE = ser.DESCRIPCION, BODEGA = ser.Bodega.N_BODEGA & " | " & ser.DESCRIPCION, ser.OPERACION).ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Visible = False
                    dtRegistro.Columns(1).Width = 120 : dtRegistro.Columns(1).HeaderText = vbNewLine & "SERIE" & vbNewLine
                    dtRegistro.Columns(2).Width = 250 : dtRegistro.Columns(2).HeaderText = "REFERENCIA"
                    dtRegistro.Columns(3).Width = 200 : dtRegistro.Columns(3).HeaderText = "BODEGA"
                    dtRegistro.Columns(4).Width = 120 : dtRegistro.Columns(4).HeaderText = "OPERACIÓN"
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                    Next
                End If
                If dtRegistro.Rows.Count > 0 Then
                    dtRegistro.Rows(0).Selected = True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmSeleccionarBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not serie Is Nothing Then
            serie = Nothing
        End If
        llenar()
    End Sub

    Private Sub txtN_Bodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(txtDescripcion.Text.Trim())
        End If
    End Sub

    Private Sub frmSeleccionarBodega_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Me.Dispose()
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                If Not serie Is Nothing Then
                    serie = Nothing
                End If
                Using db As New CodeFirst
                    Dim idserie = dtRegistro.SelectedRows(0).Cells(0).Value.ToString() : serie = db.Series.Where(Function(f) f.IDSERIE = idserie And f.ACTIVO = "S").FirstOrDefault() : idserie = Nothing
                    If Not serie Is Nothing Then
                        Me.Close()
                    Else
                        MessageBox.Show("No se encuentra esta serie. Probablemente ha sido eliminada.")
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub
End Class