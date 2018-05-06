<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformeTraslado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInformeTraslado))
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btBusqueda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.ElGroupBox6 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtTotal = New DevComponents.Editors.DoubleInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.tcpFiltros = New DevComponents.DotNetBar.TabControlPanel()
        Me.ElGroupBox7 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbBodega = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbSerie = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.tbFiltros = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaInicial = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtpFechaFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.expDetalle = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dtDetalle = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.sptInfo = New DevComponents.DotNetBar.SuperTooltip()
        Me.PanelEx4 = New DevComponents.DotNetBar.PanelEx()
        Me.gbFecha = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Menu.SuspendLayout()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox6.SuspendLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcpFiltros.SuspendLayout()
        CType(Me.ElGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox7.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.dtpFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expDetalle.SuspendLayout()
        CType(Me.dtDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx4.SuspendLayout()
        CType(Me.gbFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFecha.SuspendLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btBuscar, Me.btLimpiar, Me.ToolStripSeparator2, Me.btBusqueda, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(1022, 39)
        Me.Menu.TabIndex = 1
        Me.Menu.Text = "ToolStrip1"
        '
        'btBuscar
        '
        Me.btBuscar.AutoToolTip = False
        Me.btBuscar.ForeColor = System.Drawing.Color.Black
        Me.btBuscar.Image = Global.appFacturacion.My.Resources.Resources.FiltroAplicar
        Me.btBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(101, 36)
        Me.sptInfo.SetSuperTooltip(Me.btBuscar, New DevComponents.DotNetBar.SuperTooltipInfo("Filtrar Datos: Ctrl + F", "Sistema de Inventario y Facturación // SIF", "Actualiza el listado aplicando los filtros ingresados por el usuario.", Global.appFacturacion.My.Resources.Resources.FiltroAplicar, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btBuscar.Text = "Filtrar Datos"
        '
        'btLimpiar
        '
        Me.btLimpiar.AutoToolTip = False
        Me.btLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btLimpiar.Image = Global.appFacturacion.My.Resources.Resources.FiltroBorrar
        Me.btLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(106, 36)
        Me.sptInfo.SetSuperTooltip(Me.btLimpiar, New DevComponents.DotNetBar.SuperTooltipInfo("Borrar Filtros: Ctrl + Shift + B", "Sistema de Inventario y Facturación // SIF", "Borra los filtros aplicados por el usuario y carga nuevamente la lista.", Global.appFacturacion.My.Resources.Resources.FiltroBorrar, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.btLimpiar.Text = "Borrar Filtros"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btBusqueda
        '
        Me.btBusqueda.AutoToolTip = False
        Me.btBusqueda.ForeColor = System.Drawing.Color.Black
        Me.btBusqueda.Image = Global.appFacturacion.My.Resources.Resources.BusquedaAvanzada
        Me.btBusqueda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btBusqueda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btBusqueda.Name = "btBusqueda"
        Me.btBusqueda.Size = New System.Drawing.Size(144, 36)
        Me.sptInfo.SetSuperTooltip(Me.btBusqueda, New DevComponents.DotNetBar.SuperTooltipInfo("Vista Reporte: Ctrl + B", "Sistema de Inventario y Facturación // SIF", "Muestra una interfaz para aplicar mas filtros a las Búsquedas.", Global.appFacturacion.My.Resources.Resources.BusquedaAvanzada, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btBusqueda.Text = "Búsqueda Avanzada"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btImprimir
        '
        Me.btImprimir.AutoToolTip = False
        Me.btImprimir.ForeColor = System.Drawing.Color.Black
        Me.btImprimir.Image = Global.appFacturacion.My.Resources.Resources.imprimir_det
        Me.btImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(109, 36)
        Me.sptInfo.SetSuperTooltip(Me.btImprimir, New DevComponents.DotNetBar.SuperTooltipInfo("Vista Reporte: Ctrl + P", "Sistema de Inventario y Facturación // SIF", "Muestra una vista en modo reporte con los datos de la información tal como se ver" & _
            "án al momento de imprimir.", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btImprimir.Text = "Vista Reporte"
        '
        'KFormManager1
        '
        Me.KFormManager1.BackgroundImageStyle.Alpha = 100
        Me.KFormManager1.BackgroundImageStyle.ImageEffect = Klik.Windows.Forms.v1.Common.ImageEffect.Mirror
        Me.KFormManager1.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.FormOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.KFormManager1.MainContainer = Me
        Me.KFormManager1.ToolStripOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.TabControl1)
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx2.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(277, 354)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.Transparent
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.ColorScheme.TabBackground = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.TabControl1.ColorScheme.TabBackground2 = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.TabControl1.ColorScheme.TabBorder = System.Drawing.Color.Black
        Me.TabControl1.ColorScheme.TabItemBackground = System.Drawing.SystemColors.InactiveCaption
        Me.TabControl1.ColorScheme.TabItemBackground2 = System.Drawing.SystemColors.ActiveCaption
        Me.TabControl1.ColorScheme.TabItemBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(145, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(126, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(126, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(108, Byte), Integer)), 1.0!)})
        Me.TabControl1.ColorScheme.TabItemBorder = System.Drawing.Color.Black
        Me.TabControl1.ColorScheme.TabItemBorderDark = System.Drawing.Color.Black
        Me.TabControl1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(193, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(174, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(145, Byte), Integer)), 1.0!)})
        Me.TabControl1.ColorScheme.TabItemHotBorder = System.Drawing.Color.Navy
        Me.TabControl1.ColorScheme.TabItemHotBorderDark = System.Drawing.Color.Navy
        Me.TabControl1.ColorScheme.TabItemHotBorderLight = System.Drawing.Color.Navy
        Me.TabControl1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(145, Byte), Integer)), 0.0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), 1.0!)})
        Me.TabControl1.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.Black
        Me.TabControl1.ColorScheme.TabPanelBackground = System.Drawing.SystemColors.InactiveCaption
        Me.TabControl1.ColorScheme.TabPanelBackground2 = System.Drawing.SystemColors.ActiveCaption
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.tcpFiltros)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(277, 354)
        Me.TabControl1.TabIndex = 6
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem3)
        Me.TabControl1.Tabs.Add(Me.tbFiltros)
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.ElGroupBox6)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(277, 328)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.Black
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = -90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem3
        '
        'ElGroupBox6
        '
        Me.ElGroupBox6.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox6.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox6.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox6.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox6.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox6.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox6.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox6.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox6.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox6.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox6.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox6.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox6.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox6.CaptionStyle.Size = New System.Drawing.Size(110, 24)
        Me.ElGroupBox6.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox6.CaptionStyle.TextStyle.Text = "Resultado Total"
        Me.ElGroupBox6.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox6.Controls.Add(Me.txtTotal)
        Me.ElGroupBox6.Controls.Add(Me.Label3)
        Me.ElGroupBox6.Location = New System.Drawing.Point(10, 3)
        Me.ElGroupBox6.Name = "ElGroupBox6"
        Me.ElGroupBox6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox6.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox6.Size = New System.Drawing.Size(255, 65)
        Me.ElGroupBox6.TabIndex = 5
        '
        'txtTotal
        '
        '
        '
        '
        Me.txtTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Increment = 1.0R
        Me.txtTotal.IsInputReadOnly = True
        Me.txtTotal.Location = New System.Drawing.Point(94, 32)
        Me.txtTotal.MinValue = 0.0R
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(144, 20)
        Me.txtTotal.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Total Entradas:"
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel2
        Me.TabItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.TabItem3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.TabItem3.Image = Global.appFacturacion.My.Resources.Resources.Totales
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Silver
        Me.TabItem3.Text = "Resultados"
        '
        'tcpFiltros
        '
        Me.tcpFiltros.AutoScroll = True
        Me.tcpFiltros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tcpFiltros.Controls.Add(Me.ElGroupBox7)
        Me.tcpFiltros.Controls.Add(Me.ElGroupBox2)
        Me.tcpFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcpFiltros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcpFiltros.Location = New System.Drawing.Point(0, 26)
        Me.tcpFiltros.Name = "tcpFiltros"
        Me.tcpFiltros.Padding = New System.Windows.Forms.Padding(1)
        Me.tcpFiltros.Size = New System.Drawing.Size(277, 328)
        Me.tcpFiltros.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.tcpFiltros.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.tcpFiltros.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.tcpFiltros.Style.BorderColor.Color = System.Drawing.Color.Black
        Me.tcpFiltros.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.tcpFiltros.Style.ForeColor.Color = System.Drawing.Color.Black
        Me.tcpFiltros.Style.GradientAngle = -90
        Me.tcpFiltros.TabIndex = 1
        Me.tcpFiltros.TabItem = Me.tbFiltros
        Me.tcpFiltros.Visible = False
        '
        'ElGroupBox7
        '
        Me.ElGroupBox7.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox7.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox7.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox7.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox7.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox7.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox7.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox7.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox7.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox7.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox7.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox7.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox7.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox7.CaptionStyle.Size = New System.Drawing.Size(110, 24)
        Me.ElGroupBox7.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox7.CaptionStyle.TextStyle.Text = "Personas"
        Me.ElGroupBox7.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox7.Controls.Add(Me.Label11)
        Me.ElGroupBox7.Controls.Add(Me.Label12)
        Me.ElGroupBox7.Controls.Add(Me.txtNVendedor)
        Me.ElGroupBox7.Controls.Add(Me.txtNombreVendedor)
        Me.ElGroupBox7.Location = New System.Drawing.Point(10, 93)
        Me.ElGroupBox7.Name = "ElGroupBox7"
        Me.ElGroupBox7.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox7.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox7.Size = New System.Drawing.Size(241, 86)
        Me.ElGroupBox7.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 14)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "N° Emple.:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Empleado:"
        '
        'txtNVendedor
        '
        '
        '
        '
        Me.txtNVendedor.Border.Class = "TextBoxBorder"
        Me.txtNVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNVendedor.Location = New System.Drawing.Point(67, 31)
        Me.txtNVendedor.Name = "txtNVendedor"
        Me.txtNVendedor.Size = New System.Drawing.Size(166, 20)
        Me.txtNVendedor.TabIndex = 7
        '
        'txtNombreVendedor
        '
        '
        '
        '
        Me.txtNombreVendedor.Border.Class = "TextBoxBorder"
        Me.txtNombreVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreVendedor.Location = New System.Drawing.Point(67, 54)
        Me.txtNombreVendedor.Name = "txtNombreVendedor"
        Me.txtNombreVendedor.Size = New System.Drawing.Size(166, 20)
        Me.txtNombreVendedor.TabIndex = 8
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
        Me.ElGroupBox2.CaptionStyle.Size = New System.Drawing.Size(110, 24)
        Me.ElGroupBox2.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Localidad"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.Label5)
        Me.ElGroupBox2.Controls.Add(Me.Label8)
        Me.ElGroupBox2.Controls.Add(Me.cmbBodega)
        Me.ElGroupBox2.Controls.Add(Me.cmbSerie)
        Me.ElGroupBox2.Location = New System.Drawing.Point(10, 3)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(241, 84)
        Me.ElGroupBox2.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 14)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Sucursal:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Serie:"
        '
        'cmbBodega
        '
        Me.cmbBodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBodega.DisplayMember = "Text"
        Me.cmbBodega.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBodega.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.ItemHeight = 14
        Me.cmbBodega.Location = New System.Drawing.Point(67, 31)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(166, 20)
        Me.cmbBodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBodega.TabIndex = 1
        '
        'cmbSerie
        '
        Me.cmbSerie.DisplayMember = "Text"
        Me.cmbSerie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSerie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSerie.FormattingEnabled = True
        Me.cmbSerie.ItemHeight = 14
        Me.cmbSerie.Location = New System.Drawing.Point(67, 54)
        Me.cmbSerie.Name = "cmbSerie"
        Me.cmbSerie.Size = New System.Drawing.Size(166, 20)
        Me.cmbSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSerie.TabIndex = 2
        '
        'tbFiltros
        '
        Me.tbFiltros.AttachedControl = Me.tcpFiltros
        Me.tbFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.tbFiltros.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.tbFiltros.BorderColor = System.Drawing.Color.Black
        Me.tbFiltros.CloseButtonVisible = False
        Me.tbFiltros.DarkBorderColor = System.Drawing.Color.Black
        Me.tbFiltros.Image = Global.appFacturacion.My.Resources.Resources.Filtros
        Me.tbFiltros.LightBorderColor = System.Drawing.Color.Black
        Me.tbFiltros.Name = "tbFiltros"
        Me.tbFiltros.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Silver
        Me.tbFiltros.Text = "Busq. Avanzada"
        Me.tbFiltros.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Inicio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Final:"
        '
        'dtpFechaInicial
        '
        '
        '
        '
        Me.dtpFechaInicial.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFechaInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaInicial.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFechaInicial.ButtonDropDown.Visible = True
        Me.dtpFechaInicial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicial.Location = New System.Drawing.Point(41, 5)
        '
        '
        '
        Me.dtpFechaInicial.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFechaInicial.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFechaInicial.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpFechaInicial.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaInicial.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpFechaInicial.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaInicial.MonthCalendar.DisplayMonth = New Date(2014, 12, 1, 0, 0, 0, 0)
        Me.dtpFechaInicial.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFechaInicial.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFechaInicial.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpFechaInicial.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaInicial.MonthCalendar.TodayButtonVisible = True
        Me.dtpFechaInicial.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(80, 20)
        Me.dtpFechaInicial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFechaInicial.TabIndex = 14
        '
        'dtpFechaFinal
        '
        '
        '
        '
        Me.dtpFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFechaFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFechaFinal.ButtonDropDown.Visible = True
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFinal.Location = New System.Drawing.Point(164, 5)
        '
        '
        '
        Me.dtpFechaFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFechaFinal.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFechaFinal.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpFechaFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpFechaFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaFinal.MonthCalendar.DisplayMonth = New Date(2014, 12, 1, 0, 0, 0, 0)
        Me.dtpFechaFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFechaFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFechaFinal.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpFechaFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaFinal.MonthCalendar.TodayButtonVisible = True
        Me.dtpFechaFinal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(80, 20)
        Me.dtpFechaFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFechaFinal.TabIndex = 15
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.tcpFiltros
        Me.TabItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.TabItem2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.TabItem2.BorderColor = System.Drawing.Color.Black
        Me.TabItem2.CloseButtonVisible = False
        Me.TabItem2.DarkBorderColor = System.Drawing.Color.Black
        Me.TabItem2.Image = Global.appFacturacion.My.Resources.Resources.btn_agregar
        Me.TabItem2.LightBorderColor = System.Drawing.Color.Black
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Silver
        Me.TabItem2.Text = "Filtros / Consultas"
        '
        'expDetalle
        '
        Me.expDetalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.expDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.expDetalle.Controls.Add(Me.dtDetalle)
        Me.expDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.expDetalle.Expanded = False
        Me.expDetalle.ExpandedBounds = New System.Drawing.Rectangle(299, 200, 593, 193)
        Me.expDetalle.ExpandOnTitleClick = True
        Me.expDetalle.Location = New System.Drawing.Point(277, 365)
        Me.expDetalle.Name = "expDetalle"
        Me.expDetalle.Size = New System.Drawing.Size(745, 28)
        Me.expDetalle.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.expDetalle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expDetalle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.expDetalle.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expDetalle.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.expDetalle.Style.BorderWidth = 2
        Me.expDetalle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.expDetalle.Style.GradientAngle = 90
        Me.expDetalle.TabIndex = 4
        Me.expDetalle.TitleHeight = 28
        Me.expDetalle.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.expDetalle.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expDetalle.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.expDetalle.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expDetalle.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expDetalle.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expDetalle.TitleStyle.GradientAngle = 90
        Me.expDetalle.TitleText = "MOSTRAR DETALLE DE LA ENTRADA SELECCIONADA"
        '
        'dtDetalle
        '
        Me.dtDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtDetalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDetalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dtDetalle.Location = New System.Drawing.Point(0, 28)
        Me.dtDetalle.MultiSelect = False
        Me.dtDetalle.Name = "dtDetalle"
        Me.dtDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtDetalle.Size = New System.Drawing.Size(593, 0)
        Me.dtDetalle.TabIndex = 4
        '
        'PanelEx4
        '
        Me.PanelEx4.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx4.Controls.Add(Me.gbFecha)
        Me.PanelEx4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx4.Location = New System.Drawing.Point(277, 39)
        Me.PanelEx4.Name = "PanelEx4"
        Me.PanelEx4.Size = New System.Drawing.Size(745, 36)
        Me.PanelEx4.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx4.Style.GradientAngle = 90
        Me.PanelEx4.TabIndex = 5
        '
        'gbFecha
        '
        Me.gbFecha.BackgroundStyle.GradientAngle = 45.0!
        Me.gbFecha.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.gbFecha.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.gbFecha.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.gbFecha.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gbFecha.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gbFecha.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gbFecha.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gbFecha.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.gbFecha.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.gbFecha.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.gbFecha.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gbFecha.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.gbFecha.CaptionStyle.Size = New System.Drawing.Size(0, 0)
        Me.gbFecha.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.gbFecha.CaptionStyle.TextStyle.Text = "ElGroupBox5"
        Me.gbFecha.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gbFecha.Controls.Add(Me.Label1)
        Me.gbFecha.Controls.Add(Me.dtpFechaFinal)
        Me.gbFecha.Controls.Add(Me.dtpFechaInicial)
        Me.gbFecha.Controls.Add(Me.Label2)
        Me.gbFecha.Location = New System.Drawing.Point(4, 4)
        Me.gbFecha.Name = "gbFecha"
        Me.gbFecha.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.gbFecha.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.gbFecha.Size = New System.Drawing.Size(250, 28)
        Me.gbFecha.TabIndex = 74
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(277, 75)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(745, 290)
        Me.CrystalReportViewer1.TabIndex = 6
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.Visible = False
        '
        'dtRegistro
        '
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(277, 75)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(745, 290)
        Me.dtRegistro.TabIndex = 7
        '
        'frmInformeTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 393)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.PanelEx4)
        Me.Controls.Add(Me.expDetalle)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmInformeTraslado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Traslados"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox6.ResumeLayout(False)
        Me.ElGroupBox6.PerformLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcpFiltros.ResumeLayout(False)
        CType(Me.ElGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox7.ResumeLayout(False)
        Me.ElGroupBox7.PerformLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        CType(Me.dtpFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expDetalle.ResumeLayout(False)
        CType(Me.dtDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx4.ResumeLayout(False)
        CType(Me.gbFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFecha.ResumeLayout(False)
        Me.gbFecha.PerformLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents ElGroupBox6 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNombreVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbBodega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbSerie As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents dtpFechaInicial As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpFechaFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents tcpFiltros As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tbFiltros As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents expDetalle As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dtDetalle As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents sptInfo As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents PanelEx4 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents gbFecha As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btBusqueda As System.Windows.Forms.ToolStripButton
    Friend WithEvents ElGroupBox7 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
