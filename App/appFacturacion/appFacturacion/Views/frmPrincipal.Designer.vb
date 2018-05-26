<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
    Inherits DevComponents.DotNetBar.Office2007RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim PaintStyle1 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle2 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.stsEstado = New System.Windows.Forms.StatusStrip()
        Me.lblEmpresa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StateLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblNombreUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBodega = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblIva = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTaza = New System.Windows.Forms.ToolStripStatusLabel()
        Me.rcCintaMenu = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel4 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar23 = New DevComponents.DotNetBar.RibbonBar()
        Me.btReciboCompra = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaReciboCompra = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar22 = New DevComponents.DotNetBar.RibbonBar()
        Me.btReciboVenta = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaRecibo = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar21 = New DevComponents.DotNetBar.RibbonBar()
        Me.btCatalogoCuentas = New DevComponents.DotNetBar.ButtonItem()
        Me.btPeriodo = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar14 = New DevComponents.DotNetBar.RibbonBar()
        Me.btCPEstadoCuenta = New DevComponents.DotNetBar.ButtonItem()
        Me.btCuentasPagar = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar11 = New DevComponents.DotNetBar.RibbonBar()
        Me.btCCEstadoCuenta = New DevComponents.DotNetBar.ButtonItem()
        Me.btCuentasCobrar = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar9 = New DevComponents.DotNetBar.RibbonBar()
        Me.btEstadoResultados = New DevComponents.DotNetBar.ButtonItem()
        Me.btPeriodoContable = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer5 = New DevComponents.DotNetBar.ItemContainer()
        Me.btSeleccionar = New DevComponents.DotNetBar.ButtonItem()
        Me.btApertura = New DevComponents.DotNetBar.ButtonItem()
        Me.btCierre = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar20 = New DevComponents.DotNetBar.RibbonBar()
        Me.btPaises = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaPais = New DevComponents.DotNetBar.ButtonItem()
        Me.btCiudades = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaCiudades = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar6 = New DevComponents.DotNetBar.RibbonBar()
        Me.btIva = New DevComponents.DotNetBar.ButtonItem()
        Me.btTaza = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
        Me.btMarcas = New DevComponents.DotNetBar.ButtonItem()
        Me.btUnidadMedida = New DevComponents.DotNetBar.ButtonItem()
        Me.btPresentacion = New DevComponents.DotNetBar.ButtonItem()
        Me.btLaboratorio = New DevComponents.DotNetBar.ButtonItem()
        Me.btProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaProductos = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.btEmpresa = New DevComponents.DotNetBar.ButtonItem()
        Me.btBodega = New DevComponents.DotNetBar.ButtonItem()
        Me.btSerie = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel3 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar24 = New DevComponents.DotNetBar.RibbonBar()
        Me.btPrinterSetting = New DevComponents.DotNetBar.ButtonItem()
        Me.btServidor = New DevComponents.DotNetBar.ButtonItem()
        Me.btRegistro = New DevComponents.DotNetBar.ButtonItem()
        Me.btAyuda = New DevComponents.DotNetBar.ButtonItem()
        Me.btAcercaDe = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar10 = New DevComponents.DotNetBar.RibbonBar()
        Me.btCreateBackup = New DevComponents.DotNetBar.ButtonItem()
        Me.btRestoreDatabase = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar8 = New DevComponents.DotNetBar.RibbonBar()
        Me.btLogo = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel2 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar25 = New DevComponents.DotNetBar.RibbonBar()
        Me.btKardex = New DevComponents.DotNetBar.ButtonItem()
        Me.btControlExistencia = New DevComponents.DotNetBar.ButtonItem()
        Me.btProductWithApplication = New DevComponents.DotNetBar.ButtonItem()
        Me.btValuacionInventario = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar15 = New DevComponents.DotNetBar.RibbonBar()
        Me.btConsignar = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaConsignacion = New DevComponents.DotNetBar.ButtonItem()
        Me.btDesconsignar = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaDesconsignacion = New DevComponents.DotNetBar.ButtonItem()
        Me.btReporteConsignacion = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar5 = New DevComponents.DotNetBar.RibbonBar()
        Me.btEntradas = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaEntradas = New DevComponents.DotNetBar.ButtonItem()
        Me.btSalidas = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaSalida = New DevComponents.DotNetBar.ButtonItem()
        Me.btTraslados = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaTraslado = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel7 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar7 = New DevComponents.DotNetBar.RibbonBar()
        Me.btInformeVentaDetalle = New DevComponents.DotNetBar.ButtonItem()
        Me.btGraficosVenta = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar16 = New DevComponents.DotNetBar.RibbonBar()
        Me.btVenta = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaFactura = New DevComponents.DotNetBar.ButtonItem()
        Me.btDevolucionesVentas = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaDevolucion = New DevComponents.DotNetBar.ButtonItem()
        Me.btCotizar = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaCotizacion = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar13 = New DevComponents.DotNetBar.RibbonBar()
        Me.btClientes = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaClientes = New DevComponents.DotNetBar.ButtonItem()
        Me.btEstadoCuenta = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel8 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar19 = New DevComponents.DotNetBar.RibbonBar()
        Me.btProductoOferta = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar18 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel6 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar26 = New DevComponents.DotNetBar.RibbonBar()
        Me.btProductosComprados = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar4 = New DevComponents.DotNetBar.RibbonBar()
        Me.btCompra = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaCompra = New DevComponents.DotNetBar.ButtonItem()
        Me.btDevolucionCompra = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaDevolucionesCompras = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar3 = New DevComponents.DotNetBar.RibbonBar()
        Me.btProveedores = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaProveedores = New DevComponents.DotNetBar.ButtonItem()
        Me.btCompraEstadoCuenta = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel9 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar17 = New DevComponents.DotNetBar.RibbonBar()
        Me.btPlanilla = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedasPlanillas = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar12 = New DevComponents.DotNetBar.RibbonBar()
        Me.btVendedores = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaVendedor = New DevComponents.DotNetBar.ButtonItem()
        Me.btTrabajoArea = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaAreas = New DevComponents.DotNetBar.ButtonItem()
        Me.btTrabajoPuestos = New DevComponents.DotNetBar.ButtonItem()
        Me.btBusquedaPuestos = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuArchivo = New DevComponents.DotNetBar.Office2007StartButton()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.btUsuarios = New DevComponents.DotNetBar.ButtonItem()
        Me.btInformeUsuarios = New DevComponents.DotNetBar.ButtonItem()
        Me.btBitacora = New DevComponents.DotNetBar.ButtonItem()
        Me.btCambiarPassword = New DevComponents.DotNetBar.ButtonItem()
        Me.btCerrarSesion = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
        Me.btSalir = New DevComponents.DotNetBar.ButtonItem()
        Me.mnuCatalogos = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem6 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem5 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem8 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem7 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem3 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem2 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.btCreditos = New DevComponents.DotNetBar.ButtonItem()
        Me.styEstiloSistema = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.txtBodega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tmLimpiarMemoria = New System.Windows.Forms.Timer(Me.components)
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btCargarCiclo = New DevComponents.DotNetBar.ButtonX()
        Me.ElLabel2 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.ElLabel1 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.txtFinal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtInicio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btCargar = New DevComponents.DotNetBar.ButtonX()
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.pcLogo = New System.Windows.Forms.PictureBox()
        Me.stsEstado.SuspendLayout()
        Me.rcCintaMenu.SuspendLayout()
        Me.RibbonPanel4.SuspendLayout()
        Me.RibbonPanel1.SuspendLayout()
        Me.RibbonPanel3.SuspendLayout()
        Me.RibbonPanel2.SuspendLayout()
        Me.RibbonPanel7.SuspendLayout()
        Me.RibbonPanel8.SuspendLayout()
        Me.RibbonPanel6.SuspendLayout()
        Me.RibbonPanel9.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.ElLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.pcLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stsEstado
        '
        Me.stsEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.stsEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEmpresa, Me.StateLabel, Me.ToolStripStatusLabel2, Me.lblNombreUsuario, Me.lblUsuario, Me.lblBodega, Me.lblIva, Me.lblTaza})
        Me.stsEstado.Location = New System.Drawing.Point(5, 677)
        Me.stsEstado.Name = "stsEstado"
        Me.stsEstado.Size = New System.Drawing.Size(1012, 33)
        Me.stsEstado.TabIndex = 3
        Me.stsEstado.Text = "BARRA DE ESTADO"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Image = Global.appFacturacion.My.Resources.Resources.Isotipo24x24
        Me.lblEmpresa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(24, 28)
        Me.lblEmpresa.ToolTipText = "Sistema de Inventario y Facturación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "© Copyright - Sadara 2018. All rights reserv" &
    "ed."
        '
        'StateLabel
        '
        Me.StateLabel.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.StateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.StateLabel.Name = "StateLabel"
        Me.StateLabel.Size = New System.Drawing.Size(34, 28)
        Me.StateLabel.Text = "Listo"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(575, 28)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombreUsuario
        '
        Me.lblNombreUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblNombreUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.lblNombreUsuario.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblNombreUsuario.Image = Global.appFacturacion.My.Resources.Resources.Codigo
        Me.lblNombreUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblNombreUsuario.Name = "lblNombreUsuario"
        Me.lblNombreUsuario.Size = New System.Drawing.Size(84, 28)
        Me.lblNombreUsuario.Text = "Nombre:"
        Me.lblNombreUsuario.Visible = False
        '
        'lblUsuario
        '
        Me.lblUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.lblUsuario.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblUsuario.Image = Global.appFacturacion.My.Resources.Resources.Usuario
        Me.lblUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(81, 28)
        Me.lblUsuario.Text = "Usuario:"
        '
        'lblBodega
        '
        Me.lblBodega.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblBodega.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.lblBodega.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.lblBodega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblBodega.Image = Global.appFacturacion.My.Resources.Resources.Bodega1
        Me.lblBodega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblBodega.Name = "lblBodega"
        Me.lblBodega.Size = New System.Drawing.Size(87, 28)
        Me.lblBodega.Text = "Sucursal:"
        '
        'lblIva
        '
        Me.lblIva.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblIva.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.lblIva.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.lblIva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblIva.Image = Global.appFacturacion.My.Resources.Resources.BarImpuesto
        Me.lblIva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(77, 28)
        Me.lblIva.Text = "IVA: 0%"
        '
        'lblTaza
        '
        Me.lblTaza.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.lblTaza.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.lblTaza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblTaza.Image = Global.appFacturacion.My.Resources.Resources.Tazadecambio1
        Me.lblTaza.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblTaza.Name = "lblTaza"
        Me.lblTaza.Size = New System.Drawing.Size(119, 28)
        Me.lblTaza.Text = "T/C: $ 1 = C$ 27"
        '
        'rcCintaMenu
        '
        '
        '
        '
        Me.rcCintaMenu.BackgroundStyle.Class = ""
        Me.rcCintaMenu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rcCintaMenu.CanCustomize = False
        Me.rcCintaMenu.CaptionVisible = True
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel4)
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel1)
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel3)
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel2)
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel7)
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel8)
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel6)
        Me.rcCintaMenu.Controls.Add(Me.RibbonPanel9)
        Me.rcCintaMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.rcCintaMenu.EnableQatPlacement = False
        Me.rcCintaMenu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rcCintaMenu.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.mnuArchivo, Me.mnuCatalogos, Me.RibbonTabItem1, Me.RibbonTabItem6, Me.RibbonTabItem5, Me.RibbonTabItem8, Me.RibbonTabItem7, Me.RibbonTabItem3, Me.RibbonTabItem2})
        Me.rcCintaMenu.KeyTipsFont = New System.Drawing.Font("Arial", 7.0!)
        Me.rcCintaMenu.Location = New System.Drawing.Point(5, 1)
        Me.rcCintaMenu.Name = "rcCintaMenu"
        Me.rcCintaMenu.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.rcCintaMenu.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCreditos})
        Me.rcCintaMenu.Size = New System.Drawing.Size(1012, 170)
        Me.rcCintaMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.rcCintaMenu.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.rcCintaMenu.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.rcCintaMenu.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.rcCintaMenu.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.rcCintaMenu.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.rcCintaMenu.SystemText.QatDialogAddButton = "&Add >>"
        Me.rcCintaMenu.SystemText.QatDialogCancelButton = "Cancel"
        Me.rcCintaMenu.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.rcCintaMenu.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.rcCintaMenu.SystemText.QatDialogOkButton = "OK"
        Me.rcCintaMenu.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.rcCintaMenu.SystemText.QatDialogRemoveButton = "&Remove"
        Me.rcCintaMenu.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.rcCintaMenu.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.rcCintaMenu.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.rcCintaMenu.TabGroupHeight = 14
        Me.rcCintaMenu.TabIndex = 4
        Me.rcCintaMenu.Text = "Menu del Sistema"
        Me.rcCintaMenu.TitleText = "Sistema de <font color='#C0504D'><b>Inventario y Facturación</b></font>"
        '
        'RibbonPanel4
        '
        Me.RibbonPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar23)
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar22)
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar21)
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar14)
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar11)
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar9)
        Me.RibbonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel4.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel4.Name = "RibbonPanel4"
        Me.RibbonPanel4.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel4.Size = New System.Drawing.Size(1012, 115)
        '
        '
        '
        Me.RibbonPanel4.Style.Class = ""
        Me.RibbonPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel4.StyleMouseDown.Class = ""
        Me.RibbonPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel4.StyleMouseOver.Class = ""
        Me.RibbonPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel4.TabIndex = 8
        '
        'RibbonBar23
        '
        Me.RibbonBar23.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar23.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar23.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar23.BackgroundStyle.Class = ""
        Me.RibbonBar23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar23.ContainerControlProcessDialogKey = True
        Me.RibbonBar23.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar23.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btReciboCompra, Me.btBusquedaReciboCompra})
        Me.RibbonBar23.Location = New System.Drawing.Point(726, 0)
        Me.RibbonBar23.Name = "RibbonBar23"
        Me.RibbonBar23.Size = New System.Drawing.Size(145, 112)
        Me.RibbonBar23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar23.TabIndex = 11
        Me.RibbonBar23.Text = "Pagos / Egresos"
        '
        '
        '
        Me.RibbonBar23.TitleStyle.Class = ""
        Me.RibbonBar23.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar23.TitleStyleMouseOver.Class = ""
        Me.RibbonBar23.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btReciboCompra
        '
        Me.btReciboCompra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btReciboCompra.Enabled = False
        Me.btReciboCompra.Image = Global.appFacturacion.My.Resources.Resources.ReciboCompra
        Me.btReciboCompra.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btReciboCompra.Name = "btReciboCompra"
        Me.btReciboCompra.Text = "Pago de Proveedores"
        '
        'btBusquedaReciboCompra
        '
        Me.btBusquedaReciboCompra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaReciboCompra.Enabled = False
        Me.btBusquedaReciboCompra.Image = Global.appFacturacion.My.Resources.Resources.BusquedaReciboCompra
        Me.btBusquedaReciboCompra.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaReciboCompra.Name = "btBusquedaReciboCompra"
        Me.btBusquedaReciboCompra.Text = "Busqueda de Pago"
        '
        'RibbonBar22
        '
        Me.RibbonBar22.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar22.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar22.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar22.BackgroundStyle.Class = ""
        Me.RibbonBar22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar22.ContainerControlProcessDialogKey = True
        Me.RibbonBar22.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar22.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btReciboVenta, Me.btBusquedaRecibo})
        Me.RibbonBar22.Location = New System.Drawing.Point(581, 0)
        Me.RibbonBar22.Name = "RibbonBar22"
        Me.RibbonBar22.Size = New System.Drawing.Size(145, 112)
        Me.RibbonBar22.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar22.TabIndex = 10
        Me.RibbonBar22.Text = "Recibos / Ingresos"
        '
        '
        '
        Me.RibbonBar22.TitleStyle.Class = ""
        Me.RibbonBar22.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar22.TitleStyleMouseOver.Class = ""
        Me.RibbonBar22.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btReciboVenta
        '
        Me.btReciboVenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btReciboVenta.Enabled = False
        Me.btReciboVenta.Image = Global.appFacturacion.My.Resources.Resources.Recibo
        Me.btReciboVenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btReciboVenta.Name = "btReciboVenta"
        Me.btReciboVenta.SubItemsExpandWidth = 14
        Me.btReciboVenta.Text = "Recibos de Ventas"
        '
        'btBusquedaRecibo
        '
        Me.btBusquedaRecibo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaRecibo.Enabled = False
        Me.btBusquedaRecibo.Image = Global.appFacturacion.My.Resources.Resources.BusquedaRecibo
        Me.btBusquedaRecibo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaRecibo.Name = "btBusquedaRecibo"
        Me.btBusquedaRecibo.SubItemsExpandWidth = 14
        Me.btBusquedaRecibo.Text = "Busqueda de Recibos"
        '
        'RibbonBar21
        '
        Me.RibbonBar21.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar21.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar21.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar21.BackgroundStyle.Class = ""
        Me.RibbonBar21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar21.ContainerControlProcessDialogKey = True
        Me.RibbonBar21.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar21.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCatalogoCuentas, Me.btPeriodo})
        Me.RibbonBar21.Location = New System.Drawing.Point(428, 0)
        Me.RibbonBar21.Name = "RibbonBar21"
        Me.RibbonBar21.Size = New System.Drawing.Size(153, 112)
        Me.RibbonBar21.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar21.TabIndex = 9
        Me.RibbonBar21.Text = "Período Contable"
        '
        '
        '
        Me.RibbonBar21.TitleStyle.Class = ""
        Me.RibbonBar21.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar21.TitleStyleMouseOver.Class = ""
        Me.RibbonBar21.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar21.Visible = False
        '
        'btCatalogoCuentas
        '
        Me.btCatalogoCuentas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCatalogoCuentas.Enabled = False
        Me.btCatalogoCuentas.Image = Global.appFacturacion.My.Resources.Resources.CatalogoCuentas
        Me.btCatalogoCuentas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCatalogoCuentas.Name = "btCatalogoCuentas"
        Me.btCatalogoCuentas.SubItemsExpandWidth = 14
        Me.btCatalogoCuentas.Text = "Catalogo de Cuentas"
        '
        'btPeriodo
        '
        Me.btPeriodo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btPeriodo.Enabled = False
        Me.btPeriodo.Image = Global.appFacturacion.My.Resources.Resources.PeriodoContable
        Me.btPeriodo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btPeriodo.Name = "btPeriodo"
        Me.btPeriodo.SubItemsExpandWidth = 14
        Me.btPeriodo.Text = "Período de Contabilidad"
        '
        'RibbonBar14
        '
        Me.RibbonBar14.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar14.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar14.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar14.BackgroundStyle.Class = ""
        Me.RibbonBar14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar14.ContainerControlProcessDialogKey = True
        Me.RibbonBar14.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar14.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCPEstadoCuenta, Me.btCuentasPagar})
        Me.RibbonBar14.Location = New System.Drawing.Point(303, 0)
        Me.RibbonBar14.Name = "RibbonBar14"
        Me.RibbonBar14.Size = New System.Drawing.Size(125, 112)
        Me.RibbonBar14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar14.TabIndex = 8
        Me.RibbonBar14.Text = "Cuentas por pagar"
        '
        '
        '
        Me.RibbonBar14.TitleStyle.Class = ""
        Me.RibbonBar14.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar14.TitleStyleMouseOver.Class = ""
        Me.RibbonBar14.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btCPEstadoCuenta
        '
        Me.btCPEstadoCuenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCPEstadoCuenta.Enabled = False
        Me.btCPEstadoCuenta.Image = Global.appFacturacion.My.Resources.Resources.EstadoCuentaProveedor
        Me.btCPEstadoCuenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCPEstadoCuenta.Name = "btCPEstadoCuenta"
        Me.btCPEstadoCuenta.SubItemsExpandWidth = 14
        Me.btCPEstadoCuenta.Text = "Estado de cuenta"
        '
        'btCuentasPagar
        '
        Me.btCuentasPagar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCuentasPagar.Enabled = False
        Me.btCuentasPagar.Image = Global.appFacturacion.My.Resources.Resources.CuentasporPagar
        Me.btCuentasPagar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCuentasPagar.Name = "btCuentasPagar"
        Me.btCuentasPagar.SubItemsExpandWidth = 14
        Me.btCuentasPagar.Text = "Listado de Deudas"
        '
        'RibbonBar11
        '
        Me.RibbonBar11.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar11.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar11.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar11.BackgroundStyle.Class = ""
        Me.RibbonBar11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar11.ContainerControlProcessDialogKey = True
        Me.RibbonBar11.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar11.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCCEstadoCuenta, Me.btCuentasCobrar})
        Me.RibbonBar11.Location = New System.Drawing.Point(178, 0)
        Me.RibbonBar11.Name = "RibbonBar11"
        Me.RibbonBar11.Size = New System.Drawing.Size(125, 112)
        Me.RibbonBar11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar11.TabIndex = 7
        Me.RibbonBar11.Text = "Cuentas por cobrar"
        '
        '
        '
        Me.RibbonBar11.TitleStyle.Class = ""
        Me.RibbonBar11.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar11.TitleStyleMouseOver.Class = ""
        Me.RibbonBar11.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btCCEstadoCuenta
        '
        Me.btCCEstadoCuenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCCEstadoCuenta.Enabled = False
        Me.btCCEstadoCuenta.Image = Global.appFacturacion.My.Resources.Resources.EstadoCuentaCliente
        Me.btCCEstadoCuenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCCEstadoCuenta.Name = "btCCEstadoCuenta"
        Me.btCCEstadoCuenta.SubItemsExpandWidth = 14
        Me.btCCEstadoCuenta.Text = "Estado de Cuenta"
        '
        'btCuentasCobrar
        '
        Me.btCuentasCobrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCuentasCobrar.Enabled = False
        Me.btCuentasCobrar.Image = Global.appFacturacion.My.Resources.Resources.CuentasporCobrar
        Me.btCuentasCobrar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCuentasCobrar.Name = "btCuentasCobrar"
        Me.btCuentasCobrar.SubItemsExpandWidth = 14
        Me.btCuentasCobrar.Text = "Listado de Cobros"
        '
        'RibbonBar9
        '
        Me.RibbonBar9.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar9.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar9.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar9.BackgroundStyle.Class = ""
        Me.RibbonBar9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar9.ContainerControlProcessDialogKey = True
        Me.RibbonBar9.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btEstadoResultados, Me.btPeriodoContable, Me.ItemContainer5})
        Me.RibbonBar9.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar9.Name = "RibbonBar9"
        Me.RibbonBar9.Size = New System.Drawing.Size(175, 112)
        Me.RibbonBar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar9.TabIndex = 6
        Me.RibbonBar9.Text = "Contabilidad"
        '
        '
        '
        Me.RibbonBar9.TitleStyle.Class = ""
        Me.RibbonBar9.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar9.TitleStyleMouseOver.Class = ""
        Me.RibbonBar9.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btEstadoResultados
        '
        Me.btEstadoResultados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btEstadoResultados.Enabled = False
        Me.btEstadoResultados.Image = Global.appFacturacion.My.Resources.Resources.EstadoResultados
        Me.btEstadoResultados.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btEstadoResultados.Name = "btEstadoResultados"
        Me.btEstadoResultados.SubItemsExpandWidth = 14
        Me.btEstadoResultados.Text = "Estado de Resultados"
        Me.btEstadoResultados.Visible = False
        '
        'btPeriodoContable
        '
        Me.btPeriodoContable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btPeriodoContable.Enabled = False
        Me.btPeriodoContable.Image = Global.appFacturacion.My.Resources.Resources.PeriodoContable
        Me.btPeriodoContable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btPeriodoContable.Name = "btPeriodoContable"
        Me.btPeriodoContable.SubItemsExpandWidth = 14
        Me.btPeriodoContable.Text = "Período de Contabilidad"
        '
        'ItemContainer5
        '
        '
        '
        '
        Me.ItemContainer5.BackgroundStyle.Class = ""
        Me.ItemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer5.Name = "ItemContainer5"
        Me.ItemContainer5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btSeleccionar, Me.btApertura, Me.btCierre})
        '
        'btSeleccionar
        '
        Me.btSeleccionar.Enabled = False
        Me.btSeleccionar.Image = Global.appFacturacion.My.Resources.Resources.Periodo
        Me.btSeleccionar.Name = "btSeleccionar"
        Me.btSeleccionar.SubItemsExpandWidth = 14
        Me.btSeleccionar.Tag = "Cambiar Período"
        Me.btSeleccionar.Text = "Seleccionar"
        Me.btSeleccionar.Tooltip = "Cambiar Período"
        '
        'btApertura
        '
        Me.btApertura.Enabled = False
        Me.btApertura.Image = Global.appFacturacion.My.Resources.Resources.PeriodoApertura
        Me.btApertura.Name = "btApertura"
        Me.btApertura.SubItemsExpandWidth = 14
        Me.btApertura.Tag = "Aperturar Período Actual"
        Me.btApertura.Text = "Aperturar"
        Me.btApertura.Tooltip = "Aperturar Período Actual"
        '
        'btCierre
        '
        Me.btCierre.Enabled = False
        Me.btCierre.Image = Global.appFacturacion.My.Resources.Resources.PeriodoCierre
        Me.btCierre.Name = "btCierre"
        Me.btCierre.SubItemsExpandWidth = 14
        Me.btCierre.Tag = "Cerrar Período Actual"
        Me.btCierre.Text = "Cierre"
        Me.btCierre.Tooltip = "Cerrar Período Actual"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar20)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar6)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar2)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel1.Size = New System.Drawing.Size(1026, 115)
        '
        '
        '
        Me.RibbonPanel1.Style.Class = ""
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.Class = ""
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.Class = ""
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 1
        Me.RibbonPanel1.Visible = False
        '
        'RibbonBar20
        '
        Me.RibbonBar20.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar20.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar20.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar20.BackgroundStyle.Class = ""
        Me.RibbonBar20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar20.ContainerControlProcessDialogKey = True
        Me.RibbonBar20.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar20.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btPaises, Me.btBusquedaPais, Me.btCiudades, Me.btBusquedaCiudades})
        Me.RibbonBar20.Location = New System.Drawing.Point(775, 0)
        Me.RibbonBar20.Name = "RibbonBar20"
        Me.RibbonBar20.Size = New System.Drawing.Size(216, 112)
        Me.RibbonBar20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar20.TabIndex = 4
        Me.RibbonBar20.Text = "Ubicación Geográfica"
        '
        '
        '
        Me.RibbonBar20.TitleStyle.Class = ""
        Me.RibbonBar20.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar20.TitleStyleMouseOver.Class = ""
        Me.RibbonBar20.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar20.Visible = False
        '
        'btPaises
        '
        Me.btPaises.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btPaises.Enabled = False
        Me.btPaises.Image = Global.appFacturacion.My.Resources.Resources.Pais
        Me.btPaises.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btPaises.Name = "btPaises"
        Me.btPaises.Text = "Edición de Paises"
        '
        'btBusquedaPais
        '
        Me.btBusquedaPais.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaPais.Enabled = False
        Me.btBusquedaPais.Image = Global.appFacturacion.My.Resources.Resources.BusquedaPais
        Me.btBusquedaPais.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaPais.Name = "btBusquedaPais"
        Me.btBusquedaPais.Text = "Búsqueda de Paises"
        '
        'btCiudades
        '
        Me.btCiudades.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCiudades.Enabled = False
        Me.btCiudades.Image = Global.appFacturacion.My.Resources.Resources.Ciudad
        Me.btCiudades.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCiudades.Name = "btCiudades"
        Me.btCiudades.Text = "Edición de Ciudades"
        '
        'btBusquedaCiudades
        '
        Me.btBusquedaCiudades.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaCiudades.Enabled = False
        Me.btBusquedaCiudades.Image = Global.appFacturacion.My.Resources.Resources.BusquedaCiudad
        Me.btBusquedaCiudades.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaCiudades.Name = "btBusquedaCiudades"
        Me.btBusquedaCiudades.Text = "Búsqueda de Ciudades"
        '
        'RibbonBar6
        '
        Me.RibbonBar6.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar6.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar6.BackgroundStyle.Class = ""
        Me.RibbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar6.ContainerControlProcessDialogKey = True
        Me.RibbonBar6.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btIva, Me.btTaza})
        Me.RibbonBar6.Location = New System.Drawing.Point(648, 0)
        Me.RibbonBar6.Name = "RibbonBar6"
        Me.RibbonBar6.Size = New System.Drawing.Size(127, 112)
        Me.RibbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar6.TabIndex = 3
        Me.RibbonBar6.Text = "Moneda"
        '
        '
        '
        Me.RibbonBar6.TitleStyle.Class = ""
        Me.RibbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar6.TitleStyleMouseOver.Class = ""
        Me.RibbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btIva
        '
        Me.btIva.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btIva.Enabled = False
        Me.btIva.Image = Global.appFacturacion.My.Resources.Resources.Impuesto
        Me.btIva.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btIva.Name = "btIva"
        Me.btIva.Text = "Impuesto I.V.A"
        '
        'btTaza
        '
        Me.btTaza.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btTaza.Enabled = False
        Me.btTaza.Image = Global.appFacturacion.My.Resources.Resources.Tazadecambio
        Me.btTaza.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btTaza.Name = "btTaza"
        Me.btTaza.SubItemsExpandWidth = 14
        Me.btTaza.Text = "Taza de Cambio"
        '
        'RibbonBar2
        '
        Me.RibbonBar2.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar2.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.BackgroundStyle.Class = ""
        Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.ContainerControlProcessDialogKey = True
        Me.RibbonBar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btMarcas, Me.btUnidadMedida, Me.btPresentacion, Me.btLaboratorio, Me.btProductos, Me.btBusquedaProductos})
        Me.RibbonBar2.Location = New System.Drawing.Point(209, 0)
        Me.RibbonBar2.Name = "RibbonBar2"
        Me.RibbonBar2.Size = New System.Drawing.Size(439, 112)
        Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar2.TabIndex = 1
        Me.RibbonBar2.Text = "Gestión de Productos"
        '
        '
        '
        Me.RibbonBar2.TitleStyle.Class = ""
        Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.TitleStyleMouseOver.Class = ""
        Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btMarcas
        '
        Me.btMarcas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btMarcas.Enabled = False
        Me.btMarcas.Image = Global.appFacturacion.My.Resources.Resources.Marca
        Me.btMarcas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btMarcas.Name = "btMarcas"
        Me.btMarcas.SubItemsExpandWidth = 14
        Me.btMarcas.Text = "Edición de Concentración"
        '
        'btUnidadMedida
        '
        Me.btUnidadMedida.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btUnidadMedida.Enabled = False
        Me.btUnidadMedida.Image = Global.appFacturacion.My.Resources.Resources.UnidadMedida
        Me.btUnidadMedida.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btUnidadMedida.Name = "btUnidadMedida"
        Me.btUnidadMedida.SubItemsExpandWidth = 14
        Me.btUnidadMedida.Text = "Edición de Medidas"
        '
        'btPresentacion
        '
        Me.btPresentacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btPresentacion.Enabled = False
        Me.btPresentacion.Image = Global.appFacturacion.My.Resources.Resources.Laboratorio
        Me.btPresentacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btPresentacion.Name = "btPresentacion"
        Me.btPresentacion.SubItemsExpandWidth = 14
        Me.btPresentacion.Text = "Edición de Presentación"
        '
        'btLaboratorio
        '
        Me.btLaboratorio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btLaboratorio.Enabled = False
        Me.btLaboratorio.Image = Global.appFacturacion.My.Resources.Resources.Presentacion
        Me.btLaboratorio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btLaboratorio.Name = "btLaboratorio"
        Me.btLaboratorio.SubItemsExpandWidth = 14
        Me.btLaboratorio.Text = "Edición de Laboratorio"
        '
        'btProductos
        '
        Me.btProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btProductos.Enabled = False
        Me.btProductos.Image = Global.appFacturacion.My.Resources.Resources.Producto
        Me.btProductos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btProductos.Name = "btProductos"
        Me.btProductos.SubItemsExpandWidth = 14
        Me.btProductos.Text = "Edición de Productos"
        '
        'btBusquedaProductos
        '
        Me.btBusquedaProductos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaProductos.Enabled = False
        Me.btBusquedaProductos.Image = Global.appFacturacion.My.Resources.Resources.BusquedaProducto
        Me.btBusquedaProductos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaProductos.Name = "btBusquedaProductos"
        Me.btBusquedaProductos.SubItemsExpandWidth = 14
        Me.btBusquedaProductos.Text = "Búsqueda de Productos"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.Class = ""
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btEmpresa, Me.btBodega, Me.btSerie})
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(206, 112)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 0
        Me.RibbonBar1.Text = "Administración"
        '
        '
        '
        Me.RibbonBar1.TitleStyle.Class = ""
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.Class = ""
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btEmpresa
        '
        Me.btEmpresa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btEmpresa.Enabled = False
        Me.btEmpresa.Image = Global.appFacturacion.My.Resources.Resources.Empresa
        Me.btEmpresa.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btEmpresa.Name = "btEmpresa"
        Me.btEmpresa.SubItemsExpandWidth = 14
        Me.btEmpresa.Text = "Datos de la Empresa"
        '
        'btBodega
        '
        Me.btBodega.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBodega.Enabled = False
        Me.btBodega.Image = Global.appFacturacion.My.Resources.Resources.Bodega
        Me.btBodega.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBodega.Name = "btBodega"
        Me.btBodega.SubItemsExpandWidth = 14
        Me.btBodega.Text = "Sucursal / Bodegas"
        '
        'btSerie
        '
        Me.btSerie.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btSerie.Enabled = False
        Me.btSerie.Image = Global.appFacturacion.My.Resources.Resources.Serie
        Me.btSerie.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btSerie.Name = "btSerie"
        Me.btSerie.SubItemsExpandWidth = 14
        Me.btSerie.Text = "Series de Documentos"
        '
        'RibbonPanel3
        '
        Me.RibbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel3.Controls.Add(Me.RibbonBar24)
        Me.RibbonPanel3.Controls.Add(Me.RibbonBar10)
        Me.RibbonPanel3.Controls.Add(Me.RibbonBar8)
        Me.RibbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel3.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel3.Name = "RibbonPanel3"
        Me.RibbonPanel3.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel3.Size = New System.Drawing.Size(1026, 115)
        '
        '
        '
        Me.RibbonPanel3.Style.Class = ""
        Me.RibbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel3.StyleMouseDown.Class = ""
        Me.RibbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel3.StyleMouseOver.Class = ""
        Me.RibbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel3.TabIndex = 3
        Me.RibbonPanel3.Visible = False
        '
        'RibbonBar24
        '
        Me.RibbonBar24.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar24.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar24.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar24.BackgroundStyle.Class = ""
        Me.RibbonBar24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar24.ContainerControlProcessDialogKey = True
        Me.RibbonBar24.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar24.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btPrinterSetting, Me.btServidor, Me.btRegistro, Me.btAyuda, Me.btAcercaDe})
        Me.RibbonBar24.Location = New System.Drawing.Point(221, 0)
        Me.RibbonBar24.Name = "RibbonBar24"
        Me.RibbonBar24.Size = New System.Drawing.Size(331, 112)
        Me.RibbonBar24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar24.TabIndex = 3
        Me.RibbonBar24.Text = "Ayuda del Sistema"
        '
        '
        '
        Me.RibbonBar24.TitleStyle.Class = ""
        Me.RibbonBar24.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar24.TitleStyleMouseOver.Class = ""
        Me.RibbonBar24.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btPrinterSetting
        '
        Me.btPrinterSetting.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btPrinterSetting.Image = Global.appFacturacion.My.Resources.Resources.PrinterSetting
        Me.btPrinterSetting.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btPrinterSetting.Name = "btPrinterSetting"
        Me.btPrinterSetting.SubItemsExpandWidth = 14
        Me.btPrinterSetting.Text = "Configuración de Impresora"
        '
        'btServidor
        '
        Me.btServidor.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btServidor.Enabled = False
        Me.btServidor.Image = Global.appFacturacion.My.Resources.Resources.Servidor
        Me.btServidor.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btServidor.Name = "btServidor"
        Me.btServidor.SubItemsExpandWidth = 14
        Me.btServidor.Text = "Configurar Servidor"
        '
        'btRegistro
        '
        Me.btRegistro.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btRegistro.Image = Global.appFacturacion.My.Resources.Resources.Registrar
        Me.btRegistro.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btRegistro.Name = "btRegistro"
        Me.btRegistro.SubItemsExpandWidth = 14
        Me.btRegistro.Text = "Registrar el Software"
        '
        'btAyuda
        '
        Me.btAyuda.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btAyuda.Image = Global.appFacturacion.My.Resources.Resources.Ayuda
        Me.btAyuda.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btAyuda.Name = "btAyuda"
        Me.btAyuda.SubItemsExpandWidth = 14
        Me.btAyuda.Text = "Ayuda del Software"
        '
        'btAcercaDe
        '
        Me.btAcercaDe.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btAcercaDe.Image = Global.appFacturacion.My.Resources.Resources.Acerca
        Me.btAcercaDe.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btAcercaDe.Name = "btAcercaDe"
        Me.btAcercaDe.SubItemsExpandWidth = 14
        Me.btAcercaDe.Text = "Acerca del Software"
        '
        'RibbonBar10
        '
        Me.RibbonBar10.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar10.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar10.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar10.BackgroundStyle.Class = ""
        Me.RibbonBar10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar10.ContainerControlProcessDialogKey = True
        Me.RibbonBar10.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar10.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCreateBackup, Me.btRestoreDatabase})
        Me.RibbonBar10.Location = New System.Drawing.Point(69, 0)
        Me.RibbonBar10.Name = "RibbonBar10"
        Me.RibbonBar10.Size = New System.Drawing.Size(152, 112)
        Me.RibbonBar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar10.TabIndex = 2
        Me.RibbonBar10.Text = "Copias de Seguridad"
        '
        '
        '
        Me.RibbonBar10.TitleStyle.Class = ""
        Me.RibbonBar10.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar10.TitleStyleMouseOver.Class = ""
        Me.RibbonBar10.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btCreateBackup
        '
        Me.btCreateBackup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCreateBackup.Enabled = False
        Me.btCreateBackup.Image = Global.appFacturacion.My.Resources.Resources.CrearRespaldo
        Me.btCreateBackup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCreateBackup.Name = "btCreateBackup"
        Me.btCreateBackup.SubItemsExpandWidth = 14
        Me.btCreateBackup.Text = "Respaldar base de datos"
        '
        'btRestoreDatabase
        '
        Me.btRestoreDatabase.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btRestoreDatabase.Enabled = False
        Me.btRestoreDatabase.Image = Global.appFacturacion.My.Resources.Resources.Restaurar
        Me.btRestoreDatabase.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btRestoreDatabase.Name = "btRestoreDatabase"
        Me.btRestoreDatabase.SubItemsExpandWidth = 14
        Me.btRestoreDatabase.Text = "Restaurar Base de Datos"
        '
        'RibbonBar8
        '
        Me.RibbonBar8.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar8.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar8.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.BackgroundStyle.Class = ""
        Me.RibbonBar8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar8.ContainerControlProcessDialogKey = True
        Me.RibbonBar8.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btLogo})
        Me.RibbonBar8.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar8.Name = "RibbonBar8"
        Me.RibbonBar8.Size = New System.Drawing.Size(66, 112)
        Me.RibbonBar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar8.TabIndex = 1
        Me.RibbonBar8.Text = "Empresa"
        '
        '
        '
        Me.RibbonBar8.TitleStyle.Class = ""
        Me.RibbonBar8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.TitleStyleMouseOver.Class = ""
        Me.RibbonBar8.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar8.Visible = False
        '
        'btLogo
        '
        Me.btLogo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btLogo.Image = Global.appFacturacion.My.Resources.Resources.Logo
        Me.btLogo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btLogo.Name = "btLogo"
        Me.btLogo.SubItemsExpandWidth = 14
        Me.btLogo.Text = "Logo de Empresa"
        '
        'RibbonPanel2
        '
        Me.RibbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar25)
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar15)
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar5)
        Me.RibbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel2.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel2.Name = "RibbonPanel2"
        Me.RibbonPanel2.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel2.Size = New System.Drawing.Size(1026, 115)
        '
        '
        '
        Me.RibbonPanel2.Style.Class = ""
        Me.RibbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseDown.Class = ""
        Me.RibbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseOver.Class = ""
        Me.RibbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel2.TabIndex = 2
        Me.RibbonPanel2.Visible = False
        '
        'RibbonBar25
        '
        Me.RibbonBar25.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar25.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar25.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar25.BackgroundStyle.Class = ""
        Me.RibbonBar25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar25.ContainerControlProcessDialogKey = True
        Me.RibbonBar25.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar25.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btKardex, Me.btControlExistencia, Me.btProductWithApplication, Me.btValuacionInventario})
        Me.RibbonBar25.Location = New System.Drawing.Point(598, 0)
        Me.RibbonBar25.Name = "RibbonBar25"
        Me.RibbonBar25.Size = New System.Drawing.Size(280, 112)
        Me.RibbonBar25.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar25.TabIndex = 3
        Me.RibbonBar25.Text = "Reportes de Inventario"
        '
        '
        '
        Me.RibbonBar25.TitleStyle.Class = ""
        Me.RibbonBar25.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar25.TitleStyleMouseOver.Class = ""
        Me.RibbonBar25.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btKardex
        '
        Me.btKardex.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btKardex.Enabled = False
        Me.btKardex.Image = Global.appFacturacion.My.Resources.Resources.Kardex
        Me.btKardex.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btKardex.Name = "btKardex"
        Me.btKardex.SubItemsExpandWidth = 14
        Me.btKardex.Text = "Hoja de Kardex"
        '
        'btControlExistencia
        '
        Me.btControlExistencia.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btControlExistencia.Enabled = False
        Me.btControlExistencia.Image = Global.appFacturacion.My.Resources.Resources.ControlExistencia
        Me.btControlExistencia.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btControlExistencia.Name = "btControlExistencia"
        Me.btControlExistencia.SubItemsExpandWidth = 14
        Me.btControlExistencia.Text = "Control de Existencia"
        '
        'btProductWithApplication
        '
        Me.btProductWithApplication.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btProductWithApplication.Enabled = False
        Me.btProductWithApplication.Image = Global.appFacturacion.My.Resources.Resources.ValuacionInventario
        Me.btProductWithApplication.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btProductWithApplication.Name = "btProductWithApplication"
        Me.btProductWithApplication.SubItemsExpandWidth = 14
        Me.btProductWithApplication.Text = "Control de Aplicaciones"
        '
        'btValuacionInventario
        '
        Me.btValuacionInventario.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btValuacionInventario.Enabled = False
        Me.btValuacionInventario.Image = Global.appFacturacion.My.Resources.Resources.ValuacionInventario
        Me.btValuacionInventario.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btValuacionInventario.Name = "btValuacionInventario"
        Me.btValuacionInventario.SubItemsExpandWidth = 14
        Me.btValuacionInventario.Text = "Valuación de Inventario"
        '
        'RibbonBar15
        '
        Me.RibbonBar15.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar15.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar15.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar15.BackgroundStyle.Class = ""
        Me.RibbonBar15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar15.ContainerControlProcessDialogKey = True
        Me.RibbonBar15.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar15.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btConsignar, Me.btBusquedaConsignacion, Me.btDesconsignar, Me.btBusquedaDesconsignacion, Me.btReporteConsignacion})
        Me.RibbonBar15.Location = New System.Drawing.Point(429, 0)
        Me.RibbonBar15.Name = "RibbonBar15"
        Me.RibbonBar15.Size = New System.Drawing.Size(169, 112)
        Me.RibbonBar15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar15.TabIndex = 2
        Me.RibbonBar15.Text = "Consignaciones"
        '
        '
        '
        Me.RibbonBar15.TitleStyle.Class = ""
        Me.RibbonBar15.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar15.TitleStyleMouseOver.Class = ""
        Me.RibbonBar15.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar15.Visible = False
        '
        'btConsignar
        '
        Me.btConsignar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btConsignar.Enabled = False
        Me.btConsignar.Image = Global.appFacturacion.My.Resources.Resources.Consignar
        Me.btConsignar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btConsignar.Name = "btConsignar"
        Me.btConsignar.Text = "Consignar Productos"
        '
        'btBusquedaConsignacion
        '
        Me.btBusquedaConsignacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaConsignacion.Enabled = False
        Me.btBusquedaConsignacion.Image = Global.appFacturacion.My.Resources.Resources.BusquedaConsignacion
        Me.btBusquedaConsignacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaConsignacion.Name = "btBusquedaConsignacion"
        Me.btBusquedaConsignacion.Text = "Busqueda de Consignaciones"
        '
        'btDesconsignar
        '
        Me.btDesconsignar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btDesconsignar.Enabled = False
        Me.btDesconsignar.Image = Global.appFacturacion.My.Resources.Resources.Desconsignar
        Me.btDesconsignar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btDesconsignar.Name = "btDesconsignar"
        Me.btDesconsignar.Text = "Desconsignar productos"
        '
        'btBusquedaDesconsignacion
        '
        Me.btBusquedaDesconsignacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaDesconsignacion.Enabled = False
        Me.btBusquedaDesconsignacion.Image = Global.appFacturacion.My.Resources.Resources.BusquedaConsignacion
        Me.btBusquedaDesconsignacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaDesconsignacion.Name = "btBusquedaDesconsignacion"
        Me.btBusquedaDesconsignacion.Text = "Busqueda de Desconsignaciones"
        '
        'btReporteConsignacion
        '
        Me.btReporteConsignacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btReporteConsignacion.Enabled = False
        Me.btReporteConsignacion.Image = Global.appFacturacion.My.Resources.Resources.ReporteConsignacion
        Me.btReporteConsignacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btReporteConsignacion.Name = "btReporteConsignacion"
        Me.btReporteConsignacion.Text = "Reporte de Consignacion"
        '
        'RibbonBar5
        '
        Me.RibbonBar5.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar5.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.BackgroundStyle.Class = ""
        Me.RibbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar5.ContainerControlProcessDialogKey = True
        Me.RibbonBar5.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btEntradas, Me.btBusquedaEntradas, Me.btSalidas, Me.btBusquedaSalida, Me.btTraslados, Me.btBusquedaTraslado})
        Me.RibbonBar5.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar5.Name = "RibbonBar5"
        Me.RibbonBar5.Size = New System.Drawing.Size(426, 112)
        Me.RibbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar5.TabIndex = 1
        Me.RibbonBar5.Text = "Entradas y Salidas"
        '
        '
        '
        Me.RibbonBar5.TitleStyle.Class = ""
        Me.RibbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.TitleStyleMouseOver.Class = ""
        Me.RibbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btEntradas
        '
        Me.btEntradas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btEntradas.Enabled = False
        Me.btEntradas.Image = Global.appFacturacion.My.Resources.Resources.Entrada
        Me.btEntradas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btEntradas.Name = "btEntradas"
        Me.btEntradas.SubItemsExpandWidth = 14
        Me.btEntradas.Text = "Entradas de Productos"
        '
        'btBusquedaEntradas
        '
        Me.btBusquedaEntradas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaEntradas.Enabled = False
        Me.btBusquedaEntradas.Image = Global.appFacturacion.My.Resources.Resources.BusquedaEntrada
        Me.btBusquedaEntradas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaEntradas.Name = "btBusquedaEntradas"
        Me.btBusquedaEntradas.SubItemsExpandWidth = 14
        Me.btBusquedaEntradas.Text = "Busqueda de Entradas"
        '
        'btSalidas
        '
        Me.btSalidas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btSalidas.Enabled = False
        Me.btSalidas.Image = Global.appFacturacion.My.Resources.Resources.Salidas
        Me.btSalidas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btSalidas.Name = "btSalidas"
        Me.btSalidas.SubItemsExpandWidth = 14
        Me.btSalidas.Text = "Salidas de Productos"
        '
        'btBusquedaSalida
        '
        Me.btBusquedaSalida.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaSalida.Enabled = False
        Me.btBusquedaSalida.Image = Global.appFacturacion.My.Resources.Resources.BusquedaSalida
        Me.btBusquedaSalida.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaSalida.Name = "btBusquedaSalida"
        Me.btBusquedaSalida.SubItemsExpandWidth = 14
        Me.btBusquedaSalida.Text = "Busqueda de Salidas"
        '
        'btTraslados
        '
        Me.btTraslados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btTraslados.Enabled = False
        Me.btTraslados.Image = Global.appFacturacion.My.Resources.Resources.Traslados
        Me.btTraslados.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btTraslados.Name = "btTraslados"
        Me.btTraslados.SubItemsExpandWidth = 14
        Me.btTraslados.Text = "Traslados de Bodega"
        '
        'btBusquedaTraslado
        '
        Me.btBusquedaTraslado.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaTraslado.Enabled = False
        Me.btBusquedaTraslado.Image = Global.appFacturacion.My.Resources.Resources.BusquedaTraslado
        Me.btBusquedaTraslado.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaTraslado.Name = "btBusquedaTraslado"
        Me.btBusquedaTraslado.SubItemsExpandWidth = 14
        Me.btBusquedaTraslado.Text = "Busqueda de Traslados"
        '
        'RibbonPanel7
        '
        Me.RibbonPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel7.Controls.Add(Me.RibbonBar7)
        Me.RibbonPanel7.Controls.Add(Me.RibbonBar16)
        Me.RibbonPanel7.Controls.Add(Me.RibbonBar13)
        Me.RibbonPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel7.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel7.Name = "RibbonPanel7"
        Me.RibbonPanel7.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel7.Size = New System.Drawing.Size(1026, 115)
        '
        '
        '
        Me.RibbonPanel7.Style.Class = ""
        Me.RibbonPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel7.StyleMouseDown.Class = ""
        Me.RibbonPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel7.StyleMouseOver.Class = ""
        Me.RibbonPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel7.TabIndex = 7
        Me.RibbonPanel7.Visible = False
        '
        'RibbonBar7
        '
        Me.RibbonBar7.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar7.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar7.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar7.BackgroundStyle.Class = ""
        Me.RibbonBar7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar7.ContainerControlProcessDialogKey = True
        Me.RibbonBar7.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btInformeVentaDetalle, Me.btGraficosVenta})
        Me.RibbonBar7.Location = New System.Drawing.Point(655, 0)
        Me.RibbonBar7.Name = "RibbonBar7"
        Me.RibbonBar7.Size = New System.Drawing.Size(164, 112)
        Me.RibbonBar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar7.TabIndex = 5
        Me.RibbonBar7.Text = "Informe de ventas"
        '
        '
        '
        Me.RibbonBar7.TitleStyle.Class = ""
        Me.RibbonBar7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar7.TitleStyleMouseOver.Class = ""
        Me.RibbonBar7.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btInformeVentaDetalle
        '
        Me.btInformeVentaDetalle.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btInformeVentaDetalle.Enabled = False
        Me.btInformeVentaDetalle.Image = Global.appFacturacion.My.Resources.Resources.InformeVentaDetalle
        Me.btInformeVentaDetalle.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btInformeVentaDetalle.Name = "btInformeVentaDetalle"
        Me.btInformeVentaDetalle.SubItemsExpandWidth = 14
        Me.btInformeVentaDetalle.Text = "Productos Vendidos"
        '
        'btGraficosVenta
        '
        Me.btGraficosVenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btGraficosVenta.Image = Global.appFacturacion.My.Resources.Resources.Dashboard
        Me.btGraficosVenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btGraficosVenta.Name = "btGraficosVenta"
        Me.btGraficosVenta.SubItemsExpandWidth = 14
        Me.btGraficosVenta.Text = "Gráficos de Ventas"
        Me.btGraficosVenta.Visible = False
        '
        'RibbonBar16
        '
        Me.RibbonBar16.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar16.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar16.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar16.BackgroundStyle.Class = ""
        Me.RibbonBar16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar16.ContainerControlProcessDialogKey = True
        Me.RibbonBar16.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar16.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btVenta, Me.btBusquedaFactura, Me.btDevolucionesVentas, Me.btBusquedaDevolucion, Me.btCotizar, Me.btBusquedaCotizacion})
        Me.RibbonBar16.Location = New System.Drawing.Point(203, 0)
        Me.RibbonBar16.Name = "RibbonBar16"
        Me.RibbonBar16.Size = New System.Drawing.Size(452, 112)
        Me.RibbonBar16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar16.TabIndex = 2
        Me.RibbonBar16.Text = "Facturación"
        '
        '
        '
        Me.RibbonBar16.TitleStyle.Class = ""
        Me.RibbonBar16.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar16.TitleStyleMouseOver.Class = ""
        Me.RibbonBar16.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btVenta
        '
        Me.btVenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btVenta.Enabled = False
        Me.btVenta.Image = Global.appFacturacion.My.Resources.Resources.Venta
        Me.btVenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btVenta.Name = "btVenta"
        Me.btVenta.SubItemsExpandWidth = 14
        Me.btVenta.Text = "Facturar Productos"
        '
        'btBusquedaFactura
        '
        Me.btBusquedaFactura.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaFactura.Enabled = False
        Me.btBusquedaFactura.Image = Global.appFacturacion.My.Resources.Resources.BusquedaVenta
        Me.btBusquedaFactura.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaFactura.Name = "btBusquedaFactura"
        Me.btBusquedaFactura.SubItemsExpandWidth = 14
        Me.btBusquedaFactura.Text = "Busqueda de Facturas"
        '
        'btDevolucionesVentas
        '
        Me.btDevolucionesVentas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btDevolucionesVentas.Enabled = False
        Me.btDevolucionesVentas.Image = Global.appFacturacion.My.Resources.Resources.Devolucion
        Me.btDevolucionesVentas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btDevolucionesVentas.Name = "btDevolucionesVentas"
        Me.btDevolucionesVentas.SubItemsExpandWidth = 14
        Me.btDevolucionesVentas.Text = "Devoluciones de Ventas"
        '
        'btBusquedaDevolucion
        '
        Me.btBusquedaDevolucion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaDevolucion.Enabled = False
        Me.btBusquedaDevolucion.Image = Global.appFacturacion.My.Resources.Resources.BusquedaDevolucion
        Me.btBusquedaDevolucion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaDevolucion.Name = "btBusquedaDevolucion"
        Me.btBusquedaDevolucion.SubItemsExpandWidth = 14
        Me.btBusquedaDevolucion.Text = "Busqueda de Devoluciones"
        '
        'btCotizar
        '
        Me.btCotizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCotizar.Enabled = False
        Me.btCotizar.Image = Global.appFacturacion.My.Resources.Resources.Cotizacion
        Me.btCotizar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCotizar.Name = "btCotizar"
        Me.btCotizar.SubItemsExpandWidth = 14
        Me.btCotizar.Text = "Cotizaciónes / Proformas"
        '
        'btBusquedaCotizacion
        '
        Me.btBusquedaCotizacion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaCotizacion.Enabled = False
        Me.btBusquedaCotizacion.Image = Global.appFacturacion.My.Resources.Resources.BusquedaCotizacion
        Me.btBusquedaCotizacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaCotizacion.Name = "btBusquedaCotizacion"
        Me.btBusquedaCotizacion.SubItemsExpandWidth = 14
        Me.btBusquedaCotizacion.Text = "Busqueda de Cotizaciones"
        '
        'RibbonBar13
        '
        Me.RibbonBar13.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar13.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar13.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar13.BackgroundStyle.Class = ""
        Me.RibbonBar13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar13.ContainerControlProcessDialogKey = True
        Me.RibbonBar13.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar13.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btClientes, Me.btBusquedaClientes, Me.btEstadoCuenta})
        Me.RibbonBar13.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar13.Name = "RibbonBar13"
        Me.RibbonBar13.Size = New System.Drawing.Size(200, 112)
        Me.RibbonBar13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar13.TabIndex = 1
        Me.RibbonBar13.Text = "Clientes Potenciales"
        '
        '
        '
        Me.RibbonBar13.TitleStyle.Class = ""
        Me.RibbonBar13.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar13.TitleStyleMouseOver.Class = ""
        Me.RibbonBar13.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btClientes
        '
        Me.btClientes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btClientes.Enabled = False
        Me.btClientes.Image = Global.appFacturacion.My.Resources.Resources.Cliente
        Me.btClientes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btClientes.Name = "btClientes"
        Me.btClientes.SubItemsExpandWidth = 14
        Me.btClientes.Text = "Edición de Clientes"
        '
        'btBusquedaClientes
        '
        Me.btBusquedaClientes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaClientes.Enabled = False
        Me.btBusquedaClientes.Image = Global.appFacturacion.My.Resources.Resources.BusquedaCliente
        Me.btBusquedaClientes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaClientes.Name = "btBusquedaClientes"
        Me.btBusquedaClientes.SubItemsExpandWidth = 14
        Me.btBusquedaClientes.Text = "Búsqueda de Clientes"
        '
        'btEstadoCuenta
        '
        Me.btEstadoCuenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btEstadoCuenta.Enabled = False
        Me.btEstadoCuenta.Image = Global.appFacturacion.My.Resources.Resources.EstadoCuentaCliente
        Me.btEstadoCuenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btEstadoCuenta.Name = "btEstadoCuenta"
        Me.btEstadoCuenta.SubItemsExpandWidth = 14
        Me.btEstadoCuenta.Text = "Estado de cuenta"
        '
        'RibbonPanel8
        '
        Me.RibbonPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel8.Controls.Add(Me.RibbonBar19)
        Me.RibbonPanel8.Controls.Add(Me.RibbonBar18)
        Me.RibbonPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel8.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel8.Name = "RibbonPanel8"
        Me.RibbonPanel8.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel8.Size = New System.Drawing.Size(1026, 115)
        '
        '
        '
        Me.RibbonPanel8.Style.Class = ""
        Me.RibbonPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel8.StyleMouseDown.Class = ""
        Me.RibbonPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel8.StyleMouseOver.Class = ""
        Me.RibbonPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel8.TabIndex = 10
        Me.RibbonPanel8.Visible = False
        '
        'RibbonBar19
        '
        Me.RibbonBar19.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar19.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar19.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar19.BackgroundStyle.Class = ""
        Me.RibbonBar19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar19.ContainerControlProcessDialogKey = True
        Me.RibbonBar19.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar19.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btProductoOferta, Me.ButtonItem8, Me.ButtonItem7})
        Me.RibbonBar19.Location = New System.Drawing.Point(172, 0)
        Me.RibbonBar19.Name = "RibbonBar19"
        Me.RibbonBar19.Size = New System.Drawing.Size(213, 112)
        Me.RibbonBar19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar19.TabIndex = 1
        Me.RibbonBar19.Text = "Ofertas"
        '
        '
        '
        Me.RibbonBar19.TitleStyle.Class = ""
        Me.RibbonBar19.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar19.TitleStyleMouseOver.Class = ""
        Me.RibbonBar19.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btProductoOferta
        '
        Me.btProductoOferta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btProductoOferta.Enabled = False
        Me.btProductoOferta.Image = Global.appFacturacion.My.Resources.Resources.ProductoOferta
        Me.btProductoOferta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btProductoOferta.Name = "btProductoOferta"
        Me.btProductoOferta.SubItemsExpandWidth = 14
        Me.btProductoOferta.Text = "Ofertas de Productos"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem8.Enabled = False
        Me.ButtonItem8.Image = Global.appFacturacion.My.Resources.Resources.ClienteOferta
        Me.ButtonItem8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.SubItemsExpandWidth = 14
        Me.ButtonItem8.Text = "Ofertas de Clientes"
        Me.ButtonItem8.Visible = False
        '
        'ButtonItem7
        '
        Me.ButtonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem7.Enabled = False
        Me.ButtonItem7.Image = Global.appFacturacion.My.Resources.Resources.AnalisisVenta
        Me.ButtonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.SubItemsExpandWidth = 14
        Me.ButtonItem7.Text = "Estadísticas de Ventas"
        '
        'RibbonBar18
        '
        Me.RibbonBar18.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar18.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar18.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar18.BackgroundStyle.Class = ""
        Me.RibbonBar18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar18.ContainerControlProcessDialogKey = True
        Me.RibbonBar18.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar18.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem5, Me.ButtonItem6})
        Me.RibbonBar18.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar18.Name = "RibbonBar18"
        Me.RibbonBar18.Size = New System.Drawing.Size(169, 112)
        Me.RibbonBar18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar18.TabIndex = 0
        Me.RibbonBar18.Text = "Marketing Directo"
        '
        '
        '
        Me.RibbonBar18.TitleStyle.Class = ""
        Me.RibbonBar18.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar18.TitleStyleMouseOver.Class = ""
        Me.RibbonBar18.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar18.Visible = False
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem5.Enabled = False
        Me.ButtonItem5.Image = Global.appFacturacion.My.Resources.Resources.Emailing
        Me.ButtonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.SubItemsExpandWidth = 14
        Me.ButtonItem5.Text = "Gestión de E-Mailing"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.Enabled = False
        Me.ButtonItem6.Image = Global.appFacturacion.My.Resources.Resources.Agenda
        Me.ButtonItem6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.SubItemsExpandWidth = 14
        Me.ButtonItem6.Text = "Agenda de los Clientes"
        '
        'RibbonPanel6
        '
        Me.RibbonPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel6.Controls.Add(Me.RibbonBar26)
        Me.RibbonPanel6.Controls.Add(Me.RibbonBar4)
        Me.RibbonPanel6.Controls.Add(Me.RibbonBar3)
        Me.RibbonPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel6.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel6.Name = "RibbonPanel6"
        Me.RibbonPanel6.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel6.Size = New System.Drawing.Size(1026, 115)
        '
        '
        '
        Me.RibbonPanel6.Style.Class = ""
        Me.RibbonPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel6.StyleMouseDown.Class = ""
        Me.RibbonPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel6.StyleMouseOver.Class = ""
        Me.RibbonPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel6.TabIndex = 6
        Me.RibbonPanel6.Visible = False
        '
        'RibbonBar26
        '
        Me.RibbonBar26.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar26.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar26.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar26.BackgroundStyle.Class = ""
        Me.RibbonBar26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar26.ContainerControlProcessDialogKey = True
        Me.RibbonBar26.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar26.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btProductosComprados})
        Me.RibbonBar26.Location = New System.Drawing.Point(550, 0)
        Me.RibbonBar26.Name = "RibbonBar26"
        Me.RibbonBar26.Size = New System.Drawing.Size(111, 112)
        Me.RibbonBar26.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar26.TabIndex = 6
        Me.RibbonBar26.Text = "Informe de Compras"
        '
        '
        '
        Me.RibbonBar26.TitleStyle.Class = ""
        Me.RibbonBar26.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar26.TitleStyleMouseOver.Class = ""
        Me.RibbonBar26.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btProductosComprados
        '
        Me.btProductosComprados.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btProductosComprados.Enabled = False
        Me.btProductosComprados.Image = Global.appFacturacion.My.Resources.Resources.InformeVentaDetalle
        Me.btProductosComprados.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btProductosComprados.Name = "btProductosComprados"
        Me.btProductosComprados.SubItemsExpandWidth = 14
        Me.btProductosComprados.Text = "Compras Detalladas"
        '
        'RibbonBar4
        '
        Me.RibbonBar4.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar4.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.BackgroundStyle.Class = ""
        Me.RibbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar4.ContainerControlProcessDialogKey = True
        Me.RibbonBar4.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCompra, Me.btBusquedaCompra, Me.btDevolucionCompra, Me.btBusquedaDevolucionesCompras})
        Me.RibbonBar4.Location = New System.Drawing.Point(221, 0)
        Me.RibbonBar4.Name = "RibbonBar4"
        Me.RibbonBar4.Size = New System.Drawing.Size(329, 112)
        Me.RibbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar4.TabIndex = 4
        Me.RibbonBar4.Text = "Compras"
        '
        '
        '
        Me.RibbonBar4.TitleStyle.Class = ""
        Me.RibbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.TitleStyleMouseOver.Class = ""
        Me.RibbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btCompra
        '
        Me.btCompra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCompra.Enabled = False
        Me.btCompra.Image = Global.appFacturacion.My.Resources.Resources.Compra
        Me.btCompra.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCompra.Name = "btCompra"
        Me.btCompra.SubItemsExpandWidth = 14
        Me.btCompra.Text = "Compras de Productos"
        '
        'btBusquedaCompra
        '
        Me.btBusquedaCompra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaCompra.Enabled = False
        Me.btBusquedaCompra.Image = Global.appFacturacion.My.Resources.Resources.BusquedaCompra
        Me.btBusquedaCompra.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaCompra.Name = "btBusquedaCompra"
        Me.btBusquedaCompra.SubItemsExpandWidth = 14
        Me.btBusquedaCompra.Text = "Busqueda de Compras"
        '
        'btDevolucionCompra
        '
        Me.btDevolucionCompra.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btDevolucionCompra.Enabled = False
        Me.btDevolucionCompra.Image = Global.appFacturacion.My.Resources.Resources.DevolucionCompra
        Me.btDevolucionCompra.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btDevolucionCompra.Name = "btDevolucionCompra"
        Me.btDevolucionCompra.Text = "Devoluciones de Compras"
        '
        'btBusquedaDevolucionesCompras
        '
        Me.btBusquedaDevolucionesCompras.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaDevolucionesCompras.Enabled = False
        Me.btBusquedaDevolucionesCompras.Image = Global.appFacturacion.My.Resources.Resources.BusquedaDevolucionCompra
        Me.btBusquedaDevolucionesCompras.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaDevolucionesCompras.Name = "btBusquedaDevolucionesCompras"
        Me.btBusquedaDevolucionesCompras.Text = "Busqueda de Devoluciones"
        '
        'RibbonBar3
        '
        Me.RibbonBar3.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar3.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.BackgroundStyle.Class = ""
        Me.RibbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.ContainerControlProcessDialogKey = True
        Me.RibbonBar3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btProveedores, Me.btBusquedaProveedores, Me.btCompraEstadoCuenta})
        Me.RibbonBar3.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar3.Name = "RibbonBar3"
        Me.RibbonBar3.Size = New System.Drawing.Size(218, 112)
        Me.RibbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar3.TabIndex = 3
        Me.RibbonBar3.Text = "Gestión de proveedores"
        '
        '
        '
        Me.RibbonBar3.TitleStyle.Class = ""
        Me.RibbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.TitleStyleMouseOver.Class = ""
        Me.RibbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btProveedores
        '
        Me.btProveedores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btProveedores.Enabled = False
        Me.btProveedores.Image = Global.appFacturacion.My.Resources.Resources.Proveedor
        Me.btProveedores.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btProveedores.Name = "btProveedores"
        Me.btProveedores.SubItemsExpandWidth = 14
        Me.btProveedores.Text = "Edición de Proveedores"
        '
        'btBusquedaProveedores
        '
        Me.btBusquedaProveedores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaProveedores.Enabled = False
        Me.btBusquedaProveedores.Image = Global.appFacturacion.My.Resources.Resources.BusquedaProveedor
        Me.btBusquedaProveedores.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaProveedores.Name = "btBusquedaProveedores"
        Me.btBusquedaProveedores.SubItemsExpandWidth = 14
        Me.btBusquedaProveedores.Text = "Búsqueda de Proveedores"
        '
        'btCompraEstadoCuenta
        '
        Me.btCompraEstadoCuenta.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCompraEstadoCuenta.Enabled = False
        Me.btCompraEstadoCuenta.Image = Global.appFacturacion.My.Resources.Resources.EstadoCuentaProveedor
        Me.btCompraEstadoCuenta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btCompraEstadoCuenta.Name = "btCompraEstadoCuenta"
        Me.btCompraEstadoCuenta.SubItemsExpandWidth = 14
        Me.btCompraEstadoCuenta.Text = "Estado de cuenta"
        '
        'RibbonPanel9
        '
        Me.RibbonPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel9.Controls.Add(Me.RibbonBar17)
        Me.RibbonPanel9.Controls.Add(Me.RibbonBar12)
        Me.RibbonPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel9.Location = New System.Drawing.Point(0, 0)
        Me.RibbonPanel9.Name = "RibbonPanel9"
        Me.RibbonPanel9.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel9.Size = New System.Drawing.Size(1034, 168)
        '
        '
        '
        Me.RibbonPanel9.Style.Class = ""
        Me.RibbonPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel9.StyleMouseDown.Class = ""
        Me.RibbonPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel9.StyleMouseOver.Class = ""
        Me.RibbonPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel9.TabIndex = 11
        Me.RibbonPanel9.Visible = False
        '
        'RibbonBar17
        '
        Me.RibbonBar17.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar17.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar17.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar17.BackgroundStyle.Class = ""
        Me.RibbonBar17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar17.ContainerControlProcessDialogKey = True
        Me.RibbonBar17.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar17.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btPlanilla, Me.btBusquedasPlanillas})
        Me.RibbonBar17.Location = New System.Drawing.Point(445, 0)
        Me.RibbonBar17.Name = "RibbonBar17"
        Me.RibbonBar17.Size = New System.Drawing.Size(162, 165)
        Me.RibbonBar17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar17.TabIndex = 2
        Me.RibbonBar17.Text = "Planillas"
        '
        '
        '
        Me.RibbonBar17.TitleStyle.Class = ""
        Me.RibbonBar17.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar17.TitleStyleMouseOver.Class = ""
        Me.RibbonBar17.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar17.Visible = False
        '
        'btPlanilla
        '
        Me.btPlanilla.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btPlanilla.Enabled = False
        Me.btPlanilla.Image = Global.appFacturacion.My.Resources.Resources.TrabajadorPlanilla
        Me.btPlanilla.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btPlanilla.Name = "btPlanilla"
        Me.btPlanilla.SubItemsExpandWidth = 14
        Me.btPlanilla.Text = "Planillas de Pago"
        '
        'btBusquedasPlanillas
        '
        Me.btBusquedasPlanillas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedasPlanillas.Enabled = False
        Me.btBusquedasPlanillas.Image = Global.appFacturacion.My.Resources.Resources.BusquedaTrabajadorPlanilla
        Me.btBusquedasPlanillas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedasPlanillas.Name = "btBusquedasPlanillas"
        Me.btBusquedasPlanillas.SubItemsExpandWidth = 14
        Me.btBusquedasPlanillas.Text = "Búsquedas de Planillas de Pago"
        '
        'RibbonBar12
        '
        Me.RibbonBar12.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar12.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBar12.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar12.BackgroundStyle.Class = ""
        Me.RibbonBar12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar12.ContainerControlProcessDialogKey = True
        Me.RibbonBar12.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar12.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btVendedores, Me.btBusquedaVendedor, Me.btTrabajoArea, Me.btBusquedaAreas, Me.btTrabajoPuestos, Me.btBusquedaPuestos})
        Me.RibbonBar12.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar12.Name = "RibbonBar12"
        Me.RibbonBar12.Size = New System.Drawing.Size(442, 165)
        Me.RibbonBar12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar12.TabIndex = 1
        Me.RibbonBar12.Text = "Gestión de Empleados"
        '
        '
        '
        Me.RibbonBar12.TitleStyle.Class = ""
        Me.RibbonBar12.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar12.TitleStyleMouseOver.Class = ""
        Me.RibbonBar12.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btVendedores
        '
        Me.btVendedores.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btVendedores.Enabled = False
        Me.btVendedores.Image = Global.appFacturacion.My.Resources.Resources.Vendedor
        Me.btVendedores.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btVendedores.Name = "btVendedores"
        Me.btVendedores.SubItemsExpandWidth = 14
        Me.btVendedores.Text = "Edición de Trabajadores"
        '
        'btBusquedaVendedor
        '
        Me.btBusquedaVendedor.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaVendedor.Enabled = False
        Me.btBusquedaVendedor.Image = Global.appFacturacion.My.Resources.Resources.BusquedaVendedor
        Me.btBusquedaVendedor.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaVendedor.Name = "btBusquedaVendedor"
        Me.btBusquedaVendedor.SubItemsExpandWidth = 14
        Me.btBusquedaVendedor.Text = "Búsqueda de Trabajadores"
        '
        'btTrabajoArea
        '
        Me.btTrabajoArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btTrabajoArea.Enabled = False
        Me.btTrabajoArea.Image = Global.appFacturacion.My.Resources.Resources.TrabajoArea
        Me.btTrabajoArea.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btTrabajoArea.Name = "btTrabajoArea"
        Me.btTrabajoArea.SubItemsExpandWidth = 14
        Me.btTrabajoArea.Text = "Edición de las Áreas"
        Me.btTrabajoArea.Visible = False
        '
        'btBusquedaAreas
        '
        Me.btBusquedaAreas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaAreas.Enabled = False
        Me.btBusquedaAreas.Image = Global.appFacturacion.My.Resources.Resources.TrabajoArea
        Me.btBusquedaAreas.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaAreas.Name = "btBusquedaAreas"
        Me.btBusquedaAreas.SubItemsExpandWidth = 14
        Me.btBusquedaAreas.Text = "Búsqueda de las Áreas"
        Me.btBusquedaAreas.Visible = False
        '
        'btTrabajoPuestos
        '
        Me.btTrabajoPuestos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btTrabajoPuestos.Enabled = False
        Me.btTrabajoPuestos.Image = Global.appFacturacion.My.Resources.Resources.TrabajoPuesto
        Me.btTrabajoPuestos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btTrabajoPuestos.Name = "btTrabajoPuestos"
        Me.btTrabajoPuestos.SubItemsExpandWidth = 14
        Me.btTrabajoPuestos.Text = "Edición de los Puestos"
        Me.btTrabajoPuestos.Visible = False
        '
        'btBusquedaPuestos
        '
        Me.btBusquedaPuestos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBusquedaPuestos.Enabled = False
        Me.btBusquedaPuestos.Image = Global.appFacturacion.My.Resources.Resources.TrabajoPuesto
        Me.btBusquedaPuestos.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btBusquedaPuestos.Name = "btBusquedaPuestos"
        Me.btBusquedaPuestos.SubItemsExpandWidth = 14
        Me.btBusquedaPuestos.Text = "Búsqueda de los Puestos"
        Me.btBusquedaPuestos.Visible = False
        '
        'mnuArchivo
        '
        Me.mnuArchivo.AutoExpandOnClick = True
        Me.mnuArchivo.CanCustomize = False
        Me.mnuArchivo.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
        Me.mnuArchivo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.mnuArchivo.ImagePaddingHorizontal = 0
        Me.mnuArchivo.ImagePaddingVertical = 0
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.ShowSubItems = False
        Me.mnuArchivo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.mnuArchivo.Text = "&ARCHIVO"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.Class = "RibbonFileMenuContainer"
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer2, Me.ItemContainer4})
        '
        'ItemContainer2
        '
        '
        '
        '
        Me.ItemContainer2.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer"
        Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.ItemSpacing = 0
        Me.ItemContainer2.Name = "ItemContainer2"
        Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer3})
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer"
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer3.MinimumSize = New System.Drawing.Size(120, 0)
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btUsuarios, Me.btInformeUsuarios, Me.btBitacora, Me.btCambiarPassword, Me.btCerrarSesion})
        '
        'btUsuarios
        '
        Me.btUsuarios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btUsuarios.Enabled = False
        Me.btUsuarios.Image = Global.appFacturacion.My.Resources.Resources.Usuarios
        Me.btUsuarios.Name = "btUsuarios"
        Me.btUsuarios.SubItemsExpandWidth = 24
        Me.btUsuarios.Text = "Usuarios"
        '
        'btInformeUsuarios
        '
        Me.btInformeUsuarios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btInformeUsuarios.Enabled = False
        Me.btInformeUsuarios.Image = Global.appFacturacion.My.Resources.Resources.UsuariosConsulta
        Me.btInformeUsuarios.Name = "btInformeUsuarios"
        Me.btInformeUsuarios.Text = "Consultar Usuarios"
        '
        'btBitacora
        '
        Me.btBitacora.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btBitacora.Enabled = False
        Me.btBitacora.Image = Global.appFacturacion.My.Resources.Resources.Log
        Me.btBitacora.Name = "btBitacora"
        Me.btBitacora.Text = "Bitacora de Usuarios"
        Me.btBitacora.Visible = False
        '
        'btCambiarPassword
        '
        Me.btCambiarPassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCambiarPassword.Image = Global.appFacturacion.My.Resources.Resources.Contraseña
        Me.btCambiarPassword.Name = "btCambiarPassword"
        Me.btCambiarPassword.Text = "Cambiar Contraseña"
        '
        'btCerrarSesion
        '
        Me.btCerrarSesion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCerrarSesion.Image = Global.appFacturacion.My.Resources.Resources.CerrarSesion
        Me.btCerrarSesion.Name = "btCerrarSesion"
        Me.btCerrarSesion.Text = "Cerrar sesión"
        '
        'ItemContainer4
        '
        '
        '
        '
        Me.ItemContainer4.BackgroundStyle.Class = "RibbonFileMenuBottomContainer"
        Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer4.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right
        Me.ItemContainer4.Name = "ItemContainer4"
        Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btSalir})
        '
        'btSalir
        '
        Me.btSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btSalir.Image = Global.appFacturacion.My.Resources.Resources.Cerrar_24_24
        Me.btSalir.Name = "btSalir"
        Me.btSalir.SubItemsExpandWidth = 24
        Me.btSalir.Text = "&Salir"
        '
        'mnuCatalogos
        '
        Me.mnuCatalogos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.mnuCatalogos.Name = "mnuCatalogos"
        Me.mnuCatalogos.Panel = Me.RibbonPanel1
        Me.mnuCatalogos.Text = "&EMPRESA"
        '
        'RibbonTabItem1
        '
        Me.RibbonTabItem1.Name = "RibbonTabItem1"
        Me.RibbonTabItem1.Panel = Me.RibbonPanel2
        Me.RibbonTabItem1.Text = "&INVENTARIO"
        '
        'RibbonTabItem6
        '
        Me.RibbonTabItem6.Name = "RibbonTabItem6"
        Me.RibbonTabItem6.Panel = Me.RibbonPanel7
        Me.RibbonTabItem6.Text = "VENTAS"
        '
        'RibbonTabItem5
        '
        Me.RibbonTabItem5.Name = "RibbonTabItem5"
        Me.RibbonTabItem5.Panel = Me.RibbonPanel6
        Me.RibbonTabItem5.Text = "COMPRAS"
        '
        'RibbonTabItem8
        '
        Me.RibbonTabItem8.Name = "RibbonTabItem8"
        Me.RibbonTabItem8.Panel = Me.RibbonPanel9
        Me.RibbonTabItem8.Text = "RECURSOS HUMANOS"
        '
        'RibbonTabItem7
        '
        Me.RibbonTabItem7.Name = "RibbonTabItem7"
        Me.RibbonTabItem7.Panel = Me.RibbonPanel8
        Me.RibbonTabItem7.Text = "MARKETING"
        Me.RibbonTabItem7.Visible = False
        '
        'RibbonTabItem3
        '
        Me.RibbonTabItem3.Checked = True
        Me.RibbonTabItem3.Name = "RibbonTabItem3"
        Me.RibbonTabItem3.Panel = Me.RibbonPanel4
        Me.RibbonTabItem3.Text = "CAJA"
        '
        'RibbonTabItem2
        '
        Me.RibbonTabItem2.Name = "RibbonTabItem2"
        Me.RibbonTabItem2.Panel = Me.RibbonPanel3
        Me.RibbonTabItem2.Text = "CON&FIGURACIÓN"
        '
        'btCreditos
        '
        Me.btCreditos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btCreditos.FontBold = True
        Me.btCreditos.ForeColor = System.Drawing.Color.Yellow
        Me.btCreditos.Image = Global.appFacturacion.My.Resources.Resources.Creditos
        Me.btCreditos.Name = "btCreditos"
        Me.btCreditos.Text = "Créditos"
        Me.btCreditos.Visible = False
        '
        'styEstiloSistema
        '
        Me.styEstiloSistema.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black
        '
        'txtBodega
        '
        Me.txtBodega.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtBodega.Border.Class = "TextBoxBorder"
        Me.txtBodega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBodega.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBodega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.txtBodega.Location = New System.Drawing.Point(9, 29)
        Me.txtBodega.Name = "txtBodega"
        Me.txtBodega.ReadOnly = True
        Me.txtBodega.Size = New System.Drawing.Size(188, 22)
        Me.txtBodega.TabIndex = 1
        '
        'tmLimpiarMemoria
        '
        Me.tmLimpiarMemoria.Interval = 300000
        '
        'ElGroupBox2
        '
        Me.ElGroupBox2.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox2.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox2.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox2.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox2.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox2.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.CaptionStyle.Size = New System.Drawing.Size(120, 24)
        Me.ElGroupBox2.CaptionStyle.TextStyle.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.ElGroupBox2.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Período Contable"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.btCargarCiclo)
        Me.ElGroupBox2.Controls.Add(Me.ElLabel2)
        Me.ElGroupBox2.Controls.Add(Me.ElLabel1)
        Me.ElGroupBox2.Controls.Add(Me.txtFinal)
        Me.ElGroupBox2.Controls.Add(Me.txtInicio)
        Me.ElGroupBox2.Location = New System.Drawing.Point(7, 29)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(509, 58)
        Me.ElGroupBox2.TabIndex = 6
        '
        'btCargarCiclo
        '
        Me.btCargarCiclo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCargarCiclo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btCargarCiclo.Font = New System.Drawing.Font("Google Sans Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCargarCiclo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.btCargarCiclo.Image = Global.appFacturacion.My.Resources.Resources.Periodo
        Me.btCargarCiclo.Location = New System.Drawing.Point(10, 26)
        Me.btCargarCiclo.Name = "btCargarCiclo"
        Me.btCargarCiclo.Size = New System.Drawing.Size(63, 28)
        Me.btCargarCiclo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btCargarCiclo.TabIndex = 13
        Me.btCargarCiclo.Text = "Ciclo"
        '
        'ElLabel2
        '
        Me.ElLabel2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle1.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel2.FlashStyle = PaintStyle1
        Me.ElLabel2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel2.Location = New System.Drawing.Point(294, 29)
        Me.ElLabel2.Name = "ElLabel2"
        Me.ElLabel2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlack
        Me.ElLabel2.Size = New System.Drawing.Size(115, 23)
        Me.ElLabel2.TabIndex = 7
        Me.ElLabel2.TabStop = False
        Me.ElLabel2.TextStyle.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.ElLabel2.TextStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ElLabel2.TextStyle.Text = "Final del Período:"
        '
        'ElLabel1
        '
        Me.ElLabel1.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElLabel1.Cursor = System.Windows.Forms.Cursors.Default
        PaintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle2.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel1.FlashStyle = PaintStyle2
        Me.ElLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel1.Location = New System.Drawing.Point(81, 29)
        Me.ElLabel1.Name = "ElLabel1"
        Me.ElLabel1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlack
        Me.ElLabel1.Size = New System.Drawing.Size(115, 23)
        Me.ElLabel1.TabIndex = 5
        Me.ElLabel1.TabStop = False
        Me.ElLabel1.TextStyle.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.ElLabel1.TextStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.ElLabel1.TextStyle.Text = "Inicio del Período:"
        '
        'txtFinal
        '
        Me.txtFinal.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtFinal.Border.Class = "TextBoxBorder"
        Me.txtFinal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFinal.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.txtFinal.Location = New System.Drawing.Point(415, 29)
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.ReadOnly = True
        Me.txtFinal.Size = New System.Drawing.Size(86, 22)
        Me.txtFinal.TabIndex = 8
        Me.txtFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInicio
        '
        Me.txtInicio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtInicio.Border.Class = "TextBoxBorder"
        Me.txtInicio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInicio.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.txtInicio.Location = New System.Drawing.Point(202, 29)
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.ReadOnly = True
        Me.txtInicio.Size = New System.Drawing.Size(86, 22)
        Me.txtInicio.TabIndex = 8
        Me.txtInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ElGroupBox1
        '
        Me.ElGroupBox1.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox1.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox1.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox1.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox1.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox1.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox1.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.CaptionStyle.Size = New System.Drawing.Size(120, 24)
        Me.ElGroupBox1.CaptionStyle.TextStyle.Font = New System.Drawing.Font("Google Sans Medium", 9.0!)
        Me.ElGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Sucursal / Bodega"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.btCargar)
        Me.ElGroupBox1.Controls.Add(Me.txtBodega)
        Me.ElGroupBox1.Location = New System.Drawing.Point(522, 29)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(237, 58)
        Me.ElGroupBox1.TabIndex = 4
        '
        'btCargar
        '
        Me.btCargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btCargar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCargar.Image = Global.appFacturacion.My.Resources.Resources.Cargar_24_24
        Me.btCargar.Location = New System.Drawing.Point(196, 25)
        Me.btCargar.Name = "btCargar"
        Me.btCargar.Size = New System.Drawing.Size(32, 28)
        Me.btCargar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btCargar.TabIndex = 3
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.Controls.Add(Me.pcLogo)
        Me.ExpandablePanel1.Controls.Add(Me.ElGroupBox2)
        Me.ExpandablePanel1.Controls.Add(Me.ElGroupBox1)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandablePanel1.ExpandOnTitleClick = True
        Me.ExpandablePanel1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpandablePanel1.Location = New System.Drawing.Point(5, 171)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(1012, 93)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 21
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "<b>S</b>istema de <font color=""#C0504D""><b>I</b>nventario y <b>F</b>acturación</f" &
    "ont>"
        '
        'pcLogo
        '
        Me.pcLogo.BackColor = System.Drawing.Color.Transparent
        Me.pcLogo.Image = Global.appFacturacion.My.Resources.Resources.Isotipo32x32
        Me.pcLogo.Location = New System.Drawing.Point(985, 34)
        Me.pcLogo.Name = "pcLogo"
        Me.pcLogo.Size = New System.Drawing.Size(50, 50)
        Me.pcLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pcLogo.TabIndex = 7
        Me.pcLogo.TabStop = False
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1022, 712)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.rcCintaMenu)
        Me.Controls.Add(Me.stsEstado)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1022, 713)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.stsEstado.ResumeLayout(False)
        Me.stsEstado.PerformLayout()
        Me.rcCintaMenu.ResumeLayout(False)
        Me.rcCintaMenu.PerformLayout()
        Me.RibbonPanel4.ResumeLayout(False)
        Me.RibbonPanel1.ResumeLayout(False)
        Me.RibbonPanel3.ResumeLayout(False)
        Me.RibbonPanel2.ResumeLayout(False)
        Me.RibbonPanel7.ResumeLayout(False)
        Me.RibbonPanel8.ResumeLayout(False)
        Me.RibbonPanel6.ResumeLayout(False)
        Me.RibbonPanel9.ResumeLayout(False)
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        CType(Me.ElLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.pcLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stsEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents lblEmpresa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rcCintaMenu As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents mnuArchivo As DevComponents.DotNetBar.Office2007StartButton
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents btUsuarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents btSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents mnuCatalogos As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents btCreditos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents styEstiloSistema As DevComponents.DotNetBar.StyleManager
    Friend WithEvents RibbonPanel2 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonPanel3 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem2 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btMarcas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btSucursal As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btSerie As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblBodega As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RibbonBar5 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btEntradas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btSalidas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btTraslados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCambiarPassword As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCerrarSesion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar8 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btLogo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar10 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btCreateBackup As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btRestoreDatabase As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblNombreUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmLimpiarMemoria As System.Windows.Forms.Timer
    Friend WithEvents btCargar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblIva As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtBodega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents RibbonPanel6 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem5 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonPanel7 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem6 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonBar6 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btTaza As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btIva As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar13 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btProveedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaProveedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaProductos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar4 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btCompra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btDevolucionCompra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar15 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btDesconsignar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btConsignar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaConsignacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaDesconsignacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btReporteConsignacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaEntradas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaSalida As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaTraslado As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar16 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btBitacora As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btInformeUsuarios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBodega As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaCompra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaDevolucionesCompras As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btVenta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaFactura As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btDevolucionesVentas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaDevolucion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCotizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaCotizacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btClientes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaClientes As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btEstadoCuenta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCompraEstadoCuenta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElLabel1 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElLabel2 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents txtInicio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtFinal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents RibbonPanel4 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem3 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonBar11 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonBar9 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonBar14 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents btUnidadMedida As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btPresentacion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btLaboratorio As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCargarCiclo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblTaza As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RibbonPanel8 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem7 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonPanel9 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem8 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonBar12 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btVendedores As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaVendedor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btTrabajoArea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaAreas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btTrabajoPuestos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaPuestos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar17 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btPlanilla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedasPlanillas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar18 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonBar19 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btProductoOferta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar20 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btPaises As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCiudades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaPais As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaCiudades As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar21 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btCatalogoCuentas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btPeriodo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCPEstadoCuenta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCuentasPagar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCCEstadoCuenta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCuentasCobrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents btSeleccionar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btPeriodoContable As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btApertura As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCierre As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar7 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btInformeVentaDetalle As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar22 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btBusquedaRecibo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btReciboVenta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar23 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btReciboCompra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btBusquedaReciboCompra As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar24 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btRegistro As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btAyuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btAcercaDe As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pcLogo As System.Windows.Forms.PictureBox
    Friend WithEvents RibbonBar25 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btKardex As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btControlExistencia As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btValuacionInventario As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btEstadoResultados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar26 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents btProductosComprados As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btEmpresa As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btServidor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btPrinterSetting As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btGraficosVenta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btProductWithApplication As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents StateLabel As ToolStripStatusLabel
End Class
