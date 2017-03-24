<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSIF
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
        Me.SideBar1 = New DevComponents.DotNetBar.SideBar()
        Me.SideBarPanelItem1 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.SideBarPanelItem2 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.SideBarPanelItem3 = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.CheckBoxItem1 = New DevComponents.DotNetBar.CheckBoxItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.SuspendLayout()
        '
        'SideBar1
        '
        Me.SideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.SideBar1.Appearance = DevComponents.DotNetBar.eSideBarAppearance.Flat
        Me.SideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None
        Me.SideBar1.ColorScheme.ItemCheckedBackground = System.Drawing.Color.Empty
        Me.SideBar1.ColorScheme.ItemCheckedBackground2 = System.Drawing.Color.Empty
        Me.SideBar1.ColorScheme.ItemCheckedBorder = System.Drawing.Color.Black
        Me.SideBar1.ColorScheme.ItemCheckedText = System.Drawing.Color.White
        Me.SideBar1.ColorScheme.ItemExpandedBackground = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.SideBar1.ColorScheme.ItemExpandedBackground2 = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SideBar1.ColorScheme.ItemExpandedText = System.Drawing.Color.White
        Me.SideBar1.ColorScheme.ItemHotBackground = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SideBar1.ColorScheme.ItemHotBackground2 = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.SideBar1.ColorScheme.ItemHotBorder = System.Drawing.Color.Black
        Me.SideBar1.ColorScheme.ItemHotText = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBar1.ColorScheme.ItemPressedBackground = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.SideBar1.ColorScheme.ItemPressedBackground2 = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SideBar1.ColorScheme.ItemPressedBorder = System.Drawing.Color.Black
        Me.SideBar1.ColorScheme.ItemPressedText = System.Drawing.Color.White
        Me.SideBar1.ColorScheme.ItemText = System.Drawing.Color.White
        Me.SideBar1.ColorScheme.MenuBackground = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SideBar1.ColorScheme.MenuBackground2 = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBar1.ColorScheme.MenuBorder = System.Drawing.Color.Black
        Me.SideBar1.ColorScheme.MenuSide = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.SideBar1.ColorScheme.MenuSide2 = System.Drawing.Color.Empty
        Me.SideBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SideBar1.ExpandedPanel = Me.SideBarPanelItem3
        Me.SideBar1.Location = New System.Drawing.Point(0, 0)
        Me.SideBar1.Name = "SideBar1"
        Me.SideBar1.Panels.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SideBarPanelItem1, Me.SideBarPanelItem2, Me.SideBarPanelItem3})
        Me.SideBar1.Size = New System.Drawing.Size(180, 509)
        Me.SideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.SideBar1.TabIndex = 0
        Me.SideBar1.Text = "SideBar1"
        '
        'SideBarPanelItem1
        '
        Me.SideBarPanelItem1.BackgroundStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SideBarPanelItem1.BackgroundStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBarPanelItem1.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem1.BackgroundStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem1.BackgroundStyle.ForeColor.Color = System.Drawing.Color.White
        Me.SideBarPanelItem1.FontBold = True
        Me.SideBarPanelItem1.HeaderHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SideBarPanelItem1.HeaderHotStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBarPanelItem1.HeaderHotStyle.GradientAngle = 90
        Me.SideBarPanelItem1.HeaderSideStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SideBarPanelItem1.HeaderSideStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.SideBarPanelItem1.HeaderSideStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem1.HeaderSideStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem1.HeaderSideStyle.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Top) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SideBarPanelItem1.HeaderSideStyle.GradientAngle = 90
        Me.SideBarPanelItem1.HeaderStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.SideBarPanelItem1.HeaderStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem1.HeaderStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem1.HeaderStyle.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Right Or DevComponents.DotNetBar.eBorderSide.Top) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SideBarPanelItem1.HeaderStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SideBarPanelItem1.HeaderStyle.ForeColor.Color = System.Drawing.Color.White
        Me.SideBarPanelItem1.HeaderStyle.GradientAngle = 90
        Me.SideBarPanelItem1.Name = "SideBarPanelItem1"
        Me.SideBarPanelItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.SideBarPanelItem1.Text = "SideBarPanelItem1"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.CheckBoxItem1, Me.ButtonItem4})
        Me.ButtonItem1.Text = "New Button"
        '
        'SideBarPanelItem2
        '
        Me.SideBarPanelItem2.BackgroundStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SideBarPanelItem2.BackgroundStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBarPanelItem2.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem2.BackgroundStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem2.BackgroundStyle.ForeColor.Color = System.Drawing.Color.White
        Me.SideBarPanelItem2.FontBold = True
        Me.SideBarPanelItem2.HeaderHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SideBarPanelItem2.HeaderHotStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBarPanelItem2.HeaderHotStyle.GradientAngle = 90
        Me.SideBarPanelItem2.HeaderSideStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SideBarPanelItem2.HeaderSideStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.SideBarPanelItem2.HeaderSideStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem2.HeaderSideStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem2.HeaderSideStyle.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Top) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SideBarPanelItem2.HeaderSideStyle.GradientAngle = 90
        Me.SideBarPanelItem2.HeaderStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.SideBarPanelItem2.HeaderStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem2.HeaderStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem2.HeaderStyle.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Right Or DevComponents.DotNetBar.eBorderSide.Top) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SideBarPanelItem2.HeaderStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SideBarPanelItem2.HeaderStyle.ForeColor.Color = System.Drawing.Color.White
        Me.SideBarPanelItem2.HeaderStyle.GradientAngle = 90
        Me.SideBarPanelItem2.Name = "SideBarPanelItem2"
        Me.SideBarPanelItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2})
        Me.SideBarPanelItem2.Text = "SideBarPanelItem2"
        '
        'SideBarPanelItem3
        '
        Me.SideBarPanelItem3.BackgroundStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SideBarPanelItem3.BackgroundStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBarPanelItem3.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem3.BackgroundStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem3.BackgroundStyle.ForeColor.Color = System.Drawing.Color.White
        Me.SideBarPanelItem3.FontBold = True
        Me.SideBarPanelItem3.HeaderHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SideBarPanelItem3.HeaderHotStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SideBarPanelItem3.HeaderHotStyle.GradientAngle = 90
        Me.SideBarPanelItem3.HeaderSideStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SideBarPanelItem3.HeaderSideStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.SideBarPanelItem3.HeaderSideStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem3.HeaderSideStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem3.HeaderSideStyle.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Top) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SideBarPanelItem3.HeaderSideStyle.GradientAngle = 90
        Me.SideBarPanelItem3.HeaderStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.SideBarPanelItem3.HeaderStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SideBarPanelItem3.HeaderStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.SideBarPanelItem3.HeaderStyle.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Right Or DevComponents.DotNetBar.eBorderSide.Top) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SideBarPanelItem3.HeaderStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SideBarPanelItem3.HeaderStyle.ForeColor.Color = System.Drawing.Color.White
        Me.SideBarPanelItem3.HeaderStyle.GradientAngle = 90
        Me.SideBarPanelItem3.Name = "SideBarPanelItem3"
        Me.SideBarPanelItem3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3})
        Me.SideBarPanelItem3.Text = "SideBarPanelItem3"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "New Button"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "New Button"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "LabelItem1"
        '
        'CheckBoxItem1
        '
        Me.CheckBoxItem1.Name = "CheckBoxItem1"
        Me.CheckBoxItem1.Text = "CheckBoxItem1"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Text = "ButtonItem4"
        '
        'frmSIF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.appFacturacion.My.Resources.Resources.wallpaper_1360345_rojo
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(685, 509)
        Me.Controls.Add(Me.SideBar1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSIF"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "S.I.F."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SideBar1 As DevComponents.DotNetBar.SideBar
    Friend WithEvents SideBarPanelItem3 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SideBarPanelItem1 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SideBarPanelItem2 As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents CheckBoxItem1 As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
End Class
