Public Class frmProducto

    Dim FormLoad As Boolean = False

    Sub Limpiar()
        txtCodigo.Clear()
        txtAlterno.Clear()
        txtOriginal.Clear()
        cmbMarca.SelectedIndex = -1
        txtDescripcion.Clear()
        txtModelo.Clear()
        txtAplicacion.Clear()
        txtObservacion.Clear()
        txtCosto.Value = 0
        txtPrecio1.Value = 0
        txtPrecio2.Value = 0
        txtPrecio3.Value = 0
        txtPrecio4.Value = 0
        txtDescuentoMaximo.Value = 0
        txtCantidadMinima.Value = 10
        txtCantidadMaxima.Value = 100
        txtContiene.Value = 0
        cmbUnidaddemedida.SelectedIndex = -1
        cmbPresentacion.SelectedIndex = -1
        cmbLaboratorio.SelectedIndex = -1
        txtIdProveedor.Clear()
        txtProveedor.Clear()
        txtImagen.Clear()
        txtUbicacion.Clear()
        chkMargen.Checked = False
        pnImagen.Style.BackgroundImage = Nothing
        cmbFacturarConPrecio.SelectedIndex = 4
        rdSinExistencia.Checked = True
        rdConIVA.Checked = True
        btGuardar.Enabled = True
        btEliminar.Enabled = False
        btEliminar.Visible = True
        btEditar.Enabled = False
        btEditar.Visible = True
        btDarAlta.Enabled = False
        btDarAlta.Visible = False
        txtAlterno.Focus()
    End Sub

    Public Sub cargarImagen(ByVal fileName As String, Optional ByVal tipo As Integer = 0)
        txtImagen.Text = If(tipo.Equals(0), fileName, Config.DirectoryPathImageProducts & fileName & Config.ImageExtension)
        Dim fs As New System.IO.FileStream(If(tipo.Equals(0), fileName, Config.DirectoryPathImageProducts & fileName & Config.ImageExtension), IO.FileMode.Open, IO.FileAccess.Read)
        pnImagen.Style.BackgroundImage = Image.FromStream(fs)
        fs.Close()
        fs.Dispose()
    End Sub

    Private Sub frmProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Config.Empresa.MonedaInventario.Equals(Config.cordoba) Then
            rdCordoba.Checked = True
        Else
            rdDolar.Checked = True
        End If
        Try
            cmbFacturarConPrecio.SelectedIndex = 0
            Limpiar()
            Using db As New CodeFirst
                cmbMarca.DataSource = db.Marcas.Where(Function(f) f.ACTIVO = "S").ToList() : cmbMarca.DisplayMember = "DESCRIPCION" : cmbMarca.ValueMember = "IDMARCA" : cmbMarca.SelectedIndex = -1
                cmbUnidaddemedida.DataSource = db.UnidadesMedidas.Where(Function(f) f.ACTIVO = "S").ToList() : cmbUnidaddemedida.DisplayMember = "DESCRIPCION" : cmbUnidaddemedida.ValueMember = "IDUNIDAD" : cmbUnidaddemedida.SelectedIndex = -1
                cmbPresentacion.DataSource = db.Presentaciones.Where(Function(f) f.ACTIVO = "S").ToList() : cmbPresentacion.DisplayMember = "DESCRIPCION" : cmbPresentacion.ValueMember = "IDPRESENTACION" : cmbPresentacion.SelectedIndex = -1
                cmbLaboratorio.DataSource = db.Laboratorios.Where(Function(f) f.ACTIVO = "S").ToList() : cmbLaboratorio.DisplayMember = "DESCRIPCION" : cmbLaboratorio.ValueMember = "IDLABORATORIO" : cmbLaboratorio.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show("Error," & ex.Message)
        End Try
        txtAlterno.Focus()
        Me.FormLoad = True
    End Sub

    Private Sub btNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        Limpiar()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If txtAlterno.Text.Trim <> "" And txtOriginal.Text.Trim <> "" And (Not cmbMarca.SelectedValue Is Nothing And Not cmbMarca.SelectedIndex = -1) And (Not cmbUnidaddemedida.SelectedValue Is Nothing And Not cmbUnidaddemedida.SelectedIndex = -1) And (Not cmbPresentacion.SelectedValue Is Nothing And Not cmbPresentacion.SelectedIndex = -1) And (Not cmbLaboratorio.SelectedValue Is Nothing And Not cmbLaboratorio.SelectedIndex = -1) And Not txtDescripcion.Text.Trim = "" And Not txtCosto.Text = "" And Not txtPrecio1.Text = "" And Not txtPrecio2.Text = "" And Not txtPrecio3.Text = "" And Not txtPrecio4.Text = "" And Not txtContiene.Text = "" And Not txtCantidadMinima.Text = "" And Not txtCantidadMaxima.Text = "" And Not txtDescuentoMaximo.Text = "" Then
                Using db As New CodeFirst
                    If db.Productos.Where(Function(f) f.IDALTERNO = txtAlterno.Text.Trim).Count() = 0 Then
                        If txtCantidadMinima.Value > txtCantidadMaxima.Value Then
                            MessageBox.Show("La cantidad mínima no puede ser mayor que la cantidad máxima.")
                            Exit Sub
                        End If
                        If chkMargen.Checked = False Then
                            If txtCosto.Value >= txtPrecio1.Value And txtCosto.Value >= txtPrecio2.Value And txtCosto.Value >= txtPrecio3.Value And txtCosto.Value >= txtPrecio4.Value Then
                                MessageBox.Show("El precio fijo no puede ser menor que el costo.")
                                Exit Sub
                            End If
                        End If
                        If txtCosto.Value <= 0 Then
                            MessageBox.Show("El costo debe ser un número mayor que 0")
                            Exit Sub
                        End If
                        Dim producto As New Producto : producto.Reg = DateTime.Now : producto.IDPRODUCTO = Guid.NewGuid.ToString() : producto.IDALTERNO = txtAlterno.Text : producto.IDORIGINAL = txtOriginal.Text : producto.IDMARCA = cmbMarca.SelectedValue.ToString() : producto.DESCRIPCION = txtDescripcion.Text : producto.MODELO = txtModelo.Text : producto.APLICACION = txtAplicacion.Text : producto.OBSERVACION = txtObservacion.Text : producto.CMONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : producto.COSTO = Decimal.Parse(txtCosto.Text) : producto.MARGEN = chkMargen.Checked : producto.PRECIO1 = Decimal.Parse(txtPrecio1.Text) : producto.PRECIO2 = Decimal.Parse(txtPrecio2.Text) : producto.PRECIO3 = Decimal.Parse(txtPrecio3.Text) : producto.PRECIO4 = Decimal.Parse(txtPrecio4.Text) : producto.IDUNIDAD = cmbUnidaddemedida.SelectedValue.ToString() : producto.CONTIENE = Decimal.Parse(txtContiene.Text) : producto.CANTIDAD_MINIMA = Decimal.Parse(txtCantidadMinima.Text) : producto.CANTIDAD_MAXIMA = Decimal.Parse(txtCantidadMaxima.Text) : producto.DESCUENTO_MAXIMO = Decimal.Parse(txtDescuentoMaximo.Text) : producto.IDPRESENTACION = cmbPresentacion.SelectedValue.ToString() : producto.IDLABORATORIO = cmbLaboratorio.SelectedValue.ToString() : producto.UBICACIONFISICA = txtUbicacion.Text : producto.CANTIDAD = 0 : producto.SALDO = 0 : producto.FACTURAR_PRECIO = If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #1", 1, If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #2", 2, If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #3", 3, If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #4", 4, 5)))) : producto.IVA = rdConIVA.Checked : producto.FACTURAR_NEGATIVO = rdSinExistencia.Checked : If txtIdProveedor.Text.Trim <> "" Then : producto.IDPROVEEDOR = txtIdProveedor.Text : End If : producto.ACTIVO = "S"
                        For Each bodega In db.Bodegas
                            Dim existencia As New Existencia : existencia.IDEXISTENCIA = Guid.NewGuid.ToString() : existencia.CANTIDAD = 0 : existencia.CONSIGNADO = 0 : existencia.IDBODEGA = bodega.IDBODEGA : existencia.IDPRODUCTO = producto.IDPRODUCTO
                            db.Existencias.Add(existencia)
                        Next
                        Try
                            If Not txtImagen.Text.Trim() = "" Then
                                If System.IO.Directory.Exists(Config.DirectoryPathImageProducts) = False Then
                                    'System.IO.Directory.CreateDirectory(Me.pathProductos)
                                    Throw New Exception("No se encuentra el directorio de almacen para las Imágenes.")
                                End If
                                Dim path As String = Config.DirectoryPathImageProducts & producto.IDPRODUCTO & Config.ImageExtension
                                System.IO.File.Delete(path)
                                Dim bmp As New Bitmap(pnImagen.Style.BackgroundImage)
                                bmp.Save(path, pnImagen.Style.BackgroundImage.RawFormat)
                                bmp.Dispose()
                                producto.IMAGENAME = producto.IDPRODUCTO
                                path = Nothing
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar la imagen. Error, " & ex.Message)
                        End Try
                        db.Productos.Add(producto) : producto = Nothing
                        db.SaveChanges() : Limpiar() : MessageBox.Show("Producto guardado")
                    Else
                        MessageBox.Show("Error, No puede crear este producto por que el codigo alterno ya lo posee otro producto.")
                    End If
                End Using
            Else
                'MessageBox.Show("Error, Faltan datos.")
                If txtAlterno.Text.Trim = "" Then
                    Config.MsgAdv("Necesita ingresar el ID Alterno")
                    txtAlterno.Focus()
                    Exit Sub
                End If
                If cmbMarca.SelectedValue Is Nothing Or cmbMarca.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar una Marca")
                    cmbMarca.Focus()
                    Exit Sub
                End If
                If cmbUnidaddemedida.SelectedValue Is Nothing Or cmbUnidaddemedida.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar una Unidad de Medida")
                    cmbUnidaddemedida.Focus()
                    Exit Sub
                End If
                If cmbPresentacion.SelectedValue Is Nothing Or cmbPresentacion.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar una Presentación")
                    cmbPresentacion.Focus()
                    Exit Sub
                End If
                If cmbLaboratorio.SelectedValue Is Nothing Or cmbLaboratorio.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar un empresa")
                    cmbLaboratorio.Focus()
                    Exit Sub
                End If
                If txtDescripcion.Text.Trim Then
                    Config.MsgAdv("Necesita ingresar la Descripción")
                    txtDescripcion.Focus()
                    Exit Sub
                End If
                If txtCosto.Text Then
                    Config.MsgAdv("Necesita ingresar el Costo")
                    txtCosto.Focus()
                    Exit Sub
                End If
                If txtPrecio1.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #1")
                    txtPrecio1.Focus()
                    Exit Sub
                End If
                If txtPrecio2.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #2")
                    txtPrecio2.Focus()
                    Exit Sub
                End If
                If txtPrecio3.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #3")
                    txtPrecio3.Focus()
                    Exit Sub
                End If
                If txtPrecio4.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #4")
                    txtPrecio4.Focus()
                    Exit Sub
                End If
                If txtContiene.Text Then
                    Config.MsgAdv("Necesita ingresar la Cantidad por Unidades")
                    txtContiene.Focus()
                    Exit Sub
                End If
                If txtCantidadMinima.Text Then
                    Config.MsgAdv("Necesita ingresar la Cantidad Mínima")
                    txtCantidadMinima.Focus()
                    Exit Sub
                End If
                If txtCantidadMaxima.Text Then
                    Config.MsgAdv("Necesita ingresar la Cantidad Máxima")
                    txtCantidadMaxima.Focus()
                    Exit Sub
                End If
                If txtDescuentoMaximo.Text Then
                    Config.MsgAdv("Necesita ingresar el Descuento Máximo")
                    txtDescuentoMaximo.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        Try
            If txtAlterno.Text.Trim <> "" And txtOriginal.Text.Trim <> "" And (Not cmbMarca.SelectedValue Is Nothing And Not cmbMarca.SelectedIndex = -1) And (Not cmbUnidaddemedida.SelectedValue Is Nothing And Not cmbUnidaddemedida.SelectedIndex = -1) And (Not cmbPresentacion.SelectedValue Is Nothing And Not cmbPresentacion.SelectedIndex = -1) And (Not cmbLaboratorio.SelectedValue Is Nothing And Not cmbLaboratorio.SelectedIndex = -1) And Not txtDescripcion.Text.Trim = "" And Not txtCosto.Text = "" And Not txtPrecio1.Text = "" And Not txtPrecio2.Text = "" And Not txtPrecio3.Text = "" And Not txtPrecio4.Text = "" And Not txtContiene.Text = "" And Not txtCantidadMinima.Text = "" And Not txtCantidadMaxima.Text = "" And Not txtDescuentoMaximo.Text = "" Then
                Using db As New CodeFirst
                    If db.Productos.Where(Function(f) f.IDPRODUCTO <> txtCodigo.Text And f.IDALTERNO = txtAlterno.Text.Trim()).Count() = 0 Then
                        If txtCantidadMinima.Value > txtCantidadMaxima.Value Then
                            MessageBox.Show("La cantidad mínima no puede ser mayor que la cantidad máxima.")
                            Exit Sub
                        End If
                        If chkMargen.Checked = False Then
                            If txtCosto.Value >= txtPrecio1.Value And txtCosto.Value >= txtPrecio2.Value And txtCosto.Value >= txtPrecio3.Value And txtCosto.Value >= txtPrecio4.Value Then
                                MessageBox.Show("El precio fijo no puede ser menor que el costo.")
                                Exit Sub
                            End If
                        End If
                        Dim producto = db.Productos.Where(Function(f) f.IDPRODUCTO = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                        If Not producto Is Nothing Then
                            producto.IDALTERNO = txtAlterno.Text : producto.IDORIGINAL = txtOriginal.Text : producto.IDMARCA = cmbMarca.SelectedValue.ToString() : producto.DESCRIPCION = txtDescripcion.Text : producto.MODELO = txtModelo.Text : producto.APLICACION = txtAplicacion.Text : producto.OBSERVACION = txtObservacion.Text : If txtIdProveedor.Text.Trim <> "" Then : producto.IDPROVEEDOR = txtIdProveedor.Text : Else : producto.IDPROVEEDOR = Nothing : End If
                            If MessageBox.Show("¿Descartar cambios en el Costo?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                producto.CMONEDA = If(rdCordoba.Checked, Config.cordoba, Config.dolar) : producto.COSTO = txtCosto.Value : producto.SALDO = producto.CANTIDAD * producto.COSTO
                            End If
                            producto.MARGEN = chkMargen.Checked : producto.PRECIO1 = txtPrecio1.Value : producto.PRECIO2 = txtPrecio2.Value : producto.PRECIO3 = txtPrecio3.Value : producto.PRECIO4 = txtPrecio4.Value : producto.IDUNIDAD = cmbUnidaddemedida.SelectedValue.ToString() : producto.CONTIENE = txtContiene.Value : producto.CANTIDAD_MINIMA = txtCantidadMinima.Value : producto.CANTIDAD_MAXIMA = txtCantidadMaxima.Value : producto.DESCUENTO_MAXIMO = txtDescuentoMaximo.Value : producto.IDPRESENTACION = cmbPresentacion.SelectedValue.ToString() : producto.IDLABORATORIO = cmbLaboratorio.SelectedValue.ToString() : producto.UBICACIONFISICA = txtUbicacion.Text : producto.FACTURAR_PRECIO = If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #1", 1, If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #2", 2, If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #3", 3, If(cmbFacturarConPrecio.SelectedItem.ToString() = "Precio #4", 4, 5)))) : producto.IVA = rdConIVA.Checked : producto.FACTURAR_NEGATIVO = rdSinExistencia.Checked
                            db.Entry(producto).State = EntityState.Modified
                            Try
                                If Not txtImagen.Text = "" Then
                                    If System.IO.Directory.Exists(Config.DirectoryPathImageProducts) = False Then
                                        System.IO.Directory.CreateDirectory(Config.DirectoryPathImageProducts)
                                    End If
                                    If System.IO.File.Exists(txtImagen.Text) Then
                                        Dim path As String = Config.DirectoryPathImageProducts & producto.IDPRODUCTO & Config.ImageExtension
                                        System.IO.File.Delete(path)
                                        Dim bmp As New Bitmap(pnImagen.Style.BackgroundImage)
                                        bmp.Save(path, pnImagen.Style.BackgroundImage.RawFormat)
                                        bmp.Dispose()
                                        producto.IMAGENAME = producto.IDPRODUCTO
                                        path = Nothing
                                    Else
                                        MessageBox.Show("No se encuentra la imagen cargada a este producto. Probablemente se eliminó o no está accesible.")
                                    End If
                                Else
                                    producto.IMAGENAME = ""
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar la imagen. Descripción: " & ex.Message)
                            End Try
                            db.SaveChanges() : Limpiar() : MessageBox.Show("Producto modificado")
                        Else
                            MessageBox.Show("Error, No se encuentra este producto. Probablemente alla sido eliminado.")
                        End If
                    Else
                        MessageBox.Show("Error, No puede crear este producto por que el codigo alterno ya lo posee otro producto.")
                    End If
                End Using
            Else
                'MessageBox.Show("Error, Faltan datos.")
                If txtAlterno.Text.Trim = "" Then
                    Config.MsgAdv("Necesita ingresar el ID Alterno")
                    txtAlterno.Focus()
                    Exit Sub
                End If
                If cmbMarca.SelectedValue Is Nothing Or cmbMarca.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar una Marca")
                    cmbMarca.Focus()
                    Exit Sub
                End If
                If cmbUnidaddemedida.SelectedValue Is Nothing Or cmbUnidaddemedida.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar una Unidad de Medida")
                    cmbUnidaddemedida.Focus()
                    Exit Sub
                End If
                If cmbPresentacion.SelectedValue Is Nothing Or cmbPresentacion.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar una Presentación")
                    cmbPresentacion.Focus()
                    Exit Sub
                End If
                If cmbLaboratorio.SelectedValue Is Nothing Or cmbLaboratorio.SelectedIndex = -1 Then
                    Config.MsgAdv("Necesita seleccionar un Laboratorio")
                    cmbLaboratorio.Focus()
                    Exit Sub
                End If
                If txtDescripcion.Text.Trim Then
                    Config.MsgAdv("Necesita ingresar la Descripción")
                    txtDescripcion.Focus()
                    Exit Sub
                End If
                If txtCosto.Text Then
                    Config.MsgAdv("Necesita ingresar el Costo")
                    txtCosto.Focus()
                    Exit Sub
                End If
                If txtPrecio1.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #1")
                    txtPrecio1.Focus()
                    Exit Sub
                End If
                If txtPrecio2.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #2")
                    txtPrecio2.Focus()
                    Exit Sub
                End If
                If txtPrecio3.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #3")
                    txtPrecio3.Focus()
                    Exit Sub
                End If
                If txtPrecio4.Text Then
                    Config.MsgAdv("Necesita ingresar el Precio #4")
                    txtPrecio4.Focus()
                    Exit Sub
                End If
                If txtContiene.Text Then
                    Config.MsgAdv("Necesita ingresar la Cantidad por Unidades")
                    txtContiene.Focus()
                    Exit Sub
                End If
                If txtCantidadMinima.Text Then
                    Config.MsgAdv("Necesita ingresar la Cantidad Mínima")
                    txtCantidadMinima.Focus()
                    Exit Sub
                End If
                If txtCantidadMaxima.Text Then
                    Config.MsgAdv("Necesita ingresar la Cantidad Máxima")
                    txtCantidadMaxima.Focus()
                    Exit Sub
                End If
                If txtDescuentoMaximo.Text Then
                    Config.MsgAdv("Necesita ingresar el Descuento Máximo")
                    txtDescuentoMaximo.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        Try
            If MessageBox.Show("¿Desea eliminar este Producto?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Using db As New CodeFirst
                    Dim producto = db.Productos.Where(Function(f) f.IDPRODUCTO = txtCodigo.Text And f.ACTIVO = "S").FirstOrDefault()
                    If Not producto Is Nothing Then
                        producto.ACTIVO = "N"
                        db.Entry(producto).State = EntityState.Modified
                        db.SaveChanges() : Limpiar() : MessageBox.Show("Producto eliminado")
                    Else
                        MessageBox.Show("Error, No se encuentra este producto. Probablemente ha sido eliminado.")
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub txtAlterno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlterno.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtAlterno.Text.Trim = "" Then
                Try
                    Using db As New CodeFirst
                        Dim producto = db.Productos.Where(Function(f) f.IDALTERNO = txtAlterno.Text).FirstOrDefault()
                        If producto Is Nothing Then
                            txtOriginal.Focus()
                        Else
                            'LISTAR DATOS

                            txtCodigo.Text = producto.IDPRODUCTO
                            txtAlterno.Text = producto.IDALTERNO
                            txtOriginal.Text = producto.IDORIGINAL
                            If producto.Marca.ACTIVO = "S" Then
                                cmbMarca.Text = producto.Marca.DESCRIPCION
                            Else
                                cmbMarca.Text = ""
                            End If
                            txtDescripcion.Text = producto.DESCRIPCION
                            txtModelo.Text = producto.MODELO
                            txtAplicacion.Text = producto.APLICACION
                            txtObservacion.Text = producto.OBSERVACION
                            txtCosto.Text = producto.COSTO.ToString(Config.f_m)
                            chkMargen.Checked = producto.MARGEN
                            txtPrecio1.Text = producto.PRECIO1.ToString(Config.f_m)
                            txtPrecio2.Text = producto.PRECIO2.ToString(Config.f_m)
                            txtPrecio3.Text = producto.PRECIO3.ToString(Config.f_m)
                            txtPrecio4.Text = producto.PRECIO4.ToString(Config.f_m)
                            If producto.UnidadMedida.ACTIVO = "S" Then
                                cmbUnidaddemedida.Text = producto.UnidadMedida.DESCRIPCION
                            Else
                                cmbUnidaddemedida.Text = ""
                            End If
                            txtContiene.Value = producto.CONTIENE
                            If producto.Presentacion.ACTIVO = "S" Then
                                cmbPresentacion.Text = producto.Presentacion.DESCRIPCION
                            Else
                                cmbPresentacion.Text = ""
                            End If
                            If producto.Laboratorio.ACTIVO = "S" Then
                                cmbLaboratorio.Text = producto.Laboratorio.DESCRIPCION
                            Else
                                cmbLaboratorio.Text = ""
                            End If
                            If Not producto.IDPROVEEDOR Is Nothing Then
                                txtIdProveedor.Text = producto.IDPROVEEDOR
                                txtProveedor.Text = producto.Proveedor.N_PROVEEDOR & " | " & producto.Proveedor.NOMBRES & " " & producto.Proveedor.APELLIDOS & If(producto.Proveedor.RAZONSOCIAL.Trim <> "", " // " & producto.Proveedor.RAZONSOCIAL, "")
                            Else
                                txtIdProveedor.Clear()
                                txtProveedor.Clear()
                            End If
                            txtCantidadMinima.Value = producto.CANTIDAD_MINIMA
                            txtCantidadMaxima.Value = producto.CANTIDAD_MAXIMA
                            txtDescuentoMaximo.Value = producto.DESCUENTO_MAXIMO
                            txtUbicacion.Text = producto.UBICACIONFISICA
                            Select Case producto.FACTURAR_PRECIO
                                Case 1
                                    cmbFacturarConPrecio.SelectedIndex = 0
                                Case 2
                                    cmbFacturarConPrecio.SelectedIndex = 1
                                Case 3
                                    cmbFacturarConPrecio.SelectedIndex = 2
                                Case 4
                                    cmbFacturarConPrecio.SelectedIndex = 3
                                Case 5
                                    cmbFacturarConPrecio.SelectedIndex = 4
                            End Select
                            If producto.IVA Then
                                rdConIVA.Checked = True
                            Else
                                rdSinIVA.Checked = True
                            End If
                            If producto.FACTURAR_NEGATIVO Then
                                rdSinExistencia.Checked = True
                            Else
                                rdConExistencia.Checked = True
                            End If

                            If Not producto.IMAGENAME Is Nothing Then
                                If producto.IMAGENAME.Trim() <> "" Then
                                    If System.IO.File.Exists(Config.DirectoryPathImageProducts & producto.IMAGENAME & Config.ImageExtension) Then
                                        Me.cargarImagen(producto.IMAGENAME, 1)
                                    End If
                                End If
                            End If
                            btGuardar.Enabled = False
                            If producto.ACTIVO.Equals(Config.vTrue) Then
                                btEditar.Enabled = True
                                btEliminar.Enabled = True
                                btEliminar.Visible = True
                                btDarAlta.Visible = False
                                btDarAlta.Enabled = False
                            Else
                                btEditar.Visible = False
                                btEditar.Enabled = False
                                btEliminar.Visible = False
                                btEliminar.Enabled = False
                                btDarAlta.Visible = True
                                btDarAlta.Enabled = True
                            End If
                            txtOriginal.Focus()
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error, " & ex.Message)
                End Try
            Else
                MessageBox.Show("Error, Debe de ingresar el codigo alterno del producto.")
            End If
        End If
    End Sub

    Private Sub txtOriginal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOriginal.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtOriginal.Text.Trim = "" Then
                cmbMarca.Focus()
            Else
                MessageBox.Show("Error, Debe de ingresar el codigo original del producto.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtAlterno.Focus()
        End If
    End Sub

    Private Sub cmbMarca_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMarca.KeyDown
        If e.KeyData = Keys.Enter Then
            If cmbMarca.Text.Trim <> "" Then
                If Not cmbMarca.SelectedValue Is Nothing And Not cmbMarca.SelectedIndex = -1 Then
                    txtDescripcion.Focus()
                Else
                    Try
                        Using db As New CodeFirst
                            If db.Marcas.Where(Function(f) f.DESCRIPCION = cmbMarca.Text.Trim).Count() > 0 Then
                                btActualizarMarca_Click(Nothing, Nothing)
                            Else
                                If MessageBox.Show("No se encuentra esta marca ¿Desea crearlo?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    Dim marca As New Marca : marca.IDMARCA = Guid.NewGuid.ToString : marca.DESCRIPCION = cmbMarca.Text : marca.ACTIVO = "S" : db.Marcas.Add(marca) : db.SaveChanges() : marca = Nothing
                                    btActualizarMarca_Click(Nothing, Nothing)
                                    txtDescripcion.Focus()
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error, " & ex.Message)
                    End Try
                End If
            Else
                MessageBox.Show("Error, Debe de ingresar la marca del producto.")
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtOriginal.Focus()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtDescripcion.Text.Trim = "" Then
                txtModelo.Focus()
            Else
                MessageBox.Show("Error, Debe de ingresar la descripción del producto.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            cmbMarca.Focus()
        End If
    End Sub

    Private Sub txtModelo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtModelo.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtUbicacion.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtAplicacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAplicacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCodigo.Text.Trim = "" Then
                btGuardar_Click(Nothing, Nothing)
            Else
                btEditar_Click(Nothing, Nothing)
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtModelo.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            cmbUnidaddemedida.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            txtUbicacion.Focus()
        End If
    End Sub

    Private Sub txtCosto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCosto.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtCosto.Text.Trim = "" Then
                chkMargen.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar el Costo del Producto")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtPrecio1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio1.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtPrecio1.Text.Trim = "" Then
                txtPrecio2.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar el Precio1 del producto")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            chkMargen.Focus()
        End If
    End Sub

    Private Sub txtPrecio2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio2.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtPrecio2.Text.Trim = "" Then
                txtPrecio3.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar el Precio2 del producto")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtPrecio1.Focus()
        End If
    End Sub

    Private Sub txtPrecio3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio3.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtPrecio3.Text.Trim = "" Then
                txtPrecio4.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar el Precio3 del producto")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtPrecio2.Focus()
        End If
    End Sub

    Private Sub txtPrecio4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio4.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Not txtPrecio4.Text.Trim = "" Then
                txtCantidadMinima.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar el Precio4 del producto")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtPrecio3.Focus()
        End If
    End Sub

    Private Sub frmProducto_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscar.Click
        frmBuscarProductos.frm_return = 10
        frmBuscarProductos.ShowDialog()
    End Sub

    Private Sub btActualizarMarca_Click(sender As Object, e As EventArgs) Handles btAcutalizarMarca.Click
        Try
            Using db As New CodeFirst
                Dim marca As String = cmbMarca.Text
                cmbMarca.DataSource = db.Marcas.Where(Function(f) f.ACTIVO = "S").ToList() : cmbMarca.DisplayMember = "DESCRIPCION" : cmbMarca.ValueMember = "IDMARCA"
                cmbMarca.Text = marca
                marca = Nothing
                cmbMarca.SelectionLength = 0
                cmbMarca.SelectionStart = cmbMarca.Text.Length
                cmbMarca.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error," & ex.Message)
        End Try
    End Sub

    Private Sub btImagen_Click(sender As Object, e As EventArgs) Handles btImagen.Click
        Try
            If opArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.cargarImagen(fileName:=opArchivo.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub pnImagen_DoubleClick(sender As Object, e As EventArgs) Handles pnImagen.DoubleClick
        If Not pnImagen.Style.BackgroundImage Is Nothing Then
            frmVistaPrevia.pnImagen.Style.BackgroundImage = Me.pnImagen.Style.BackgroundImage
            frmVistaPrevia.ShowDialog()
        Else
            MessageBox.Show("No hay imagen para mostrar")
        End If
    End Sub

    Private Sub chkMargen_CheckedChanged(sender As Object, e As EventArgs) Handles chkMargen.CheckedChanged
        txtPrecio1.Focus()
    End Sub

    Private Sub cmbUnidaddemedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUnidaddemedida.KeyDown
        If e.KeyData = Keys.Enter Then
            If cmbUnidaddemedida.Text.Trim <> "" Then
                If Not cmbUnidaddemedida.SelectedValue Is Nothing And Not cmbUnidaddemedida.SelectedIndex = -1 Then
                    txtContiene.Focus()
                Else
                    Try
                        Using db As New CodeFirst
                            If db.UnidadesMedidas.Where(Function(f) f.DESCRIPCION = cmbUnidaddemedida.Text.Trim).Count() > 0 Then
                                btActualizarMarca_Click(Nothing, Nothing)
                            Else
                                If MessageBox.Show("No se encuentra esta Unidad de Medida ¿Desea crearlo?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    Dim unidad As New UnidadMedida : unidad.IDUNIDAD = Guid.NewGuid.ToString : unidad.DESCRIPCION = cmbUnidaddemedida.Text : unidad.ACTIVO = "S" : db.UnidadesMedidas.Add(unidad) : db.SaveChanges() : unidad = Nothing
                                    btUnidaddemedida_Click(Nothing, Nothing)
                                    txtContiene.Focus()
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error, " & ex.Message)
                    End Try
                End If
            Else
                MessageBox.Show("Error, Debe de ingresar la unidad de medida del producto.")
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub btUnidaddemedida_Click(sender As Object, e As EventArgs) Handles btUnidaddemedida.Click
        Try
            Using db As New CodeFirst
                Dim unidad As String = cmbUnidaddemedida.Text
                cmbUnidaddemedida.DataSource = db.UnidadesMedidas.Where(Function(f) f.ACTIVO = "S").ToList() : cmbUnidaddemedida.DisplayMember = "DESCRIPCION" : cmbUnidaddemedida.ValueMember = "IDUNIDAD"
                cmbUnidaddemedida.Text = unidad
                unidad = Nothing
                cmbUnidaddemedida.SelectionLength = 0
                cmbUnidaddemedida.SelectionStart = cmbUnidaddemedida.Text.Length
                cmbUnidaddemedida.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error," & ex.Message)
        End Try
    End Sub

    Private Sub cmbPresentacion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPresentacion.KeyDown
        If e.KeyData = Keys.Enter Then
            If cmbPresentacion.Text.Trim <> "" Then
                If Not cmbPresentacion.SelectedValue Is Nothing And Not cmbPresentacion.SelectedIndex = -1 Then
                    cmbLaboratorio.Focus()
                Else
                    Try
                        Using db As New CodeFirst
                            If db.Presentaciones.Where(Function(f) f.DESCRIPCION = cmbPresentacion.Text.Trim).Count() > 0 Then
                                btPresentacion_Click(Nothing, Nothing)
                            Else
                                If MessageBox.Show("No se encuentra esta Presentación ¿Desea crearlo?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    Dim presentacion As New Presentacion : presentacion.IDPRESENTACION = Guid.NewGuid.ToString : presentacion.DESCRIPCION = cmbPresentacion.Text : presentacion.ACTIVO = "S" : db.Presentaciones.Add(presentacion) : db.SaveChanges() : presentacion = Nothing
                                    btPresentacion_Click(Nothing, Nothing)
                                    cmbLaboratorio.Focus()
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error, " & ex.Message)
                    End Try
                End If
            Else
                MessageBox.Show("Error, Debe de ingresar la presentación del producto.")
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtDescuentoMaximo.Focus()
        End If
    End Sub

    Private Sub btPresentacion_Click(sender As Object, e As EventArgs) Handles btPresentacion.Click
        Try
            Using db As New CodeFirst
                Dim presentacion As String = cmbPresentacion.Text
                cmbPresentacion.DataSource = db.Presentaciones.Where(Function(f) f.ACTIVO = "S").ToList() : cmbPresentacion.DisplayMember = "DESCRIPCION" : cmbPresentacion.ValueMember = "IDPRESENTACION"
                cmbPresentacion.Text = presentacion
                presentacion = Nothing
                cmbPresentacion.SelectionLength = 0
                cmbPresentacion.SelectionStart = cmbPresentacion.Text.Length
                cmbPresentacion.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error," & ex.Message)
        End Try
    End Sub

    Private Sub cmbLaboratorio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLaboratorio.KeyDown
        If e.KeyData = Keys.Enter Then
            If cmbLaboratorio.Text.Trim <> "" Then
                If Not cmbLaboratorio.SelectedValue Is Nothing And Not cmbLaboratorio.SelectedIndex = -1 Then
                    txtProveedor.Focus()
                Else
                    Try
                        Using db As New CodeFirst
                            If db.Laboratorios.Where(Function(f) f.DESCRIPCION = cmbLaboratorio.Text.Trim).Count() > 0 Then
                                btLaboratorio_Click(Nothing, Nothing)
                            Else
                                If MessageBox.Show("No se encuentra esta empresa ¿Desea crearlo?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    Dim laboratorio As New Laboratorio : laboratorio.IDLABORATORIO = Guid.NewGuid.ToString : laboratorio.DESCRIPCION = cmbLaboratorio.Text : laboratorio.ACTIVO = "S" : db.Laboratorios.Add(laboratorio) : db.SaveChanges() : laboratorio = Nothing
                                    btLaboratorio_Click(Nothing, Nothing)
                                    txtProveedor.Focus()
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error, " & ex.Message)
                    End Try
                End If
            Else
                MessageBox.Show("Error, Debe de ingresar el empresa del producto.")
            End If
        ElseIf e.KeyData = Keys.Escape Then
            cmbPresentacion.Focus()
        End If
    End Sub

    Private Sub txtContiene_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContiene.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtContiene.Text.Trim() <> "" Then
                txtCosto.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar la cantidad de unidades que contiene la unidad de medida especificada.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            cmbUnidaddemedida.Focus()
        End If
    End Sub

    Private Sub btLaboratorio_Click(sender As Object, e As EventArgs) Handles btLaboratorio.Click
        Try
            Using db As New CodeFirst
                Dim laboratorio As String = cmbLaboratorio.Text
                cmbLaboratorio.DataSource = db.Laboratorios.Where(Function(f) f.ACTIVO = "S").ToList() : cmbLaboratorio.DisplayMember = "DESCRIPCION" : cmbLaboratorio.ValueMember = "IDLABORATORIO"
                cmbLaboratorio.Text = laboratorio
                laboratorio = Nothing
                cmbLaboratorio.SelectionLength = 0
                cmbLaboratorio.SelectionStart = cmbLaboratorio.Text.Length
                cmbLaboratorio.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error," & ex.Message)
        End Try
    End Sub

    Private Sub txtCantidadMinima_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadMinima.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCantidadMinima.Text.Trim <> "" Then
                txtCantidadMaxima.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar la cantidad mínima del producto.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtPrecio4.Focus()
        End If
    End Sub

    Private Sub txtDescuentoMaximo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoMaximo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCantidadMinima.Text.Trim <> "" Then
                cmbPresentacion.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar el descuento máximo del producto.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtCantidadMaxima.Focus()
        End If
    End Sub

    Private Sub txtCantidadMaxima_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadMaxima.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtCantidadMaxima.Text.Trim <> "" Then
                txtDescuentoMaximo.Focus()
            Else
                MessageBox.Show("Error, Debe ingresar la cantidad máxima del producto.")
            End If
        ElseIf e.KeyChar = ChrW(27) Then
            txtCantidadMinima.Focus()
        End If
    End Sub

    Private Sub txtUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUbicacion.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtObservacion.Focus()
        ElseIf e.KeyChar = ChrW(27) Then
            cmbLaboratorio.Focus()
        End If
    End Sub

    Private Sub chkMargen_KeyDown(sender As Object, e As KeyEventArgs) Handles chkMargen.KeyDown
        If e.KeyData = Keys.Enter Then
            If chkMargen.Checked Then
                chkMargen.Checked = False
            Else
                chkMargen.Checked = True
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtPrecio1.Focus()
        ElseIf e.KeyData = Keys.Add Then
            chkMargen.Checked = True
        ElseIf e.KeyData = Keys.Subtract Then
            chkMargen.Checked = False
        End If
    End Sub


    Private Sub frmProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    btNuevo_Click(Nothing, Nothing)
                Case Keys.G
                    If btGuardar.Enabled Then
                        btGuardar_Click(Nothing, Nothing)
                    End If
                Case Keys.E
                    If btEditar.Enabled Then
                        btEditar_Click(Nothing, Nothing)
                    End If
                Case Keys.Delete
                    If btEliminar.Enabled Then
                        btEliminar_Click(Nothing, Nothing)
                    End If
                Case Keys.B
                    btBuscar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub dtpFechaVencimiento_KeyDown(sender As Object, e As KeyEventArgs)
        txtAplicacion.Focus()
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyData = Keys.Enter Then
            txtAplicacion.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            cmbLaboratorio.Focus()
        End If
    End Sub

    Private Sub btBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btBuscarProveedor.Click
        frmBuscarProveedor.frm_return = 6
        frmBuscarProveedor.ShowDialog()
        If txtIdProveedor.Text.Trim <> "" Then
            txtAplicacion.Focus()
        Else
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub btAgregarProveedor_Click(sender As Object, e As EventArgs) Handles btAgregarProveedor.Click
        frmProveedor.MdiParent = frmPrincipal
        frmProveedor.BringToFront()
        frmProveedor.Show()
    End Sub

    Private Sub frmProducto_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        txtImagen.Width = pnContImage.Width - btImagen.Width - btEliminarImagen.Width - (txtImagen.Location.X * 2)
        btImagen.Left = txtImagen.Location.X + txtImagen.Width - 1
        btEliminarImagen.Left = txtImagen.Location.X + txtImagen.Width + btEliminarImagen.Width - 2
        pnImagen.Width = pnContImage.Width - (pnImagen.Location.X * 2)
        pnImagen.Height = pnContImage.Height - pnImagen.Location.X - 31
    End Sub

    Private Sub btDarAlta_Click(sender As Object, e As EventArgs) Handles btDarAlta.Click
        Try
            If MessageBox.Show("¿Desea activar este Producto?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Using db As New CodeFirst
                    Dim producto = db.Productos.Where(Function(f) f.IDPRODUCTO = txtCodigo.Text And f.ACTIVO = "N").FirstOrDefault()
                    If Not producto Is Nothing Then
                        producto.ACTIVO = "S"
                        db.Entry(producto).State = EntityState.Modified
                        db.SaveChanges() : Limpiar()
                        Config.MsgInfo("Activado correctamente")
                    Else
                        Config.MsgErr("Este producto ya se encuentra activado.")
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btEliminarImagen_Click(sender As Object, e As EventArgs) Handles btEliminarImagen.Click
       
        pnImagen.Style.BackgroundImage = Nothing
        txtImagen.Clear()

    End Sub
End Class