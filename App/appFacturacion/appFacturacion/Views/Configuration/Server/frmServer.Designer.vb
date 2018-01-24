<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServer))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtBD = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAutenticacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btCancelar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.btConfigurar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.btCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btConfigurar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Dirección IP o DNS e Instancia SGBD:"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(216, 99)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(164, 20)
        Me.txtServer.TabIndex = 3
        '
        'txtBD
        '
        Me.txtBD.Location = New System.Drawing.Point(216, 125)
        Me.txtBD.Name = "txtBD"
        Me.txtBD.Size = New System.Drawing.Size(164, 20)
        Me.txtBD.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre de la Base de Datos:"
        '
        'txtUsuario
        '
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Location = New System.Drawing.Point(216, 177)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(164, 20)
        Me.txtUsuario.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(86, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Usuario de SQL Server:"
        '
        'txtContraseña
        '
        Me.txtContraseña.Enabled = False
        Me.txtContraseña.Location = New System.Drawing.Point(216, 203)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtContraseña.Size = New System.Drawing.Size(164, 20)
        Me.txtContraseña.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Contraseña:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(132, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Autenticación:"
        '
        'cmbAutenticacion
        '
        Me.cmbAutenticacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAutenticacion.FormattingEnabled = True
        Me.cmbAutenticacion.Location = New System.Drawing.Point(216, 151)
        Me.cmbAutenticacion.Name = "cmbAutenticacion"
        Me.cmbAutenticacion.Size = New System.Drawing.Size(164, 22)
        Me.cmbAutenticacion.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(411, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Configuración Servidor - Sadara SIF 2016"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(431, 53)
        Me.Panel1.TabIndex = 0
        '
        'btCancelar
        '
        Me.btCancelar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btCancelar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btCancelar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btCancelar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btCancelar.BorderStyle.EdgeRadius = 7
        Me.btCancelar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btCancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btCancelar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btCancelar.ForegroundImageStyle.Image = Global.appFacturacion.My.Resources.Resources.Testear
        Me.btCancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCancelar.Location = New System.Drawing.Point(226, 238)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver
        Me.btCancelar.Size = New System.Drawing.Size(82, 31)
        Me.btCancelar.TabIndex = 14
        Me.btCancelar.TextStyle.Text = "Testear"
        Me.btCancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btConfigurar
        '
        Me.btConfigurar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btConfigurar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btConfigurar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btConfigurar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.btConfigurar.BorderStyle.EdgeRadius = 7
        Me.btConfigurar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btConfigurar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btConfigurar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btConfigurar.ForegroundImageStyle.Image = Global.appFacturacion.My.Resources.Resources.Config
        Me.btConfigurar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btConfigurar.Location = New System.Drawing.Point(127, 238)
        Me.btConfigurar.Name = "btConfigurar"
        Me.btConfigurar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.btConfigurar.Size = New System.Drawing.Size(95, 31)
        Me.btConfigurar.TabIndex = 13
        Me.btConfigurar.TextStyle.Text = "Configurar"
        Me.btConfigurar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.appFacturacion.My.Resources.Resources.Linea
        Me.PictureBox1.Location = New System.Drawing.Point(0, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(431, 4)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(431, 307)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.btConfigurar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmbAutenticacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conexión con el Servidor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btConfigurar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtBD As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAutenticacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btConfigurar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents btCancelar As Klik.Windows.Forms.v1.EntryLib.ELButton
End Class
