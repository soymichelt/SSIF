Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmBReciboCompra
    Public frm_return As Integer = 0
    Dim FormLoad As Boolean = False

    Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From rec In db.ComprasRecibos Join ser In db.Series On ser.IDSERIE Equals rec.IDSERIE Join bod In db.Bodegas On bod.IDBODEGA Equals ser.IDBODEGA Where ser.IDSERIE.Contains(pserie) And rec.FECHARECIBO >= finicio And rec.FECHARECIBO <= ffin Select ANULADO = If(rec.ANULADO.Equals("S"), "Anulado", ""), rec.IDRECIBO, SERIE = ser.NOMBRE, rec.CONSECUTIVO, rec.N_DOCUMENTO, rec.FECHARECIBO, N_EMPLEADO = If(rec.ANULADO.Equals(Config.vFalse), rec.Empleado.N_TRABAJADOR, ""), EMPLEADO = If(rec.ANULADO.Equals(Config.vFalse), rec.Empleado.NOMBRES & " " & rec.Empleado.APELLIDOS, ""), N_PROVEEDOR = If(rec.ANULADO.Equals("N"), If(Not rec.IDPROVEEDOR Is Nothing, rec.Proveedor.N_PROVEEDOR, ""), ""), PROVEEDOR = If(rec.ANULADO.Equals("N"), rec.Proveedor.NOMBRES & " " & rec.Proveedor.APELLIDOS, ""), CONCEPTO = If(rec.ANULADO.Equals("N"), rec.CONCEPTO, ""), MONEDA = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), ""), TAZACAMBIO = If(rec.ANULADO.Equals(vFalse), rec.TAZACAMBIO, Nothing), ImporteTotal = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.IMPORTETOTAL_C, rec.IMPORTETOTAL_D), Nothing), Descuento = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.DESCUENTOTOTAL_C, rec.DESCUENTOTOTAL_D), Nothing), Sobrante = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.SOBRANTEDECAJA_C, rec.SOBRANTEDECAJA_D), Nothing), MontoTotal = If(rec.ANULADO.Equals("N"), If(rec.MONEDA.Equals(Config.cordoba), rec.MONTOTOTAL_C, rec.MONTOTOTAL_D), Nothing)).ToList
                dtRegistro.DataSource = consulta.ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = vbNewLine & "" & vbNewLine
                    dtRegistro.Columns(1).Visible = False
                    dtRegistro.Columns(2).Width = 55
                    dtRegistro.Columns(3).Width = 150 : dtRegistro.Columns(3).HeaderText = "Nº DOCUMENTO"
                    dtRegistro.Columns(4).Width = 150 : dtRegistro.Columns(4).HeaderText = "Nº RECIBO"
                    dtRegistro.Columns(5).Width = 150 : dtRegistro.Columns(5).DefaultCellStyle.Format = Config.dateFormat : dtRegistro.Columns(5).HeaderText = "FECHA"
                    dtRegistro.Columns(6).Width = 150 : dtRegistro.Columns(6).HeaderText = "N° EMPLEADO"
                    dtRegistro.Columns(7).Width = 250 : dtRegistro.Columns(7).HeaderText = "NOMBRES Y APELLIDOS DEL EMPLEADO"
                    dtRegistro.Columns(8).Width = 120 : dtRegistro.Columns(8).HeaderText = "Nº PROVEEDOR"
                    dtRegistro.Columns(9).Width = 250 : dtRegistro.Columns(9).HeaderText = "NOMBRES Y APELLIDOS DEL PROVEEDOR"
                    dtRegistro.Columns(10).Width = 350 : dtRegistro.Columns(10).HeaderText = "CONCEPTO"
                    dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).HeaderText = "MONEDA"
                    dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).HeaderText = "T / Z" : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).HeaderText = "T. IMPORTE" : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(14).Width = 100 : dtRegistro.Columns(14).HeaderText = "T. DESCUENTO" : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(15).Width = 100 : dtRegistro.Columns(15).HeaderText = "T. SOBRANTE" : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(16).Width = 100 : dtRegistro.Columns(16).HeaderText = "T. MONTO" : dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m
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
                cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.warehouseId And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
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
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.warehouseId And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    'llenar series
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.warehouseId And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
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
                    Dim idrecibo As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString()
                    Dim v = db.ComprasRecibos.Where(Function(f) f.IDRECIBO = idrecibo).FirstOrDefault()
                    If Not v Is Nothing Then
                        If v.ANULADO = "N" Then
                            Select Case frm_return
                                Case 0
                                    frmReciboCompra.LoadInfo(vInt:=v, ByInt:=True)
                            End Select
                            Me.Close()
                        Else
                            MessageBox.Show("Recibo de Compra anulado")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra este Recibo de Compra o ha sido eliminada")
                    End If
                    idrecibo = Nothing : v = Nothing
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

    Private Sub frmBReciboCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.B
                    btBuscar_Click(Nothing, Nothing)
                Case Keys.Delete
                    btLimpiar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub
End Class