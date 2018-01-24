Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmInformeConsignacionProducto
    Sub llenar(ByVal idbodega As String, Optional ByVal idcliente As String = "", Optional ByVal alterno As String = "", Optional ByVal original As String = "", Optional ByVal producto As String = "")
        Try
            Using db As New CodeFirst
                Dim consulta = From cli In db.Clientes Join con In db.Consignaciones On cli.IDCLIENTE Equals con.IDCLIENTE Join ser In db.Series On con.IDSERIE Equals ser.IDSERIE Join bod In db.Bodegas On ser.IDBODEGA Equals bod.IDBODEGA Join det In db.ConsignacionesDetalles On con.IDCONSIGNACION Equals det.IDCONSIGNACION Join exi In db.Existencias On exi.IDEXISTENCIA Equals det.IDEXISTENCIA Join pro In db.Productos On pro.IDPRODUCTO Equals exi.IDPRODUCTO Join mar In db.Marcas On mar.IDMARCA Equals pro.IDMARCA Where bod.IDBODEGA = idbodega And cli.IDCLIENTE.Contains(idcliente) And pro.IDALTERNO.Contains(alterno) And pro.IDORIGINAL.Contains(original) And pro.DESCRIPCION.Contains(producto) Group By CODCLIENTE = cli.IDCLIENTE, cli.N_CLIENTE, CLIENTE = cli.NOMBRES & " " & cli.APELLIDOS, cli.RAZONSOCIAL, MARCA = mar.DESCRIPCION, pro.IDPRODUCTO, pro.IDALTERNO, pro.IDORIGINAL, pro.DESCRIPCION, UNIDAD = pro.UnidadMedida.DESCRIPCION Into CONSIGNADO = Sum(det.CANTIDAD) Order By CONSIGNADO Ascending Select CODCLIENTE, N_CLIENTE, CLIENTE, RAZONSOCIAL, MARCA, IDPRODUCTO, IDALTERNO, IDORIGINAL, DESCRIPCION, UNIDAD, CONSIGNADO
                Dim informeconsignaciones As New List(Of INFORMECONSIGNACION)
                Dim consig As INFORMECONSIGNACION
                Using db2 As New CodeFirst
                    For Each c In consulta
                        consig = New INFORMECONSIGNACION()
                        consig.IDCLIENTE = c.CODCLIENTE : consig.N_CLIENTE = c.N_CLIENTE : consig.NOMBRECLIENTE = c.CLIENTE : consig.MARCA = c.MARCA : consig.IDALTERNO = c.IDALTERNO : consig.IDORIGINAL = c.IDORIGINAL : consig.NOMBREPRODUCTO = c.DESCRIPCION : consig.UNIDAD_DE_MEDIDA = c.UNIDAD : consig.CONSIGNADO = c.CONSIGNADO
                        Dim desconsig = From des In db2.Desconsignaciones Join det In db2.DesconsignacionesDetalles On des.IDDESCONSIGNACION Equals det.IDDESCONSIGNACION Where des.ANULADO = "N" And des.IDCLIENTE = c.CODCLIENTE And det.Existencia.IDPRODUCTO = c.IDPRODUCTO Select det.CANTIDAD
                        If Not desconsig Is Nothing Then
                            If desconsig.Count() > 0 Then
                                consig.CONSIGNADO = c.CONSIGNADO - desconsig.Sum()
                            End If
                        End If
                        If consig.CONSIGNADO > 0 Then
                            informeconsignaciones.Add(consig)
                        End If
                        'destruir
                        desconsig = Nothing
                        consig = Nothing
                    Next
                    If informeconsignaciones.Count > 0 Then
                        Dim rpt As New rptInformeConsignado
                        rpt.SetDataSource(informeconsignaciones)
                        CrystalReportViewer1.ReportSource = rpt
                        rpt = Nothing
                    Else
                        MessageBox.Show("No se encontraron registros con estos parámetros.")
                    End If
                End Using
                consulta = Nothing
                informeconsignaciones = Nothing
            End Using

        Catch ex As Exception
            MessageBox.Show("Error," & ex.Message)
        End Try
    End Sub

    Private Sub frmInformeConsignacionFiltrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.Bodegas Where bod.ACTIVO = "S" Select bod.IDBODEGA, BODEGA = bod.N_BODEGA & " | " & bod.DESCRIPCION).ToList() : cmbBodega.DisplayMember = "BODEGA" : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
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
                            txtAlterno.Focus()
                        Else
                            MessageBox.Show("Error, No se encuentra este cliente.")
                            frmBuscarClientes.txtCodigo.Text = txtNCliente.Text
                            frmBuscarClientes.frm_return = 12 'retornar el valor aqui
                            frmBuscarClientes.ShowDialog()
                            If Not txtIdCliente.Text.Trim = "" Then
                                txtNCliente.Clear()
                                txtAlterno.Focus()
                            End If
                        End If
                        cliente = Nothing
                    Else
                        txtNCliente.Clear()
                        frmBuscarClientes.frm_return = 12 'retornar el valor aqui
                        frmBuscarClientes.ShowDialog()
                        If Not txtIdCliente.Text.Trim = "" Then
                            txtNCliente.Clear()
                            txtAlterno.Focus()
                        End If
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btBuscarCliente_Click(sender As Object, e As EventArgs) Handles btBuscarCliente.Click
        frmBuscarClientes.frm_return = 12
        frmBuscarClientes.ShowDialog()
        If Not txtIdCliente.Text.Trim() = "" Then
            txtAlterno.Focus()
        Else
            txtNCliente.Focus()
        End If
    End Sub

    Private Sub txtAlterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlterno.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtOriginal.Focus()
        End If
    End Sub

    Private Sub btAlterno_Click(sender As Object, e As EventArgs) Handles btAlterno.Click
        frmBuscarProductos.frm_return = 12 'retornar el valor aqui
        frmBuscarProductos.ShowDialog()
        If Not txtAlterno.Text.Trim = "" Then
            txtOriginal.Focus()
        End If
    End Sub

    Private Sub txtOriginal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOriginal.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub btOriginal_Click(sender As Object, e As EventArgs) Handles btOriginal.Click
        frmBuscarProductos.frm_return = 13 'retornar el valor aqui
        frmBuscarProductos.ShowDialog()
        If Not txtOriginal.Text.Trim = "" Then
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(13) Then
            btMostrar.Focus()
        End If
    End Sub

    Private Sub btDescripcion_Click(sender As Object, e As EventArgs) Handles btDescripcion.Click
        frmBuscarProductos.frm_return = 14 'retornar el valor aqui
        frmBuscarProductos.ShowDialog()
        If Not txtDescripcion.Text.Trim = "" Then
            btMostrar.Focus()
        End If
    End Sub

    Private Sub btMostrar_Click(sender As Object, e As EventArgs) Handles btMostrar.Click
        If Not cmbBodega.SelectedValue Is Nothing Then
            If Not cmbBodega.SelectedIndex = -1 Then
                llenar(cmbBodega.SelectedValue.ToString, txtIdCliente.Text, txtAlterno.Text.Trim, txtOriginal.Text.Trim, txtDescripcion.Text.Trim)
                txtNCliente.Focus()
            Else
                MessageBox.Show("Debe seleccionar la sucursal.")
            End If
        Else
            MessageBox.Show("Debe seleccionar la sucursal.")
        End If
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        txtNCliente.Focus()
    End Sub

    Private Sub frmInformeConsignacionProducto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class