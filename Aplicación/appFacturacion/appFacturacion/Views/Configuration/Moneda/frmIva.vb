Public Class frmIva
    Sub llenar()
        Try
            lvRegistro.Items.Clear()
            Using db As New CodeFirst
                Dim item As New ListViewItem
                For Each taza In db.IVAS
                    item = lvRegistro.Items.Add(taza.IDIVA)
                    item.SubItems.Add(taza.FECHA.ToString(Config.formato_fecha))
                    item.SubItems.Add(taza.PORCENTAJE.ToString(Config.f_m))
                Next
                item = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
    Private Sub frmIva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar()
        Try
            Using db As New CodeFirst
                Dim iva = db.IVAS.ToList().OrderBy(Function(f) f.FECHA).LastOrDefault()
                If Not iva Is Nothing Then
                    txtPorcentaje.Text = iva.PORCENTAJE.ToString(Config.f_m)
                Else
                    MessageBox.Show("Error, Debe crear un Impuesto al Valor Agregado")
                    btGuardar.Enabled = True
                    txtPorcentaje.Enabled = True
                    txtPorcentaje.Focus()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        btGuardar.Enabled = True
        txtPorcentaje.Enabled = True
        txtPorcentaje.Value = 0
        txtPorcentaje.Focus()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Try
            If Not txtPorcentaje.Text.Trim() = "" Then
                If txtPorcentaje.Value > 0 Then
                    Using db As New CodeFirst
                        Dim iva As New IVA : iva.IDIVA = Guid.NewGuid.ToString() : iva.FECHA = DateTime.Now : iva.PORCENTAJE = Decimal.Parse(txtPorcentaje.Text) : db.IVAS.Add(iva)
                        db.SaveChanges()
                        Config._Iva = iva
                        Config.iva = iva.PORCENTAJE / 100
                        iva = Nothing
                    End Using
                    llenar()
                    txtPorcentaje.Enabled = False
                    btGuardar.Enabled = False
                Else
                    MessageBox.Show("Error, Ingrese un valor mayor a 0")
                End If
            Else
                MessageBox.Show("Error, Ingrese la taza de cambio.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
End Class