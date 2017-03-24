Public Class frmBCompra
    Public frm_return As Integer = 0
    Dim FormLoad As Boolean = True

    Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From com In db.Compras Join ser In db.Series On ser.IDSERIE Equals com.IDSERIE Join bod In db.Bodegas On bod.IDBODEGA Equals ser.IDBODEGA Where ser.IDSERIE.Contains(pserie) And com.FECHACOMPRA >= finicio And com.FECHACOMPRA <= ffin Select ANULADO = If(com.ANULADO.Equals("S"), "Anulado", ""), com.IDCOMPRA, SERIE = ser.NOMBRE, com.CONSECUTIVO, com.N_COMPRA, com.FECHACOMPRA, FECHADEVOLUCION = If(com.ANULADO.Equals(Config.vFalse), com.FECHADEVOLUCION, Nothing), N_EMPLEADO = If(com.ANULADO.Equals(Config.vFalse), com.Empleado.N_TRABAJADOR, ""), EMPLEADO = If(com.ANULADO.Equals(Config.vFalse), com.Empleado.NOMBRES & " " & com.Empleado.APELLIDOS, ""), N_PROVEEDOR = If(com.ANULADO.Equals("N"), If(Not com.IDPROVEEDOR Is Nothing, com.Proveedor.N_PROVEEDOR, ""), ""), PROVEEDOR = If(com.ANULADO.Equals("N"), If(Not com.IDPROVEEDOR Is Nothing, com.Proveedor.NOMBRES & " " & com.Proveedor.APELLIDOS, com.PROVEEDORCONTADO), ""), CONDICIÓN = If(com.ANULADO.Equals("N"), If(com.CREDITO, "Crédito", "Contado"), ""), MONEDA = If(com.ANULADO.Equals("N"), If(com.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), ""), TAZACAMBIO = If(com.ANULADO.Equals(vFalse), com.TAZACAMBIO, Nothing), DESCUENTO = If(com.ANULADO.Equals("N"), If(com.MONEDA.Equals(Config.cordoba), com.DESCUENTO_DIN_C, com.DESCUENTO_DIN_D), Nothing), SUBTOTAL = If(com.ANULADO.Equals("N"), If(com.MONEDA.Equals(Config.cordoba), com.SUBTOTAL_C, com.SUBTOTAL_D), Nothing), IVA = If(com.ANULADO.Equals("N"), If(com.MONEDA.Equals(Config.cordoba), com.IVA_DIN_C, com.IVA_DIN_D), Nothing), TOTAL = If(com.ANULADO.Equals("N"), If(com.MONEDA.Equals(Config.cordoba), com.TOTAL_C, com.TOTAL_D), Nothing), com.CREDITO).ToList
                If rdContado.Checked Then
                    consulta = consulta.Where(Function(f) Not f.CREDITO And f.ANULADO.Equals("")).ToList
                ElseIf rdCredito.Checked Then
                    consulta = consulta.Where(Function(f) f.CREDITO And f.ANULADO.Equals("")).ToList
                End If
                dtRegistro.DataSource = consulta.ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = vbNewLine & "" & vbNewLine
                    dtRegistro.Columns(1).Visible = False
                    dtRegistro.Columns(2).Width = 55
                    dtRegistro.Columns(3).Width = 150 : dtRegistro.Columns(3).HeaderText = "Nº REQUISA"
                    dtRegistro.Columns(4).Width = 150 : dtRegistro.Columns(4).HeaderText = "Nº COMPRA"
                    dtRegistro.Columns(5).Width = 150 : dtRegistro.Columns(5).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(5).HeaderText = "FECHA"
                    dtRegistro.Columns(6).Width = 150 : dtRegistro.Columns(6).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(6).HeaderText = "F. DEVOLUCIÓN"
                    dtRegistro.Columns(7).Width = 150 : dtRegistro.Columns(7).HeaderText = "N° EMPLEADO"
                    dtRegistro.Columns(8).Width = 250 : dtRegistro.Columns(8).HeaderText = "NOMBRES Y APELLIDOS DEL EMPLEADO"
                    dtRegistro.Columns(9).Width = 120 : dtRegistro.Columns(9).HeaderText = "Nº PROVEEDOR"
                    dtRegistro.Columns(10).Width = 250 : dtRegistro.Columns(10).HeaderText = "NOMBRES Y APELLIDOS DEL PROVEEDOR"
                    dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).HeaderText = "CONDICIÓN"
                    dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).HeaderText = "MONEDA"
                    dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).HeaderText = "T / Z" : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(14).Width = 100 : dtRegistro.Columns(14).HeaderText = "DESCUENTO" : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(15).Width = 100 : dtRegistro.Columns(15).HeaderText = "SUB-TOTAL" : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(16).Width = 100 : dtRegistro.Columns(16).HeaderText = "IVA" : dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(17).Width = 100 : dtRegistro.Columns(17).HeaderText = "TOTAL" : dtRegistro.Columns(17).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(18).Visible = False
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
                cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "COMPRA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
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
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "COMPRA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    'llenar series
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "COMPRA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
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
                    Dim idcompra As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString()
                    Dim compra = db.Compras.Where(Function(f) f.IDCOMPRA = idcompra).FirstOrDefault()
                    If Not compra Is Nothing Then
                        If compra.ANULADO = "N" Then
                            Select Case frm_return
                                Case 0
                                    frmCompra.LoadInfo(vInt:=compra, ByInt:=True)
                            End Select
                            Me.Close()
                        Else
                            MessageBox.Show("Esta 'Compra' esta anulado")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra esta 'Compra' o ha sido eliminada")
                    End If
                    idcompra = Nothing : compra = Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
            llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", cmbSerie.SelectedValue.ToString())
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

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If Me.FormLoad Then
            If rdContado.Checked Then
                If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
                Else
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
                End If
            End If
        End If
    End Sub

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If Me.FormLoad Then
            If rdCredito.Checked Then
                If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
                Else
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
                End If
            End If
        End If
    End Sub

    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        If Me.FormLoad Then
            If rdTodos.Checked Then
                If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
                Else
                    llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
                End If
            End If
        End If
    End Sub

    Private Sub frmBCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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