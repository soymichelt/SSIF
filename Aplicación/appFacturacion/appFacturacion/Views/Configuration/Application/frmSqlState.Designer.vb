<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSqlState
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSqlState))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btIniciar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.picState = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.stSQL = New System.ServiceProcess.ServiceController()
        Me.btActualizar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        CType(Me.btIniciar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btActualizar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estado de la Base de Datos:"
        '
        'btIniciar
        '
        Me.btIniciar.BorderStyle.EdgeRadius = 23
        Me.btIniciar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btIniciar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btIniciar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btIniciar.ForegroundImageStyle.Image = Global.appFacturacion.My.Resources.Resources.Iniciar
        Me.btIniciar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btIniciar.Location = New System.Drawing.Point(6, 27)
        Me.btIniciar.Name = "btIniciar"
        Me.btIniciar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlack
        Me.btIniciar.Size = New System.Drawing.Size(113, 30)
        Me.btIniciar.TabIndex = 1
        Me.btIniciar.TextStyle.Text = "Iniciar Servicio"
        Me.btIniciar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picState
        '
        Me.picState.BackColor = System.Drawing.Color.White
        Me.picState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picState.Image = Global.appFacturacion.My.Resources.Resources.stIniciado
        Me.picState.Location = New System.Drawing.Point(258, 9)
        Me.picState.Name = "picState"
        Me.picState.Size = New System.Drawing.Size(48, 48)
        Me.picState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picState.TabIndex = 2
        Me.picState.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(170, 9)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(49, 14)
        Me.lblEstado.TabIndex = 3
        Me.lblEstado.Text = "Iniciado"
        '
        'btActualizar
        '
        Me.btActualizar.BorderStyle.EdgeRadius = 23
        Me.btActualizar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btActualizar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btActualizar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btActualizar.ForegroundImageStyle.Image = Global.appFacturacion.My.Resources.Resources.ActualizarService
        Me.btActualizar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btActualizar.Location = New System.Drawing.Point(129, 27)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver
        Me.btActualizar.Size = New System.Drawing.Size(113, 30)
        Me.btActualizar.TabIndex = 1
        Me.btActualizar.TextStyle.Text = "Recargar Lista"
        Me.btActualizar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSqlState
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(312, 64)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.picState)
        Me.Controls.Add(Me.btActualizar)
        Me.Controls.Add(Me.btIniciar)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSqlState"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de la Base de Datos"
        CType(Me.btIniciar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btActualizar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btIniciar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents picState As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents stSQL As System.ServiceProcess.ServiceController
    Friend WithEvents btActualizar As Klik.Windows.Forms.v1.EntryLib.ELButton
End Class
