<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrinterSettings
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrinterSettings))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btCancelar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.btConfigurar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.pdPrint = New System.Windows.Forms.PrintDialog()
        Me.cmbImpresoras = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btConfigurar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(460, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Configuración de Impresora - Sadara SIF 2017"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 53)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.appFacturacion.My.Resources.Resources.Linea
        Me.PictureBox1.Location = New System.Drawing.Point(0, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(482, 4)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
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
        Me.btCancelar.Location = New System.Drawing.Point(265, 210)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver
        Me.btCancelar.Size = New System.Drawing.Size(82, 31)
        Me.btCancelar.TabIndex = 24
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
        Me.btConfigurar.Location = New System.Drawing.Point(166, 210)
        Me.btConfigurar.Name = "btConfigurar"
        Me.btConfigurar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.btConfigurar.Size = New System.Drawing.Size(95, 31)
        Me.btConfigurar.TabIndex = 23
        Me.btConfigurar.TextStyle.Text = "Configurar"
        Me.btConfigurar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pdPrint
        '
        Me.pdPrint.UseEXDialog = True
        '
        'cmbImpresoras
        '
        Me.cmbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresoras.FormattingEnabled = True
        Me.cmbImpresoras.Location = New System.Drawing.Point(175, 142)
        Me.cmbImpresoras.Name = "cmbImpresoras"
        Me.cmbImpresoras.Size = New System.Drawing.Size(262, 22)
        Me.cmbImpresoras.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 14)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Nombre de la Impresora:"
        '
        'frmPrinterSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(482, 307)
        Me.Controls.Add(Me.cmbImpresoras)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.btConfigurar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPrinterSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de Impresora"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btConfigurar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btCancelar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents btConfigurar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents pdPrint As PrintDialog
    Friend WithEvents cmbImpresoras As ComboBox
    Friend WithEvents Label2 As Label
End Class
