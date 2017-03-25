<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.opArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.btEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.chkSalesPriceChange = New System.Windows.Forms.CheckBox()
        Me.chkContabilidad = New System.Windows.Forms.CheckBox()
        Me.chkInventario = New System.Windows.Forms.CheckBox()
        Me.chkCompra = New System.Windows.Forms.CheckBox()
        Me.chkVenta = New System.Windows.Forms.CheckBox()
        Me.chkConsultasContabilidad = New System.Windows.Forms.CheckBox()
        Me.chkConsultasInventario = New System.Windows.Forms.CheckBox()
        Me.chkConsultasCompra = New System.Windows.Forms.CheckBox()
        Me.chkConsultasVenta = New System.Windows.Forms.CheckBox()
        Me.chkConsultasAdministrador = New System.Windows.Forms.CheckBox()
        Me.chkAdministrador = New System.Windows.Forms.CheckBox()
        Me.ElGroupBox4 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkMostrar = New System.Windows.Forms.CheckBox()
        Me.txtObservacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtContraseña = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtApellidos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombres = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnContImage = New DevComponents.DotNetBar.PanelEx()
        Me.btImagen = New DevComponents.DotNetBar.ButtonX()
        Me.txtImagen = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.pnImagen = New DevComponents.DotNetBar.PanelEx()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox4.SuspendLayout()
        Me.pnContImage.SuspendLayout()
        Me.SuspendLayout()
        '
        'opArchivo
        '
        Me.opArchivo.Filter = "Imagenes (.jpg, .jpeg, .png, .gif)|*.jpg;*.jpeg;*.png;*.gif"
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
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btEditar, Me.btEliminar, Me.ToolStripSeparator1, Me.btBuscar})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(682, 39)
        Me.Menu.TabIndex = 36
        Me.Menu.Text = "ToolStrip1"
        '
        'btNuevo
        '
        Me.btNuevo.ForeColor = System.Drawing.Color.Black
        Me.btNuevo.Image = Global.appFacturacion.My.Resources.Resources.nuevo
        Me.btNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(74, 36)
        Me.btNuevo.Text = "Nuevo"
        '
        'btGuardar
        '
        Me.btGuardar.ForeColor = System.Drawing.Color.Black
        Me.btGuardar.Image = Global.appFacturacion.My.Resources.Resources.guardar
        Me.btGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(83, 36)
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
        'btEliminar
        '
        Me.btEliminar.Enabled = False
        Me.btEliminar.ForeColor = System.Drawing.Color.Black
        Me.btEliminar.Image = Global.appFacturacion.My.Resources.Resources.eliminar
        Me.btEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(95, 36)
        Me.btEliminar.Text = "Desactivar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btBuscar
        '
        Me.btBuscar.Image = Global.appFacturacion.My.Resources.Resources.buscar_det
        Me.btBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(78, 36)
        Me.btBuscar.Text = "Buscar"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ElGroupBox1)
        Me.PanelEx1.Controls.Add(Me.ElGroupBox4)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx1.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(307, 368)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 37
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Labores"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.chkSalesPriceChange)
        Me.ElGroupBox1.Controls.Add(Me.chkContabilidad)
        Me.ElGroupBox1.Controls.Add(Me.chkInventario)
        Me.ElGroupBox1.Controls.Add(Me.chkCompra)
        Me.ElGroupBox1.Controls.Add(Me.chkVenta)
        Me.ElGroupBox1.Controls.Add(Me.chkConsultasContabilidad)
        Me.ElGroupBox1.Controls.Add(Me.chkConsultasInventario)
        Me.ElGroupBox1.Controls.Add(Me.chkConsultasCompra)
        Me.ElGroupBox1.Controls.Add(Me.chkConsultasVenta)
        Me.ElGroupBox1.Controls.Add(Me.chkConsultasAdministrador)
        Me.ElGroupBox1.Controls.Add(Me.chkAdministrador)
        Me.ElGroupBox1.Location = New System.Drawing.Point(12, 183)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(279, 178)
        Me.ElGroupBox1.TabIndex = 3
        '
        'chkSalesPriceChange
        '
        Me.chkSalesPriceChange.AutoSize = True
        Me.chkSalesPriceChange.Location = New System.Drawing.Point(12, 144)
        Me.chkSalesPriceChange.Name = "chkSalesPriceChange"
        Me.chkSalesPriceChange.Size = New System.Drawing.Size(132, 18)
        Me.chkSalesPriceChange.TabIndex = 143
        Me.chkSalesPriceChange.Text = "Editar Precio de Venta"
        Me.chkSalesPriceChange.UseVisualStyleBackColor = True
        '
        'chkContabilidad
        '
        Me.chkContabilidad.AutoSize = True
        Me.chkContabilidad.Location = New System.Drawing.Point(12, 120)
        Me.chkContabilidad.Name = "chkContabilidad"
        Me.chkContabilidad.Size = New System.Drawing.Size(84, 18)
        Me.chkContabilidad.TabIndex = 144
        Me.chkContabilidad.Text = "Contabilidad"
        Me.chkContabilidad.UseVisualStyleBackColor = True
        '
        'chkInventario
        '
        Me.chkInventario.AutoSize = True
        Me.chkInventario.Location = New System.Drawing.Point(12, 98)
        Me.chkInventario.Name = "chkInventario"
        Me.chkInventario.Size = New System.Drawing.Size(73, 18)
        Me.chkInventario.TabIndex = 144
        Me.chkInventario.Text = "Inventario"
        Me.chkInventario.UseVisualStyleBackColor = True
        '
        'chkCompra
        '
        Me.chkCompra.AutoSize = True
        Me.chkCompra.Location = New System.Drawing.Point(12, 74)
        Me.chkCompra.Name = "chkCompra"
        Me.chkCompra.Size = New System.Drawing.Size(63, 18)
        Me.chkCompra.TabIndex = 144
        Me.chkCompra.Text = "Compra"
        Me.chkCompra.UseVisualStyleBackColor = True
        '
        'chkVenta
        '
        Me.chkVenta.AutoSize = True
        Me.chkVenta.Location = New System.Drawing.Point(12, 52)
        Me.chkVenta.Name = "chkVenta"
        Me.chkVenta.Size = New System.Drawing.Size(54, 18)
        Me.chkVenta.TabIndex = 143
        Me.chkVenta.Text = "Venta"
        Me.chkVenta.UseVisualStyleBackColor = True
        '
        'chkConsultasContabilidad
        '
        Me.chkConsultasContabilidad.AutoSize = True
        Me.chkConsultasContabilidad.Location = New System.Drawing.Point(111, 120)
        Me.chkConsultasContabilidad.Name = "chkConsultasContabilidad"
        Me.chkConsultasContabilidad.Size = New System.Drawing.Size(150, 18)
        Me.chkConsultasContabilidad.TabIndex = 142
        Me.chkConsultasContabilidad.Text = "Consultas de Contabilidad"
        Me.chkConsultasContabilidad.UseVisualStyleBackColor = True
        '
        'chkConsultasInventario
        '
        Me.chkConsultasInventario.AutoSize = True
        Me.chkConsultasInventario.Location = New System.Drawing.Point(111, 98)
        Me.chkConsultasInventario.Name = "chkConsultasInventario"
        Me.chkConsultasInventario.Size = New System.Drawing.Size(139, 18)
        Me.chkConsultasInventario.TabIndex = 142
        Me.chkConsultasInventario.Text = "Consultas de Inventario"
        Me.chkConsultasInventario.UseVisualStyleBackColor = True
        '
        'chkConsultasCompra
        '
        Me.chkConsultasCompra.AutoSize = True
        Me.chkConsultasCompra.Location = New System.Drawing.Point(111, 74)
        Me.chkConsultasCompra.Name = "chkConsultasCompra"
        Me.chkConsultasCompra.Size = New System.Drawing.Size(129, 18)
        Me.chkConsultasCompra.TabIndex = 142
        Me.chkConsultasCompra.Text = "Consultas de Compra"
        Me.chkConsultasCompra.UseVisualStyleBackColor = True
        '
        'chkConsultasVenta
        '
        Me.chkConsultasVenta.AutoSize = True
        Me.chkConsultasVenta.Location = New System.Drawing.Point(111, 52)
        Me.chkConsultasVenta.Name = "chkConsultasVenta"
        Me.chkConsultasVenta.Size = New System.Drawing.Size(120, 18)
        Me.chkConsultasVenta.TabIndex = 142
        Me.chkConsultasVenta.Text = "Consultas de Venta"
        Me.chkConsultasVenta.UseVisualStyleBackColor = True
        '
        'chkConsultasAdministrador
        '
        Me.chkConsultasAdministrador.AutoSize = True
        Me.chkConsultasAdministrador.Location = New System.Drawing.Point(111, 30)
        Me.chkConsultasAdministrador.Name = "chkConsultasAdministrador"
        Me.chkConsultasAdministrador.Size = New System.Drawing.Size(158, 18)
        Me.chkConsultasAdministrador.TabIndex = 142
        Me.chkConsultasAdministrador.Text = "Consultas de Administrador"
        Me.chkConsultasAdministrador.UseVisualStyleBackColor = True
        '
        'chkAdministrador
        '
        Me.chkAdministrador.AutoSize = True
        Me.chkAdministrador.Location = New System.Drawing.Point(12, 30)
        Me.chkAdministrador.Name = "chkAdministrador"
        Me.chkAdministrador.Size = New System.Drawing.Size(93, 18)
        Me.chkAdministrador.TabIndex = 142
        Me.chkAdministrador.Text = "Administrador"
        Me.chkAdministrador.UseVisualStyleBackColor = True
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
        Me.ElGroupBox4.CaptionStyle.TextStyle.Text = "Datos Usuario"
        Me.ElGroupBox4.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox4.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox4.Controls.Add(Me.chkMostrar)
        Me.ElGroupBox4.Controls.Add(Me.txtObservacion)
        Me.ElGroupBox4.Controls.Add(Me.Label6)
        Me.ElGroupBox4.Controls.Add(Me.txtContraseña)
        Me.ElGroupBox4.Controls.Add(Me.Label3)
        Me.ElGroupBox4.Controls.Add(Me.txtUsuario)
        Me.ElGroupBox4.Controls.Add(Me.Label1)
        Me.ElGroupBox4.Controls.Add(Me.txtApellidos)
        Me.ElGroupBox4.Controls.Add(Me.txtNombres)
        Me.ElGroupBox4.Controls.Add(Me.Label2)
        Me.ElGroupBox4.Controls.Add(Me.Label4)
        Me.ElGroupBox4.Location = New System.Drawing.Point(12, 10)
        Me.ElGroupBox4.Name = "ElGroupBox4"
        Me.ElGroupBox4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox4.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox4.Size = New System.Drawing.Size(279, 167)
        Me.ElGroupBox4.TabIndex = 2
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Location = New System.Drawing.Point(275, -16)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigo.TabIndex = 145
        Me.txtCodigo.Visible = False
        '
        'chkMostrar
        '
        Me.chkMostrar.AutoSize = True
        Me.chkMostrar.Location = New System.Drawing.Point(208, 98)
        Me.chkMostrar.Name = "chkMostrar"
        Me.chkMostrar.Size = New System.Drawing.Size(63, 18)
        Me.chkMostrar.TabIndex = 144
        Me.chkMostrar.Text = "Mostrar"
        Me.chkMostrar.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        '
        '
        '
        Me.txtObservacion.Border.Class = "TextBoxBorder"
        Me.txtObservacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtObservacion.Location = New System.Drawing.Point(87, 120)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(179, 37)
        Me.txtObservacion.TabIndex = 139
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 14)
        Me.Label6.TabIndex = 140
        Me.Label6.Text = "Observación:"
        '
        'txtContraseña
        '
        '
        '
        '
        Me.txtContraseña.Border.Class = "TextBoxBorder"
        Me.txtContraseña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContraseña.Location = New System.Drawing.Point(87, 97)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(115, 20)
        Me.txtContraseña.TabIndex = 125
        Me.txtContraseña.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Contraseña:"
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.Location = New System.Drawing.Point(87, 74)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(179, 20)
        Me.txtUsuario.TabIndex = 124
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Usuario:"
        '
        'txtApellidos
        '
        '
        '
        '
        Me.txtApellidos.Border.Class = "TextBoxBorder"
        Me.txtApellidos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtApellidos.Location = New System.Drawing.Point(87, 51)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(179, 20)
        Me.txtApellidos.TabIndex = 123
        '
        'txtNombres
        '
        '
        '
        '
        Me.txtNombres.Border.Class = "TextBoxBorder"
        Me.txtNombres.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombres.Location = New System.Drawing.Point(87, 28)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(179, 20)
        Me.txtNombres.TabIndex = 122
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Nombres:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 14)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Apellidos:"
        '
        'pnContImage
        '
        Me.pnContImage.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnContImage.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnContImage.Controls.Add(Me.btImagen)
        Me.pnContImage.Controls.Add(Me.txtImagen)
        Me.pnContImage.Controls.Add(Me.pnImagen)
        Me.pnContImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnContImage.Location = New System.Drawing.Point(307, 39)
        Me.pnContImage.Name = "pnContImage"
        Me.pnContImage.Size = New System.Drawing.Size(375, 368)
        Me.pnContImage.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnContImage.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnContImage.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnContImage.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnContImage.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnContImage.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnContImage.Style.GradientAngle = 90
        Me.pnContImage.TabIndex = 39
        '
        'btImagen
        '
        Me.btImagen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btImagen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btImagen.Location = New System.Drawing.Point(343, 5)
        Me.btImagen.Name = "btImagen"
        Me.btImagen.Size = New System.Drawing.Size(27, 23)
        Me.btImagen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btImagen.TabIndex = 10
        Me.btImagen.Text = "..."
        '
        'txtImagen
        '
        Me.txtImagen.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtImagen.Border.Class = "TextBoxBorder"
        Me.txtImagen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtImagen.Location = New System.Drawing.Point(6, 7)
        Me.txtImagen.Name = "txtImagen"
        Me.txtImagen.ReadOnly = True
        Me.txtImagen.Size = New System.Drawing.Size(338, 20)
        Me.txtImagen.TabIndex = 9
        '
        'pnImagen
        '
        Me.pnImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnImagen.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnImagen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnImagen.Location = New System.Drawing.Point(6, 31)
        Me.pnImagen.Name = "pnImagen"
        Me.pnImagen.Size = New System.Drawing.Size(364, 330)
        Me.pnImagen.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnImagen.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnImagen.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnImagen.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnImagen.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnImagen.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnImagen.Style.GradientAngle = 90
        Me.pnImagen.TabIndex = 11
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 407)
        Me.Controls.Add(Me.pnContImage)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edición de Usuarios"
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox4.ResumeLayout(False)
        Me.ElGroupBox4.PerformLayout()
        Me.pnContImage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents opArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents pnContImage As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox4 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtContraseña As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtApellidos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombres As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents chkAdministrador As System.Windows.Forms.CheckBox
    Friend WithEvents chkContabilidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkInventario As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompra As System.Windows.Forms.CheckBox
    Friend WithEvents chkVenta As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsultasInventario As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsultasCompra As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsultasVenta As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsultasAdministrador As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsultasContabilidad As System.Windows.Forms.CheckBox
    Friend WithEvents btImagen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtImagen As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents pnImagen As DevComponents.DotNetBar.PanelEx
    Friend WithEvents chkMostrar As System.Windows.Forms.CheckBox
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents chkSalesPriceChange As System.Windows.Forms.CheckBox
End Class
