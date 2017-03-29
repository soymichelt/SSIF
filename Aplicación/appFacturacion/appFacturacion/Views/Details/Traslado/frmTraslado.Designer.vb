<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraslado
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
        Dim PaintStyle1 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraslado))
        Dim PaintStyle2 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle3 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.MenuSistema = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btVendedor = New DevComponents.DotNetBar.ButtonX()
        Me.txtIdVendedor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btActualizarSerie = New DevComponents.DotNetBar.ButtonX()
        Me.txtIdSerie = New System.Windows.Forms.TextBox()
        Me.txtSerie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtReferencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dtpFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtConcepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtReferTraslado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btActualizarBodegaSale = New DevComponents.DotNetBar.ButtonX()
        Me.btActualizarBodegaEntra = New DevComponents.DotNetBar.ButtonX()
        Me.cmbBodegaEntra = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbBodegaSale = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox3 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtTotal = New DevComponents.Editors.DoubleInput()
        Me.ElLabel8 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.ElGroupBox4 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ElLabel1 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.ElLabel4 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.txtCantidad = New DevComponents.Editors.DoubleInput()
        Me.btAgregarProducto = New DevComponents.DotNetBar.ButtonX()
        Me.txtCodigoAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btProducto = New DevComponents.DotNetBar.ButtonX()
        Me.lvRegistro = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sptInfo = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuSistema.SuspendLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox3.SuspendLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox4.SuspendLayout()
        CType(Me.ElLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'MenuSistema
        '
        Me.MenuSistema.BackColor = System.Drawing.Color.White
        Me.MenuSistema.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.MenuSistema.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btAnular, Me.ToolStripSeparator1, Me.btImprimir})
        Me.MenuSistema.Location = New System.Drawing.Point(0, 0)
        Me.MenuSistema.Name = "MenuSistema"
        Me.MenuSistema.Size = New System.Drawing.Size(959, 39)
        Me.MenuSistema.TabIndex = 0
        Me.MenuSistema.Text = "ToolStrip1"
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
        Me.btImprimir.Enabled = False
        Me.btImprimir.ForeColor = System.Drawing.Color.Black
        Me.btImprimir.Image = Global.appFacturacion.My.Resources.Resources.imprimir_det
        Me.btImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(79, 36)
        Me.btImprimir.Text = "Imprimir"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(191, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 14)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Ref.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Serie:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Concepto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(191, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "N° Doc.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 14)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Sale de:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Entra en:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Referencia:"
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Datos Traslado"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.btVendedor)
        Me.ElGroupBox1.Controls.Add(Me.txtIdVendedor)
        Me.ElGroupBox1.Controls.Add(Me.Label6)
        Me.ElGroupBox1.Controls.Add(Me.txtNVendedor)
        Me.ElGroupBox1.Controls.Add(Me.txtNombreVendedor)
        Me.ElGroupBox1.Controls.Add(Me.Label9)
        Me.ElGroupBox1.Controls.Add(Me.btActualizarSerie)
        Me.ElGroupBox1.Controls.Add(Me.txtIdSerie)
        Me.ElGroupBox1.Controls.Add(Me.txtSerie)
        Me.ElGroupBox1.Controls.Add(Me.Label8)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Controls.Add(Me.Label7)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.Label5)
        Me.ElGroupBox1.Controls.Add(Me.Label10)
        Me.ElGroupBox1.Controls.Add(Me.txtReferencia)
        Me.ElGroupBox1.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox1.Controls.Add(Me.dtpFecha)
        Me.ElGroupBox1.Controls.Add(Me.txtConcepto)
        Me.ElGroupBox1.Controls.Add(Me.txtReferTraslado)
        Me.ElGroupBox1.Controls.Add(Me.Label12)
        Me.ElGroupBox1.Controls.Add(Me.Label11)
        Me.ElGroupBox1.Controls.Add(Me.Label13)
        Me.ElGroupBox1.Controls.Add(Me.Label14)
        Me.ElGroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(355, 174)
        Me.ElGroupBox1.TabIndex = 1
        '
        'btVendedor
        '
        Me.btVendedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btVendedor.BackColor = System.Drawing.Color.Transparent
        Me.btVendedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btVendedor.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btVendedor.Location = New System.Drawing.Point(317, 76)
        Me.btVendedor.Name = "btVendedor"
        Me.btVendedor.Size = New System.Drawing.Size(29, 22)
        Me.btVendedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btVendedor.TabIndex = 124
        '
        'txtIdVendedor
        '
        Me.txtIdVendedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdVendedor.Location = New System.Drawing.Point(61, 77)
        Me.txtIdVendedor.Name = "txtIdVendedor"
        Me.txtIdVendedor.ReadOnly = True
        Me.txtIdVendedor.Size = New System.Drawing.Size(5, 20)
        Me.txtIdVendedor.TabIndex = 120
        Me.txtIdVendedor.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "Empleado:"
        '
        'txtNVendedor
        '
        '
        '
        '
        Me.txtNVendedor.Border.Class = "TextBoxBorder"
        Me.txtNVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNVendedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNVendedor.Location = New System.Drawing.Point(69, 77)
        Me.txtNVendedor.Name = "txtNVendedor"
        Me.txtNVendedor.Size = New System.Drawing.Size(102, 20)
        Me.txtNVendedor.TabIndex = 122
        '
        'txtNombreVendedor
        '
        Me.txtNombreVendedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNombreVendedor.Border.Class = "TextBoxBorder"
        Me.txtNombreVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreVendedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreVendedor.Location = New System.Drawing.Point(169, 77)
        Me.txtNombreVendedor.Name = "txtNombreVendedor"
        Me.txtNombreVendedor.ReadOnly = True
        Me.txtNombreVendedor.Size = New System.Drawing.Size(149, 20)
        Me.txtNombreVendedor.TabIndex = 123
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(345, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label9, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label9.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label9.TabIndex = 125
        Me.Label9.Text = "*"
        '
        'btActualizarSerie
        '
        Me.btActualizarSerie.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btActualizarSerie.BackColor = System.Drawing.Color.Transparent
        Me.btActualizarSerie.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btActualizarSerie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btActualizarSerie.Image = Global.appFacturacion.My.Resources.Resources.CargarSerie16x16
        Me.btActualizarSerie.Location = New System.Drawing.Point(142, 28)
        Me.btActualizarSerie.Name = "btActualizarSerie"
        Me.btActualizarSerie.Size = New System.Drawing.Size(29, 22)
        Me.btActualizarSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btActualizarSerie.TabIndex = 2
        '
        'txtIdSerie
        '
        Me.txtIdSerie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSerie.Location = New System.Drawing.Point(63, 29)
        Me.txtIdSerie.Name = "txtIdSerie"
        Me.txtIdSerie.ReadOnly = True
        Me.txtIdSerie.Size = New System.Drawing.Size(5, 20)
        Me.txtIdSerie.TabIndex = 13
        Me.txtIdSerie.Visible = False
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtSerie.Border.Class = "TextBoxBorder"
        Me.txtSerie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSerie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(69, 29)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(74, 20)
        Me.txtSerie.TabIndex = 1
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReferencia.Border.Class = "TextBoxBorder"
        Me.txtReferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReferencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(227, 27)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(120, 20)
        Me.txtReferencia.TabIndex = 3
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(69, 53)
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
        Me.dtpFecha.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(250, 52)
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
        'txtConcepto
        '
        '
        '
        '
        Me.txtConcepto.Border.Class = "TextBoxBorder"
        Me.txtConcepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConcepto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.Location = New System.Drawing.Point(69, 101)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(277, 37)
        Me.txtConcepto.TabIndex = 6
        '
        'txtReferTraslado
        '
        '
        '
        '
        Me.txtReferTraslado.Border.Class = "TextBoxBorder"
        Me.txtReferTraslado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReferTraslado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferTraslado.Location = New System.Drawing.Point(69, 142)
        Me.txtReferTraslado.Name = "txtReferTraslado"
        Me.txtReferTraslado.Size = New System.Drawing.Size(277, 20)
        Me.txtReferTraslado.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(170, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label12, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label12.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(345, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label11, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label11.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(345, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label13, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label13.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label13.TabIndex = 128
        Me.Label13.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(345, 144)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label14, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label14.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "*"
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
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Datos Bodegas"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.btActualizarBodegaSale)
        Me.ElGroupBox2.Controls.Add(Me.btActualizarBodegaEntra)
        Me.ElGroupBox2.Controls.Add(Me.Label4)
        Me.ElGroupBox2.Controls.Add(Me.Label3)
        Me.ElGroupBox2.Controls.Add(Me.cmbBodegaEntra)
        Me.ElGroupBox2.Controls.Add(Me.cmbBodegaSale)
        Me.ElGroupBox2.Controls.Add(Me.Label15)
        Me.ElGroupBox2.Controls.Add(Me.Label16)
        Me.ElGroupBox2.Location = New System.Drawing.Point(12, 186)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(355, 91)
        Me.ElGroupBox2.TabIndex = 2
        '
        'btActualizarBodegaSale
        '
        Me.btActualizarBodegaSale.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btActualizarBodegaSale.BackColor = System.Drawing.Color.Transparent
        Me.btActualizarBodegaSale.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btActualizarBodegaSale.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btActualizarBodegaSale.Image = Global.appFacturacion.My.Resources.Resources.Actualizar_16_16
        Me.btActualizarBodegaSale.Location = New System.Drawing.Point(317, 59)
        Me.btActualizarBodegaSale.Name = "btActualizarBodegaSale"
        Me.btActualizarBodegaSale.Size = New System.Drawing.Size(29, 22)
        Me.btActualizarBodegaSale.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btActualizarBodegaSale.TabIndex = 11
        '
        'btActualizarBodegaEntra
        '
        Me.btActualizarBodegaEntra.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btActualizarBodegaEntra.BackColor = System.Drawing.Color.Transparent
        Me.btActualizarBodegaEntra.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btActualizarBodegaEntra.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btActualizarBodegaEntra.Image = Global.appFacturacion.My.Resources.Resources.Actualizar_16_16
        Me.btActualizarBodegaEntra.Location = New System.Drawing.Point(317, 34)
        Me.btActualizarBodegaEntra.Name = "btActualizarBodegaEntra"
        Me.btActualizarBodegaEntra.Size = New System.Drawing.Size(29, 22)
        Me.btActualizarBodegaEntra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btActualizarBodegaEntra.TabIndex = 9
        '
        'cmbBodegaEntra
        '
        Me.cmbBodegaEntra.DisplayMember = "Text"
        Me.cmbBodegaEntra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBodegaEntra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodegaEntra.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodegaEntra.FormattingEnabled = True
        Me.cmbBodegaEntra.ItemHeight = 14
        Me.cmbBodegaEntra.Location = New System.Drawing.Point(69, 35)
        Me.cmbBodegaEntra.Name = "cmbBodegaEntra"
        Me.cmbBodegaEntra.Size = New System.Drawing.Size(265, 20)
        Me.cmbBodegaEntra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBodegaEntra.TabIndex = 8
        '
        'cmbBodegaSale
        '
        Me.cmbBodegaSale.DisplayMember = "Text"
        Me.cmbBodegaSale.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBodegaSale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodegaSale.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodegaSale.FormattingEnabled = True
        Me.cmbBodegaSale.ItemHeight = 14
        Me.cmbBodegaSale.Location = New System.Drawing.Point(69, 60)
        Me.cmbBodegaSale.Name = "cmbBodegaSale"
        Me.cmbBodegaSale.Size = New System.Drawing.Size(265, 20)
        Me.cmbBodegaSale.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBodegaSale.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(345, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label15, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label15.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label15.TabIndex = 118
        Me.Label15.Text = "*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(345, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label16, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label16.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label16.TabIndex = 119
        Me.Label16.Text = "*"
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.ElGroupBox1)
        Me.PanelEx2.Controls.Add(Me.ElGroupBox2)
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
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ElGroupBox3)
        Me.PanelEx1.Controls.Add(Me.ElGroupBox4)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(394, 39)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(565, 106)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 2
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
        Me.ElGroupBox3.CaptionStyle.Size = New System.Drawing.Size(0, 0)
        Me.ElGroupBox3.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox3.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox3.Controls.Add(Me.txtTotal)
        Me.ElGroupBox3.Controls.Add(Me.ElLabel8)
        Me.ElGroupBox3.Controls.Add(Me.lblContador)
        Me.ElGroupBox3.Location = New System.Drawing.Point(364, 18)
        Me.ElGroupBox3.Name = "ElGroupBox3"
        Me.ElGroupBox3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox3.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox3.Size = New System.Drawing.Size(196, 76)
        Me.ElGroupBox3.TabIndex = 12
        '
        'txtTotal
        '
        '
        '
        '
        Me.txtTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Increment = 1.0R
        Me.txtTotal.IsInputReadOnly = True
        Me.txtTotal.Location = New System.Drawing.Point(96, 6)
        Me.txtTotal.MinValue = 0.0R
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(93, 23)
        Me.txtTotal.TabIndex = 76
        '
        'ElLabel8
        '
        Me.ElLabel8.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle1.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel8.FlashStyle = PaintStyle1
        Me.ElLabel8.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel8.Location = New System.Drawing.Point(7, 6)
        Me.ElLabel8.Name = "ElLabel8"
        Me.ElLabel8.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel8.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel8.TabIndex = 75
        Me.ElLabel8.TabStop = False
        Me.ElLabel8.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel8.TextStyle.Text = "Total Neto:"
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.BackColor = System.Drawing.Color.Transparent
        Me.lblContador.ForeColor = System.Drawing.Color.Black
        Me.lblContador.Location = New System.Drawing.Point(9, 36)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(59, 14)
        Me.lblContador.TabIndex = 4
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
        Me.ElGroupBox4.CaptionStyle.Size = New System.Drawing.Size(0, 0)
        Me.ElGroupBox4.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox4.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox4.Controls.Add(Me.Label19)
        Me.ElGroupBox4.Controls.Add(Me.ElLabel1)
        Me.ElGroupBox4.Controls.Add(Me.ElLabel4)
        Me.ElGroupBox4.Controls.Add(Me.txtCantidad)
        Me.ElGroupBox4.Controls.Add(Me.btAgregarProducto)
        Me.ElGroupBox4.Controls.Add(Me.txtCodigoAlterno)
        Me.ElGroupBox4.Controls.Add(Me.btProducto)
        Me.ElGroupBox4.Location = New System.Drawing.Point(6, 18)
        Me.ElGroupBox4.Name = "ElGroupBox4"
        Me.ElGroupBox4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox4.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox4.Size = New System.Drawing.Size(307, 76)
        Me.ElGroupBox4.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(9, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(251, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label19, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label19.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label19.TabIndex = 78
        Me.Label19.Text = "(*)  CAMPO OBLIGATORIO: INGRESAR DETALLE"
        '
        'ElLabel1
        '
        Me.ElLabel1.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle2.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel1.FlashStyle = PaintStyle2
        Me.ElLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel1.Location = New System.Drawing.Point(7, 31)
        Me.ElLabel1.Name = "ElLabel1"
        Me.ElLabel1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel1.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel1.TabIndex = 74
        Me.ElLabel1.TabStop = False
        Me.ElLabel1.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel1.TextStyle.Text = "Cantidad:"
        '
        'ElLabel4
        '
        Me.ElLabel4.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle3.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel4.FlashStyle = PaintStyle3
        Me.ElLabel4.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel4.Location = New System.Drawing.Point(7, 6)
        Me.ElLabel4.Name = "ElLabel4"
        Me.ElLabel4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel4.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel4.TabIndex = 75
        Me.ElLabel4.TabStop = False
        Me.ElLabel4.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel4.TextStyle.Text = "Producto:"
        '
        'txtCantidad
        '
        '
        '
        '
        Me.txtCantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantidad.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtCantidad.Increment = 1.0R
        Me.txtCantidad.Location = New System.Drawing.Point(96, 31)
        Me.txtCantidad.MinValue = 0.0R
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(101, 23)
        Me.txtCantidad.TabIndex = 9
        Me.txtCantidad.Value = 1.0R
        '
        'btAgregarProducto
        '
        Me.btAgregarProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAgregarProducto.BackColor = System.Drawing.Color.Transparent
        Me.btAgregarProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAgregarProducto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAgregarProducto.Image = Global.appFacturacion.My.Resources.Resources.btn_agregar
        Me.btAgregarProducto.Location = New System.Drawing.Point(272, 6)
        Me.btAgregarProducto.Name = "btAgregarProducto"
        Me.btAgregarProducto.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btAgregarProducto.Size = New System.Drawing.Size(29, 22)
        Me.btAgregarProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAgregarProducto.TabIndex = 8
        '
        'txtCodigoAlterno
        '
        Me.txtCodigoAlterno.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtCodigoAlterno.Border.Class = "TextBoxBorder"
        Me.txtCodigoAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigoAlterno.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodigoAlterno.ForeColor = System.Drawing.Color.Yellow
        Me.txtCodigoAlterno.Location = New System.Drawing.Point(96, 6)
        Me.txtCodigoAlterno.Name = "txtCodigoAlterno"
        Me.txtCodigoAlterno.Size = New System.Drawing.Size(148, 23)
        Me.txtCodigoAlterno.TabIndex = 6
        '
        'btProducto
        '
        Me.btProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btProducto.BackColor = System.Drawing.Color.Transparent
        Me.btProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btProducto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btProducto.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btProducto.Location = New System.Drawing.Point(243, 6)
        Me.btProducto.Name = "btProducto"
        Me.btProducto.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btProducto.Size = New System.Drawing.Size(29, 22)
        Me.btProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btProducto.TabIndex = 7
        '
        'lvRegistro
        '
        Me.lvRegistro.BackColor = System.Drawing.Color.White
        Me.lvRegistro.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.lvRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvRegistro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRegistro.FullRowSelect = True
        Me.lvRegistro.GridLines = True
        Me.lvRegistro.Location = New System.Drawing.Point(394, 145)
        Me.lvRegistro.MultiSelect = False
        Me.lvRegistro.Name = "lvRegistro"
        Me.lvRegistro.Size = New System.Drawing.Size(565, 250)
        Me.lvRegistro.TabIndex = 3
        Me.lvRegistro.UseCompatibleStateImageBehavior = False
        Me.lvRegistro.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Nº PRODUCTO"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Nº PRODUCTO"
        Me.ColumnHeader10.Width = 150
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "COD. ORIGINAL"
        Me.ColumnHeader11.Width = 150
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "DESCRIPCION DEL PRODUCTO"
        Me.ColumnHeader12.Width = 300
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "EXI."
        Me.ColumnHeader14.Width = 100
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "CT."
        Me.ColumnHeader15.Width = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "C / U"
        Me.ColumnHeader16.Width = 100
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "TOTAL"
        Me.ColumnHeader17.Width = 100
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = ""
        Me.ColumnHeader18.Width = 0
        '
        'frmTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 395)
        Me.Controls.Add(Me.lvRegistro)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.MenuSistema)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(227, 27)
        Me.Name = "frmTraslado"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslados de una sucursal a otra"
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuSistema.ResumeLayout(False)
        Me.MenuSistema.PerformLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox3.ResumeLayout(False)
        Me.ElGroupBox3.PerformLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox4.ResumeLayout(False)
        Me.ElGroupBox4.PerformLayout()
        CType(Me.ElLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents MenuSistema As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents btActualizarSerie As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btActualizarBodegaEntra As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btActualizarBodegaSale As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtReferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtpFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtConcepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtReferTraslado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbBodegaEntra As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbBodegaSale As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox3 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents ElLabel8 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents ElGroupBox4 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElLabel1 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElLabel4 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents txtCantidad As DevComponents.Editors.DoubleInput
    Friend WithEvents btAgregarProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCodigoAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lvRegistro As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents sptInfo As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents btVendedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtIdVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombreVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
