Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmBuscarDesconsignacion

    Public idserie As String = ""

    Sub llenar(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, Optional ByVal idcliente As String = "", Optional ByVal cliente As String = "", Optional ByVal idvendedor As String = "", Optional ByVal vendedor As String = "")
        Try
            Using db As New CodeFirst
                lvRegistro.Items.Clear()
                Dim item As New ListViewItem
                Dim consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                If Not idcliente.Trim() = "" And Not idvendedor.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where cli.N_CLIENTE.Contains(idcliente) And tra.N_TRABAJADOR.Contains(idvendedor) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                ElseIf Not idcliente.Trim() = "" And Not vendedor.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where cli.N_CLIENTE.Contains(idcliente) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(vendedor) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                ElseIf Not cliente.Trim() = "" And Not idvendedor.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where (cli.NOMBRES & " " & cli.APELLIDOS).Contains(cliente) And tra.N_TRABAJADOR.Contains(idvendedor) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                ElseIf Not cliente.Trim() = "" And Not vendedor.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where (cli.NOMBRES & " " & cli.APELLIDOS).Contains(cliente) And (tra.NOMBRES & " " & tra.APELLIDOS).Contains(vendedor) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                ElseIf Not idcliente.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where cli.N_CLIENTE.Contains(idcliente) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                ElseIf Not cliente.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where (cli.NOMBRES & " " & cli.APELLIDOS).Contains(cliente) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                ElseIf Not idvendedor.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where tra.N_TRABAJADOR.Contains(idvendedor) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                ElseIf Not vendedor.Trim() = "" Then
                    consulta = From descon In db.Desconsignaciones Join ser In db.Series On descon.IDSERIE Equals ser.IDSERIE Join cli In db.Clientes On cli.IDCLIENTE Equals descon.IDCLIENTE Join tra In db.Empleados On tra.IDEMPLEADO Equals descon.IDEMPLEADO Where descon.ANULADO = "N" And descon.IDSERIE = Me.idserie And descon.FECHACONSIGNACION >= fecha1 And descon.FECHACONSIGNACION <= fecha2 Where (tra.NOMBRES & " " & tra.APELLIDOS).Contains(vendedor) Select ser, descon, cli, tra Order By descon.FECHACONSIGNACION
                End If
                For Each desconsignacion In consulta
                    item = lvRegistro.Items.Add(desconsignacion.descon.IDDESCONSIGNACION)
                    item.SubItems.Add(desconsignacion.ser.NOMBRE)
                    item.SubItems.Add(desconsignacion.descon.CONSECUTIVO)
                    item.SubItems.Add(desconsignacion.descon.FECHACONSIGNACION.ToShortDateString())
                    item.SubItems.Add(desconsignacion.cli.N_CLIENTE & " | " & desconsignacion.cli.NOMBRES & " " & desconsignacion.cli.APELLIDOS)
                    item.SubItems.Add(desconsignacion.tra.N_TRABAJADOR & " | " & desconsignacion.tra.NOMBRES & " " & desconsignacion.tra.APELLIDOS)
                    item.SubItems.Add(desconsignacion.descon.OBSERVACION)
                    item.SubItems.Add(desconsignacion.descon.TOTAL.ToString(Config.f_m))
                Next
                item = Nothing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub
    Private Sub frmBuscarDesconsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar(DateTime.Now.ToShortDateString() & " 00:00:00", DateTime.Now.ToShortDateString() & " 23:59:59")
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59")
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        llenar(dtpFechaInicial.Text & " 00:00:00", dtpFechaFinal.Text & " 23:59:59")
    End Sub

    Private Sub lvRegistro_DoubleClick(sender As Object, e As EventArgs) Handles lvRegistro.DoubleClick
        If lvRegistro.SelectedItems.Count > 0 Then
            Try
                Using db As New CodeFirst
                    Dim iddesconsignacion As String = lvRegistro.SelectedItems(0).Text
                    Dim desconsignacion = db.Desconsignaciones.Where(Function(f) f.IDDESCONSIGNACION = iddesconsignacion).FirstOrDefault()
                    If Not desconsignacion Is Nothing Then
                        If desconsignacion.ANULADO = "N" Then
                            frmDesconsignacion.txtCodigo.Text = desconsignacion.CONSECUTIVO
                            frmDesconsignacion.dtpFecha.Text = desconsignacion.FECHACONSIGNACION.ToShortDateString()
                            frmDesconsignacion.txtIdVendedor.Text = desconsignacion.Empleado.IDEMPLEADO
                            frmDesconsignacion.txtNombreVendedor.Text = desconsignacion.Empleado.N_TRABAJADOR & " | " & desconsignacion.Empleado.NOMBRES & " " & desconsignacion.Empleado.APELLIDOS
                            frmDesconsignacion.txtIdCliente.Text = desconsignacion.Cliente.IDCLIENTE
                            frmDesconsignacion.txtNombreCliente.Text = desconsignacion.Cliente.N_CLIENTE & " | " & desconsignacion.Cliente.NOMBRES & " " & desconsignacion.Cliente.APELLIDOS
                            frmDesconsignacion.txtConcepto.Text = desconsignacion.OBSERVACION
                            Dim item As New ListViewItem
                            frmDesconsignacion.lvRegistro.Items.Clear()
                            For Each detalle In desconsignacion.DesconsignacionesDetalles
                                item = frmDesconsignacion.lvRegistro.Items.Add(detalle.IDEXISTENCIA)
                                item.SubItems.Add(detalle.Existencia.Producto.IDALTERNO)
                                item.SubItems.Add(detalle.Existencia.Producto.DESCRIPCION)
                                item.SubItems.Add(detalle.EXISTENCIA_PRODUCTO.ToString(Config.f_m))
                                item.SubItems.Add((detalle.EXISTENCIA_PRODUCTO - detalle.EXISTENCIA_CONSIGNADA).ToString(Config.f_m))
                                item.SubItems.Add(detalle.EXISTENCIA_CONSIGNADA.ToString(Config.f_m))
                                item.SubItems.Add(detalle.CANTIDAD.ToString(Config.f_m))
                            Next
                            item = Nothing
                            frmDesconsignacion.txtTotal.Text = desconsignacion.TOTAL.ToString(Config.f_m)
                            frmDesconsignacion.lblContador.Text = "N° ITEM: " & lvRegistro.Items.Count.ToString()
                            frmConsignacion.txtCodigo.Enabled = False
                            frmDesconsignacion.btGuardar.Enabled = False

                            Me.Close()
                        Else
                            MessageBox.Show("Esta entrada esta anulada")
                        End If
                    Else
                        MessageBox.Show("Error, No se encuentra esta entrada o ha sido eliminada")
                    End If
                    iddesconsignacion = Nothing
                    desconsignacion = Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub frmBuscarDesconsignacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
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

    Private Sub btBuscarCliente_Click(sender As Object, e As EventArgs) Handles btBuscarCliente.Click
        frmBuscarClientes.frm_return = 6
        frmBuscarClientes.ShowDialog()
        If rdIdCliente.Checked Then
            txtIdCliente.Focus()
        ElseIf rdNombreCliente.Checked Then
            txtNombreCliente.Focus()
        End If
    End Sub

    Private Sub btBuscarTrabajador_Click(sender As Object, e As EventArgs) Handles btBuscarTrabajador.Click
        frmBuscarEmpleado.frm_return = 6
        frmBuscarEmpleado.ShowDialog()
        If rdIdTrabajador.Checked Then
            txtIdTrabajador.Focus()
        ElseIf rdNombreTrabajador.Checked Then
            txtNombreTrabajador.Focus()
        End If
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
End Class