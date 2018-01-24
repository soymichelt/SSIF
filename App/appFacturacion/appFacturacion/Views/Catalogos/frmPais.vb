Imports System.Data.OleDb
Public Class frmPais

    Sub limpiar()
        txtCodigo.Clear()
        txtNPais.Clear()
        txtNombre.Clear()
        txtAbreviatura1.Clear()
        txtAbreviatura2.Clear()
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEditar.Enabled = False
        txtNPais.Focus()
    End Sub

    Private Sub frmTrabajadorPuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        'Try
        '    If txtNPais.Text.Trim <> "" And txtNombre.Text.Trim <> "" Then
        '        Using db As New MODELODEDATOS
        '            Dim pais As New PAIS : pais.IDPAIS = Guid.NewGuid.ToString() : pais.N_PAIS = txtNPais.Text : pais.NOMBRE = txtNombre.Text : pais.ABREVIATURA1 = txtAbreviatura1.Text : pais.ABREVIATURA2 = txtAbreviatura2.Text : pais.ACTIVO = "S" : db.PAISES.Add(pais) : db.SaveChanges() : pais = Nothing
        '            limpiar()
        '            MessageBox.Show("País guardado")
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
        '    If txtNPais.Text.Trim <> "" And txtNombre.Text.Trim <> "" Then
        '        Using db As New MODELODEDATOS
        '            If db.PAISES.Where(Function(f) Not f.IDPAIS = txtCodigo.Text And f.NOMBRE = txtNPais.Text.Trim).Count() = 0 Then
        '                Dim pais = db.PAISES.Where(Function(f) f.IDPAIS = txtCodigo.Text).FirstOrDefault()
        '                If Not pais Is Nothing Then
        '                    pais.N_PAIS = txtNPais.Text : pais.NOMBRE = txtNombre.Text : pais.ABREVIATURA1 = txtAbreviatura1.Text : pais.ABREVIATURA2 = txtAbreviatura2.Text
        '                    db.Entry(pais).State = EntityState.Modified : pais = Nothing
        '                    db.SaveChanges() : limpiar() : MessageBox.Show("País editado")
        '                Else
        '                    MessageBox.Show("Error, No se encuentra este País. Probablemente ha sido eliminado.")
        '                End If
        '            Else
        '                MessageBox.Show("Error, Ya existe un País con este nombre.")
        '            End If
        '        End Using
        '    Else
        '        MessageBox.Show("Error, Faltan datos.")
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Error, " & ex.Message)
        'End Try
    End Sub

    Private Sub btEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        'Try
        '    Using db As New MODELODEDATOS
        '        Dim pais = db.PAISES.Where(Function(f) f.IDPAIS = txtCodigo.Text).FirstOrDefault()
        '        If Not pais Is Nothing Then
        '            pais.ACTIVO = "N"
        '            db.Entry(pais).State = EntityState.Modified : pais = Nothing
        '            db.SaveChanges() : limpiar() : MessageBox.Show("País eliminado")
        '        Else
        '            MessageBox.Show("Error, No se encuentra este País. Probablemente ha sido eliminado.")
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
        frmBuscarPais.frm_return = 1
        frmBuscarPais.ShowDialog()
    End Sub
End Class