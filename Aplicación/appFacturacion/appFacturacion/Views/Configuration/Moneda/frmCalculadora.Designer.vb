<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculadora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalculadora))
        Me.calculadora = New Klik.Windows.Forms.v1.EntryLib.ELCalculator()
        CType(Me.calculadora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'calculadora
        '
        Me.calculadora.ButtonOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.calculadora.ButtonTexts = New String() {"Round", "Back", "CE", "C", "MC", "MR", "MS", "M+", "÷", "X", "-", "+", "%", "1/ x", "=", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+/-", ".", "Ok", "Cancel"}
        Me.calculadora.ContainerStyle.BackgroundStyle.GradientAngle = 45.0!
        Me.calculadora.ContainerStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.calculadora.ContainerStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.calculadora.DecimalSeparator = "."
        Me.calculadora.Dock = System.Windows.Forms.DockStyle.Fill
        Me.calculadora.Expanded = True
        Me.calculadora.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calculadora.FooterStyle.BackgroundStyle.GradientAngle = 0.0!
        Me.calculadora.FooterStyle.FlashStyle.GradientAngle = 0.0!
        Me.calculadora.FooterStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.calculadora.FooterStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.calculadora.FooterStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.calculadora.FooterStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.calculadora.FooterStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.calculadora.HeaderStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.calculadora.HeaderStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.calculadora.HeaderStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.calculadora.HeaderStyle.Height = 24
        Me.calculadora.HeaderStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack
        Me.calculadora.HeaderStyle.TextStyle.ForeColor = System.Drawing.Color.White
        Me.calculadora.Location = New System.Drawing.Point(0, 0)
        Me.calculadora.Name = "calculadora"
        Me.calculadora.Size = New System.Drawing.Size(275, 273)
        Me.calculadora.TabIndex = 0
        Me.calculadora.ThousandSeparator = "3"
        '
        'frmCalculadora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 273)
        Me.Controls.Add(Me.calculadora)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalculadora"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculadora del Sistema"
        CType(Me.calculadora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents calculadora As Klik.Windows.Forms.v1.EntryLib.ELCalculator
End Class
