Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmMoneda

    Sub llenar()
        Try
            Using db As New CodeFirst
                Dim t = (From taz In db.Tazas Select taz.IDTAZA, taz.FECHA, taz.CAMBIO Order By FECHA).ToList()
                txtTazadecambio.Value = If(Not t.LastOrDefault Is Nothing, t.LastOrDefault.CAMBIO, 27.0)
                dtRegistro.DataSource = t
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Visible = False
                    dtRegistro.Columns(1).HeaderText = vbNewLine & "FECHA" & vbNewLine : dtRegistro.Columns(1).Width = 110
                    dtRegistro.Columns(2).HeaderText = "TAZA DE CAMBIO" : dtRegistro.Columns(2).Width = 110
                End If
                t = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmTazadecambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTazadecambio.DisplayFormat = Config.f_m
        llenar()
    End Sub

    Sub limpiar()
        txtCodigo.Clear()
        txtTazadecambio.Value = Nothing
        btGuardar.Enabled = True
        btEditar.Enabled = False
        btEliminar.Enabled = False
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If Not txtTazadecambio.Text.Trim() = "" Then
                If txtTazadecambio.Value > 0 Then
                    Using db As New CodeFirst
                        Dim taza As New Taza : taza.IDTAZA = Guid.NewGuid.ToString() : taza.FECHA = DateTime.Now : taza.CAMBIO = txtTazadecambio.Value : db.Tazas.Add(taza)
                        db.SaveChanges()
                        taza = Nothing
                    End Using
                    MessageBox.Show("Taza de Cambio Guardada")
                    limpiar()
                    llenar()
                Else
                    MessageBox.Show("Error, Ingrese un valor mayor a 0")
                End If
            Else
                MessageBox.Show("Error, Ingrese la taza de cambio.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmTazadecambio_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub txtTazadecambio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTazadecambio.KeyDown
        'If e.KeyData = Keys.Enter Then
        '    frmCalculadora.ShowDialog()
        '    txtTazadecambio.Text = frmCalculadora.retornar
        '    frmCalculadora.Dispose()
        'End If
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                Using db As New CodeFirst
                    Dim idtaza = dtRegistro.SelectedRows(0).Cells(0).Value.ToString()
                    Dim taza = db.Tazas.Where(Function(f) f.IDTAZA = idtaza).FirstOrDefault
                    If Not taza Is Nothing Then
                        txtCodigo.Text = taza.IDTAZA
                        txtTazadecambio.Value = taza.CAMBIO
                        'btGuardar.Enabled = False
                        'btEditar.Enabled = True
                        'btEliminar.Enabled = True

                        taza = Nothing
                    Else
                        MessageBox.Show("No se encuentra esta moneda. Probablemente ha sido eliminada.")
                    End If
                    idtaza = Nothing
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        Try
            If Not txtTazadecambio.Text.Trim() = "" Then
                If txtTazadecambio.Value > 0 Then
                    Using db As New CodeFirst
                        Dim moneda = db.Tazas.Where(Function(f) f.IDTAZA = txtCodigo.Text).FirstOrDefault
                        If Not moneda Is Nothing Then
                            moneda.CAMBIO = Decimal.Parse(txtTazadecambio.Text) : db.Entry(moneda).State = EntityState.Modified
                            db.SaveChanges()
                            moneda = Nothing
                            MessageBox.Show("Moneda Editada")
                            limpiar()
                            llenar()
                        Else
                            MessageBox.Show("No se encuentra esta moneda. Por lo que no puede ser editada.")
                        End If
                    End Using
                Else
                    MessageBox.Show("Error, Ingrese un valor mayor a 0")
                End If
            Else
                MessageBox.Show("Error, Ingrese todos los datos.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Try
            Using db As New CodeFirst
                Dim taza = db.Tazas.Where(Function(f) f.IDTAZA = txtCodigo.Text).FirstOrDefault
                If Not taza Is Nothing Then
                    db.SaveChanges()
                    taza = Nothing
                    MessageBox.Show("Moneda Eliminada")
                    limpiar()
                    llenar()
                Else
                    MessageBox.Show("No se encuentra esta moneda. Por lo que no puede ser editada.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub


    Private Sub txtTazadecambio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTazadecambio.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtTazadecambio.Text.Trim <> "" Then
                If btGuardar.Enabled Then
                    btGuardar_Click(Nothing, Nothing)
                Else
                    btEditar_Click(Nothing, Nothing)
                End If
            Else
                MessageBox.Show("Ingresar la taza de cambio de la moneda.")
            End If
        End If
    End Sub
End Class