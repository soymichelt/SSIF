Public Class frmBuscarCotizacion
    Dim item As New ListViewItem
    Public idserie As String = ""
    Public frm_return As Integer = 0
    Dim idcotizacion As String

    Sub llenar(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, Optional ByVal idcliente As String = "", Optional ByVal cliente As String = "", Optional ByVal idtrabajador As String = "", Optional ByVal trabajador As String = "")
        Try
            lvRegistro.Items.Clear()
            Using db As New CodeFirst
                Dim consulta = (From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra).Union(From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE Is Nothing And ser.IDSERIE.Contains(idserie) Where cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 Select cot, ser, idclie = "", clie = cot.CLIENTECONTADO, tra)
                If Not cliente.Trim() = "" And Not trabajador.Trim() = "" Then
                    consulta = (From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And (cli.NOMBRES & " " & cli.APELLIDOS).Contains(cliente) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(trabajador) Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra).Union(From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE Is Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And cot.CLIENTECONTADO.Contains(cliente) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(trabajador) Select cot, ser, idclie = "", clie = cot.CLIENTECONTADO, tra)
                ElseIf Not cliente.Trim() = "" Then
                    consulta = (From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And (cli.NOMBRES & " " & cli.APELLIDOS).Contains(cliente) Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra).Union(From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE Is Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And cot.CLIENTECONTADO.Contains(cliente) Select cot, ser, idclie = "", clie = cot.CLIENTECONTADO, tra)
                ElseIf Not trabajador.Trim() = "" Then
                    consulta = (From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(trabajador) Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra).Union(From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE Is Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(trabajador) Select cot, ser, idclie = "", clie = cot.CLIENTECONTADO, tra)
                ElseIf Not idcliente.Trim() = "" And Not idtrabajador.Trim() = "" Then
                    consulta = From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And cli.N_CLIENTE = idcliente And tra.N_TRABAJADOR = idtrabajador Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra
                ElseIf Not idcliente.Trim() = "" Then
                    consulta = From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And cli.N_CLIENTE = idcliente Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra
                ElseIf Not idtrabajador.Trim() = "" Then
                    consulta = (From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And tra.N_TRABAJADOR = idtrabajador Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra).Union(From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE Is Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And tra.N_TRABAJADOR = idtrabajador Select cot, ser, idclie = "", clie = cot.CLIENTECONTADO, tra)
                ElseIf Not idcliente.Trim() = "" And Not trabajador.Trim() = "" Then
                    consulta = From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And cli.N_CLIENTE = idcliente And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(trabajador) Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra
                ElseIf Not cliente.Trim() = "" And Not idtrabajador.Trim() = "" Then
                    consulta = (From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join cli In db.CLIENTES On cli.IDCLIENTE Equals cot.IDCLIENTE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE IsNot Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And (cli.NOMBRES & " " & cli.APELLIDOS).Contains(cliente) And tra.N_TRABAJADOR = idtrabajador Select cot, ser, idclie = cli.N_CLIENTE, clie = cli.NOMBRES & " " & cli.APELLIDOS, tra).Union(From cot In db.COTIZACIONES Join ser In db.SERIES On ser.IDSERIE Equals cot.IDSERIE Join tra In db.EMPLEADOS On tra.IDEMPLEADO Equals cot.IDEMPLEADO Where cot.IDCLIENTE Is Nothing And ser.IDSERIE.Contains(idserie) And cot.FECHACOTIZACION >= fecha1 And cot.FECHACOTIZACION <= fecha2 And cot.CLIENTECONTADO.Contains(cliente) And tra.N_TRABAJADOR = idtrabajador Select cot, ser, idclie = "", clie = cot.CLIENTECONTADO, tra)
                End If
                For Each venta In consulta.OrderBy(Function(f) f.cot.FECHACOTIZACION)
                    item = lvRegistro.Items.Add(venta.cot.IDCOTIZACION)
                    item.SubItems.Add(venta.ser.NOMBRE)
                    item.SubItems.Add(venta.cot.CONSECUTIVO)
                    item.SubItems.Add(venta.cot.FECHACOTIZACION.ToString())
                    If Not venta.idclie = "" Then
                        item.SubItems.Add(venta.idclie & "|" & venta.clie)
                    Else
                        item.SubItems.Add(venta.clie)
                    End If
                    item.SubItems.Add(venta.tra.N_TRABAJADOR & "|" & venta.tra.NOMBRES & " " & venta.tra.APELLIDOS)
                    If venta.cot.CREDITO Then
                        item.SubItems.Add("S")
                        item.SubItems.Add(DateTime.Parse(venta.cot.FECHACREDITOVENCIMIENTO).ToString(Config.formato_fecha))
                    Else
                        item.SubItems.Add("N")
                        item.SubItems.Add("")
                    End If
                    item.SubItems.Add(venta.cot.DESCUENTO_DIN_C.ToString(Config.f_m))
                    item.SubItems.Add(venta.cot.SUBTOTAL_C.ToString(Config.f_m))
                    item.SubItems.Add(venta.cot.IVA_DIN_C.ToString(Config.f_m))
                    item.SubItems.Add(venta.cot.TOTAL_C.ToString(Config.f_m))
                Next
                item = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
    
    Private Sub frmBuscarCotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            llenar(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub lvRegistro_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRegistro.DoubleClick
        'If lvRegistro.SelectedRows.Count > 0 Then
        '    Try
        '        Using db As New MODELODEDATOS
        '            Dim idventa As String = dtRegistro.SelectedRows(0).Cells(1).Value.ToString() : Dim venta = db.VENTAS.Where(Function(f) f.IDVENTA = idventa).FirstOrDefault()
        '            If Not venta Is Nothing Then
        '                If venta.ANULADO = "N" Then
        '                    Select Case frm_return
        '                        Case 0
        '                            frmCotizacion.txtIdSerie.Text = venta.SERIE.IDSERIE
        '                            frmCotizacion.txtSerie.Text = venta.SERIE.NOMBRE
        '                            frmCotizacion.txtReferencia.Text = venta.SERIE.DESCRIPCION
        '                            frmCotizacion.idfactura = venta.IDVENTA
        '                            frmCotizacion.txtCodigo.Text = venta.CONSECUTIVO
        '                            frmCotizacion.txtCodigo.Enabled = False
        '                            frmCotizacion.dtpFecha.Text = venta.FECHAFACTURA.ToShortDateString()
        '                            frmCompra.chkExonerado.Checked = venta.EXONERADO
        '                            frmCotizacion.txtIdVendedor.Text = venta.TRABAJADOR.IDTRABAJADOR
        '                            frmCotizacion.txtNombreVendedor.Text = venta.TRABAJADOR.N_TRABAJADOR & " | " & venta.TRABAJADOR.NOMBRES & " " & venta.TRABAJADOR.APELLIDOS
        '                            If Not venta.IDCLIENTE Is Nothing Then
        '                                frmCotizacion.txtIdCliente.Text = venta.CLIENTE.IDCLIENTE
        '                                frmCotizacion.txtNombreCliente.Text = venta.CLIENTE.N_CLIENTE & " | " & venta.CLIENTE.NOMBRES & " " & venta.CLIENTE.APELLIDOS
        '                                If venta.CREDITO Then
        '                                    frmCotizacion.rdCredito.Checked = True
        '                                Else
        '                                    frmCotizacion.rdContado.Checked = True
        '                                End If
        '                            Else
        '                                frmCotizacion.rdContado.Checked = True
        '                                frmCotizacion.txtIdCliente.Text = ""
        '                                frmCotizacion.txtNombreCliente.Text = venta.CLIENTECONTADO
        '                            End If
        '                            If venta.TIPODESCUENTO = "POR PRODUCTO" Then
        '                                frmCotizacion.rdDescuentoPorProducto.Checked = True
        '                            ElseIf venta.TIPODESCUENTO = "POR FACTURA" Then
        '                                frmCotizacion.rdDescuentoPorFactura.Checked = True
        '                            Else
        '                                frmCotizacion.rdSindescuento.Checked = True
        '                            End If
        '                            Dim item As LST_DETALLE_VENTA
        '                            frmCotizacion.detalles.RemoveAll(Function(f) True)
        '                            For Each detalle In venta.DETALLES_VENTAS
        '                                item = New LST_DETALLE_VENTA()
        '                                item.IDEXISTENCIA = detalle.IDEXISTENCIA
        '                                item.IDALTERNO = detalle.EXISTENCIA.PRODUCTO.IDALTERNO
        '                                item.DESCRIPCION = detalle.EXISTENCIA.PRODUCTO.DESCRIPCION
        '                                item.IVA = detalle.EXISTENCIA.PRODUCTO.IVA
        '                                item.MARCA = If(detalle.EXISTENCIA.PRODUCTO.MARCA.ACTIVO.Equals("S"), detalle.EXISTENCIA.PRODUCTO.MARCA.DESCRIPCION, "")
        '                                item.UNIDAD_DE_MEDIDA = If(detalle.EXISTENCIA.PRODUCTO.UNIDAD_DE_MEDIDA.ACTIVO.Equals("S"), detalle.EXISTENCIA.PRODUCTO.UNIDAD_DE_MEDIDA.DESCRIPCION, "")
        '                                item.PRESENTACION = If(detalle.EXISTENCIA.PRODUCTO.PRESENTACION.ACTIVO.Equals("S"), detalle.EXISTENCIA.PRODUCTO.PRESENTACION.DESCRIPCION, "")
        '                                item.EXISTENCIA = detalle.EXISTENCIA_PRODUCTO
        '                                item.CANTIDAD = detalle.CANTIDAD
        '                                item.PRECIOUNITARIO = detalle.PRECIOUNITARIO
        '                                item.DESCUENTO_POR = detalle.DESCUENTO_POR
        '                                item.DESCUENTO_DIN = detalle.DESCUENTO_DIN
        '                                item.DESCUENTO_DIN_TOTAL = detalle.DESCUENTO_DIN_TOTAL
        '                                item.PRECIONETO = detalle.PRECIONETO
        '                                item.SUBTOTAL = detalle.SUBTOTAL
        '                                item.IVA_POR = detalle.IVA_POR
        '                                item.IVA_DIN = detalle.IVA_DIN
        '                                item.IVA_DIN_TOTAL = detalle.IVA_DIN_TOTAL
        '                                item.TOTAL = detalle.TOTAL
        '                                frmCotizacion.detalles.Add(item)
        '                                item = Nothing
        '                            Next
        '                            frmCotizacion.Grid()
        '                            frmCotizacion.txtTotalDescuento.Value = venta.DESCUENTO_DIN
        '                            frmCotizacion.txtTotalSubtotal.Value = venta.SUBTOTAL
        '                            frmCotizacion.txtIva.Value = venta.IVA_DIN
        '                            frmCotizacion.txtTotal.Value = venta.TOTAL
        '                            frmCotizacion.lblContador.Text = "N° ITEM: " & frmCotizacion.dtRegistro.Rows.Count.ToString()
        '                            frmCotizacion.btGuardar.Enabled = False
        '                            frmCotizacion.btImprimir.Enabled = True
        '                            Me.Close()
        '                    End Select
        '                Else
        '                    MessageBox.Show("Esta 'Venta' esta anulado")
        '                End If
        '            Else
        '                MessageBox.Show("Error, No se encuentra esta 'Venta' o ha sido eliminada")
        '            End If
        '            idventa = Nothing : venta = Nothing
        '        End Using
        '    Catch ex As Exception
        '        MessageBox.Show("Error, " & ex.Message)
        '    End Try
        'End If
    End Sub

    Private Sub frmBuscarCotizacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub lvRegistro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            lvRegistro_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", txtIdCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtIdTrabajador.Text.Trim(), txtNombreTrabajador.Text.Trim())
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", txtIdCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtIdTrabajador.Text.Trim(), txtNombreTrabajador.Text.Trim())
    End Sub

    Private Sub txtIdCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", txtIdCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtIdTrabajador.Text.Trim(), txtNombreTrabajador.Text.Trim())
        End If
    End Sub

    Private Sub txtNombreCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", txtIdCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtIdTrabajador.Text.Trim(), txtNombreTrabajador.Text.Trim())
        End If
    End Sub

    Private Sub txtIdTrabajador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdTrabajador.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", txtIdCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtIdTrabajador.Text.Trim(), txtNombreTrabajador.Text.Trim())
        End If
    End Sub

    Private Sub txtNombreTrabajador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreTrabajador.KeyPress
        If e.KeyChar = ChrW(13) Then
            llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59", txtIdCliente.Text.Trim(), txtNombreCliente.Text.Trim(), txtIdTrabajador.Text.Trim(), txtNombreTrabajador.Text.Trim())
        End If
    End Sub

    Private Sub btBuscarCliente_Click(sender As Object, e As EventArgs) Handles btBuscarCliente.Click
        frmBuscarClientes.frm_return = 4
        frmBuscarClientes.ShowDialog()
        If rdIdCliente.Checked Then
            txtIdCliente.Focus()
        ElseIf rdNombreCliente.Checked Then
            txtNombreCliente.Focus()
        End If
    End Sub

    Private Sub btBuscarTrabajador_Click(sender As Object, e As EventArgs) Handles btBuscarTrabajador.Click
        frmBuscarEmpleado.frm_return = 4
        frmBuscarEmpleado.ShowDialog()
        If rdIdTrabajador.Checked Then
            txtIdTrabajador.Focus()
        ElseIf rdNombreTrabajador.Checked Then
            txtNombreTrabajador.Focus()
        End If
    End Sub

    Private Sub rdIdCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rdIdCliente.CheckedChanged
        If rdIdCliente.Checked Then
            txtNombreCliente.Enabled = False
            txtNombreCliente.Clear()
            txtIdCliente.Enabled = True
            txtIdCliente.Focus()
        End If
    End Sub

    Private Sub rdNombreCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rdNombreCliente.CheckedChanged
        If rdNombreCliente.Checked Then
            txtIdCliente.Enabled = False
            txtIdCliente.Clear()
            txtNombreCliente.Enabled = True
            txtNombreCliente.Focus()
        End If
    End Sub

    Private Sub rdIdTrabajador_CheckedChanged(sender As Object, e As EventArgs) Handles rdIdTrabajador.CheckedChanged
        If rdIdTrabajador.Checked Then
            txtNombreTrabajador.Enabled = False
            txtNombreTrabajador.Clear()
            txtIdTrabajador.Enabled = True
            txtIdTrabajador.Focus()
        End If
    End Sub

    Private Sub rdNombreTrabajador_CheckedChanged(sender As Object, e As EventArgs) Handles rdNombreTrabajador.CheckedChanged
        If rdNombreTrabajador.Checked Then
            txtIdTrabajador.Enabled = False
            txtIdTrabajador.Clear()
            txtNombreTrabajador.Enabled = True
            txtNombreTrabajador.Focus()
        End If
    End Sub
End Class