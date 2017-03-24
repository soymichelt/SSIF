Public Class frmEstadoCuenta
    Dim saldo, disponible, vencido As Decimal
    Sub MostrarEstadoCuenta(ByVal fechacorte As DateTime)
        Try
            If Not txtIdCliente.Text.Trim() = "" Then
                Using db As New CodeFirst
                    Dim cliente = db.Clientes.Where(Function(f) f.IDCLIENTE = txtIdCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                    If Not cliente Is Nothing Then
                        Dim ventas = From ven In db.Ventas Where ven.ANULADO = "N" And ven.IDCLIENTE = txtIdCliente.Text And ven.CREDITO = True Select SALDOCREDITO = If(cliente.MONEDA.Equals(Config.cordoba), If(ven.MONEDA.Equals(Config.cordoba), ven.SALDOCREDITO, ven.SALDOCREDITO * Config.tazadecambio), If(ven.MONEDA.Equals(Config.cordoba), ven.SALDOCREDITO / Config.tazadecambio, ven.SALDOCREDITO))
                        If Not ventas Is Nothing Then
                            If ventas.Count() > 0 Then
                                saldo = ventas.Sum()
                            Else
                                saldo = 0.0
                            End If
                        Else
                            saldo = 0.0
                        End If
                        disponible = cliente.LIMITECREDITO - saldo
                        Dim ventas_vencida = From ven In db.Ventas Where ven.ANULADO = "N" And ven.IDCLIENTE = txtIdCliente.Text And ven.CREDITO = True And ven.FECHACREDITOVENCIMIENTO <= DateTime.Now Select SALDOCREDITO = If(cliente.MONEDA.Equals(Config.cordoba), If(ven.MONEDA.Equals(Config.cordoba), ven.SALDOCREDITO, ven.SALDOCREDITO * Config.tazadecambio), If(ven.MONEDA.Equals(Config.cordoba), ven.SALDOCREDITO / Config.tazadecambio, ven.SALDOCREDITO))
                        If Not ventas_vencida Is Nothing Then
                            If ventas_vencida.Count() > 0 Then
                                vencido = Decimal.Parse(ventas_vencida.Sum())
                            Else
                                vencido = 0.0
                            End If
                        Else
                            vencido = 0.0
                        End If
                        Dim consulta = (From cli In db.Clientes Join ven In db.Ventas On cli.IDCLIENTE Equals ven.IDCLIENTE Join estado In db.VentasEstadosCuentas On ven.IDVENTA Equals estado.IDVENTA Join ser In db.Series On ser.IDSERIE Equals estado.IDSERIE Where estado.ACTIVO = "S" And ven.ANULADO = "N" And cli.IDCLIENTE = cliente.IDCLIENTE And ven.CREDITO And estado.FECHA <= fechacorte Order By estado.N Ascending Select estado.N, cli.N_CLIENTE, NOMBRECLIENTE = cli.NOMBRES & " " & cli.APELLIDOS, cli.RAZONSOCIAL, cli.DOMICILIO, cli.TELEFONO, LIMITE = cliente.LIMITECREDITO, SALDOCLIENTE = saldo, DISPONIBLECLIENTE = disponible, VENCIDOCLIENTE = vencido, SERIE = ser.NOMBRE, estado.N_DOCUMENTO, estado.OPERACION, estado.FECHA, estado.PLAZO, estado.FECHAVENCIMIENTO, MONEC = estado.MONEDA, MONEDA = If(estado.MONEDA = Config.cordoba, "Córdoba", "Dólar"), estado.TAZACAMBIO, estado.DEBE_C, estado.DEBE_D, estado.HABER_C, estado.HABER_D, ID = ven.N, ven.IDVENTA, ven.SALDOCREDITO)
                        Dim s = (From v In db.Ventas Where v.ANULADO.Equals("N") And v.IDCLIENTE.Equals(cliente.IDCLIENTE) And v.CREDITO And v.FECHAFACTURA < fechacorte Select v.MONEDA, v.SALDOCREDITO)
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
                                temp = If(c.MONEC.Equals(Config.cordoba), c.DEBE_C, c.DEBE_D)
                                m = c.MONEC
                            End If
                            If tmpb = c.ID Then
                                temp = temp - If(m.Equals(Config.cordoba), c.HABER_C, c.HABER_D)
                            End If
                            Dim reg As New ESTADODECUENTA
                            reg.N = c.N
                            reg.SERIE = c.SERIE
                            reg.N_DOCUMENTO = c.N_DOCUMENTO
                            reg.OPERACION = c.OPERACION
                            reg.FECHA = c.FECHA
                            reg.PLAZO = If(Not c.FECHAVENCIMIENTO Is Nothing, DateDiff("d", c.FECHA, c.FECHAVENCIMIENTO).ToString(), "")
                            reg.FECHAVENCIMIENTO = If(Not c.FECHAVENCIMIENTO Is Nothing, c.FECHAVENCIMIENTO.Value.ToShortDateString(), "")
                            reg.MONEDA = c.MONEDA
                            reg.TAZA = c.TAZACAMBIO
                            reg.DEBE = If(c.MONEC.Equals(Config.cordoba), c.DEBE_C, c.DEBE_D)
                            reg.HABER = If(c.MONEC.Equals(Config.cordoba), c.HABER_C, c.HABER_D)
                            reg.SALDO = temp
                            reg.ID = c.ID
                            estadodecuenta.Add(reg)
                            reg = Nothing
                        Next
                        temp = Nothing : tmpb = Nothing
                        Dim rpt As New rptEstadoCuenta
                        Dim itextobject As CrystalDecisions.CrystalReports.Engine.TextObject
                        If rdPendientes.Checked Then
                            itextobject = rpt.ReportDefinition.ReportObjects("txtFactura") : itextobject.Text = "(FACTURAS PENDIENTES)"
                        ElseIf rdCanceladas.Checked Then
                            itextobject = rpt.ReportDefinition.ReportObjects("txtFactura") : itextobject.Text = "(FACTURAS CANCELADAS)"
                        Else
                            itextobject = rpt.ReportDefinition.ReportObjects("txtFactura") : itextobject.Text = "(TODAS LAS FACTURAS)"
                        End If
                        itextobject = rpt.ReportDefinition.ReportObjects("txtFechaCorte") : itextobject.Text = fechacorte.ToShortDateString
                        itextobject = rpt.ReportDefinition.ReportObjects("txtCodigo") : itextobject.Text = cliente.N_CLIENTE
                        itextobject = rpt.ReportDefinition.ReportObjects("txtNombre") : itextobject.Text = cliente.NOMBRES & " " & cliente.APELLIDOS
                        itextobject = rpt.ReportDefinition.ReportObjects("txtRazonSocial") : itextobject.Text = cliente.RAZONSOCIAL
                        itextobject = rpt.ReportDefinition.ReportObjects("txtTelefono") : itextobject.Text = cliente.TELEFONO
                        itextobject = rpt.ReportDefinition.ReportObjects("txtDireccion") : itextobject.Text = cliente.DOMICILIO
                        itextobject = rpt.ReportDefinition.ReportObjects("txtLimite") : itextobject.Text = cliente.LIMITECREDITO.ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtSaldo") : itextobject.Text = saldo.ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtDisponible") : itextobject.Text = disponible.ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtVencido") : itextobject.Text = vencido.ToString(Config.f_m)
                        itextobject = rpt.ReportDefinition.ReportObjects("txtMoneda") : itextobject.Text = If(cliente.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar")

                        'TOTALES
                        'Dim a = estadodecuenta.Where(Function(f) f.MONEDA.Equals(SESION.cordoba)).Sum(Function(f) f.DEBE)
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
                        ventas = Nothing : s = Nothing : ventas_vencida = Nothing : consulta = Nothing : estadodecuenta = Nothing : saldo = Nothing : disponible = Nothing : vencido = Nothing
                    End If
                    cliente = Nothing
                End Using
            Else
                MessageBox.Show("Error, Seleccione el cliente.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        txtNCliente.Focus()
    End Sub

    Private Sub txtNCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            Try
                Using db As New CodeFirst
                    If Not txtNCliente.Text.Trim() = "" Then
                        Dim cliente = db.Clientes.Where(Function(f) f.N_CLIENTE = txtNCliente.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not cliente Is Nothing Then
                            txtIdCliente.Text = cliente.IDCLIENTE
                            txtNombreCliente.Text = cliente.N_CLIENTE & " | " & cliente.NOMBRES & " " & cliente.APELLIDOS
                            txtRazonSocial.Text = cliente.RAZONSOCIAL
                            txtNCliente.Clear()
                            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
                        Else
                            MessageBox.Show("Error, No se encuentra este cliente.")
                            frmBuscarClientes.txtCodigo.Text = txtNCliente.Text
                            frmBuscarClientes.frm_return = 11 'retornar el valor aqui
                            frmBuscarClientes.ShowDialog()
                            If Not txtIdCliente.Text.Trim = "" Then
                                txtNCliente.Clear()
                                MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
                            End If
                        End If
                        cliente = Nothing
                    Else
                        txtNCliente.Clear()
                        frmBuscarClientes.frm_return = 11 'retornar el valor aqui
                        frmBuscarClientes.ShowDialog()
                        If Not txtIdCliente.Text.Trim = "" Then
                            txtNCliente.Clear()
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
        'Me.Dispose()
    End Sub

    Private Sub btBuscarCliente_Click(sender As Object, e As EventArgs) Handles btBuscarCliente.Click
        frmBuscarClientes.frm_return = 11
        frmBuscarClientes.ShowDialog()
        If Not txtIdCliente.Text.Trim() = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        Else
            txtNCliente.Focus()
        End If
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh(source As Object, e As CrystalDecisions.Windows.Forms.ViewerEventArgs)
        MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
    End Sub

    Private Sub frmEstadoCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtIdCliente.Clear()
        txtNCliente.Clear()
        txtNombreCliente.Clear()
        txtRazonSocial.Clear()
        rdPendientes.Checked = True
        dtpFechaCorte.Value = DateTime.Now
        CrystalReportViewer1.ReportSource = Nothing
    End Sub

    Private Sub rdPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rdPendientes.CheckedChanged
        If rdPendientes.Checked Then
            If Not txtIdCliente.Text.Trim = "" Then
                MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
            End If
        End If
    End Sub

    Private Sub rdCanceladas_CheckedChanged(sender As Object, e As EventArgs) Handles rdCanceladas.CheckedChanged
        If rdCanceladas.Checked Then
            If Not txtIdCliente.Text.Trim = "" Then
                MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
            End If
        End If
    End Sub

    Private Sub rdTodas_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodas.CheckedChanged
        If rdTodas.Checked Then
            If Not txtIdCliente.Text.Trim = "" Then
                MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
            End If
        End If
    End Sub

    Private Sub dtpFechaCorte_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaCorte.ValueChanged
        If Not txtIdCliente.Text.Trim = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        End If
    End Sub

    Private Sub CrystalReportViewer1_ReportRefresh_1(source As Object, e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
        If Not txtIdCliente.Text.Trim = "" Then
            MostrarEstadoCuenta(DateTime.Parse(dtpFechaCorte.Text & " 23:59:59"))
        End If
    End Sub

    Private Sub frmEstadoCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.B : btBuscar_Click(Nothing, Nothing)
                Case Keys.Delete : btLimpiar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub
End Class