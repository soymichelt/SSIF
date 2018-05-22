Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmMarca
    Sub llenar(Optional ByVal bodega As String = "")
        Try
            Using db As New CodeFirst
                dtRegistro.DataSource = (From mar In db.Marcas Where mar.ACTIVO = "S" And mar.DESCRIPCION.Contains(bodega) Select mar.IDMARCA, mar.DESCRIPCION).ToList
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Visible = False
                    dtRegistro.Columns(1).HeaderText = vbNewLine & "DESCRIPCIÓN DE LA MARCA" & vbNewLine : dtRegistro.Columns(1).Width = 450
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                        c.HeaderText = c.HeaderText.ToUpper
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
    Sub limpiar()
        txtCodigo.Clear()
        txtNombre.Clear()
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
    End Sub
    Private Sub frmMarca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "Brand",
            "Load",
            "Load Brand",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
        Me.frmMarca_Resize(Nothing, Nothing)
        llenar()
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(13) Then
            llenar(txtBuscar.Text.Trim)
        End If
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If Not txtNombre.Text.Trim = "" Then
                Using db As New CodeFirst
                    If db.Marcas.Where(Function(f) f.DESCRIPCION = txtNombre.Text.Trim).Count() = 0 Then
                        Dim marca As New Marca : marca.Reg = DateTime.Now : marca.IDMARCA = Guid.NewGuid().ToString() : marca.DESCRIPCION = txtNombre.Text : marca.ACTIVO = "S"
                        db.Marcas.Add(marca)
                        db.SaveChanges() : limpiar() : llenar(txtBuscar.Text.Trim) : MessageBox.Show("Marca guardada")
                    Else
                        MessageBox.Show("Error, Ya existe una marca con este nombre.")
                    End If
                End Using
            Else
                MessageBox.Show("Error, Faltan datos.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        Try
            If Not txtCodigo.Text.Trim = "" And Not txtNombre.Text.Trim = "" Then
                Using db As New CodeFirst
                    If db.Marcas.Where(Function(f) f.DESCRIPCION = txtNombre.Text.Trim And Not f.IDMARCA = txtCodigo.Text).Count() = 0 Then
                        Dim marca = db.Marcas.Where(Function(f) f.IDMARCA = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not marca Is Nothing Then
                            marca.DESCRIPCION = txtNombre.Text
                            db.Entry(marca).State = EntityState.Modified
                            db.SaveChanges() : limpiar() : llenar(txtBuscar.Text.Trim) : MessageBox.Show("Marca editada")
                        Else
                            MessageBox.Show("Error, No se encuentra esta marca. Probablemente alla sido eliminada.")
                        End If
                    Else
                        MessageBox.Show("Error, Ya existe una marca con este nombre.")
                    End If
                End Using
            Else
                MessageBox.Show("Error, Faltan datos.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        Try
            Using db As New CodeFirst
                Dim marca = db.Marcas.Where(Function(f) f.IDMARCA = txtCodigo.Text).FirstOrDefault()
                If Not marca Is Nothing Then
                    marca.ACTIVO = "N"
                    db.Entry(marca).State = EntityState.Modified
                    db.SaveChanges()
                    limpiar()
                    llenar(txtBuscar.Text.Trim)
                    MessageBox.Show("Marca eliminada")
                Else
                    MessageBox.Show("Error, No se encuentra esta marca. Probablemente alla sido eliminada.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmMarca_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCodigo.Text.Trim() <> "" Then
                btEditar_Click(Nothing, Nothing)
            Else
                btGuardar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                txtCodigo.Text = dtRegistro.SelectedRows(0).Cells(0).Value.ToString()
                txtNombre.Text = dtRegistro.SelectedRows(0).Cells(1).Value.ToString()
                btGuardar.Enabled = False
                btEditar.Enabled = True
                btEliminar.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        llenar(txtBuscar.Text.Trim)
    End Sub


    Private Sub frmMarca_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblBuscar.Left = pnBuscar.Width - 205
        txtBuscar.Left = pnBuscar.Width - 151
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            dtRegistro_CellDoubleClick(Nothing, Nothing)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub frmMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    btNuevo_Click(Nothing, Nothing)
                Case Keys.G
                    If btGuardar.Enabled Then
                        btGuardar_Click(Nothing, Nothing)
                    End If
                Case Keys.E
                    If btEditar.Enabled Then
                        btEditar_Click(Nothing, Nothing)
                    End If
                Case Keys.Delete
                    If btEliminar.Enabled Then
                        btEliminar_Click(Nothing, Nothing)
                    End If
            End Select
        End If
    End Sub
End Class