Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmValuacion

    Public frm_return As Integer = 0
    Dim FormLoad As Boolean = False
    Sub Lista(ByVal IDBod As String, Optional ByVal nombre As String = "", Optional ByVal codigo_original As String = "", Optional ByVal aplicacion As String = "", Optional ByVal codigo_alterno As String = "", Optional ByVal marcas As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From prod In db.Productos Join exi In db.Existencias On prod.IDPRODUCTO Equals exi.IDPRODUCTO Join mar In db.Marcas On prod.IDMARCA Equals mar.IDMARCA Where prod.ACTIVO = "S" And exi.Bodega.ACTIVO = "S" And exi.IDBODEGA = IDBod And prod.DESCRIPCION.Contains(nombre) And prod.IDORIGINAL.Contains(codigo_original) And prod.APLICACION.Contains(aplicacion) And prod.IDALTERNO.Contains(codigo_alterno) And mar.DESCRIPCION.Contains(marcas) Order By prod.IDALTERNO Select exi.IDBODEGA, mar.IDMARCA, BODEGA = exi.Bodega.N_BODEGA & " " & exi.Bodega.DESCRIPCION, prod.IDPRODUCTO, prod.IDALTERNO, prod.IDORIGINAL, PRODUCTO = prod.DESCRIPCION, MARCA = mar.DESCRIPCION, APLIC = prod.APLICACION, exi.CANTIDAD, prod.COSTO, TOTAL = exi.CANTIDAD * prod.COSTO).ToList
                If Not cmbExistencia.SelectedItem Is Nothing Then
                    Select Case cmbExistencia.SelectedItem.ToString()
                        Case "MAYORES A CERO"
                            consulta = consulta.Where(Function(f) f.CANTIDAD > 0).ToList
                        Case "IGUALES A CERO"
                            consulta = consulta.Where(Function(f) f.CANTIDAD = 0).ToList
                        Case "MENORES A CERO"
                            consulta = consulta.Where(Function(f) f.CANTIDAD < 0).ToList
                    End Select
                End If

                If dtRegistro.Visible Then
                    dtRegistro.DataSource = consulta
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Visible = False
                        dtRegistro.Columns(1).Visible = False
                        dtRegistro.Columns(2).Visible = False
                        dtRegistro.Columns(3).Visible = False
                        dtRegistro.Columns(4).HeaderText = vbNewLine & "ID ALTERNO" & vbNewLine : dtRegistro.Columns(4).Width = 120
                        dtRegistro.Columns(5).HeaderText = "ID ORIGINAL" : dtRegistro.Columns(5).Width = 120
                        dtRegistro.Columns(6).HeaderText = "DESCRIPCIÓN DEL PRODUCTO" : dtRegistro.Columns(6).Width = 220
                        dtRegistro.Columns(7).HeaderText = "MARCA" : dtRegistro.Columns(7).Width = 150
                        dtRegistro.Columns(8).HeaderText = "APLICACIÓN" : dtRegistro.Columns(8).Width = 150
                        dtRegistro.Columns(9).HeaderText = "EXISTENCIA" : dtRegistro.Columns(9).Width = 100 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(10).HeaderText = "COSTO" : dtRegistro.Columns(10).Width = 100 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m
                        dtRegistro.Columns(11).HeaderText = "TOTAL" : dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.HeaderText = c.HeaderText.ToUpper
                            c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                        Next
                    End If
                    consulta = Nothing
                Else
                    Dim rpt As New rptValuacion
                    Config.CrystalTitle("VALUACIÓN DE INVENTARIO", rpt)
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    If codigo_alterno <> "" Then
                        band = rpt.Section2.ReportObjects("txtAlterno") : band.Text = codigo_alterno
                    Else
                        band = rpt.Section2.ReportObjects("txtAlterno") : band.Text = "%Todos%"
                    End If
                    If codigo_original <> "" Then
                        band = rpt.Section2.ReportObjects("txtOriginal") : band.Text = codigo_original
                    Else
                        band = rpt.Section2.ReportObjects("txtOriginal") : band.Text = "%Todos%"
                    End If
                    If nombre <> "" Then
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = nombre
                    Else
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = "%Todos%"
                    End If
                    If aplicacion <> "" Then
                        band = rpt.Section2.ReportObjects("txtAplicacion") : band.Text = aplicacion
                    Else
                        band = rpt.Section2.ReportObjects("txtAplicacion") : band.Text = "%Todos%"
                    End If
                    If marcas <> "" Then
                        band = rpt.Section2.ReportObjects("txtmarca") : band.Text = aplicacion
                    Else
                        band = rpt.Section2.ReportObjects("txtmarca") : band.Text = "%Todos%"
                    End If

                    If Not cmbExistencia.SelectedItem Is Nothing Then
                        Select Case cmbExistencia.SelectedItem.ToString()
                            Case "MAYORES A CERO"
                                band = rpt.Section2.ReportObjects("txtExistencia") : band.Text = "MAYORES A CERO"
                            Case "IGUALES A CERO"
                                band = rpt.Section2.ReportObjects("txtExistencia") : band.Text = "IGUALES A CERO"
                            Case "MENORES A CERO"
                                band = rpt.Section2.ReportObjects("txtExistencia") : band.Text = "MENORES A CERO"
                            Case Else
                                band = rpt.Section2.ReportObjects("txtExistencia") : band.Text = "%Todos%"
                        End Select
                    End If
                    rpt.SetDataSource(consulta.ToList())
                    CrystalReportViewer1.ReportSource = rpt

                    rpt = Nothing : consulta = Nothing
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Sub ListarExistencia(ByVal IDProducto As String)
        Try
            Using db As New CodeFirst
                dtExistencia.DataSource = (From exi In db.Existencias Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where exi.IDPRODUCTO = IDProducto And exi.CANTIDAD <> 0 Select bod.N_BODEGA, BODEGA = bod.DESCRIPCION, EXISTENCIA = exi.CANTIDAD, exi.Producto.COSTO, TOTAL = exi.CANTIDAD * exi.Producto.COSTO).ToList
                If dtExistencia.Columns.Count > 0 Then
                    dtExistencia.Columns(0).HeaderText = vbNewLine & "No. Bodega" & vbNewLine : dtExistencia.Columns(0).Width = 150
                    dtExistencia.Columns(1).HeaderText = "Descripción de la Bodega" : dtExistencia.Columns(1).Width = 350
                    dtExistencia.Columns(2).HeaderText = "Existencia" : dtExistencia.Columns(2).DefaultCellStyle.Format = Config.f_m : dtExistencia.Columns(2).Width = 100
                    dtExistencia.Columns(3).HeaderText = "Costo" : dtExistencia.Columns(3).DefaultCellStyle.Format = Config.f_m : dtExistencia.Columns(3).Width = 100
                    dtExistencia.Columns(4).HeaderText = "Total" : dtExistencia.Columns(4).DefaultCellStyle.Format = Config.f_m : dtExistencia.Columns(4).Width = 100
                    For Each c As DataGridViewColumn In dtExistencia.Columns
                        c.HeaderText = c.HeaderText.ToUpper
                        c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbExistencia.SelectedIndex = 0
        Try
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.Bodegas Where bod.ACTIVO = "S" Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.DisplayMember = "DESCRIPCION"
                cmbBodega.Text = Config._Bodega.N_BODEGA & " | " & Config._Bodega.DESCRIPCION
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
        Me.FormLoad = True
    End Sub

    Private Sub txtIdAlterno_TextChanged(sender As Object, e As EventArgs) Handles txtIdAlterno.TextChanged, txtNombre.TextChanged, txtIdOriginal.TextChanged, txtAplicacion.TextChanged, txtmarca.TextChanged
        If dtRegistro.Visible Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                Lista(cmbBodega.SelectedValue.ToString(), txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
            Else
                Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
            End If
        End If
    End Sub

    Private Sub frmBuscarProducto_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

    End Sub

    Private Sub dtRegistro_SelectionChanged(sender As Object, e As EventArgs) Handles dtRegistro.SelectionChanged
        If Me.FormLoad Then
            Try
                If dtRegistro.SelectedRows.Count > 0 Then
                    ListarExistencia(dtRegistro.SelectedRows(0).Cells(0).Value.ToString)
                End If
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        dtRegistro_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub frmBuscarProducto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dtRegistro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtRegistro.KeyPress
        If e.KeyChar = ChrW(13) Then
            dtRegistro_SelectionChanged(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                Lista(cmbBodega.SelectedValue.ToString(), txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
            Else
                Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
            End If
        End If
    End Sub

    Private Sub cmbExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExistencia.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                Lista(cmbBodega.SelectedValue.ToString(), txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
            Else
                Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
            End If
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        ExpandablePanel1.Visible = True
        CrystalReportViewer1.Visible = False
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            Lista(cmbBodega.SelectedValue.ToString(), txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
        Else
            Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        cmbBodega.SelectedIndex = -1
        cmbExistencia.SelectedIndex = -1
        txtIdAlterno.Clear()
        txtIdOriginal.Clear()
        txtNombre.Clear()
        txtAplicacion.Clear()
        Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        ExpandablePanel1.Visible = False
        CrystalReportViewer1.Visible = True
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            Lista(cmbBodega.SelectedValue.ToString(), txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
        Else
            Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
        End If
    End Sub

    Private Sub txtIdAlterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress, txtIdOriginal.KeyPress, txtIdAlterno.KeyPress, txtAplicacion.KeyPress, txtmarca.KeyPress
        If e.KeyChar = ChrW(13) Then
            If CrystalReportViewer1.Visible Then
                If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                    Lista(cmbBodega.SelectedValue.ToString(), txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
                Else
                    Lista(Config.bodega, txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtmarca.Text.Trim)
                End If
            End If
        End If
    End Sub
End Class