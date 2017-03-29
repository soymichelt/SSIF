Public Class frmPrincipal
    'fin definicio de variables
    Dim salir As Boolean = False
    Public forzarcierre As Boolean = False
    'validar permisos de usuario
    Sub cargarPrivilegios()
        Try
            If Not Config.Empresa Is Nothing Then
                Config.NombreEmpresa = Config.Empresa.Nombre
                Config.RUC = Config.Empresa.RUC
                Config.Telefono1 = Config.Empresa.Telefono1
                Config.Telefono2 = Config.Empresa.Telefono2
                Config.Direccion = Config.Empresa.Direccion
                If Config.Usuario.Administrador Then
                    btUsuarios.Enabled = True
                    btEmpresa.Enabled = True
                    btBodega.Enabled = True
                    btSerie.Enabled = True
                    btIva.Enabled = True
                    btTaza.Enabled = True
                    btRestaurar.Enabled = True
                    btCrearRespaldo.Enabled = True
                    btServidor.Enabled = True
                End If
                If Config.Usuario.CAdministrador Then
                    btInformeUsuarios.Enabled = True
                    btBitacora.Enabled = True
                End If
                If Config.Usuario.Inventario Then
                    btMarcas.Enabled = True
                    btUnidadMedida.Enabled = True
                    btPresentacion.Enabled = True
                    btLaboratorio.Enabled = True
                    btCuentasCobrar.Enabled = True
                    btCuentasPagar.Enabled = True
                    btProductos.Enabled = True
                    btBusquedaProductos.Enabled = True
                    btControlExistencia.Enabled = True
                    btEntradas.Enabled = True
                    btSalidas.Enabled = True
                    btTraslados.Enabled = True
                    btConsignar.Enabled = True
                    btDesconsignar.Enabled = True
                End If
                If Config.Usuario.CInventario Then
                    btKardex.Enabled = True
                    btValuacionInventario.Enabled = True
                    btBusquedaEntradas.Enabled = True
                    btBusquedaSalida.Enabled = True
                    btBusquedaTraslado.Enabled = True
                    btBusquedaConsignacion.Enabled = True
                    btBusquedaDesconsignacion.Enabled = True
                    btReporteConsignacion.Enabled = True
                End If
                If Config.Usuario.Venta Then
                    btVendedores.Enabled = True
                    btBusquedaVendedor.Enabled = True
                    btVenta.Enabled = True
                    btDevolucionesVentas.Enabled = True
                    btCotizar.Enabled = True
                    btClientes.Enabled = True
                    btBusquedaClientes.Enabled = True
                End If
                If Config.Usuario.CVenta Then
                    btBusquedaFactura.Enabled = True
                    btBusquedaDevolucion.Enabled = True
                    btBusquedaCotizacion.Enabled = True
                    btInformeVentaDetalle.Enabled = True
                    btEstadoCuenta.Enabled = True
                End If
                If Config.Usuario.Contabilidad Then
                    btReciboVenta.Enabled = True
                    btReciboCompra.Enabled = True
                    btPeriodoContable.Enabled = True
                    btSeleccionar.Enabled = True
                    btApertura.Enabled = True
                    btCierre.Enabled = True
                End If
                If Config.Usuario.CContabilidad Then
                    btCuentasCobrar.Enabled = True
                    btCuentasPagar.Enabled = True
                    btBusquedaRecibo.Enabled = True
                    btCCEstadoCuenta.Enabled = True
                    btCompraEstadoCuenta.Enabled = True
                    btCPEstadoCuenta.Enabled = True
                    btBusquedaReciboCompra.Enabled = True
                    btEstadoResultados.Enabled = True
                End If
                If Config.Usuario.Compra Then
                    btProveedores.Enabled = True
                    btBusquedaProveedores.Enabled = True
                    btCompra.Enabled = True
                End If
                If Config.Usuario.CCompra Then
                    btBusquedaCompra.Enabled = True
                    btDevolucionCompra.Enabled = True
                    btCPEstadoCuenta.Enabled = True
                    btBusquedaDevolucionesCompras.Enabled = True
                    btProductosComprados.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Public Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            rcCintaMenu.SelectedRibbonTabItem = mnuCatalogos
            txtBodega.Text = Config.nom_bodega
            lblNombreUsuario.Text = "Nombres: " & Config.Usuario.Nombres & " " & Config.Usuario.Apellidos
            lblUsuario.Text = "Usuario: " & Config.Usuario.NombreCuenta
            lblBodega.Text = "Sucursal: " & Config._Bodega.N_BODEGA & " - " & Config._Bodega.DESCRIPCION
            Using db As New CodeFirst
                'IVA
                Config._Iva = db.ImpuestosValoresAgregados.OrderByDescending(Function(f) f.FECHA).FirstOrDefault()
                If Not Config._Iva Is Nothing Then
                    Config.iva = Config._Iva.PORCENTAJE / 100
                Else
                    Config.iva = 0
                End If
                'Taza de Cambio
                Config._Taza = db.Tazas.OrderByDescending(Function(f) f.FECHA).FirstOrDefault()
                If Not Config._Taza Is Nothing Then
                    Config.tazadecambio = Config._Taza.CAMBIO
                Else
                    Config.tazadecambio = 0
                End If
                'Periodo Contable
                Config._Periodo = db.Periodos.Where(Function(f) f.ACTUAL.Equals("S") And f.ACTIVO.Equals("S") And f.APERTURA IsNot Nothing).FirstOrDefault()
                If Not Config._Periodo Is Nothing Then
                    txtInicio.Text = Config._Periodo.INICIO.ToShortDateString
                    txtFinal.Text = Config._Periodo.FINAL.ToShortDateString
                Else
                    txtInicio.Text = "S/E"
                    txtFinal.Text = "S/E"
                End If
                'Empresa
                Config.Empresa = db.Empresas.OrderBy(Function(f) f.N).ToList().LastOrDefault
                If Not Config.Empresa Is Nothing Then
                    Me.cargarPrivilegios()
                Else
                    If Config.Usuario.Administrador Then
                        btEmpresa.Enabled = True
                    End If
                End If
                lblIva.Text = "I.V.A: " & (Config.iva * 100).ToString(Config.f_m) & " %"
                lblTaza.Text = "Taza de Cambio: $ 1 = C$ " & (Config.tazadecambio).ToString(Config.f_m)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    'inicio llamadas a formularios
    Private Sub btBodega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSucursal.Click, btBodega.Click
        If Me.MdiChildren.Length = 0 Then
            frmBodega.ShowDialog()
        Else
            MessageBox.Show("Cierre las ventanas abiertas.")
        End If
    End Sub

    Private Sub btSerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSerie.Click
        If Me.MdiChildren.Length = 0 Then
            frmSerie.ShowDialog()
        Else
            MessageBox.Show("Cierre las ventanas abiertas.")
        End If
    End Sub

    Private Sub btMarcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMarcas.Click
        frmMarca.MdiParent = Me
        frmMarca.BringToFront()
        frmMarca.Show()
    End Sub

    Private Sub btProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProductos.Click
        frmProducto.MdiParent = Me
        frmProducto.BringToFront()
        frmProducto.Show()
    End Sub

    Private Sub btClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClientes.Click
        frmCliente.MdiParent = Me
        frmCliente.BringToFront()
        frmCliente.Show()
    End Sub

    Private Sub btVendedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVendedores.Click
        frmEmpleado.MdiParent = Me
        frmEmpleado.BringToFront()
        frmEmpleado.Show()
    End Sub

    Private Sub btProveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProveedores.Click
        frmProveedor.MdiParent = Me
        frmProveedor.BringToFront()
        frmProveedor.Show()
    End Sub

    Private Sub btVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVenta.Click
        frmVenta.MdiParent = Me
        frmVenta.BringToFront()
        frmVenta.Show()
    End Sub
    'fin llamadas a formularios

    Private Sub btTaza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTaza.Click
        If Me.MdiChildren.Length = 0 Then
            frmMoneda.ShowDialog()
            frmMoneda.Dispose()
        Else
            MessageBox.Show("Error, Para cambiar la taza de cambio debe cerrar todos las ventanas.")
        End If
    End Sub

    Private Sub btDevoluciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDevolucionesVentas.Click
        frmNotaDevolucion.MdiParent = Me
        frmNotaDevolucion.BringToFront()
        frmNotaDevolucion.Show()
    End Sub

    Private Sub btAnulaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCompra.Click
        frmCompra.MdiParent = Me
        frmCompra.BringToFront()
        frmCompra.Show()
    End Sub

    Private Sub btEntradas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEntradas.Click
        frmEntrada.MdiParent = Me
        frmEntrada.BringToFront()
        frmEntrada.Show()
    End Sub

    Private Sub btSalidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalidas.Click
        frmSalida.MdiParent = Me
        frmSalida.BringToFront()
        frmSalida.Show()
    End Sub

    Private Sub btTraslados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTraslados.Click
        frmTraslado.MdiParent = Me
        frmTraslado.BringToFront()
        frmTraslado.Show()
    End Sub

    Private Sub btInformeFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBusquedaFactura.Click
        frmInformeVentas.MdiParent = Me
        frmInformeVentas.BringToFront()
        frmInformeVentas.Show()
    End Sub

    Private Sub btVentasporVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btInformePorClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmInformeFacturaPorCliente.MdiParent = Me
        'frmInformeFacturaPorCliente.BringToFront()
        'frmInformeFacturaPorCliente.Show()
    End Sub

    Private Sub btInformacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmInformacion.ShowDialog()
    End Sub

    Private Sub btLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLogo.Click
        frmLogo.ShowDialog()
    End Sub

    Private Sub btCotizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCotizar.Click
        'frmCotizacion.MdiParent = Me
        'frmCotizacion.BringToFront()
        'frmCotizacion.Show()
        frmCotizacion.MdiParent = Me
        frmCotizacion.BringToFront()
        frmCotizacion.Show()
    End Sub


    Private Sub btKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btKardex.Click
        frmKardex.MdiParent = Me
        frmKardex.BringToFront()
        frmKardex.Show()
    End Sub

    Private Sub btUsuarios_Click(sender As Object, e As EventArgs) Handles btUsuarios.Click
        frmUser.MdiParent = Me
        frmUser.BringToFront()
        frmUser.Show()
    End Sub

    ''''''''''''''''''''''''''''''''
    'Declaración de la API
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    'Funcion de liberacion de memoria
    Private Sub tmTiempo_Tick(sender As Object, e As EventArgs) Handles tmLimpiarMemoria.Tick
        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)
        Catch ex As Exception
            MessageBox.Show("Error, Al intentar limpiar memoria del sistema. Descripcion: " & ex.Message)
        End Try
    End Sub

    Private Sub btInformeEntrada_Click(sender As Object, e As EventArgs) Handles btBusquedaEntradas.Click
        frmInformeEntrada.MdiParent = Me
        frmInformeEntrada.BringToFront()
        frmInformeEntrada.Show()
    End Sub

    Private Sub btInformeSalida_Click(sender As Object, e As EventArgs) Handles btBusquedaSalida.Click
        frmInformeSalida.MdiParent = Me
        frmInformeSalida.BringToFront()
        frmInformeSalida.Show()
    End Sub

    Private Sub btInformeTraslado_Click(sender As Object, e As EventArgs) Handles btBusquedaTraslado.Click
        frmInformeTraslado.MdiParent = Me
        frmInformeTraslado.BringToFront()
        frmInformeTraslado.Show()
    End Sub

    Private Sub btCargar_Click(sender As Object, e As EventArgs) Handles btCargar.Click
        If Me.MdiChildren.Length = 0 Then
            frmSeleccionarBodega.ShowDialog()
            txtBodega.Focus()
            txtBodega.SelectionLength = 0
        Else
            MessageBox.Show("Cierre las ventanas abiertas.")
        End If
    End Sub

    Private Sub btIva_Click(sender As Object, e As EventArgs) Handles btIva.Click
        If Me.MdiChildren.Length = 0 Then
            frmIva.ShowDialog()
            frmIva.Dispose()
        Else
            MessageBox.Show("Error, Para cambiar el I.V.A debe cerrar todos las ventanas.")
        End If
    End Sub

    Private Sub btConsignar_Click(sender As Object, e As EventArgs) Handles btConsignar.Click
        frmConsignacion.MdiParent = Me
        frmConsignacion.BringToFront()
        frmConsignacion.Show()
    End Sub

    Private Sub btDesconsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDesconsignar.Click
        frmDesconsignacion.MdiParent = Me
        frmDesconsignacion.BringToFront()
        frmDesconsignacion.Show()
    End Sub

    Private Sub btInformeConsignacionFiltrado_Click(sender As Object, e As EventArgs) Handles btReporteConsignacion.Click
        frmInformeConsignacionProducto.MdiParent = Me
        frmInformeConsignacionProducto.BringToFront()
        frmInformeConsignacionProducto.Show()
    End Sub

    Private Sub btRecibo_Click(sender As Object, e As EventArgs) Handles btReciboVenta.Click
        frmReciboVenta.MdiParent = Me
        frmReciboVenta.BringToFront()
        frmReciboVenta.Show()
    End Sub

    Private Sub btEstadoCuenta_Click(sender As Object, e As EventArgs) Handles btEstadoCuenta.Click
        frmEstadoCuenta.MdiParent = Me
        frmEstadoCuenta.BringToFront()
        frmEstadoCuenta.Show()
    End Sub


    Private Sub btBusquedaProductos_Click(sender As Object, e As EventArgs) Handles btBusquedaProductos.Click
        frmBuscarProductos.ShowDialog()
    End Sub

    Private Sub btBusquedaConsignacion_Click(sender As Object, e As EventArgs) Handles btBusquedaConsignacion.Click
        frmInformeConsignacion.MdiParent = Me
        frmInformeConsignacion.BringToFront()
        frmInformeConsignacion.Show()
    End Sub

    Private Sub btInformeVentaDetalle_Click(sender As Object, e As EventArgs) Handles btInformeVentaDetalle.Click
        'frmInformeVentaDetalle.MdiParent = Me
        'frmInformeVentaDetalle.BringToFront()
        'frmInformeVentaDetalle.Show()
        frmProductosVendidos.MdiParent = Me
        frmProductosVendidos.BringToFront()
        frmProductosVendidos.Show()
    End Sub


    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        Me.Close()
    End Sub

    Private Sub btInformeUsuarios_Click(sender As Object, e As EventArgs) Handles btInformeUsuarios.Click
        frmBuscarUsuario.ShowDialog()
    End Sub

    Private Sub btCambiarPassword_Click(sender As Object, e As EventArgs) Handles btCambiarPassword.Click
        frmCambiarContraseña.ShowDialog()
    End Sub

    Private Sub btBitacora_Click(sender As Object, e As EventArgs) Handles btBitacora.Click

    End Sub

    Private Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        salir = True
        Me.Close()
    End Sub

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If forzarcierre Then
            Me.Dispose()
        Else
            If salir Then
                If MessageBox.Show("¿Desea cerrar sesión?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                    frmLogin.Show()
                    Me.Dispose()
                Else
                    e.Cancel = True
                End If
            Else
                If MessageBox.Show("¿Desea cerrar la aplicación?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                    Application.ExitThread()
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub frmPrincipal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pcLogo.Left = ExpandablePanel1.Width - 62
        Me.Text = "Sistema de Facturación e Inventario // SIF " & Me.Width & " x " & Me.Height
        Me.rcCintaMenu.TitleText = Me.Text
        If Me.Width >= 1175 Then
            lblEmpresa.Text = "Sistema de Inventario y Facturación // SIF"
        Else
            lblEmpresa.Text = ""
        End If
    End Sub


    Private Sub btBusquedaVendedor_Click(sender As Object, e As EventArgs) Handles btBusquedaVendedor.Click
        frmBuscarEmpleado.ShowDialog()
    End Sub

    Private Sub btBusquedaClientes_Click(sender As Object, e As EventArgs) Handles btBusquedaClientes.Click
        frmBuscarClientes.ShowDialog()
    End Sub

    Private Sub btBusquedaProveedores_Click(sender As Object, e As EventArgs) Handles btBusquedaProveedores.Click
        frmBuscarProveedor.ShowDialog()
    End Sub

    Private Sub btBusquedaCompra_Click(sender As Object, e As EventArgs) Handles btBusquedaCompra.Click
        frmInformeCompras.MdiParent = Me
        frmInformeCompras.BringToFront()
        frmInformeCompras.Show()
    End Sub

    Private Sub btDevolucionCompra_Click(sender As Object, e As EventArgs) Handles btDevolucionCompra.Click
        frmNotaDevolucionCompra.MdiParent = Me
        frmNotaDevolucionCompra.BringToFront()
        frmNotaDevolucionCompra.Show()
    End Sub

    Private Sub btBusquedaDevolucionesCompras_Click(sender As Object, e As EventArgs) Handles btBusquedaDevolucionesCompras.Click
        frmInformeDevolucionesCompras.MdiParent = Me
        frmInformeDevolucionesCompras.BringToFront()
        frmInformeDevolucionesCompras.Show()
    End Sub

    Private Sub btReciboCompra_Click(sender As Object, e As EventArgs) Handles btReciboCompra.Click
        frmReciboCompra.MdiParent = Me
        frmReciboCompra.BringToFront()
        frmReciboCompra.Show()
    End Sub

    Private Sub btBusquedaReciboCompra_Click(sender As Object, e As EventArgs) Handles btBusquedaReciboCompra.Click
        frmInformeReciboCompra.MdiParent = Me
        frmInformeReciboCompra.BringToFront()
        frmInformeReciboCompra.Show()
    End Sub

    Private Sub btCompraEstadoCuenta_Click(sender As Object, e As EventArgs) Handles btCompraEstadoCuenta.Click
        frmCompraEstadoCuenta.MdiParent = Me
        frmCompraEstadoCuenta.BringToFront()
        frmCompraEstadoCuenta.Show()
    End Sub

    Private Sub btCuentasCobrar_Click(sender As Object, e As EventArgs) Handles btCuentasCobrar.Click
        frmCuentasPorCobrar.MdiParent = Me
        frmCuentasPorCobrar.BringToFront()
        frmCuentasPorCobrar.Show()
    End Sub

    Private Sub btCuentasPagar_Click(sender As Object, e As EventArgs) Handles btCuentasPagar.Click
        frmCuentasPorPagar.MdiParent = Me
        frmCuentasPorPagar.BringToFront()
        frmCuentasPorPagar.Show()
    End Sub

    Private Sub btBusquedaRecibo_Click(sender As Object, e As EventArgs) Handles btBusquedaRecibo.Click
        frmInformeRecibo.MdiParent = Me
        frmInformeRecibo.BringToFront()
        frmInformeRecibo.Show()
    End Sub

    Private Sub btEstadoResultados_Click(sender As Object, e As EventArgs)
        frmEstadoResultados.MdiParent = Me
        frmEstadoResultados.BringToFront()
        frmEstadoResultados.Show()
    End Sub

    Private Sub btPeriodo_Click(sender As Object, e As EventArgs)
        frmPeriodo.MdiParent = Me
        frmPeriodo.BringToFront()
        frmPeriodo.Show()
    End Sub

    Private Sub btControlExistencia_Click(sender As Object, e As EventArgs) Handles btControlExistencia.Click
        frmControlExistencia.MdiParent = Me
        frmControlExistencia.BringToFront()
        frmControlExistencia.Show()
    End Sub

    Private Sub btUnidadMedida_Click(sender As Object, e As EventArgs) Handles btUnidadMedida.Click
        frmUnidadMedida.MdiParent = Me
        frmUnidadMedida.BringToFront()
        frmUnidadMedida.Show()
    End Sub

    Private Sub btPresentacion_Click(sender As Object, e As EventArgs) Handles btPresentacion.Click
        frmPresentacion.MdiParent = Me
        frmPresentacion.BringToFront()
        frmPresentacion.Show()
    End Sub

    Private Sub btLaboratorio_Click(sender As Object, e As EventArgs) Handles btLaboratorio.Click
        frmLaboratorio.MdiParent = Me
        frmLaboratorio.BringToFront()
        frmLaboratorio.Show()
    End Sub

    Private Sub btBusquedaDesconsignacion_Click(sender As Object, e As EventArgs) Handles btBusquedaDesconsignacion.Click
        frmInformeDesconsignacion.MdiParent = Me
        frmInformeDesconsignacion.BringToFront()
        frmInformeDesconsignacion.Show()
    End Sub

    Private Sub btCatalogoCuentas_Click(sender As Object, e As EventArgs)
        'frmCatalogoCuentas.MdiParent = Me
        'frmCatalogoCuentas.BringToFront()
        'frmCatalogoCuentas.Show()
    End Sub

    Private Sub btTrabajoArea_Click(sender As Object, e As EventArgs) Handles btTrabajoArea.Click
        'frmEmpleadoArea.MdiParent = Me
        'frmEmpleadoArea.BringToFront()
        'frmEmpleadoArea.Show()
    End Sub

    Private Sub btBusquedaPuestos_Click(sender As Object, e As EventArgs) Handles btBusquedaPuestos.Click
        'frmBuscarTrabajadorPuesto.ShowDialog()
    End Sub

    Private Sub btTrabajoPuestos_Click(sender As Object, e As EventArgs) Handles btTrabajoPuestos.Click
        'frmEmpleadoPuesto.MdiParent = Me
        'frmEmpleadoPuesto.BringToFront()
        'frmEmpleadoPuesto.Show()
    End Sub

    Private Sub btBusquedaAreas_Click(sender As Object, e As EventArgs) Handles btBusquedaAreas.Click
        'frmBuscarTrabajadorArea.ShowDialog()
    End Sub

    Private Sub btPaises_Click(sender As Object, e As EventArgs) Handles btPaises.Click
        frmPais.MdiParent = Me
        frmPais.BringToFront()
        frmPais.Show()
    End Sub

    Private Sub btBusquedaPais_Click(sender As Object, e As EventArgs) Handles btBusquedaPais.Click
        frmBuscarPais.ShowDialog()
    End Sub

    Private Sub btCiudades_Click(sender As Object, e As EventArgs) Handles btCiudades.Click
        frmCiudad.MdiParent = Me
        frmCiudad.BringToFront()
        frmCiudad.Show()
    End Sub

    Private Sub btCargarCiclo_Click(sender As Object, e As EventArgs) Handles btCargarCiclo.Click
        If Me.MdiChildren.Length = 0 Then
            frmPeriodoList.ShowDialog()
        Else
            MessageBox.Show("Cierre las ventanas abiertas.")
        End If
        txtInicio.Focus()
    End Sub

    Private Sub btSeleccionar_Click(sender As Object, e As EventArgs) Handles btSeleccionar.Click
        frmPeriodoList.ShowDialog()
    End Sub

    Private Sub btApertura_Click(sender As Object, e As EventArgs) Handles btApertura.Click

    End Sub


    Private Sub btPeriodoContable_Click(sender As Object, e As EventArgs) Handles btPeriodoContable.Click
        If Me.MdiChildren.Length = 0 Then
            frmPeriodo.ShowDialog()
        Else
            MessageBox.Show("Cierre las ventanas abiertas.")
        End If
    End Sub

    Private Sub frmPrincipal_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged
        Me.rcCintaMenu.TitleText = "Sistema de <font color='#C0504D'><b>Inventario y Facturación</b></font> - (" & Me.Text & ")"
    End Sub


    Private Sub btBusquedaCotizacion_Click(sender As Object, e As EventArgs) Handles btBusquedaCotizacion.Click
        frmInformeCotizaciones.MdiParent = Me
        frmInformeCotizaciones.BringToFront()
        frmInformeCotizaciones.Show()
    End Sub

    Private Sub btBusquedaDevolucion_Click(sender As Object, e As EventArgs) Handles btBusquedaDevolucion.Click
        frmInformeDevolucionesVentas.MdiParent = Me
        frmInformeDevolucionesVentas.BringToFront()
        frmInformeDevolucionesVentas.Show()
    End Sub

    Private Sub btEmpresa_Click(sender As Object, e As EventArgs) Handles btEmpresa.Click
        If Me.MdiChildren.Length = 0 Then
            frmInformacion.ShowDialog()
        Else
            MessageBox.Show("Cierre las ventanas abiertas.")
        End If
    End Sub

    Private Sub btCCEstadoCuenta_Click(sender As Object, e As EventArgs) Handles btCCEstadoCuenta.Click
        frmEstadoCuenta.MdiParent = Me
        frmEstadoCuenta.BringToFront()
        frmEstadoCuenta.Show()
    End Sub

    Private Sub btCPEstadoCuenta_Click(sender As Object, e As EventArgs) Handles btCPEstadoCuenta.Click
        frmCompraEstadoCuenta.MdiParent = Me
        frmCompraEstadoCuenta.BringToFront()
        frmCompraEstadoCuenta.Show()
    End Sub


    Private Sub btRegistro_Click(sender As Object, e As EventArgs) Handles btRegistro.Click
        If Me.MdiChildren.Length = 0 Then
            frmRegister.ShowDialog()
        Else
            MessageBox.Show("Cierre las ventanas abiertas.")
        End If
    End Sub

    Private Sub btAyuda_Click(sender As Object, e As EventArgs) Handles btAyuda.Click

    End Sub

    Private Sub btAcercaDe_Click(sender As Object, e As EventArgs) Handles btAcercaDe.Click
        frmAcercaDe.ShowDialog()
    End Sub

    Private Sub btValuacionInventario_Click(sender As Object, e As EventArgs) Handles btValuacionInventario.Click
        frmValuacion.MdiParent = Me
        frmValuacion.BringToFront()
        frmValuacion.Show()
    End Sub

    Private Sub btProductosComprados_Click(sender As Object, e As EventArgs) Handles btProductosComprados.Click
        frmProductosComprados.MdiParent = Me
        frmProductosComprados.BringToFront()
        frmProductosComprados.Show()
    End Sub

    Private Sub btCreditos_Click(sender As Object, e As EventArgs) Handles btCreditos.Click
        frmAcercaDe.ShowDialog()
    End Sub

    Private Sub btServidor_Click(sender As Object, e As EventArgs) Handles btServidor.Click
        frmServer.ShowDialog()
    End Sub

    Private Sub btPrinterSetting_Click(sender As Object, e As EventArgs) Handles btPrinterSetting.Click
        frmPrinterSettings.ShowDialog()
    End Sub

    Private Sub btProductoOferta_Click(sender As Object, e As EventArgs) Handles btProductoOferta.Click
        frmPromocion.MdiParent = Me
        frmPromocion.BringToFront()
        frmPromocion.Show()
    End Sub
End Class