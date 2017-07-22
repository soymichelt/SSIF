﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO

Namespace My
    
    'NOTA: este archivo se genera de forma automática; no lo modifique directamente. Para realizar cambios,
    ' o si detecta errores de compilación en este archivo, vaya al Diseñador de proyectos
    ' (vaya a Propiedades del proyecto o haga doble clic en el nodo My Project en el
    ' Explorador de soluciones) y realice cambios en la pestaña Aplicación.
    '
    Partial Friend Class MyApplication
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = false
            Me.EnableVisualStyles = true
            Me.SaveMySettingsOnExit = true
            Me.ShutDownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterAllFormsClose
        End Sub
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Protected Overrides Sub OnCreateMainForm()
            Try

                'Archivo de Configuración de SQL Server
                Config.ServerLoad()
                If Sadara.Models.V1.Config.SQLServerName Is Nothing Then

                    If MessageBox.Show("¿Quieres configurar la Conexión al Servidor SGBD?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        frmServer.ShowDialog()
                        Config.ServerLoad()

                        If Sadara.Models.V1.Config.SQLServerName Is Nothing Then
                            Config.ExitApplication()
                        End If

                    Else

                        Config.ExitApplication()

                    End If

                End If

                If Config.SQLServicesName.Trim <> "" Then
                    Dim bService As Boolean = False
                    Dim c As ServiceProcess.ServiceController = ServiceProcess.ServiceController.GetServices().Where(Function(f) f.ServiceName.Equals(Config.SQLServicesName)).FirstOrDefault
                    If c IsNot Nothing Then
                        If c.Status <> ServiceProcess.ServiceControllerStatus.Running Then
                            Me.MainForm = Global.appFacturacion.frmSqlState
                            frmSqlState.ShowDialog()
                            bService = If(frmSqlState.SQLState.Equals(1), True, False)
                        End If
                    Else
                        Me.MainForm = Global.appFacturacion.frmSqlState
                        frmSqlState.ShowDialog()
                        bService = If(frmSqlState.SQLState.Equals(1), True, False)
                    End If
                    If Not bService Then
                        Config.ExitApplication()
                    End If
                End If

                'Cargando impresora
                Config.PrinterSelect()

                Using db As New CodeFirst
                    db.Database.CreateIfNotExists()
                    If Not db.Bodegas.Count() > 0 Then
                        If MessageBox.Show("¿Desea que el sistema cargue información de inicio?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim bod As New Bodega
                            bod.IDBODEGA = Guid.NewGuid.ToString()
                            bod.N_BODEGA = "SUC001"
                            bod.DESCRIPCION = "SUCURSAL CENTRAL"
                            bod.ACTIVO = "S"
                            db.Bodegas.Add(bod)
                            db.SaveChanges()
                            If Not db.Periodos.Count() > 0 Then
                                Dim periodo As New Periodo
                                periodo.IDPERIODO = Guid.NewGuid.ToString()
                                periodo.Reg = DateTime.Now
                                periodo.INICIO = DateTime.Parse("01/01/" & DateTime.Now.Year & " 00:00:00")
                                periodo.FINAL = DateTime.Parse("31/12/" & DateTime.Now.Year & " 23:59:59")
                                periodo.ACTUAL = "S"
                                periodo.ACTIVO = "S"
                                db.Periodos.Add(periodo)
                                db.SaveChanges()
                            End If
                            'crear mas informacion de inicio
                            If Not db.Usuarios.Count() > 0 Then
                                Dim user As New Usuario
                                user.IDUsuario = Guid.NewGuid.ToString()
                                user.NombreCuenta = "Admin"
                                user.Contraseña = "admin*123"
                                user.Nombres = "MICHEL ROBERTO"
                                user.Apellidos = "TRAÑA TABLADA"
                                user.Administrador = True
                                user.CAdministrador = True
                                user.Venta = True
                                user.VenderNegativo = True
                                user.CVenta = True
                                user.Compra = True
                                user.CCompra = True
                                user.Contabilidad = True
                                user.CContabilidad = True
                                user.Inventario = True
                                user.CInventario = True
                                user.SalesPriceChange = True
                                user.ImageName = ""
                                user.Observacion = "USUARIO CREADO AUTOMÁTICAMENTE POR EL SISTEMA"
                                user.Activo = "S"
                                db.Usuarios.Add(user)
                                db.SaveChanges()
                                user = Nothing
                            End If
                            If Not db.Series.Count() > 0 Then
                                Dim serie As Serie
                                If Not db.Series.Where(Function(f) f.OPERACION = "VENTA").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "FACT"
                                    serie.DESCRIPCION = "FACTURACIÓN SUCURSAL CENTRAL"
                                    serie.OPERACION = "VENTA"
                                    serie.TICKET = "S"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "COMPRA").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "COMP"
                                    serie.DESCRIPCION = "COMPRAS SUCURSAL CENTRAL"
                                    serie.OPERACION = "COMPRA"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "ENTRADA").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "ENTR"
                                    serie.DESCRIPCION = "ENTRADA SUCURSAL CENTRAL"
                                    serie.OPERACION = "ENTRADA"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "SALIDA").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "SALI"
                                    serie.DESCRIPCION = "SALIDA SUCURSAL CENTRAL"
                                    serie.OPERACION = "SALIDA"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "TRASLADO").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "TRASL"
                                    serie.DESCRIPCION = "TRASLADO SUCURSAL CENTRAL"
                                    serie.OPERACION = "TRASLADO"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "RECIBO DE VENTA").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "REC-V"
                                    serie.DESCRIPCION = "RECIBO DE VENTA SUCURSAL CENTRAL"
                                    serie.OPERACION = "RECIBO DE VENTA"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "RECIBO DE COMPRA").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "REC-C"
                                    serie.DESCRIPCION = "RECIBO DE COMPRA SUCURSAL CENTRAL"
                                    serie.OPERACION = "RECIBO DE COMPRA"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "CONSIGNACION").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "CONSIG"
                                    serie.DESCRIPCION = "CONSIGNACIÓN SUCURSAL CENTRAL"
                                    serie.OPERACION = "CONSIGNACION"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "DESCONSIGNACION").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "DESCON"
                                    serie.DESCRIPCION = "DESCONSIGNACIÓN SUCURSAL CENTRAL"
                                    serie.OPERACION = "DESCONSIGNACION"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                If Not db.Series.Where(Function(f) f.OPERACION = "COTIZACION").Count() > 0 Then
                                    serie = New Serie
                                    serie.IDSERIE = Guid.NewGuid.ToString()
                                    serie.IDBODEGA = bod.IDBODEGA
                                    serie.NOMBRE = "COTIZ"
                                    serie.DESCRIPCION = "COTIZACIÓN SUCURSAL CENTRAL"
                                    serie.OPERACION = "COTIZACION"
                                    serie.TICKET = "N"
                                    serie.FACTURA_MANUAL = "N"
                                    serie.ACTIVO = "S"
                                    db.Series.Add(serie)
                                End If
                                db.SaveChanges()
                                serie = Nothing
                            End If
                            bod = Nothing

                            If Not db.Tazas.Count() > 0 Then
                                Dim taza As New Taza
                                taza.IDTAZA = Guid.NewGuid.ToString()
                                taza.FECHA = DateTime.Now
                                taza.CAMBIO = 27

                                db.Tazas.Add(taza)
                                db.SaveChanges()
                                taza = Nothing
                            End If
                            If Not db.ImpuestosValoresAgregados.Count() > 0 Then
                                Dim iva As New ImpuestoValorAgregado
                                iva.IDIVA = Guid.NewGuid.ToString()
                                iva.FECHA = DateTime.Now
                                iva.PORCENTAJE = 15

                                db.ImpuestosValoresAgregados.Add(iva)
                                db.SaveChanges()
                                iva = Nothing
                            End If
                        End If
                    End If

                    'Config.Key = License.GetIlimit
                    'If Not License.LicenseValidateIlimit Then
                    '    Me.MainForm = Global.appFacturacion.frmRegister
                    '    Global.appFacturacion.frmRegister.ShowDialog()
                    'End If

                    'If Not Config.DateLimite Is Nothing Then
                    '    If Config.DateLimite.Value <= DateTime.Now Then
                    '        Config.MsgErr("El período de prueba ha expirado.")
                    '        Config.ExitApplication()
                    '    End If
                    'End If

                    Me.MainForm = Global.appFacturacion.frmLogin
                End Using
            Catch ex As Exception

                'frmErrorEstablecerConexionServidor.txtError.Text = "Error, " & ex.Message
                'Me.MainForm = Global.appFacturacion.frmErrorEstablecerConexionServidor

                MessageBox.Show("Error: " & ex.Message)

                Me.MainForm = Global.appFacturacion.frmServer

            End Try
        End Sub
    End Class
End Namespace
