Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmSeleccionarBodega
    Public frm_return As Integer = 0
    Sub llenar(Optional ByVal n_bodega As String = "", Optional ByVal nombre As String = "")
        Try
            Using db As New CodeFirst
                Dim item As New ListViewItem
                lvRegistro.Items.Clear()
                For Each bod In db.Bodegas.Where(Function(f) f.ACTIVO = "S" And f.N_BODEGA.Contains(n_bodega) And f.DESCRIPCION.Contains(nombre)).OrderBy(Function(f) f.N)
                    item = lvRegistro.Items.Add(bod.IDBODEGA)
                    item.SubItems.Add(bod.N_BODEGA)
                    item.SubItems.Add(bod.DESCRIPCION)
                Next
                item = Nothing
                If lvRegistro.Items.Count > 0 Then
                    lvRegistro.Items(0).Selected = True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmSeleccionarBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar()
    End Sub

    Private Sub txtN_Bodega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress, txtN_Bodega.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(txtN_Bodega.Text.Trim(), txtDescripcion.Text.Trim())
        End If
    End Sub

    Private Sub lvRegistro_DoubleClick(sender As Object, e As EventArgs) Handles lvRegistro.DoubleClick
        Try
            Using db As New CodeFirst
                If lvRegistro.SelectedItems.Count > 0 Then
                    With lvRegistro.SelectedItems(0)
                        Config.currentUser = db.Usuarios.Where(Function(f) f.IDUsuario = Config.currentUser.IDUsuario And f.Activo.Equals(Config.vTrue)).FirstOrDefault()
                        If Not Config.currentUser Is Nothing Then
                            Dim IdBodega = .SubItems(0).Text
                            Config._warehouse = db.Bodegas.Where(Function(f) f.IDBODEGA = IdBodega And f.ACTIVO = "S").FirstOrDefault()
                            If Not Config._warehouse Is Nothing Then
                                Config.warehouseId = IdBodega
                                Config.warehouseName = Config._warehouse.N_BODEGA & " - " & Config._warehouse.DESCRIPCION
                                frmPrincipal.txtBodega.Text = Config.warehouseName
                                frmPrincipal.lblBodega.Text = "Sucursal: " & Config.warehouseName
                                Select Case Me.frm_return
                                    Case 1
                                        frmPrincipal.Show()
                                End Select
                                'salir
                                Me.Close()
                            Else
                                MessageBox.Show("No se encuentra esta 'Sucursal'")
                            End If
                        Else
                            MessageBox.Show("No se encuentra este 'Usuario'. Por favor, Iniciar Sesión.")
                            Config.LoginInit()
                        End If
                    End With
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmSeleccionarBodega_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub lvRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles lvRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            lvRegistro_DoubleClick(Nothing, Nothing)
        End If
    End Sub
End Class