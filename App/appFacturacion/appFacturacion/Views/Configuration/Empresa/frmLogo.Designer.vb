<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogo
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btExaminar = New System.Windows.Forms.Button()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.opAbrir = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 200)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btExaminar
        '
        Me.btExaminar.Location = New System.Drawing.Point(12, 215)
        Me.btExaminar.Name = "btExaminar"
        Me.btExaminar.Size = New System.Drawing.Size(27, 23)
        Me.btExaminar.TabIndex = 1
        Me.btExaminar.Text = "..."
        Me.btExaminar.UseVisualStyleBackColor = True
        '
        'btGuardar
        '
        Me.btGuardar.Enabled = False
        Me.btGuardar.Location = New System.Drawing.Point(45, 215)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btGuardar.TabIndex = 2
        Me.btGuardar.Text = "Guardar"
        Me.btGuardar.UseVisualStyleBackColor = True
        '
        'opAbrir
        '
        Me.opAbrir.Filter = "Seleccionar Imagen | *.jpg;*.jpeg;*.png;*.bmp;*.gif"
        '
        'frmLogo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 241)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.btExaminar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmLogo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Establecer Logo"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btExaminar As System.Windows.Forms.Button
    Friend WithEvents btGuardar As System.Windows.Forms.Button
    Friend WithEvents opAbrir As System.Windows.Forms.OpenFileDialog
End Class
