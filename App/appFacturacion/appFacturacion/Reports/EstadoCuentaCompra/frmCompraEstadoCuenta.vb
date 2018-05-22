Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmCompraEstadoCuenta
    Dim saldo, disponible, vencido As Decimal
    Sub MostrarEstadoCuenta(ByVal fechacorte As DateTime)
        Try
            If Not txtIdProveedor.Text.Trim() = "" Then
                Using db As New CodeFirst
                    Dim proveedor = db.Proveedores.Where(Function(f) f.IDPROVEEDOR = txtIdProveedor.Text And f.ACTIVO = "S").FirstOrDefault()
                    If Not proveedor Is Nothing Then
                        Dim compras = From com In db.Compras Where com.ANULADO = "N" And com.IDPROVEEDOR = txtIdProveedor.Text And com.CREDITO = True Select SALDOCREDITO = If(proveedor.MONEDA.Equals(Config.cordoba), If(com.MONEDA.Equals(Config.cordoba), com.SALDOCREDITO, com.SALDOCREDITO * Config.exchangeRate), If(com.MONEDA.Equals(Config.cordoba), com.SALDOCREDITO / Config.exchangeRate, com.SALDOCREDITO))
                        If Not compras Is Nothing Then
                            If compras.Count() > 0 Then
                                saldo = Decimal.Parse(compras.Sum())
                            Else
                                saldo = 0.0
                            End If
                        Else
                            saldo = 0.0
                        End If
                        disponible = proveedor.LIMITECREDITO - saldo
                        Dim compras_vencida = From com In db.Compras Where com.ANULADO = "N" And com.IDPROVEEDOR = txtIdProveedor.Text And com.CREDITO = True And com.FECHACREDITOVENCIMIENTO <= DateTime.Now Select SALDOCREDITO = If(proveedor.MONEDA.Equals(Config.cordoba), If(com.MONEDA.Equals(Config.cordoba), com.SALDOCREDITO, com.SALDOCREDITO * Config.exchangeRate), If(com.MONEDA.Equals(Config.cordoba), com.SALDOCREDITO / Config.exchangeRate, com.SALDOCREDITO))
                        If Not compras_vencida Is Nothing Then
                            If compras_vencida.Count() > 0 Then
                                vencido = Decimal.Parse(compras_vencida.Sum())
                            Else
                                vencido = 0.0
                            End If
                        Else
                            vencido = 0.0
                        End If
                        Dim consulta = From pro In db.Proveedores Join com In db.Compras On pro.IDPROVEEDOR Equals com.IDPROVEEDOR Join estado In db.ComprasEstadosCuentas On com.IDCOMPRA Equals estado.IDCOMPRA Join ser In db.SERIES On ser.IDSERIE Equals estado.IDSERIE Where estado.ACTIVO = "S" And pro.IDPROVEEDOR = txtIdProveedor.Text And com.CREDITO And com.FECHACOMPRA <= fechacorte Order By estado.N Ascending Select estado.N, SERIE = ser.NOMBRE, estado.N_DOCUMENTO, estado.N_COMPRA, estado.FORMADEPAGO, estado.N_PAGO, estado.OPERACION, estado.FECHA, estado.PLAZO, estado.FECHAVENCIMIENTO, MONEC = estado.MONEDA, MONEDA = If(estado.MONEDA = Config.cordoba, "Córdoba", "Dólar"), estado.TAZACAMBIO, estado.DEBE_C, estado.DEBE_D, estado.HABER_C, estado.HABER_D, ID = com.N, com.SALDOCREDITO
                        Dim s = (From v In db.Compras Where v.ANULADO.Equals("N") And v.IDPROVEEDOR.Equals(proveedor.IDPROVEEDOR) And v.CREDITO And v.FECHACOMPRA < fechacorte Select v.MONEDA, v.SALDOCREDITO)
                        If rdPendientes.Checked Then
                            consulta = consulta.Where(Function(f) f.SALDOCREDITO > 0)
                        ElseIf rdCanceladas.Checked Then
                            consulta = consulta.Where(Function(f) f.SALDOCREDITO <= 0)
                        End If
                        Dim estadodecuenta As New List(Of ESTADODECUENTA)
                        Dim temp As Decimal = 0 : Dim tmpb = -1 : Dim m = ""
                        For Each c In (From con In consulta Order By con.ID Ascending, con.N Ascending, con.OPERACION Descending)
                            If tmpb <> c.ID Then
                                tmpb = c.ID
                                temp = If(c.MONEC.Equals(Config.cordoba), c.HABER_C, c.HABER_D)
                                m = c.MONEC
                            Else
                                temp = temp - If(m.Equals(Config.cordoba), c.DEBE_C, c.DEBE_D)
                            End If
                            Dim reg As New ESTADODECUENTA : reg.N = c.N : reg.SERIE = c.SERIE : reg.N_DOCUMENTO = c.N_DOCUMENTO : reg.OPERACION = c.OPERACION : reg.FECHA = c.FECHA : reg.PLAZO = If(Not c.FECHAVENCIMIENTO Is Nothing, DateDiff("d", c.FECHA, c.FECHAVENCIMIENTO).ToString(), "") : reg.FECHAVENCIMIENTO = If(Not c.FECHAVENCIMIENTO Is Nothing, c.FECHAVENCIMIENTO.Value.ToShortDateString(), "") : reg.MONEDA = c.MONEDA : reg.TAZA = c.TAZACAMBIO : reg.DEBE = If(c.MONEC.Equals(Config.cordoba), c.DEBE_C, c.DEBE_D) : reg.HABER = If(c.MONEC.Equals(Config.cordoba), c.HABER_C, c.HABER_D) : reg.SALDO = temp : reg.ID = c.ID : estadodecuenta.Add(reg) : reg = Nothing
                        Next
                        Dim rpt As New rptCompraEstadoCuenta
                        Dim itextobject As CrystalDecisions.CrystalReports.Engine.TextObject
                        If rdPendientes.Checked Then
                            itextobject = rpt.ReportDefinition.ReportObjects("txtFactura") : itextobject.Text = "(FACTURAS PENDIENTES)"
                        ElseIf rdCanceladas.Checked Then
                            itextobject = rpt.ReportDefinition.ReportObjects("txtFactura") : itextobject.Text = "(FACTURAS CANCELADAS)"
                        Else
                            itextobject = rpt.ReportDefinition.ReportObjects("txtFactura") : itextobject.Text = "(TODAS LAS FACTURAS)"
                        End If
                        itextobject = rpt.ReportDefinition.ReportObjects("txtFechaCorte") : itextobject.Text = fechacorte.ToShortDateString
                        itextobject = rpt.ReportDefinition.ReportObjects("txtCodigo") : itextobject.Text = proveedor.N_PROVEEDOR
                        itextobject = rpt.ReportDefinition.ReportObjects("txtNombre") : itextobject.Text = proveedor.NOMBRES & " " & proveedor.APELLIDOS
                        itextobject = rpt.ReportDefinition.ReportObjects("txtRazonSocial") : itextobject.Text = proveedor.RAZONSOCIAL
                        itextobject = rpt.ReportDefinition.ReportObjects("txtTelefono") : itextobject.Text = proveedor.TELEFONO
                        itextobject = rpt.ReportDefinition.ReportObjects("txtDireccion") : itextobject.Text = proveedor.DOMICILIO
                        itextobject = rpt.ReportDefinition.ReportObjects("txtLimite") : itextobject.Text = proveedor.LIMITECREDITO.ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtSaldo") : itextobject.Text = saldo.ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtDisponible") : itextobject.Text = disponible.ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtVencido") : itextobject.Text = vencido.ToString(Config.f_m)

                        'TOTALES
                        itextobject = rpt.ReportDefinition.ReportObjects("txtDebeCordoba") : itextobject.Text = (estadodecuenta.Where(Function(f) f.MONEDA.Equals("Córdoba")).Sum(Function(f) f.DEBE)).ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtHaberCordoba") : itextobject.Text = (estadodecuenta.Where(Function(f) f.MONEDA.Equals("Córdoba")).Sum(Function(f) f.HABER)).ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtSaldoCordoba") : itextobject.Text = (If(s.Where(Function(f) f.MONEDA.Equals(Config.cordoba)).Count > 0, s.Where(Function(f) f.MONEDA.Equals(Config.cordoba)).Sum(Function(f) f.SALDOCREDITO), 0.0)).ToString(Config.f_m)

                        itextobject = rpt.ReportDefinition.ReportObjects("txtDebeDolar") : itextobject.Text = (estadodecuenta.Where(Function(f) f.MONEDA.Equals("Dólar")).Sum(Function(f) f.DEBE)).ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtHaberDolar") : itextobject.Text = (estadodecuenta.Where(Function(f) f.MONEDA.Equals("Dólar")).Sum(Function(f) f.HABER)).ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtSaldoDolar") : itextobject.Text = (If(s.Where(Function(f) f.MONEDA.Equals(Config.dolar)).Count > 0, s.Where(Function(f) f.MONEDA.Equals(Config.dolar)).Sum(Function(f) f.SALDOCREDITO), 0.0)).ToString(Config.f_m)
                        'FIN TOTALES

                        rpt.SetDataSource(estadodecuenta.OrderBy(Function(f) f.N))
                        Config.CrystalTitle("ESTADO DE CUENTA", rpt)
                        CrystalReportViewer1.ReportSource = rpt
                        CrystalReportViewer1.Zoom(75)
                        rpt = Nothing : itextobject = Nothing
                        compras = Nothing : compras_vencida = Nothing : consulta = Nothing : estadodecuenta = Nothing : saldo = Nothing : disponible = Nothing : vencido = Nothing
                    End If
                    proveedor = Nothing
                End Using
            Else
                MessageBox.Show("Error, Seleccione el proveedor.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        txtNProveedor.Focus()
    End Sub

    Private Sub txtNCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNProveedor.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                Using db As New CodeFirst
                    If Not txtNProveedor.Text.Trim() = "" Then
                        Dim proveedor = db.Proveedores.Where(Function(f) f.N_PROVEEDOR = txtNProveedor.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not proveedor Is Nothing Then
                            txtIdProveedor.Text = proveedor.IDPROVEEDOR
                            txtNombreProveedor.Text = proveedor.N_PROVEEDOR & " | " & proveedor.NOMBRES & " " & proveedor.APELLIDOS
                            txtRazonSocial.Text = proveedor.RAZONSOCIAL
                            txtNProveedor.Clear()
                            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
                        Else
                            MessageBox.Show("Error, No se encuentra este 'Proveedor'.")
                            frmBuscarClientes.txtCodigo.Text = txtNProveedor.Text
                            frmBuscarProveedor.frm_return = 11 'retornar el valor aqui
                            frmBuscarProveedor.ShowDialog()
                            If Not txtIdProveedor.Text.Trim = "" Then
                                txtNProveedor.Clear()
                                MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
                            End If
                        End If
                        proveedor = Nothing
                    Else
                        txtNProveedor.Clear()
                        frmBuscarProveedor.frm_return = 4 'retornar el valor aqui
                        frmBuscarProveedor.ShowDialog()
                        If Not txtIdProveedor.Text.Trim = "" Then
                            txtNProveedor.Clear()
                            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
                        End If
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub frmEstadoCuenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btBuscarCliente_Click(sender As Object, e As EventArgs) Handles btBuscarCliente.Click
        frmBuscarProveedor.frm_return = 4
        frmBuscarProveedor.ShowDialog()
        If Not txtIdProveedor.Text.Trim() = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        Else
            txtNProveedor.Focus()
        End If
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(source As Object, e As CrystalDecisions.Windows.Forms.ViewerEventArgs)
        MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
    End Sub

    Private Sub frmEstadoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpFechaCorte.Value = DateTime.Now

        Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "AccountStatusPurchase",
            "Load",
            "Load AccountStatusPurchase",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtIdProveedor.Clear()
        txtNProveedor.Clear()
        txtNombreProveedor.Clear()
        rdPendientes.Checked = True
        dtpFechaCorte.Value = DateTime.Now
        CrystalReportViewer1.ReportSource = Nothing
    End Sub

    Private Sub rdPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rdPendientes.CheckedChanged
        If Not txtIdProveedor.Text.Trim = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        End If
    End Sub

    Private Sub rdCanceladas_CheckedChanged(sender As Object, e As EventArgs) Handles rdCanceladas.CheckedChanged
        If Not txtIdProveedor.Text.Trim = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        End If
    End Sub

    Private Sub rdTodas_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodas.CheckedChanged
        If Not txtIdProveedor.Text.Trim = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        End If
    End Sub

    Private Sub dtpFechaCorte_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaCorte.ValueChanged
        If Not txtIdProveedor.Text.Trim = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        End If
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh_1(source As Object, e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        If Not txtIdProveedor.Text.Trim = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        End If
    End Sub

    Private Sub frmCompraEstadoCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.B : btBuscar_Click(Nothing, Nothing)
                Case Keys.Delete : btLimpiar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub
End Class