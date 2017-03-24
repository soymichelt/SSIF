'Imports System.Data.SqlClient
'Imports System.Data
'Imports System.Windows.Forms
'Public Class TRANSACCION
'#Region "Variables Privadas"
'    Dim conexion As SqlConnection
'    Dim comando As SqlCommand
'    Dim lector As SqlDataReader
'    Dim adapter As SqlDataAdapter
'    Dim tabla As DataTable
'    Dim datarow() As DataRow
'    Dim cadenaConexion As String = "DATA SOURCE=(localdb)\v11.0; INITIAL CATALOG=BDRUTA; INTEGRATED SECURITY=TRUE;"
'    Dim Transaccion As SqlTransaction
'    Dim conexionTransacion As SqlConnection
'    Dim comandoTransaccion As SqlCommand
'#End Region
'#Region "Constructores"
'    Public Sub New()
'        conexion = New SqlConnection(cadenaConexion)
'    End Sub
'#End Region
'#Region "Metodos"
'    Public Function IniciarTransaccion() As Boolean
'        Try
'            If Not conexionTransacion Is Nothing Then
'                If conexionTransacion.State = ConnectionState.Open Then
'                    conexionTransacion.Dispose()
'                    SqlConnection.ClearAllPools()
'                End If
'            End If
'            conexionTransacion = New SqlConnection(cadenaConexion)
'            conexionTransacion.Open()
'            Transaccion = conexionTransacion.BeginTransaction()
'            comandoTransaccion = conexionTransacion.CreateCommand()
'            comandoTransaccion.Transaction = Transaccion
'            Return True
'        Catch ex As Exception
'            Return False
'        End Try
'    End Function

'    Public Function EjecutarTransaccion(ByVal consulta As String) As Boolean
'        Try
'            comandoTransaccion.CommandText = consulta
'            comandoTransaccion.ExecuteNonQuery()
'            Return True
'        Catch ex As Exception
'            Return False
'        End Try
'    End Function

'    Public Function EnviarTransaccion() As Boolean
'        Try
'            Transaccion.Commit()

'            'eliminar todo
'            Transaccion.Dispose()
'            conexion.Close()
'            conexion.Dispose()
'            comandoTransaccion.Dispose()

'            'confirmar que todo fue correcto
'            Return True
'        Catch ex As Exception
'            Return False
'        End Try
'    End Function

'    Public Function RollBack()
'        Try
'            Transaccion.Rollback()

'            'eliminar todo
'            Transaccion.Dispose()
'            conexion.Close()
'            conexion.Dispose()
'            comando.Dispose()

'            'confirmar que todo fue correcto
'            Return True
'        Catch ex As Exception
'            Return False
'        End Try
'    End Function

'    Public Function conectar() As SqlConnection
'        Try
'            If conexion.State = ConnectionState.Open Then
'                conexion.Dispose()
'                SqlConnection.ClearAllPools()
'            End If
'            conexion = New SqlConnection(cadenaConexion)
'            conexion.Open()
'            Return conexion
'        Catch ex As Exception
'            Return Nothing
'        End Try
'    End Function

'    Public Function ejecutar(ByVal consulta As String, Optional ByVal msj As Boolean = False) As Boolean
'        Try
'            comando = New SqlCommand(consulta, conectar)
'            comando.ExecuteNonQuery()
'            If msj Then
'                MessageBox.Show("Transaccion ejecutada correctamente.")
'            End If
'            comando.Dispose()
'            Return True
'        Catch ex As Exception
'            MessageBox.Show("Error, " & ex.Message)
'            Return False
'        End Try
'    End Function

'    Public Function buscar(ByVal consulta As String, ByVal valor_recuperar As String) As String
'        Try
'            comando = New SqlCommand(consulta, conectar)
'            lector = comando.ExecuteReader
'            If lector.Read Then
'                Return lector(valor_recuperar).ToString
'            Else
'                Return ""
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Error, " & ex.Message)
'            Return ""
'        End Try
'    End Function

'    Public Function Retornar_Tabla(ByVal consulta As String) As DataTable
'        Try
'            adapter = New SqlDataAdapter(consulta, conectar)
'            tabla = New DataTable
'            adapter.Fill(tabla)
'            Return tabla
'        Catch ex As Exception
'            MessageBox.Show("Error, " & ex.Message)
'            Return Nothing
'        End Try
'    End Function

'    Public Function Retornar_Columnas(ByVal consulta As String) As DataRow()
'        Try
'            datarow = Me.Retornar_Tabla(consulta).Select()
'            Return datarow
'        Catch ex As Exception
'            MessageBox.Show("Error, " & ex.Message)
'            Return Nothing
'        End Try
'    End Function

'    Public Function Retornar_lector(ByVal consulta As String) As SqlDataReader
'        Try
'            comando = New SqlCommand(consulta, conectar)
'            lector = comando.ExecuteReader
'            Return lector
'        Catch ex As Exception
'            MessageBox.Show("Error, " & ex.Message)
'            Return Nothing
'        End Try
'    End Function

'    Public Sub llenar_combo(ByVal consulta As String, ByVal combobox As ComboBox, ByVal valor As String, ByVal nombre As String)
'        Try
'            combobox.DataSource = Retornar_Tabla(consulta)
'            combobox.ValueMember = valor
'            combobox.DisplayMember = nombre
'            combobox.SelectedIndex = -1
'        Catch ex As Exception
'            MessageBox.Show("Error, " & ex.Message)
'        End Try
'    End Sub

'    Public Function GenerarCodigo(ByVal codigo As String, ByVal tabla As String, ByVal serie As String) As String
'        Try
'            comando = New SqlCommand("SELECT MAX(" & codigo & ") AS COD FROM " & tabla & " WHERE CONVERT(VARCHAR(36),IDSERIE) = '" & serie & "'", conectar())
'            lector = comando.ExecuteReader
'            If lector.Read() Then
'                Dim cod As String = lector("COD").ToString
'                If Not cod.Trim = "" Then
'                    cod = (Convert.ToInt32(cod) + 1).ToString
'                    Dim longitud As Integer = cod.Length
'                    For i As Integer = 0 To 9 - longitud
'                        cod = "0" & cod
'                    Next
'                    Return cod
'                Else
'                    Return "0000000001"
'                End If
'            Else
'                Return ""
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Error, " & ex.Message)
'            Return ""
'        End Try
'    End Function

'    'Public Sub Reporte(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal visor As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal consulta As String)
'    '    Try
'    '        rpt.SetDataSource(Retornar_Tabla(consulta))
'    '        visor.ReportSource = rpt
'    '    Catch ex As Exception
'    '        MessageBox.Show("Error, " & ex.Message)
'    '    End Try
'    'End Sub
'#End Region
'End Class





'Try
'                Using db As New MODELODEDATOS
'                    db.Database.CreateIfNotExists()
'                    If Not db.BODEGAS.Count() > 0 Then
'                        If MessageBox.Show("No se encontrarón sucursales creadas ¿Desea que el sistema información de inicio?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
'Dim bod As New BODEGA
'                            bod.IDBODEGA = Guid.NewGuid.ToString()
'                            bod.N_BODEGA = "SUC-001"
'                            bod.DESCRIPCION = "SUCURSAL CENTRAL"
'                            bod.ACTIVO = "S"
'                            db.BODEGAS.Add(bod)
'                            db.SaveChanges()
'                            If Not db.PERIODOS.Count() > 0 Then
'Dim periodo As New PERIODO
'                                periodo.IDPERIODO = Guid.NewGuid.ToString()
'                                periodo.AÑOLECTIVO = Short.Parse(DateTime.Now.Year.ToString())
'                                periodo.INICIO = DateTime.Parse("01/01/" & periodo.AÑOLECTIVO.ToString())
'                                periodo.FINAL = DateTime.Parse("31/12/" & periodo.AÑOLECTIVO.ToString())
'                                periodo.ACTUAL = "S"
'                                periodo.ACTIVO = "S"
'                                db.PERIODOS.Add(periodo)
'                                db.SaveChanges()
'                            End If
''cargar catalogos de cuentas
'                            If Not db.CATALOGOS_CUENTAS.Count() > 0 Then
'Dim cuenta As New CATALOGO_CUENTA
''ACTIVOS
'                                cuenta.IDCUENTA = Guid.NewGuid.ToString()
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.CODIGO_CUENTA_SUPERIOR = ""
'                                cuenta.NIVEL = 1
'                                cuenta.CODIGO_CUENTA = "100"
'                                cuenta.CONCEPTO = "ACTIVOS"
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.NATURALEZA = "DEUDORA"
'                                cuenta.DEBER = 0
'                                cuenta.HABER = 0
'                                cuenta.SALDO = 0
'                                cuenta.ACTIVO = "S"
'                                db.CATALOGOS_CUENTAS.Add(cuenta)
''PASIVOS
'                                cuenta = New CATALOGO_CUENTA
'                                cuenta.IDCUENTA = Guid.NewGuid.ToString()
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.CODIGO_CUENTA_SUPERIOR = ""
'                                cuenta.NIVEL = 1
'                                cuenta.CODIGO_CUENTA = "200"
'                                cuenta.CONCEPTO = "PASIVOS"
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.NATURALEZA = "ACREEDORA"
'                                cuenta.DEBER = 0
'                                cuenta.HABER = 0
'                                cuenta.SALDO = 0
'                                cuenta.ACTIVO = "S"
'                                db.CATALOGOS_CUENTAS.Add(cuenta)
''CAPITAL
'                                cuenta = New CATALOGO_CUENTA
'                                cuenta.IDCUENTA = Guid.NewGuid.ToString()
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.CODIGO_CUENTA_SUPERIOR = ""
'                                cuenta.NIVEL = 1
'                                cuenta.CODIGO_CUENTA = "300"
'                                cuenta.CONCEPTO = "CAPITAL"
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.NATURALEZA = "ACREEDORA"
'                                cuenta.DEBER = 0
'                                cuenta.HABER = 0
'                                cuenta.SALDO = 0
'                                cuenta.ACTIVO = "S"
'                                db.CATALOGOS_CUENTAS.Add(cuenta)
''INGRESOS
'                                cuenta = New CATALOGO_CUENTA
'                                cuenta.IDCUENTA = Guid.NewGuid.ToString()
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.CODIGO_CUENTA_SUPERIOR = ""
'                                cuenta.NIVEL = 1
'                                cuenta.CODIGO_CUENTA = "400"
'                                cuenta.CONCEPTO = "INGRESOS"
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.NATURALEZA = "ACREEDORA"
'                                cuenta.DEBER = 0
'                                cuenta.HABER = 0
'                                cuenta.SALDO = 0
'                                cuenta.ACTIVO = "S"
'                                db.CATALOGOS_CUENTAS.Add(cuenta)
''COSTOS
'                                cuenta = New CATALOGO_CUENTA
'                                cuenta.IDCUENTA = Guid.NewGuid.ToString()
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.CODIGO_CUENTA_SUPERIOR = ""
'                                cuenta.NIVEL = 1
'                                cuenta.CODIGO_CUENTA = "500"
'                                cuenta.CONCEPTO = "COSTOS"
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.NATURALEZA = "DEUDORA"
'                                cuenta.DEBER = 0
'                                cuenta.HABER = 0
'                                cuenta.SALDO = 0
'                                cuenta.ACTIVO = "S"
'                                db.CATALOGOS_CUENTAS.Add(cuenta)
''GASTOS
'                                cuenta = New CATALOGO_CUENTA
'                                cuenta.IDCUENTA = Guid.NewGuid.ToString()
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.CODIGO_CUENTA_SUPERIOR = ""
'                                cuenta.NIVEL = 1
'                                cuenta.CODIGO_CUENTA = "600"
'                                cuenta.CONCEPTO = "GASTOS"
'                                cuenta.CUENTA_SUPERIOR = ""
'                                cuenta.NATURALEZA = "DEUDORA"
'                                cuenta.DEBER = 0
'                                cuenta.HABER = 0
'                                cuenta.SALDO = 0
'                                cuenta.ACTIVO = "S"
'                                db.CATALOGOS_CUENTAS.Add(cuenta)
'                            End If
''crear mas informacion de inicio
'                            If Not db.USUARIOS.Count() > 0 Then
'Dim user As New USUARIO
'                                user.IDUSUARIO = Guid.NewGuid.ToString()
'                                user.NOMBRECUENTA = "Admin"
'                                user.CONTRASEÑA = "admin*123"
'                                user.NOMBRES = "MICHEL ROBERTO"
'                                user.APELLIDOS = "TRAÑA TABLADA"
'                                user.OBSERVACION = "USUARIO CREADO AUTOMÁTICAMENTE POR EL SISTEMA"
'                                user.ACTIVO = "S"
'                                db.USUARIOS.Add(user)
'Dim privilegio As USUARIO_PRIVILEGIO
'                                For Each bod In db.BODEGAS.Where(Function(f) f.ACTIVO = "S")
'                                    For Each c In frmUsuarios.cmbPermisos.Items
'                                        privilegio = New USUARIO_PRIVILEGIO
'                                        privilegio.IDPRIVILEGIO = Guid.NewGuid.ToString
'                                        privilegio.IDUSUARIO = user.IDUSUARIO
'                                        privilegio.IDBODEGA = bod.IDBODEGA
'                                        privilegio.PERMISO = c.ToString()
'                                        db.USUARIOS_PRIVILEGIOS.Add(privilegio)
'                                    Next
'                                Next
'                                db.SaveChanges()
'                                user = Nothing : privilegio = Nothing
'                            End If
'                            If Not db.SERIES.Count() > 0 Then
'Dim serie As SERIE
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "VENTA").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "FACT"
'                                    serie.DESCRIPCION = "FACTURACIÓN SUCURSAL CENTRAL"
'                                    serie.OPERACION = "VENTA"
'                                    serie.TICKET = "S"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "COMPRA").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "COMP"
'                                    serie.DESCRIPCION = "COMPRAS SUCURSAL CENTRAL"
'                                    serie.OPERACION = "COMPRA"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "ENTRADA").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "ENTR"
'                                    serie.DESCRIPCION = "ENTRADA SUCURSAL CENTRAL"
'                                    serie.OPERACION = "ENTRADA"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "SALIDA").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "SALI"
'                                    serie.DESCRIPCION = "SALIDA SUCURSAL CENTRAL"
'                                    serie.OPERACION = "SALIDA"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "TRASLADO").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "TRASL"
'                                    serie.DESCRIPCION = "TRASLADO SUCURSAL CENTRAL"
'                                    serie.OPERACION = "TRASLADO"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "RECIBO DE VENTA").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "REC-V"
'                                    serie.DESCRIPCION = "RECIBO DE VENTA SUCURSAL CENTRAL"
'                                    serie.OPERACION = "RECIBO DE VENTA"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "RECIBO DE COMPRA").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "REC-C"
'                                    serie.DESCRIPCION = "RECIBO DE COMPRA SUCURSAL CENTRAL"
'                                    serie.OPERACION = "RECIBO DE COMPRA"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "CONSIGNACION").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "CONSIG"
'                                    serie.DESCRIPCION = "CONSIGNACIÓN SUCURSAL CENTRAL"
'                                    serie.OPERACION = "CONSIGNACION"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "DESCONSIGNACION").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "DESCON"
'                                    serie.DESCRIPCION = "DESCONSIGNACIÓN SUCURSAL CENTRAL"
'                                    serie.OPERACION = "DESCONSIGNACION"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                If Not db.SERIES.Where(Function(f) f.OPERACION = "COTIZACION").Count() > 0 Then
'                                    serie = New SERIE
'                                    serie.IDSERIE = Guid.NewGuid.ToString()
'                                    serie.IDBODEGA = bod.IDBODEGA
'                                    serie.NOMBRE = "COTIZ"
'                                    serie.DESCRIPCION = "COTIZACIÓN SUCURSAL CENTRAL"
'                                    serie.OPERACION = "COTIZACION"
'                                    serie.TICKET = "N"
'                                    serie.FACTURA_MANUAL = "N"
'                                    serie.ACTIVO = "S"
'                                    db.SERIES.Add(serie)
'                                End If
'                                db.SaveChanges()
'                                serie = Nothing
'                            End If
'                            bod = Nothing

'                            If Not db.TAZAS.Count() > 0 Then
'Dim taza As New TAZA
'                                taza.IDTAZA = Guid.NewGuid.ToString()
'                                taza.FECHA = DateTime.Now
'                                taza.CAMBIO = 27

'                                db.TAZAS.Add(taza)
'                                db.SaveChanges()
'                                taza = Nothing
'                            End If
'                            If Not db.IVAS.Count() > 0 Then
'Dim iva As New IVA
'                                iva.IDIVA = Guid.NewGuid.ToString()
'                                iva.FECHA = DateTime.Now
'                                iva.PORCENTAJE = 15

'                                db.IVAS.Add(iva)
'                                db.SaveChanges()
'                                iva = Nothing
'                            End If
'                        End If
'                    End If
'                    Me.MainForm = Global.appFacturacion.frmIniciarSesion
'                End Using
'            Catch ex As Exception
'                frmErrorEstablecerConexionServidor.txtError.Text = "Error, " & ex.Message
'                Me.MainForm = Global.appFacturacion.frmErrorEstablecerConexionServidor
'            End Try