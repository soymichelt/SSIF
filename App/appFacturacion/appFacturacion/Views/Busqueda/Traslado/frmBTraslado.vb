Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmBTraslado
    Public frm_return As Integer = 0
    Dim FormLoad As Boolean = False

    Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "")
        Try
            Using db As New CodeFirst
                dtRegistro.DataSource = (From tra In db.Traslados Join ser In db.Series On ser.IDSERIE Equals tra.IDSERIE Join bod In db.Bodegas On bod.IDBODEGA Equals ser.IDBODEGA Where ser.IDSERIE.Contains(pserie) And tra.FECHATRASLADO >= finicio And tra.FECHATRASLADO <= ffin Select ANULADO = If(tra.ANULADO.Equals("S"), "Anulado", ""), tra.IDTRASLADO, SERIE = ser.NOMBRE, tra.CONSECUTIVO, tra.FECHATRASLADO, N_EMPLEADO = If(tra.ANULADO.Equals(Config.vFalse), tra.Empleado.N_TRABAJADOR, ""), EMPLEADO = If(tra.ANULADO.Equals(Config.vFalse), tra.Empleado.NOMBRES & " " & tra.Empleado.APELLIDOS, ""), OBSERVACION = If(tra.ANULADO.Equals("N"), tra.CONCEPTO, ""), REFERENCIA = If(tra.ANULADO.Equals(Config.vFalse), tra.REFERENCIA, ""), TOTAL = If(tra.ANULADO.Equals("N"), tra.TOTAL, Nothing)).ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = ""
                    dtRegistro.Columns(1).Visible = False
                    dtRegistro.Columns(2).Width = 55
                    dtRegistro.Columns(3).Width = 150 : dtRegistro.Columns(3).HeaderText = "Nº TRASLADO"
                    dtRegistro.Columns(4).Width = 150 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(4).HeaderText = "FECHA"
                    dtRegistro.Columns(5).Width = 150 : dtRegistro.Columns(5).HeaderText = "N° EMPLEADO"
                    dtRegistro.Columns(6).Width = 250 : dtRegistro.Columns(6).HeaderText = "NOMBRE DEL EMPLEADO"
                    dtRegistro.Columns(7).Width = 500 : dtRegistro.Columns(7).HeaderText = "CONCEPTO DEL TRASLADO"
                    dtRegistro.Columns(8).Width = 150 : dtRegistro.Columns(8).HeaderText = "REFERENCIA"
                    dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(9).Width = 150 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m
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
                cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "TRASLADO").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
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
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "TRASLADO").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    'llenar series
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "TRASLADO").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
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
                    Dim idtraslado As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString() : Dim traslado = db.Traslados.Where(Function(f) f.IDTRASLADO = idtraslado).FirstOrDefault()
                    If Not traslado Is Nothing Then
                        If traslado.ANULADO = "N" Then
                            Select Case frm_return
                                Case 0
                                    frmTraslado.LoadInfo(vInt:=traslado, ByInt:=True)
                            End Select
                            Me.Close()
                        Else
                            MessageBox.Show("Traslado anulado")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra este Traslado o ha sido eliminada")
                    End If
                    idtraslado = Nothing : traslado = Nothing
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