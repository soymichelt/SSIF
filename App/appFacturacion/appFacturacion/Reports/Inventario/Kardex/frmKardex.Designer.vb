<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKardex
    'Inherits System.Windows.Forms.Form
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKardex))
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btBuscarCliente = New DevComponents.DotNetBar.ButtonX()
        Me.txtIdAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.dtpFecha2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtpFecha1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.ElGroupBox3 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.cmbBodega = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbOperacion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.lblNombreEmpresa = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.lblArticulo = New DevComponents.DotNetBar.LabelX()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.dtpFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox3.SuspendLayout()
        Me.Menu.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nº Alterno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(138, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Inicio:"
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
        Me.ElGroupBox2.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Seleccción Producto"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.btBuscarCliente)
        Me.ElGroupBox2.Controls.Add(Me.txtIdAlterno)
        Me.ElGroupBox2.Controls.Add(Me.Label1)
        Me.ElGroupBox2.Location = New System.Drawing.Point(12, 86)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(256, 71)
        Me.ElGroupBox2.TabIndex = 1
        '
        'btBuscarCliente
        '
        Me.btBuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarCliente.BackColor = System.Drawing.Color.Transparent
        Me.btBuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarCliente.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btBuscarCliente.Location = New System.Drawing.Point(220, 32)
        Me.btBuscarCliente.Name = "btBuscarCliente"
        Me.btBuscarCliente.Size = New System.Drawing.Size(29, 24)
        Me.btBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarCliente.TabIndex = 2
        '
        'txtIdAlterno
        '
        '
        '
        '
        Me.txtIdAlterno.Border.Class = "TextBoxBorder"
        Me.txtIdAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdAlterno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdAlterno.Location = New System.Drawing.Point(97, 34)
        Me.txtIdAlterno.Name = "txtIdAlterno"
        Me.txtIdAlterno.Size = New System.Drawing.Size(125, 20)
        Me.txtIdAlterno.TabIndex = 1
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Rango de Fechas"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.dtpFecha2)
        Me.ElGroupBox1.Controls.Add(Me.dtpFecha1)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Location = New System.Drawing.Point(12, 163)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(256, 66)
        Me.ElGroupBox1.TabIndex = 2
        '
        'dtpFecha2
        '
        '
        '
        '
        Me.dtpFecha2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFecha2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFecha2.ButtonDropDown.Visible = True
        Me.dtpFecha2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha2.Location = New System.Drawing.Point(164, 34)
        '
        '
        '
        Me.dtpFecha2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFecha2.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpFecha2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpFecha2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha2.MonthCalendar.DisplayMonth = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.dtpFecha2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFecha2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFecha2.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpFecha2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha2.MonthCalendar.TodayButtonVisible = True
        Me.dtpFecha2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFecha2.TabIndex = 3
        '
        'dtpFecha1
        '
        '
        '
        '
        Me.dtpFecha1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFecha1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFecha1.ButtonDropDown.Visible = True
        Me.dtpFecha1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha1.Location = New System.Drawing.Point(50, 34)
        '
        '
        '
        Me.dtpFecha1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFecha1.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpFecha1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpFecha1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha1.MonthCalendar.DisplayMonth = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.dtpFecha1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFecha1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFecha1.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpFecha1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha1.MonthCalendar.TodayButtonVisible = True
        Me.dtpFecha1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecha1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFecha1.TabIndex = 2
        '
        'ElGroupBox3
        '
        Me.ElGroupBox3.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox3.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox3.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox3.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox3.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox3.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox3.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox3.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox3.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox3.CaptionStyle.Size = New System.Drawing.Size(120, 24)
        Me.ElGroupBox3.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox3.CaptionStyle.TextStyle.Text = "Transacciones"
        Me.ElGroupBox3.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox3.Controls.Add(Me.cmbBodega)
        Me.ElGroupBox3.Controls.Add(Me.cmbOperacion)
        Me.ElGroupBox3.Controls.Add(Me.Label7)
        Me.ElGroupBox3.Controls.Add(Me.Label6)
        Me.ElGroupBox3.Location = New System.Drawing.Point(12, 235)
        Me.ElGroupBox3.Name = "ElGroupBox3"
        Me.ElGroupBox3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox3.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox3.Size = New System.Drawing.Size(256, 86)
        Me.ElGroupBox3.TabIndex = 3
        '
        'cmbBodega
        '
        Me.cmbBodega.DisplayMember = "Text"
        Me.cmbBodega.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.ItemHeight = 14
        Me.cmbBodega.Location = New System.Drawing.Point(68, 58)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(181, 20)
        Me.cmbBodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBodega.TabIndex = 5
        '
        'cmbOperacion
        '
        Me.cmbOperacion.DisplayMember = "Text"
        Me.cmbOperacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperacion.FormattingEnabled = True
        Me.cmbOperacion.ItemHeight = 14
        Me.cmbOperacion.Items.AddRange(New Object() {Me.ComboItem10, Me.ComboItem1, Me.ComboItem11, Me.ComboItem2, Me.ComboItem12, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5, Me.ComboItem6, Me.ComboItem7})
        Me.cmbOperacion.Location = New System.Drawing.Point(84, 34)
        Me.cmbOperacion.Name = "cmbOperacion"
        Me.cmbOperacion.Size = New System.Drawing.Size(165, 20)
        Me.cmbOperacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbOperacion.TabIndex = 4
        '
        'ComboItem1
        '
        Me.ComboItem1.FontStyle = System.Drawing.FontStyle.Bold
        Me.ComboItem1.Text = "VENTA CONTADO"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "VENTA CREDITO"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "COMPRA CONTADO"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "COMPRA CREDITO"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "ENTRADA"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "SALIDA"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "TRASLADO"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "DEVOLUCION VENTA"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "DEVOLUCION COMPRA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Bodegas:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 14)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Movimientos:"
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btBuscar, Me.btLimpiar, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(956, 39)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "ToolStrip1"
        '
        'btBuscar
        '
        Me.btBuscar.ForeColor = System.Drawing.Color.Black
        Me.btBuscar.Image = Global.appFacturacion.My.Resources.Resources.FiltroAplicar
        Me.btBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(101, 36)
        Me.btBuscar.Text = "Filtrar Datos"
        '
        'btLimpiar
        '
        Me.btLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btLimpiar.Image = Global.appFacturacion.My.Resources.Resources.FiltroBorrar
        Me.btLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btLimpiar.Name = "btLimpiar"
        Me.btLimpiar.Size = New System.Drawing.Size(106, 36)
        Me.btLimpiar.Text = "Borrar Filtros"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btImprimir
        '
        Me.btImprimir.ForeColor = System.Drawing.Color.Black
        Me.btImprimir.Image = Global.appFacturacion.My.Resources.Resources.imprimir_det
        Me.btImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(109, 36)
        Me.btImprimir.Text = "Vista Reporte"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.lblNombreEmpresa)
        Me.PanelEx1.Controls.Add(Me.ElGroupBox2)
        Me.PanelEx1.Controls.Add(Me.ElGroupBox1)
        Me.PanelEx1.Controls.Add(Me.ElGroupBox3)
        Me.PanelEx1.Controls.Add(Me.PanelEx2)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx1.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(280, 354)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'lblNombreEmpresa
        '
        '
        '
        '
        Me.lblNombreEmpresa.BackgroundStyle.Class = ""
        Me.lblNombreEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(12, 3)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(256, 35)
        Me.lblNombreEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.lblNombreEmpresa.TabIndex = 5
        Me.lblNombreEmpresa.Text = "NOMBRE DEL NEGOCIO S.A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TARJETA AUXILIAR DE ALMACÉN"
        Me.lblNombreEmpresa.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.lblArticulo)
        Me.PanelEx2.Location = New System.Drawing.Point(12, 44)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(256, 36)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 7
        '
        'lblArticulo
        '
        '
        '
        '
        Me.lblArticulo.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArticulo.BackgroundStyle.BorderBottomWidth = 2
        Me.lblArticulo.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArticulo.BackgroundStyle.BorderLeftWidth = 2
        Me.lblArticulo.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArticulo.BackgroundStyle.BorderRightWidth = 2
        Me.lblArticulo.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArticulo.BackgroundStyle.BorderTopWidth = 2
        Me.lblArticulo.BackgroundStyle.Class = ""
        Me.lblArticulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArticulo.Location = New System.Drawing.Point(2, 2)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(253, 33)
        Me.lblArticulo.TabIndex = 7
        Me.lblArticulo.Text = "ARTICULO: <font color=""#C0504D""><u>_____________________________</u></font>"
        Me.lblArticulo.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'dtRegistro
        '
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(280, 39)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(676, 354)
        Me.dtRegistro.TabIndex = 2
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(280, 39)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(676, 354)
        Me.CrystalReportViewer1.TabIndex = 55
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.Visible = False
        '
        'frmKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 393)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKardex"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarjeta Auxiliar de Inventario Kardex"
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.dtpFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox3.ResumeLayout(False)
        Me.ElGroupBox3.PerformLayout()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtIdAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents dtpFecha1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpFecha2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents ElGroupBox3 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbOperacion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbBodega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents lblNombreEmpresa As DevComponents.DotNetBar.LabelX
    Friend WithEvents btBuscarCliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblArticulo As DevComponents.DotNetBar.LabelX
End Class
