Imports Sadara.Models.V1.Database
Imports System.IO

Public Class frmServer
    Dim FormLoad As Boolean = False

    Public Property Identity As Boolean

    Private Sub frmServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargar Combo de Autenticación
        Dim Aut As New List(Of Tuple(Of String, String))
        Aut.Add(New Tuple(Of String, String)("1", "Autenticación de Windows"))
        Aut.Add(New Tuple(Of String, String)("2", "Autenticación de SQL Server"))
        cmbAutenticacion.DataSource = Aut.ToList
        cmbAutenticacion.ValueMember = "Item1"
        cmbAutenticacion.DisplayMember = "Item2"
        cmbAutenticacion.SelectedIndex = 0

        'Evaluar si se llama desde la autenticación
        If Me.Identity Then
            'Cargar datos si existen
            Try

            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        End If


        FormLoad = True
    End Sub

    Private Sub cmbAutenticacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAutenticacion.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbAutenticacion.SelectedItem Is Nothing And cmbAutenticacion.SelectedIndex <> -1 Then
                If cmbAutenticacion.SelectedValue = "1" Then
                    txtUsuario.Enabled = False
                    txtUsuario.Clear()
                    txtContraseña.Enabled = False
                    txtContraseña.Clear()
                    btConfigurar.Focus()
                ElseIf cmbAutenticacion.SelectedValue = "2" Then
                    txtUsuario.Enabled = True
                    txtContraseña.Enabled = True
                    txtUsuario.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btConfigurar_Click(sender As Object, e As EventArgs) Handles btConfigurar.Click
        Try
            If txtServer.Text <> "" And txtBD.Text <> "" Then
                If Not cmbAutenticacion.SelectedItem Is Nothing And cmbAutenticacion.SelectedIndex <> -1 Then
                    If cmbAutenticacion.SelectedValue = "2" Then
                        If txtUsuario.Text = "" And txtContraseña.Text = "" Then
                            Config.MsgErr("Es necesario ingresar el Usuario y la Contraseña del SGBD.")
                            Exit Sub
                        End If
                    End If
                    'Configurar el Archivo
                    Using dWritter As New StreamWriter(Config.ServerFileName, append:=False)
                        dWritter.WriteLine(CryptoSecurity.Encoding(txtServer.Text))
                        dWritter.WriteLine(CryptoSecurity.Encoding(txtBD.Text))
                        If txtUsuario.Text <> "" And txtContraseña.Text <> "" Then
                            dWritter.WriteLine(CryptoSecurity.Encoding(txtUsuario.Text))
                            dWritter.WriteLine(CryptoSecurity.Encoding(txtContraseña.Text))
                        End If
                        dWritter.Flush()
                    End Using
                    Config.MsgInfo("Guardado Correctamente")
                Else
                    cmbAutenticacion.SelectedIndex = 0
                End If
            Else
                Config.MsgErr("Necesita ingresar el IP o DNS del Servidor y el nombre de la Instancia del SGBD.")
            End If
        Catch ex As Exception
            Config.MsgErr("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub txtServer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtServer.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtServer.Text.Trim <> "" Then
                txtBD.Focus()
            Else
                Config.MsgErr("Necesita ingresar la dirección IP o DNS del Servidor.")
            End If
        End If
    End Sub

    Private Sub txtBD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBD.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtBD.Text.Trim <> "" Then
                cmbAutenticacion.Focus()
            Else
                Config.MsgErr("Necesita ingresar el nombre de la base de datos.")
            End If
        End If
    End Sub

    Private Sub cmbAutenticacion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbAutenticacion.KeyDown
        If e.KeyData = Keys.Enter Then
            If Not cmbAutenticacion.SelectedValue Is Nothing And cmbAutenticacion.SelectedIndex <> -1 Then
                If cmbAutenticacion.SelectedValue = "1" Then
                    btConfigurar.Focus()
                ElseIf cmbAutenticacion.SelectedValue = "2" Then
                    txtUsuario.Focus()
                End If
            Else
                Config.MsgErr("Seleccione un tipo de autenticación.")
            End If
        End If
    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtUsuario.Text.Trim <> "" Then
                txtContraseña.Focus()
            Else
                Config.MsgErr("Necesita ingresar el nombre de usuario del SGBD.")
            End If
        End If
    End Sub

    Private Sub txtContraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtContraseña.Text.Trim <> "" Then
                btConfigurar.Focus()
            Else
                Config.MsgErr("Necesita ingresar la contraseña de usuario del SGBD.")
            End If
        End If
    End Sub

    Private Sub btTestear_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Try
            If txtServer.Text <> "" And txtBD.Text <> "" Then
                Using cnn As New SqlClient.SqlConnection
                    If Not cmbAutenticacion.SelectedItem Is Nothing And cmbAutenticacion.SelectedIndex <> -1 Then
                        Select Case cmbAutenticacion.SelectedValue
                            Case "1"
                                cnn.ConnectionString = "Data Source=" & txtServer.Text & ";Initial Catalog=" & txtBD.Text & "; Integrated Security=True;"
                            Case "2"
                                If txtUsuario.Text = "" And txtContraseña.Text = "" Then
                                    Config.MsgErr("Es necesario ingresar el Usuario y la Contraseña del SGBD.")
                                    Exit Sub
                                End If
                                cnn.ConnectionString = "Data Source=" & txtServer.Text & ";Initial Catalog=" & txtBD.Text & "; User ID=" & txtUsuario.Text & "; Password=" & txtContraseña.Text & ";"
                        End Select
                        cnn.Open()
                        cnn.Close()
                        cnn.Dispose()
                        Config.MsgInfo("Conexión establecida correctamente.")
                    Else
                        cmbAutenticacion.SelectedIndex = 0
                    End If
                End Using
            Else
                Config.MsgErr("Necesita ingresar el IP o DNS del Servidor y el nombre de la Instancia del SGBD.")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
End Class