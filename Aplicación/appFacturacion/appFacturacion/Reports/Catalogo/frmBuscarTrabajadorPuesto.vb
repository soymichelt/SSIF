Public Class frmBuscarTrabajadorPuesto
    Public frm_return As Integer = 0

    Sub llenar(Optional ByVal nombre As String = "", Optional ByVal descripcion As String = "")
        'Try
        '    Using db As New MODELODEDATOS
        '        If dtRegistro.Visible Then
        '            dtRegistro.DataSource = (From pue In db.TRABAJADORES_PUESTOS Where pue.ACTIVO = "S" And pue.NOMBRE_PUESTO.Contains(nombre) And pue.DESCRIPCION.Contains(descripcion) Select pue, CVI = If(pue.CONTADOR, "Contador, ", "") & If(pue.VENDEDOR, "Vendedor, ", "") & If(pue.INVENTARISTA, "Inventarista, ", ""), CMA = If(pue.CAJERO, "Cajero, ", "") & If(pue.MANTENIMIENTO, "Mantenimiento, ", "") & If(pue.ADMINISTRADOR_EMPRESA, "Administrador, ", ""), MRI = If(pue.MARKETING, "Marketing, ", "") & If(pue.RRHH, "Recursos Humanos, ", "") & If(pue.INFORMATICO, "Informático, ", ""), GAC = If(pue.GERENTE, "Gerencia, ", "") & If(pue.ASEO, "Aseo, ", "") & If(pue.CONSERJE, "Conserje", ""), SSA = If(pue.SECRETARIO, "Secretario, ", "") & If(pue.SOPORTE_TECNICO, "Soporte Técnico, ", "") & If(pue.ATENCION_CLIENTE, "Atención al Cliente, ", ""), D = If(pue.DISEÑADOR, "Diseñador de la Empresa", "") Select pue, V1 = CVI & CMA & MRI, V2 = GAC & SSA & D Select pue.IDPUESTO, pue.NOMBRE_PUESTO, DESCRIPCION_PUESTO = pue.DESCRIPCION, LABORES = V1 & V2, pue.OTRO).ToList()
        '            If dtRegistro.Columns.Count > 0 Then
        '                dtRegistro.Columns(0).Visible = False
        '                dtRegistro.Columns(1).Width = 150 : dtRegistro.Columns(1).HeaderText = "NOMBRE DEL PUESTO"
        '                dtRegistro.Columns(2).Width = 300 : dtRegistro.Columns(2).HeaderText = "DESCRIPCIÓN DEL PUESTO"
        '                dtRegistro.Columns(3).Width = 600 : dtRegistro.Columns(3).HeaderText = "LABORES"
        '                dtRegistro.Columns(4).Width = 300 : dtRegistro.Columns(4).HeaderText = "OTRAS LABORES"
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
        '                Dim idpuesto = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
        '                Dim puesto = db.TRABAJADORES_PUESTOS.Where(Function(f) f.ACTIVO = "S" And f.IDPUESTO = idpuesto).FirstOrDefault()

        '                If Not puesto Is Nothing Then
        '                    frmEmpleadoPuesto.txtCodigo.Text = puesto.IDPUESTO
        '                    frmEmpleadoPuesto.txtNombre.Text = puesto.NOMBRE_PUESTO
        '                    frmEmpleadoPuesto.txtDescripcion.Text = puesto.DESCRIPCION
        '                    frmEmpleadoPuesto.chkContador.Checked = puesto.CONTADOR
        '                    frmEmpleadoPuesto.chkVendedor.Checked = puesto.VENDEDOR
        '                    frmEmpleadoPuesto.chkInventarista.Checked = puesto.INVENTARISTA
        '                    frmEmpleadoPuesto.chkCajero.Checked = puesto.CAJERO
        '                    frmEmpleadoPuesto.chkMantenimiento.Checked = puesto.MANTENIMIENTO
        '                    frmEmpleadoPuesto.chkAdministrador.Checked = puesto.ADMINISTRADOR_EMPRESA
        '                    frmEmpleadoPuesto.chkMarketing.Checked = puesto.MARKETING
        '                    frmEmpleadoPuesto.chkRecursosHumanos.Checked = puesto.RRHH
        '                    frmEmpleadoPuesto.chkInformatico.Checked = puesto.INFORMATICO
        '                    frmEmpleadoPuesto.chkGerente.Checked = puesto.GERENTE
        '                    frmEmpleadoPuesto.chkAseo.Checked = puesto.ASEO
        '                    frmEmpleadoPuesto.chkConserje.Checked = puesto.CONSERJE
        '                    frmEmpleadoPuesto.chkSecretario.Checked = puesto.SECRETARIO
        '                    frmEmpleadoPuesto.chkSoporte.Checked = puesto.SOPORTE_TECNICO
        '                    frmEmpleadoPuesto.chkAtencion.Checked = puesto.ATENCION_CLIENTE
        '                    frmEmpleadoPuesto.chkDiseñador.Checked = puesto.DISEÑADOR
        '                    frmEmpleadoPuesto.txtOtros.Text = puesto.OTRO

        '                    frmEmpleadoPuesto.btGuardar.Enabled = False
        '                    frmEmpleadoPuesto.btEliminar.Enabled = True
        '                    frmEmpleadoPuesto.btEditar.Enabled = True

        '                    frmEmpleadoPuesto.txtNombre.Focus()

        '                    'mostrar formulario luego de cargar datos
        '                    frmEmpleadoPuesto.MdiParent = frmPrincipal
        '                    frmEmpleadoPuesto.BringToFront()
        '                    frmEmpleadoPuesto.Show()
        '                Else
        '                    MessageBox.Show("Error, No se encuentra este puesto. Probablemente alla sido eliminado")
        '                End If

        '                idpuesto = Nothing
        '                puesto = Nothing
        '            End Using
        '        Case 1
        '            Using db As New MODELODEDATOS
        '                Dim idpuesto = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
        '                Dim puesto = db.TRABAJADORES_PUESTOS.Where(Function(f) f.ACTIVO = "S" And f.IDPUESTO = idpuesto).FirstOrDefault()

        '                If Not puesto Is Nothing Then
        '                    frmEmpleadoPuesto.txtCodigo.Text = puesto.IDPUESTO
        '                    frmEmpleadoPuesto.txtNombre.Text = puesto.NOMBRE_PUESTO
        '                    frmEmpleadoPuesto.txtDescripcion.Text = puesto.DESCRIPCION
        '                    frmEmpleadoPuesto.chkContador.Checked = puesto.CONTADOR
        '                    frmEmpleadoPuesto.chkVendedor.Checked = puesto.VENDEDOR
        '                    frmEmpleadoPuesto.chkInventarista.Checked = puesto.INVENTARISTA
        '                    frmEmpleadoPuesto.chkCajero.Checked = puesto.CAJERO
        '                    frmEmpleadoPuesto.chkMantenimiento.Checked = puesto.MANTENIMIENTO
        '                    frmEmpleadoPuesto.chkAdministrador.Checked = puesto.ADMINISTRADOR_EMPRESA
        '                    frmEmpleadoPuesto.chkMarketing.Checked = puesto.MARKETING
        '                    frmEmpleadoPuesto.chkRecursosHumanos.Checked = puesto.RRHH
        '                    frmEmpleadoPuesto.chkInformatico.Checked = puesto.INFORMATICO
        '                    frmEmpleadoPuesto.chkGerente.Checked = puesto.GERENTE
        '                    frmEmpleadoPuesto.chkAseo.Checked = puesto.ASEO
        '                    frmEmpleadoPuesto.chkConserje.Checked = puesto.CONSERJE
        '                    frmEmpleadoPuesto.chkSecretario.Checked = puesto.SECRETARIO
        '                    frmEmpleadoPuesto.chkSoporte.Checked = puesto.SOPORTE_TECNICO
        '                    frmEmpleadoPuesto.chkAtencion.Checked = puesto.ATENCION_CLIENTE
        '                    frmEmpleadoPuesto.chkDiseñador.Checked = puesto.DISEÑADOR
        '                    frmEmpleadoPuesto.txtOtros.Text = puesto.OTRO

        '                    frmEmpleadoPuesto.btGuardar.Enabled = False
        '                    frmEmpleadoPuesto.btEliminar.Enabled = True
        '                    frmEmpleadoPuesto.btEditar.Enabled = True

        '                    frmEmpleadoPuesto.txtNombre.Focus()
        '                Else
        '                    MessageBox.Show("Error, No se encuentra este puesto. Probablemente alla sido eliminado")
        '                End If

        '                idpuesto = Nothing
        '                puesto = Nothing
        '            End Using
        '        Case 2
        '            frmEmpleado.txtIdPuesto.Text = dtRegistro.SelectedRows(0).Cells(0).Value.ToString()
        '            frmEmpleado.txtPuesto.Text = dtRegistro.SelectedRows(0).Cells(1).Value.ToString()
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