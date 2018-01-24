<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPromocion
    'Inherits System.Windows.Forms.Form
    Inherits System.Windows.Forms.Form

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
        Dim PaintStyle4 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle5 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle6 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPromocion))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.btAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.lblContador = New System.Windows.Forms.Label()
        Me.ElGroupBox4 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtNPromocion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpHoraFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpHoraInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodigoAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ElLabel4 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.btPromocion = New DevComponents.DotNetBar.ButtonX()
        Me.btProducto = New DevComponents.DotNetBar.ButtonX()
        Me.ElGroupBox5 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtCantidad = New DevComponents.Editors.DoubleInput()
        Me.ElLabel5 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.txtDescuento = New DevComponents.Editors.DoubleInput()
        Me.ElLabel6 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.sptInfo = New DevComponents.DotNetBar.SuperTooltip()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rdProductos = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Menu.SuspendLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox4.SuspendLayout()
        CType(Me.dtpHoraFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpHoraInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.ElLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox5.SuspendLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(146, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 14)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Descripción:"
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btEditar, Me.btAnular, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(959, 39)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "ToolStrip1"
        '
        'btNuevo
        '
        Me.btNuevo.AutoToolTip = False
        Me.btNuevo.Image = Global.appFacturacion.My.Resources.Resources.nuevo
        Me.btNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(74, 36)
        Me.sptInfo.SetSuperTooltip(Me.btNuevo, New DevComponents.DotNetBar.SuperTooltipInfo("Nuevo: Ctrl + N", "Sistema de Inventario y Facturación // SIF", "Limpia los campos y permite ingresar un nuevo registro.", Global.appFacturacion.My.Resources.Resources.nuevo, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btNuevo.Text = "Nuevo"
        '
        'btGuardar
        '
        Me.btGuardar.AutoToolTip = False
        Me.btGuardar.Image = Global.appFacturacion.My.Resources.Resources.guardar
        Me.btGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(83, 36)
        Me.sptInfo.SetSuperTooltip(Me.btGuardar, New DevComponents.DotNetBar.SuperTooltipInfo("Guardar: Ctrl + G", "Sistema de Inventario y Facturación // SIF", "Guardar el registro en pantalla con su respectiva información. Cabe destacar que " & _
            "los datos previamente son expuestos a un proceso de validación.", Global.appFacturacion.My.Resources.Resources.guardar, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btGuardar.Text = "Guardar"
        '
        'btEditar
        '
        Me.btEditar.Enabled = False
        Me.btEditar.ForeColor = System.Drawing.Color.Black
        Me.btEditar.Image = Global.appFacturacion.My.Resources.Resources.editar
        Me.btEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEditar.Name = "btEditar"
        Me.btEditar.Size = New System.Drawing.Size(70, 36)
        Me.btEditar.Text = "Editar"
        '
        'btAnular
        '
        Me.btAnular.AutoToolTip = False
        Me.btAnular.Enabled = False
        Me.btAnular.Image = Global.appFacturacion.My.Resources.Resources.eliminar
        Me.btAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btAnular.Name = "btAnular"
        Me.btAnular.Size = New System.Drawing.Size(75, 36)
        Me.sptInfo.SetSuperTooltip(Me.btAnular, New DevComponents.DotNetBar.SuperTooltipInfo("Anular: Ctrl + Del", "Sistema de Inventario y Facturación // SIF", "Elimina el registro mostrado en pantalla.", Global.appFacturacion.My.Resources.Resources.eliminar, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btAnular.Text = "Anular"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btImprimir
        '
        Me.btImprimir.AutoToolTip = False
        Me.btImprimir.Enabled = False
        Me.btImprimir.ForeColor = System.Drawing.Color.Black
        Me.btImprimir.Image = Global.appFacturacion.My.Resources.Resources.imprimir_det
        Me.btImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(79, 36)
        Me.sptInfo.SetSuperTooltip(Me.btImprimir, New DevComponents.DotNetBar.SuperTooltipInfo("Imprimir: Ctrl + P", "Sistema de Inventario y Facturación // SIF", "Imprime el documento mostrado en pantalla.", Global.appFacturacion.My.Resources.Resources.imprimir_det, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btImprimir.Text = "Imprimir"
        '
        'bkEstilo
        '
        Me.bkEstilo.BackgroundImageStyle.Alpha = 100
        Me.bkEstilo.BackgroundImageStyle.ImageEffect = Klik.Windows.Forms.v1.Common.ImageEffect.Mirror
        Me.bkEstilo.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.bkEstilo.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.bkEstilo.FormOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.bkEstilo.MainContainer = Me
        Me.bkEstilo.ToolStripOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.BackColor = System.Drawing.Color.Transparent
        Me.lblContador.ForeColor = System.Drawing.Color.Black
        Me.lblContador.Location = New System.Drawing.Point(9, 60)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(59, 14)
        Me.lblContador.TabIndex = 71
        Me.lblContador.Text = "N° ITEM: 0"
        '
        'ElGroupBox4
        '
        Me.ElGroupBox4.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox4.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox4.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox4.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox4.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox4.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox4.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox4.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox4.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox4.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox4.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox4.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox4.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox4.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox4.CaptionStyle.TextStyle.Text = "Promoción"
        Me.ElGroupBox4.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox4.Controls.Add(Me.RadioButton1)
        Me.ElGroupBox4.Controls.Add(Me.txtNPromocion)
        Me.ElGroupBox4.Controls.Add(Me.rdProductos)
        Me.ElGroupBox4.Controls.Add(Me.Label7)
        Me.ElGroupBox4.Controls.Add(Me.Label9)
        Me.ElGroupBox4.Controls.Add(Me.dtpHoraFinal)
        Me.ElGroupBox4.Controls.Add(Me.Label5)
        Me.ElGroupBox4.Controls.Add(Me.dtpHoraInicio)
        Me.ElGroupBox4.Controls.Add(Me.Label3)
        Me.ElGroupBox4.Controls.Add(Me.dtpFinal)
        Me.ElGroupBox4.Controls.Add(Me.Label2)
        Me.ElGroupBox4.Controls.Add(Me.dtpInicio)
        Me.ElGroupBox4.Controls.Add(Me.Label1)
        Me.ElGroupBox4.Controls.Add(Me.txtDescripcion)
        Me.ElGroupBox4.Controls.Add(Me.Label8)
        Me.ElGroupBox4.Controls.Add(Me.Label12)
        Me.ElGroupBox4.Controls.Add(Me.Label4)
        Me.ElGroupBox4.Controls.Add(Me.Label6)
        Me.ElGroupBox4.Location = New System.Drawing.Point(12, 6)
        Me.ElGroupBox4.Name = "ElGroupBox4"
        Me.ElGroupBox4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox4.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox4.Size = New System.Drawing.Size(355, 137)
        Me.ElGroupBox4.TabIndex = 1
        '
        'txtNPromocion
        '
        Me.txtNPromocion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNPromocion.Border.Class = "TextBoxBorder"
        Me.txtNPromocion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNPromocion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPromocion.Location = New System.Drawing.Point(86, 29)
        Me.txtNPromocion.Name = "txtNPromocion"
        Me.txtNPromocion.ReadOnly = True
        Me.txtNPromocion.Size = New System.Drawing.Size(54, 20)
        Me.txtNPromocion.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 14)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Nº Promoción:"
        '
        'dtpHoraFinal
        '
        '
        '
        '
        Me.dtpHoraFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpHoraFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpHoraFinal.ButtonDropDown.Visible = True
        Me.dtpHoraFinal.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.dtpHoraFinal.Location = New System.Drawing.Point(269, 78)
        '
        '
        '
        Me.dtpHoraFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpHoraFinal.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpHoraFinal.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpHoraFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpHoraFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraFinal.MonthCalendar.DisplayMonth = New Date(2017, 3, 1, 0, 0, 0, 0)
        Me.dtpHoraFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpHoraFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpHoraFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpHoraFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpHoraFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpHoraFinal.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpHoraFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraFinal.MonthCalendar.TodayButtonVisible = True
        Me.dtpHoraFinal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpHoraFinal.Name = "dtpHoraFinal"
        Me.dtpHoraFinal.Size = New System.Drawing.Size(79, 20)
        Me.dtpHoraFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpHoraFinal.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(188, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Hora de Fin:"
        '
        'dtpHoraInicio
        '
        '
        '
        '
        Me.dtpHoraInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpHoraInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpHoraInicio.ButtonDropDown.Visible = True
        Me.dtpHoraInicio.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.dtpHoraInicio.Location = New System.Drawing.Point(269, 52)
        '
        '
        '
        Me.dtpHoraInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpHoraInicio.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpHoraInicio.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpHoraInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpHoraInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraInicio.MonthCalendar.DisplayMonth = New Date(2017, 3, 1, 0, 0, 0, 0)
        Me.dtpHoraInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpHoraInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpHoraInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpHoraInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpHoraInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpHoraInicio.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpHoraInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpHoraInicio.MonthCalendar.TodayButtonVisible = True
        Me.dtpHoraInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpHoraInicio.Name = "dtpHoraInicio"
        Me.dtpHoraInicio.Size = New System.Drawing.Size(79, 20)
        Me.dtpHoraInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpHoraInicio.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(188, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Hora de Inicio:"
        '
        'dtpFinal
        '
        '
        '
        '
        Me.dtpFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFinal.ButtonDropDown.Visible = True
        Me.dtpFinal.Location = New System.Drawing.Point(78, 78)
        '
        '
        '
        Me.dtpFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFinal.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFinal.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFinal.MonthCalendar.DisplayMonth = New Date(2017, 3, 1, 0, 0, 0, 0)
        Me.dtpFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFinal.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFinal.MonthCalendar.TodayButtonVisible = True
        Me.dtpFinal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(95, 20)
        Me.dtpFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFinal.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Finaliza el:"
        '
        'dtpInicio
        '
        '
        '
        '
        Me.dtpInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpInicio.ButtonDropDown.Visible = True
        Me.dtpInicio.Location = New System.Drawing.Point(78, 52)
        '
        '
        '
        Me.dtpInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpInicio.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpInicio.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInicio.MonthCalendar.DisplayMonth = New Date(2017, 3, 1, 0, 0, 0, 0)
        Me.dtpInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpInicio.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInicio.MonthCalendar.TodayButtonVisible = True
        Me.dtpInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(95, 20)
        Me.dtpInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpInicio.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Comienza el:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(219, 27)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(129, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(346, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label12, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label12.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(171, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label4, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label4.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(170, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label6, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label6.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "*"
        '
        'txtCodigoAlterno
        '
        Me.txtCodigoAlterno.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtCodigoAlterno.Border.Class = "TextBoxBorder"
        Me.txtCodigoAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigoAlterno.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoAlterno.ForeColor = System.Drawing.Color.Yellow
        Me.txtCodigoAlterno.Location = New System.Drawing.Point(96, 6)
        Me.txtCodigoAlterno.Name = "txtCodigoAlterno"
        Me.txtCodigoAlterno.Size = New System.Drawing.Size(148, 23)
        Me.txtCodigoAlterno.TabIndex = 26
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.ElGroupBox4)
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelEx2.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(394, 356)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 1
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.ElGroupBox2)
        Me.PanelEx3.Controls.Add(Me.ElGroupBox5)
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx3.Location = New System.Drawing.Point(394, 39)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(565, 114)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 2
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
        Me.ElGroupBox2.CaptionStyle.Size = New System.Drawing.Size(0, 0)
        Me.ElGroupBox2.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "ElGroupBox2"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.Label19)
        Me.ElGroupBox2.Controls.Add(Me.txtCodigoAlterno)
        Me.ElGroupBox2.Controls.Add(Me.ElLabel4)
        Me.ElGroupBox2.Controls.Add(Me.btPromocion)
        Me.ElGroupBox2.Controls.Add(Me.btProducto)
        Me.ElGroupBox2.Location = New System.Drawing.Point(6, 18)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(307, 79)
        Me.ElGroupBox2.TabIndex = 72
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(9, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(251, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label19, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label19.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label19.TabIndex = 76
        Me.Label19.Text = "(*)  CAMPO OBLIGATORIO: INGRESAR DETALLE"
        '
        'ElLabel4
        '
        Me.ElLabel4.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle4.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel4.FlashStyle = PaintStyle4
        Me.ElLabel4.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel4.Location = New System.Drawing.Point(7, 6)
        Me.ElLabel4.Name = "ElLabel4"
        Me.ElLabel4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel4.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel4.TabIndex = 73
        Me.ElLabel4.TabStop = False
        Me.ElLabel4.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel4.TextStyle.Text = "Producto:"
        '
        'btPromocion
        '
        Me.btPromocion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btPromocion.BackColor = System.Drawing.Color.Transparent
        Me.btPromocion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btPromocion.Image = Global.appFacturacion.My.Resources.Resources.Promocion
        Me.btPromocion.Location = New System.Drawing.Point(272, 6)
        Me.btPromocion.Name = "btPromocion"
        Me.btPromocion.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btPromocion.Size = New System.Drawing.Size(29, 23)
        Me.btPromocion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btPromocion.TabIndex = 28
        '
        'btProducto
        '
        Me.btProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btProducto.BackColor = System.Drawing.Color.Transparent
        Me.btProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btProducto.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btProducto.Location = New System.Drawing.Point(243, 6)
        Me.btProducto.Name = "btProducto"
        Me.btProducto.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btProducto.Size = New System.Drawing.Size(29, 23)
        Me.btProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btProducto.TabIndex = 27
        '
        'ElGroupBox5
        '
        Me.ElGroupBox5.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox5.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox5.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox5.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox5.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox5.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox5.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox5.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox5.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox5.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox5.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox5.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox5.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox5.CaptionStyle.Size = New System.Drawing.Size(0, 0)
        Me.ElGroupBox5.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox5.CaptionStyle.TextStyle.Text = "ElGroupBox5"
        Me.ElGroupBox5.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox5.Controls.Add(Me.txtCantidad)
        Me.ElGroupBox5.Controls.Add(Me.lblContador)
        Me.ElGroupBox5.Controls.Add(Me.ElLabel5)
        Me.ElGroupBox5.Controls.Add(Me.txtDescuento)
        Me.ElGroupBox5.Controls.Add(Me.ElLabel6)
        Me.ElGroupBox5.Location = New System.Drawing.Point(362, 18)
        Me.ElGroupBox5.Name = "ElGroupBox5"
        Me.ElGroupBox5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox5.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox5.Size = New System.Drawing.Size(196, 79)
        Me.ElGroupBox5.TabIndex = 73
        '
        'txtCantidad
        '
        '
        '
        '
        Me.txtCantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantidad.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Increment = 1.0R
        Me.txtCantidad.Location = New System.Drawing.Point(96, 31)
        Me.txtCantidad.MinValue = 0.0R
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(93, 23)
        Me.txtCantidad.TabIndex = 76
        '
        'ElLabel5
        '
        Me.ElLabel5.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle5.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle5.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel5.FlashStyle = PaintStyle5
        Me.ElLabel5.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel5.Location = New System.Drawing.Point(7, 31)
        Me.ElLabel5.Name = "ElLabel5"
        Me.ElLabel5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel5.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel5.TabIndex = 74
        Me.ElLabel5.TabStop = False
        Me.ElLabel5.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel5.TextStyle.Text = "Cantidad"
        '
        'txtDescuento
        '
        '
        '
        '
        Me.txtDescuento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescuento.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDescuento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.Increment = 1.0R
        Me.txtDescuento.Location = New System.Drawing.Point(96, 6)
        Me.txtDescuento.MinValue = 0.0R
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(93, 23)
        Me.txtDescuento.TabIndex = 76
        '
        'ElLabel6
        '
        Me.ElLabel6.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle6.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle6.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel6.FlashStyle = PaintStyle6
        Me.ElLabel6.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel6.Location = New System.Drawing.Point(7, 6)
        Me.ElLabel6.Name = "ElLabel6"
        Me.ElLabel6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel6.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel6.TabIndex = 74
        Me.ElLabel6.TabStop = False
        Me.ElLabel6.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel6.TextStyle.Text = "Descuento:"
        '
        'dtRegistro
        '
        Me.dtRegistro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtRegistro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(394, 153)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(565, 242)
        Me.dtRegistro.TabIndex = 74
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 14)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Tipo de Promoción:"
        '
        'rdProductos
        '
        Me.rdProductos.AutoSize = True
        Me.rdProductos.Location = New System.Drawing.Point(109, 106)
        Me.rdProductos.Name = "rdProductos"
        Me.rdProductos.Size = New System.Drawing.Size(116, 18)
        Me.rdProductos.TabIndex = 3
        Me.rdProductos.TabStop = True
        Me.rdProductos.Text = "Producto o Grupos"
        Me.rdProductos.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(231, 106)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(116, 18)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Criterios de Saldos"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'frmPromocion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(959, 395)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPromocion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promociones"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox4.ResumeLayout(False)
        Me.ElGroupBox4.PerformLayout()
        CType(Me.dtpHoraFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpHoraInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        CType(Me.ElLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox5.ResumeLayout(False)
        Me.ElGroupBox5.PerformLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ElGroupBox4 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents btPromocion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCodigoAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElLabel4 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElGroupBox5 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElLabel5 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElLabel6 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtDescuento As DevComponents.Editors.DoubleInput
    Friend WithEvents txtCantidad As DevComponents.Editors.DoubleInput
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents sptInfo As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpHoraInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpHoraFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNPromocion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rdProductos As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
