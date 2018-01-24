Imports System.Data.OleDb
Public Class frmCiudad

    Sub limpiar()
        txtCodigo.Clear()
        txtNCiudad.Clear()
        txtNombre.Clear()
        txtIdPais.Clear()
        txtPais.Clear()
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtNCiudad.Focus()
    End Sub

    Private Sub frmTrabajadorPuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        'Try
        '    If txtNCiudad.Text.Trim <> "" And txtNombre.Text.Trim <> "" Then
        '        Using db As New MODELODEDATOS
        '            Dim ciudad As New CIUDAD : ciudad.IDCIUDAD = Guid.NewGuid.ToString() : ciudad.N_CIUDAD = txtNCiudad.Text : ciudad.NOMBRE = txtNombre.Text : ciudad.IDPAIS = txtIdPais.Text : ciudad.ACTIVO = "S" : db.CIUDADES.Add(ciudad) : db.SaveChanges() : ciudad = Nothing
        '            limpiar()
        '            MessageBox.Show("Ciudad guardada")
        '        End Using
        '    Else
        '        MessageBox.Show("Ingresar todos los campos de orden obligatorios (*)")
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Error, " & ex.Message)
        'End Try
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        'Try
        '    If txtNCiudad.Text.Trim <> "" And txtNombre.Text.Trim <> "" Then
        '        Using db As New MODELODEDATOS
        '            If db.PAISES.Where(Function(f) Not f.IDPAIS = txtCodigo.Text And f.NOMBRE = txtNCiudad.Text.Trim).Count() = 0 Then
        '                Dim ciudad = db.CIUDADES.Where(Function(f) f.IDCIUDAD = txtCodigo.Text).FirstOrDefault()
        '                If Not ciudad Is Nothing Then
        '                    ciudad.N_CIUDAD = txtNCiudad.Text : ciudad.NOMBRE = txtNombre.Text : ciudad.IDPAIS = txtIdPais.Text
        '                    db.Entry(ciudad).State = EntityState.Modified : ciudad = Nothing
        '                    db.SaveChanges() : limpiar() : MessageBox.Show("Ciudad editada")
        '                Else
        '                    MessageBox.Show("Error, No se encuentra esta Ciudad. Probablemente ha sido eliminado.")
        '                End If
        '            Else
        '                MessageBox.Show("Error, Ya existe un País con este nombre.")
        '            End If
        '        End Using
        '    Else
        '        MessageBox.Show("Ingresar todos los campos de orden obligatorios (*)")
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Error, " & ex.Message)
        'End Try
    End Sub

    Private Sub btEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        'Try
        '    Using db As New MODELODEDATOS
        '        Dim ciudad = db.CIUDADES.Where(Function(f) f.IDCIUDAD = txtCodigo.Text).FirstOrDefault()
        '        If Not ciudad Is Nothing Then
        '            ciudad.ACTIVO = "N"
        '            db.Entry(ciudad).State = EntityState.Modified : ciudad = Nothing
        '            db.SaveChanges() : limpiar() : MessageBox.Show("Ciudad eliminada")
        '        Else
        '            MessageBox.Show("Error, No se encuentra esta Ciudad. Probablemente ha sido eliminado.")
        '        End If
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show("Error, " & ex.Message)
        'End Try
    End Sub

    Private Sub frmCliente_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        
    End Sub

    Private Sub btPais_Click(sender As Object, e As EventArgs) Handles btPais.Click
        frmBuscarPais.frm_return = 2
        frmBuscarPais.ShowDialog()
        txtPais.Focus()
    End Sub

    Private Sub txtPais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPais.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdPais.Text <> "" Then
                If txtCodigo.Text = "" Then
                    btGuardar_Click(Nothing, Nothing)
                Else
                    btEditar_Click(Nothing, Nothing)
                End If
            Else
                btPais_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtNCiudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCiudad.KeyPress
        'If e.KeyChar = ChrW(13) Then
        '    If txtNCiudad.Text.Trim() <> "" Then
        '        Using db As New MODELODEDATOS
        '            Dim ciudad = db.CIUDADES.Where(Function(f) f.N_CIUDAD = txtNCiudad.Text).FirstOrDefault()
        '            If ciudad Is Nothing Then
        '                txtNombre.Focus()
        '            Else
        '                txtCodigo.Text = ciudad.IDCIUDAD
        '                txtNombre.Text = ciudad.NOMBRE
        '                txtIdPais.Text = ciudad.PAIS.IDPAIS
        '                txtPais.Text = ciudad.PAIS.NOMBRE
        '                btGuardar.Enabled = False
        '                btEditar.Enabled = True
        '                btEliminar.Enabled = True
        '                txtNombre.Focus()
        '            End If
        '            ciudad = Nothing
        '        End Using
        '    Else
        '        MessageBox.Show("Ingresar el código de la ciudad")
        '    End If
        'End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        'If e.KeyChar = ChrW(13) Then
        '    If txtNombre.Text.Trim <> "" Then
        '        txtPais.Focus()
        '    Else
        '        MessageBox.Show("Ingresar el nombre de la ciudad")
        '    End If
        'End If
    End Sub
End Class