Public Class frmEstado
    Public frm_return As Integer = 0
    Public id As String
#Region "Información de Créditos"
    Public Sub InfoCliente()
        Using db As New CodeFirst
            Select Case frm_return
                Case 0 'clientes
                    Dim cliente = db.CLIENTES.Where(Function(f) f.IDCLIENTE = Me.id And f.ACTIVO = "S").FirstOrDefault()
                    If Not cliente Is Nothing Then
                        If cliente.PLAZO > 0 Then
                            txtPlazo.Text = cliente.PLAZO.ToString()
                        Else
                            MessageBox.Show("Error, Este cliente no tiene plazo para crédito.")
                            Exit Sub
                        End If
                        txtMoneda.Text = If(cliente.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar")
                        If cliente.LIMITECREDITO > 0 Then
                            txtLimite.Text = cliente.LIMITECREDITO.ToString(Config.f_m)
                        Else
                            MessageBox.Show("Error, Este cliente no tiene crédito.")
                            Exit Sub
                        End If
                        'ventas en cordoba
                        Dim ventas = From ven In db.VENTAS Where ven.ANULADO = "N" And ven.IDCLIENTE = Me.id And ven.CREDITO = True And ven.MONEDA = Config.cordoba Select ven.SALDOCREDITO
                        If Not ventas Is Nothing Then
                            If ventas.Count() > 0 Then
                                txtSaldoCordoba.Text = Decimal.Parse(ventas.Sum()).ToString(Config.f_m)
                            Else
                                txtSaldoCordoba.Value = 0
                            End If
                        Else
                            txtSaldoCordoba.Value = 0
                        End If
                        'ventas en dolar
                        ventas = From ven In db.VENTAS Where ven.ANULADO = "N" And ven.IDCLIENTE = Me.id And ven.CREDITO = True And ven.MONEDA = Config.dolar Select ven.SALDOCREDITO
                        If Not ventas Is Nothing Then
                            If ventas.Count() > 0 Then
                                txtSaldoDolar.Value = Decimal.Parse(ventas.Sum())
                            Else
                                txtSaldoDolar.Value = 0
                            End If
                        Else
                            txtSaldoDolar.Value = 0
                        End If
                        'saldo disponible
                        txtDisponible.Value = If(cliente.MONEDA.Equals(Config.cordoba), txtLimite.Value - txtSaldoCordoba.Value - (txtSaldoDolar.Value * Config.tazadecambio), Decimal.Parse(txtLimite.Text) - (txtSaldoCordoba.Value / Config.tazadecambio) - txtSaldoDolar.Value)
                        'saldo vencido en cordobas
                        ventas = From ven In db.VENTAS Where ven.ANULADO = "N" And ven.IDCLIENTE = Me.id And ven.CREDITO = True And ven.MONEDA = Config.cordoba And ven.FECHACREDITOVENCIMIENTO < DateTime.Now Select ven.SALDOCREDITO
                        If Not ventas Is Nothing Then
                            If ventas.Count() > 0 Then
                                txtVencidoCordoba.Text = Decimal.Parse(ventas.Sum()).ToString(Config.f_m)
                            Else
                                txtVencidoCordoba.Text = "0.00"
                            End If
                        Else
                            txtVencidoCordoba.Text = "0.00"
                        End If
                        'saldo vencido en dolar
                        ventas = From ven In db.VENTAS Where ven.ANULADO = "N" And ven.IDCLIENTE = Me.id And ven.CREDITO = True And ven.MONEDA = Config.dolar And ven.FECHACREDITOVENCIMIENTO < DateTime.Now Select ven.SALDOCREDITO
                        If Not ventas Is Nothing Then
                            If ventas.Count() > 0 Then
                                txtVencidoDolar.Text = Decimal.Parse(ventas.Sum()).ToString(Config.f_m)
                            Else
                                txtVencidoDolar.Text = "0.00"
                            End If
                        Else
                            txtVencidoDolar.Text = "0.00"
                        End If
                        ventas = Nothing
                    Else
                        MessageBox.Show("Error, No se encuentra este cliente.")
                    End If
                    cliente = Nothing
                Case 1 'proveedores
                    Dim proveedor = db.PROVEEDORES.Where(Function(f) f.IDPROVEEDOR = Me.id And f.ACTIVO = "S").FirstOrDefault()
                    If Not proveedor Is Nothing Then
                        If proveedor.PLAZO > 0 Then
                            txtPlazo.Text = proveedor.PLAZO.ToString()
                        Else
                            MessageBox.Show("Error, La empresa no tiene plazo para crédito con este proveedor.")
                            Exit Sub
                        End If
                        txtPlazo.Text = If(proveedor.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar")
                        If proveedor.LIMITECREDITO > 0 Then
                            txtLimite.Text = proveedor.LIMITECREDITO.ToString(Config.f_m)
                        Else
                            MessageBox.Show("Error, La empresa no tiene crédito con este proveedor.")
                            Exit Sub
                        End If
                        'ventas en cordoba
                        Dim compras = From com In db.COMPRAS Where com.ANULADO = "N" And com.IDPROVEEDOR = Me.id And com.CREDITO = True And com.MONEDA = Config.cordoba Select com.SALDOCREDITO
                        If Not compras Is Nothing Then
                            If compras.Count() > 0 Then
                                txtSaldoCordoba.Text = Decimal.Parse(compras.Sum()).ToString(Config.f_m)
                            Else
                                txtSaldoCordoba.Value = 0
                            End If
                        Else
                            txtSaldoCordoba.Value = 0
                        End If
                        'ventas en dolar
                        compras = From com In db.COMPRAS Where com.ANULADO = "N" And com.IDPROVEEDOR = Me.id And com.CREDITO = True And com.MONEDA = Config.dolar Select com.SALDOCREDITO
                        If Not compras Is Nothing Then
                            If compras.Count() > 0 Then
                                txtSaldoDolar.Value = Decimal.Parse(compras.Sum())
                            Else
                                txtSaldoDolar.Value = 0
                            End If
                        Else
                            txtSaldoDolar.Value = 0
                        End If
                        'saldo disponible
                        txtDisponible.Value = If(proveedor.MONEDA.Equals(Config.cordoba), txtLimite.Value - txtSaldoCordoba.Value - (txtSaldoDolar.Value * Config.tazadecambio), Decimal.Parse(txtLimite.Text) - (txtSaldoCordoba.Value / Config.tazadecambio) - txtSaldoDolar.Value)
                        'saldo vencido en cordobas
                        compras = From com In db.COMPRAS Where com.ANULADO = "N" And com.IDPROVEEDOR = Me.id And com.CREDITO = True And com.MONEDA = Config.cordoba And com.FECHACREDITOVENCIMIENTO < DateTime.Now Select com.SALDOCREDITO
                        If Not compras Is Nothing Then
                            If compras.Count() > 0 Then
                                txtVencidoCordoba.Text = Decimal.Parse(compras.Sum()).ToString(Config.f_m)
                            Else
                                txtVencidoCordoba.Text = "0.00"
                            End If
                        Else
                            txtVencidoCordoba.Text = "0.00"
                        End If
                        'saldo vencido en dolar
                        compras = From com In db.COMPRAS Where com.ANULADO = "N" And com.IDPROVEEDOR = Me.id And com.CREDITO = True And com.MONEDA = Config.dolar And com.FECHACREDITOVENCIMIENTO < DateTime.Now Select com.SALDOCREDITO
                        If Not compras Is Nothing Then
                            If compras.Count() > 0 Then
                                txtVencidoDolar.Text = Decimal.Parse(compras.Sum()).ToString(Config.f_m)
                            Else
                                txtVencidoDolar.Text = "0.00"
                            End If
                        Else
                            txtVencidoDolar.Text = "0.00"
                        End If
                        compras = Nothing
                    Else
                        MessageBox.Show("Error, No se encuentra este proveedor.")
                    End If
                    proveedor = Nothing
            End Select
        End Using
    End Sub
#End Region

    Private Sub frmEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.InfoCliente()
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmEstado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class