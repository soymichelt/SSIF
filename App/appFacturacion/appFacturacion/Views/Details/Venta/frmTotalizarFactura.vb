Public Class frmTotalizarFactura

    Private Sub txtPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPago.KeyPress
        Try
            If e.KeyChar = ChrW(13) Then
                If txtPago.Value >= Decimal.Parse(txtTotal.Text) Then
                    txtCambio.Text = (txtPago.Value - Decimal.Parse(txtTotal.Text)).ToString(Config.f_m)
                    btAceptar.Focus()
                Else
                    MessageBox.Show("Faltan: C$ " & (Decimal.Parse(txtTotal.Text) - txtPago.Value))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btAceptar_Click(sender As Object, e As EventArgs) Handles btAceptar.Click
        Me.Close()
    End Sub

    Private Sub frmTotalizarFactura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class