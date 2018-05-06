Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmBuscarClientes
    Public frm_return As Integer = 0

    Sub llenar(Optional ByVal nombre As String = "", Optional ByVal codigo As String = "", Optional ByVal RazonSocialP As String = "")

        Try

            Using db As New CodeFirst

                Dim consulta = (From cli In db.Clientes Where cli.ACTIVO = "S" And cli.N_CLIENTE.Contains(codigo) And (cli.NOMBRES & " " & cli.APELLIDOS).Contains(nombre) And cli.RAZONSOCIAL.Contains(RazonSocialP) Select cli.IDCLIENTE, cli.N_CLIENTE, cli.IDENTIFICACION, NOMBRES = cli.NOMBRES & " " & cli.APELLIDOS, cli.TELEFONO, cli.RAZONSOCIAL, cli.DOMICILIO).ToList()

                If dtRegistro.Visible Then

                    dtRegistro.DataSource = consulta

                    If dtRegistro.Columns.Count > 0 Then

                        dtRegistro.Columns(0).Visible = False
                        dtRegistro.Columns(1).Width = 150 : dtRegistro.Columns(1).HeaderText = vbNewLine & "N° CLIENTE" & vbNewLine
                        dtRegistro.Columns(2).Width = 150
                        dtRegistro.Columns(3).Width = 300 : dtRegistro.Columns(3).HeaderText = "NOMBRES Y APELLIDOS"
                        dtRegistro.Columns(4).Width = 100
                        dtRegistro.Columns(5).Width = 300 : dtRegistro.Columns(5).HeaderText = "RAZÓN SOCIAL"
                        dtRegistro.Columns(6).Width = 400 : dtRegistro.Columns(6).HeaderText = "DIRECCIÓN"

                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                        Next

                    End If

                Else

                    Dim rpt As New rptInformeCliente
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
                    rpt.SetDataSource(consulta)
                    CrystalReportViewer1.ReportSource = rpt
                    CrystalReportViewer1.Zoom(75)
                    rpt = Nothing : band = Nothing

                End If

            End Using

        Catch ex As Exception

            MessageBox.Show("Error, " & ex.Message)

        End Try
    End Sub

    Private Async Sub frmBuscarClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Await Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "CustomerSearch",
            "Load",
            "Load CustomerSearch",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        llenar()

    End Sub

    Private Sub frmBuscarClientes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim id = dtRegistro.SelectedRows(0).Cells(0).Value.ToString()
                    Dim c = db.Clientes.Where(Function(f) f.IDCLIENTE = id And f.ACTIVO = "S").FirstOrDefault
                    If Not c Is Nothing Then
                        Select Case frm_return
                            Case 0
                                frmCliente.txtCodigo.Text = c.IDCLIENTE
                                frmCliente.txtCodCliente.Text = c.N_CLIENTE
                                If c.TIPOPERSONA = "Natural" Then
                                    frmCliente.rdNatural.Checked = True
                                ElseIf c.TIPOPERSONA = "Jurídica" Then
                                    frmCliente.rdJuridica.Checked = True
                                End If
                                frmCliente.txtNombres.Text = c.NOMBRES
                                frmCliente.txtApellidos.Text = c.APELLIDOS
                                frmCliente.txtTelefono.Text = c.TELEFONO
                                frmCliente.txtDomicilio.Text = c.DOMICILIO
                                frmCliente.txtCedula.Text = c.IDENTIFICACION
                                frmCliente.txtLimite.Value = c.LIMITECREDITO
                                frmCliente.txtPlazo.Value = c.PLAZO
                                frmCliente.txtRazonSocial.Text = c.RAZONSOCIAL

                                frmCliente.btGuardar.Enabled = False
                                frmCliente.btEliminar.Enabled = True
                                frmCliente.btEditar.Enabled = True

                                frmCliente.txtCodCliente.Focus()

                                'mostrar formulario luego de cargar datos
                                frmCliente.MdiParent = frmPrincipal
                                frmCliente.BringToFront()
                                frmCliente.Show()
                            Case 1

                                frmVenta.rdContado.Checked = True
                                frmVenta.txtIdCliente.Text = c.IDCLIENTE
                                frmVenta.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)

                            Case 2

                                frmCotizacion.rdContado.Checked = True
                                frmCotizacion.txtIdCliente.Text = c.IDCLIENTE
                                frmCotizacion.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)

                            Case 3

                            Case 4
                                
                            Case 5

                            Case 6
                                If frmBuscarDesconsignacion.rdIdCliente.Checked Then
                                    frmBuscarDesconsignacion.txtIdCliente.Text = c.N_CLIENTE
                                ElseIf frmBuscarDesconsignacion.rdNombreCliente.Checked Then
                                    frmBuscarDesconsignacion.txtNombreCliente.Text = c.NOMBRES & " " & c.APELLIDOS
                                End If
                            Case 7
                                If frmBuscarConsignacion.rdIdCliente.Checked Then
                                    frmBuscarConsignacion.txtIdCliente.Text = c.N_CLIENTE
                                ElseIf frmBuscarConsignacion.rdNombreCliente.Checked Then
                                    frmBuscarConsignacion.txtNombreCliente.Text = c.NOMBRES & " " & c.APELLIDOS
                                End If
                            Case 8
                                frmConsignacion.txtIdCliente.Text = c.IDCLIENTE
                                frmConsignacion.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)
                            Case 9
                                frmDesconsignacion.txtIdCliente.Text = c.IDCLIENTE
                                frmDesconsignacion.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)
                            Case 10
                                frmNotaDevolucion.txtIdCliente.Text = c.IDCLIENTE
                                frmNotaDevolucion.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)
                            Case 11
                                frmEstadoCuenta.txtIdCliente.Text = c.IDCLIENTE
                                frmEstadoCuenta.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)
                                frmEstadoCuenta.txtRazonSocial.Text = c.RAZONSOCIAL
                            Case 12
                                frmInformeConsignacionProducto.txtIdCliente.Text = c.IDCLIENTE
                                frmInformeConsignacionProducto.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)
                                frmInformeConsignacionProducto.txtRazonSocial.Text = c.RAZONSOCIAL
                            Case 13
                                frmInformeVentaDetalle.txtNCliente.Text = c.N_CLIENTE
                            Case 14
                                'frmInformeFacturas.txtNCliente.Text = dtRegistro.SelectedRows(0).Cells(1).Value.ToString
                            Case 15
                                frmReciboVenta.txtIdCliente.Text = c.IDCLIENTE
                                frmReciboVenta.txtNombreCliente.Text = If(c.TIPOPERSONA = "Natural" Or c.RAZONSOCIAL.Trim() = "", c.N_CLIENTE & " " & c.NOMBRES & " " & c.APELLIDOS, c.N_CLIENTE & " " & c.RAZONSOCIAL)
                            Case 16
                                frmCliente.txtCodigo.Text = c.IDCLIENTE
                                frmCliente.txtCodCliente.Text = c.N_CLIENTE
                                If c.TIPOPERSONA = "Natural" Then
                                    frmCliente.rdNatural.Checked = True
                                ElseIf c.TIPOPERSONA = "Jurídica" Then
                                    frmCliente.rdJuridica.Checked = True
                                End If
                                frmCliente.txtNombres.Text = c.NOMBRES
                                frmCliente.txtApellidos.Text = c.APELLIDOS
                                frmCliente.txtTelefono.Text = c.TELEFONO
                                frmCliente.txtDomicilio.Text = c.DOMICILIO
                                frmCliente.txtCedula.Text = c.IDENTIFICACION
                                frmCliente.txtLimite.Value = c.LIMITECREDITO
                                frmCliente.txtPlazo.Value = c.PLAZO
                                frmCliente.txtRazonSocial.Text = c.RAZONSOCIAL

                                frmCliente.btGuardar.Enabled = False
                                frmCliente.btEliminar.Enabled = True
                                frmCliente.btEditar.Enabled = True

                                frmCliente.txtCodCliente.Focus()

                            Case 17 ' Formulario Productos Vendidos

                                frmProductosVendidos.txtNCliente.Text = c.N_CLIENTE

                        End Select

                        Me.Close()

                    Else
                        MessageBox.Show("No se encuentra este cliente. Probablemente ha sido eliminado.")
                    End If
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

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged, txtNombre.TextChanged, txtRazonSocial.TextChanged
        llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim, txtRazonSocial.Text)
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        CrystalReportViewer1.Visible = False
        llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim, txtRazonSocial.Text)
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtCodigo.Clear()
        txtNombre.Clear()
        llenar()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        CrystalReportViewer1.Visible = True
        dtRegistro.Visible = False
        llenar(txtNombre.Text.Trim, txtCodigo.Text.Trim, txtRazonSocial.Text)
    End Sub
End Class