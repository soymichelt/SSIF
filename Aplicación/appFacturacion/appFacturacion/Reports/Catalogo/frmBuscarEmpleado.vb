Public Class frmBuscarEmpleado
    Public frm_return As Integer = 0
    Public LaborPre As Integer = 0

    Sub llenar(Optional ByVal nombre As String = "", Optional ByVal codigo As String = "")
        Try
            Using db As New CodeFirst
                If dtRegistro.Visible Then
                    dtRegistro.DataSource = (From ven In db.Empleados Where ven.ACTIVO = "S" And ven.N_TRABAJADOR.Contains(codigo) And (ven.NOMBRES & " " & ven.APELLIDOS).Contains(nombre) Select ven.IDEMPLEADO, ven.N_TRABAJADOR, ven.IDENTIFICACION, NOMBRES = ven.NOMBRES & " " & ven.APELLIDOS, VENTA = If(ven.VENTA, "VENTA", ""), COMPRA = If(ven.COMPRA, "COMPRA", ""), INVENTARIO = If(ven.INVENTARIO, "INVENTARIO", ""), CONTABILIDAD = If(ven.CONTABILIDAD, "CONTABILIDAD", ""), ven.TELEFONO, ven.DOMICILIO).ToList()
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Visible = False
                        dtRegistro.Columns(1).Width = 150 : dtRegistro.Columns(1).HeaderText = vbNewLine & "N° EMPLEADO" & vbNewLine
                        dtRegistro.Columns(2).Width = 150
                        dtRegistro.Columns(3).Width = 300 : dtRegistro.Columns(3).HeaderText = "NOMBRES Y APELLIDOS"
                        dtRegistro.Columns(4).Width = 120 : dtRegistro.Columns(4).HeaderText = "VENTA"
                        dtRegistro.Columns(5).Width = 120 : dtRegistro.Columns(5).HeaderText = "COMPRA"
                        dtRegistro.Columns(6).Width = 120 : dtRegistro.Columns(6).HeaderText = "INVENTARIO"
                        dtRegistro.Columns(7).Width = 120 : dtRegistro.Columns(7).HeaderText = "CONTABILIDAD"
                        dtRegistro.Columns(8).Width = 100 : dtRegistro.Columns(8).HeaderText = "TELÉFONO"
                        dtRegistro.Columns(9).Width = 400 : dtRegistro.Columns(9).HeaderText = "DIRECCIÓN"
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                        Next
                    End If
                Else
                    Dim rpt As New rptInformeVendedor
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    If nombre <> "" Then
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = nombre
                    Else
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = "%Todos%"
                    End If
                    If codigo <> "" Then
                        band = rpt.Section2.ReportObjects("txtCodigo") : band.Text = codigo
                    Else
                        band = rpt.Section2.ReportObjects("txtCodigo") : band.Text = "%Todos%"
                    End If
                    rpt.SetDataSource((From tra In db.Empleados Where tra.N_TRABAJADOR.Contains(codigo) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(nombre) Select N_VENDEDOR = tra.N_TRABAJADOR, tra.IDENTIFICACION, tra.NOMBRES, tra.APELLIDOS, VENTA = If(tra.VENTA, "VENTA", ""), COMPRA = If(tra.COMPRA, "COMPRA", ""), INVENTARIO = If(tra.INVENTARIO, "INVENTARIO", ""), CONTABILIDAD = If(tra.CONTABILIDAD, "CONTABILIDAD", ""), tra.TELEFONO, tra.DOMICILIO, tra.OBSERVACION).ToList)
                    CrystalReportViewer1.ReportSource = rpt
                    CrystalReportViewer1.Zoom(75)
                    rpt = Nothing : band = Nothing
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
    Private Sub frmBuscarVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenar()
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(13) Then
            If Not txtNombre.Text.Trim = "" Or Not txtCodigo.Text.Trim = "" Then
                llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
            End If
        End If
    End Sub

    Private Sub frmBuscarVendedor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim id = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
                    Dim v = db.Empleados.Where(Function(f) f.ACTIVO = "S" And f.IDEMPLEADO = id).FirstOrDefault()
                    If Not v Is Nothing Then
                        Select Case frm_return
                            Case 0
                                frmEmpleado.txtCodigo.Text = v.IDEMPLEADO
                                frmEmpleado.txtCodTrabajador.Text = v.N_TRABAJADOR
                                frmEmpleado.txtNombres.Text = v.NOMBRES
                                frmEmpleado.txtApellidos.Text = v.APELLIDOS
                                frmEmpleado.txtTelefono.Text = v.TELEFONO
                                frmEmpleado.txtDomicilio.Text = v.DOMICILIO
                                frmEmpleado.txtObservacion.Text = v.OBSERVACION
                                frmEmpleado.txtCedula.Text = v.IDENTIFICACION
                                frmEmpleado.txtCorreo.Text = v.CORREO
                                If v.SEXO = "Masculino" Then
                                    frmEmpleado.rdMasculino.Checked = True
                                Else
                                    frmEmpleado.rdFemenino.Checked = True
                                End If
                                frmEmpleado.chkVentas.Checked = v.VENTA
                                frmEmpleado.chkCompras.Checked = v.COMPRA
                                frmEmpleado.chkInventario.Checked = v.INVENTARIO
                                frmEmpleado.chkContabilidad.Checked = v.CONTABILIDAD

                                frmEmpleado.btGuardar.Enabled = False
                                frmEmpleado.btEliminar.Enabled = True
                                frmEmpleado.btEditar.Enabled = True
                                frmEmpleado.txtCodTrabajador.Focus()

                                'mostrar formulario luego de cargar datos
                                frmEmpleado.MdiParent = frmPrincipal
                                frmEmpleado.BringToFront()
                                frmEmpleado.Show()
                            Case 1
                                If v.VENTA Then
                                    frmVenta.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmVenta.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 2
                                If v.VENTA Then
                                    frmCotizacion.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmCotizacion.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 3

                            Case 4
                                If v.VENTA Then
                                    If frmBuscarCotizacion.rdIdTrabajador.Checked Then
                                        frmBuscarCotizacion.txtIdTrabajador.Text = v.N_TRABAJADOR
                                    ElseIf frmBuscarCotizacion.rdNombreTrabajador.Checked Then
                                        frmBuscarCotizacion.txtNombreTrabajador.Text = v.NOMBRES & " " & v.APELLIDOS
                                    End If
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 5

                            Case 6
                                If v.VENTA Then
                                    If frmBuscarDesconsignacion.rdIdTrabajador.Checked Then
                                        frmBuscarDesconsignacion.txtIdTrabajador.Text = v.N_TRABAJADOR
                                    ElseIf frmBuscarDesconsignacion.rdNombreTrabajador.Checked Then
                                        frmBuscarDesconsignacion.txtNombreTrabajador.Text = v.NOMBRES & " " & v.APELLIDOS
                                    End If
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 7
                                If v.VENTA Then
                                    If frmBuscarConsignacion.rdIdTrabajador.Checked Then
                                        frmBuscarConsignacion.txtIdTrabajador.Text = v.N_TRABAJADOR
                                    ElseIf frmBuscarConsignacion.rdNombreTrabajador.Checked Then
                                        frmBuscarConsignacion.txtNombreTrabajador.Text = v.NOMBRES & " " & v.APELLIDOS
                                    End If
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 8
                                If v.VENTA Then
                                    frmConsignacion.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmConsignacion.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 9
                                If v.VENTA Then
                                    frmDesconsignacion.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmDesconsignacion.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 10
                                If v.VENTA Then
                                    frmInformeVentaDetalle.txtIdVendedor.Text = v.N_TRABAJADOR
                                    frmInformeVentaDetalle.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Venta'")
                                End If
                            Case 11
                                'frmInformeFacturas.txtIdVendedor.Text = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
                                'frmInformeFacturas.txtNombreVendedor.Text = dtRegistro.SelectedRows(0).Cells(1).Value.ToString & " | " & dtRegistro.SelectedRows(0).Cells(3).Value.ToString
                            Case 12
                                frmEmpleado.txtCodigo.Text = v.IDEMPLEADO
                                frmEmpleado.txtCodTrabajador.Text = v.N_TRABAJADOR
                                frmEmpleado.txtNombres.Text = v.NOMBRES
                                frmEmpleado.txtApellidos.Text = v.APELLIDOS
                                frmEmpleado.txtTelefono.Text = v.TELEFONO
                                frmEmpleado.txtDomicilio.Text = v.DOMICILIO
                                frmEmpleado.txtObservacion.Text = v.OBSERVACION
                                frmEmpleado.txtCedula.Text = v.IDENTIFICACION
                                frmEmpleado.txtCorreo.Text = v.CORREO
                                If v.SEXO = "Masculino" Then
                                    frmEmpleado.rdMasculino.Checked = True
                                Else
                                    frmEmpleado.rdFemenino.Checked = True
                                End If

                                frmEmpleado.chkVentas.Checked = v.VENTA
                                frmEmpleado.chkCompras.Checked = v.COMPRA
                                frmEmpleado.chkInventario.Checked = v.INVENTARIO
                                frmEmpleado.chkContabilidad.Checked = v.CONTABILIDAD

                                frmEmpleado.btGuardar.Enabled = False
                                frmEmpleado.btEliminar.Enabled = True
                                frmEmpleado.btEditar.Enabled = True

                                frmEmpleado.txtCodTrabajador.Focus()
                            Case 13
                                If v.COMPRA Then
                                    frmCompra.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmCompra.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Compra'.")
                                End If
                            Case 14
                                If v.COMPRA Then
                                    frmNotaDevolucionCompra.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmNotaDevolucionCompra.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Compra'.")
                                End If
                            Case 15
                                If v.CONTABILIDAD Then
                                    frmReciboVenta.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmReciboVenta.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Contabilidad'.")
                                End If
                            Case 16
                                If v.CONTABILIDAD Then
                                    frmReciboCompra.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmReciboCompra.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Contabilidad'.")
                                End If
                            Case 17
                                If v.INVENTARIO Then
                                    frmEntrada.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmEntrada.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Inventario'.")
                                End If
                            Case 18
                                If v.INVENTARIO Then
                                    frmSalida.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmSalida.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Inventario'.")
                                End If
                            Case 19
                                If v.INVENTARIO Then
                                    frmTraslado.txtIdVendedor.Text = v.IDEMPLEADO
                                    frmTraslado.txtNombreVendedor.Text = v.N_TRABAJADOR & " - " & v.NOMBRES & " " & v.APELLIDOS
                                Else
                                    MessageBox.Show("Seleccione un 'Empleado' con labor de 'Inventario'.")
                                End If
                        End Select
                        Me.Close()
                    Else
                        MessageBox.Show("Este 'Empleado' no se encuentra. Probablemente ha sido eliminado.")
                    End If
                    id = Nothing : v = Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
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

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
    End Sub

    Private Sub chkVentas_CheckedChanged(sender As Object, e As EventArgs) Handles chkVentas.CheckedChanged
        If chkVentas.Checked Then
            llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
        End If
    End Sub

    Private Sub chkCompras_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompras.CheckedChanged
        If chkCompras.Checked Then
            llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
        End If
    End Sub

    Private Sub chkInventario_CheckedChanged(sender As Object, e As EventArgs) Handles chkInventario.CheckedChanged
        If chkInventario.Checked Then
            llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
        End If
    End Sub

    Private Sub chkContabilidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkContabilidad.CheckedChanged
        If chkContabilidad.Checked Then
            llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim)
        End If
    End Sub
End Class