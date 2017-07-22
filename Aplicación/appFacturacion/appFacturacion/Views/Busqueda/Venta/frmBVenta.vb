Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmBVenta
    Public frm_return As Integer = 0
    Sub llenar(ByVal finicio As DateTime, ByVal ffin As DateTime, Optional ByVal pserie As String = "", Optional ByVal pcodigocliente As String = "", Optional ByVal pnombrecliente As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = (From ven In db.Ventas Join ser In db.SERIES On ser.IDSERIE Equals ven.IDSERIE Join bod In db.Bodegas On bod.IDBODEGA Equals ser.IDBODEGA Join tra In db.EMPLEADOS On ven.IDEMPLEADO Equals tra.IDEMPLEADO Where ser.IDSERIE.Contains(pserie) And ven.FECHAFACTURA >= finicio And ven.FECHAFACTURA <= ffin Select ANULADO = If(ven.ANULADO.Equals("S"), "Anulado", ""), ven.IDVENTA, SERIE = ser.NOMBRE, ven.CONSECUTIVO, ven.FECHAFACTURA, N_CLIENTE = If(ven.ANULADO.Equals("N"), If(Not ven.IDCLIENTE Is Nothing, ven.CLIENTE.N_CLIENTE, ""), ""), CLIENTE = If(ven.ANULADO.Equals("N"), If(Not ven.IDCLIENTE Is Nothing, ven.CLIENTE.NOMBRES & " " & ven.CLIENTE.APELLIDOS, ven.CLIENTECONTADO), ""), N_VENDEDOR = If(ven.ANULADO.Equals("N"), tra.N_TRABAJADOR, ""), VENDEDOR = If(ven.ANULADO.Equals("N"), tra.NOMBRES & " " & tra.APELLIDOS, ""), CONDICIÓN = If(ven.ANULADO.Equals("N"), If(ven.CREDITO, "Crédito", "Contado"), ""), MONEDA = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), ""), TAZACAMBIO = If(ven.ANULADO.Equals(Config.vFalse), ven.TAZACAMBIO, Nothing), DESCUENTO = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.DESCUENTO_DIN_C, ven.DESCUENTO_DIN_D), Nothing), SUBTOTAL = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.SUBTOTAL_C, ven.SUBTOTAL_D), Nothing), IVA = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.IVA_DIN_C, ven.IVA_DIN_D), Nothing), TOTAL = If(ven.ANULADO.Equals("N"), If(ven.MONEDA.Equals(Config.cordoba), ven.TOTAL_C, ven.TOTAL_D), Nothing), ven.CREDITO).ToList
                If rdContado.Checked Then
                    consulta = consulta.Where(Function(f) f.CREDITO = False And f.ANULADO = "").ToList
                ElseIf rdCredito.Checked Then
                    consulta = consulta.Where(Function(f) f.CREDITO And f.ANULADO = "").ToList
                End If
                If pcodigocliente.Trim <> "" Then
                    consulta = consulta.Where(Function(f) f.N_CLIENTE.Contains(pcodigocliente)).ToList
                End If
                If pnombrecliente.Trim <> "" Then
                    consulta = consulta.Where(Function(f) f.CLIENTE.Contains(pnombrecliente)).ToList
                End If
                dtRegistro.DataSource = consulta.ToList()
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).Width = 55 : dtRegistro.Columns(0).HeaderText = vbNewLine & "" & vbNewLine
                    dtRegistro.Columns(1).Visible = False
                    dtRegistro.Columns(2).Width = 55
                    dtRegistro.Columns(3).Width = 90 : dtRegistro.Columns(3).HeaderText = "Nº VENTA"
                    dtRegistro.Columns(4).Width = 80 : dtRegistro.Columns(4).DefaultCellStyle.Format = Config.formato_fecha : dtRegistro.Columns(4).HeaderText = "FECHA"
                    dtRegistro.Columns(7).Width = 80 : dtRegistro.Columns(5).HeaderText = "Nº CLIENTE"
                    dtRegistro.Columns(8).Width = 250 : dtRegistro.Columns(6).HeaderText = "NOMBRES Y APELLIDOS DEL CLIENTE"
                    dtRegistro.Columns(5).Width = 80 : dtRegistro.Columns(7).HeaderText = "Nº EMPLEADO"
                    dtRegistro.Columns(6).Width = 220 : dtRegistro.Columns(8).HeaderText = "NOMBRES Y APELLIDOS DEL EMPLEADO"
                    dtRegistro.Columns(9).Width = 70 : dtRegistro.Columns(9).HeaderText = "CONDICIÓN"
                    dtRegistro.Columns(10).Width = 100 : dtRegistro.Columns(10).HeaderText = "MONEDA"
                    dtRegistro.Columns(11).Width = 100 : dtRegistro.Columns(11).HeaderText = "T / Z" : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(12).Width = 100 : dtRegistro.Columns(12).HeaderText = "DESCUENTO" : dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(13).Width = 100 : dtRegistro.Columns(13).HeaderText = "SUB-TOTAL" : dtRegistro.Columns(13).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(14).Width = 100 : dtRegistro.Columns(14).HeaderText = "IVA" : dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(15).Width = 100 : dtRegistro.Columns(15).HeaderText = "TOTAL" : dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(15).Visible = False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtRegistro.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
            Using db As New CodeFirst
                'llenar series
                cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                dtpFechaInicial.Value = DateTime.Now
                dtpFechaFinal.Value = DateTime.Now
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btActualizarSerie_Click(sender As Object, e As EventArgs) Handles btActualizarSerie.Click
        Try
            Using db As New CodeFirst
                If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
                    Dim serie As String = cmbSerie.Text
                    'llenar series
                    cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                    cmbSerie.Text = serie
                    serie = Nothing
                Else
                    'llenar series
                    cmbSerie.DataSource = db.SERIES.Where(Function(f) f.IDBODEGA = Config.bodega And f.ACTIVO = "S" And f.OPERACION = "VENTA").ToList() : cmbSerie.DisplayMember = "NOMBRE" : cmbSerie.ValueMember = "IDSERIE" : cmbSerie.SelectedIndex = -1
                    cmbSerie.Focus()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
        Else
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        cmbSerie.SelectedIndex = -1
        dtpFechaInicial.Value = DateTime.Now
        dtpFechaFinal.Value = DateTime.Now
        llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), )
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim idventa As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString() : Dim venta = db.Ventas.Where(Function(f) f.IDVENTA = idventa).FirstOrDefault()
                    If Not venta Is Nothing Then
                        If venta.ANULADO = "N" Then
                            Select Case frm_return
                                Case 0
                                    frmVenta.txtIdSerie.Text = venta.SERIE.IDSERIE
                                    frmVenta.txtSerie.Text = venta.SERIE.NOMBRE
                                    frmVenta.txtReferencia.Text = venta.SERIE.DESCRIPCION
                                    frmVenta.Id = venta.IDVENTA
                                    frmVenta.txtCodigo.Text = venta.CONSECUTIVO
                                    frmVenta.txtCodigo.Enabled = False
                                    frmVenta.dtpFecha.Text = venta.FECHAFACTURA.ToShortDateString()
                                    frmVenta.chkExonerado.Checked = venta.EXONERADO
                                    frmVenta.txtIdVendedor.Text = venta.Empleado.IDEMPLEADO
                                    frmVenta.txtNombreVendedor.Text = venta.Empleado.N_TRABAJADOR & " | " & venta.Empleado.NOMBRES & " " & venta.Empleado.APELLIDOS
                                    If Not venta.IDCLIENTE Is Nothing Then
                                        frmVenta.txtIdCliente.Text = venta.CLIENTE.IDCLIENTE
                                        frmVenta.txtNombreCliente.Text = venta.CLIENTE.N_CLIENTE & " | " & venta.CLIENTE.NOMBRES & " " & venta.CLIENTE.APELLIDOS
                                        If venta.CREDITO Then
                                            frmVenta.rdCredito.Checked = True
                                        Else
                                            frmVenta.rdContado.Checked = True
                                        End If
                                    Else
                                        frmVenta.rdContado.Checked = True
                                        frmVenta.txtIdCliente.Text = ""
                                        frmVenta.txtNombreCliente.Text = venta.CLIENTECONTADO
                                    End If
                                    If venta.TIPODESCUENTO = "POR PRODUCTO" Then
                                        frmVenta.rdDescuentoPorProducto.Checked = True
                                    ElseIf venta.TIPODESCUENTO = "POR FACTURA" Then
                                        frmVenta.rdDescuentoPorFactura.Checked = True
                                    Else
                                        frmVenta.rdSindescuento.Checked = True
                                    End If
                                    Dim item As LST_DETALLE_VENTA
                                    frmVenta.detalles.RemoveAll(Function(f) True)
                                    For Each detalle In venta.VentasDetalles
                                        item = New LST_DETALLE_VENTA()
                                        item.IDEXISTENCIA = detalle.IDEXISTENCIA
                                        item.IDALTERNO = detalle.Existencia.Producto.IDALTERNO
                                        item.DESCRIPCION = detalle.Existencia.Producto.DESCRIPCION
                                        item.IVA = detalle.Existencia.Producto.IVA
                                        item.MARCA = If(detalle.Existencia.Producto.Marca.ACTIVO.Equals("S"), detalle.Existencia.Producto.Marca.DESCRIPCION, "")
                                        item.UNIDAD_DE_MEDIDA = If(detalle.Existencia.Producto.UnidadMedida.ACTIVO.Equals("S"), detalle.Existencia.Producto.UnidadMedida.DESCRIPCION, "")
                                        item.PRESENTACION = If(detalle.Existencia.Producto.Presentacion.ACTIVO.Equals("S"), detalle.Existencia.Producto.Presentacion.DESCRIPCION, "")
                                        item.EXISTENCIA = detalle.EXISTENCIA_PRODUCTO
                                        item.CANTIDAD = detalle.CANTIDAD
                                        item.PRECIOUNITARIO_C = detalle.PRECIOUNITARIO_C : item.PRECIOUNITARIO_D = detalle.PRECIOUNITARIO_D
                                        item.DESCUENTO_POR = detalle.DESCUENTO_POR
                                        item.DESCUENTO_DIN_C = detalle.DESCUENTO_DIN_C : item.DESCUENTO_DIN_D = detalle.DESCUENTO_DIN_D
                                        item.DESCUENTO_DIN_TOTAL_C = detalle.DESCUENTO_DIN_TOTAL_C : item.DESCUENTO_DIN_TOTAL_D = detalle.DESCUENTO_DIN_TOTAL_D
                                        item.PRECIONETO_C = detalle.PRECIONETO_C : item.PRECIONETO_D = detalle.PRECIONETO_D
                                        item.SUBTOTAL_C = detalle.SUBTOTAL_C : item.SUBTOTAL_D = detalle.SUBTOTAL_D
                                        item.IVA_POR = detalle.IVA_POR
                                        item.IVA_DIN_C = detalle.IVA_DIN_C : item.IVA_DIN_D = detalle.IVA_DIN_D
                                        item.IVA_DIN_TOTAL_C = detalle.IVA_DIN_TOTAL_C : item.IVA_DIN_TOTAL_D = detalle.IVA_DIN_TOTAL_D
                                        item.TOTAL_C = detalle.TOTAL_C : item.TOTAL_D = detalle.TOTAL_D
                                        frmVenta.detalles.Add(item)
                                        item = Nothing
                                    Next
                                    frmVenta.Grid()
                                    frmVenta.lblContador.Text = "N° ITEM: " & frmVenta.dtRegistro.Rows.Count.ToString()
                                    frmVenta.btGuardar.Enabled = False
                                    frmVenta.btAnular.Enabled = True
                                    frmVenta.btImprimir.Enabled = True
                                    Me.Close()
                            End Select
                        Else
                            MessageBox.Show("Esta 'Venta' esta anulado")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra esta 'Venta' o ha sido eliminada")
                    End If
                    idventa = Nothing : venta = Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbSerie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerie.SelectedIndexChanged
        If Not cmbSerie.SelectedValue Is Nothing And Not cmbSerie.SelectedIndex = -1 Then
            llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
        End If
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
        Else
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
        Else
            llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
        End If
    End Sub

    Private Sub rdContado_CheckedChanged(sender As Object, e As EventArgs) Handles rdContado.CheckedChanged
        If rdContado.Checked Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
            End If
        End If
    End Sub

    Private Sub rdCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdCredito.CheckedChanged
        If rdCredito.Checked Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
            End If
        End If
    End Sub

    Private Sub rdTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodos.CheckedChanged
        If rdTodos.Checked Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
            End If
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCliente.KeyDown
        If e.KeyData = Keys.Enter Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
            End If
        End If
    End Sub

    Private Sub txtNombreCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreCliente.KeyDown
        If e.KeyData = Keys.Enter Then
            If Not cmbSerie.SelectedValue Is Nothing And cmbSerie.SelectedIndex <> -1 Then
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), cmbSerie.SelectedValue.ToString(), txtCodigoCliente.Text, txtNombreCliente.Text)
            Else
                llenar(DateTime.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), DateTime.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"), , txtCodigoCliente.Text, txtNombreCliente.Text)
            End If
        End If
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmBVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.B
                    btBuscar_Click(Nothing, Nothing)
                Case Keys.Delete
                    btLimpiar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub
End Class