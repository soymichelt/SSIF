<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentasPorCobrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentasPorCobrar))
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox6 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtTotal = New DevComponents.Editors.DoubleInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtRazonSocial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btBuscarCliente = New DevComponents.DotNetBar.ButtonX()
        Me.txtNCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtTotalDolar = New DevComponents.Editors.DoubleInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Menu.SuspendLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox6.SuspendLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btBuscar, Me.btLimpiar, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(911, 39)
        Me.Menu.TabIndex = 52
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
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ElGroupBox6)
        Me.PanelEx1.Controls.Add(Me.ElGroupBox1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx1.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(297, 354)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 53
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
        Me.ElGroupBox6.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox6.CaptionStyle.TextStyle.Text = "Resultados"
        Me.ElGroupBox6.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox6.Controls.Add(Me.txtTotalDolar)
        Me.ElGroupBox6.Controls.Add(Me.Label4)
        Me.ElGroupBox6.Controls.Add(Me.txtTotal)
        Me.ElGroupBox6.Controls.Add(Me.Label7)
        Me.ElGroupBox6.Location = New System.Drawing.Point(12, 123)
        Me.ElGroupBox6.Name = "ElGroupBox6"
        Me.ElGroupBox6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox6.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox6.Size = New System.Drawing.Size(256, 87)
        Me.ElGroupBox6.TabIndex = 15
        '
        'txtTotal
        '
        '
        '
        '
        Me.txtTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Increment = 1.0R
        Me.txtTotal.IsInputReadOnly = True
        Me.txtTotal.Location = New System.Drawing.Point(79, 30)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(165, 20)
        Me.txtTotal.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Total (C$):"
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Cliente"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.txtRazonSocial)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Controls.Add(Me.txtNombreCliente)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.ButtonX2)
        Me.ElGroupBox1.Controls.Add(Me.ButtonX1)
        Me.ElGroupBox1.Controls.Add(Me.btBuscarCliente)
        Me.ElGroupBox1.Controls.Add(Me.txtNCliente)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(254, 108)
        Me.ElGroupBox1.TabIndex = 0
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtRazonSocial.Border.Class = "TextBoxBorder"
        Me.txtRazonSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRazonSocial.Location = New System.Drawing.Point(79, 79)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(137, 20)
        Me.txtRazonSocial.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "R. Social:"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNombreCliente.Border.Class = "TextBoxBorder"
        Me.txtNombreCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreCliente.Location = New System.Drawing.Point(79, 54)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(137, 20)
        Me.txtNombreCliente.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre:"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.BackColor = System.Drawing.Color.Transparent
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.ButtonX2.Location = New System.Drawing.Point(215, 78)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(29, 22)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 7
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.ButtonX1.Location = New System.Drawing.Point(215, 53)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(29, 22)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 5
        '
        'btBuscarCliente
        '
        Me.btBuscarCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarCliente.BackColor = System.Drawing.Color.Transparent
        Me.btBuscarCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarCliente.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btBuscarCliente.Location = New System.Drawing.Point(215, 27)
        Me.btBuscarCliente.Name = "btBuscarCliente"
        Me.btBuscarCliente.Size = New System.Drawing.Size(29, 22)
        Me.btBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarCliente.TabIndex = 3
        '
        'txtNCliente
        '
        '
        '
        '
        Me.txtNCliente.Border.Class = "TextBoxBorder"
        Me.txtNCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNCliente.Location = New System.Drawing.Point(79, 28)
        Me.txtNCliente.Name = "txtNCliente"
        Me.txtNCliente.Size = New System.Drawing.Size(137, 20)
        Me.txtNCliente.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código:"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(297, 39)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(614, 354)
        Me.CrystalReportViewer1.TabIndex = 54
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
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
        Me.dtRegistro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(297, 39)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(614, 354)
        Me.dtRegistro.TabIndex = 56
        '
        'txtTotalDolar
        '
        '
        '
        '
        Me.txtTotalDolar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalDolar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalDolar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalDolar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDolar.Increment = 1.0R
        Me.txtTotalDolar.IsInputReadOnly = True
        Me.txtTotalDolar.Location = New System.Drawing.Point(79, 56)
        Me.txtTotalDolar.Name = "txtTotalDolar"
        Me.txtTotalDolar.Size = New System.Drawing.Size(165, 20)
        Me.txtTotalDolar.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Total ($):"
        '
        'frmCuentasPorCobrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 393)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCuentasPorCobrar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por Cobrar"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox6.ResumeLayout(False)
        Me.ElGroupBox6.PerformLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDolar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtRazonSocial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btBuscarCliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ElGroupBox6 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDolar As DevComponents.Editors.DoubleInput
    Friend WithEvents Label4 As Label
End Class
