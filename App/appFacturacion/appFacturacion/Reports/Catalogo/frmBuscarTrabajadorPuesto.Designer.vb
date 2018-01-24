<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarTrabajadorPuesto
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        Me.Menu.SuspendLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(286, 39)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(717, 500)
        Me.dtRegistro.TabIndex = 58
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.ElGroupBox2)
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx2.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(286, 500)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 57
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
        Me.ElGroupBox2.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Puestos"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.txtNombre)
        Me.ElGroupBox2.Controls.Add(Me.Label2)
        Me.ElGroupBox2.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox2.Controls.Add(Me.Label1)
        Me.ElGroupBox2.Location = New System.Drawing.Point(15, 4)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(256, 84)
        Me.ElGroupBox2.TabIndex = 4
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Location = New System.Drawing.Point(97, 52)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(152, 20)
        Me.txtNombre.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Descripción:"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Location = New System.Drawing.Point(97, 27)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(152, 20)
        Me.txtCodigo.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre:"
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btBuscar, Me.btLimpiar, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(1003, 39)
        Me.Menu.TabIndex = 56
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
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(286, 39)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(717, 500)
        Me.CrystalReportViewer1.TabIndex = 59
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.Visible = False
        '
        'frmBuscarTrabajadorPuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 539)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "frmBuscarTrabajadorPuesto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Puestos de la Empresa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
