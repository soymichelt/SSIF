Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmCuentasPorCobrar

    Private Async Function GetList() As Threading.Tasks.Task(Of List(Of Sadara.Models.V2.POCO.AccountReceivableEntity))

        Return Await Sadara.BusinessLayer.Customer.Instance.GetListAccountsReceivableAsync(Config.currentBusiness.MonedaInventario, Config.exchangeRate, txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtRazonSocial.Text.Trim())

    End Function

    Async Sub LoadDataInUI(Optional ByVal codigo As String = "", Optional ByVal nombre As String = "", Optional ByVal razon As String = "")
        Try
            Using db As New CodeFirst

                Dim result = Await Me.GetList()

                If dtRegistro.Visible Then

                    dtRegistro.DataSource = result.ToList

                    If result.Count > 0 Then
                        txtTotal.Value = (result).Where(Function(f) f.MoneyOfCredit.Equals(Config.cordoba)).Sum(Function(f) f.Billed)
                        txtTotalDolar.Value = (result).Where(Function(f) f.MoneyOfCredit.Equals(Config.dolar)).Sum(Function(f) f.BilledDollar)
                    Else
                        txtTotal.Value = 0.0
                        txtTotalDolar.Value = 0.0
                    End If

                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Width = 90 : dtRegistro.Columns(0).HeaderText = vbNewLine & "N° CLIENTE" & vbNewLine
                        dtRegistro.Columns(1).Width = 120 : dtRegistro.Columns(1).HeaderText = "IDENTIFICACIÓN"
                        dtRegistro.Columns(2).Width = 250 : dtRegistro.Columns(2).HeaderText = "NOMBRES Y APELLIDOS DEL CLIENTE"
                        dtRegistro.Columns(3).Width = 200 : dtRegistro.Columns(3).HeaderText = "RAZÓN SOCIAL"
                        dtRegistro.Columns(4).Width = 100 : dtRegistro.Columns(4).HeaderText = "TELÉFONO"

                        dtRegistro.Columns(5).Width = 100 : dtRegistro.Columns(5).HeaderText = "MONEDA CRÉDITO"

                        dtRegistro.Columns(6).Width = 100 : dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(6).HeaderText = "PLAZO"
                        dtRegistro.Columns(7).Width = 100 : dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(7).HeaderText = "LÍMITE"

                        dtRegistro.Columns(8).Width = 100 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(8).HeaderText = "SALDO (C$)"
                        dtRegistro.Columns(9).Width = 100 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(9).HeaderText = "SALDO ($)"

                        dtRegistro.Columns(10).Width = 100 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(10).HeaderText = "VENCIDO (C$)"
                        dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(11).HeaderText = "VENCIDO ($)"

                        dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(12).HeaderText = "DISPONIBLE"
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                        Next
                    End If

                Else

                        Dim rpt As New rptCuentasPorCobrar
                    Config.CrystalTitle("CUENTAS POR COBRAR", rpt)
                    Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                    If codigo <> "" Then
                        band = rpt.Section2.ReportObjects("txtCodigo") : band.Text = codigo
                    Else
                        band = rpt.Section2.ReportObjects("txtCodigo") : band.Text = "%Todos%"
                    End If
                    If nombre <> "" Then
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = nombre
                    Else
                        band = rpt.Section2.ReportObjects("txtNombre") : band.Text = "%Todos%"
                    End If
                    If razon <> "" Then
                        band = rpt.Section2.ReportObjects("txtRazonSocial") : band.Text = razon
                    Else
                        band = rpt.Section2.ReportObjects("txtRazonSocial") : band.Text = "%Todos%"
                    End If
                    If result.Count > 0 Then
                        txtTotal.Value = (result).Sum(Function(f) f.Billed)
                    Else
                        txtTotal.Value = 0.0
                    End If
                    rpt.SetDataSource((From r In result Select N_CLIENTE = r.CustomerCode, IDENTIFICACION = r.DNI, CLIENTE = r.CustomerName, RAZONSOCIAL = r.BusinessName, PLAZO = r.CreditTerm, LIMITE = r.CreditLimit, FACTURADO = r.Billed, VENCIDO = r.AmountExpired, DISPONIBLE = r.AmountAvailable).ToList())
                    CrystalReportViewer1.ReportSource = rpt
                    CrystalReportViewer1.Zoom(75)
                    rpt = Nothing : band = Nothing

                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmCuentasPorCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "AccountsReceivable",
            "Load",
            "Load AccountsReceivable",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
        txtTotal.DisplayFormat = Config.f_m
        LoadDataInUI()
    End Sub

    Private Sub txtNCliente_TextChanged(sender As Object, e As EventArgs) Handles txtRazonSocial.TextChanged, txtNombreCliente.TextChanged, txtNCliente.TextChanged
        If dtRegistro.Visible Then
            LoadDataInUI(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtRazonSocial.Text.Trim())
        End If
    End Sub

    Private Sub txtNombreCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRazonSocial.KeyPress, txtNombreCliente.KeyPress, txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            LoadDataInUI(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtRazonSocial.Text.Trim())
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtNCliente.Clear()
        txtNombreCliente.Clear()
        txtRazonSocial.Clear()
        LoadDataInUI(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtRazonSocial.Text.Trim())
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        CrystalReportViewer1.Visible = True
        LoadDataInUI(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtRazonSocial.Text.Trim())
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        LoadDataInUI(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtRazonSocial.Text.Trim())
    End Sub
End Class