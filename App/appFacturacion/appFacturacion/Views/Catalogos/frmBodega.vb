Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Imports System.Data.SqlClient

Public Class frmBodega

    Sub llenar(Optional ByVal bodega As String = "")
        Try
            Using db As New CodeFirst
                dtRegistro.DataSource = (From b In db.Bodegas Where b.ACTIVO.Equals(Config.vTrue) And b.DESCRIPCION.Contains(bodega) Select b.IDBODEGA, b.N_BODEGA, b.DESCRIPCION Order By N_BODEGA).ToList
                If dtRegistro.Columns.Count > 0 Then
                    With dtRegistro
                        .Columns(0).Visible = False
                        .Columns(1).HeaderText = vbNewLine & "N° Bodega" & vbNewLine : .Columns(1).Width = 180
                        .Columns(2).HeaderText = "Descripción de la Bodega" : .Columns(2).Width = 800
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                            c.HeaderText = c.HeaderText.ToUpper
                        Next
                    End With
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Sub limpiar()
        txtCodigo.Clear()
        txtCodBodega.Clear()
        txtNombre.Clear()
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtCodBodega.Focus()
    End Sub

    Private Sub frmBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "Warehouse",
            "Load",
            "Load Warehouse",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Me.frmBodega_Resize(Nothing, Nothing)

        llenar()

        dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)

    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(txtBuscar.Text.Trim)
        End If
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click

        limpiar()

    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If Not txtCodBodega.Text.Trim = "" And Not txtNombre.Text.Trim = "" Then
                Using db As New CodeFirst
                    If db.Bodegas.Where(Function(f) f.N_BODEGA = txtCodBodega.Text.Trim).Count() = 0 Then

                        Dim bodega As New Bodega : bodega.Reg = DateTime.Now : bodega.IDBODEGA = Guid.NewGuid.ToString() : bodega.N_BODEGA = txtCodBodega.Text : bodega.DESCRIPCION = txtNombre.Text : bodega.ACTIVO = "S"

                        'agregar bodega
                        db.Bodegas.Add(bodega)

                        'guardar cambios
                        db.SaveChanges()

                        'Crear existencias
                        Try
                            db.Database.ExecuteSqlCommand("Exec SpCrearExistenciaPorProducto @IDBodega", New SqlParameter("@IDBodega", bodega.IDBODEGA))
                        Catch ex As Exception
                            Config.MsgAdv("No se han podido crear las existencias. Para poder manipular los productos es necesario crear las existencias. Detalles del error: " & ex.Message)
                        End Try

                        bodega = Nothing

                        limpiar()

                        llenar(txtBuscar.Text.Trim)

                        MessageBox.Show("Bodega guardada")

                    Else
                        MessageBox.Show("Error, Ya existe una bodega con este código.")
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
            If Not txtCodigo.Text.Trim = "" And Not txtCodBodega.Text.Trim = "" And Not txtNombre.Text.Trim = "" Then
                Using db As New CodeFirst
                    If db.Bodegas.Where(Function(f) Not f.IDBODEGA = txtCodigo.Text And f.N_BODEGA = txtCodBodega.Text).Count() = 0 Then
                        Dim bodega = db.Bodegas.Where(Function(f) f.IDBODEGA = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not bodega Is Nothing Then
                            bodega.N_BODEGA = txtCodBodega.Text : bodega.DESCRIPCION = txtNombre.Text
                            db.Entry(bodega).State = EntityState.Modified
                            db.SaveChanges() : limpiar() : llenar(txtBuscar.Text.Trim) : MessageBox.Show("Bodega editada")
                        Else
                            MessageBox.Show("Error, No se encuentra esta bodega. Probablemente ha sido eliminada.")
                        End If
                    Else
                        MessageBox.Show("Error, Ya existe una bodega con este código.")
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
        If MessageBox.Show("¿Desea eliminar esta bodega?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
            Try
                Using db As New CodeFirst
                    Dim bodega = db.Bodegas.Where(Function(f) f.IDBODEGA = txtCodigo.Text).FirstOrDefault()
                    If Not bodega Is Nothing Then
                        bodega.ACTIVO = "N"
                        db.Entry(bodega).State = EntityState.Modified
                        db.SaveChanges() : limpiar() : llenar(txtBuscar.Text.Trim) : MessageBox.Show("Bodega editada")
                    Else
                        MessageBox.Show("Error, No se encuentra esta bodega. Probablemente ha sido eliminada.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub frmBodega_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub txtN_Bodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodBodega.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCodBodega.Text.Trim() <> "" Then
                Using db As New CodeFirst
                    Dim bodega = db.Bodegas.Where(Function(f) f.N_BODEGA = txtCodBodega.Text).FirstOrDefault()
                    If bodega Is Nothing Then
                        txtNombre.Focus()
                    Else
                        txtCodigo.Text = bodega.IDBODEGA
                        txtNombre.Text = bodega.DESCRIPCION
                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                        txtNombre.Focus()
                    End If
                    bodega = Nothing
                End Using
            Else
                MessageBox.Show("Ingresar el código de la sucursal")
            End If
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtNombre.Text.Trim <> "" Then
                If txtCodigo.Text = "" Then
                    btGuardar_Click(Nothing, Nothing)
                Else
                    btEditar_Click(Nothing, Nothing)
                End If
            Else
                MessageBox.Show("Ingresar nombre de la sucursal")
            End If
        End If
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Using db As New CodeFirst
                    txtCodigo.Text = dtRegistro.SelectedRows(0).Cells(0).Value.ToString()
                    Dim b = db.Bodegas.Where(Function(f) f.IDBODEGA.Equals(txtCodigo.Text) And f.ACTIVO.Equals(Config.vTrue)).FirstOrDefault
                    If Not b Is Nothing Then
                        txtCodBodega.Text = b.N_BODEGA
                        txtNombre.Text = b.DESCRIPCION
                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                        txtCodBodega.Focus()
                    Else
                        MessageBox.Show("No se encuentra esta 'Bodega'. Probablemente ha sido eliminado.")
                        txtCodigo.Clear()
                        txtCodBodega.Focus()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub frmBodega_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmBodega_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblBuscar.Left = pnBuscar.Width - 205
        txtBuscar.Left = pnBuscar.Width - 151
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        llenar(txtBuscar.Text.Trim)
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

End Class