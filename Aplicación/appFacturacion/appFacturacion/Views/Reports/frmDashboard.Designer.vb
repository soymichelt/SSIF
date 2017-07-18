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
        Dim XyDiagram23 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series67 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView67 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim Series68 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView68 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim Series69 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView69 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim ChartTitle23 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Me.chartVentasMensuales = New DevExpress.XtraCharts.ChartControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        CType(Me.chartVentasMensuales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chartVentasMensuales
        '
        Me.chartVentasMensuales.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.DataBindings = Nothing
        XyDiagram23.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram23.AxisY.VisibleInPanesSerializable = "-1"
        Me.chartVentasMensuales.Diagram = XyDiagram23
        Me.chartVentasMensuales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartVentasMensuales.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.chartVentasMensuales.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.chartVentasMensuales.Legend.Border.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.chartVentasMensuales.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.Legend.Name = "Default Legend"
        Me.chartVentasMensuales.Legend.Title.Text = "Series del Gráfico"
        Me.chartVentasMensuales.Legend.Title.Visible = True
        Me.chartVentasMensuales.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.Location = New System.Drawing.Point(15, 95)
        Me.chartVentasMensuales.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chartVentasMensuales.Name = "chartVentasMensuales"
        Series67.Name = "Totales del Año"
        LineSeriesView67.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        LineSeriesView67.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(219, Byte), Integer))
        LineSeriesView67.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series67.View = LineSeriesView67
        Series68.Name = "Hombres"
        LineSeriesView68.Color = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(89, Byte), Integer))
        LineSeriesView68.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(221, Byte), Integer))
        LineSeriesView68.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series68.View = LineSeriesView68
        Series69.Name = "Empresa"
        LineSeriesView69.Color = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        LineSeriesView69.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(240, Byte), Integer))
        LineSeriesView69.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series69.View = LineSeriesView69
        Me.chartVentasMensuales.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series67, Series68, Series69}
        Me.chartVentasMensuales.Size = New System.Drawing.Size(545, 530)
        Me.chartVentasMensuales.TabIndex = 0
        ChartTitle23.Text = "Ventas Mensuales"
        Me.chartVentasMensuales.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle23})
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
        Me.GroupControl1.Location = New System.Drawing.Point(15, 18)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.GroupControl1.Size = New System.Drawing.Size(545, 77)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Ventas Mensuales (Filtros del gráfico)"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.chartVentasMensuales)
        Me.PanelControl1.Controls.Add(Me.GroupControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Padding = New System.Windows.Forms.Padding(15, 18, 15, 18)
        Me.PanelControl1.Size = New System.Drawing.Size(575, 643)
        Me.PanelControl1.TabIndex = 3
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Location = New System.Drawing.Point(575, 0)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(5, 643)
        Me.SplitterControl1.TabIndex = 4
        Me.SplitterControl1.TabStop = False
        '
        'frmDashboard
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 643)
        Me.Controls.Add(Me.SplitterControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        CType(XyDiagram23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartVentasMensuales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chartVentasMensuales As DevExpress.XtraCharts.ChartControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
End Class
