<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsignacion
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
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ElGroupBox4 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btActualizarSerie = New DevComponents.DotNetBar.ButtonX()
        Me.btAgregarVendedor = New DevComponents.DotNetBar.ButtonX()
        Me.btVendedor = New DevComponents.DotNetBar.ButtonX()
        Me.txtIdVendedor = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.btAgregarCliente = New DevComponents.DotNetBar.ButtonX()
        Me.btCliente = New DevComponents.DotNetBar.ButtonX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSerie = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtReferencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dtpFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtNombreVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lvRegistro = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ElGroupBox3 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConcepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btAgregarProducto = New DevComponents.DotNetBar.ButtonX()
        Me.btProducto = New DevComponents.DotNetBar.ButtonX()
        Me.txtCodigoAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCantidad = New DevComponents.Editors.DoubleInput()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu.SuspendLayout()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox4.SuspendLayout()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(654, 39)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "ToolStrip1"
        '
        'btNuevo
        '
        Me.btNuevo.Image = Global.appFacturacion.My.Resources.Resources.nuevo
        Me.btNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(74, 36)
        Me.btNuevo.Text = "Nuevo"
        '
        'btGuardar
        '
        Me.btGuardar.Image = Global.appFacturacion.My.Resources.Resources.guardar
        Me.btGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(83, 36)
        Me.btGuardar.Text = "Guardar"
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
        Me.ElGroupBox4.CaptionStyle.TextStyle.Text = "Consignación"
        Me.ElGroupBox4.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox4.Controls.Add(Me.btActualizarSerie)
        Me.ElGroupBox4.Controls.Add(Me.btAgregarVendedor)
        Me.ElGroupBox4.Controls.Add(Me.btVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtIdVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtIdCliente)
        Me.ElGroupBox4.Controls.Add(Me.btAgregarCliente)
        Me.ElGroupBox4.Controls.Add(Me.btCliente)
        Me.ElGroupBox4.Controls.Add(Me.Label8)
        Me.ElGroupBox4.Controls.Add(Me.Label1)
        Me.ElGroupBox4.Controls.Add(Me.Label2)
        Me.ElGroupBox4.Controls.Add(Me.Label5)
        Me.ElGroupBox4.Controls.Add(Me.Label10)
        Me.ElGroupBox4.Controls.Add(Me.Label3)
        Me.ElGroupBox4.Controls.Add(Me.cmbSerie)
        Me.ElGroupBox4.Controls.Add(Me.txtReferencia)
        Me.ElGroupBox4.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox4.Controls.Add(Me.dtpFecha)
        Me.ElGroupBox4.Controls.Add(Me.txtNombreVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtNombreCliente)
        Me.ElGroupBox4.Controls.Add(Me.txtNVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtNCliente)
        Me.ElGroupBox4.Location = New System.Drawing.Point(9, 43)
        Me.ElGroupBox4.Name = "ElGroupBox4"
        Me.ElGroupBox4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox4.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox4.Size = New System.Drawing.Size(440, 128)
        Me.ElGroupBox4.TabIndex = 1
        '
        'btActualizarSerie
        '
        Me.btActualizarSerie.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btActualizarSerie.BackColor = System.Drawing.Color.Transparent
        Me.btActualizarSerie.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btActualizarSerie.Image = Global.appFacturacion.My.Resources.Resources.Actualizar_16_16
        Me.btActualizarSerie.Location = New System.Drawing.Point(156, 26)
        Me.btActualizarSerie.Name = "btActualizarSerie"
        Me.btActualizarSerie.Size = New System.Drawing.Size(29, 22)
        Me.btActualizarSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btActualizarSerie.TabIndex = 2
        '
        'btAgregarVendedor
        '
        Me.btAgregarVendedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAgregarVendedor.BackColor = System.Drawing.Color.Transparent
        Me.btAgregarVendedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAgregarVendedor.Image = Global.appFacturacion.My.Resources.Resources.btn_agregar
        Me.btAgregarVendedor.Location = New System.Drawing.Point(401, 74)
        Me.btAgregarVendedor.Name = "btAgregarVendedor"
        Me.btAgregarVendedor.Size = New System.Drawing.Size(29, 22)
        Me.btAgregarVendedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAgregarVendedor.TabIndex = 9
        '
        'btVendedor
        '
        Me.btVendedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btVendedor.BackColor = System.Drawing.Color.Transparent
        Me.btVendedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btVendedor.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btVendedor.Location = New System.Drawing.Point(372, 74)
        Me.btVendedor.Name = "btVendedor"
        Me.btVendedor.Size = New System.Drawing.Size(29, 22)
        Me.btVendedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btVendedor.TabIndex = 8
        '
        'txtIdVendedor
        '
        Me.txtIdVendedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdVendedor.Location = New System.Drawing.Point(75, 75)
        Me.txtIdVendedor.Name = "txtIdVendedor"
        Me.txtIdVendedor.ReadOnly = True
        Me.txtIdVendedor.Size = New System.Drawing.Size(5, 20)
        Me.txtIdVendedor.TabIndex = 110
        Me.txtIdVendedor.Visible = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(75, 99)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(5, 20)
        Me.txtIdCliente.TabIndex = 107
        Me.txtIdCliente.Visible = False
        '
        'btAgregarCliente
        '
        Me.btAgregarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAgregarCliente.BackColor = System.Drawing.Color.Transparent
        Me.btAgregarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAgregarCliente.Image = Global.appFacturacion.My.Resources.Resources.btn_agregar
        Me.btAgregarCliente.Location = New System.Drawing.Point(401, 99)
        Me.btAgregarCliente.Name = "btAgregarCliente"
        Me.btAgregarCliente.Size = New System.Drawing.Size(29, 22)
        Me.btAgregarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAgregarCliente.TabIndex = 13
        '
        'btCliente
        '
        Me.btCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCliente.BackColor = System.Drawing.Color.Transparent
        Me.btCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btCliente.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btCliente.Location = New System.Drawing.Point(372, 99)
        Me.btCliente.Name = "btCliente"
        Me.btCliente.Size = New System.Drawing.Size(29, 22)
        Me.btCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btCliente.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 14)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Serie:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "N° Doc.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(285, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cliente:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(191, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Ref.:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Vendedor:"
        '
        'cmbSerie
        '
        Me.cmbSerie.DisplayMember = "Text"
        Me.cmbSerie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSerie.FormattingEnabled = True
        Me.cmbSerie.ItemHeight = 14
        Me.cmbSerie.Location = New System.Drawing.Point(83, 27)
        Me.cmbSerie.Name = "cmbSerie"
        Me.cmbSerie.Size = New System.Drawing.Size(91, 20)
        Me.cmbSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSerie.TabIndex = 1
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReferencia.Border.Class = "TextBoxBorder"
        Me.txtReferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReferencia.Location = New System.Drawing.Point(222, 27)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(208, 20)
        Me.txtReferencia.TabIndex = 3
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Location = New System.Drawing.Point(83, 52)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(102, 20)
        Me.txtCodigo.TabIndex = 4
        '
        'dtpFecha
        '
        '
        '
        '
        Me.dtpFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFecha.ButtonDropDown.Visible = True
        Me.dtpFecha.Location = New System.Drawing.Point(333, 51)
        '
        '
        '
        Me.dtpFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFecha.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.MonthCalendar.DisplayMonth = New Date(2014, 12, 1, 0, 0, 0, 0)
        Me.dtpFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.MonthCalendar.TodayButtonVisible = True
        Me.dtpFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(97, 20)
        Me.dtpFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFecha.TabIndex = 5
        '
        'txtNombreVendedor
        '
        Me.txtNombreVendedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNombreVendedor.Border.Class = "TextBoxBorder"
        Me.txtNombreVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreVendedor.Location = New System.Drawing.Point(184, 75)
        Me.txtNombreVendedor.Name = "txtNombreVendedor"
        Me.txtNombreVendedor.ReadOnly = True
        Me.txtNombreVendedor.Size = New System.Drawing.Size(189, 20)
        Me.txtNombreVendedor.TabIndex = 7
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNombreCliente.Border.Class = "TextBoxBorder"
        Me.txtNombreCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreCliente.Location = New System.Drawing.Point(184, 99)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(189, 20)
        Me.txtNombreCliente.TabIndex = 11
        '
        'txtNVendedor
        '
        '
        '
        '
        Me.txtNVendedor.Border.Class = "TextBoxBorder"
        Me.txtNVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNVendedor.Location = New System.Drawing.Point(83, 75)
        Me.txtNVendedor.Name = "txtNVendedor"
        Me.txtNVendedor.Size = New System.Drawing.Size(102, 20)
        Me.txtNVendedor.TabIndex = 6
        '
        'txtNCliente
        '
        '
        '
        '
        Me.txtNCliente.Border.Class = "TextBoxBorder"
        Me.txtNCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNCliente.Location = New System.Drawing.Point(83, 99)
        Me.txtNCliente.Name = "txtNCliente"
        Me.txtNCliente.Size = New System.Drawing.Size(102, 20)
        Me.txtNCliente.TabIndex = 10
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.BackColor = System.Drawing.Color.Transparent
        Me.lblContador.ForeColor = System.Drawing.Color.White
        Me.lblContador.Location = New System.Drawing.Point(5, 400)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(59, 14)
        Me.lblContador.TabIndex = 5
        Me.lblContador.Text = "N° ITEM: 0"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Location = New System.Drawing.Point(570, 398)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(72, 20)
        Me.txtTotal.TabIndex = 6
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvRegistro
        '
        Me.lvRegistro.BackColor = System.Drawing.Color.White
        Me.lvRegistro.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader5})
        Me.lvRegistro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRegistro.FullRowSelect = True
        Me.lvRegistro.GridLines = True
        Me.lvRegistro.Location = New System.Drawing.Point(8, 201)
        Me.lvRegistro.MultiSelect = False
        Me.lvRegistro.Name = "lvRegistro"
        Me.lvRegistro.Size = New System.Drawing.Size(634, 197)
        Me.lvRegistro.TabIndex = 4
        Me.lvRegistro.UseCompatibleStateImageBehavior = False
        Me.lvRegistro.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nº PRODUCTO"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "COD. ALTERNO"
        Me.ColumnHeader2.Width = 110
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DESCRIPCION DEL PRODUCTO"
        Me.ColumnHeader3.Width = 246
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "EXI."
        Me.ColumnHeader4.Width = 68
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "S / CNS"
        Me.ColumnHeader7.Width = 68
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "CSN"
        Me.ColumnHeader8.Width = 68
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CT."
        Me.ColumnHeader5.Width = 68
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
        Me.ElGroupBox3.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox3.CaptionStyle.TextStyle.Text = "Observacion"
        Me.ElGroupBox3.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox3.Controls.Add(Me.Label4)
        Me.ElGroupBox3.Controls.Add(Me.txtConcepto)
        Me.ElGroupBox3.Location = New System.Drawing.Point(455, 43)
        Me.ElGroupBox3.Name = "ElGroupBox3"
        Me.ElGroupBox3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox3.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox3.Size = New System.Drawing.Size(187, 129)
        Me.ElGroupBox3.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 14)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Observación:"
        '
        'txtConcepto
        '
        '
        '
        '
        Me.txtConcepto.Border.Class = "TextBoxBorder"
        Me.txtConcepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConcepto.Location = New System.Drawing.Point(7, 51)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(173, 68)
        Me.txtConcepto.TabIndex = 14
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btAgregarProducto)
        Me.PanelEx1.Controls.Add(Me.btProducto)
        Me.PanelEx1.Controls.Add(Me.txtCodigoAlterno)
        Me.PanelEx1.Controls.Add(Me.txtCantidad)
        Me.PanelEx1.Location = New System.Drawing.Point(8, 176)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(635, 26)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 3
        '
        'btAgregarProducto
        '
        Me.btAgregarProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAgregarProducto.BackColor = System.Drawing.Color.Transparent
        Me.btAgregarProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAgregarProducto.Image = Global.appFacturacion.My.Resources.Resources.btn_agregar
        Me.btAgregarProducto.Location = New System.Drawing.Point(141, 2)
        Me.btAgregarProducto.Name = "btAgregarProducto"
        Me.btAgregarProducto.Size = New System.Drawing.Size(29, 22)
        Me.btAgregarProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAgregarProducto.TabIndex = 17
        '
        'btProducto
        '
        Me.btProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btProducto.BackColor = System.Drawing.Color.Transparent
        Me.btProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btProducto.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btProducto.Location = New System.Drawing.Point(112, 2)
        Me.btProducto.Name = "btProducto"
        Me.btProducto.Size = New System.Drawing.Size(29, 22)
        Me.btProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btProducto.TabIndex = 16
        '
        'txtCodigoAlterno
        '
        '
        '
        '
        Me.txtCodigoAlterno.Border.Class = "TextBoxBorder"
        Me.txtCodigoAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigoAlterno.Location = New System.Drawing.Point(3, 3)
        Me.txtCodigoAlterno.Name = "txtCodigoAlterno"
        Me.txtCodigoAlterno.Size = New System.Drawing.Size(110, 20)
        Me.txtCodigoAlterno.TabIndex = 15
        '
        'txtCantidad
        '
        '
        '
        '
        Me.txtCantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantidad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Increment = 1.0R
        Me.txtCantidad.Location = New System.Drawing.Point(561, 3)
        Me.txtCantidad.MinValue = 0.0R
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(70, 20)
        Me.txtCantidad.TabIndex = 18
        Me.txtCantidad.Value = 1.0R
        '
        'frmConsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 418)
        Me.Controls.Add(Me.ElGroupBox3)
        Me.Controls.Add(Me.lblContador)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lvRegistro)
        Me.Controls.Add(Me.ElGroupBox4)
        Me.Controls.Add(Me.Menu)
        Me.Controls.Add(Me.PanelEx1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmConsignacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consignacion"
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox4.ResumeLayout(False)
        Me.ElGroupBox4.PerformLayout()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox3.ResumeLayout(False)
        Me.ElGroupBox3.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ElGroupBox4 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents btActualizarSerie As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btAgregarVendedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btVendedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtIdVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents btAgregarCliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btCliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lvRegistro As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ElGroupBox3 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents cmbSerie As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtReferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtpFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtNombreVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombreCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtConcepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btAgregarProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCodigoAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCantidad As DevComponents.Editors.DoubleInput
End Class
