Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Imports System.Data.SqlClient
Public Class frmProductosVendidos

    Dim FormLoad As Boolean = False

    Sub Lista(ByVal Fecha1 As DateTime, ByVal Fecha2 As DateTime, Optional ByVal IDBodega As String = "", Optional ByVal IDSerie As String = "", Optional ByVal NEmpleado As String = "", Optional ByVal Empleado As String = "", Optional ByVal NCliente As String = "", Optional ByVal Cliente As String = "")
        Try
            Using db As New CodeFirst

                Dim SpSQL = db.Database.SqlQuery(Of lstProductosVendidos)("SpProductosVendidos @Inicio, @Final, @IDBodega, @IDSerie, @NEmpleado, @Empleado, @NCliente, @Cliente, @TipoVenta, @MonInv, @Moneda, @Taza", New SqlParameter("@Inicio", Fecha1), New SqlParameter("@Final", Fecha2), New SqlParameter("@IDBodega", IDBodega), New SqlParameter("@IDSerie", IDSerie), New SqlParameter("@NEmpleado", NEmpleado), New SqlParameter("@Empleado", Empleado), New SqlParameter("@NCliente", NCliente), New SqlParameter("@Cliente", Cliente), New SqlParameter("@TipoVenta", If(rdContado.Checked, 1, If(rdCredito.Checked, 2, 0))), New SqlParameter("@MonInv", If(Config.currentBusiness.MonedaInventario.Equals(Config.cordoba), 1, 0)), New SqlParameter("@Moneda", If(rdMCordoba.Checked, 1, 0)), New SqlParameter("@Taza", Config.exchangeRate)).ToList()

                'Unificando información

                If Not SpSQL Is Nothing Then

                    With SpSQL

                        txtDescuento.Value = .Sum(Function(f) f.Descuento)
                        txtCostoTotal.Value = .Sum(Function(f) f.CostoTotal)
                        txtSubtotal.Value = .Sum(Function(f) f.SubTotal)
                        txtIva.Value = .Sum(Function(f) f.Iva)
                        txtTotal.Value = .Sum(Function(f) f.Total)
                        txtUtilidad.Value = .Sum(Function(f) f.Utilidad)

                    End With

                Else

                    txtDescuento.Value = 0.0
                    txtCostoTotal.Value = 0.0
                    txtSubtotal.Value = 0.0
                    txtIva.Value = 0.0
                    txtTotal.Value = 0.0
                    txtUtilidad.Value = 0.0

                End If

                If dtRegistro.Visible Then

                    dtRegistro.DataSource = (From c In SpSQL Select c.IDAlterno, c.Descripcion, c.Cantidad, c.CostoPromedio, c.CostoTotal, c.PrecioPromedio, c.Descuento, c.SubTotal, c.Utilidad, c.Iva, c.Total).ToList

                    If dtRegistro.Columns.Count > 0 Then

                        dtRegistro.Columns(0).HeaderText = vbNewLine & "ID ALTERNO" & vbNewLine : dtRegistro.Columns(0).Width = 145
                        dtRegistro.Columns(1).HeaderText = "DESCRIPCIÓN DEL PRODUCTO" : dtRegistro.Columns(1).Width = 250
                        dtRegistro.Columns(2).HeaderText = "CANTIDAD" : dtRegistro.Columns(2).Width = 145 : dtRegistro.Columns(2).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(3).HeaderText = "COSTO PROMEDIO" : dtRegistro.Columns(3).Width = 145 : dtRegistro.Columns(3).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(4).HeaderText = "COSTO TOTAL" : dtRegistro.Columns(4).Width = 145 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(5).HeaderText = "PRECIO PROMEDIO" : dtRegistro.Columns(5).Width = 145 : dtRegistro.Columns(5).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(6).HeaderText = "DESCUENTO" : dtRegistro.Columns(6).Width = 145 : dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(7).HeaderText = "SUB-TOTAL" : dtRegistro.Columns(7).Width = 145 : dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(8).HeaderText = "UTILIDAD" : dtRegistro.Columns(8).Width = 145 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(9).HeaderText = "IVA" : dtRegistro.Columns(9).Width = 145 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(10).HeaderText = "TOTAL NETO" : dtRegistro.Columns(10).Width = 145 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m

                        For Each c As DataGridViewColumn In dtRegistro.Columns

                            c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)

                        Next

                    End If

                Else

                    Dim rpt As New rptInformeVentaDetalle
                    Config.CrystalTitle("VENTA DETALLADA", rpt)
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    band = rpt.Section2.ReportObjects("txtFecha1") : band.Text = dtpFechaInicial.Value.ToLongDateString()
                    band = rpt.Section2.ReportObjects("txtFecha2") : band.Text = dtpFechaFinal.Value.ToLongDateString()

                    If IDBodega <> "" Then
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = cmbBodega.Text
                    Else
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = "%Todos%"
                    End If

                    If IDSerie <> "" Then
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = cmbSerie.Text
                    Else
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = "%Todos%"
                    End If

                    If NEmpleado <> "" Then
                        band = rpt.Section2.ReportObjects("txtVendedor") : band.Text = txtNombreVendedor.Text
                    Else
                        band = rpt.Section2.ReportObjects("txtVendedor") : band.Text = "%Todos%"
                    End If

                    If rdContado.Checked Then
                        band = rpt.Section2.ReportObjects("txtTipoFactura") : band.Text = "Contado"
                    ElseIf rdCredito.Checked Then
                        band = rpt.Section2.ReportObjects("txtTipoFactura") : band.Text = "Crédito"
                    Else
                        band = rpt.Section2.ReportObjects("txtTipoFactura") : band.Text = "%Todos%"
                    End If

                    If NCliente <> "" Then
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = NCliente
                    Else
                        band = rpt.Section2.ReportObjects("txtNCliente") : band.Text = "%Todos%"
                    End If

                    If NCliente <> "" Then
                        band = rpt.Section2.ReportObjects("txtNombreCliente") : band.Text = Cliente
                    Else
                        band = rpt.Section2.ReportObjects("txtNombreCliente") : band.Text = "%Todos%"
                    End If

                    rpt.SetDataSource(SpSQL.ToList)
                    CrystalReportViewer1.ReportSource = rpt
                    rpt = Nothing : band = Nothing

                End If

                SpSQL = Nothing ': sAgg = Nothing

            End Using

        Catch ex As Exception

            MessageBox.Show("Error, " & ex.Message)

        End Try

    End Sub

    Sub Filtrar()
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString(), txtNEmpleado.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
            Else
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), , txtNEmpleado.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        Else
            Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", , , txtNEmpleado.Text.Trim, txtNombreVendedor.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
        End If
    End Sub

    Private Async Sub frmInformeVentaDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Await Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "SaleProductReport",
            "Load",
            "Load SaleProductReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Try
            frmInformeVentaDetalle_Resize(Nothing, Nothing)
            txtDescuento.Value = 0.0
            txtCostoTotal.Value = 0.0
            txtSubtotal.Value = 0.0
            txtIva.Value = 0.0
            txtTotal.Value = 0.0
            txtUtilidad.Value = 0.0

            dtpFechaInicial.Value = DateTime.Now
            dtpFechaFinal.Value = DateTime.Now
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.Bodegas Select bod.IDBODEGA, NOMBRE = bod.N_BODEGA & " - " & bod.DESCRIPCION).ToList() : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.DisplayMember = "NOMBRE" : cmbBodega.SelectedIndex = -1
                cmbSerie.DataSource = Nothing
            End Using

            'Lista(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Sub llenarserie(ByVal bodega As String)

        Try
            Using db As New CodeFirst
                cmbSerie.DataSource = db.Series.Where(Function(f) f.ACTIVO = "S" And f.OPERACION = "VENTA" And f.IDBODEGA = bodega).ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try

    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                llenarserie(cmbBodega.SelectedValue.ToString())
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), , txtNEmpleado.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                cmbSerie.Focus()
            Else
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", , txtNEmpleado.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
            End If
        End If
    End Sub

    Private Sub cmbBodega_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                llenarserie(cmbBodega.SelectedValue.ToString())
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), , txtNEmpleado.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                cmbSerie.Focus()
            Else
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", , txtNEmpleado.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                If cmbBodega.Text.Trim = "" Then
                    txtNEmpleado.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString(), txtNEmpleado.Text.Trim, txtNCliente.Text.Trim, txtNombreCliente.Text.Trim)
                txtNEmpleado.Focus()
            End If
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        CrystalReportViewer1.Visible = False
        Me.Filtrar()
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        If Me.FormLoad Then
            'cargar
            Me.Filtrar()
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If Me.FormLoad Then
            'cargar
            Me.Filtrar()
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        dtpFechaInicial.Value = DateTime.Now
        dtpFechaFinal.Value = DateTime.Now
        cmbBodega.SelectedIndex = -1
        cmbSerie.SelectedIndex = -1
        txtNEmpleado.Clear()
        txtNEmpleado.Clear()
        txtNombreVendedor.Clear()
        txtNCliente.Clear()
        txtNombreCliente.Clear()
        Lista(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        CrystalReportViewer1.Visible = True
        'cargar
        Me.Filtrar()
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If Me.FormLoad Then
            If rdContado.Checked Then
                'cargar
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If Me.FormLoad Then
            If rdCredito.Checked Then
                'cargar
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        If Me.FormLoad Then
            If rdTodos.Checked Then
                'cargar
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub frmInformeVentaDetalle_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        gbMoneda.Left = (PanelEx4.Width / 2) - (gbMoneda.Width / 2) + 4
        gbTipoVenta.Left = PanelEx4.Width - gbTipoVenta.Width - 4
    End Sub

    Private Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        If tbFiltros.Visible Then
            TabControl1.SelectedTabIndex = 0
            tbFiltros.Visible = False
            tcpFiltros.Visible = False
            Me.FormLoad = False
            cmbBodega.SelectedIndex = -1
            cmbSerie.SelectedIndex = -1
            txtNCliente.Clear()
            txtNombreCliente.Clear()
            txtNEmpleado.Clear()
            txtNombreVendedor.Clear()
            Lista(dtpFechaInicial.Value.ToShortDateString & " 00:00:00", dtpFechaFinal.Value.ToShortDateString & " 23:59:59")
            Me.FormLoad = True
        Else
            tbFiltros.Visible = True
            tcpFiltros.Visible = True
            TabControl1.SelectedTabIndex = 1
            cmbBodega.Focus()
        End If
    End Sub

    Private Sub txtNCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNCliente.KeyDown, txtNombreVendedor.KeyDown, txtNombreCliente.KeyDown, txtNEmpleado.KeyDown
        If e.KeyData = Keys.Enter Then
            If dtRegistro.Visible Then
                Me.Filtrar()
            Else
                Me.Filtrar()
            End If
        End If
    End Sub

    Private Sub frmInformeVentaDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.B : btBuscar_Click(Nothing, Nothing)
                Case Keys.Delete : btLimpiar_Click(Nothing, Nothing)
                Case Keys.A : btBusqueda_Click(Nothing, Nothing)
                Case Keys.P : btImprimir_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub btBuscarCliente_Click(sender As Object, e As EventArgs) Handles btBuscarCliente.Click

        frmBuscarClientes.frm_return = 17
        frmBuscarClientes.ShowDialog()
        txtNCliente.Focus()

    End Sub

    Private Sub btBuscarEmpleado_Click(sender As Object, e As EventArgs) Handles btBuscarEmpleado.Click

        frmBuscarEmpleado.frm_return = 20
        frmBuscarEmpleado.ShowDialog()
        txtNEmpleado.Focus()

    End Sub

End Class