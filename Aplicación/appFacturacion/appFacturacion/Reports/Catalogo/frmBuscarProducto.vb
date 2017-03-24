Public Class frmBuscarProductos
    Public frm_return As Integer = 0
    Dim FormLoad As Boolean = False
    Sub llenar(Optional ByVal pNombre As String = "", Optional ByVal pIDOriginal As String = "", Optional ByVal pAplicacion As String = "", Optional ByVal pIDAlterno As String = "", Optional ByVal pMarca As String = "", Optional ByVal pNombreComercial As String = "", Optional ByVal pLaboratorio As String = "", Optional ByVal pDistribuidor As String = "", Optional ByVal pForma As String = "", Optional ByVal pUbicacion As String = "", Optional ByVal pExportar As Boolean = False)
        Try
            Using db As New CodeFirst
                'Dim consulta = From prod In db.PRODUCTOS Join exi In db.EXISTENCIAS On prod.IDPRODUCTO Equals exi.IDPRODUCTO Join mar In db.MARCAS On prod.IDMARCA Equals mar.IDMARCA Join lab In db.LABORATORIOS On lab.IDLABORATORIO Equals prod.IDLABORATORIO Join pre In db.PRESENTACIONES On pre.IDPRESENTACION Equals prod.IDPRESENTACION Where prod.ACTIVO = "S" And exi.IDBODEGA = Config.bodega And prod.DESCRIPCION.Contains(pNombre) And prod.IDORIGINAL.Contains(pIDOriginal) And prod.APLICACION.Contains(pAplicacion) And prod.IDALTERNO.Contains(pIDAlterno) And mar.DESCRIPCION.Contains(pMarca) And prod.MODELO.Contains(pNombreComercial) And lab.DESCRIPCION.Contains(pLaboratorio) And pre.DESCRIPCION.Contains(pForma) And prod.UBICACIONFISICA.Contains(pUbicacion) Select prod, exi, mar, lab, pre, PRVN = If(prod.PROVEEDOR IsNot Nothing, prod.PROVEEDOR.NOMBRES & " " & prod.PROVEEDOR.APELLIDOS, Config.TextNull), PRVR = If(prod.PROVEEDOR IsNot Nothing, " // " & prod.PROVEEDOR.RAZONSOCIAL, "") Where (PRVN & PRVR).Contains(pDistribuidor) Select prod.IDALTERNO, prod.IDORIGINAL, PRODUCTO = prod.DESCRIPCION, prod.MODELO, EXIS = exi.CANTIDAD, MARCA = If(mar.ACTIVO.Equals(Config.vTrue), mar.DESCRIPCION, Config.TextNull), APLIC = prod.APLICACION, MONEDA = If(prod.CMONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), PRECIO1 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO1 / 100), prod.PRECIO1), PRECIO2 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO2 / 100), prod.PRECIO2), PRECIO3 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO3 / 100), prod.PRECIO3), PRECIO4 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO4 / 100), prod.PRECIO4), prod.IDPRODUCTO, PRESENTACIÓN = If(prod.PRESENTACION.ACTIVO.Equals(Config.vTrue), prod.PRESENTACION.DESCRIPCION, Config.TextNull), LABORATORIO = If(prod.LABORATORIO.ACTIVO.Equals(Config.vTrue), prod.LABORATORIO.DESCRIPCION, Config.TextNull), UNIDAD_DE_MEDIDA = If(prod.UNIDAD_DE_MEDIDA.ACTIVO.Equals(Config.vTrue), prod.UNIDAD_DE_MEDIDA.DESCRIPCION, Config.TextNull), prod.CONTIENE, prod.CANTIDAD_MINIMA, prod.CANTIDAD_MAXIMA, PROVEEDOR = PRVN & PRVR, prod.UBICACIONFISICA
                Dim consulta = From prod In db.PRODUCTOS Join exi In db.EXISTENCIAS On prod.IDPRODUCTO Equals exi.IDPRODUCTO Join mar In db.MARCAS On prod.IDMARCA Equals mar.IDMARCA Join lab In db.LABORATORIOS On lab.IDLABORATORIO Equals prod.IDLABORATORIO Join pre In db.PRESENTACIONES On pre.IDPRESENTACION Equals prod.IDPRESENTACION Where prod.ACTIVO = "S" And exi.IDBODEGA = Config.bodega And prod.DESCRIPCION.Contains(pNombre) And prod.IDORIGINAL.Contains(pIDOriginal) And prod.APLICACION.Contains(pAplicacion) And prod.IDALTERNO.Contains(pIDAlterno) And mar.DESCRIPCION.Contains(pMarca) And prod.MODELO.Contains(pNombreComercial) And lab.DESCRIPCION.Contains(pLaboratorio) And pre.DESCRIPCION.Contains(pForma) And prod.UBICACIONFISICA.Contains(pUbicacion) Select prod, exi, mar, lab, pre, PRVN = If(prod.PROVEEDOR IsNot Nothing, prod.PROVEEDOR.NOMBRES & " " & prod.PROVEEDOR.APELLIDOS, Config.TextNull), PRVR = If(prod.PROVEEDOR IsNot Nothing, " // " & prod.PROVEEDOR.RAZONSOCIAL, "") Where (PRVN & PRVR).Contains(pDistribuidor) Select prod.IDALTERNO, prod.IDORIGINAL, PRODUCTO = prod.DESCRIPCION, prod.MODELO, EXIS = exi.CANTIDAD, MARCA = If(mar.ACTIVO.Equals(Config.vTrue), mar.DESCRIPCION, Config.TextNull), APLIC = prod.APLICACION, prod.UBICACIONFISICA, PRECIO1 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO1 / 100), prod.PRECIO1), PRECIO2 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO2 / 100), prod.PRECIO2), PRECIO3 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO3 / 100), prod.PRECIO3), PRECIO4 = If(prod.MARGEN, prod.COSTO + (prod.COSTO * prod.PRECIO4 / 100), prod.PRECIO4), prod.IDPRODUCTO, PRESENTACIÓN = If(prod.PRESENTACION.ACTIVO.Equals(Config.vTrue), prod.PRESENTACION.DESCRIPCION, Config.TextNull), LABORATORIO = If(prod.LABORATORIO.ACTIVO.Equals(Config.vTrue), prod.LABORATORIO.DESCRIPCION, Config.TextNull), UNIDAD_DE_MEDIDA = If(prod.UNIDAD_DE_MEDIDA.ACTIVO.Equals(Config.vTrue), prod.UNIDAD_DE_MEDIDA.DESCRIPCION, Config.TextNull), prod.CONTIENE, prod.CANTIDAD_MINIMA, prod.CANTIDAD_MAXIMA, PROVEEDOR = PRVN & PRVR, MONEDA = If(prod.CMONEDA.Equals(Config.cordoba), "Córdoba", "Dólar"), prod.COSTO
                If rdMinDebajo.Checked Then
                    consulta = consulta.Where(Function(f) f.EXIS < f.CANTIDAD_MINIMA)
                ElseIf rdMinEncima.Checked Then
                    consulta = consulta.Where(Function(f) f.EXIS > f.CANTIDAD_MINIMA)
                End If

                If rdMaxDebajo.Checked Then
                    consulta = consulta.Where(Function(f) f.EXIS < f.CANTIDAD_MAXIMA)
                ElseIf rdMaxEncima.Checked Then
                    consulta = consulta.Where(Function(f) f.EXIS > f.CANTIDAD_MAXIMA)
                End If

                If rdExiNegativo.Checked Then
                    consulta = consulta.Where(Function(f) f.EXIS < 0)
                ElseIf rdExiPositivo.Checked Then
                    consulta = consulta.Where(Function(f) f.EXIS > 0)
                End If

                If (pExportar) Then
                    'Crear reporte
                    Dim rpt As New rptExportarBusqueda

                    'listar parametros
                    Dim oText As CrystalDecisions.CrystalReports.Engine.TextObject
                    oText = rpt.Section2.ReportObjects("txtIDAlterno")
                    oText.Text = pIDAlterno
                    oText = rpt.Section2.ReportObjects("txtIDOriginal")
                    oText.Text = pIDOriginal
                    oText = rpt.Section2.ReportObjects("txtNombre")
                    oText.Text = pNombre
                    oText = rpt.Section2.ReportObjects("txtModelo")
                    oText.Text = pNombreComercial
                    oText = rpt.Section2.ReportObjects("txtEmpresa")
                    oText.Text = pLaboratorio
                    oText = rpt.Section2.ReportObjects("txtDimencion")
                    oText.Text = pUbicacion
                    oText = rpt.Section2.ReportObjects("txtProveedor")
                    oText.Text = pDistribuidor
                    oText = rpt.Section2.ReportObjects("txtPresentacion")
                    oText.Text = pForma

                    oText = rpt.Section2.ReportObjects("txtMinimo")
                    oText.Text = If(rdMinDebajo.Checked, "Por Debajo", If(rdMinEncima.Checked, "Por Encima", "Todos"))
                    oText = rpt.Section2.ReportObjects("txtMaximo")
                    oText.Text = If(rdMaxDebajo.Checked, "Por Debajo", If(rdMaxEncima.Checked, "Por Encima", "Todos"))
                    oText = rpt.Section2.ReportObjects("txtExistencia")
                    oText.Text = If(rdExiNegativo.Checked, "Negativo", If(rdExiPositivo.Checked, "Positivo", "Todos"))


                    'enlazar datos
                    rpt.SetDataSource((From v In consulta Select v.IDALTERNO, v.IDORIGINAL, NOMBRE = v.PRODUCTO, v.MARCA, MINIMO = v.CANTIDAD_MINIMA, MAXIMO = v.CANTIDAD_MAXIMA, EXISTENCIA = v.EXIS, v.COSTO).ToList)
                    CrystalReportViewer1.ReportSource = rpt
                    CrystalReportViewer1.Visible = True
                    'Salir
                    Exit Sub
                Else
                    CrystalReportViewer1.Visible = False
                End If

                dtRegistro.DataSource = consulta.ToList
                If dtRegistro.Columns.Count > 0 Then
                    dtRegistro.Columns(0).HeaderText = vbNewLine & "ID Alterno" & vbNewLine : dtRegistro.Columns(0).Width = 150
                    dtRegistro.Columns(1).HeaderText = "ID Original" : dtRegistro.Columns(1).Width = 150
                    dtRegistro.Columns(2).HeaderText = "NOMBRE" : dtRegistro.Columns(2).Width = 280
                    dtRegistro.Columns(3).HeaderText = "MODELO" : dtRegistro.Columns(3).Width = 70
                    dtRegistro.Columns(4).HeaderText = "EXIS" : dtRegistro.Columns(4).Width = 45
                    dtRegistro.Columns(5).HeaderText = "MARCA" : dtRegistro.Columns(5).Width = 120
                    dtRegistro.Columns(6).HeaderText = "APLICACIÓN" : dtRegistro.Columns(6).Width = 280
                    dtRegistro.Columns(7).Width = 150 : dtRegistro.Columns(7).HeaderText = "DIMENCION"

                    dtRegistro.Columns(8).Width = 70 : dtRegistro.Columns(8).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(9).Width = 70 : dtRegistro.Columns(9).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(10).Width = 70 : dtRegistro.Columns(10).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(11).Width = 70 : dtRegistro.Columns(11).DefaultCellStyle.Format = Config.f_m

                    dtRegistro.Columns(12).Visible = False

                    dtRegistro.Columns(13).HeaderText = "PRESENTACIÓN" : dtRegistro.Columns(13).Width = 150
                    dtRegistro.Columns(14).HeaderText = "EMPRESA" : dtRegistro.Columns(14).Width = 150
                    dtRegistro.Columns(15).HeaderText = "U / M" : dtRegistro.Columns(15).Width = 100
                    dtRegistro.Columns(16).HeaderText = "CONTIENE" : dtRegistro.Columns(16).Width = 60 : dtRegistro.Columns(16).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(17).HeaderText = "CANT. MIN." : dtRegistro.Columns(17).Width = 45 : dtRegistro.Columns(17).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(18).HeaderText = "CANT. MAX." : dtRegistro.Columns(18).Width = 45 : dtRegistro.Columns(18).DefaultCellStyle.Format = Config.f_m
                    dtRegistro.Columns(19).Width = 150 : dtRegistro.Columns(19).HeaderText = "PROVEEDOR"
                    dtRegistro.Columns(20).HeaderText = "MONEDA" : dtRegistro.Columns(20).Width = 70
                    dtRegistro.Columns(21).Visible = False
                    For Each c As DataGridViewColumn In dtRegistro.Columns
                        c.DefaultCellStyle.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Regular)
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        lblContador.Text = "Nº ITEM: " & dtRegistro.RowCount.ToString("##0")
    End Sub

    Sub llenarExistencia(ByVal idproducto As String)
        Try
            Using db As New CodeFirst
                dtExistencia.DataSource = (From exi In db.EXISTENCIAS Join bod In db.BODEGAS On exi.IDBODEGA Equals bod.IDBODEGA Where exi.IDPRODUCTO = idproducto Select bod.N_BODEGA, BODEGA = bod.DESCRIPCION, EXISTENCIA = exi.CANTIDAD, exi.CONSIGNADO).ToList
                dtExistencia.Columns(1).Width = 200 : dtExistencia.Columns(2).Width = 100 : dtExistencia.Columns(3).Width = 100
                dtExistencia.Columns(2).DefaultCellStyle.Format = Config.f_m : dtExistencia.Columns(3).DefaultCellStyle.Format = Config.f_m
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
        Me.FormLoad = True
    End Sub

    Private Sub txtIdAlterno_TextChanged(sender As Object, e As EventArgs) Handles txtIdAlterno.TextChanged, txtNombre.TextChanged, txtIdOriginal.TextChanged, txtAplicacion.TextChanged, txtMarca.TextChanged, txtNombreComercial.TextChanged, txtLaboratorio.TextChanged, txtForma.TextChanged, txtDistribuidor.TextChanged, txtUbicacion.TextChanged
        llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
    End Sub

    Private Sub frmBuscarProducto_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'txtMarca.Width = Me.Width - txtMarca.Left - 20
        'txtUbicacion.Width = Me.Width - txtUbicacion.Left - 20
    End Sub

    Private Sub dtRegistro_SelectionChanged(sender As Object, e As EventArgs) Handles dtRegistro.SelectionChanged
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                llenarExistencia(dtRegistro.SelectedRows(0).Cells(12).Value.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                Using db As New CodeFirst
                    Dim ID = dtRegistro.SelectedRows(0).Cells(12).Value.ToString
                    Dim p = db.PRODUCTOS.Where(Function(f) f.ACTIVO = "S" And f.IDPRODUCTO = ID).FirstOrDefault()
                    If Not p Is Nothing Then
                        Select Case frm_return
                            Case 0
                                frmProducto.txtCodigo.Text = p.IDPRODUCTO
                                frmProducto.txtAlterno.Text = p.IDALTERNO
                                frmProducto.txtOriginal.Text = p.IDORIGINAL
                                frmProducto.txtDescripcion.Text = p.DESCRIPCION
                                If p.MARCA.ACTIVO = "S" Then
                                    frmProducto.cmbMarca.Text = p.MARCA.DESCRIPCION
                                Else
                                    frmProducto.cmbMarca.Text = ""
                                End If
                                If p.UNIDAD_DE_MEDIDA.ACTIVO = "S" Then
                                    frmProducto.cmbUnidaddemedida.Text = p.UNIDAD_DE_MEDIDA.DESCRIPCION
                                Else
                                    frmProducto.cmbUnidaddemedida.Text = ""
                                End If
                                If p.PRESENTACION.ACTIVO = "S" Then
                                    frmProducto.cmbPresentacion.Text = p.PRESENTACION.DESCRIPCION
                                Else
                                    frmProducto.cmbPresentacion.Text = ""
                                End If
                                If p.LABORATORIO.ACTIVO = "S" Then
                                    frmProducto.cmbLaboratorio.Text = p.LABORATORIO.DESCRIPCION
                                Else
                                    frmProducto.cmbLaboratorio.Text = ""
                                End If
                                frmProducto.txtModelo.Text = p.MODELO
                                frmProducto.txtAplicacion.Text = p.APLICACION
                                frmProducto.txtObservacion.Text = p.OBSERVACION
                                frmProducto.txtCosto.Text = p.COSTO
                                frmProducto.chkMargen.Checked = p.MARGEN
                                frmProducto.txtPrecio1.Text = p.PRECIO1
                                frmProducto.txtPrecio2.Text = p.PRECIO2
                                frmProducto.txtPrecio3.Text = p.PRECIO3
                                frmProducto.txtPrecio4.Text = p.PRECIO4
                                frmProducto.txtContiene.Value = p.CONTIENE
                                frmProducto.txtCantidadMinima.Value = p.CANTIDAD_MINIMA
                                frmProducto.txtCantidadMaxima.Value = p.CANTIDAD_MAXIMA

                                If Not p.IDPROVEEDOR Is Nothing Then
                                    frmProducto.txtIdProveedor.Text = p.IDPROVEEDOR
                                    frmProducto.txtProveedor.Text = p.PROVEEDOR.N_PROVEEDOR & " | " & p.PROVEEDOR.NOMBRES & " " & p.PROVEEDOR.APELLIDOS & If(p.PROVEEDOR.RAZONSOCIAL.Trim <> "", " // " & p.PROVEEDOR.RAZONSOCIAL, "")
                                Else
                                    frmProducto.txtIdProveedor.Clear()
                                    frmProducto.txtProveedor.Clear()
                                End If
                                Select Case p.FACTURAR_PRECIO
                                    Case 1
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 0
                                    Case 2
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 1
                                    Case 3
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 2
                                    Case 4
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 3
                                    Case 5
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 4
                                End Select
                                If p.IVA Then
                                    frmProducto.rdConIVA.Checked = True
                                Else
                                    frmProducto.rdSinIVA.Checked = True
                                End If
                                If p.FACTURAR_NEGATIVO Then
                                    frmProducto.rdSinExistencia.Checked = True
                                Else
                                    frmProducto.rdConExistencia.Checked = True
                                End If

                                If Not p.IMAGENAME Is Nothing Then
                                    If Not p.IMAGENAME.Trim() = "" Then
                                        If System.IO.File.Exists(Config.DirectoryPathImageProducts & p.IMAGENAME & Config.ImageExtension) Then
                                            frmProducto.cargarImagen(p.IMAGENAME, 1)
                                        Else
                                            frmProducto.txtImagen.Clear()
                                            frmProducto.pnImagen.Style.BackgroundImage = Nothing
                                        End If
                                    Else
                                        frmProducto.txtImagen.Clear()
                                        frmProducto.pnImagen.Style.BackgroundImage = Nothing
                                    End If
                                Else
                                    frmProducto.txtImagen.Clear()
                                    frmProducto.pnImagen.Style.BackgroundImage = Nothing
                                End If

                                frmProducto.btGuardar.Enabled = False
                                frmProducto.btEditar.Enabled = True
                                frmProducto.btEliminar.Enabled = True

                                frmProducto.txtOriginal.Focus()

                                'mostrar formulario luego de cargar datos
                                frmProducto.MdiParent = frmPrincipal
                                frmProducto.BringToFront()
                                frmProducto.Show()
                            Case 1
                                frmVenta.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 2
                                frmEntrada.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 3
                                frmSalida.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 4
                                frmTraslado.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 5
                                frmCotizacion.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 6
                                frmKardex.txtIdAlterno.Text = p.IDALTERNO
                                frmKardex.BringToFront()
                            Case 7
                                frmConsignacion.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 8
                                frmDesconsignacion.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 10
                                frmProducto.txtCodigo.Text = p.IDPRODUCTO
                                frmProducto.txtAlterno.Text = p.IDALTERNO
                                frmProducto.txtOriginal.Text = p.IDORIGINAL
                                frmProducto.txtDescripcion.Text = p.DESCRIPCION
                                frmProducto.txtUbicacion.Text = p.UBICACIONFISICA
                                If p.MARCA.ACTIVO = "S" Then
                                    frmProducto.cmbMarca.Text = p.MARCA.DESCRIPCION
                                Else
                                    frmProducto.cmbMarca.Text = ""
                                End If
                                If p.UNIDAD_DE_MEDIDA.ACTIVO = "S" Then
                                    frmProducto.cmbUnidaddemedida.Text = p.UNIDAD_DE_MEDIDA.DESCRIPCION
                                Else
                                    frmProducto.cmbUnidaddemedida.Text = ""
                                End If
                                If p.PRESENTACION.ACTIVO = "S" Then
                                    frmProducto.cmbPresentacion.Text = p.PRESENTACION.DESCRIPCION
                                Else
                                    frmProducto.cmbPresentacion.Text = ""
                                End If
                                If p.LABORATORIO.ACTIVO = "S" Then
                                    frmProducto.cmbLaboratorio.Text = p.LABORATORIO.DESCRIPCION
                                Else
                                    frmProducto.cmbLaboratorio.Text = ""
                                End If
                                frmProducto.txtModelo.Text = p.MODELO
                                frmProducto.txtAplicacion.Text = p.APLICACION
                                frmProducto.txtObservacion.Text = p.OBSERVACION
                                frmProducto.txtCosto.Text = p.COSTO
                                frmProducto.chkMargen.Checked = p.MARGEN
                                frmProducto.txtPrecio1.Text = p.PRECIO1
                                frmProducto.txtPrecio2.Text = p.PRECIO2
                                frmProducto.txtPrecio3.Text = p.PRECIO3
                                frmProducto.txtPrecio4.Text = p.PRECIO4
                                frmProducto.txtContiene.Value = p.CONTIENE
                                frmProducto.txtCantidadMinima.Value = p.CANTIDAD_MINIMA
                                frmProducto.txtCantidadMaxima.Value = p.CANTIDAD_MAXIMA
                                If Not p.IDPROVEEDOR Is Nothing Then
                                    frmProducto.txtIdProveedor.Text = p.IDPROVEEDOR
                                    frmProducto.txtProveedor.Text = p.PROVEEDOR.N_PROVEEDOR & " | " & p.PROVEEDOR.NOMBRES & " " & p.PROVEEDOR.APELLIDOS & If(p.PROVEEDOR.RAZONSOCIAL.Trim <> "", " // " & p.PROVEEDOR.RAZONSOCIAL, "")
                                Else
                                    frmProducto.txtIdProveedor.Clear()
                                    frmProducto.txtProveedor.Clear()
                                End If
                                Select Case p.FACTURAR_PRECIO
                                    Case 1
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 0
                                    Case 2
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 1
                                    Case 3
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 2
                                    Case 4
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 3
                                    Case 5
                                        frmProducto.cmbFacturarConPrecio.SelectedIndex = 4
                                End Select
                                If p.IVA Then
                                    frmProducto.rdConIVA.Checked = True
                                Else
                                    frmProducto.rdSinIVA.Checked = True
                                End If
                                If p.FACTURAR_NEGATIVO Then
                                    frmProducto.rdSinExistencia.Checked = True
                                Else
                                    frmProducto.rdConExistencia.Checked = True
                                End If

                                If Not p.IMAGENAME Is Nothing Then
                                    If Not p.IMAGENAME.Trim() = "" Then
                                        If System.IO.File.Exists(Config.DirectoryPathImageProducts & p.IMAGENAME & Config.ImageExtension) Then
                                            frmProducto.cargarImagen(p.IMAGENAME, 1)
                                        Else
                                            frmProducto.txtImagen.Clear()
                                            frmProducto.pnImagen.Style.BackgroundImage = Nothing
                                        End If
                                    Else
                                        frmProducto.txtImagen.Clear()
                                        frmProducto.pnImagen.Style.BackgroundImage = Nothing
                                    End If
                                Else
                                    frmProducto.txtImagen.Clear()
                                    frmProducto.pnImagen.Style.BackgroundImage = Nothing
                                End If

                                frmProducto.btGuardar.Enabled = False
                                frmProducto.btEditar.Enabled = True
                                frmProducto.btEliminar.Enabled = True

                                frmProducto.txtOriginal.Focus()
                            Case 11
                                frmNotaDevolucion.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 12
                                frmInformeConsignacionProducto.txtAlterno.Text = p.IDALTERNO
                            Case 13
                                frmInformeConsignacionProducto.txtOriginal.Text = p.IDORIGINAL
                            Case 14
                                frmInformeConsignacionProducto.txtDescripcion.Text = p.DESCRIPCION
                            Case 15
                                frmCompra.txtCodigoAlterno.Text = p.IDALTERNO
                            Case 16
                                frmNotaDevolucionCompra.txtCodigoAlterno.Text = p.IDALTERNO
                        End Select
                        Me.Close()
                    Else
                        MessageBox.Show("Error, No se encuentra este producto. Probablemente alla sido eliminado")
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarProducto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Me.Dispose()
    End Sub

    Private Sub dtRegistro_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtRegistro.CellFormatting
        'Try
        '    If dtRegistro.Columns(e.ColumnIndex).Name = "EXIS" Then
        '        If Decimal.Parse(e.Value) < Decimal.Parse(dtRegistro.Rows(e.RowIndex).Cells(16).Value) Then
        '            dtRegistro.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        '        End If
        '        If Decimal.Parse(e.Value) > Decimal.Parse(dtRegistro.Rows(e.RowIndex).Cells(17).Value) Then
        '            dtRegistro.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Yellow
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("error, " & ex.Message)
        'End Try
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            dtRegistro_CellDoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub rdMinTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdMinTodos.CheckedChanged
        If Me.FormLoad Then
            If rdMinTodos.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdMinDebajo_CheckedChanged(sender As Object, e As EventArgs) Handles rdMinDebajo.CheckedChanged
        If Me.FormLoad Then
            If rdMinDebajo.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdMinEncima_CheckedChanged(sender As Object, e As EventArgs) Handles rdMinEncima.CheckedChanged
        If Me.FormLoad Then
            If rdMinEncima.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdMaxTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdMaxTodos.CheckedChanged
        If Me.FormLoad Then
            If rdMaxTodos.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdMaxDebajo_CheckedChanged(sender As Object, e As EventArgs) Handles rdMaxDebajo.CheckedChanged
        If Me.FormLoad Then
            If rdMaxDebajo.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdMaxEncima_CheckedChanged(sender As Object, e As EventArgs) Handles rdMaxEncima.CheckedChanged
        If Me.FormLoad Then
            If rdMaxEncima.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdExiTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdExiTodos.CheckedChanged
        If Me.formload Then
            If rdExiTodos.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdExiNegativo_CheckedChanged(sender As Object, e As EventArgs) Handles rdExiNegativo.CheckedChanged
        If Me.FormLoad Then
            If rdExiNegativo.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub rdExiPositivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdExiPositivo.CheckedChanged
        If Me.FormLoad Then
            If rdExiPositivo.Checked Then
                llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim)
            End If
        End If
    End Sub

    Private Sub btExportar_Click(sender As Object, e As EventArgs) Handles btExportar.Click
        llenar(txtNombre.Text.Trim, txtIdOriginal.Text.Trim, txtAplicacion.Text.Trim, txtIdAlterno.Text.Trim, txtMarca.Text.Trim, txtNombreComercial.Text.Trim, txtLaboratorio.Text.Trim, txtDistribuidor.Text.Trim, txtForma.Text.Trim, txtUbicacion.Text.Trim, True)
    End Sub

End Class