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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView1 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView2 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim Series3 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView3 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Me.chartVentasMensuales = New DevExpress.XtraCharts.ChartControl()
        CType(Me.chartVentasMensuales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chartVentasMensuales
        '
        Me.chartVentasMensuales.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.DataBindings = Nothing
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.chartVentasMensuales.Diagram = XyDiagram1
        Me.chartVentasMensuales.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.chartVentasMensuales.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.chartVentasMensuales.Legend.Border.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.chartVentasMensuales.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
        Me.chartVentasMensuales.Legend.Name = "Default Legend"
        Me.chartVentasMensuales.Legend.Title.Text = "Información del Gráfico"
        Me.chartVentasMensuales.Legend.Title.Visible = True
        Me.chartVentasMensuales.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.chartVentasMensuales.Location = New System.Drawing.Point(-32, 119)
        Me.chartVentasMensuales.Name = "chartVentasMensuales"
        Series1.Name = "Totales del Año"
        LineSeriesView1.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer))
        LineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(219, Byte), Integer))
        LineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.View = LineSeriesView1
        Series2.Name = "Hombres"
        LineSeriesView2.Color = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(89, Byte), Integer))
        LineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(221, Byte), Integer))
        LineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series2.View = LineSeriesView2
        Series3.Name = "Empresa"
        LineSeriesView3.Color = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        LineSeriesView3.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(240, Byte), Integer))
        LineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series3.View = LineSeriesView3
        Me.chartVentasMensuales.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2, Series3}
        Me.chartVentasMensuales.Size = New System.Drawing.Size(525, 358)
        Me.chartVentasMensuales.TabIndex = 0
        ChartTitle1.Text = "Ventas Mensuales"
        Me.chartVentasMensuales.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 554)
        Me.Controls.Add(Me.chartVentasMensuales)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartVentasMensuales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chartVentasMensuales As DevExpress.XtraCharts.ChartControl
End Class
