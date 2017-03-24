Public Class frmBDevolucionVenta
    Public frm_return As Integer = 0
    Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From dev In db.VentasDevoluciones Join ser In db.Series On ser.IDSERIE Equals dev.IDSERIE Join bod In db.Bodegas On bod.IDBODEGA Equals ser.IDBODEGA Join tra In db.Empleados On dev.IDEMPLEADO Equals tra.IDEMPLEADO Where ser.IDSERIE.Contains(pserie) And dev.FECHADEVOLUCION >= finicio And dev.FECHADEVOLUCION <= ffin Select ANULADO = If(dev.ANULADO.Equals("S"), "Anulado", ""), dev.IDDEVOLUCION, SERIE = ser.NOMBRE, dev.CONSECUTIVO, dev.FECHADEVOLUCION, N_VENDEDOR = If(dev.ANULADO.Equals("N"), tra.N_TRABAJADOR, ""), VENDEDOR = If(dev.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), N_CLIENTE = If(dev.ANULADO.Equals("N"), If(Not dev.IDCLIENTE Is Nothing, dev.Cliente.N_CLIENTE, ""), ""), CLIENTE = If(dev.ANULADO.Equals("N"), If(Not dev.IDCLIENTE Is Nothing, dev.Cliente.NOMBRES & " " & dev.Cliente.APELLIDOS, dev.CLIENTECONTADO), ""), CONDICIÓN = If(dev.ANULADO.Equals("N"), If(dev.CREDITO, "Crédito", "Contado"), ""), MONEDA = If(dev.ANULADO.Equals("N"), If(dev.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), ""), TAZACAMBIO = If(dev.ANULADO.Equals(Config.vFalse), dev.TAZACAMBIO, Nothing), DESCUENTO = If(dev.ANULADO.Equals("N"), If(dev.MONEDA.Equals(Config.cordoba), dev.DESCUENTO_DIN_C, dev.DESCUENTO_DIN_D), Nothing), SUBTOTAL = If(dev.ANULADO.Equals("N"), If(dev.MONEDA.Equals(Config.cordoba), dev.SUBTOTAL_C, dev.SUBTOTAL_D), Nothing), IVA = If(dev.ANULADO.Equals("N"), If(dev.MONEDA.Equals(Config.cordoba), dev.IVA_DIN_C, dev.IVA_DIN_D), Nothing), TOTAL = If(dev.ANULADO.Equals("N"), If(dev.MONEDA.Equals(Config.cordoba), dev.TOTAL_C, dev.TOTAL_D), Nothing), dev.CREDITO).ToList
                dtRegistro.DataSource = consulta.ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = ""
                    dtRegistro.Columns(1).Visible = False
                    dtRegistro.Columns(2).Width = 55
                    dtRegistro.Columns(3).Width = 150 : dtRegistro.Columns(3).HeaderText = "Nº DEVOLUCIÓN"
                    dtRegistro.Columns(4).Width = 150 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(4).HeaderText = "FECHA"
                    dtRegistro.Columns(5).Width = 120 : dtRegistro.Columns(5).HeaderText = "Nº VENDEDOR"
                    dtRegistro.Columns(6).Width = 250 : dtRegistro.Columns(6).HeaderText = "NOMBRES Y APELLIDOS DEL VENDEDOR"
                    dtRegistro.Columns(7).Width = 120 : dtRegistro.Columns(7).HeaderText = "Nº CLIENTE"
                    dtRegistro.Columns(8).Width = 250 : dtRegistro.Columns(8).HeaderText = "NOMBRES Y APELLIDOS DEL CLIENTE"
                    dtRegistro.Columns(9).Width = 100 : dtRegistro.Columns(9).HeaderText = "CONDICIÓN"
                    dtRegistro.Columns(10).Width = 100 : dtRegistro.Columns(10).HeaderText = "MONEDA"
                    dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).HeaderText = "T / Z" : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).HeaderText = "DESCUENTO" : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).HeaderText = "SUB-TOTAL" : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(14).Width = 100 : dtRegistro.Columns(14).HeaderText = "IVA" : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(15).Width = 100 : dtRegistro.Columns(15).HeaderText = "TOTAL" : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(16).Visible = False
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
                cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                dtpFechaInicial.Value = DateTime.Now
                dtpFechaFinal.Value = DateTime.Now
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        Try
            Using db As New CodeFirst
                If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                    Dim serie As String = cmbSerie.Text
                    'llenar series
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    'llenar series
                    cmbSerie.DataSource = db.Series.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
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
                    Dim iddevolucion As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString() : Dim devolucion = db.VentasDevoluciones.Where(Function(f) f.IDDEVOLUCION = iddevolucion).FirstOrDefault()
                    If Not devolucion Is Nothing Then
                        If devolucion.ANULADO = "N" Then
                            Select Case frm_return
                                Case 0
                                    frmNotaDevolucion.LoadInfo(vInt:=devolucion, ByInt:=True)
                            End Select
                            Me.Close()
                        Else
                            MessageBox.Show("Esta 'Devolución de Venta' esta anulado")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra esta 'Devolución de Venta' o ha sido eliminada")
                    End If
                    iddevolucion = Nothing : devolucion = Nothing
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
        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
        Else
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString())
        Else
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
        End If
    End Sub

    Private Sub frmBDevolucionVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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