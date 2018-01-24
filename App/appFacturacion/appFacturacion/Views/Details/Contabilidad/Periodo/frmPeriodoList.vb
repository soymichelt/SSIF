Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmPeriodoList
    Public FrmReturn As Integer = 0
    Public Sub PeriodoList()
        Try
            Using db As New CodeFirst
                Dim consulta = (From p In db.Periodos Where p.ACTIVO = "S" Select p.IDPERIODO, p.Reg, p.INICIO, p.FINAL, p.APERTURA, p.CIERRE)
                dtRegistro.DataSource = consulta.ToList
                If dtRegistro.Columns.Count > 0 Then
                    With dtRegistro
                        .Columns(0).Visible = False
                        .Columns(1).HeaderText = vbNewLine & "Registrado" & vbNewLine : .Columns(1).Width = 120
                        .Columns(2).HeaderText = "Inicio" : .Columns(2).Width = 120
                        .Columns(3).HeaderText = "Final" : .Columns(3).Width = 120
                        .Columns(4).HeaderText = "Apertura" : .Columns(4).Width = 120
                        .Columns(5).HeaderText = "Cierre" : .Columns(5).Width = 120

                        For Each c As DataGridViewColumn In .Columns
                            c.HeaderText = c.HeaderText.ToUpper
                            c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                        Next
                    End With
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmPeriodoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
        PeriodoList()
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim id = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
                    Dim p = db.Periodos.Where(Function(f) f.IDPERIODO = id).FirstOrDefault
                    If Not p Is Nothing Then
                        Select Case Me.FrmReturn
                            Case 0
                                Config._Periodo = p
                                frmPrincipal.txtInicio.Text = p.INICIO.ToShortDateString
                                frmPrincipal.txtFinal.Text = p.FINAL.ToShortDateString
                        End Select
                        id = Nothing : p = Nothing
                        Me.Close()
                    Else
                        MessageBox.Show("No se encuentra este 'Periodo'.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmPeriodoList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Me.Dispose()
    End Sub
End Class