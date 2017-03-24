<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegister))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtClaveEncriptada = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btRegistrar = New DevComponents.DotNetBar.ButtonX()
        Me.bkEstilo = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.lblVence = New System.Windows.Forms.Label()
        Me.st = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "KEY DE REGISTRO:"
        '
        'txtClave
        '
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClave.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(158, 15)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtClave.Size = New System.Drawing.Size(128, 23)
        Me.txtClave.TabIndex = 1
        '
        'txtClaveEncriptada
        '
        Me.txtClaveEncriptada.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtClaveEncriptada.Border.Class = "TextBoxBorder"
        Me.txtClaveEncriptada.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClaveEncriptada.Font = New System.Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveEncriptada.ForeColor = System.Drawing.Color.Black
        Me.txtClaveEncriptada.Location = New System.Drawing.Point(15, 44)
        Me.txtClaveEncriptada.Multiline = True
        Me.txtClaveEncriptada.Name = "txtClaveEncriptada"
        Me.txtClaveEncriptada.ReadOnly = True
        Me.txtClaveEncriptada.Size = New System.Drawing.Size(299, 86)
        Me.txtClaveEncriptada.TabIndex = 3
        '
        'btRegistrar
        '
        Me.btRegistrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btRegistrar.BackColor = System.Drawing.Color.Transparent
        Me.btRegistrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btRegistrar.Image = Global.appFacturacion.My.Resources.Resources.Key
        Me.btRegistrar.Location = New System.Drawing.Point(285, 15)
        Me.btRegistrar.Name = "btRegistrar"
        Me.btRegistrar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btRegistrar.Size = New System.Drawing.Size(29, 23)
        Me.btRegistrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btRegistrar.TabIndex = 2
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
        'lblVence
        '
        Me.lblVence.AutoSize = True
        Me.lblVence.BackColor = System.Drawing.Color.Transparent
        Me.lblVence.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVence.ForeColor = System.Drawing.Color.White
        Me.lblVence.Location = New System.Drawing.Point(67, 140)
        Me.lblVence.Name = "lblVence"
        Me.lblVence.Size = New System.Drawing.Size(190, 24)
        Me.lblVence.TabIndex = 4
        Me.lblVence.Text = "VENCE: 30/09/2016"
        '
        'st
        '
        Me.st.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black
        '
        'frmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 174)
        Me.Controls.Add(Me.lblVence)
        Me.Controls.Add(Me.txtClaveEncriptada)
        Me.Controls.Add(Me.btRegistrar)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Sistema"
        CType(Me.bkEstilo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btRegistrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtClaveEncriptada As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents bkEstilo As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents lblVence As System.Windows.Forms.Label
    Friend WithEvents st As DevComponents.DotNetBar.StyleManager
End Class
