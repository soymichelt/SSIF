Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmBuscarUsuario
    Public frm_return As Integer = 0

    Sub llenar(Optional ByVal nombre_ As String = "", Optional ByVal nombreusuario As String = "")
        Try
            Using db As New CodeFirst
                If dtRegistro.Visible Then
                    dtRegistro.DataSource = (From user In db.Usuarios Where (user.Nombres & " " & user.Apellidos).Contains(nombre_) And user.NombreCuenta.Contains(nombreusuario) Select user.IDUsuario, ACTIVO = If(user.Activo.Equals("S"), "Activo", "Desactivado"), NOMBRE = user.Nombres & " " & user.Apellidos, USUARIO = user.NombreCuenta, user.Observacion).ToList
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Visible = False
                        dtRegistro.Columns(1).HeaderText = vbNewLine & "" & vbNewLine
                        dtRegistro.Columns(2).Width = 400
                        dtRegistro.Columns(3).Width = 200
                        dtRegistro.Columns(4).Width = 600
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                        Next
                    End If
                Else
                    Dim rpt As New rptInformeUsuarios
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    If nombre_ <> "" Then
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = nombre_
                    Else
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = "%Todos%"
                    End If
                    If nombreusuario <> "" Then
                        band = rpt.Section2.ReportObjects("txtUsuario") : band.Text = nombreusuario
                    Else
                        band = rpt.Section2.ReportObjects("txtUsuario") : band.Text = "%Todos%"
                    End If
                    rpt.SetDataSource((From user In db.Usuarios Where user.Activo = "S" And (user.Nombres & " " & user.Apellidos).Contains(nombre_) And user.NombreCuenta.Contains(nombreusuario) Select user.IDUsuario, NOMBRE = user.Nombres & " " & user.Apellidos, USUARIO = user.NombreCuenta, user.Observacion).ToList)
                    CrystalReportViewer1.ReportSource = rpt
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "UserSearch",
            "Load",
            "Load UserSearch",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        llenar()
    End Sub

    Private Sub frmBuscarUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtNombre.Clear()
        txtUsuario.Clear()
        llenar()
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        CrystalReportViewer1.Visible = False
        llenar()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(txtNombre.Text.Trim(), txtUsuario.Text.Trim())
        End If
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(txtNombre.Text.Trim(), txtUsuario.Text.Trim())
        End If
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        CrystalReportViewer1.Visible = True
        'cargar
        llenar(txtNombre.Text.Trim(), txtUsuario.Text.Trim())
    End Sub

    Private Sub dtRegistro_SelectionChanged(sender As Object, e As EventArgs) Handles dtRegistro.SelectionChanged

    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Select Case frm_return
                Case 0
                    Using db As New CodeFirst
                        Dim idusuario = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
                        Dim u = db.Usuarios.Where(Function(f) f.IDUsuario = idusuario).FirstOrDefault()

                        If Not u Is Nothing Then
                            frmUser.txtCodigo.Text = u.IDUsuario
                            frmUser.txtNombres.Text = u.Nombres
                            frmUser.txtApellidos.Text = u.Apellidos
                            frmUser.txtUsuario.Text = u.NombreCuenta
                            frmUser.txtObservacion.Text = u.Observacion
                            If Not u.ImageName Is Nothing Then
                                If Not u.ImageName.Trim() = "" Then
                                    If System.IO.File.Exists(u.ImageName) Then
                                        frmUser.cargarImagen(Config.DirectoryPathImageUsers & u.ImageName & Config.ImageExtension)
                                    End If
                                End If
                            End If
                            frmUser.chkAdministrador.Checked = u.Administrador
                            frmUser.chkConsultasAdministrador.Checked = u.CAdministrador
                            frmUser.chkVenta.Checked = u.Venta
                            frmUser.chkConsultasVenta.Checked = u.CVenta
                            frmUser.chkCompra.Checked = u.Compra
                            frmUser.chkConsultasCompra.Checked = u.CCompra
                            frmUser.chkInventario.Checked = u.Inventario
                            frmUser.chkConsultasInventario.Checked = u.CInventario
                            frmUser.chkContabilidad.Checked = u.Contabilidad
                            frmUser.chkConsultasContabilidad.Checked = u.CContabilidad
                            frmUser.chkPromocion.Checked = u.Promocion
                            frmUser.chkConsultasPromocion.Checked = u.CPromocion
                            frmUser.chkSalesPriceChange.Checked = u.SalesPriceChange

                            frmUser.btGuardar.Enabled = False
                            frmUser.btEliminar.Enabled = True
                            frmUser.btEditar.Enabled = True

                            'mostrar formulario luego de cargar datos
                            frmUser.MdiParent = frmPrincipal
                            frmUser.BringToFront()
                            frmUser.Show()
                        Else
                            MessageBox.Show("Error, No se encuentra este Usuario. Probablemente alla sido eliminado")
                        End If

                        idusuario = Nothing
                        u = Nothing
                    End Using
                Case 1
                    Using db As New CodeFirst
                        Dim idusuario = dtRegistro.SelectedRows(0).Cells(0).Value.ToString
                        Dim u = db.Usuarios.Where(Function(f) f.IDUsuario = idusuario).FirstOrDefault()

                        If Not u Is Nothing Then
                            frmUser.txtCodigo.Text = u.IDUsuario
                            frmUser.txtNombres.Text = u.Nombres
                            frmUser.txtApellidos.Text = u.Apellidos
                            frmUser.txtUsuario.Text = u.NombreCuenta
                            frmUser.txtObservacion.Text = u.Observacion
                            If Not u.ImageName Is Nothing Then
                                If Not u.ImageName.Trim() = "" Then
                                    If System.IO.File.Exists(u.ImageName) Then
                                        frmUser.cargarImagen(Config.DirectoryPathImageUsers & u.ImageName & Config.ImageExtension)
                                    End If
                                End If
                            End If
                            frmUser.chkAdministrador.Checked = u.Administrador
                            frmUser.chkConsultasAdministrador.Checked = u.CAdministrador
                            frmUser.chkVenta.Checked = u.Venta
                            frmUser.chkConsultasVenta.Checked = u.CVenta
                            frmUser.chkCompra.Checked = u.Compra
                            frmUser.chkConsultasCompra.Checked = u.CCompra
                            frmUser.chkInventario.Checked = u.Inventario
                            frmUser.chkConsultasInventario.Checked = u.CInventario
                            frmUser.chkContabilidad.Checked = u.Contabilidad
                            frmUser.chkConsultasContabilidad.Checked = u.CContabilidad
                            frmUser.chkPromocion.Checked = u.Promocion
                            frmUser.chkConsultasPromocion.Checked = u.CPromocion
                            frmUser.chkSalesPriceChange.Checked = u.SalesPriceChange

                            frmUser.btGuardar.Enabled = False
                            frmUser.btEliminar.Enabled = True
                            frmUser.btEditar.Enabled = True
                        Else
                            MessageBox.Show("Error, No se encuentra este Usuario. Probablemente alla sido eliminado")
                        End If

                        idusuario = Nothing
                        u = Nothing
                    End Using
            End Select
            Me.Close()
        End If
    End Sub

    Private Sub dtRegistro_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtRegistro.CellFormatting
        Try
            If dtRegistro.Columns(e.ColumnIndex).Name = "ACTIVO" Then
                If e.Value = "Desactivado" Then
                    dtRegistro.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged, txtNombre.TextChanged
        If dtRegistro.Visible Then
            llenar(txtNombre.Text.Trim, txtUsuario.Text.Trim)
        End If
    End Sub
End Class