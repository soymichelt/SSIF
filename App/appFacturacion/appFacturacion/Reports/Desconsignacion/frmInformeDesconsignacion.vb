Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmInformeDesconsignacion

    Sub llenar(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, Optional ByVal bodegap As String = "", Optional ByVal seriep As String = "")
        Try
            Using db As New CodeFirst
                If dtRegistro.Visible Then
                    dtRegistro.DataSource = (From des In db.Desconsignaciones Join ser In db.Series On ser.IDSERIE Equals des.IDSERIE Where des.FECHACONSIGNACION >= fecha1 And des.FECHACONSIGNACION <= fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) Order By des.N Select ANULADO = If(des.ANULADO.Equals("S"), "Anulado", ""), des.IDDESCONSIGNACION, SERIE = ser.NOMBRE, des.CONSECUTIVO, des.FECHACONSIGNACION, N_VENDEDOR = If(des.ANULADO.Equals("N"), des.Empleado.N_TRABAJADOR, ""), VENDEDOR = If(des.ANULADO.Equals("N"), des.Empleado.NOMBRES & " " & des.Empleado.APELLIDOS, ""), N_CLIENTE = If(des.ANULADO.Equals("N"), des.Cliente.N_CLIENTE, ""), CLIENTE = If(des.ANULADO.Equals("N"), des.Cliente.NOMBRES & " " & des.Cliente.APELLIDOS, ""), OBSERVACION = If(des.ANULADO.Equals("N"), des.OBSERVACION, "")).ToList
                    If dtRegistro.Rows.Count = 0 Then
                        dtDetalle.DataSource = Nothing
                    Else
                        txtTotal.Value = (From des In db.Desconsignaciones Join ser In db.Series On ser.IDSERIE Equals des.IDSERIE Where des.ANULADO = "N" And des.FECHACONSIGNACION >= fecha1 And des.FECHACONSIGNACION <= fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) Select des.TOTAL).Sum()
                    End If
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = ""
                        dtRegistro.Columns(1).Visible = False
                        dtRegistro.Columns(2).Width = 55
                        dtRegistro.Columns(3).Width = 160 : dtRegistro.Columns(3).HeaderText = "Nº DESCONSIGNACIÓN"
                        dtRegistro.Columns(4).Width = 100 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(4).HeaderText = "FECHA"
                        dtRegistro.Columns(5).Width = 120 : dtRegistro.Columns(5).HeaderText = "Nº VENDEDOR"
                        dtRegistro.Columns(6).Width = 200 : dtRegistro.Columns(6).HeaderText = "NOMBRES DEL VENDEDOR"
                        dtRegistro.Columns(7).Width = 120 : dtRegistro.Columns(7).HeaderText = "Nº CLIENTE"
                        dtRegistro.Columns(8).Width = 200 : dtRegistro.Columns(8).HeaderText = "NOMBRES DEL CLIENTE"
                        dtRegistro.Columns(9).Width = 300 : dtRegistro.Columns(9).HeaderText = "OBSERVACIÓN DE LA DESCONSIGNACIÓN"
                        'dtRegistro.Columns(10).DefaultCellStyle.Format = SESION.formato_moneda : dtRegistro.Columns(10).Width = 100
                    End If
                Else
                    Dim rpt As New rptInformeEntrada
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    band = rpt.Section2.ReportObjects("txtFecha1") : band.Text = fecha1.ToLongDateString()
                    band = rpt.Section2.ReportObjects("txtFecha2") : band.Text = fecha2.ToLongDateString()
                    If bodegap <> "" Then
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = bodegap
                    Else
                        band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = "%Todos%"
                    End If
                    If seriep <> "" Then
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = seriep
                    Else
                        band = rpt.Section2.ReportObjects("txtSerie") : band.Text = "%Todos%"
                    End If
                    rpt.SetDataSource((From ent In db.Entradas Join ser In db.Series On ser.IDSERIE Equals ent.IDSERIE Join det In db.EntradasDetalles On ent.IDENTRADA Equals det.IDENTRADA Join exi In db.Existencias On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join mar In db.Marcas On pro.IDMARCA Equals mar.IDMARCA Where ent.FECHAENTRADA >= fecha1 And ent.FECHAENTRADA <= fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) And ser.IDSERIE.Contains(seriep) Order By ent.N Select ent.IDENTRADA, SERIE = ser.NOMBRE, ent.CONSECUTIVO, ent.FECHAENTRADA, ent.OBSERVACION, ent.TOTAL, pro.IDALTERNO, pro.IDORIGINAL, pro.DESCRIPCION, MARCA = mar.DESCRIPCION, pro.IDUNIDAD, COSTO_UNITARIO = det.COSTO, det.CANTIDAD, SUBTOTAL = det.TOTAL).ToList)
                    CrystalReportViewer1.ReportSource = rpt
                    CrystalReportViewer1.Zoom(75)
                    rpt = Nothing : band = Nothing
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Sub llenarDetalle(ByVal id As String)
        Try
            Using db As New CodeFirst
                Dim desconsignacion = (From des In db.Desconsignaciones Join ser In db.Series On des.IDSERIE Equals ser.IDSERIE Where des.IDDESCONSIGNACION = id Select des.IDDESCONSIGNACION, SERIE = ser.NOMBRE, des.CONSECUTIVO, des.ANULADO).FirstOrDefault()
                If Not desconsignacion Is Nothing Then
                    If desconsignacion.ANULADO = "N" Then
                        ExpandablePanel1.TitleText = "Mostrar detalle de la desconsignación '" & desconsignacion.SERIE & " - " & desconsignacion.CONSECUTIVO & "'"
                        dtDetalle.DataSource = (From mar In db.Marcas Join pro In db.Productos On mar.IDMARCA Equals pro.IDMARCA Join exi In db.Existencias On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join det In db.DesconsignacionesDetalles On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Where det.IDDESCONSIGNACION = id Select pro.IDALTERNO, pro.IDORIGINAL, pro.DESCRIPCION, MARCA = If(pro.Marca.ACTIVO = "S", pro.Marca.DESCRIPCION, "SIN ESPECIFICAR"), UNIDAD_DE_MEDIDA = If(pro.UnidadMedida.ACTIVO = "S", pro.UnidadMedida.DESCRIPCION, "SIN ESPECIFICAR"), det.CANTIDAD).ToList
                        If dtDetalle.Columns.Count > 0 Then
                            dtDetalle.Columns(5).DefaultCellStyle.Format = Config.f_m
                        End If
                    Else
                        ExpandablePanel1.TitleText = "No se puede mostrar detalle de la desconsignación '" & desconsignacion.SERIE & " - " & desconsignacion.CONSECUTIVO & "' por que está anulada."
                        dtDetalle.DataSource = Nothing
                    End If
                Else
                    MessageBox.Show("No se encuentra esta Desconsignación")
                End If
                desconsignacion = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmInformeFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtTotal.DisplayFormat = Config.f_m
            dtpFechaInicial.Value = DateTime.Now
            dtpFechaFinal.Value = DateTime.Now
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.Bodegas Select bod.IDBODEGA, NOMBRE = bod.N_BODEGA & " - " & bod.DESCRIPCION).ToList() : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.DisplayMember = "NOMBRE" : cmbBodega.SelectedIndex = -1
                cmbSerie.DataSource = Nothing
            End Using

            llenar(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        ExpandablePanel1.Visible = True
        CrystalReportViewer1.Visible = False
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString())
            Else
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), )
            End If
        Else
            llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59")
        End If
    End Sub

    Sub llenarserie(ByVal bodega As String)
        Try
            Using db As New CodeFirst
                cmbSerie.DataSource = db.Series.Where(Function(f) f.ACTIVO = "S" And f.OPERACION = "ENTRADA" And f.IDBODEGA = bodega).ToList() : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            llenarserie(cmbBodega.SelectedValue.ToString())
            llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString())
            cmbSerie.Focus()
        Else
            llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59")
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
            llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString())
        End If
    End Sub


    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        dtpFechaInicial.Value = DateTime.Now
        dtpFechaFinal.Value = DateTime.Now
        cmbBodega.SelectedIndex = -1
        cmbSerie.SelectedIndex = -1
        llenar(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        'cargar
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString())
            Else
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), )
            End If
        Else
            llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59")
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        'cargar
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString())
            Else
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), )
            End If
        Else
            llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59")
        End If
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        ExpandablePanel1.Visible = False
        CrystalReportViewer1.Visible = True
        'cargar
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), cmbSerie.SelectedValue.ToString())
            Else
                llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59", cmbBodega.SelectedValue.ToString(), )
            End If
        Else
            llenar(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00", dtpFechaFinal.Value.ToShortDateString() & " 23:59:59")
        End If
    End Sub

    Private Sub dtRegistro_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtRegistro.CellFormatting
        Try
            If dtRegistro.Columns(e.ColumnIndex).Name = "ANULADO" Then
                If e.Value = "Anulado" Then
                    dtRegistro.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("error, " & ex.Message)
        End Try
    End Sub

    Private Sub dtRegistro_SelectionChanged(sender As Object, e As EventArgs) Handles dtRegistro.SelectionChanged
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                llenarDetalle(dtRegistro.SelectedRows(0).Cells(1).Value.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmInformeConsignacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class