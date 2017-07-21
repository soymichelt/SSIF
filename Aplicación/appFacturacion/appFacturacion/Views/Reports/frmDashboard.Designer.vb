<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim XyDiagram2 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series5 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView4 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim Series6 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView5 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim Series7 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView6 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim ChartTitle3 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim SimpleDiagram3D2 As DevExpress.XtraCharts.SimpleDiagram3D = New DevExpress.XtraCharts.SimpleDiagram3D()
        Dim Series8 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim Pie3DSeriesView2 As DevExpress.XtraCharts.Pie3DSeriesView = New DevExpress.XtraCharts.Pie3DSeriesView()
        Dim ChartTitle4 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.chartVentasMensuales = New DevExpress.XtraCharts.ChartControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.chartVentasMensuales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SimpleDiagram3D2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Pie3DSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.BackColor2 = System.Drawing.Color.White
        Me.GroupControl1.Appearance.BorderColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.Options.UseBackColor = True
        Me.GroupControl1.Appearance.Options.UseBorderColor = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.GroupControl1.Size = New System.Drawing.Size(859, 67)
        Me.GroupControl1.TabIndex = 8
        Me.GroupControl1.Text = "Dashboard de Ventas (Filtros del gráfico)"
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SplitterControl1.Location = New System.Drawing.Point(569, 67)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(5, 455)
        Me.SplitterControl1.TabIndex = 10
        Me.SplitterControl1.TabStop = False
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(574, 67)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Padding = New System.Windows.Forms.Padding(15, 18, 15, 18)
        Me.PanelControl2.Size = New System.Drawing.Size(285, 455)
        Me.PanelControl2.TabIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.chartVentasMensuales)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 67)
        Me.PanelControl1.MinimumSize = New System.Drawing.Size(400, 400)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Padding = New System.Windows.Forms.Padding(15, 18, 15, 18)
        Me.PanelControl1.Size = New System.Drawing.Size(569, 455)
        Me.PanelControl1.TabIndex = 11
        '
        'chartVentasMensuales
        '
        Me.chartVentasMensuales.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.DataBindings = Nothing
        XyDiagram2.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram2.AxisY.VisibleInPanesSerializable = "-1"
        Me.chartVentasMensuales.Diagram = XyDiagram2
        Me.chartVentasMensuales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartVentasMensuales.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.chartVentasMensuales.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.chartVentasMensuales.Legend.Border.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.chartVentasMensuales.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.Legend.Name = "Default Legend"
        Me.chartVentasMensuales.Legend.Title.Text = "Series del Gráfico"
        Me.chartVentasMensuales.Legend.Title.Visible = True
        Me.chartVentasMensuales.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.Location = New System.Drawing.Point(15, 18)
        Me.chartVentasMensuales.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chartVentasMensuales.Name = "chartVentasMensuales"
        Series5.Name = "Totales del Año"
        LineSeriesView4.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        LineSeriesView4.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(219, Byte), Integer))
        LineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series5.View = LineSeriesView4
        Series6.Name = "Hombres"
        LineSeriesView5.Color = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(89, Byte), Integer))
        LineSeriesView5.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(221, Byte), Integer))
        LineSeriesView5.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series6.View = LineSeriesView5
        Series7.Name = "Empresa"
        LineSeriesView6.Color = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        LineSeriesView6.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(240, Byte), Integer))
        LineSeriesView6.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series7.View = LineSeriesView6
        Me.chartVentasMensuales.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series5, Series6, Series7}
        Me.chartVentasMensuales.Size = New System.Drawing.Size(539, 419)
        Me.chartVentasMensuales.TabIndex = 0
        ChartTitle3.Text = "Ventas Mensuales"
        Me.chartVentasMensuales.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle3})
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.ChartControl1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(15, 18)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(255, 419)
        Me.PanelControl3.TabIndex = 12
        '
        'ChartControl1
        '
        Me.ChartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChartControl1.DataBindings = Nothing
        SimpleDiagram3D2.RotationMatrixSerializable = "1;0;0;0;0;0.5;-0.866025403784439;0;0;0.866025403784439;0.5;0;0;0;0;1"
        Me.ChartControl1.Diagram = SimpleDiagram3D2
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.ChartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.ChartControl1.Legend.Border.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.ChartControl1.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Legend.Title.Text = "Series del Gráfico"
        Me.ChartControl1.Legend.Title.Visible = True
        Me.ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChartControl1.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.ChartControl1.Name = "ChartControl1"
        Series8.Name = "Series 1"
        Series8.View = Pie3DSeriesView2
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series8}
        Me.ChartControl1.Size = New System.Drawing.Size(255, 419)
        Me.ChartControl1.TabIndex = 0
        ChartTitle4.Text = "Empleados Destacados"
        Me.ChartControl1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle4})
        '
        'frmDashboard
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 522)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.SplitterControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartVentasMensuales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(SimpleDiagram3D2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Pie3DSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chartVentasMensuales As DevExpress.XtraCharts.ChartControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
End Class
