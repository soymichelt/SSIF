Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.IO

Module Config
    'Clavo de Registro
    Public RegistryKey As Microsoft.Win32.RegistryKey
    Public Key As Object
    Public DateLimite As Nullable(Of DateTime)

    Public Sub ServerLoad()
        Try
            If File.Exists(Config.ServerFileName) Then
                'Lector del Archivo de Configuración
                Dim read As StreamReader = New IO.StreamReader(Config.ServerFileName)

                'Leyendo el servidor del servidor
                Dim sLine = read.ReadLine()
                If Not sLine Is Nothing Then

                    'Configurar Nombre del Servidor SQL en el modelo
                    Sadara.Models.V1.Config.SQLServerName = CryptoSecurity.Decoding(sLine)

                Else
                    Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                    Sadara.Models.V1.Config.SQLServerName = Nothing
                End If


                'Leyendo el nombre de la base de datos
                sLine = read.ReadLine()
                If Not sLine Is Nothing Then

                    'Configurar Nombre de la Base de Datos en el modelo
                    Sadara.Models.V1.Config.InitialCatalog = CryptoSecurity.Decoding(sLine)

                Else
                    Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                    Sadara.Models.V1.Config.SQLServerName = Nothing
                End If


                'Leyendo el Usuario del SGBD
                sLine = read.ReadLine()
                If Not sLine Is Nothing Then

                    'Configurar Nombre del Usuario de SQL en el modelo
                    Sadara.Models.V1.Config.SQLUser = CryptoSecurity.Decoding(sLine)


                    'Leyendo el Password del SGBD
                    sLine = read.ReadLine()
                    If Not sLine Is Nothing Then

                        'Configurar Contraseña del Usuario de SQL en el modelo
                        Sadara.Models.V1.Config.SQLPass = CryptoSecurity.Decoding(sLine)

                    Else
                        Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                        Sadara.Models.V1.Config.SQLServerName = Nothing
                    End If

                Else
                    Sadara.Models.V1.Config.SQLUser = ""
                    Sadara.Models.V1.Config.SQLPass = ""
                End If

            Else
                Config.MsgErr("La configuración del servidor no existe. Deberá configurarlo manualmente.")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
            Sadara.Models.V1.Config.SQLServerName = Nothing
        End Try
    End Sub

    Public PrinterFileName As String = My.Application.Info.DirectoryPath & "\Printer.Config.Sif"
    Public Sub PrinterSelect()
        Try
            If File.Exists(Config.PrinterFileName) Then
                'Lector del Archivo de Configuración
                Using read As StreamReader = New IO.StreamReader(Config.PrinterFileName)
                    'Leyendo el servidor del servidor
                    Dim sLine = read.ReadLine()
                    If Not sLine Is Nothing Then
                        Config.PrinterName = CryptoSecurity.Decoding(sLine)
                    Else
                        Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                        Config.PrinterName = Nothing
                    End If
                End Using
            Else
                Config.PrinterName = Nothing
            End If
        Catch ex As Exception
            Config.PrinterName = Nothing
        End Try
    End Sub



    'SQL Server
    'Public SQLServicesName As String = "MSSQL$SQLEXPRESS" ' Instancia de SQL Server
    Public SQLServicesName As String = "" 'LocalDB

    'IP Config
    Public ServerFileName As String = My.Application.Info.DirectoryPath & "\Server.Config.Sif"

    'Directorios
    Public DirectoryPathImageUsers As String = My.Application.Info.DirectoryPath & "\Imagenes\ImgUsers\"
    Public DirectoryPathImageProducts As String = My.Application.Info.DirectoryPath & "\Imagenes\ImgProducts\"

    'Sistema
    Public Titulo As String = "Sistema de Inventario y Facturación v1.0"

    'Mensaje
    Public Sub MsgInfo(ByVal Msg As String)
        System.Windows.Forms.MessageBox.Show(Msg, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub MsgAdv(ByVal Msg As String)
        System.Windows.Forms.MessageBox.Show("Advertencia: " & Msg, "Advertencia! Mensaje de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Public Sub MsgErr(ByVal Msg As String)
        System.Windows.Forms.MessageBox.Show("Error: " & Msg, "Error! Mensaje de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    'Image
    Public ImageExtension As String = ".jpeg"

    'datos de la bodega
    Public warehouseId As String
    Public warehouseName As String
    Public exchangeRate As Decimal
    Public iva As Decimal

    'objetos
    Public _warehouse As Bodega
    Public _exchangeRate As Taza
    Public _iva As ImpuestoValorAgregado

    'datos de usuario
    Public currentUser As Usuario
    Public activatePrivileges As Usuario

    'datos del tema
    Public tema_ribon_dev As New DevComponents.DotNetBar.StyleManager
    Public tema_form_style_klik As New Klik.Windows.Forms.v1.Common.KStyleManager
    Public fondo_principal As New Color


    ''''''''''''''''''''''''''''''''''''''''''
    Public dateFormat As String = "dd/MM/yyyy"

    Public f_c As String = "#,##0"
    Public f_m As String = "#,##0.0000"
    Public f_t As String = "#,##0.00"
    Public f_m_r As String = "-(#,##0.00)"
    Public f_m_e As String = "#,##0.0000"
    Public formatoAutonumerico As String = "#0000000000"

    '''''''''''''''''''''''''''''''''''''''''
    Public currentBusiness As Empresa
    Public businessName As String = "VETERINARIA ""LA ECONÓMICA"""
    Public businessAddress As String = "Ciudad Rama, frente al Colegio Nuestra Señora de Fatima"
    Public businessRUC As String = "1211406630002J"
    Public businessPhone1 As String = "8840-3000"
    Public businessPhone2 As String = "8624-8024"

    Public Sub FormatDecimalControls(ByVal Controls As List(Of Control))

    End Sub

    Public Sub MetodoPromedio(ByVal producto As Producto)
        Using db As New CodeFirst
            If producto.Existencias.Count > 0 Then
                Dim kardexs = From kar In db.Kardexs Join exi In db.Existencias On kar.IDEXISTENCIA Equals exi.IDEXISTENCIA Where exi.IDPRODUCTO = producto.IDPRODUCTO And kar.ACTIVO = "S" Select SALDO = kar.DEBER - kar.HABER
                Dim costo_promedio As Decimal = 0
                If kardexs.Count() > 0 Then
                    costo_promedio = kardexs.Sum() / producto.Existencias.Sum(Function(f) f.Bodega.ACTIVO = "S" And f.CANTIDAD + f.CONSIGNADO)
                End If
            End If
        End Using
    End Sub

    Public Function ValidateLapse(ByVal currentDate As DateTime) As Boolean
        Try
            Using db As New CodeFirst
                Config._lapse = db.Periodos.Where(Function(f) f.IDPERIODO = Config._lapse.IDPERIODO And f.ACTIVO.Equals(Config.vTrue) And f.ACTUAL.Equals(Config.vTrue)).FirstOrDefault
                If Not Config._lapse Is Nothing Then
                    With Config._lapse
                        If Not .APERTURA Is Nothing Then
                            If .CIERRE Is Nothing Then
                                If currentDate <= .INICIO Or currentDate >= .FINAL Then
                                    Config.MsgErr("La Fecha debe estar dentro del rango de 'Período Contable': Desde " & .INICIO.ToShortDateString & " Hasta " & .FINAL.ToShortDateString)
                                Else
                                    Return True
                                End If
                            Else
                                Config.MsgErr("Ya se realizó el cierre de este 'Período Contable'.")
                            End If
                        Else
                            Config.MsgErr("Aperturar el 'Período Contable'.")
                        End If
                    End With
                Else
                    Config.MsgErr("Primero debe establecer un 'Período Contable'.")
                End If
            End Using
            Return False
        Catch ex As Exception
            Config.MsgErr(ex.Message)
            Return False
        End Try
    End Function

    Public PrinterName As String = "EPSON TM-U220 Receipt"

    'datos de periodo
    Public _lapse As Periodo

    'valores
    Public vTrue As String = "S"
    Public vFalse As String = "N"
    Public textNull As String = "SIN ESPECIFICAR"
    Public cordoba As String = "C"
    Public dolar As String = "D"

    'Cerrar
    Public Sub ExitApplication()
        Application.Exit()
    End Sub

    Public Sub LoginInit()
        frmLogin.Show()
        For Each c As Form In Application.OpenForms
            If c.Name <> "frmIniciarSesion" Then
                c.Dispose()
            End If
        Next
    End Sub

    Public Sub CrystalTitle(ByVal Title As String, ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim txtob As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.ReportObjects("txtTitulo")
        txtob.Text = "SISTEMA DE INVENTARIO Y FACTURACIÓN" & vbNewLine & Config.businessName & vbNewLine & Title
        txtob = Nothing
    End Sub

End Module