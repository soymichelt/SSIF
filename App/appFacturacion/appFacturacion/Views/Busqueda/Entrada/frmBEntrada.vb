Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmBEntrada
    Public frm_return As Integer = 0
    Dim FormLoad As Boolean = False
    Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "")
        Try
            Using db As New CodeFirst
                dtRegistro.DataSource = (From ent In db.Entradas Join ser In db.SERIES On ser.IDSERIE Equals ent.IDSERIE Join bod In db.Bodegas On bod.IDBODEGA Equals ser.IDBODEGA Where ser.IDSERIE.Contains(pserie) And ent.FECHAENTRADA >= finicio And ent.FECHAENTRADA <= ffin Select ANULADO = If(ent.ANULADO.Equals("S"), "Anulado", ""), ent.IDENTRADA, SERIE = ser.NOMBRE, ent.CONSECUTIVO, ent.FECHAENTRADA, N_EMPLEADO = If(ent.ANULADO.Equals(Config.vFalse), ent.EMPLEADO.N_TRABAJADOR, ""), EMPLEADO = If(ent.ANULADO.Equals(Config.vFalse), ent.EMPLEADO.NOMBRES & " " & ent.EMPLEADO.APELLIDOS, ""), OBSERVACION = If(ent.ANULADO.Equals("N"), ent.OBSERVACION, ""), TOTAL = If(ent.ANULADO.Equals("N"), ent.TOTAL, Nothing)).ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = vbNewLine & "" & vbNewLine
                    dtRegistro.Columns(1).Visible = False
                    dtRegistro.Columns(2).Width = 55
                    dtRegistro.Columns(3).Width = 150 : dtRegistro.Columns(3).HeaderText = "Nº ENTRADA"
                    dtRegistro.Columns(4).Width = 150 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(4).HeaderText = "FECHA"
                    dtRegistro.Columns(5).Width = 150 : dtRegistro.Columns(5).HeaderText = "N° EMPLEADO"
                    dtRegistro.Columns(6).Width = 250 : dtRegistro.Columns(6).HeaderText = "NOMBRE DEL EMPLEADO"
                    dtRegistro.Columns(7).Width = 300 : dtRegistro.Columns(7).HeaderText = "CONCEPTO DE LA ENTRADA"
                    dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(8).Width = 150 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                'llenar series
                cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "ENTRADA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                dtpFechaInicial.Value = DateTime.Now
                dtpFechaFinal.Value = DateTime.Now
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        Try
            Using db As New CodeFirst
                If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                    Dim serie As String = cmbSerie.Text
                    'llenar series
                    cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "ENTRADA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    'llenar series
                    cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "ENTRADA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
        Else
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        cmbSerie.SelectedIndex = -1
        dtpFechaInicial.Value = DateTime.Now
        dtpFechaFinal.Value = DateTime.Now
        llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim identrada As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString() : Dim entrada = db.Entradas.Where(Function(f) f.IDENTRADA = identrada).FirstOrDefault()
                    If Not entrada Is Nothing Then
                        If entrada.ANULADO = "N" Then
                            Select Case frm_return
                                Case 0
                                    frmEntrada.LoadInfo(vInt:=entrada, ByInt:=True)
                                    Me.Close()
                            End Select
                        Else
                            MessageBox.Show("Esta entrada esta anulada")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra esta entrada o ha sido eliminada")
                    End If
                    identrada = Nothing : entrada = Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", cmbSerie.SelectedValue.ToString())
            End If
        End If
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        If Me.FormLoad Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
            End If
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If Me.FormLoad Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
            End If
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub
End Class