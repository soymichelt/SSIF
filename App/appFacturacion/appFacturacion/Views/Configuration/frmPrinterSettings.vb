Imports System.IO
Imports System.Drawing.Printing
Public Class frmPrinterSettings

    Dim FormLoad As Boolean = False

    Private Sub frmServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargar datos si existen
        Try
            If PrinterSettings.InstalledPrinters.Count > 0 Then
                cmbImpresoras.Items.Clear()
                For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
                    cmbImpresoras.Items.Add(PrinterSettings.InstalledPrinters.Item(i).ToString)
                    If Not Config.PrintName Is Nothing Then
                        cmbImpresoras.Text = Config.PrintName
                    Else
                        cmbImpresoras.SelectedIndex = -1
                    End If
                Next
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try

        FormLoad = True
    End Sub

    Private Sub btConfigurar_Click(sender As Object, e As EventArgs) Handles btConfigurar.Click
        Try
            If Not cmbImpresoras.SelectedIndex = -1 Then
                'Configurar el Archivo
                Using dWritter As New StreamWriter(Config.PrinterFileName, append:=False)
                    dWritter.WriteLine(CryptoSecurity.Encoding(cmbImpresoras.Text))
                    dWritter.Flush()
                End Using
                Config.MsgInfo("Guardado Correctamente")
                Config.PrintName = cmbImpresoras.Text
            End If
        Catch ex As Exception
            Config.MsgErr("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btTestear_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
End Class