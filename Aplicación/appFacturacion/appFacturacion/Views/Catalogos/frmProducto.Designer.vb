<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProducto))
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.btEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btDarAlta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtDescuentoMaximo = New DevComponents.Editors.DoubleInput()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ElGroupBox5 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.rdDolar = New System.Windows.Forms.RadioButton()
        Me.rdCordoba = New System.Windows.Forms.RadioButton()
        Me.chkMargen = New System.Windows.Forms.CheckBox()
        Me.txtIdProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btAgregarProveedor = New DevComponents.DotNetBar.ButtonX()
        Me.btBuscarProveedor = New DevComponents.DotNetBar.ButtonX()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtUbicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtCantidadMaxima = New DevComponents.Editors.DoubleInput()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtContiene = New DevComponents.Editors.DoubleInput()
        Me.btLaboratorio = New DevComponents.DotNetBar.ButtonX()
        Me.cmbLaboratorio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.btPresentacion = New DevComponents.DotNetBar.ButtonX()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbPresentacion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtCantidadMinima = New DevComponents.Editors.DoubleInput()
        Me.txtObservacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtModelo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtOriginal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btUnidaddemedida = New DevComponents.DotNetBar.ButtonX()
        Me.btAcutalizarMarca = New DevComponents.DotNetBar.ButtonX()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.cmbUnidaddemedida = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbMarca = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtAplicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCosto = New DevComponents.Editors.DoubleInput()
        Me.txtPrecio1 = New DevComponents.Editors.DoubleInput()
        Me.txtPrecio2 = New DevComponents.Editors.DoubleInput()
        Me.txtPrecio3 = New DevComponents.Editors.DoubleInput()
        Me.txtPrecio4 = New DevComponents.Editors.DoubleInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.opArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.ElTab1 = New Klik.Windows.Forms.v1.EntryLib.ELTab()
        Me.ElTabPage1 = New Klik.Windows.Forms.v1.EntryLib.ELTabPage()
        Me.ElTabPage2 = New Klik.Windows.Forms.v1.EntryLib.ELTabPage()
        Me.ElGroupBox6 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.dtpFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ElGroupBox4 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.rdSinIVA = New System.Windows.Forms.RadioButton()
        Me.rdConIVA = New System.Windows.Forms.RadioButton()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cmbFacturarConPrecio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ElGroupBox3 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.rdSinExistencia = New System.Windows.Forms.RadioButton()
        Me.rdConExistencia = New System.Windows.Forms.RadioButton()
        Me.btImagen = New DevComponents.DotNetBar.ButtonX()
        Me.txtImagen = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.pnImagen = New DevComponents.DotNetBar.PanelEx()
        Me.sptInfo = New DevComponents.DotNetBar.SuperTooltip()
        Me.pnContImage = New DevComponents.DotNetBar.PanelEx()
        Me.btEliminarImagen = New DevComponents.DotNetBar.ButtonX()
        Me.Menu.SuspendLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.txtDescuentoMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox5.SuspendLayout()
        CType(Me.txtCantidadMaxima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContiene, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidadMinima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElTab1.SuspendLayout()
        CType(Me.ElTabPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElTabPage1.SuspendLayout()
        CType(Me.ElTabPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElTabPage2.SuspendLayout()
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox6.SuspendLayout()
        CType(Me.dtpFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox4.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox3.SuspendLayout()
        Me.pnContImage.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.SystemColors.Control
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btEditar, Me.btEliminar, Me.btDarAlta, Me.ToolStripSeparator1, Me.btBuscar})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(944, 39)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "Menu"
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
        'btDarAlta
        '
        Me.btDarAlta.Enabled = False
        Me.btDarAlta.ForeColor = System.Drawing.Color.Black
        Me.btDarAlta.Image = Global.appFacturacion.My.Resources.Resources.Alta
        Me.btDarAlta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btDarAlta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btDarAlta.Name = "btDarAlta"
        Me.btDarAlta.Size = New System.Drawing.Size(96, 36)
        Me.btDarAlta.Text = "Dar de Alta"
        Me.btDarAlta.Visible = False
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(427, 182)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 14)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Precio #4:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(292, 182)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 14)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Precio #3:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(154, 182)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 14)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Precio #2:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 14)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Precio #1:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 156)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 14)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Costo Promedio:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 14)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Observación:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 285)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 14)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Aplicación:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 14)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Modelo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(285, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 14)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Nombre:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Marca:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(285, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "ID Original:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID Alterno:"
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Datos Producto"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.txtDescuentoMaximo)
        Me.ElGroupBox1.Controls.Add(Me.Label15)
        Me.ElGroupBox1.Controls.Add(Me.ElGroupBox5)
        Me.ElGroupBox1.Controls.Add(Me.chkMargen)
        Me.ElGroupBox1.Controls.Add(Me.txtIdProveedor)
        Me.ElGroupBox1.Controls.Add(Me.btAgregarProveedor)
        Me.ElGroupBox1.Controls.Add(Me.btBuscarProveedor)
        Me.ElGroupBox1.Controls.Add(Me.Label23)
        Me.ElGroupBox1.Controls.Add(Me.txtProveedor)
        Me.ElGroupBox1.Controls.Add(Me.txtUbicacion)
        Me.ElGroupBox1.Controls.Add(Me.Label21)
        Me.ElGroupBox1.Controls.Add(Me.txtCantidadMaxima)
        Me.ElGroupBox1.Controls.Add(Me.Label20)
        Me.ElGroupBox1.Controls.Add(Me.Label19)
        Me.ElGroupBox1.Controls.Add(Me.Label18)
        Me.ElGroupBox1.Controls.Add(Me.txtContiene)
        Me.ElGroupBox1.Controls.Add(Me.btLaboratorio)
        Me.ElGroupBox1.Controls.Add(Me.cmbLaboratorio)
        Me.ElGroupBox1.Controls.Add(Me.btPresentacion)
        Me.ElGroupBox1.Controls.Add(Me.Label16)
        Me.ElGroupBox1.Controls.Add(Me.cmbPresentacion)
        Me.ElGroupBox1.Controls.Add(Me.txtCantidadMinima)
        Me.ElGroupBox1.Controls.Add(Me.txtObservacion)
        Me.ElGroupBox1.Controls.Add(Me.txtModelo)
        Me.ElGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.ElGroupBox1.Controls.Add(Me.txtOriginal)
        Me.ElGroupBox1.Controls.Add(Me.txtAlterno)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Controls.Add(Me.btUnidaddemedida)
        Me.ElGroupBox1.Controls.Add(Me.btAcutalizarMarca)
        Me.ElGroupBox1.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.Label8)
        Me.ElGroupBox1.Controls.Add(Me.Label14)
        Me.ElGroupBox1.Controls.Add(Me.Label9)
        Me.ElGroupBox1.Controls.Add(Me.Label7)
        Me.ElGroupBox1.Controls.Add(Me.Label13)
        Me.ElGroupBox1.Controls.Add(Me.Label10)
        Me.ElGroupBox1.Controls.Add(Me.Label4)
        Me.ElGroupBox1.Controls.Add(Me.Label6)
        Me.ElGroupBox1.Controls.Add(Me.Label12)
        Me.ElGroupBox1.Controls.Add(Me.Label11)
        Me.ElGroupBox1.Controls.Add(Me.Label5)
        Me.ElGroupBox1.Controls.Add(Me.cmbUnidaddemedida)
        Me.ElGroupBox1.Controls.Add(Me.cmbMarca)
        Me.ElGroupBox1.Controls.Add(Me.txtAplicacion)
        Me.ElGroupBox1.Controls.Add(Me.txtCosto)
        Me.ElGroupBox1.Controls.Add(Me.txtPrecio1)
        Me.ElGroupBox1.Controls.Add(Me.txtPrecio2)
        Me.ElGroupBox1.Controls.Add(Me.txtPrecio3)
        Me.ElGroupBox1.Controls.Add(Me.txtPrecio4)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Controls.Add(Me.Label17)
        Me.ElGroupBox1.Controls.Add(Me.Label24)
        Me.ElGroupBox1.Controls.Add(Me.Label25)
        Me.ElGroupBox1.Controls.Add(Me.Label26)
        Me.ElGroupBox1.Controls.Add(Me.Label27)
        Me.ElGroupBox1.Controls.Add(Me.Label28)
        Me.ElGroupBox1.Controls.Add(Me.Label29)
        Me.ElGroupBox1.Controls.Add(Me.Label30)
        Me.ElGroupBox1.Controls.Add(Me.Label31)
        Me.ElGroupBox1.Controls.Add(Me.Label32)
        Me.ElGroupBox1.Controls.Add(Me.Label33)
        Me.ElGroupBox1.Controls.Add(Me.Label34)
        Me.ElGroupBox1.Controls.Add(Me.Label35)
        Me.ElGroupBox1.Controls.Add(Me.Label36)
        Me.ElGroupBox1.Controls.Add(Me.Label38)
        Me.ElGroupBox1.Controls.Add(Me.Label39)
        Me.ElGroupBox1.Location = New System.Drawing.Point(7, 4)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(552, 317)
        Me.ElGroupBox1.TabIndex = 1
        '
        'txtDescuentoMaximo
        '
        '
        '
        '
        Me.txtDescuentoMaximo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDescuentoMaximo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescuentoMaximo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDescuentoMaximo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuentoMaximo.Increment = 1.0R
        Me.txtDescuentoMaximo.Location = New System.Drawing.Point(465, 231)
        Me.txtDescuentoMaximo.MaxValue = 100.0R
        Me.txtDescuentoMaximo.MinValue = 0.0R
        Me.txtDescuentoMaximo.Name = "txtDescuentoMaximo"
        Me.txtDescuentoMaximo.Size = New System.Drawing.Size(74, 20)
        Me.txtDescuentoMaximo.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(358, 233)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 14)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Descuento Máximo:"
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
        Me.ElGroupBox5.CaptionStyle.TextStyle.Text = "ElGroupBox2"
        Me.ElGroupBox5.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox5.Controls.Add(Me.rdDolar)
        Me.ElGroupBox5.Controls.Add(Me.rdCordoba)
        Me.ElGroupBox5.Location = New System.Drawing.Point(386, 153)
        Me.ElGroupBox5.Name = "ElGroupBox5"
        Me.ElGroupBox5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox5.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox5.Size = New System.Drawing.Size(153, 23)
        Me.ElGroupBox5.TabIndex = 136
        '
        'rdDolar
        '
        Me.rdDolar.AutoSize = True
        Me.rdDolar.Enabled = False
        Me.rdDolar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDolar.Location = New System.Drawing.Point(87, 2)
        Me.rdDolar.Name = "rdDolar"
        Me.rdDolar.Size = New System.Drawing.Size(50, 18)
        Me.rdDolar.TabIndex = 12
        Me.rdDolar.Text = "Dólar"
        Me.rdDolar.UseVisualStyleBackColor = True
        '
        'rdCordoba
        '
        Me.rdCordoba.AutoSize = True
        Me.rdCordoba.Checked = True
        Me.rdCordoba.Enabled = False
        Me.rdCordoba.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCordoba.Location = New System.Drawing.Point(12, 2)
        Me.rdCordoba.Name = "rdCordoba"
        Me.rdCordoba.Size = New System.Drawing.Size(66, 18)
        Me.rdCordoba.TabIndex = 11
        Me.rdCordoba.TabStop = True
        Me.rdCordoba.Text = "Córdoba"
        Me.rdCordoba.UseVisualStyleBackColor = True
        '
        'chkMargen
        '
        Me.chkMargen.AutoSize = True
        Me.chkMargen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMargen.Location = New System.Drawing.Point(227, 155)
        Me.chkMargen.Name = "chkMargen"
        Me.chkMargen.Size = New System.Drawing.Size(152, 18)
        Me.chkMargen.TabIndex = 135
        Me.chkMargen.Text = "Margen en Porcentaje (%)"
        Me.chkMargen.UseVisualStyleBackColor = True
        '
        'txtIdProveedor
        '
        '
        '
        '
        Me.txtIdProveedor.Border.Class = "TextBoxBorder"
        Me.txtIdProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdProveedor.Enabled = False
        Me.txtIdProveedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProveedor.Location = New System.Drawing.Point(95, 257)
        Me.txtIdProveedor.Name = "txtIdProveedor"
        Me.txtIdProveedor.Size = New System.Drawing.Size(5, 20)
        Me.txtIdProveedor.TabIndex = 26
        Me.txtIdProveedor.Visible = False
        '
        'btAgregarProveedor
        '
        Me.btAgregarProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAgregarProveedor.BackColor = System.Drawing.Color.Transparent
        Me.btAgregarProveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAgregarProveedor.Image = Global.appFacturacion.My.Resources.Resources.btn_agregar
        Me.btAgregarProveedor.Location = New System.Drawing.Point(511, 256)
        Me.btAgregarProveedor.Name = "btAgregarProveedor"
        Me.btAgregarProveedor.Size = New System.Drawing.Size(29, 22)
        Me.btAgregarProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAgregarProveedor.TabIndex = 28
        '
        'btBuscarProveedor
        '
        Me.btBuscarProveedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarProveedor.BackColor = System.Drawing.Color.Transparent
        Me.btBuscarProveedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarProveedor.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btBuscarProveedor.Location = New System.Drawing.Point(483, 256)
        Me.btBuscarProveedor.Name = "btBuscarProveedor"
        Me.btBuscarProveedor.Size = New System.Drawing.Size(29, 22)
        Me.btBuscarProveedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarProveedor.TabIndex = 27
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(17, 259)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 14)
        Me.Label23.TabIndex = 26
        Me.Label23.Text = "Proveedor:"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtProveedor.Border.Class = "TextBoxBorder"
        Me.txtProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtProveedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(102, 257)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(382, 20)
        Me.txtProveedor.TabIndex = 26
        '
        'txtUbicacion
        '
        '
        '
        '
        Me.txtUbicacion.Border.Class = "TextBoxBorder"
        Me.txtUbicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUbicacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicacion.Location = New System.Drawing.Point(352, 79)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(188, 20)
        Me.txtUbicacion.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(289, 81)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 14)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Dimencion:"
        '
        'txtCantidadMaxima
        '
        '
        '
        '
        Me.txtCantidadMaxima.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidadMaxima.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantidadMaxima.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantidadMaxima.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadMaxima.Increment = 1.0R
        Me.txtCantidadMaxima.Location = New System.Drawing.Point(234, 206)
        Me.txtCantidadMaxima.MinValue = 0.0R
        Me.txtCantidadMaxima.Name = "txtCantidadMaxima"
        Me.txtCantidadMaxima.Size = New System.Drawing.Size(48, 20)
        Me.txtCantidadMaxima.TabIndex = 19
        Me.txtCantidadMaxima.Value = 100.0R
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(154, 207)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 14)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Cant. Máxima:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(507, 134)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 10)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "UNDS."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(391, 132)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 14)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Y Contiene:"
        '
        'txtContiene
        '
        '
        '
        '
        Me.txtContiene.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtContiene.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContiene.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtContiene.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContiene.Increment = 1.0R
        Me.txtContiene.Location = New System.Drawing.Point(457, 129)
        Me.txtContiene.MinValue = 0.0R
        Me.txtContiene.Name = "txtContiene"
        Me.txtContiene.Size = New System.Drawing.Size(48, 20)
        Me.txtContiene.TabIndex = 12
        Me.txtContiene.Value = 1.0R
        '
        'btLaboratorio
        '
        Me.btLaboratorio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btLaboratorio.BackColor = System.Drawing.Color.Transparent
        Me.btLaboratorio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btLaboratorio.Image = Global.appFacturacion.My.Resources.Resources.Actualizar_16_16
        Me.btLaboratorio.Location = New System.Drawing.Point(317, 230)
        Me.btLaboratorio.Name = "btLaboratorio"
        Me.btLaboratorio.Size = New System.Drawing.Size(29, 22)
        Me.btLaboratorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btLaboratorio.TabIndex = 24
        '
        'cmbLaboratorio
        '
        Me.cmbLaboratorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLaboratorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLaboratorio.DisplayMember = "Text"
        Me.cmbLaboratorio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLaboratorio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLaboratorio.FormattingEnabled = True
        Me.cmbLaboratorio.ItemHeight = 14
        Me.cmbLaboratorio.Location = New System.Drawing.Point(75, 231)
        Me.cmbLaboratorio.Name = "cmbLaboratorio"
        Me.cmbLaboratorio.Size = New System.Drawing.Size(259, 20)
        Me.cmbLaboratorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLaboratorio.TabIndex = 23
        '
        'btPresentacion
        '
        Me.btPresentacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btPresentacion.BackColor = System.Drawing.Color.Transparent
        Me.btPresentacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btPresentacion.Image = Global.appFacturacion.My.Resources.Resources.Actualizar_16_16
        Me.btPresentacion.Location = New System.Drawing.Point(510, 205)
        Me.btPresentacion.Name = "btPresentacion"
        Me.btPresentacion.Size = New System.Drawing.Size(29, 22)
        Me.btPresentacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btPresentacion.TabIndex = 22
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(294, 207)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 14)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Presentación:"
        '
        'cmbPresentacion
        '
        Me.cmbPresentacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPresentacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPresentacion.DisplayMember = "Text"
        Me.cmbPresentacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPresentacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPresentacion.FormattingEnabled = True
        Me.cmbPresentacion.ItemHeight = 14
        Me.cmbPresentacion.Location = New System.Drawing.Point(373, 206)
        Me.cmbPresentacion.Name = "cmbPresentacion"
        Me.cmbPresentacion.Size = New System.Drawing.Size(155, 20)
        Me.cmbPresentacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPresentacion.TabIndex = 21
        '
        'txtCantidadMinima
        '
        '
        '
        '
        Me.txtCantidadMinima.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidadMinima.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantidadMinima.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantidadMinima.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadMinima.Increment = 1.0R
        Me.txtCantidadMinima.Location = New System.Drawing.Point(93, 206)
        Me.txtCantidadMinima.MinValue = 0.0R
        Me.txtCantidadMinima.Name = "txtCantidadMinima"
        Me.txtCantidadMinima.Size = New System.Drawing.Size(48, 20)
        Me.txtCantidadMinima.TabIndex = 18
        Me.txtCantidadMinima.Value = 10.0R
        '
        'txtObservacion
        '
        '
        '
        '
        Me.txtObservacion.Border.Class = "TextBoxBorder"
        Me.txtObservacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtObservacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(95, 104)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(445, 20)
        Me.txtObservacion.TabIndex = 8
        '
        'txtModelo
        '
        '
        '
        '
        Me.txtModelo.Border.Class = "TextBoxBorder"
        Me.txtModelo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtModelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.Location = New System.Drawing.Point(67, 79)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(207, 20)
        Me.txtModelo.TabIndex = 6
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(338, 54)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(202, 20)
        Me.txtDescripcion.TabIndex = 5
        '
        'txtOriginal
        '
        '
        '
        '
        Me.txtOriginal.Border.Class = "TextBoxBorder"
        Me.txtOriginal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOriginal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginal.Location = New System.Drawing.Point(348, 29)
        Me.txtOriginal.Name = "txtOriginal"
        Me.txtOriginal.Size = New System.Drawing.Size(191, 20)
        Me.txtOriginal.TabIndex = 2
        '
        'txtAlterno
        '
        '
        '
        '
        Me.txtAlterno.Border.Class = "TextBoxBorder"
        Me.txtAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlterno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlterno.Location = New System.Drawing.Point(79, 29)
        Me.txtAlterno.Name = "txtAlterno"
        Me.txtAlterno.Size = New System.Drawing.Size(195, 20)
        Me.txtAlterno.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Unidad de Medida:"
        '
        'btUnidaddemedida
        '
        Me.btUnidaddemedida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btUnidaddemedida.BackColor = System.Drawing.Color.Transparent
        Me.btUnidaddemedida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btUnidaddemedida.Image = Global.appFacturacion.My.Resources.Resources.Actualizar_16_16
        Me.btUnidaddemedida.Location = New System.Drawing.Point(345, 128)
        Me.btUnidaddemedida.Name = "btUnidaddemedida"
        Me.btUnidaddemedida.Size = New System.Drawing.Size(29, 22)
        Me.btUnidaddemedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btUnidaddemedida.TabIndex = 11
        '
        'btAcutalizarMarca
        '
        Me.btAcutalizarMarca.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAcutalizarMarca.BackColor = System.Drawing.Color.Transparent
        Me.btAcutalizarMarca.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAcutalizarMarca.Image = Global.appFacturacion.My.Resources.Resources.Actualizar_16_16
        Me.btAcutalizarMarca.Location = New System.Drawing.Point(245, 53)
        Me.btAcutalizarMarca.Name = "btAcutalizarMarca"
        Me.btAcutalizarMarca.Size = New System.Drawing.Size(29, 22)
        Me.btAcutalizarMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAcutalizarMarca.TabIndex = 4
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(-98, 239)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 26
        Me.txtCodigo.Visible = False
        '
        'cmbUnidaddemedida
        '
        Me.cmbUnidaddemedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUnidaddemedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnidaddemedida.DisplayMember = "Text"
        Me.cmbUnidaddemedida.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbUnidaddemedida.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidaddemedida.FormattingEnabled = True
        Me.cmbUnidaddemedida.ItemHeight = 14
        Me.cmbUnidaddemedida.Location = New System.Drawing.Point(118, 129)
        Me.cmbUnidaddemedida.Name = "cmbUnidaddemedida"
        Me.cmbUnidaddemedida.Size = New System.Drawing.Size(244, 20)
        Me.cmbUnidaddemedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbUnidaddemedida.TabIndex = 10
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMarca.DisplayMember = "Text"
        Me.cmbMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMarca.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.ItemHeight = 14
        Me.cmbMarca.Location = New System.Drawing.Point(63, 54)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(200, 20)
        Me.cmbMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbMarca.TabIndex = 3
        '
        'txtAplicacion
        '
        '
        '
        '
        Me.txtAplicacion.Border.Class = "TextBoxBorder"
        Me.txtAplicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAplicacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplicacion.Location = New System.Drawing.Point(83, 283)
        Me.txtAplicacion.Name = "txtAplicacion"
        Me.txtAplicacion.Size = New System.Drawing.Size(456, 20)
        Me.txtAplicacion.TabIndex = 29
        '
        'txtCosto
        '
        '
        '
        '
        Me.txtCosto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCosto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCosto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCosto.Increment = 1.0R
        Me.txtCosto.Location = New System.Drawing.Point(118, 154)
        Me.txtCosto.MinValue = 0.0R
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(82, 20)
        Me.txtCosto.TabIndex = 9
        '
        'txtPrecio1
        '
        '
        '
        '
        Me.txtPrecio1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPrecio1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrecio1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPrecio1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio1.Increment = 1.0R
        Me.txtPrecio1.Location = New System.Drawing.Point(76, 180)
        Me.txtPrecio1.MinValue = 0.0R
        Me.txtPrecio1.Name = "txtPrecio1"
        Me.txtPrecio1.Size = New System.Drawing.Size(55, 20)
        Me.txtPrecio1.TabIndex = 14
        '
        'txtPrecio2
        '
        '
        '
        '
        Me.txtPrecio2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPrecio2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrecio2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPrecio2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio2.Increment = 1.0R
        Me.txtPrecio2.Location = New System.Drawing.Point(213, 180)
        Me.txtPrecio2.MinValue = 0.0R
        Me.txtPrecio2.Name = "txtPrecio2"
        Me.txtPrecio2.Size = New System.Drawing.Size(55, 20)
        Me.txtPrecio2.TabIndex = 15
        '
        'txtPrecio3
        '
        '
        '
        '
        Me.txtPrecio3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPrecio3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrecio3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPrecio3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio3.Increment = 1.0R
        Me.txtPrecio3.Location = New System.Drawing.Point(351, 180)
        Me.txtPrecio3.MinValue = 0.0R
        Me.txtPrecio3.Name = "txtPrecio3"
        Me.txtPrecio3.Size = New System.Drawing.Size(55, 20)
        Me.txtPrecio3.TabIndex = 16
        '
        'txtPrecio4
        '
        '
        '
        '
        Me.txtPrecio4.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPrecio4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrecio4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPrecio4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio4.Increment = 1.0R
        Me.txtPrecio4.Location = New System.Drawing.Point(485, 180)
        Me.txtPrecio4.MinValue = 0.0R
        Me.txtPrecio4.Name = "txtPrecio4"
        Me.txtPrecio4.Size = New System.Drawing.Size(55, 20)
        Me.txtPrecio4.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Cant. Mínima:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(17, 233)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 14)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Empresa:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(272, 32)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label24, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label24.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label24.TabIndex = 118
        Me.Label24.Text = "*"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(538, 32)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label25, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label25.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label25.TabIndex = 119
        Me.Label25.Text = "*"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(272, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label26, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label26.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label26.TabIndex = 120
        Me.Label26.Text = "*"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(538, 57)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label27, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label27.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label27.TabIndex = 121
        Me.Label27.Text = "*"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(198, 157)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label28, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label28.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label28.TabIndex = 122
        Me.Label28.Text = "*"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(374, 132)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label29, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label29.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label29.TabIndex = 123
        Me.Label29.Text = "*"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(538, 133)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label30, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label30.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label30.TabIndex = 124
        Me.Label30.Text = "*"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Red
        Me.Label31.Location = New System.Drawing.Point(130, 183)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label31, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label31.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label31.TabIndex = 125
        Me.Label31.Text = "*"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(267, 183)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label32, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label32.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label32.TabIndex = 126
        Me.Label32.Text = "*"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Red
        Me.Label33.Location = New System.Drawing.Point(405, 183)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label33, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label33.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label33.TabIndex = 127
        Me.Label33.Text = "*"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(538, 183)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label34, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label34.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label34.TabIndex = 128
        Me.Label34.Text = "*"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Red
        Me.Label35.Location = New System.Drawing.Point(140, 208)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label35, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label35.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label35.TabIndex = 129
        Me.Label35.Text = "*"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(280, 208)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label36, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label36.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label36.TabIndex = 130
        Me.Label36.Text = "*"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Red
        Me.Label38.Location = New System.Drawing.Point(538, 210)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label38, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label38.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label38.TabIndex = 132
        Me.Label38.Text = "*"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Red
        Me.Label39.Location = New System.Drawing.Point(345, 235)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label39, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label39.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label39.TabIndex = 133
        Me.Label39.Text = "*"
        '
        'opArchivo
        '
        Me.opArchivo.FileName = "OpenFileDialog1"
        Me.opArchivo.Filter = "Imagenes (.jpg, .jpeg, .png, .gif)|*.jpg;*.jpeg;*.png;*.gif"
        '
        'ElTab1
        '
        Me.ElTab1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ElTab1.Location = New System.Drawing.Point(0, 39)
        Me.ElTab1.Name = "ElTab1"
        Me.ElTab1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElTab1.Size = New System.Drawing.Size(568, 356)
        Me.ElTab1.TabCaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElTab1.TabCaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElTab1.TabCaptionStyle.StateStyles.FocusStyle.BackgroundPaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElTab1.TabCaptionStyle.StateStyles.FocusStyle.BackgroundSolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElTab1.TabIndex = 1
        Me.ElTab1.TabPages.Add(Me.ElTabPage1)
        Me.ElTab1.TabPages.Add(Me.ElTabPage2)
        '
        'ElTabPage1
        '
        Me.ElTabPage1.BackgroundStyle.GradientAngle = 45.0!
        Me.ElTabPage1.CaptionImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElTabPage1.CaptionTextStyle.ForeColor = System.Drawing.Color.White
        Me.ElTabPage1.CaptionTextStyle.Text = "Información del Producto"
        Me.ElTabPage1.Controls.Add(Me.ElGroupBox1)
        Me.ElTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.ElTabPage1.Name = "ElTabPage1"
        Me.ElTabPage1.Size = New System.Drawing.Size(566, 332)
        '
        'ElTabPage2
        '
        Me.ElTabPage2.BackgroundStyle.GradientAngle = 45.0!
        Me.ElTabPage2.CaptionImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElTabPage2.CaptionTextStyle.ForeColor = System.Drawing.Color.White
        Me.ElTabPage2.CaptionTextStyle.Text = "Detalles Adicionales"
        Me.ElTabPage2.Controls.Add(Me.ElGroupBox6)
        Me.ElTabPage2.Controls.Add(Me.ElGroupBox4)
        Me.ElTabPage2.Controls.Add(Me.ElGroupBox2)
        Me.ElTabPage2.Controls.Add(Me.ElGroupBox3)
        Me.ElTabPage2.Location = New System.Drawing.Point(1, 23)
        Me.ElTabPage2.Name = "ElTabPage2"
        Me.ElTabPage2.Size = New System.Drawing.Size(566, 332)
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
        Me.ElGroupBox6.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlack
        Me.ElGroupBox6.CaptionStyle.TextStyle.Text = "Promociones"
        Me.ElGroupBox6.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox6.Controls.Add(Me.dtpFinal)
        Me.ElGroupBox6.Controls.Add(Me.Label40)
        Me.ElGroupBox6.Controls.Add(Me.dtpInicio)
        Me.ElGroupBox6.Controls.Add(Me.Label22)
        Me.ElGroupBox6.Location = New System.Drawing.Point(3, 57)
        Me.ElGroupBox6.Name = "ElGroupBox6"
        Me.ElGroupBox6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlack
        Me.ElGroupBox6.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox6.Size = New System.Drawing.Size(557, 72)
        Me.ElGroupBox6.TabIndex = 39
        Me.ElGroupBox6.Visible = False
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
        Me.dtpFinal.Location = New System.Drawing.Point(259, 35)
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
        Me.dtpFinal.TabIndex = 138
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(186, 37)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(65, 14)
        Me.Label40.TabIndex = 137
        Me.Label40.Text = "Fecha Final:"
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
        Me.dtpInicio.Location = New System.Drawing.Point(80, 35)
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
        Me.dtpInicio.TabIndex = 136
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 37)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 14)
        Me.Label22.TabIndex = 135
        Me.Label22.Text = "Fecha Inicio:"
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
        Me.ElGroupBox4.CaptionStyle.TextStyle.Text = "IVA"
        Me.ElGroupBox4.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox4.Controls.Add(Me.LabelX2)
        Me.ElGroupBox4.Controls.Add(Me.rdSinIVA)
        Me.ElGroupBox4.Controls.Add(Me.rdConIVA)
        Me.ElGroupBox4.Location = New System.Drawing.Point(184, 3)
        Me.ElGroupBox4.Name = "ElGroupBox4"
        Me.ElGroupBox4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox4.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox4.Size = New System.Drawing.Size(175, 45)
        Me.ElGroupBox4.TabIndex = 37
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(7, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(86, 23)
        Me.LabelX2.TabIndex = 32
        Me.LabelX2.Text = "Impuesto (IVA):"
        '
        'rdSinIVA
        '
        Me.rdSinIVA.AutoSize = True
        Me.rdSinIVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSinIVA.Location = New System.Drawing.Point(133, 16)
        Me.rdSinIVA.Name = "rdSinIVA"
        Me.rdSinIVA.Size = New System.Drawing.Size(38, 18)
        Me.rdSinIVA.TabIndex = 34
        Me.rdSinIVA.Text = "No"
        Me.rdSinIVA.UseVisualStyleBackColor = True
        '
        'rdConIVA
        '
        Me.rdConIVA.AutoSize = True
        Me.rdConIVA.Checked = True
        Me.rdConIVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdConIVA.Location = New System.Drawing.Point(93, 16)
        Me.rdConIVA.Name = "rdConIVA"
        Me.rdConIVA.Size = New System.Drawing.Size(34, 18)
        Me.rdConIVA.TabIndex = 34
        Me.rdConIVA.TabStop = True
        Me.rdConIVA.Text = "Si"
        Me.rdConIVA.UseVisualStyleBackColor = True
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
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "IVA"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.LabelX1)
        Me.ElGroupBox2.Controls.Add(Me.cmbFacturarConPrecio)
        Me.ElGroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(175, 45)
        Me.ElGroupBox2.TabIndex = 35
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(7, 11)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(44, 23)
        Me.LabelX1.TabIndex = 32
        Me.LabelX1.Text = "Precio:"
        '
        'cmbFacturarConPrecio
        '
        Me.cmbFacturarConPrecio.DisplayMember = "Text"
        Me.cmbFacturarConPrecio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFacturarConPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacturarConPrecio.FormattingEnabled = True
        Me.cmbFacturarConPrecio.ItemHeight = 14
        Me.cmbFacturarConPrecio.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5})
        Me.cmbFacturarConPrecio.Location = New System.Drawing.Point(57, 13)
        Me.cmbFacturarConPrecio.Name = "cmbFacturarConPrecio"
        Me.cmbFacturarConPrecio.Size = New System.Drawing.Size(111, 20)
        Me.cmbFacturarConPrecio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFacturarConPrecio.TabIndex = 33
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Precio #1"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Precio #2"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Precio #3"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Precio #4"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Lista de Precios"
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
        Me.ElGroupBox3.CaptionStyle.TextStyle.Text = "IVA"
        Me.ElGroupBox3.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox3.Controls.Add(Me.LabelX3)
        Me.ElGroupBox3.Controls.Add(Me.rdSinExistencia)
        Me.ElGroupBox3.Controls.Add(Me.rdConExistencia)
        Me.ElGroupBox3.Location = New System.Drawing.Point(364, 3)
        Me.ElGroupBox3.Name = "ElGroupBox3"
        Me.ElGroupBox3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox3.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox3.Size = New System.Drawing.Size(196, 45)
        Me.ElGroupBox3.TabIndex = 36
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(7, 11)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 23)
        Me.LabelX3.TabIndex = 32
        Me.LabelX3.Text = "Inventario Negativo:"
        '
        'rdSinExistencia
        '
        Me.rdSinExistencia.AutoSize = True
        Me.rdSinExistencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSinExistencia.Location = New System.Drawing.Point(114, 16)
        Me.rdSinExistencia.Name = "rdSinExistencia"
        Me.rdSinExistencia.Size = New System.Drawing.Size(34, 18)
        Me.rdSinExistencia.TabIndex = 34
        Me.rdSinExistencia.Text = "Si"
        Me.rdSinExistencia.UseVisualStyleBackColor = True
        '
        'rdConExistencia
        '
        Me.rdConExistencia.AutoSize = True
        Me.rdConExistencia.Checked = True
        Me.rdConExistencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdConExistencia.Location = New System.Drawing.Point(154, 16)
        Me.rdConExistencia.Name = "rdConExistencia"
        Me.rdConExistencia.Size = New System.Drawing.Size(38, 18)
        Me.rdConExistencia.TabIndex = 34
        Me.rdConExistencia.TabStop = True
        Me.rdConExistencia.Text = "No"
        Me.rdConExistencia.UseVisualStyleBackColor = True
        '
        'btImagen
        '
        Me.btImagen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btImagen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btImagen.Location = New System.Drawing.Point(229, 5)
        Me.btImagen.Name = "btImagen"
        Me.btImagen.Size = New System.Drawing.Size(27, 23)
        Me.btImagen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btImagen.TabIndex = 30
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
        Me.txtImagen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImagen.Location = New System.Drawing.Point(6, 7)
        Me.txtImagen.Name = "txtImagen"
        Me.txtImagen.ReadOnly = True
        Me.txtImagen.Size = New System.Drawing.Size(224, 20)
        Me.txtImagen.TabIndex = 29
        '
        'pnImagen
        '
        Me.pnImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnImagen.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnImagen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnImagen.Location = New System.Drawing.Point(6, 33)
        Me.pnImagen.Name = "pnImagen"
        Me.pnImagen.Size = New System.Drawing.Size(364, 316)
        Me.pnImagen.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnImagen.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnImagen.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnImagen.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnImagen.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnImagen.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnImagen.Style.GradientAngle = 90
        Me.pnImagen.TabIndex = 31
        '
        'pnContImage
        '
        Me.pnContImage.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnContImage.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnContImage.Controls.Add(Me.btEliminarImagen)
        Me.pnContImage.Controls.Add(Me.btImagen)
        Me.pnContImage.Controls.Add(Me.txtImagen)
        Me.pnContImage.Controls.Add(Me.pnImagen)
        Me.pnContImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnContImage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnContImage.Location = New System.Drawing.Point(568, 39)
        Me.pnContImage.Name = "pnContImage"
        Me.pnContImage.Size = New System.Drawing.Size(376, 356)
        Me.pnContImage.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnContImage.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnContImage.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnContImage.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnContImage.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnContImage.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnContImage.Style.GradientAngle = 90
        Me.pnContImage.TabIndex = 2
        '
        'btEliminarImagen
        '
        Me.btEliminarImagen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btEliminarImagen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btEliminarImagen.Image = Global.appFacturacion.My.Resources.Resources.Eliminar16x16
        Me.btEliminarImagen.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btEliminarImagen.Location = New System.Drawing.Point(256, 5)
        Me.btEliminarImagen.Name = "btEliminarImagen"
        Me.btEliminarImagen.Size = New System.Drawing.Size(27, 23)
        Me.btEliminarImagen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btEliminarImagen.TabIndex = 32
        '
        'frmProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 395)
        Me.Controls.Add(Me.pnContImage)
        Me.Controls.Add(Me.ElTab1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(850, 420)
        Me.Name = "frmProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edición de Productos"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.txtDescuentoMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox5.ResumeLayout(False)
        Me.ElGroupBox5.PerformLayout()
        CType(Me.txtCantidadMaxima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContiene, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidadMinima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElTab1.ResumeLayout(False)
        CType(Me.ElTabPage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElTabPage1.ResumeLayout(False)
        CType(Me.ElTabPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElTabPage2.ResumeLayout(False)
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox6.ResumeLayout(False)
        Me.ElGroupBox6.PerformLayout()
        CType(Me.dtpFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox4.ResumeLayout(False)
        Me.ElGroupBox4.PerformLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox3.ResumeLayout(False)
        Me.ElGroupBox3.PerformLayout()
        Me.pnContImage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btAcutalizarMarca As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtOriginal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbMarca As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtModelo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAplicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtObservacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents opArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtCosto As DevComponents.Editors.DoubleInput
    Friend WithEvents txtPrecio1 As DevComponents.Editors.DoubleInput
    Friend WithEvents txtPrecio2 As DevComponents.Editors.DoubleInput
    Friend WithEvents txtPrecio3 As DevComponents.Editors.DoubleInput
    Friend WithEvents txtPrecio4 As DevComponents.Editors.DoubleInput
    Friend WithEvents txtCantidadMinima As DevComponents.Editors.DoubleInput
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btPresentacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbPresentacion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btLaboratorio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbLaboratorio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btUnidaddemedida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbUnidaddemedida As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtContiene As DevComponents.Editors.DoubleInput
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadMaxima As DevComponents.Editors.DoubleInput
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtUbicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ElTab1 As Klik.Windows.Forms.v1.EntryLib.ELTab
    Friend WithEvents ElTabPage1 As Klik.Windows.Forms.v1.EntryLib.ELTabPage
    Friend WithEvents ElTabPage2 As Klik.Windows.Forms.v1.EntryLib.ELTabPage
    Friend WithEvents btImagen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtImagen As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents pnImagen As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbFacturarConPrecio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents rdSinIVA As System.Windows.Forms.RadioButton
    Friend WithEvents rdConIVA As System.Windows.Forms.RadioButton
    Friend WithEvents rdConExistencia As System.Windows.Forms.RadioButton
    Friend WithEvents rdSinExistencia As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElGroupBox4 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents ElGroupBox3 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtIdProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btAgregarProveedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btBuscarProveedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents sptInfo As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents pnContImage As DevComponents.DotNetBar.PanelEx
    Friend WithEvents chkMargen As System.Windows.Forms.CheckBox
    Friend WithEvents ElGroupBox5 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents rdDolar As System.Windows.Forms.RadioButton
    Friend WithEvents rdCordoba As System.Windows.Forms.RadioButton
    Friend WithEvents btDarAlta As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEliminarImagen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ElGroupBox6 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtDescuentoMaximo As DevComponents.Editors.DoubleInput
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
