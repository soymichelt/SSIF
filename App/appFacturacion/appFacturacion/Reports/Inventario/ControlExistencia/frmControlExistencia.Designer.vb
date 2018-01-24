<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlExistencia
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlExistencia))
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.cmbExistencia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbBodega = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAplicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtIdOriginal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtIdAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtmarca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dtExistencia = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        Me.Menu.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.dtExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ElGroupBox1.CaptionStyle.Size = New System.Drawing.Size(130, 24)
        Me.ElGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Criterios de Bodega"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.cmbExistencia)
        Me.ElGroupBox1.Controls.Add(Me.Label6)
        Me.ElGroupBox1.Controls.Add(Me.cmbBodega)
        Me.ElGroupBox1.Controls.Add(Me.Label4)
        Me.ElGroupBox1.Location = New System.Drawing.Point(12, 185)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(298, 89)
        Me.ElGroupBox1.TabIndex = 2
        '
        'cmbExistencia
        '
        Me.cmbExistencia.DisplayMember = "Text"
        Me.cmbExistencia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExistencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbExistencia.FormattingEnabled = True
        Me.cmbExistencia.ItemHeight = 14
        Me.cmbExistencia.Items.AddRange(New Object() {Me.ComboItem4, Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.cmbExistencia.Location = New System.Drawing.Point(108, 55)
        Me.cmbExistencia.Name = "cmbExistencia"
        Me.cmbExistencia.Size = New System.Drawing.Size(175, 20)
        Me.cmbExistencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbExistencia.TabIndex = 5
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "MAYORES A CERO"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "MENORES A CERO"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "IGUALES A CERO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Existencia:"
        '
        'cmbBodega
        '
        Me.cmbBodega.DisplayMember = "Text"
        Me.cmbBodega.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.ItemHeight = 14
        Me.cmbBodega.Location = New System.Drawing.Point(108, 30)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(175, 20)
        Me.cmbBodega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBodega.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Selec. Bodega:"
        '
        'txtAplicacion
        '
        '
        '
        '
        Me.txtAplicacion.Border.Class = "TextBoxBorder"
        Me.txtAplicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAplicacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplicacion.Location = New System.Drawing.Point(108, 109)
        Me.txtAplicacion.Name = "txtAplicacion"
        Me.txtAplicacion.Size = New System.Drawing.Size(174, 20)
        Me.txtAplicacion.TabIndex = 4
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(108, 84)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(174, 20)
        Me.txtNombre.TabIndex = 3
        '
        'txtIdOriginal
        '
        '
        '
        '
        Me.txtIdOriginal.Border.Class = "TextBoxBorder"
        Me.txtIdOriginal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdOriginal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdOriginal.Location = New System.Drawing.Point(108, 59)
        Me.txtIdOriginal.Name = "txtIdOriginal"
        Me.txtIdOriginal.Size = New System.Drawing.Size(174, 20)
        Me.txtIdOriginal.TabIndex = 2
        '
        'txtIdAlterno
        '
        '
        '
        '
        Me.txtIdAlterno.Border.Class = "TextBoxBorder"
        Me.txtIdAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdAlterno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdAlterno.Location = New System.Drawing.Point(108, 34)
        Me.txtIdAlterno.Name = "txtIdAlterno"
        Me.txtIdAlterno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIdAlterno.Size = New System.Drawing.Size(174, 20)
        Me.txtIdAlterno.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "ID Alterno:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Nombre Producto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "ID Original:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Aplicación:"
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btBuscar, Me.btLimpiar, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(938, 39)
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
        Me.PanelEx1.Controls.Add(Me.ElGroupBox2)
        Me.PanelEx1.Controls.Add(Me.ElGroupBox1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx1.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(325, 354)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
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
        Me.ElGroupBox2.CaptionStyle.Size = New System.Drawing.Size(130, 24)
        Me.ElGroupBox2.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Criterios de Productos"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.txtmarca)
        Me.ElGroupBox2.Controls.Add(Me.Label7)
        Me.ElGroupBox2.Controls.Add(Me.txtAplicacion)
        Me.ElGroupBox2.Controls.Add(Me.Label5)
        Me.ElGroupBox2.Controls.Add(Me.txtNombre)
        Me.ElGroupBox2.Controls.Add(Me.Label3)
        Me.ElGroupBox2.Controls.Add(Me.txtIdOriginal)
        Me.ElGroupBox2.Controls.Add(Me.Label2)
        Me.ElGroupBox2.Controls.Add(Me.txtIdAlterno)
        Me.ElGroupBox2.Controls.Add(Me.Label1)
        Me.ElGroupBox2.Location = New System.Drawing.Point(12, 7)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(298, 172)
        Me.ElGroupBox2.TabIndex = 1
        '
        'txtmarca
        '
        '
        '
        '
        Me.txtmarca.Border.Class = "TextBoxBorder"
        Me.txtmarca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtmarca.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmarca.Location = New System.Drawing.Point(108, 134)
        Me.txtmarca.Name = "txtmarca"
        Me.txtmarca.Size = New System.Drawing.Size(174, 20)
        Me.txtmarca.TabIndex = 61
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(62, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Marca:"
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.Controls.Add(Me.dtExistencia)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ExpandablePanel1.Expanded = False
        Me.ExpandablePanel1.ExpandedBounds = New System.Drawing.Rectangle(325, 308, 613, 200)
        Me.ExpandablePanel1.ExpandOnTitleClick = True
        Me.ExpandablePanel1.Location = New System.Drawing.Point(325, 367)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(613, 26)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 59
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Existencia del producto: "
        '
        'dtExistencia
        '
        Me.dtExistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtExistencia.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtExistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtExistencia.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dtExistencia.Location = New System.Drawing.Point(0, 26)
        Me.dtExistencia.Name = "dtExistencia"
        Me.dtExistencia.Size = New System.Drawing.Size(613, 0)
        Me.dtExistencia.TabIndex = 5
        '
        'dtRegistro
        '
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(325, 39)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(613, 328)
        Me.dtRegistro.TabIndex = 60
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
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(325, 39)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(613, 328)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.Visible = False
        '
        'frmControlExistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 393)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(946, 39)
        Me.Name = "frmControlExistencia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Existencia de Inventario"
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.dtExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtAplicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIdOriginal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIdAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dtExistencia As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbBodega As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbExistencia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtmarca As DevComponents.DotNetBar.Controls.TextBoxX
End Class
