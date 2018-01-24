Public Class frmBuscarTrabajadorArea
    Public frm_return As Integer = 0

    Sub llenar(Optional ByVal nombre As String = "", Optional ByVal descripcion As String = "")
        'Try
        '    Using db As New MODELODEDATOS
        '        If dtRegistro.Visible Then
        '            dtRegistro.DataSource = (From are In db.TRABAJADORES_AREAS Where are.ACTIVO = "S" And are.NOMBRE_AREA.Contains(nombre) And are.DESCRIPCION.Contains(descripcion) Select are.IDAREA, are.NOMBRE_AREA, DESCRIPCION_AREA = are.DESCRIPCION).ToList()
        '            If dtRegistro.Columns.Count > 0 Then
        '                dtRegistro.Columns(0).Visible = False
        '                dtRegistro.Columns(1).Width = 300 : dtRegistro.Columns(1).HeaderText = "NOMBRE DEL ÁREA"
        '                dtRegistro.Columns(2).Width = 800 : dtRegistro.Columns(2).HeaderText = "DESCRIPCIÓN DEL ÁREA"
        '            End If
        '        Else
        '            Dim rpt As New rptInformeCliente
        '            Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
        '            If nombre <> "" Then
        '                band = rpt.Section2.ReportObjects("txtNombre") : band.Text = nombre
        '            Else
        '                band = rpt.Section2.ReportObjects("txtNombre") : band.Text = "%Todos%"
        '            End If
        '            If descripcion <> "" Then
        '                band = rpt.Section2.ReportObjects("txtCodigo") : band.Text = descripcion
        '            Else
        '                band = rpt.Section2.ReportObjects("txtCodigo") : band.Text = "%Todos%"
        '            End If
        '            rpt.SetDataSource((From cli In db.CLIENTES Where cli.N_CLIENTE.Contains(descripcion) And (cli.NOMBRES & " " & cli.APELLIDOS).Contains(nombre) Select cli.N_CLIENTE, cli.IDENTIFICACION, cli.NOMBRES, cli.APELLIDOS, cli.RAZONSOCIAL, cli.TELEFONO, cli.DOMICILIO).ToList)
        '            CrystalReportViewer1.ReportSource = rpt
        '            CrystalReportViewer1.Zoom(75)
        '            rpt = Nothing : band = Nothing
        '        End If
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show("Error, " & ex.Message)
        'End Try
    End Sub

    Private Sub frmBuscarClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar()
    End Sub

    Private Sub frmBuscarClientes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        'If dtRegistro.SelectedRows.Count > 0 Then
        '    Select Case frm_return
        '        Case 0
        '            Using db As New MODELODEDATOS
        '                Dim idarea = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
        '                Dim area = db.TRABAJADORES_AREAS.Where(Function(f) f.ACTIVO = "S" And f.IDAREA = idarea).FirstOrDefault()

        '                If Not area Is Nothing Then
        '                    frmEmpleadoArea.txtCodigo.Text = area.IDAREA
        '                    frmEmpleadoArea.txtNombre.Text = area.NOMBRE_AREA
        '                    frmEmpleadoArea.txtDescripcion.Text = area.DESCRIPCION

        '                    frmEmpleadoArea.btGuardar.Enabled = False
        '                    frmEmpleadoArea.btEliminar.Enabled = True
        '                    frmEmpleadoArea.btEditar.Enabled = True

        '                    frmEmpleadoArea.txtNombre.Focus()

        '                    'mostrar formulario luego de cargar datos
        '                    frmEmpleadoArea.MdiParent = frmPrincipal
        '                    frmEmpleadoArea.BringToFront()
        '                    frmEmpleadoArea.Show()
        '                Else
        '                    MessageBox.Show("Error, No se encuentra esta Área. Probablemente alla sido eliminado")
        '                End If

        '                idarea = Nothing
        '                area = Nothing
        '            End Using
        '        Case 1
        '            Using db As New MODELODEDATOS
        '                Dim idarea = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
        '                Dim area = db.TRABAJADORES_AREAS.Where(Function(f) f.ACTIVO = "S" And f.IDAREA = idarea).FirstOrDefault()

        '                If Not area Is Nothing Then
        '                    frmEmpleadoArea.txtCodigo.Text = area.IDAREA
        '                    frmEmpleadoArea.txtNombre.Text = area.NOMBRE_AREA
        '                    frmEmpleadoArea.txtDescripcion.Text = area.DESCRIPCION

        '                    frmEmpleadoArea.btGuardar.Enabled = False
        '                    frmEmpleadoArea.btEliminar.Enabled = True
        '                    frmEmpleadoArea.btEditar.Enabled = True

        '                    frmEmpleadoArea.txtNombre.Focus()
        '                Else
        '                    MessageBox.Show("Error, No se encuentra este Área. Probablemente alla sido eliminado")
        '                End If

        '                idarea = Nothing
        '                area = Nothing
        '            End Using
        '        Case 2
        '            frmEmpleado.txtIdArea.Text = dtRegistro.SelectedRows(0).Cells(0).Value.ToString()
        '            frmEmpleado.txtArea.Text = dtRegistro.SelectedRows(0).Cells(1).Value.ToString()
        '    End Select
        '    Me.Close()
        'End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged, txtNombre.TextChanged
        llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        CrystalReportViewer1.Visible = False
        llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtCodigo.Clear()
        txtNombre.Clear()
        llenar()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        CrystalReportViewer1.Visible = True
        dtRegistro.Visible = False
        llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
    End Sub
End Class