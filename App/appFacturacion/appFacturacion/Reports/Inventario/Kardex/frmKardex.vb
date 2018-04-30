Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Public Class frmKardex

    Dim producto As String = ""
    Dim FormLoad As Boolean = False
    Sub List(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, Optional ByVal transaccion As String = "", Optional ByVal sucursal As String = "", Optional ByVal producto As String = "")
        Try
            Using db As New CodeFirst
                Dim p As Producto
                If Not producto.Trim = "" Then
                    p = db.Productos.Where(Function(f) f.IDALTERNO = Me.producto).FirstOrDefault
                End If
                If p Is Nothing Then
                    If dtRegistro.Visible Then
                        Dim consulta = From kar In db.Kardexs Join ser In db.Series On kar.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On kar.IDEXISTENCIA Equals exi.IDEXISTENCIA Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA
                            Where kar.ACTIVO = "S" And kar.FECHADOCUMENTO >= fecha1 And kar.FECHADOCUMENTO <= fecha2 And kar.OPERACION.Contains(transaccion) And bod.IDBODEGA.Contains(sucursal)
                            Order By kar.FECHADOCUMENTO, kar.N
                            Select BODEGA = bod.N_BODEGA & " - " & bod.DESCRIPCION, SERIE = ser.NOMBRE, kar.N_DOCUMENTO, kar.FECHADOCUMENTO, OPERACION = (If(kar.OPERACION = "VENTA CREDITO", "V/Cr.", If(kar.OPERACION = "VENTA CONTADO", "V/Co.", If(kar.OPERACION = "VENTA", "Vent.", If(kar.OPERACION = "COMPRA CREDITO", "C/Cre.", If(kar.OPERACION = "COMPRA CONTADO", "C/Co.", If(kar.OPERACION = "COMPRA", "Comp.", If(kar.OPERACION = "ENTRADA", "Ent.", If(kar.OPERACION = "SALIDA", "Sal.", If(kar.OPERACION = "TRASLADO", "Tras.", If(kar.OPERACION = "DEVOLUCION VENTA", "D/Vent.", If(kar.OPERACION = "DEVOLUCION COMPRA", "D/Comp.", kar.OPERACION)))))))))))),
                            kar.DESCRIPCION, kar.ENTRADA, kar.SALIDA, EXISTENCIA = kar.EXISTENCIA_ALMACEN, CMONEDA = If(kar.CMONEDA.Equals(Config.cordoba), "C$", "$"), kar.COSTO, kar.TAZACAMBIO, kar.COSTO_PROMEDIO, MONEDA = If(kar.MONEDA.Equals(Config.cordoba), "C$", If(kar.MONEDA.Equals(Config.dolar), "$", "")), PRECIO = If(kar.MONEDA.Equals(Config.cordoba), kar.PRECIO_C, If(kar.MONEDA.Equals(Config.dolar), kar.PRECIO_D, 0.0)), kar.DEBER, kar.HABER, kar.SALDO
                        dtRegistro.DataSource = consulta.ToList
                        If dtRegistro.Columns.Count > 0 Then
                            dtRegistro.Columns(0).HeaderText = vbNewLine & "BODEGA" & vbNewLine : dtRegistro.Columns(0).Width = 180
                            dtRegistro.Columns(2).HeaderText = "Nº DOCUMENTO" : dtRegistro.Columns(2).Width = 120
                            dtRegistro.Columns(3).HeaderText = "FECHA" : dtRegistro.Columns(3).DefaultCellStyle.Format = Config.dateFormat
                            dtRegistro.Columns(5).HeaderText = "DESCRIPCIÓN" : dtRegistro.Columns(5).Width = 250
                            dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(9).HeaderText = "M / C" : dtRegistro.Columns(9).Width = 60
                            dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(12).HeaderText = "COSTO / P."
                            dtRegistro.Columns(13).HeaderText = "M / P" : dtRegistro.Columns(13).Width = 60
                            dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(14).HeaderText = "PRECIO NETO" ' : dtRegistro.Columns(13).Visible = False
                            dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(17).DefaultCellStyle.Format = Config.f_m
                            For Each c As DataGridViewColumn In dtRegistro.Columns
                                c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                            Next
                        End If
                        consulta = Nothing
                        txtIdAlterno.Clear()
                    Else
                        'Select bod.IDBODEGA, BODEGA = bod.N_BODEGA & " - " & bod.DESCRIPCION, SERIE = ser.NOMBRE, kar.N_DOCUMENTO, kar.FECHADOCUMENTO, OPERACION = (If(kar.OPERACION = "VENTA CREDITO", "V/Cr.", If(kar.OPERACION = "VENTA CONTADO", "V/Co.", If(kar.OPERACION = "VENTA", "Vent.", If(kar.OPERACION = "COMPRA CREDITO", "C/Cre.", If(kar.OPERACION = "COMPRA CONTADO", "C/Co.", If(kar.OPERACION = "COMPRA", "Comp.", If(kar.OPERACION = "ENTRADA", "Ent.", If(kar.OPERACION = "SALIDA", "Sal.", If(kar.OPERACION = "TRASLADO", "Tras.", If(kar.OPERACION = "DEVOLUCION VENTA", "D/Vent.", If(kar.OPERACION = "DEVOLUCION COMPRA", "D/Comp.", If(kar.OPERACION = "CONSIGNACION", "Consig.", If(kar.OPERACION = "DESCONSIGNACION", "Desconsig.", "")))))))))))))),
                        Dim consulta = From kar In db.Kardexs Join ser In db.Series On kar.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On kar.IDEXISTENCIA Equals exi.IDEXISTENCIA Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA
                            Where kar.ACTIVO = "S" And kar.FECHADOCUMENTO >= fecha1 And kar.FECHADOCUMENTO <= fecha2 And kar.OPERACION.Contains(transaccion) And bod.IDBODEGA.Contains(sucursal)
                            Order By kar.FECHADOCUMENTO, kar.N
                            Select bod.IDBODEGA, BODEGA = bod.N_BODEGA & " - " & bod.DESCRIPCION, SERIE = ser.NOMBRE, kar.N_DOCUMENTO, kar.FECHADOCUMENTO, OPERACION = (If(kar.OPERACION = "VENTA CREDITO", "V/Cr.", If(kar.OPERACION = "VENTA CONTADO", "V/Co.", If(kar.OPERACION = "VENTA", "Vent.", If(kar.OPERACION = "COMPRA CREDITO", "C/Cre.", If(kar.OPERACION = "COMPRA CONTADO", "C/Co.", If(kar.OPERACION = "COMPRA", "Comp.", If(kar.OPERACION = "ENTRADA", "Ent.", If(kar.OPERACION = "SALIDA", "Sal.", If(kar.OPERACION = "TRASLADO", "Tras.", If(kar.OPERACION = "DEVOLUCION VENTA", "D/Vent.", If(kar.OPERACION = "DEVOLUCION COMPRA", "D/Comp.", kar.OPERACION)))))))))))),
                            kar.DESCRIPCION, kar.ENTRADA, kar.SALIDA, EXISTENCIA = kar.EXISTENCIA_ALMACEN, kar.CMONEDA, kar.COSTO, kar.COSTO_PROMEDIO, kar.PRECIO_C, kar.DEBER, kar.HABER, kar.SALDO
                        Dim rpt As New rptKardex
                        Config.CrystalTitle("KARDEX DE INVENTARIO", rpt)
                        Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                        band = rpt.Section2.ReportObjects("txtMonedaInventario") : band.Text = "INVENTARIO VALORADO EN: " & If(Config.currentBusiness.MonedaInventario.Equals(Config.cordoba), "CÓRDOBA", "DÓLAR")
                        band = rpt.Section2.ReportObjects("txtFecha1") : band.Text = fecha1.ToLongDateString()
                        band = rpt.Section2.ReportObjects("txtFecha2") : band.Text = fecha2.ToLongDateString()
                        band = rpt.Section2.ReportObjects("txtProducto") : band.Text = "ARTICULO: " & txtIdAlterno.Text.Trim()
                        If sucursal <> "" Then
                            band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = sucursal
                        Else
                            band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = "%Todos%"
                        End If
                        If transaccion <> "" Then
                            band = rpt.Section2.ReportObjects("txtTransaccion") : band.Text = transaccion
                        Else
                            band = rpt.Section2.ReportObjects("txtTransaccion") : band.Text = "%Todos%"
                        End If
                        rpt.SetDataSource(consulta.ToList)
                        CrystalReportViewer1.ReportSource = rpt
                        CrystalReportViewer1.Zoom(75)
                        rpt = Nothing : band = Nothing : consulta = Nothing
                    End If
                Else
                    lblArticulo.Text = "ARTICULO: <font color='#C0504D'>" & p.IDALTERNO & " - " & p.DESCRIPCION & "</font>"
                    If dtRegistro.Visible Then
                        Dim consulta = From kar In db.Kardexs Join ser In db.Series On kar.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On kar.IDEXISTENCIA Equals exi.IDEXISTENCIA Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA
                            Where kar.ACTIVO = "S" And exi.Producto.IDALTERNO = producto And kar.FECHADOCUMENTO >= fecha1 And kar.FECHADOCUMENTO <= fecha2 And kar.OPERACION.Contains(transaccion) And bod.IDBODEGA.Contains(sucursal)
                            Order By kar.FECHADOCUMENTO, kar.N
                            Select BODEGA = bod.N_BODEGA & " - " & bod.DESCRIPCION, SERIE = ser.NOMBRE, kar.N_DOCUMENTO, kar.FECHADOCUMENTO, OPERACION = (If(kar.OPERACION = "VENTA CREDITO", "V/Cr.", If(kar.OPERACION = "VENTA CONTADO", "V/Co.", If(kar.OPERACION = "VENTA", "Vent.", If(kar.OPERACION = "COMPRA CREDITO", "C/Cre.", If(kar.OPERACION = "COMPRA CONTADO", "C/Co.", If(kar.OPERACION = "COMPRA", "Comp.", If(kar.OPERACION = "ENTRADA", "Ent.", If(kar.OPERACION = "SALIDA", "Sal.", If(kar.OPERACION = "TRASLADO", "Tras.", If(kar.OPERACION = "DEVOLUCION VENTA", "D/Vent.", If(kar.OPERACION = "DEVOLUCION COMPRA", "D/Comp.", kar.OPERACION)))))))))))),
                            kar.DESCRIPCION, kar.ENTRADA, kar.SALIDA, EXISTENCIA = kar.EXISTENCIA_ALMACEN, CMONEDA = If(kar.CMONEDA.Equals(Config.cordoba), "C$", "$"), kar.COSTO, kar.TAZACAMBIO, kar.COSTO_PROMEDIO, MONEDA = If(kar.MONEDA.Equals(Config.cordoba), "C$", If(kar.MONEDA.Equals(Config.dolar), "$", "")), PRECIO = If(kar.MONEDA.Equals(Config.cordoba), kar.PRECIO_C, If(kar.MONEDA.Equals(Config.dolar), kar.PRECIO_D, 0.0)), kar.DEBER, kar.HABER, kar.SALDO
                        dtRegistro.DataSource = consulta.ToList
                        If dtRegistro.Columns.Count > 0 Then
                            dtRegistro.Columns(0).HeaderText = vbNewLine & "BODEGA" & vbNewLine : dtRegistro.Columns(0).Width = 180
                            dtRegistro.Columns(2).HeaderText = "Nº DOCUMENTO" : dtRegistro.Columns(2).Width = 120
                            dtRegistro.Columns(3).HeaderText = "FECHA" : dtRegistro.Columns(3).DefaultCellStyle.Format = Config.dateFormat
                            dtRegistro.Columns(5).HeaderText = "DESCRIPCIÓN" : dtRegistro.Columns(5).Width = 250
                            dtRegistro.Columns(6).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(7).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(9).HeaderText = "M / C" : dtRegistro.Columns(9).Width = 60
                            dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(12).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(12).HeaderText = "COSTO / P."
                            dtRegistro.Columns(13).HeaderText = "M / P" : dtRegistro.Columns(13).Width = 60
                            dtRegistro.Columns(14).DefaultCellStyle.Format = Config.f_m : dtRegistro.Columns(14).HeaderText = "PRECIO NETO" ' : dtRegistro.Columns(13).Visible = False
                            dtRegistro.Columns(15).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m
                            dtRegistro.Columns(17).DefaultCellStyle.Format = Config.f_m
                            For Each c As DataGridViewColumn In dtRegistro.Columns
                                c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                            Next
                        End If
                        consulta = Nothing
                        txtIdAlterno.Clear()
                    Else
                        'Select bod.IDBODEGA, BODEGA = bod.N_BODEGA & " - " & bod.DESCRIPCION, SERIE = ser.NOMBRE, kar.N_DOCUMENTO, kar.FECHADOCUMENTO, OPERACION = (If(kar.OPERACION = "VENTA CREDITO", "V/Cr.", If(kar.OPERACION = "VENTA CONTADO", "V/Co.", If(kar.OPERACION = "VENTA", "Vent.", If(kar.OPERACION = "COMPRA CREDITO", "C/Cre.", If(kar.OPERACION = "COMPRA CONTADO", "C/Co.", If(kar.OPERACION = "COMPRA", "Comp.", If(kar.OPERACION = "ENTRADA", "Ent.", If(kar.OPERACION = "SALIDA", "Sal.", If(kar.OPERACION = "TRASLADO", "Tras.", If(kar.OPERACION = "DEVOLUCION VENTA", "D/Vent.", If(kar.OPERACION = "DEVOLUCION COMPRA", "D/Comp.", If(kar.OPERACION = "CONSIGNACION", "Consig.", If(kar.OPERACION = "DESCONSIGNACION", "Desconsig.", "")))))))))))))),
                        Dim consulta = From kar In db.Kardexs Join ser In db.Series On kar.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On kar.IDEXISTENCIA Equals exi.IDEXISTENCIA Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where kar.ACTIVO = "S" And exi.Producto.IDALTERNO = producto And kar.FECHADOCUMENTO >= fecha1 And kar.FECHADOCUMENTO <= fecha2 And kar.OPERACION.Contains(transaccion) And bod.IDBODEGA.Contains(sucursal) Order By kar.FECHADOCUMENTO, kar.N
                        Select bod.IDBODEGA, BODEGA = bod.N_BODEGA & " - " & bod.DESCRIPCION, SERIE = ser.NOMBRE, kar.N_DOCUMENTO, kar.FECHADOCUMENTO, OPERACION = (If(kar.OPERACION = "VENTA CREDITO", "V/Cr.", If(kar.OPERACION = "VENTA CONTADO", "V/Co.", If(kar.OPERACION = "VENTA", "Vent.", If(kar.OPERACION = "COMPRA CREDITO", "C/Cre.", If(kar.OPERACION = "COMPRA CONTADO", "C/Co.", If(kar.OPERACION = "COMPRA", "Comp.", If(kar.OPERACION = "ENTRADA", "Ent.", If(kar.OPERACION = "SALIDA", "Sal.", If(kar.OPERACION = "TRASLADO", "Tras.", If(kar.OPERACION = "DEVOLUCION VENTA", "D/Vent.", If(kar.OPERACION = "DEVOLUCION COMPRA", "D/Comp.", kar.OPERACION)))))))))))),
                        kar.DESCRIPCION, kar.ENTRADA, kar.SALIDA, EXISTENCIA = kar.EXISTENCIA_ALMACEN, kar.CMONEDA, kar.COSTO, kar.COSTO_PROMEDIO, kar.PRECIO_C, kar.DEBER, kar.HABER, kar.SALDO
                        Dim rpt As New rptKardex
                        Config.CrystalTitle("KARDEX DE INVENTARIO", rpt)
                        Dim band As CrystalDecisions.CrystalReports.Engine.TextObject
                        band = rpt.Section2.ReportObjects("txtMonedaInventario") : band.Text = "INVENTARIO VALORADO EN: " & If(Config.currentBusiness.MonedaInventario.Equals(Config.cordoba), "CÓRDOBA", "DÓLAR")
                        band = rpt.Section2.ReportObjects("txtFecha1") : band.Text = fecha1.ToLongDateString()
                        band = rpt.Section2.ReportObjects("txtFecha2") : band.Text = fecha2.ToLongDateString()
                        band = rpt.Section2.ReportObjects("txtProducto") : band.Text = "ARTICULO: " & txtIdAlterno.Text.Trim()
                        If sucursal <> "" Then
                            band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = sucursal
                        Else
                            band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = "%Todos%"
                        End If
                        If transaccion <> "" Then
                            band = rpt.Section2.ReportObjects("txtTransaccion") : band.Text = transaccion
                        Else
                            band = rpt.Section2.ReportObjects("txtTransaccion") : band.Text = "%Todos%"
                        End If
                        rpt.SetDataSource(consulta.ToList)
                        CrystalReportViewer1.ReportSource = rpt
                        CrystalReportViewer1.Zoom(75)
                        rpt = Nothing : band = Nothing : consulta = Nothing
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lblNombreEmpresa.Text = Config.businessName & vbNewLine & "TARJETA AUXILIAR DE ALMACÉN"
            dtpFecha1.Value = DateTime.Now
            dtpFecha2.Value = DateTime.Now
            cmbOperacion.SelectedIndex = 0
            Using db As New CodeFirst
                cmbBodega.DataSource = (From bod In db.Bodegas Select bod.IDBODEGA, BODEGA = bod.N_BODEGA & " - " & bod.DESCRIPCION).ToList() : cmbBodega.DisplayMember = "BODEGA" : cmbBodega.ValueMember = "IDBODEGA" : cmbBodega.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        Me.FormLoad = True
    End Sub

    Private Sub txtIdAlterno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdAlterno.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtIdAlterno.Text.Trim <> "" Then
                Me.producto = txtIdAlterno.Text.Trim()
                If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                    If cmbOperacion.SelectedItem Is Nothing Then
                        List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", cmbBodega.SelectedValue.ToString(), Me.producto)
                    Else
                        List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, cmbBodega.SelectedValue.ToString(), Me.producto)
                    End If
                Else
                    If cmbOperacion.SelectedItem Is Nothing Then
                        List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
                    Else
                        List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, "", Me.producto)
                    End If
                End If
            Else
                MessageBox.Show("Ingresar ID Alterno de un Producto.")
            End If
        End If
    End Sub

    Private Sub dtpFecha2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha2.ValueChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", cmbBodega.SelectedValue.ToString(), Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, cmbBodega.SelectedValue.ToString(), Me.producto)
                End If
            Else
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, "", Me.producto)
                End If
            End If
        End If
    End Sub

    Private Sub dtpFecha1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha1.ValueChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", cmbBodega.SelectedValue.ToString(), Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, cmbBodega.SelectedValue.ToString(), Me.producto)
                End If
            Else
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, "", Me.producto)
                End If
            End If
        End If
    End Sub

    Private Sub cmbOperacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperacion.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", cmbBodega.SelectedValue.ToString(), Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, cmbBodega.SelectedValue.ToString(), Me.producto)
                End If
            Else
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, "", Me.producto)
                End If
            End If
        End If
    End Sub

    Private Sub cmbBodega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.FormLoad Then
            If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", cmbBodega.SelectedValue.ToString(), Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, cmbBodega.SelectedValue.ToString(), Me.producto)
                End If
            Else
                If cmbOperacion.SelectedItem Is Nothing Then
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
                Else
                    List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, "", Me.producto)
                End If
            End If
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        CrystalReportViewer1.Visible = False
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If cmbOperacion.SelectedItem Is Nothing Then
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", cmbBodega.SelectedValue.ToString(), Me.producto)
            Else
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, cmbBodega.SelectedValue.ToString(), Me.producto)
            End If
        Else
            If cmbOperacion.SelectedItem Is Nothing Then
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
            Else
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, "", Me.producto)
            End If
        End If
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        Me.producto = ""
        dtpFecha1.Value = DateTime.Now
        dtpFecha2.Value = DateTime.Now
        cmbBodega.SelectedIndex = -1
        cmbOperacion.SelectedIndex = 0
        List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
    End Sub

    Private Sub btBuscarCliente_Click(sender As Object, e As EventArgs) Handles btBuscarCliente.Click
        frmBuscarProductos.frm_return = 6
        frmBuscarProductos.ShowDialog()
        txtIdAlterno.Focus()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        CrystalReportViewer1.Visible = True
        If Not cmbBodega.SelectedValue Is Nothing And Not cmbBodega.SelectedIndex = -1 Then
            If cmbOperacion.SelectedItem Is Nothing Then
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", cmbBodega.SelectedValue.ToString(), Me.producto)
            Else
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, cmbBodega.SelectedValue.ToString(), Me.producto)
            End If
        Else
            If cmbOperacion.SelectedItem Is Nothing Then
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", "", "", Me.producto)
            Else
                List(dtpFecha1.Value.ToShortDateString & " 00:00:00", dtpFecha2.Value.ToShortDateString & " 23:59:59", cmbOperacion.SelectedItem.ToString, "", Me.producto)
            End If
        End If
    End Sub

    Private Sub frmKardex_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If Me.FormLoad Then
            cmbBodega_TextChanged(Nothing, Nothing)
        End If
    End Sub
End Class