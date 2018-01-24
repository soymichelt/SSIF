<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaDevolucion
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
        Dim PaintStyle2 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle3 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle4 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaDevolucion))
        Dim PaintStyle5 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle6 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle7 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim PaintStyle8 As Klik.Windows.Forms.v1.Common.PaintStyle = New Klik.Windows.Forms.v1.Common.PaintStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.ElGroupBox4 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtIdFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtSaldo = New DevComponents.Editors.DoubleInput()
        Me.btBuscarFactura = New DevComponents.DotNetBar.ButtonX()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.rdContado = New System.Windows.Forms.RadioButton()
        Me.rdCredito = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btActualizarSerie = New DevComponents.DotNetBar.ButtonX()
        Me.ElGroupBox6 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtTazaCambio = New DevComponents.Editors.DoubleInput()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.rdDolar = New System.Windows.Forms.RadioButton()
        Me.rdCordoba = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIdSerie = New System.Windows.Forms.TextBox()
        Me.txtSerie = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ElGroupBox3 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtDescuentoPorFactura = New DevComponents.Editors.DoubleInput()
        Me.lblDescuentoPorFactura = New System.Windows.Forms.Label()
        Me.rdSindescuento = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rdDescuentoPorFactura = New System.Windows.Forms.RadioButton()
        Me.rdDescuentoPorProducto = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dtpFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.chkExonerado = New System.Windows.Forms.CheckBox()
        Me.txtReferencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btVendedor = New DevComponents.DotNetBar.ButtonX()
        Me.txtIdVendedor = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.btCliente = New DevComponents.DotNetBar.ButtonX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreVendedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox5 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtTotal = New DevComponents.Editors.DoubleInput()
        Me.txtTotalIva = New DevComponents.Editors.DoubleInput()
        Me.txtTotalSubtotal = New DevComponents.Editors.DoubleInput()
        Me.ElLabel8 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.ElLabel7 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.ElLabel5 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.txtTotalDescuento = New DevComponents.Editors.DoubleInput()
        Me.ElLabel6 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCodigoAlterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ElLabel3 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.ElLabel2 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.ElLabel1 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.ElLabel4 = New Klik.Windows.Forms.v1.EntryLib.ELLabel()
        Me.chkIncluyeIVA = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtDescuentoPorProducto = New DevComponents.Editors.DoubleInput()
        Me.btAgregarProducto = New DevComponents.DotNetBar.ButtonX()
        Me.txtCantidad = New DevComponents.Editors.DoubleInput()
        Me.btProducto = New DevComponents.DotNetBar.ButtonX()
        Me.txtIva = New DevComponents.Editors.DoubleInput()
        Me.txtPrecio = New DevComponents.Editors.DoubleInput()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.sptInfo = New DevComponents.DotNetBar.SuperTooltip()
        Me.Menu.SuspendLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox4.SuspendLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox6.SuspendLayout()
        CType(Me.txtTazaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox3.SuspendLayout()
        CType(Me.txtDescuentoPorFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        CType(Me.ElGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox5.SuspendLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalSubtotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.ElLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescuentoPorProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° Doc.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(179, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Cliente:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Serie:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(179, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 14)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Ref.:"
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btAnular, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(959, 39)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "ToolStrip1"
        '
        'btNuevo
        '
        Me.btNuevo.AutoToolTip = False
        Me.btNuevo.Image = Global.appFacturacion.My.Resources.Resources.nuevo
        Me.btNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(74, 36)
        Me.sptInfo.SetSuperTooltip(Me.btNuevo, New DevComponents.DotNetBar.SuperTooltipInfo("Nuevo: Ctrl + N", "", "Limpia los campos y permite ingresar un nuevo registro.", Global.appFacturacion.My.Resources.Resources.nuevo, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btNuevo.Text = "Nuevo"
        '
        'btGuardar
        '
        Me.btGuardar.AutoToolTip = False
        Me.btGuardar.Image = Global.appFacturacion.My.Resources.Resources.guardar
        Me.btGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(83, 36)
        Me.sptInfo.SetSuperTooltip(Me.btGuardar, New DevComponents.DotNetBar.SuperTooltipInfo("Guardar: Ctrl + G", "", "Guardar el registro en pantalla con su respectiva información. Cabe destacar que " & _
            "los datos previamente son expuestos a un proceso de validación.", Global.appFacturacion.My.Resources.Resources.guardar, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
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
        Me.sptInfo.SetSuperTooltip(Me.btAnular, New DevComponents.DotNetBar.SuperTooltipInfo("Anular: Ctrl + Del", "", "Elimina el registro mostrado en pantalla.", Global.appFacturacion.My.Resources.Resources.eliminar, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btAnular.Text = "Anular"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btImprimir
        '
        Me.btImprimir.AutoToolTip = False
        Me.btImprimir.Enabled = False
        Me.btImprimir.ForeColor = System.Drawing.Color.Black
        Me.btImprimir.Image = Global.appFacturacion.My.Resources.Resources.imprimir_det
        Me.btImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(79, 36)
        Me.sptInfo.SetSuperTooltip(Me.btImprimir, New DevComponents.DotNetBar.SuperTooltipInfo("Imprimir: Ctrl + P", "", "Imprime el documento mostrado en pantalla.", Global.appFacturacion.My.Resources.Resources.imprimir_det, Nothing, DevComponents.DotNetBar.eTooltipColor.[Default]))
        Me.btImprimir.Text = "Imprimir"
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
        Me.ElGroupBox4.CaptionStyle.Size = New System.Drawing.Size(120, 24)
        Me.ElGroupBox4.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox4.CaptionStyle.TextStyle.Text = "Nota de Devolución"
        Me.ElGroupBox4.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox4.Controls.Add(Me.ElGroupBox1)
        Me.ElGroupBox4.Controls.Add(Me.btActualizarSerie)
        Me.ElGroupBox4.Controls.Add(Me.ElGroupBox6)
        Me.ElGroupBox4.Controls.Add(Me.Label9)
        Me.ElGroupBox4.Controls.Add(Me.txtIdSerie)
        Me.ElGroupBox4.Controls.Add(Me.txtSerie)
        Me.ElGroupBox4.Controls.Add(Me.ElGroupBox3)
        Me.ElGroupBox4.Controls.Add(Me.Label4)
        Me.ElGroupBox4.Controls.Add(Me.txtObservacion)
        Me.ElGroupBox4.Controls.Add(Me.dtpFecha)
        Me.ElGroupBox4.Controls.Add(Me.chkExonerado)
        Me.ElGroupBox4.Controls.Add(Me.txtReferencia)
        Me.ElGroupBox4.Controls.Add(Me.btVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtIdVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtIdCliente)
        Me.ElGroupBox4.Controls.Add(Me.btCliente)
        Me.ElGroupBox4.Controls.Add(Me.Label8)
        Me.ElGroupBox4.Controls.Add(Me.Label1)
        Me.ElGroupBox4.Controls.Add(Me.Label2)
        Me.ElGroupBox4.Controls.Add(Me.Label5)
        Me.ElGroupBox4.Controls.Add(Me.Label10)
        Me.ElGroupBox4.Controls.Add(Me.Label3)
        Me.ElGroupBox4.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox4.Controls.Add(Me.txtNVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtNCliente)
        Me.ElGroupBox4.Controls.Add(Me.txtNombreVendedor)
        Me.ElGroupBox4.Controls.Add(Me.txtNombreCliente)
        Me.ElGroupBox4.Controls.Add(Me.Label6)
        Me.ElGroupBox4.Controls.Add(Me.Label7)
        Me.ElGroupBox4.Controls.Add(Me.Label12)
        Me.ElGroupBox4.Controls.Add(Me.Label13)
        Me.ElGroupBox4.Controls.Add(Me.Label15)
        Me.ElGroupBox4.Location = New System.Drawing.Point(12, 6)
        Me.ElGroupBox4.Name = "ElGroupBox4"
        Me.ElGroupBox4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox4.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox4.Size = New System.Drawing.Size(355, 320)
        Me.ElGroupBox4.TabIndex = 1
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
        Me.ElGroupBox1.CaptionStyle.Size = New System.Drawing.Size(0, 0)
        Me.ElGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Condición Pago"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.txtIdFactura)
        Me.ElGroupBox1.Controls.Add(Me.txtSaldo)
        Me.ElGroupBox1.Controls.Add(Me.btBuscarFactura)
        Me.ElGroupBox1.Controls.Add(Me.Label17)
        Me.ElGroupBox1.Controls.Add(Me.rdContado)
        Me.ElGroupBox1.Controls.Add(Me.rdCredito)
        Me.ElGroupBox1.Controls.Add(Me.Label16)
        Me.ElGroupBox1.Controls.Add(Me.Label19)
        Me.ElGroupBox1.Controls.Add(Me.Panel1)
        Me.ElGroupBox1.Controls.Add(Me.txtFactura)
        Me.ElGroupBox1.Location = New System.Drawing.Point(8, 217)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(162, 92)
        Me.ElGroupBox1.TabIndex = 132
        '
        'txtIdFactura
        '
        Me.txtIdFactura.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtIdFactura.Border.Class = "TextBoxBorder"
        Me.txtIdFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdFactura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdFactura.Location = New System.Drawing.Point(-2, 88)
        Me.txtIdFactura.Name = "txtIdFactura"
        Me.txtIdFactura.ReadOnly = True
        Me.txtIdFactura.Size = New System.Drawing.Size(5, 20)
        Me.txtIdFactura.TabIndex = 19
        '
        'txtSaldo
        '
        '
        '
        '
        Me.txtSaldo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSaldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaldo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSaldo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.ForeColor = System.Drawing.Color.Red
        Me.txtSaldo.Increment = 1.0R
        Me.txtSaldo.IsInputReadOnly = True
        Me.txtSaldo.Location = New System.Drawing.Point(82, 66)
        Me.txtSaldo.MinValue = 0.0R
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(73, 20)
        Me.txtSaldo.TabIndex = 18
        '
        'btBuscarFactura
        '
        Me.btBuscarFactura.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarFactura.BackColor = System.Drawing.Color.Transparent
        Me.btBuscarFactura.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarFactura.Enabled = False
        Me.btBuscarFactura.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btBuscarFactura.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btBuscarFactura.Location = New System.Drawing.Point(126, 43)
        Me.btBuscarFactura.Name = "btBuscarFactura"
        Me.btBuscarFactura.Size = New System.Drawing.Size(29, 22)
        Me.btBuscarFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarFactura.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 14)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Saldo Deudor:"
        '
        'rdContado
        '
        Me.rdContado.AutoSize = True
        Me.rdContado.Checked = True
        Me.rdContado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdContado.Location = New System.Drawing.Point(6, 26)
        Me.rdContado.Name = "rdContado"
        Me.rdContado.Size = New System.Drawing.Size(68, 18)
        Me.rdContado.TabIndex = 14
        Me.rdContado.TabStop = True
        Me.rdContado.Text = "Contado."
        Me.rdContado.UseVisualStyleBackColor = True
        '
        'rdCredito
        '
        Me.rdCredito.AutoSize = True
        Me.rdCredito.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCredito.Location = New System.Drawing.Point(103, 26)
        Me.rdCredito.Name = "rdCredito"
        Me.rdCredito.Size = New System.Drawing.Size(59, 18)
        Me.rdCredito.TabIndex = 15
        Me.rdCredito.TabStop = True
        Me.rdCredito.Text = "Credito"
        Me.rdCredito.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 14)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Términos de la Factura"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 14)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Factura:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(6, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 3)
        Me.Panel1.TabIndex = 2
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtFactura.Border.Class = "TextBoxBorder"
        Me.txtFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFactura.Enabled = False
        Me.txtFactura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(54, 44)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(73, 20)
        Me.txtFactura.TabIndex = 16
        '
        'btActualizarSerie
        '
        Me.btActualizarSerie.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btActualizarSerie.BackColor = System.Drawing.Color.Transparent
        Me.btActualizarSerie.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btActualizarSerie.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btActualizarSerie.Image = Global.appFacturacion.My.Resources.Resources.CargarSerie16x16
        Me.btActualizarSerie.Location = New System.Drawing.Point(140, 26)
        Me.btActualizarSerie.Name = "btActualizarSerie"
        Me.btActualizarSerie.Size = New System.Drawing.Size(29, 22)
        Me.btActualizarSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btActualizarSerie.TabIndex = 2
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
        Me.ElGroupBox6.CaptionStyle.Size = New System.Drawing.Size(0, 0)
        Me.ElGroupBox6.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox6.CaptionStyle.TextStyle.Text = "ElGroupBox6"
        Me.ElGroupBox6.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox6.Controls.Add(Me.txtTazaCambio)
        Me.ElGroupBox6.Controls.Add(Me.Label18)
        Me.ElGroupBox6.Controls.Add(Me.rdDolar)
        Me.ElGroupBox6.Controls.Add(Me.rdCordoba)
        Me.ElGroupBox6.Location = New System.Drawing.Point(69, 144)
        Me.ElGroupBox6.Name = "ElGroupBox6"
        Me.ElGroupBox6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox6.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox6.Size = New System.Drawing.Size(277, 26)
        Me.ElGroupBox6.TabIndex = 14
        '
        'txtTazaCambio
        '
        '
        '
        '
        Me.txtTazaCambio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTazaCambio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTazaCambio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTazaCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTazaCambio.Increment = 1.0R
        Me.txtTazaCambio.IsInputReadOnly = True
        Me.txtTazaCambio.Location = New System.Drawing.Point(206, 3)
        Me.txtTazaCambio.MaxValue = 100.0R
        Me.txtTazaCambio.MinValue = 25.0R
        Me.txtTazaCambio.Name = "txtTazaCambio"
        Me.txtTazaCambio.Size = New System.Drawing.Size(69, 20)
        Me.txtTazaCambio.TabIndex = 3
        Me.txtTazaCambio.Value = 25.0R
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(142, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 14)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "T. / Cambio:"
        '
        'rdDolar
        '
        Me.rdDolar.AutoSize = True
        Me.rdDolar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDolar.Location = New System.Drawing.Point(72, 3)
        Me.rdDolar.Name = "rdDolar"
        Me.rdDolar.Size = New System.Drawing.Size(50, 18)
        Me.rdDolar.TabIndex = 2
        Me.rdDolar.TabStop = True
        Me.rdDolar.Text = "Dólar"
        Me.rdDolar.UseVisualStyleBackColor = True
        '
        'rdCordoba
        '
        Me.rdCordoba.AutoSize = True
        Me.rdCordoba.Checked = True
        Me.rdCordoba.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCordoba.Location = New System.Drawing.Point(5, 3)
        Me.rdCordoba.Name = "rdCordoba"
        Me.rdCordoba.Size = New System.Drawing.Size(66, 18)
        Me.rdCordoba.TabIndex = 1
        Me.rdCordoba.TabStop = True
        Me.rdCordoba.Text = "Córdoba"
        Me.rdCordoba.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 14)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Moneda:"
        '
        'txtIdSerie
        '
        Me.txtIdSerie.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSerie.Location = New System.Drawing.Point(63, 27)
        Me.txtIdSerie.Name = "txtIdSerie"
        Me.txtIdSerie.ReadOnly = True
        Me.txtIdSerie.Size = New System.Drawing.Size(5, 20)
        Me.txtIdSerie.TabIndex = 124
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
        Me.txtSerie.Location = New System.Drawing.Point(69, 27)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(74, 20)
        Me.txtSerie.TabIndex = 1
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
        Me.ElGroupBox3.CaptionStyle.TextStyle.Text = "1"
        Me.ElGroupBox3.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox3.Controls.Add(Me.Panel4)
        Me.ElGroupBox3.Controls.Add(Me.txtDescuentoPorFactura)
        Me.ElGroupBox3.Controls.Add(Me.lblDescuentoPorFactura)
        Me.ElGroupBox3.Controls.Add(Me.rdSindescuento)
        Me.ElGroupBox3.Controls.Add(Me.Label11)
        Me.ElGroupBox3.Controls.Add(Me.rdDescuentoPorFactura)
        Me.ElGroupBox3.Controls.Add(Me.rdDescuentoPorProducto)
        Me.ElGroupBox3.Location = New System.Drawing.Point(184, 217)
        Me.ElGroupBox3.Name = "ElGroupBox3"
        Me.ElGroupBox3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox3.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox3.Size = New System.Drawing.Size(162, 92)
        Me.ElGroupBox3.TabIndex = 17
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(6, 22)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(150, 3)
        Me.Panel4.TabIndex = 52
        '
        'txtDescuentoPorFactura
        '
        '
        '
        '
        Me.txtDescuentoPorFactura.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDescuentoPorFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescuentoPorFactura.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDescuentoPorFactura.Enabled = False
        Me.txtDescuentoPorFactura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuentoPorFactura.Increment = 1.0R
        Me.txtDescuentoPorFactura.Location = New System.Drawing.Point(111, 65)
        Me.txtDescuentoPorFactura.MaxValue = 100.0R
        Me.txtDescuentoPorFactura.MinValue = 0.0R
        Me.txtDescuentoPorFactura.Name = "txtDescuentoPorFactura"
        Me.txtDescuentoPorFactura.Size = New System.Drawing.Size(45, 20)
        Me.txtDescuentoPorFactura.TabIndex = 25
        '
        'lblDescuentoPorFactura
        '
        Me.lblDescuentoPorFactura.AutoSize = True
        Me.lblDescuentoPorFactura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuentoPorFactura.ForeColor = System.Drawing.Color.Black
        Me.lblDescuentoPorFactura.Location = New System.Drawing.Point(77, 67)
        Me.lblDescuentoPorFactura.Name = "lblDescuentoPorFactura"
        Me.lblDescuentoPorFactura.Size = New System.Drawing.Size(28, 14)
        Me.lblDescuentoPorFactura.TabIndex = 50
        Me.lblDescuentoPorFactura.Text = "0.00"
        '
        'rdSindescuento
        '
        Me.rdSindescuento.AutoSize = True
        Me.rdSindescuento.Checked = True
        Me.rdSindescuento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSindescuento.Location = New System.Drawing.Point(6, 27)
        Me.rdSindescuento.Name = "rdSindescuento"
        Me.rdSindescuento.Size = New System.Drawing.Size(97, 18)
        Me.rdSindescuento.TabIndex = 22
        Me.rdSindescuento.TabStop = True
        Me.rdSindescuento.Text = "Sin descuento."
        Me.rdSindescuento.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 14)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Descuentos en Factura"
        '
        'rdDescuentoPorFactura
        '
        Me.rdDescuentoPorFactura.AutoSize = True
        Me.rdDescuentoPorFactura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDescuentoPorFactura.Location = New System.Drawing.Point(6, 63)
        Me.rdDescuentoPorFactura.Name = "rdDescuentoPorFactura"
        Me.rdDescuentoPorFactura.Size = New System.Drawing.Size(74, 18)
        Me.rdDescuentoPorFactura.TabIndex = 24
        Me.rdDescuentoPorFactura.TabStop = True
        Me.rdDescuentoPorFactura.Text = "x Factura."
        Me.rdDescuentoPorFactura.UseVisualStyleBackColor = True
        '
        'rdDescuentoPorProducto
        '
        Me.rdDescuentoPorProducto.AutoSize = True
        Me.rdDescuentoPorProducto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDescuentoPorProducto.Location = New System.Drawing.Point(6, 45)
        Me.rdDescuentoPorProducto.Name = "rdDescuentoPorProducto"
        Me.rdDescuentoPorProducto.Size = New System.Drawing.Size(80, 18)
        Me.rdDescuentoPorProducto.TabIndex = 23
        Me.rdDescuentoPorProducto.TabStop = True
        Me.rdDescuentoPorProducto.Text = "x Producto."
        Me.rdDescuentoPorProducto.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Concepto:"
        '
        'txtObservacion
        '
        '
        '
        '
        Me.txtObservacion.Border.Class = "TextBoxBorder"
        Me.txtObservacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtObservacion.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtObservacion.Location = New System.Drawing.Point(69, 175)
        Me.txtObservacion.Margin = New System.Windows.Forms.Padding(0)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(277, 37)
        Me.txtObservacion.TabIndex = 16
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
        Me.dtpFecha.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dtpFecha.Location = New System.Drawing.Point(239, 51)
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
        Me.dtpFecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
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
        Me.dtpFecha.Size = New System.Drawing.Size(107, 20)
        Me.dtpFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFecha.TabIndex = 5
        '
        'chkExonerado
        '
        Me.chkExonerado.AutoSize = True
        Me.chkExonerado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkExonerado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExonerado.Location = New System.Drawing.Point(4, 122)
        Me.chkExonerado.Name = "chkExonerado"
        Me.chkExonerado.Size = New System.Drawing.Size(118, 18)
        Me.chkExonerado.TabIndex = 13
        Me.chkExonerado.Text = "Factura exonerada"
        Me.chkExonerado.UseVisualStyleBackColor = True
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReferencia.Border.Class = "TextBoxBorder"
        Me.txtReferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReferencia.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtReferencia.Location = New System.Drawing.Point(214, 27)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(132, 20)
        Me.txtReferencia.TabIndex = 3
        '
        'btVendedor
        '
        Me.btVendedor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btVendedor.BackColor = System.Drawing.Color.Transparent
        Me.btVendedor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btVendedor.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btVendedor.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btVendedor.Location = New System.Drawing.Point(317, 74)
        Me.btVendedor.Name = "btVendedor"
        Me.btVendedor.Size = New System.Drawing.Size(29, 22)
        Me.btVendedor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btVendedor.TabIndex = 8
        '
        'txtIdVendedor
        '
        Me.txtIdVendedor.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtIdVendedor.Location = New System.Drawing.Point(62, 76)
        Me.txtIdVendedor.Name = "txtIdVendedor"
        Me.txtIdVendedor.ReadOnly = True
        Me.txtIdVendedor.Size = New System.Drawing.Size(5, 20)
        Me.txtIdVendedor.TabIndex = 110
        Me.txtIdVendedor.Visible = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtIdCliente.Location = New System.Drawing.Point(62, 99)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(5, 20)
        Me.txtIdCliente.TabIndex = 107
        Me.txtIdCliente.Visible = False
        '
        'btCliente
        '
        Me.btCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btCliente.BackColor = System.Drawing.Color.Transparent
        Me.btCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btCliente.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btCliente.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btCliente.Location = New System.Drawing.Point(317, 98)
        Me.btCliente.Name = "btCliente"
        Me.btCliente.Size = New System.Drawing.Size(29, 22)
        Me.btCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btCliente.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Empleado:"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtCodigo.Location = New System.Drawing.Point(69, 51)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 4
        '
        'txtNVendedor
        '
        '
        '
        '
        Me.txtNVendedor.Border.Class = "TextBoxBorder"
        Me.txtNVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNVendedor.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtNVendedor.Location = New System.Drawing.Point(69, 75)
        Me.txtNVendedor.Name = "txtNVendedor"
        Me.txtNVendedor.Size = New System.Drawing.Size(100, 20)
        Me.txtNVendedor.TabIndex = 6
        '
        'txtNCliente
        '
        '
        '
        '
        Me.txtNCliente.Border.Class = "TextBoxBorder"
        Me.txtNCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNCliente.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtNCliente.Location = New System.Drawing.Point(69, 99)
        Me.txtNCliente.Name = "txtNCliente"
        Me.txtNCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtNCliente.TabIndex = 10
        '
        'txtNombreVendedor
        '
        Me.txtNombreVendedor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNombreVendedor.Border.Class = "TextBoxBorder"
        Me.txtNombreVendedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreVendedor.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtNombreVendedor.Location = New System.Drawing.Point(168, 75)
        Me.txtNombreVendedor.Name = "txtNombreVendedor"
        Me.txtNombreVendedor.ReadOnly = True
        Me.txtNombreVendedor.Size = New System.Drawing.Size(150, 20)
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
        Me.txtNombreCliente.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtNombreCliente.Location = New System.Drawing.Point(168, 99)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(150, 20)
        Me.txtNombreCliente.TabIndex = 11
        Me.txtNombreCliente.Text = "CLIENTES VARIOS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(168, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label6, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label6.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(345, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label7, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label7.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(345, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label12, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label12.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label12.TabIndex = 128
        Me.Label12.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(345, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label13, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label13.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(345, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label15, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label15.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label15.TabIndex = 130
        Me.Label15.Text = "*"
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.ElGroupBox4)
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Left
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
        'PanelEx3
        '
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.ElGroupBox5)
        Me.PanelEx3.Controls.Add(Me.ElGroupBox2)
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelEx3.Location = New System.Drawing.Point(394, 39)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(565, 173)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 2
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
        Me.ElGroupBox5.CaptionStyle.TextStyle.Text = "ElGroupBox5"
        Me.ElGroupBox5.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox5.Controls.Add(Me.txtTotal)
        Me.ElGroupBox5.Controls.Add(Me.txtTotalIva)
        Me.ElGroupBox5.Controls.Add(Me.txtTotalSubtotal)
        Me.ElGroupBox5.Controls.Add(Me.ElLabel8)
        Me.ElGroupBox5.Controls.Add(Me.ElLabel7)
        Me.ElGroupBox5.Controls.Add(Me.lblContador)
        Me.ElGroupBox5.Controls.Add(Me.ElLabel5)
        Me.ElGroupBox5.Controls.Add(Me.txtTotalDescuento)
        Me.ElGroupBox5.Controls.Add(Me.ElLabel6)
        Me.ElGroupBox5.Location = New System.Drawing.Point(362, 18)
        Me.ElGroupBox5.Name = "ElGroupBox5"
        Me.ElGroupBox5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox5.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox5.Size = New System.Drawing.Size(196, 127)
        Me.ElGroupBox5.TabIndex = 75
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
        Me.txtTotal.Location = New System.Drawing.Point(96, 81)
        Me.txtTotal.MinValue = 0.0R
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(93, 23)
        Me.txtTotal.TabIndex = 76
        '
        'txtTotalIva
        '
        '
        '
        '
        Me.txtTotalIva.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalIva.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalIva.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalIva.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.Increment = 1.0R
        Me.txtTotalIva.IsInputReadOnly = True
        Me.txtTotalIva.Location = New System.Drawing.Point(96, 56)
        Me.txtTotalIva.MinValue = 0.0R
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.Size = New System.Drawing.Size(93, 23)
        Me.txtTotalIva.TabIndex = 76
        '
        'txtTotalSubtotal
        '
        '
        '
        '
        Me.txtTotalSubtotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalSubtotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalSubtotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalSubtotal.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSubtotal.Increment = 1.0R
        Me.txtTotalSubtotal.IsInputReadOnly = True
        Me.txtTotalSubtotal.Location = New System.Drawing.Point(96, 31)
        Me.txtTotalSubtotal.MinValue = 0.0R
        Me.txtTotalSubtotal.Name = "txtTotalSubtotal"
        Me.txtTotalSubtotal.Size = New System.Drawing.Size(93, 23)
        Me.txtTotalSubtotal.TabIndex = 76
        '
        'ElLabel8
        '
        Me.ElLabel8.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle1.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel8.FlashStyle = PaintStyle1
        Me.ElLabel8.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel8.Location = New System.Drawing.Point(7, 81)
        Me.ElLabel8.Name = "ElLabel8"
        Me.ElLabel8.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel8.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel8.TabIndex = 74
        Me.ElLabel8.TabStop = False
        Me.ElLabel8.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel8.TextStyle.Text = "Total Neto:"
        '
        'ElLabel7
        '
        Me.ElLabel7.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle2.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel7.FlashStyle = PaintStyle2
        Me.ElLabel7.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel7.Location = New System.Drawing.Point(7, 56)
        Me.ElLabel7.Name = "ElLabel7"
        Me.ElLabel7.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel7.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel7.TabIndex = 74
        Me.ElLabel7.TabStop = False
        Me.ElLabel7.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel7.TextStyle.Text = "Imp. (IVA):"
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.BackColor = System.Drawing.Color.Transparent
        Me.lblContador.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContador.ForeColor = System.Drawing.Color.Black
        Me.lblContador.Location = New System.Drawing.Point(9, 108)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(59, 14)
        Me.lblContador.TabIndex = 71
        Me.lblContador.Text = "N° ITEM: 0"
        '
        'ElLabel5
        '
        Me.ElLabel5.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle3.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel5.FlashStyle = PaintStyle3
        Me.ElLabel5.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel5.Location = New System.Drawing.Point(7, 31)
        Me.ElLabel5.Name = "ElLabel5"
        Me.ElLabel5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel5.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel5.TabIndex = 74
        Me.ElLabel5.TabStop = False
        Me.ElLabel5.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel5.TextStyle.Text = "Sub Total:"
        '
        'txtTotalDescuento
        '
        '
        '
        '
        Me.txtTotalDescuento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalDescuento.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.Increment = 1.0R
        Me.txtTotalDescuento.IsInputReadOnly = True
        Me.txtTotalDescuento.Location = New System.Drawing.Point(96, 6)
        Me.txtTotalDescuento.MinValue = 0.0R
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.Size = New System.Drawing.Size(93, 23)
        Me.txtTotalDescuento.TabIndex = 76
        '
        'ElLabel6
        '
        Me.ElLabel6.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle4.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel6.FlashStyle = PaintStyle4
        Me.ElLabel6.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel6.Location = New System.Drawing.Point(7, 6)
        Me.ElLabel6.Name = "ElLabel6"
        Me.ElLabel6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel6.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel6.TabIndex = 74
        Me.ElLabel6.TabStop = False
        Me.ElLabel6.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel6.TextStyle.Text = "Descuento:"
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
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "ElGroupBox2"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.Label14)
        Me.ElGroupBox2.Controls.Add(Me.txtCodigoAlterno)
        Me.ElGroupBox2.Controls.Add(Me.ElLabel3)
        Me.ElGroupBox2.Controls.Add(Me.ElLabel2)
        Me.ElGroupBox2.Controls.Add(Me.ElLabel1)
        Me.ElGroupBox2.Controls.Add(Me.ElLabel4)
        Me.ElGroupBox2.Controls.Add(Me.chkIncluyeIVA)
        Me.ElGroupBox2.Controls.Add(Me.txtDescuentoPorProducto)
        Me.ElGroupBox2.Controls.Add(Me.btAgregarProducto)
        Me.ElGroupBox2.Controls.Add(Me.txtCantidad)
        Me.ElGroupBox2.Controls.Add(Me.btProducto)
        Me.ElGroupBox2.Controls.Add(Me.txtIva)
        Me.ElGroupBox2.Controls.Add(Me.txtPrecio)
        Me.ElGroupBox2.Location = New System.Drawing.Point(6, 18)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(307, 127)
        Me.ElGroupBox2.TabIndex = 74
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(9, 108)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(251, 14)
        Me.sptInfo.SetSuperTooltip(Me.Label14, New DevComponents.DotNetBar.SuperTooltipInfo("Advertencia! Campo de orden obligatorio (*).", "Sistema de Inventario y Facturación // SIF", resources.GetString("Label14.SuperTooltip"), Global.appFacturacion.My.Resources.Resources._Error, Nothing, DevComponents.DotNetBar.eTooltipColor.Red))
        Me.Label14.TabIndex = 75
        Me.Label14.Text = "(*)  CAMPO OBLIGATORIO: INGRESAR DETALLE"
        '
        'txtCodigoAlterno
        '
        Me.txtCodigoAlterno.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtCodigoAlterno.Border.Class = "TextBoxBorder"
        Me.txtCodigoAlterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigoAlterno.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoAlterno.ForeColor = System.Drawing.Color.Yellow
        Me.txtCodigoAlterno.Location = New System.Drawing.Point(96, 6)
        Me.txtCodigoAlterno.Name = "txtCodigoAlterno"
        Me.txtCodigoAlterno.Size = New System.Drawing.Size(148, 23)
        Me.txtCodigoAlterno.TabIndex = 26
        '
        'ElLabel3
        '
        Me.ElLabel3.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle5.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle5.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel3.FlashStyle = PaintStyle5
        Me.ElLabel3.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel3.Location = New System.Drawing.Point(7, 82)
        Me.ElLabel3.Name = "ElLabel3"
        Me.ElLabel3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel3.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel3.TabIndex = 73
        Me.ElLabel3.TabStop = False
        Me.ElLabel3.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel3.TextStyle.Text = "Descuento:"
        '
        'ElLabel2
        '
        Me.ElLabel2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle6.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle6.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel2.FlashStyle = PaintStyle6
        Me.ElLabel2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel2.Location = New System.Drawing.Point(7, 56)
        Me.ElLabel2.Name = "ElLabel2"
        Me.ElLabel2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel2.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel2.TabIndex = 73
        Me.ElLabel2.TabStop = False
        Me.ElLabel2.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel2.TextStyle.Text = "Precio:"
        '
        'ElLabel1
        '
        Me.ElLabel1.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle7.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle7.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel1.FlashStyle = PaintStyle7
        Me.ElLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel1.Location = New System.Drawing.Point(7, 31)
        Me.ElLabel1.Name = "ElLabel1"
        Me.ElLabel1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel1.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel1.TabIndex = 73
        Me.ElLabel1.TabStop = False
        Me.ElLabel1.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel1.TextStyle.Text = "Cantidad:"
        '
        'ElLabel4
        '
        Me.ElLabel4.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        PaintStyle8.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        PaintStyle8.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElLabel4.FlashStyle = PaintStyle8
        Me.ElLabel4.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElLabel4.Location = New System.Drawing.Point(7, 6)
        Me.ElLabel4.Name = "ElLabel4"
        Me.ElLabel4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElLabel4.Size = New System.Drawing.Size(85, 23)
        Me.ElLabel4.TabIndex = 73
        Me.ElLabel4.TabStop = False
        Me.ElLabel4.TextStyle.ForeColor = System.Drawing.Color.Yellow
        Me.ElLabel4.TextStyle.Text = "Producto:"
        '
        'chkIncluyeIVA
        '
        Me.chkIncluyeIVA.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.chkIncluyeIVA.BackgroundStyle.Class = ""
        Me.chkIncluyeIVA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkIncluyeIVA.CheckSignSize = New System.Drawing.Size(10, 10)
        Me.chkIncluyeIVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncluyeIVA.Location = New System.Drawing.Point(7, 133)
        Me.chkIncluyeIVA.Name = "chkIncluyeIVA"
        Me.chkIncluyeIVA.Size = New System.Drawing.Size(190, 19)
        Me.chkIncluyeIVA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkIncluyeIVA.TabIndex = 33
        Me.chkIncluyeIVA.Text = "<b><font color=""#C0504D"">IVA</font></b>incluido en este producto."
        Me.chkIncluyeIVA.TextColor = System.Drawing.Color.Black
        Me.chkIncluyeIVA.Visible = False
        '
        'txtDescuentoPorProducto
        '
        '
        '
        '
        Me.txtDescuentoPorProducto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDescuentoPorProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescuentoPorProducto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDescuentoPorProducto.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuentoPorProducto.Increment = 1.0R
        Me.txtDescuentoPorProducto.Location = New System.Drawing.Point(96, 82)
        Me.txtDescuentoPorProducto.MinValue = 0.0R
        Me.txtDescuentoPorProducto.Name = "txtDescuentoPorProducto"
        Me.txtDescuentoPorProducto.Size = New System.Drawing.Size(101, 23)
        Me.txtDescuentoPorProducto.TabIndex = 31
        '
        'btAgregarProducto
        '
        Me.btAgregarProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btAgregarProducto.BackColor = System.Drawing.Color.Transparent
        Me.btAgregarProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btAgregarProducto.Image = Global.appFacturacion.My.Resources.Resources.btn_agregar
        Me.btAgregarProducto.Location = New System.Drawing.Point(272, 6)
        Me.btAgregarProducto.Name = "btAgregarProducto"
        Me.btAgregarProducto.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btAgregarProducto.Size = New System.Drawing.Size(29, 23)
        Me.btAgregarProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btAgregarProducto.TabIndex = 28
        '
        'txtCantidad
        '
        '
        '
        '
        Me.txtCantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantidad.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Increment = 1.0R
        Me.txtCantidad.Location = New System.Drawing.Point(96, 31)
        Me.txtCantidad.MinValue = 0.0R
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(101, 23)
        Me.txtCantidad.TabIndex = 29
        Me.txtCantidad.Value = 1.0R
        '
        'btProducto
        '
        Me.btProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btProducto.BackColor = System.Drawing.Color.Transparent
        Me.btProducto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btProducto.Image = Global.appFacturacion.My.Resources.Resources.btn_buscar
        Me.btProducto.Location = New System.Drawing.Point(243, 6)
        Me.btProducto.Name = "btProducto"
        Me.btProducto.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btProducto.Size = New System.Drawing.Size(29, 23)
        Me.btProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btProducto.TabIndex = 27
        '
        'txtIva
        '
        '
        '
        '
        Me.txtIva.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtIva.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIva.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtIva.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva.Increment = 1.0R
        Me.txtIva.Location = New System.Drawing.Point(251, 132)
        Me.txtIva.MaxValue = 100.0R
        Me.txtIva.MinValue = 0.0R
        Me.txtIva.Name = "txtIva"
        Me.txtIva.Size = New System.Drawing.Size(50, 20)
        Me.txtIva.TabIndex = 32
        Me.txtIva.Visible = False
        '
        'txtPrecio
        '
        '
        '
        '
        Me.txtPrecio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPrecio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrecio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPrecio.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Increment = 1.0R
        Me.txtPrecio.Location = New System.Drawing.Point(96, 56)
        Me.txtPrecio.MinValue = 0.0R
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(101, 23)
        Me.txtPrecio.TabIndex = 30
        '
        'dtRegistro
        '
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(394, 212)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(565, 183)
        Me.dtRegistro.TabIndex = 3
        '
        'frmNotaDevolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(959, 395)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmNotaDevolucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota de Devolución"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox4.ResumeLayout(False)
        Me.ElGroupBox4.PerformLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox6.ResumeLayout(False)
        Me.ElGroupBox6.PerformLayout()
        CType(Me.txtTazaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox3.ResumeLayout(False)
        Me.ElGroupBox3.PerformLayout()
        CType(Me.txtDescuentoPorFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.ElGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox5.ResumeLayout(False)
        Me.ElGroupBox5.PerformLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalSubtotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        CType(Me.ElLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescuentoPorProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ElGroupBox4 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btCliente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btVendedor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIdVendedor As System.Windows.Forms.TextBox
    Friend WithEvents btActualizarSerie As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtReferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtpFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtNombreVendedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombreCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents chkExonerado As System.Windows.Forms.CheckBox
    Friend WithEvents ElGroupBox3 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtDescuentoPorFactura As DevComponents.Editors.DoubleInput
    Friend WithEvents lblDescuentoPorFactura As System.Windows.Forms.Label
    Friend WithEvents rdSindescuento As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rdDescuentoPorFactura As System.Windows.Forms.RadioButton
    Friend WithEvents rdDescuentoPorProducto As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtCodigoAlterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ElLabel3 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElLabel2 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElLabel1 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElLabel4 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents chkIncluyeIVA As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtDescuentoPorProducto As DevComponents.Editors.DoubleInput
    Friend WithEvents btAgregarProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCantidad As DevComponents.Editors.DoubleInput
    Friend WithEvents btProducto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtIva As DevComponents.Editors.DoubleInput
    Friend WithEvents txtPrecio As DevComponents.Editors.DoubleInput
    Friend WithEvents ElGroupBox5 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents txtTotalIva As DevComponents.Editors.DoubleInput
    Friend WithEvents txtTotalSubtotal As DevComponents.Editors.DoubleInput
    Friend WithEvents ElLabel8 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents ElLabel7 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents ElLabel5 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents txtTotalDescuento As DevComponents.Editors.DoubleInput
    Friend WithEvents ElLabel6 As Klik.Windows.Forms.v1.EntryLib.ELLabel
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtIdSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ElGroupBox6 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtTazaCambio As DevComponents.Editors.DoubleInput
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents rdDolar As System.Windows.Forms.RadioButton
    Friend WithEvents rdCordoba As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents sptInfo As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents rdContado As System.Windows.Forms.RadioButton
    Friend WithEvents rdCredito As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtFactura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btBuscarFactura As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtSaldo As DevComponents.Editors.DoubleInput
    Friend WithEvents txtIdFactura As DevComponents.DotNetBar.Controls.TextBoxX
End Class
