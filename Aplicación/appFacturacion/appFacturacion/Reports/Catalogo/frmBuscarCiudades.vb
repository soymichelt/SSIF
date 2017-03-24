Public Class frmBuscarCiudades
    Public frm_return As Integer = 0

    Sub llenar(Optional ByVal nombre As String = "", Optional ByVal descripcion As String = "")
        'Try
        '    Using db As New MODELODEDATOS
        '        If dtRegistro.Visible Then
        '            dtRegistro.DataSource = (From pai In db.PAISES Join ciu In db.CIUDADES On pai.IDPAIS Equals ciu.IDPAIS Where pai.ACTIVO = "S" And ciu.N_CIUDAD.Contains(nombre) And ciu.NOMBRE.Contains(descripcion) Select ciu.IDCIUDAD, ciu.N_CIUDAD, NOMBRE_CIUDAD = ciu.NOMBRE, NOMBRE_PAIS = pai.N_PAIS & " - " & pai.NOMBRE).ToList()
        '            If dtRegistro.Columns.Count > 0 Then
        '                dtRegistro.Columns(0).Visible = False
        '                dtRegistro.Columns(1).Width = 150 : dtRegistro.Columns(1).HeaderText = "Nº CIUDADES"
        '                dtRegistro.Columns(2).Width = 400 : dtRegistro.Columns(2).HeaderText = "NOMBRE DE LA CIUDAD"
        '                dtRegistro.Columns(3).Width = 300 : dtRegistro.Columns(3).HeaderText = "PAÍS"
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
        '                Dim idciudad = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
        '                Dim ciudad = db.CIUDADES.Where(Function(f) f.IDCIUDAD = idciudad).FirstOrDefault()

        '                If Not ciudad Is Nothing Then
        '                    frmCiudad.txtCodigo.Text = ciudad.IDPAIS
        '                    frmCiudad.txtNCiudad.Text = ciudad.N_CIUDAD
        '                    frmCiudad.txtNombre.Text = ciudad.NOMBRE
        '                    frmCiudad.txtPais.Text = ciudad.PAIS.N_PAIS & " - " & ciudad.PAIS.NOMBRE

        '                    frmCiudad.btGuardar.Enabled = False
        '                    frmCiudad.btEliminar.Enabled = True
        '                    frmCiudad.btEditar.Enabled = True

        '                    frmCiudad.txtNCiudad.Focus()

        '                    'mostrar formulario luego de cargar datos
        '                    frmCiudad.MdiParent = frmPrincipal
        '                    frmCiudad.BringToFront()
        '                    frmCiudad.Show()
        '                Else
        '                    MessageBox.Show("Error, No se encuentra esta Ciudad. Probablemente alla sido eliminado")
        '                End If

        '                idciudad = Nothing
        '                ciudad = Nothing
        '            End Using
        '        Case 1
        '            Using db As New MODELODEDATOS
        '                Dim idciudad = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
        '                Dim ciudad = db.CIUDADES.Where(Function(f) f.IDCIUDAD = idciudad).FirstOrDefault()

        '                If Not ciudad Is Nothing Then
        '                    frmCiudad.txtCodigo.Text = ciudad.IDPAIS
        '                    frmCiudad.txtNCiudad.Text = ciudad.N_CIUDAD
        '                    frmCiudad.txtNombre.Text = ciudad.NOMBRE
        '                    frmCiudad.txtPais.Text = ciudad.PAIS.N_PAIS & " - " & ciudad.PAIS.NOMBRE

        '                    frmCiudad.btGuardar.Enabled = False
        '                    frmCiudad.btEliminar.Enabled = True
        '                    frmCiudad.btEditar.Enabled = True

        '                    frmCiudad.txtNCiudad.Focus()
        '                Else
        '                    MessageBox.Show("Error, No se encuentra esta Ciudad. Probablemente alla sido eliminado")
        '                End If

        '                idciudad = Nothing
        '                ciudad = Nothing
        '            End Using
        '        Case 2
        '            frmEmpleado.txtIdCiudad.Text = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
        '            frmEmpleado.txtCiudad.Text = dtRegistro.SelectedRows(0).Cells(1).Value.ToString & " - " & dtRegistro.SelectedRows(0).Cells(2).Value.ToString() & ", " & dtRegistro.SelectedRows(0).Cells(3).Value.ToString()
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