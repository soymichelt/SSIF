Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmInformacion

    Private business As Sadara.Models.V1.POCO.Empresa

    Private Sub SelectBusiness(ByVal businessId As Guid)

        Using db As New CodeFirst

            Me.business = db.Empresas.Where(Function(f) f.IdEmpresa = businessId).FirstOrDefault()

        End Using

    End Sub

    Private Sub SetDataInControls()

        If Config.currentBusiness IsNot Nothing Then

            Me.SelectBusiness(Config.currentBusiness.IdEmpresa)

            If Me.business IsNot Nothing Then

                txtNombre.Text = business.Nombre
                txtRuc.Text = business.RUC
                txtTelefono1.Text = business.Telefono1
                txtTelefono2.Text = business.Telefono2
                txtDireccion.Text = business.Direccion

                If business.MonedaInventario.Equals(Config.cordoba) Then
                    rdCordoba.Checked = True
                Else
                    rdDolar.Checked = True
                End If

            End If

        End If

    End Sub

    Private Sub AddOrEditBusiness()

        Try

            If txtNombre.Text.Trim <> "" Then

                Using db As New CodeFirst

                    If Config.currentBusiness IsNot Nothing Then

                        Me.SelectBusiness(Config.currentBusiness.IdEmpresa)

                    End If

                    If Me.business IsNot Nothing Then

                        db.Entry(Me.business).State = Entity.EntityState.Modified

                    Else

                        Me.business = New Empresa() With {
                            .IdEmpresa = Guid.NewGuid()
                        }
                        db.Empresas.Add(Me.business)

                    End If

                    With Me.business

                        .Nombre = txtNombre.Text
                        .RUC = txtRuc.Text
                        .Telefono1 = txtTelefono1.Text
                        .Telefono2 = txtTelefono2.Text
                        .Direccion = txtDireccion.Text
                        .MonedaInventario = If(rdCordoba.Checked, Config.cordoba, Config.dolar)

                    End With

                    db.SaveChanges()
                    rdCordoba.Enabled = False
                    rdDolar.Enabled = False
                    Config.currentBusiness = Me.business
                    frmPrincipal.cargarPrivilegios()
                    Me.business = Nothing
                    MessageBox.Show("Guardado!!")
                    txtNombre.Focus()

                End Using

            Else

                MessageBox.Show("Ingresar los campos de orden obligatorio (*)")

            End If

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)

        End Try

    End Sub

    Private Sub frmInformacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Dispose()

    End Sub

    Private Sub frmInformacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SetDataInControls()

    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click

        Me.AddOrEditBusiness()

    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtNombre.Text.Trim <> "" Then
                txtRuc.Focus()
            Else
                Config.MsgErr("Ingresar el Nombre de la Empresa.")
            End If
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        If e.KeyData = Keys.Enter Then
            txtTelefono1.Focus()
        End If
    End Sub


    Private Sub txtTelefono1_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono1.TextChanged
        If txtTelefono1.Text.Trim.Length = 9 Then
            txtTelefono2.Focus()
        End If
    End Sub

    Private Sub txtTelefono2_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono2.TextChanged
        If txtTelefono2.Text.Trim.Length = 9 Then
            txtDireccion.Focus()
        End If
    End Sub

    Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccion.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            rdCordoba.Focus()
        End If
    End Sub
End Class