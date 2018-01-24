Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmCuentasPorPagar

    Sub llenar(Optional ByVal codigo As String = "", Optional ByVal nombre As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From pro In db.Proveedores Where pro.FACTURADO_C <> 0 And pro.ACTIVO = "S" And pro.N_PROVEEDOR.Contains(codigo) And pro.NOMBRES.Contains(nombre) Select pro.N_PROVEEDOR, PROVEEDOR = pro.NOMBRES & " " & pro.APELLIDOS, pro.RAZONSOCIAL, pro.TELEFONO, pro.PLAZO, LIMITE = pro.LIMITECREDITO, FACTURADO = If(pro.MONEDA.Equals(Config.cordoba), pro.FACTURADO_C + (pro.FACTURADO_D * Config.tazadecambio), (pro.FACTURADO_C / Config.tazadecambio) + pro.FACTURADO_D), DISPONIBLE = pro.LIMITECREDITO - If(pro.MONEDA.Equals(Config.cordoba), pro.FACTURADO_C + (pro.FACTURADO_D * Config.tazadecambio), (pro.FACTURADO_C / Config.tazadecambio) + pro.FACTURADO_D))
                If dtRegistro.Visible Then
                    'dtRegistro.DataSource = (From cli In db.CLIENTES Join ven In db.VENTAS On cli.IDCLIENTE Equals ven.IDCLIENTE Where cli.N_CLIENTE.Contains(codigo) And (cli.NOMBRES & " " & cli.APELLIDOS).Contains(nombre) And cli.RAZONSOCIAL.Contains(razon) Group ven By cli Into ven = Group Select cli.N_CLIENTE, cli.IDENTIFICACION, CLIENTE = cli.NOMBRES & " " & cli.APELLIDOS, cli.RAZONSOCIAL, cli.PLAZO, cli.LIMITECREDITO, cli.FACTURADO, VENCIDO = If(Not ven.Where(Function(f) f.FECHACREDITOVENCIMIENTO > DateTime.Now And f.SALDOCREDITO > 0).Select(Function(f) f.SALDOCREDITO).Count() > 0, ven.Where(Function(f) f.FECHACREDITOVENCIMIENTO > DateTime.Now And f.SALDOCREDITO > 0).Select(Function(f) f.SALDOCREDITO).Sum(), 0.0), SALDO = cli.LIMITECREDITO - cli.FACTURADO).ToList()
                    dtRegistro.DataSource = consulta.ToList()
                    If consulta.Count > 0 Then
                        txtTotal.Value = (consulta).Sum(Function(f) f.FACTURADO)
                    Else
                        txtTotal.Value = 0.0
                    End If
                    If dtRegistro.Columns.Count > 0 Then
                        dtRegistro.Columns(0).Width = 120 : dtRegistro.Columns(0).HeaderText = vbNewLine & "N° PROVEEDOR" & vbNewLine
                        dtRegistro.Columns(1).Width = 250 : dtRegistro.Columns(1).HeaderText = "NOMBRE DEL PROVEEDOR"
                        dtRegistro.Columns(2).Width = 200 : dtRegistro.Columns(2).HeaderText = "RAZÓN SOCIAL"
                        dtRegistro.Columns(3).Width = 100 : dtRegistro.Columns(3).HeaderText = "TELÉFONO"
                        dtRegistro.Columns(4).Width = 100 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(4).HeaderText = "PLAZO"
                        dtRegistro.Columns(5).Width = 100 : dtRegistro.Columns(5).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(5).HeaderText = "LÍMITE"
                        dtRegistro.Columns(6).Width = 100 : dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(6).HeaderText = "SALDO"
                        dtRegistro.Columns(7).Width = 100 : dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(7).HeaderText = "DISPONIBLE"
                        For Each c As DataGridViewColumn In dtRegistro.Columns
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                        Next
                    End If
                Else
                    Dim rpt As New rptCuentasPorPagar
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
                    If consulta.Count > 0 Then
                        txtTotal.Value = (consulta).Sum(Function(f) f.FACTURADO)
                    Else
                        txtTotal.Value = 0.0
                    End If
                    rpt.SetDataSource((From pro In db.Proveedores Where pro.FACTURADO_C <> 0 And pro.ACTIVO = "S" And pro.N_PROVEEDOR.Contains(codigo) And (pro.NOMBRES & " " & pro.APELLIDOS).Contains(nombre) Select pro.N_PROVEEDOR, PROVEEDOR = pro.NOMBRES & " " & pro.APELLIDOS, pro.PLAZO, LIMITE = pro.LIMITECREDITO, FACTURADO = If(pro.MONEDA.Equals(Config.cordoba), pro.FACTURADO_C + (pro.FACTURADO_D * Config.tazadecambio), (pro.FACTURADO_C / Config.tazadecambio) + pro.FACTURADO_D), DISPONIBLE = pro.LIMITECREDITO - If(pro.MONEDA.Equals(Config.cordoba), pro.FACTURADO_C + (pro.FACTURADO_D * Config.tazadecambio), (pro.FACTURADO_C / Config.tazadecambio) + pro.FACTURADO_D)).ToList())
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
        dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
        llenar()
    End Sub

    Private Sub txtNCliente_TextChanged(sender As Object, e As EventArgs) Handles txtNombreCliente.TextChanged, txtNCliente.TextChanged
        If dtRegistro.Visible Then
            llenar(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim())
        End If
    End Sub

    Private Sub txtNombreCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreCliente.KeyPress, txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim())
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtNCliente.Clear()
        txtNombreCliente.Clear()
        llenar(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim())
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        CrystalReportViewer1.Visible = True
        llenar(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim())
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        llenar(txtNCliente.Text.Trim(), txtNombreCliente.Text.Trim())
    End Sub
End Class