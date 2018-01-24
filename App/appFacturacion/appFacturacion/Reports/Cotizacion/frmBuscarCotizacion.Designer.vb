<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarCotizacion
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
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btBuscarTrabajador = New DevComponents.DotNetBar.ButtonX()
        Me.txtNombreTrabajador = New System.Windows.Forms.TextBox()
        Me.rdNombreTrabajador = New System.Windows.Forms.RadioButton()
        Me.txtIdTrabajador = New System.Windows.Forms.TextBox()
        Me.rdIdTrabajador = New System.Windows.Forms.RadioButton()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btBuscarCliente = New DevComponents.DotNetBar.ButtonX()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.rdNombreCliente = New System.Windows.Forms.RadioButton()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.rdIdCliente = New System.Windows.Forms.RadioButton()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvRegistro = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Busqueda"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.GroupPanel3)
        Me.ElGroupBox1.Controls.Add(Me.GroupPanel2)
        Me.ElGroupBox1.Controls.Add(Me.GroupPanel1)
        Me.ElGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ElGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(1008, 112)
        Me.ElGroupBox1.TabIndex = 24
        Me.ElGroupBox1.TransparentStyle.BackColor = System.Drawing.Color.Transparent
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.btBuscarTrabajador)
        Me.GroupPanel3.Controls.Add(Me.txtNombreTrabajador)
        Me.GroupPanel3.Controls.Add(Me.rdNombreTrabajador)
        Me.GroupPanel3.Controls.Add(Me.txtIdTrabajador)
        Me.GroupPanel3.Controls.Add(Me.rdIdTrabajador)
        Me.GroupPanel3.Location = New System.Drawing.Point(452, 30)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(233, 74)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.Class = ""
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.Class = ""
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.Class = ""
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 16
        Me.GroupPanel3.Text = "Por Trabajador"
        '
        'btBuscarTrabajador
        '
        Me.btBuscarTrabajador.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarTrabajador.BackColor = System.Drawing.Color.Transparent
        Me.btBuscarTrabajador.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarTrabajador.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btBuscarTrabajador.Location = New System.Drawing.Point(192, 2)
        Me.btBuscarTrabajador.Name = "btBuscarTrabajador"
        Me.btBuscarTrabajador.Size = New System.Drawing.Size(29, 22)
        Me.btBuscarTrabajador.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarTrabajador.TabIndex = 100
        '
        'txtNombreTrabajador
        '
        Me.txtNombreTrabajador.Enabled = False
        Me.txtNombreTrabajador.Location = New System.Drawing.Point(75, 28)
        Me.txtNombreTrabajador.Name = "txtNombreTrabajador"
        Me.txtNombreTrabajador.Size = New System.Drawing.Size(146, 21)
        Me.txtNombreTrabajador.TabIndex = 13
        '
        'rdNombreTrabajador
        '
        Me.rdNombreTrabajador.AutoSize = True
        Me.rdNombreTrabajador.Location = New System.Drawing.Point(5, 27)
        Me.rdNombreTrabajador.Name = "rdNombreTrabajador"
        Me.rdNombreTrabajador.Size = New System.Drawing.Size(64, 19)
        Me.rdNombreTrabajador.TabIndex = 12
        Me.rdNombreTrabajador.Text = "Nomb.:"
        Me.rdNombreTrabajador.UseVisualStyleBackColor = True
        '
        'txtIdTrabajador
        '
        Me.txtIdTrabajador.Location = New System.Drawing.Point(75, 3)
        Me.txtIdTrabajador.Name = "txtIdTrabajador"
        Me.txtIdTrabajador.Size = New System.Drawing.Size(59, 21)
        Me.txtIdTrabajador.TabIndex = 11
        '
        'rdIdTrabajador
        '
        Me.rdIdTrabajador.AutoSize = True
        Me.rdIdTrabajador.Checked = True
        Me.rdIdTrabajador.Location = New System.Drawing.Point(5, 2)
        Me.rdIdTrabajador.Name = "rdIdTrabajador"
        Me.rdIdTrabajador.Size = New System.Drawing.Size(38, 19)
        Me.rdIdTrabajador.TabIndex = 10
        Me.rdIdTrabajador.TabStop = True
        Me.rdIdTrabajador.Text = "Id:"
        Me.rdIdTrabajador.UseVisualStyleBackColor = True
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.btBuscarCliente)
        Me.GroupPanel2.Controls.Add(Me.txtNombreCliente)
        Me.GroupPanel2.Controls.Add(Me.rdNombreCliente)
        Me.GroupPanel2.Controls.Add(Me.txtIdCliente)
        Me.GroupPanel2.Controls.Add(Me.rdIdCliente)
        Me.GroupPanel2.Location = New System.Drawing.Point(213, 30)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(233, 74)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.Class = ""
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.Class = ""
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.Class = ""
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 15
        Me.GroupPanel2.Text = "Por Cliente"
        '
        'btBuscarCliente
        '
        Me.btBuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarCliente.BackColor = System.Drawing.Color.Transparent
        Me.btBuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarCliente.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btBuscarCliente.Location = New System.Drawing.Point(192, 2)
        Me.btBuscarCliente.Name = "btBuscarCliente"
        Me.btBuscarCliente.Size = New System.Drawing.Size(29, 22)
        Me.btBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarCliente.TabIndex = 100
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Enabled = False
        Me.txtNombreCliente.Location = New System.Drawing.Point(75, 28)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(146, 21)
        Me.txtNombreCliente.TabIndex = 13
        '
        'rdNombreCliente
        '
        Me.rdNombreCliente.AutoSize = True
        Me.rdNombreCliente.Location = New System.Drawing.Point(5, 27)
        Me.rdNombreCliente.Name = "rdNombreCliente"
        Me.rdNombreCliente.Size = New System.Drawing.Size(64, 19)
        Me.rdNombreCliente.TabIndex = 12
        Me.rdNombreCliente.Text = "Nomb.:"
        Me.rdNombreCliente.UseVisualStyleBackColor = True
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Location = New System.Drawing.Point(75, 3)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(59, 21)
        Me.txtIdCliente.TabIndex = 11
        '
        'rdIdCliente
        '
        Me.rdIdCliente.AutoSize = True
        Me.rdIdCliente.Checked = True
        Me.rdIdCliente.Location = New System.Drawing.Point(5, 2)
        Me.rdIdCliente.Name = "rdIdCliente"
        Me.rdIdCliente.Size = New System.Drawing.Size(38, 19)
        Me.rdIdCliente.TabIndex = 10
        Me.rdIdCliente.TabStop = True
        Me.rdIdCliente.Text = "Id:"
        Me.rdIdCliente.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.dtpFechaInicial)
        Me.GroupPanel1.Controls.Add(Me.dtpFechaFinal)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 30)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(195, 74)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.Class = ""
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.Class = ""
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.Class = ""
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 14
        Me.GroupPanel1.Text = "Rango de Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha Inicial:"
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.CalendarForeColor = System.Drawing.Color.Blue
        Me.dtpFechaInicial.CalendarTitleBackColor = System.Drawing.Color.Red
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicial.Location = New System.Drawing.Point(85, 4)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(95, 21)
        Me.dtpFechaInicial.TabIndex = 2
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CalendarForeColor = System.Drawing.Color.Blue
        Me.dtpFechaFinal.CalendarTitleBackColor = System.Drawing.Color.Red
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(84, 27)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(97, 21)
        Me.dtpFechaFinal.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Final:"
        '
        'lvRegistro
        '
        Me.lvRegistro.BackColor = System.Drawing.Color.White
        Me.lvRegistro.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.lvRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvRegistro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRegistro.ForeColor = System.Drawing.Color.Blue
        Me.lvRegistro.FullRowSelect = True
        Me.lvRegistro.GridLines = True
        Me.lvRegistro.LabelEdit = True
        Me.lvRegistro.Location = New System.Drawing.Point(0, 112)
        Me.lvRegistro.MultiSelect = False
        Me.lvRegistro.Name = "lvRegistro"
        Me.lvRegistro.Size = New System.Drawing.Size(1008, 410)
        Me.lvRegistro.TabIndex = 25
        Me.lvRegistro.UseCompatibleStateImageBehavior = False
        Me.lvRegistro.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID FACTURA"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "SER"
        Me.ColumnHeader2.Width = 40
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "CONSECUT."
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "FECHA"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "CLIENTE"
        Me.ColumnHeader27.Width = 200
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "VENDEDOR"
        Me.ColumnHeader28.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CRED."
        Me.ColumnHeader5.Width = 47
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "FECH. CRE. V."
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "D. T."
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "SUBTOTAL"
        Me.ColumnHeader10.Width = 80
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "I. V. A"
        Me.ColumnHeader11.Width = 80
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "TOTAL"
        Me.ColumnHeader12.Width = 80
        '
        'frmBuscarCotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1008, 522)
        Me.Controls.Add(Me.lvRegistro)
        Me.Controls.Add(Me.ElGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "frmBuscarCotizacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Cotización"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents lvRegistro As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btBuscarTrabajador As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNombreTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents rdNombreTrabajador As System.Windows.Forms.RadioButton
    Friend WithEvents txtIdTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents rdIdTrabajador As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btBuscarCliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents rdNombreCliente As System.Windows.Forms.RadioButton
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents rdIdCliente As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
