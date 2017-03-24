Public Class frmBuscarProveedor
    Public frm_return As Integer = 0
    Sub llenar(Optional ByVal nproveedor As String = "", Optional ByVal nombreproveedor As String = "", Optional ByVal RazonSocialP As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From pro In db.Proveedores Where pro.ACTIVO = "S" And pro.N_PROVEEDOR.Contains(nproveedor) And pro.NOMBRES.Contains(nombreproveedor) And pro.RAZONSOCIAL.Contains(RazonSocialP) Select pro.IDPROVEEDOR, pro.N_PROVEEDOR, PROVEEDOR = pro.NOMBRES & " " & pro.APELLIDOS, pro.RAZONSOCIAL, pro.TELEFONO, pro.DOMICILIO).ToList()
                If dtRegistro.Visible Then
                    dtRegistro.DataSource = consulta
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Visible = False
                        dtRegistro.Columns(1).Width = 150 : dtRegistro.Columns(1).HeaderText = vbNewLine & "N° PROVEEDOR" & vbNewLine
                        dtRegistro.Columns(2).Width = 300 : dtRegistro.Columns(2).HeaderText = "NOMBRES Y APELLIDOS"
                        dtRegistro.Columns(3).Width = 300 : dtRegistro.Columns(2).HeaderText = "RAZÓN SOCIAL"
                        dtRegistro.Columns(5).Width = 550
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                        Next
                    End If
                Else
                    Dim rpt As New rptInformeProveedor
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    If nombreproveedor <> "" Then
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = nombreproveedor
                    Else
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = "%Todos%"
                    End If
                    If nproveedor <> "" Then
                        band = rpt.Section2.ReportObjects("txtCodigo") : band.Text = nproveedor
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

    Private Sub frmBuscarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
        llenar()
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        CrystalReportViewer1.Visible = False
        llenar(txtNProveedor.Text.Trim(), txtNombre.Text.Trim(), txtRazonSocial.Text.Trim())
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtNProveedor.Clear()
        txtNombre.Clear()
        llenar()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        CrystalReportViewer1.Visible = True
        dtRegistro.Visible = False
        llenar(txtNProveedor.Text.Trim(), txtNombre.Text.Trim(), txtRazonSocial.Text.Trim())
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                Using db As New CodeFirst
                    Dim id = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
                    Dim p = db.Proveedores.Where(Function(f) f.ACTIVO = "S" And f.IDPROVEEDOR = id).FirstOrDefault()
                    If Not p Is Nothing Then
                        Select Case frm_return
                            Case 0
                                frmProveedor.txtCodigo.Text = p.IDPROVEEDOR
                                frmProveedor.txtCodProveedor.Text = p.N_PROVEEDOR
                                frmProveedor.txtNombres.Text = p.NOMBRES
                                frmProveedor.txtApellidos.Text = p.APELLIDOS
                                frmProveedor.txtTelefono.Text = p.TELEFONO
                                frmProveedor.txtDomicilio.Text = p.DOMICILIO
                                frmProveedor.txtPlazo.Value = p.PLAZO
                                frmProveedor.txtLimite.Text = p.LIMITECREDITO
                                frmProveedor.txtRazonSocial.Text = p.RAZONSOCIAL
                                If p.TIPOPERSONA = "Natural" Then
                                    frmProveedor.rdNatural.Checked = True
                                ElseIf p.TIPOPERSONA = "Jurídica" Then
                                    frmProveedor.rdJuridica.Checked = True
                                End If

                                frmProveedor.btGuardar.Enabled = False
                                frmProveedor.btEliminar.Enabled = True
                                frmProveedor.btEditar.Enabled = True

                                frmProveedor.txtCodProveedor.Focus()

                                'mostrar formulario luego de cargar datos
                                frmProveedor.MdiParent = frmPrincipal
                                frmProveedor.BringToFront()
                                frmProveedor.Show()
                            Case 1
                                frmProveedor.txtCodigo.Text = p.IDPROVEEDOR
                                frmProveedor.txtCodProveedor.Text = p.N_PROVEEDOR
                                frmProveedor.txtNombres.Text = p.NOMBRES
                                frmProveedor.txtApellidos.Text = p.APELLIDOS
                                frmProveedor.txtTelefono.Text = p.TELEFONO
                                frmProveedor.txtDomicilio.Text = p.DOMICILIO
                                frmProveedor.txtPlazo.Value = p.PLAZO
                                frmProveedor.txtLimite.Text = p.LIMITECREDITO
                                frmProveedor.txtRazonSocial.Text = p.RAZONSOCIAL
                                If p.TIPOPERSONA = "Natural" Then
                                    frmProveedor.rdNatural.Checked = True
                                ElseIf p.TIPOPERSONA = "Jurídica" Then
                                    frmProveedor.rdJuridica.Checked = True
                                End If
                                frmProveedor.btGuardar.Enabled = False
                                frmProveedor.btEliminar.Enabled = True
                                frmProveedor.btEditar.Enabled = True

                                frmProveedor.txtCodProveedor.Focus()
                            Case 2
                                frmCompra.txtIdProveedor.Text = p.IDPROVEEDOR
                                frmCompra.txtNombreProveedor.Text = p.N_PROVEEDOR & " | " & p.NOMBRES & " " & p.APELLIDOS & If(p.RAZONSOCIAL.Trim <> "", " // " & p.RAZONSOCIAL, "")
                            Case 3
                                frmReciboCompra.txtIdProveedor.Text = p.IDPROVEEDOR
                                frmReciboCompra.txtNombreProveedor.Text = p.N_PROVEEDOR & " | " & p.NOMBRES & " " & p.APELLIDOS & If(p.RAZONSOCIAL.Trim <> "", " // " & p.RAZONSOCIAL, "")
                            Case 4
                                frmCompraEstadoCuenta.txtIdProveedor.Text = p.IDPROVEEDOR
                                frmCompraEstadoCuenta.txtNombreProveedor.Text = p.N_PROVEEDOR & " | " & p.NOMBRES & " " & p.APELLIDOS
                                frmCompraEstadoCuenta.txtRazonSocial.Text = p.RAZONSOCIAL
                            Case 5
                                frmNotaDevolucionCompra.txtIdProveedor.Text = p.IDPROVEEDOR
                                frmNotaDevolucionCompra.txtNombreProveedor.Text = p.N_PROVEEDOR & " | " & p.NOMBRES & " " & p.APELLIDOS & If(p.RAZONSOCIAL.Trim <> "", " // " & p.RAZONSOCIAL, "")
                            Case 6
                                frmProducto.txtIdProveedor.Text = p.IDPROVEEDOR
                                frmProducto.txtProveedor.Text = p.N_PROVEEDOR & " | " & p.NOMBRES & " " & p.APELLIDOS & If(p.RAZONSOCIAL.Trim <> "", " // " & p.RAZONSOCIAL, "")
                        End Select
                        Me.Close()
                    Else
                        MessageBox.Show("Error, No se encuentra este 'Proveedor'. Probablemente alla sido eliminado")
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarProveedor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub txtNProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtNProveedor.TextChanged, txtNombre.TextChanged, txtRazonSocial.TextChanged
        llenar(txtNProveedor.Text.Trim(), txtNombre.Text.Trim(), txtRazonSocial.Text.Trim())
    End Sub
End Class