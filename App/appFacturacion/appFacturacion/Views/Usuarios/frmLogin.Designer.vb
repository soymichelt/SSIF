<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim GradientBlend1 As Klik.Windows.Forms.v1.Common.GradientBlend = New Klik.Windows.Forms.v1.Common.GradientBlend()
        Dim GradientBlend2 As Klik.Windows.Forms.v1.Common.GradientBlend = New Klik.Windows.Forms.v1.Common.GradientBlend()
        Dim GradientBlend3 As Klik.Windows.Forms.v1.Common.GradientBlend = New Klik.Windows.Forms.v1.Common.GradientBlend()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.styEstiloSistema = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtContraseña = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.gpSesion = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btSalir = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.btEntrar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpSesion.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btSalir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btEntrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(33, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(9, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contraseña:"
        '
        'styEstiloSistema
        '
        Me.styEstiloSistema.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUsuario.Border.BorderColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerDiameter = 3
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.txtUsuario.Location = New System.Drawing.Point(101, 35)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(5)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(145, 22)
        Me.txtUsuario.TabIndex = 1
        '
        'txtContraseña
        '
        Me.txtContraseña.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtContraseña.Border.BorderColor = System.Drawing.Color.Black
        Me.txtContraseña.Border.Class = "TextBoxBorder"
        Me.txtContraseña.Border.CornerDiameter = 3
        Me.txtContraseña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContraseña.Font = New System.Drawing.Font("Google Sans Medium", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.txtContraseña.Location = New System.Drawing.Point(101, 65)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtContraseña.Size = New System.Drawing.Size(145, 22)
        Me.txtContraseña.TabIndex = 2
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
        'gpSesion
        '
        Me.gpSesion.BackgroundStyle.GradientAngle = 45.0!
        Me.gpSesion.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.gpSesion.CaptionStyle.Align = System.Drawing.ContentAlignment.MiddleCenter
        Me.gpSesion.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.gpSesion.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.gpSesion.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.gpSesion.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.gpSesion.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gpSesion.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.gpSesion.CaptionStyle.Size = New System.Drawing.Size(210, 24)
        Me.gpSesion.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.gpSesion.CaptionStyle.TextStyle.Text = "Sistema de Inventario y Facturación"
        Me.gpSesion.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gpSesion.Controls.Add(Me.PictureBox3)
        Me.gpSesion.Controls.Add(Me.btSalir)
        Me.gpSesion.Controls.Add(Me.btEntrar)
        Me.gpSesion.Controls.Add(Me.txtUsuario)
        Me.gpSesion.Controls.Add(Me.Label1)
        Me.gpSesion.Controls.Add(Me.txtContraseña)
        Me.gpSesion.Controls.Add(Me.Label2)
        Me.gpSesion.Location = New System.Drawing.Point(111, 105)
        Me.gpSesion.Name = "gpSesion"
        Me.gpSesion.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.gpSesion.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.gpSesion.Size = New System.Drawing.Size(259, 151)
        Me.gpSesion.TabIndex = 2
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.appFacturacion.My.Resources.Resources.Linea
        Me.PictureBox3.Location = New System.Drawing.Point(12, 95)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(234, 4)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 13
        Me.PictureBox3.TabStop = False
        '
        'btSalir
        '
        Me.btSalir.BackgroundStyle.GradientEndColor = System.Drawing.Color.BurlyWood
        Me.btSalir.BackgroundStyle.GradientStartColor = System.Drawing.Color.NavajoWhite
        Me.btSalir.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btSalir.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btSalir.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btSalir.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btSalir.BorderStyle.EdgeRadius = 7
        Me.btSalir.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btSalir.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btSalir.DropDownArrowColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btSalir.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btSalir.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btSalir.ForegroundImageStyle.Image = Global.appFacturacion.My.Resources.Resources.Cerrar_24_24
        Me.btSalir.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btSalir.Location = New System.Drawing.Point(121, 111)
        Me.btSalir.Name = "btSalir"
        Me.btSalir.Size = New System.Drawing.Size(125, 31)
        Me.btSalir.StateStyles.FocusStyle.BackgroundPaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btSalir.StateStyles.FocusStyle.BackgroundSolidColor = System.Drawing.Color.BurlyWood
        GradientBlend1.Factor = 0!
        GradientBlend1.Position = 0!
        GradientBlend2.Factor = 0!
        GradientBlend2.Position = 0.5!
        GradientBlend3.Factor = 1.0!
        GradientBlend3.Position = 1.0!
        Me.btSalir.StateStyles.HoverStyle.BackgroundGradientBlend.Add(GradientBlend1)
        Me.btSalir.StateStyles.HoverStyle.BackgroundGradientBlend.Add(GradientBlend2)
        Me.btSalir.StateStyles.HoverStyle.BackgroundGradientBlend.Add(GradientBlend3)
        Me.btSalir.StateStyles.PressedStyle.BackgroundGradientEndColor = System.Drawing.Color.NavajoWhite
        Me.btSalir.StateStyles.PressedStyle.BackgroundGradientStartColor = System.Drawing.Color.BurlyWood
        Me.btSalir.TabIndex = 4
        Me.btSalir.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btSalir.TextStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btSalir.TextStyle.Text = "Salir del Sistema"
        Me.btSalir.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btSalir.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom
        '
        'btEntrar
        '
        Me.btEntrar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btEntrar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btEntrar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btEntrar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btEntrar.BorderStyle.EdgeRadius = 7
        Me.btEntrar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btEntrar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btEntrar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btEntrar.ForegroundImageStyle.Image = Global.appFacturacion.My.Resources.Resources.Entrar
        Me.btEntrar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btEntrar.Location = New System.Drawing.Point(12, 111)
        Me.btEntrar.Name = "btEntrar"
        Me.btEntrar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlack
        Me.btEntrar.Size = New System.Drawing.Size(108, 31)
        Me.btEntrar.TabIndex = 3
        Me.btEntrar.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btEntrar.TextStyle.Text = "Iniciar Sesión"
        Me.btEntrar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 404)
        Me.Controls.Add(Me.gpSesion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(372, 305)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Sesion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpSesion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpSesion.ResumeLayout(False)
        Me.gpSesion.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btSalir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btEntrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents styEstiloSistema As DevComponents.DotNetBar.StyleManager
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtContraseña As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents gpSesion As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents btSalir As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents btEntrar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
