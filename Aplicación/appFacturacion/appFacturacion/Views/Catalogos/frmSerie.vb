Public Class frmSerie
    Dim FormLoad As Boolean = False
    Sub llenar(Optional ByVal nombre As String = "")
        Try
            Using db As New CodeFirst
                dtRegistro.DataSource = (From ser In db.SERIES Where ser.ACTIVO = "S" And ser.NOMBRE.Contains(nombre) Select ser.IDSERIE, SERIE = ser.NOMBRE, ser.DESCRIPCION, ser.OPERACION, BODEGA = ser.BODEGA.N_BODEGA & " | " & ser.BODEGA.DESCRIPCION, TipoDocumento = If(ser.FACTURA_MANUAL.Equals(Config.vTrue), "Manual", "Sistema"), TipoImpresion = If(ser.TICKET.Equals(Config.vTrue), "Ticket", "Carta")).ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Visible = False
                    dtRegistro.Columns(1).HeaderText = vbNewLine & "NOMBRE" & vbNewLine
                    dtRegistro.Columns(2).HeaderText = "DESCRIPCIÓN DE LA SERIE" : dtRegistro.Columns(2).Width = 280
                    dtRegistro.Columns(3).HeaderText = "OPERACIÓN" : dtRegistro.Columns(3).Width = 100
                    dtRegistro.Columns(4).HeaderText = "SUCURSAL" : dtRegistro.Columns(4).Width = 230
                    dtRegistro.Columns(5).HeaderText = "TIPO DOCUMENTO" : dtRegistro.Columns(5).Width = 150
                    dtRegistro.Columns(6).HeaderText = "TIPO IMPRESIÓN" : dtRegistro.Columns(6).Width = 150
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
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
        txtDescripcion.Clear()
        cmbOperacion.SelectedIndex = -1 : cmbOperacion.Enabled = True
        cmbBodega.SelectedIndex = -1 : cmbBodega.Enabled = True
        chkFacturaManual.Visible = False
        chkFacturaManual.Checked = False
        chkFacturaManual.Enabled = True
        chkTicket.Visible = False
        chkTicket.Checked = True
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtNombre.Focus()
    End Sub

    Private Sub frmSerie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.frmSerie_Resize(Nothing, Nothing)
        Try
            llenar()
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.BODEGAS Where bod.ACTIVO = "S" Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodega.DisplayMember = "DESCRIPCION" : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
        txtNombre.Focus()
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(txtBuscar.Text.Trim)
        End If
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If txtNombre.Text.Trim <> "" And txtDescripcion.Text.Trim <> "" And (Not cmbOperacion.SelectedItem Is Nothing And Not cmbOperacion.SelectedIndex = -1) And (Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1) Then
                Using db As New CodeFirst
                    If db.SERIES.Where(Function(f) f.NOMBRE = txtNombre.Text).Count() = 0 Then
                        Dim serie As New SERIE : serie.Reg = DateTime.Now : serie.IDSERIE = Guid.NewGuid.ToString() : serie.NOMBRE = txtNombre.Text : serie.DESCRIPCION = txtDescripcion.Text : serie.OPERACION = cmbOperacion.SelectedItem.ToString() : serie.IDBODEGA = cmbBodega.SelectedValue.ToString() : serie.ACTIVO = "S"
                        If chkFacturaManual.Visible Then
                            If chkFacturaManual.Checked Then
                                serie.FACTURA_MANUAL = Config.vTrue
                                serie.TICKET = Config.vFalse
                            Else
                                serie.FACTURA_MANUAL = Config.vFalse
                                If chkTicket.Visible Then
                                    If chkTicket.Checked Then
                                        serie.TICKET = Config.vTrue
                                    Else
                                        serie.TICKET = Config.vFalse
                                    End If
                                Else
                                    serie.TICKET = Config.vFalse
                                End If
                            End If
                        Else
                            serie.FACTURA_MANUAL = Config.vFalse
                            If chkTicket.Visible Then
                                If chkTicket.Checked Then
                                    serie.TICKET = Config.vTrue
                                Else
                                    serie.TICKET = Config.vFalse
                                End If
                            Else
                                serie.TICKET = Config.vFalse
                            End If
                        End If
                        db.SERIES.Add(serie)
                        db.SaveChanges() : limpiar() : llenar(txtBuscar.Text.Trim) : MessageBox.Show("Serie guardada")
                    Else
                        MessageBox.Show("Error, Ya existe una serie con este nombre.")
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
            If txtNombre.Text.Trim <> "" And txtDescripcion.Text.Trim <> "" Then
                Using db As New CodeFirst
                    If db.SERIES.Where(Function(f) Not f.IDSERIE = txtCodigo.Text And f.NOMBRE = txtNombre.Text).Count() = 0 Then
                        Dim serie = db.SERIES.Where(Function(f) f.IDSERIE = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not serie Is Nothing Then
                            serie.NOMBRE = txtNombre.Text
                            serie.DESCRIPCION = txtDescripcion.Text
                            db.Entry(serie).State = EntityState.Modified
                            db.SaveChanges() : limpiar() : llenar(txtBuscar.Text.Trim) : MessageBox.Show("Serie editada")
                        Else
                            MessageBox.Show("Error, No se encuentra esta serie. Probablemente ha sido eliminada.")
                        End If
                    Else
                        MessageBox.Show("Error, Ya existe una serie con este nombre.")
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
                Dim s = db.SERIES.Where(Function(f) f.IDSERIE = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                If Not s Is Nothing Then
                    s.ACTIVO = "N"
                    db.Entry(s).State = EntityState.Modified
                    db.SaveChanges() : limpiar() : llenar(txtBuscar.Text.Trim) : MessageBox.Show("Serie eliminada")
                Else
                    MessageBox.Show("Error, No se encuentra esta serie. Probablemente ha sido eliminada.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmSerie_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btAcutalizarBodega_Click(sender As Object, e As EventArgs) Handles btAcutalizarBodega.Click
        Try
            Using db As New CodeFirst
                If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                    Dim serie As String = cmbBodega.Text
                    cmbBodega.DataSource = (From bod In db.BODEGAS Where bod.ACTIVO = "S" Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodega.DisplayMember = "DESCRIPCION" : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.SelectedIndex = -1
                    cmbBodega.Text = serie
                    serie = Nothing
                Else
                    cmbBodega.DataSource = (From bod In db.BODEGAS Where bod.ACTIVO = "S" Select bod.IDBODEGA, DESCRIPCION = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodega.DisplayMember = "DESCRIPCION" : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.SelectedIndex = -1
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub cmbOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperacion.SelectedIndexChanged, cmbOperacion.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbOperacion.SelectedItem Is Nothing Then
                If cmbOperacion.SelectedItem.ToString() = "VENTA" Or cmbOperacion.SelectedItem.ToString() = "RECIBO DE VENTA" Then
                    chkFacturaManual.Visible = True
                    chkTicket.Visible = True
                Else
                    chkFacturaManual.Visible = False
                    chkTicket.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        llenar(txtBuscar.Text.Trim)
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Dim ID = dtRegistro.SelectedRows(0).Cells(0).Value.ToString()
            Try
                Using db As New CodeFirst
                    Dim s = db.SERIES.Where(Function(f) f.IDSERIE.Equals(ID)).FirstOrDefault
                    If Not s Is Nothing Then
                        txtCodigo.Text = s.IDSERIE
                        txtNombre.Text = s.NOMBRE
                        txtDescripcion.Text = s.DESCRIPCION
                        cmbOperacion.Text = s.OPERACION : cmbOperacion.Enabled = False
                        cmbBodega.Text = s.BODEGA.DESCRIPCION : cmbBodega.Enabled = False
                        If s.OPERACION.Equals("VENTA") Then
                            If s.FACTURA_MANUAL.Equals("S") Then
                                chkFacturaManual.Checked = True
                            Else
                                chkFacturaManual.Checked = False
                            End If
                            chkFacturaManual.Checked = False
                        End If
                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                    Else
                        MessageBox.Show("No se encuentra esta 'Serie'. Probablemente ha sido eliminada.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub frmSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtNombre.Text.Trim <> "" Then
                txtDescripcion.Focus()
            Else
                MessageBox.Show("Ingresar el nombre de la Serie")
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtDescripcion.Text.Trim <> "" Then
                cmbOperacion.Focus()
            Else
                MessageBox.Show("Ingresar la descripción de la Serie.")
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cmbOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbOperacion.KeyDown
        If e.KeyData = Keys.Enter Then
            If Not cmbOperacion.SelectedItem Is Nothing Then
                cmbBodega.Focus()
            Else
                MessageBox.Show("Seleccionar la operación de la Serie")
            End If
        End If
    End Sub

    Private Sub cmbBodega_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBodega.KeyDown
        If e.KeyData = Keys.Enter Then
            If Not cmbBodega.SelectedValue Is Nothing Then
                If btGuardar.Enabled Then
                    btGuardar_Click(Nothing, Nothing)
                ElseIf btEditar.Enabled Then
                    btEditar_Click(Nothing, Nothing)
                End If
            Else
                MessageBox.Show("Seleccionar la bodega de la Serie")
            End If
        End If
    End Sub

    Private Sub frmSerie_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblBuscar.Left = pnBuscar.Width - 205
        txtBuscar.Left = pnBuscar.Width - 151
    End Sub



    Private Sub chkFacturaManual_CheckedChanged(sender As Object, e As EventArgs) Handles chkFacturaManual.CheckedChanged
        If chkFacturaManual.Checked Then
            chkTicket.Checked = False
        End If
    End Sub

    Private Sub chkTicket_CheckedChanged(sender As Object, e As EventArgs) Handles chkTicket.CheckedChanged
        If chkTicket.Checked Then
            If chkFacturaManual.Checked = True Then
                chkTicket.Checked = False
            End If
        End If
    End Sub
End Class