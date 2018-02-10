<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarProductos
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarProductos))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btExportar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.PanelEx4 = New DevComponents.DotNetBar.PanelEx()
        Me.rdExiPositivo = New System.Windows.Forms.RadioButton()
        Me.rdExiNegativo = New System.Windows.Forms.RadioButton()
        Me.rdExiTodos = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.rdMaxEncima = New System.Windows.Forms.RadioButton()
        Me.rdMaxDebajo = New System.Windows.Forms.RadioButton()
        Me.rdMaxTodos = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.rdMinEncima = New System.Windows.Forms.RadioButton()
        Me.rdMinDebajo = New System.Windows.Forms.RadioButton()
        Me.rdMinTodos = New System.Windows.Forms.RadioButton()
        Me.txtUbicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtForma = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDistribuidor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLaboratorio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNombreComercial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMarca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAplicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtIdOriginal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtIdAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dtExistencia = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.contextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreview = New System.Windows.Forms.ToolStripMenuItem()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.btExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx4.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.dtExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextMenu.SuspendLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ElGroupBox1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1046, 115)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Criterios de búsqueda"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.btExportar)
        Me.ElGroupBox1.Controls.Add(Me.lblContador)
        Me.ElGroupBox1.Controls.Add(Me.PanelEx4)
        Me.ElGroupBox1.Controls.Add(Me.Label13)
        Me.ElGroupBox1.Controls.Add(Me.PanelEx3)
        Me.ElGroupBox1.Controls.Add(Me.Label12)
        Me.ElGroupBox1.Controls.Add(Me.PanelEx2)
        Me.ElGroupBox1.Controls.Add(Me.txtUbicacion)
        Me.ElGroupBox1.Controls.Add(Me.Label10)
        Me.ElGroupBox1.Controls.Add(Me.txtForma)
        Me.ElGroupBox1.Controls.Add(Me.Label9)
        Me.ElGroupBox1.Controls.Add(Me.txtDistribuidor)
        Me.ElGroupBox1.Controls.Add(Me.Label8)
        Me.ElGroupBox1.Controls.Add(Me.txtLaboratorio)
        Me.ElGroupBox1.Controls.Add(Me.Label7)
        Me.ElGroupBox1.Controls.Add(Me.txtNombreComercial)
        Me.ElGroupBox1.Controls.Add(Me.Label11)
        Me.ElGroupBox1.Controls.Add(Me.Label6)
        Me.ElGroupBox1.Controls.Add(Me.txtMarca)
        Me.ElGroupBox1.Controls.Add(Me.Label4)
        Me.ElGroupBox1.Controls.Add(Me.txtAplicacion)
        Me.ElGroupBox1.Controls.Add(Me.txtNombre)
        Me.ElGroupBox1.Controls.Add(Me.txtIdOriginal)
        Me.ElGroupBox1.Controls.Add(Me.txtIdAlterno)
        Me.ElGroupBox1.Controls.Add(Me.Label5)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(1046, 115)
        Me.ElGroupBox1.TabIndex = 0
        '
        'btExportar
        '
        Me.btExportar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btExportar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btExportar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btExportar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btExportar.BorderStyle.EdgeRadius = 7
        Me.btExportar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btExportar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btExportar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btExportar.ForegroundImageStyle.Image = Global.appFacturacion.My.Resources.Resources.Exportar24x24
        Me.btExportar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btExportar.Location = New System.Drawing.Point(870, 78)
        Me.btExportar.Name = "btExportar"
        Me.btExportar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlack
        Me.btExportar.Size = New System.Drawing.Size(147, 31)
        Me.btExportar.TabIndex = 74
        Me.btExportar.TextStyle.Text = "Exportar Búsqueda"
        Me.btExportar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.BackColor = System.Drawing.Color.Transparent
        Me.lblContador.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContador.ForeColor = System.Drawing.Color.Black
        Me.lblContador.Location = New System.Drawing.Point(9, 88)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(59, 14)
        Me.lblContador.TabIndex = 72
        Me.lblContador.Text = "N° ITEM: 0"
        '
        'PanelEx4
        '
        Me.PanelEx4.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx4.Controls.Add(Me.rdExiPositivo)
        Me.PanelEx4.Controls.Add(Me.rdExiNegativo)
        Me.PanelEx4.Controls.Add(Me.rdExiTodos)
        Me.PanelEx4.Location = New System.Drawing.Point(645, 78)
        Me.PanelEx4.Name = "PanelEx4"
        Me.PanelEx4.Size = New System.Drawing.Size(182, 31)
        Me.PanelEx4.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx4.Style.GradientAngle = 90
        Me.PanelEx4.TabIndex = 47
        '
        'rdExiPositivo
        '
        Me.rdExiPositivo.AutoSize = True
        Me.rdExiPositivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdExiPositivo.Location = New System.Drawing.Point(122, 6)
        Me.rdExiPositivo.Name = "rdExiPositivo"
        Me.rdExiPositivo.Size = New System.Drawing.Size(62, 18)
        Me.rdExiPositivo.TabIndex = 2
        Me.rdExiPositivo.Text = "Positiva"
        Me.rdExiPositivo.UseVisualStyleBackColor = True
        '
        'rdExiNegativo
        '
        Me.rdExiNegativo.AutoSize = True
        Me.rdExiNegativo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdExiNegativo.Location = New System.Drawing.Point(56, 6)
        Me.rdExiNegativo.Name = "rdExiNegativo"
        Me.rdExiNegativo.Size = New System.Drawing.Size(67, 18)
        Me.rdExiNegativo.TabIndex = 1
        Me.rdExiNegativo.Text = "Negativa"
        Me.rdExiNegativo.UseVisualStyleBackColor = True
        '
        'rdExiTodos
        '
        Me.rdExiTodos.AutoSize = True
        Me.rdExiTodos.Checked = True
        Me.rdExiTodos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdExiTodos.Location = New System.Drawing.Point(3, 6)
        Me.rdExiTodos.Name = "rdExiTodos"
        Me.rdExiTodos.Size = New System.Drawing.Size(54, 18)
        Me.rdExiTodos.TabIndex = 0
        Me.rdExiTodos.TabStop = True
        Me.rdExiTodos.Text = "Todos"
        Me.rdExiTodos.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(584, 86)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 14)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Existencia:"
        '
        'PanelEx3
        '
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.rdMaxEncima)
        Me.PanelEx3.Controls.Add(Me.rdMaxDebajo)
        Me.PanelEx3.Controls.Add(Me.rdMaxTodos)
        Me.PanelEx3.Location = New System.Drawing.Point(412, 78)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(170, 31)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 45
        '
        'rdMaxEncima
        '
        Me.rdMaxEncima.AutoSize = True
        Me.rdMaxEncima.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMaxEncima.Location = New System.Drawing.Point(113, 6)
        Me.rdMaxEncima.Name = "rdMaxEncima"
        Me.rdMaxEncima.Size = New System.Drawing.Size(59, 18)
        Me.rdMaxEncima.TabIndex = 2
        Me.rdMaxEncima.Text = "Encima"
        Me.rdMaxEncima.UseVisualStyleBackColor = True
        '
        'rdMaxDebajo
        '
        Me.rdMaxDebajo.AutoSize = True
        Me.rdMaxDebajo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMaxDebajo.Location = New System.Drawing.Point(56, 6)
        Me.rdMaxDebajo.Name = "rdMaxDebajo"
        Me.rdMaxDebajo.Size = New System.Drawing.Size(58, 18)
        Me.rdMaxDebajo.TabIndex = 1
        Me.rdMaxDebajo.Text = "Debajo"
        Me.rdMaxDebajo.UseVisualStyleBackColor = True
        '
        'rdMaxTodos
        '
        Me.rdMaxTodos.AutoSize = True
        Me.rdMaxTodos.Checked = True
        Me.rdMaxTodos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMaxTodos.Location = New System.Drawing.Point(3, 6)
        Me.rdMaxTodos.Name = "rdMaxTodos"
        Me.rdMaxTodos.Size = New System.Drawing.Size(54, 18)
        Me.rdMaxTodos.TabIndex = 0
        Me.rdMaxTodos.TabStop = True
        Me.rdMaxTodos.Text = "Todos"
        Me.rdMaxTodos.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(363, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 14)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Máximo:"
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.rdMinEncima)
        Me.PanelEx2.Controls.Add(Me.rdMinDebajo)
        Me.PanelEx2.Controls.Add(Me.rdMinTodos)
        Me.PanelEx2.Location = New System.Drawing.Point(191, 78)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(170, 31)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 43
        '
        'rdMinEncima
        '
        Me.rdMinEncima.AutoSize = True
        Me.rdMinEncima.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMinEncima.Location = New System.Drawing.Point(113, 6)
        Me.rdMinEncima.Name = "rdMinEncima"
        Me.rdMinEncima.Size = New System.Drawing.Size(59, 18)
        Me.rdMinEncima.TabIndex = 2
        Me.rdMinEncima.Text = "Encima"
        Me.rdMinEncima.UseVisualStyleBackColor = True
        '
        'rdMinDebajo
        '
        Me.rdMinDebajo.AutoSize = True
        Me.rdMinDebajo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMinDebajo.Location = New System.Drawing.Point(56, 6)
        Me.rdMinDebajo.Name = "rdMinDebajo"
        Me.rdMinDebajo.Size = New System.Drawing.Size(58, 18)
        Me.rdMinDebajo.TabIndex = 1
        Me.rdMinDebajo.Text = "Debajo"
        Me.rdMinDebajo.UseVisualStyleBackColor = True
        '
        'rdMinTodos
        '
        Me.rdMinTodos.AutoSize = True
        Me.rdMinTodos.Checked = True
        Me.rdMinTodos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMinTodos.Location = New System.Drawing.Point(3, 6)
        Me.rdMinTodos.Name = "rdMinTodos"
        Me.rdMinTodos.Size = New System.Drawing.Size(54, 18)
        Me.rdMinTodos.TabIndex = 0
        Me.rdMinTodos.TabStop = True
        Me.rdMinTodos.Text = "Todos"
        Me.rdMinTodos.UseVisualStyleBackColor = True
        '
        'txtUbicacion
        '
        '
        '
        '
        Me.txtUbicacion.Border.Class = "TextBoxBorder"
        Me.txtUbicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUbicacion.Location = New System.Drawing.Point(772, 52)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(100, 20)
        Me.txtUbicacion.TabIndex = 40
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(713, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 14)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Dimencion:"
        '
        'txtForma
        '
        '
        '
        '
        Me.txtForma.Border.Class = "TextBoxBorder"
        Me.txtForma.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtForma.Location = New System.Drawing.Point(607, 52)
        Me.txtForma.Name = "txtForma"
        Me.txtForma.Size = New System.Drawing.Size(100, 20)
        Me.txtForma.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(528, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 14)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Presentación:"
        '
        'txtDistribuidor
        '
        '
        '
        '
        Me.txtDistribuidor.Border.Class = "TextBoxBorder"
        Me.txtDistribuidor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDistribuidor.Location = New System.Drawing.Point(422, 52)
        Me.txtDistribuidor.Name = "txtDistribuidor"
        Me.txtDistribuidor.Size = New System.Drawing.Size(100, 20)
        Me.txtDistribuidor.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(356, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 14)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Proveedor:"
        '
        'txtLaboratorio
        '
        '
        '
        '
        Me.txtLaboratorio.Border.Class = "TextBoxBorder"
        Me.txtLaboratorio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLaboratorio.Location = New System.Drawing.Point(247, 52)
        Me.txtLaboratorio.Name = "txtLaboratorio"
        Me.txtLaboratorio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLaboratorio.Size = New System.Drawing.Size(100, 20)
        Me.txtLaboratorio.TabIndex = 34
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(176, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 14)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Empresa:"
        '
        'txtNombreComercial
        '
        '
        '
        '
        Me.txtNombreComercial.Border.Class = "TextBoxBorder"
        Me.txtNombreComercial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreComercial.Location = New System.Drawing.Point(70, 52)
        Me.txtNombreComercial.Name = "txtNombreComercial"
        Me.txtNombreComercial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNombreComercial.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreComercial.TabIndex = 32
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(145, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Mínimo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 14)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Modelo:"
        '
        'txtMarca
        '
        '
        '
        '
        Me.txtMarca.Border.Class = "TextBoxBorder"
        Me.txtMarca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMarca.Location = New System.Drawing.Point(917, 52)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(100, 20)
        Me.txtMarca.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(878, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Marca:"
        '
        'txtAplicacion
        '
        '
        '
        '
        Me.txtAplicacion.Border.Class = "TextBoxBorder"
        Me.txtAplicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAplicacion.Location = New System.Drawing.Point(607, 28)
        Me.txtAplicacion.Name = "txtAplicacion"
        Me.txtAplicacion.Size = New System.Drawing.Size(410, 20)
        Me.txtAplicacion.TabIndex = 4
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Location = New System.Drawing.Point(422, 28)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(100, 20)
        Me.txtNombre.TabIndex = 3
        '
        'txtIdOriginal
        '
        '
        '
        '
        Me.txtIdOriginal.Border.Class = "TextBoxBorder"
        Me.txtIdOriginal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdOriginal.Location = New System.Drawing.Point(247, 28)
        Me.txtIdOriginal.Name = "txtIdOriginal"
        Me.txtIdOriginal.Size = New System.Drawing.Size(100, 20)
        Me.txtIdOriginal.TabIndex = 2
        '
        'txtIdAlterno
        '
        '
        '
        '
        Me.txtIdAlterno.Border.Class = "TextBoxBorder"
        Me.txtIdAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdAlterno.Location = New System.Drawing.Point(70, 28)
        Me.txtIdAlterno.Name = "txtIdAlterno"
        Me.txtIdAlterno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIdAlterno.Size = New System.Drawing.Size(100, 20)
        Me.txtIdAlterno.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "ID Alterno:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(356, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(176, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "ID Original:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(528, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Aplicación:"
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.Controls.Add(Me.dtExistencia)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ExpandablePanel1.Expanded = False
        Me.ExpandablePanel1.ExpandedBounds = New System.Drawing.Rectangle(0, 347, 930, 161)
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 367)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(1046, 26)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 2
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Existencias de productos en otras bodegas"
        '
        'dtExistencia
        '
        Me.dtExistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtExistencia.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtExistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtExistencia.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dtExistencia.Location = New System.Drawing.Point(0, 26)
        Me.dtExistencia.Name = "dtExistencia"
        Me.dtExistencia.Size = New System.Drawing.Size(930, 0)
        Me.dtExistencia.TabIndex = 4
        '
        'dtRegistro
        '
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(0, 115)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(1046, 252)
        Me.dtRegistro.TabIndex = 3
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 115)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1046, 252)
        Me.CrystalReportViewer1.TabIndex = 4
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.Visible = False
        '
        'contextMenu
        '
        Me.contextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelect, Me.ToolStripSeparator1, Me.mnuPreview})
        Me.contextMenu.Name = "contextMenu"
        Me.contextMenu.Size = New System.Drawing.Size(153, 76)
        '
        'mnuSelect
        '
        Me.mnuSelect.Name = "mnuSelect"
        Me.mnuSelect.Size = New System.Drawing.Size(152, 22)
        Me.mnuSelect.Text = "Seleccionar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'mnuPreview
        '
        Me.mnuPreview.Name = "mnuPreview"
        Me.mnuPreview.Size = New System.Drawing.Size(152, 22)
        Me.mnuPreview.Text = "Vista Previa"
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
        'frmBuscarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 393)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.PanelEx1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmBuscarProductos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.btExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx4.ResumeLayout(False)
        Me.PanelEx4.PerformLayout()
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx3.PerformLayout()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.dtExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextMenu.ResumeLayout(False)
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtAplicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIdOriginal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIdAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtExistencia As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtMarca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtForma As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDistribuidor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLaboratorio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNombreComercial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUbicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents rdMinTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdMinDebajo As System.Windows.Forms.RadioButton
    Friend WithEvents rdMinEncima As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents rdMaxEncima As System.Windows.Forms.RadioButton
    Friend WithEvents rdMaxDebajo As System.Windows.Forms.RadioButton
    Friend WithEvents rdMaxTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PanelEx4 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents rdExiPositivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdExiNegativo As System.Windows.Forms.RadioButton
    Friend WithEvents rdExiTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents btExportar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents contextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
End Class
