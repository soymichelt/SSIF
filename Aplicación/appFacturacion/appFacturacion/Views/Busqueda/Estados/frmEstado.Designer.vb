<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstado))
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtVencidoDolar = New DevComponents.Editors.DoubleInput()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPlazo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMoneda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSaldoDolar = New DevComponents.Editors.DoubleInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVencidoCordoba = New DevComponents.Editors.DoubleInput()
        Me.txtDisponible = New DevComponents.Editors.DoubleInput()
        Me.txtSaldoCordoba = New DevComponents.Editors.DoubleInput()
        Me.txtLimite = New DevComponents.Editors.DoubleInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.txtVencidoDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVencidoCordoba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoCordoba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Información"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.txtVencidoDolar)
        Me.ElGroupBox1.Controls.Add(Me.Label8)
        Me.ElGroupBox1.Controls.Add(Me.txtPlazo)
        Me.ElGroupBox1.Controls.Add(Me.Label7)
        Me.ElGroupBox1.Controls.Add(Me.txtMoneda)
        Me.ElGroupBox1.Controls.Add(Me.Label6)
        Me.ElGroupBox1.Controls.Add(Me.txtSaldoDolar)
        Me.ElGroupBox1.Controls.Add(Me.Label5)
        Me.ElGroupBox1.Controls.Add(Me.txtVencidoCordoba)
        Me.ElGroupBox1.Controls.Add(Me.txtDisponible)
        Me.ElGroupBox1.Controls.Add(Me.txtSaldoCordoba)
        Me.ElGroupBox1.Controls.Add(Me.txtLimite)
        Me.ElGroupBox1.Controls.Add(Me.Label4)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Location = New System.Drawing.Point(30, 27)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(309, 266)
        Me.ElGroupBox1.TabIndex = 0
        '
        'txtVencidoDolar
        '
        Me.txtVencidoDolar.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtVencidoDolar.BackgroundStyle.BackColor = System.Drawing.Color.Black
        Me.txtVencidoDolar.BackgroundStyle.BorderColor = System.Drawing.Color.Yellow
        Me.txtVencidoDolar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtVencidoDolar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVencidoDolar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtVencidoDolar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVencidoDolar.ForeColor = System.Drawing.Color.Yellow
        Me.txtVencidoDolar.Increment = 1.0R
        Me.txtVencidoDolar.IsInputReadOnly = True
        Me.txtVencidoDolar.Location = New System.Drawing.Point(128, 221)
        Me.txtVencidoDolar.MinValue = 0.0R
        Me.txtVencidoDolar.Name = "txtVencidoDolar"
        Me.txtVencidoDolar.Size = New System.Drawing.Size(166, 23)
        Me.txtVencidoDolar.TabIndex = 41
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 14)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Vencido en Dólar:"
        '
        'txtPlazo
        '
        Me.txtPlazo.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtPlazo.Border.BorderColor = System.Drawing.Color.Yellow
        Me.txtPlazo.Border.Class = "TextBoxBorder"
        Me.txtPlazo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPlazo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlazo.ForeColor = System.Drawing.Color.Yellow
        Me.txtPlazo.Location = New System.Drawing.Point(128, 32)
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.ReadOnly = True
        Me.txtPlazo.Size = New System.Drawing.Size(166, 23)
        Me.txtPlazo.TabIndex = 39
        Me.txtPlazo.Text = "0"
        Me.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 14)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Plazo del Crédito:"
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtMoneda.Border.BorderColor = System.Drawing.Color.Yellow
        Me.txtMoneda.Border.Class = "TextBoxBorder"
        Me.txtMoneda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMoneda.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.ForeColor = System.Drawing.Color.Yellow
        Me.txtMoneda.Location = New System.Drawing.Point(128, 59)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(166, 23)
        Me.txtMoneda.TabIndex = 37
        Me.txtMoneda.Text = "Córdoba"
        Me.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 14)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Móneda del Crédito:"
        '
        'txtSaldoDolar
        '
        Me.txtSaldoDolar.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtSaldoDolar.BackgroundStyle.BackColor = System.Drawing.Color.Black
        Me.txtSaldoDolar.BackgroundStyle.BorderColor = System.Drawing.Color.Yellow
        Me.txtSaldoDolar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSaldoDolar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaldoDolar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSaldoDolar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoDolar.ForeColor = System.Drawing.Color.Yellow
        Me.txtSaldoDolar.Increment = 1.0R
        Me.txtSaldoDolar.IsInputReadOnly = True
        Me.txtSaldoDolar.Location = New System.Drawing.Point(128, 140)
        Me.txtSaldoDolar.MinValue = 0.0R
        Me.txtSaldoDolar.Name = "txtSaldoDolar"
        Me.txtSaldoDolar.Size = New System.Drawing.Size(166, 23)
        Me.txtSaldoDolar.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 14)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Saldo en Dólar:"
        '
        'txtVencidoCordoba
        '
        Me.txtVencidoCordoba.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtVencidoCordoba.BackgroundStyle.BackColor = System.Drawing.Color.Black
        Me.txtVencidoCordoba.BackgroundStyle.BorderColor = System.Drawing.Color.Yellow
        Me.txtVencidoCordoba.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtVencidoCordoba.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVencidoCordoba.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtVencidoCordoba.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVencidoCordoba.ForeColor = System.Drawing.Color.Yellow
        Me.txtVencidoCordoba.Increment = 1.0R
        Me.txtVencidoCordoba.IsInputReadOnly = True
        Me.txtVencidoCordoba.Location = New System.Drawing.Point(128, 194)
        Me.txtVencidoCordoba.MinValue = 0.0R
        Me.txtVencidoCordoba.Name = "txtVencidoCordoba"
        Me.txtVencidoCordoba.Size = New System.Drawing.Size(166, 23)
        Me.txtVencidoCordoba.TabIndex = 33
        '
        'txtDisponible
        '
        Me.txtDisponible.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtDisponible.BackgroundStyle.BackColor = System.Drawing.Color.Black
        Me.txtDisponible.BackgroundStyle.BorderColor = System.Drawing.Color.Yellow
        Me.txtDisponible.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDisponible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDisponible.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDisponible.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisponible.ForeColor = System.Drawing.Color.Yellow
        Me.txtDisponible.Increment = 1.0R
        Me.txtDisponible.IsInputReadOnly = True
        Me.txtDisponible.Location = New System.Drawing.Point(128, 167)
        Me.txtDisponible.MinValue = 0.0R
        Me.txtDisponible.Name = "txtDisponible"
        Me.txtDisponible.Size = New System.Drawing.Size(166, 23)
        Me.txtDisponible.TabIndex = 32
        '
        'txtSaldoCordoba
        '
        Me.txtSaldoCordoba.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtSaldoCordoba.BackgroundStyle.BackColor = System.Drawing.Color.Black
        Me.txtSaldoCordoba.BackgroundStyle.BorderColor = System.Drawing.Color.Yellow
        Me.txtSaldoCordoba.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSaldoCordoba.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaldoCordoba.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSaldoCordoba.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoCordoba.ForeColor = System.Drawing.Color.Yellow
        Me.txtSaldoCordoba.Increment = 1.0R
        Me.txtSaldoCordoba.IsInputReadOnly = True
        Me.txtSaldoCordoba.Location = New System.Drawing.Point(128, 113)
        Me.txtSaldoCordoba.MinValue = 0.0R
        Me.txtSaldoCordoba.Name = "txtSaldoCordoba"
        Me.txtSaldoCordoba.Size = New System.Drawing.Size(166, 23)
        Me.txtSaldoCordoba.TabIndex = 31
        '
        'txtLimite
        '
        Me.txtLimite.BackColor = System.Drawing.Color.Black
        '
        '
        '
        Me.txtLimite.BackgroundStyle.BackColor = System.Drawing.Color.Black
        Me.txtLimite.BackgroundStyle.BorderColor = System.Drawing.Color.Yellow
        Me.txtLimite.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtLimite.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLimite.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtLimite.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimite.ForeColor = System.Drawing.Color.Yellow
        Me.txtLimite.Increment = 1.0R
        Me.txtLimite.IsInputReadOnly = True
        Me.txtLimite.Location = New System.Drawing.Point(128, 86)
        Me.txtLimite.MinValue = 0.0R
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(166, 23)
        Me.txtLimite.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Vencido en Córdoba:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Disponible:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Saldo en Córdoba:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Límite del Crédito:"
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
        'frmEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 326)
        Me.Controls.Add(Me.ElGroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información de Crédito"
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.txtVencidoDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVencidoCordoba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoCordoba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLimite As DevComponents.Editors.DoubleInput
    Friend WithEvents txtVencidoCordoba As DevComponents.Editors.DoubleInput
    Friend WithEvents txtDisponible As DevComponents.Editors.DoubleInput
    Friend WithEvents txtSaldoCordoba As DevComponents.Editors.DoubleInput
    Friend WithEvents txtSaldoDolar As DevComponents.Editors.DoubleInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPlazo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtVencidoDolar As DevComponents.Editors.DoubleInput
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
