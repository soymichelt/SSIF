Imports System.IO
Module Config
    'Clavo de Registro
    Public RegistryKey As Microsoft.Win32.RegistryKey
    Public Key As Object
    Public DateLimite As Nullable(Of DateTime)

    'IP Config
    Public SQLServerName As String = Nothing
    Public ServerFileName As String = My.Application.Info.DirectoryPath & "\Server.Config.Sif"

    Public Sub ServerLoad()
        Try
            If File.Exists(Config.ServerFileName) Then
                'Lector del Archivo de Configuración
                Dim read As StreamReader = New IO.StreamReader(Config.ServerFileName)


                'Leyendo el servidor del servidor
                Dim sLine = read.ReadLine()
                If Not sLine Is Nothing Then
                    Config.SQLServerName = CryptoSecurity.Decoding(sLine)
                Else
                    Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                    Config.SQLServerName = Nothing
                End If


                'Leyendo el nombre de la base de datos
                sLine = read.ReadLine()
                If Not sLine Is Nothing Then
                    Config.InitialCatalog = CryptoSecurity.Decoding(sLine)
                Else
                    Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                    Config.SQLServerName = Nothing
                End If


                'Leyendo el Usuario del SGBD
                sLine = read.ReadLine()
                If Not sLine Is Nothing Then
                    Config.SQLUser = CryptoSecurity.Decoding(sLine)


                    'Leyendo el Password del SGBD
                    sLine = read.ReadLine()
                    If Not sLine Is Nothing Then
                        Config.SQLPass = CryptoSecurity.Decoding(sLine)
                    Else
                        Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                        Config.SQLServerName = Nothing
                    End If
                Else
                    Config.SQLUser = ""
                    Config.SQLPass = ""
                End If
            Else
                Config.MsgErr("La configuración del servidor no existe. Deberá configurarlo manualmente.")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
            Config.SQLServerName = Nothing
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
                        Config.PrintName = CryptoSecurity.Decoding(sLine)
                    Else
                        Config.MsgErr("Configurar el archivo de conexión del Servidor SGBD.")
                        Config.PrintName = Nothing
                    End If
                End Using
            Else
                Config.PrintName = Nothing
            End If
        Catch ex As Exception
            Config.PrintName = Nothing
        End Try
    End Sub



    'SQL Server
    'Public SQLServicesName As String = "MSSQL$SQLEXPRESS" ' Instancia de SQL Server
    Public SQLServicesName As String = "" 'LocalDB

    'SQL Data
    Public InitialCatalog As String = "dbFacturacion-12-Noviembre-2016"
    Public SQLUser As String = "sa"
    Public SQLPass As String = "admin*123"

    'SQL Connection
    Public SQLConecction As String = "Data Source=" + Config.SQLServerName + ";Initial Catalog=dbFacturacion-08-Junio-2016;Integrated Security=True"
    'Public SQLConecction As String = "Data Source=.\UNANFAREMCH;Initial Catalog=dbFacturacion-08-Junio-2016;Integrated Security=True"
    'Public SQLConection As String = "Data Source=.\SIF;Initial Catalog=dbFacturacion-08-Junio-2016;User ID = sa; Password = admin*123;"
    'Public SQLConection As String = "Data Source=.\SQLEXPRESS;Initial Catalog=dbFacturacion-08-Junio-2016; Integrated Security = True;"

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
    Public bodega As String
    Public nom_bodega As String
    Public tazadecambio As Decimal
    Public iva As Decimal

    'objetos
    Public _Bodega As Bodega
    Public _Taza As Taza
    Public _Iva As ImpuestoValorAgregado

    'datos de usuario
    Public Usuario As Usuario
    Public ActivarPrivilegio As Usuario

    'datos del tema
    Public tema_ribon_dev As New DevComponents.DotNetBar.StyleManager
    Public tema_form_style_klik As New Klik.Windows.Forms.v1.Common.KStyleManager
    Public fondo_principal As New Color


    ''''''''''''''''''''''''''''''''''''''''''
    Public formato_fecha As String = "dd/MM/yyyy"
    'Public f_m As String = "#,##0.0000"
    'Public f_t As String = "#,##0.0000"
    'Public f_m_r As String = "-(#,##0.0000)"
    Public f_c As String = "#,##0"
    Public f_m As String = "#,##0.00"
    Public f_t As String = "#,##0.00"
    Public f_m_r As String = "-(#,##0.00)"


    '''''''''''''''''''''''''''''''''''''''''
    Public Empresa As Empresa
    Public NombreEmpresa As String = "VETERINARIA ""LA ECONÓMICA"""
    Public Direccion As String = "Ciudad Rama, frente al Colegio Nuestra Señora de Fatima"
    Public RUC As String = "1211406630002J"
    Public Telefono1 As String = "8840-3000"
    Public Telefono2 As String = "8624-8024"

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

    Public Function ValidarPeriodo(ByVal Fecha As DateTime) As Boolean
        Try
            Using db As New CodeFirst
                Config._Periodo = db.Periodos.Where(Function(f) f.IDPERIODO = Config._Periodo.IDPERIODO And f.ACTIVO.Equals(Config.vTrue) And f.ACTUAL.Equals(Config.vTrue)).FirstOrDefault
                If Not Config._Periodo Is Nothing Then
                    With Config._Periodo
                        If Not .APERTURA Is Nothing Then
                            If .CIERRE Is Nothing Then
                                If Fecha <= .INICIO Or Fecha >= .FINAL Then
                                    Config.MsgErr("La Fecha debe estar dentro del rango de 'Período Contable': Desde " & .INICIO.ToShortDateString & " Hasta " & .FINAL.ToShortDateString)
                                    Return False
                                Else
                                    Return True
                                End If
                            Else
                                Config.MsgErr("Ya se realizó el cierre de este 'Período Contable'.")
                                Return False
                            End If
                        Else
                            Config.MsgErr("Aperturar el 'Período Contable'.")
                            Return False
                        End If
                    End With
                Else
                    Config.MsgErr("Primero debe establecer un 'Período Contable'.")
                End If
            End Using
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Function

    'impresora por defecto
    'Public PrintName As String = "Microsoft XPS Document Writer"
    'Public PrintName As String = "Foxit Reader PDF Printer"
    'Public PrintName As String = "EPSON TM-U220 ReceiptE4
    'Public PrintName As String = "EPSON TM-U220 Receipt"

    Public PrintName As String = "EPSON TM-U220 Receipt"

    'datos de periodo
    Public _Periodo As Periodo

    'valores
    Public vTrue As String = "S"
    Public vFalse As String = "N"
    Public TextNull As String = "SIN ESPECIFICAR"
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
        txtob.Text = "SISTEMA DE INVENTARIO Y FACTURACIÓN" & vbNewLine & Config.NombreEmpresa & vbNewLine & Title
        txtob = Nothing
    End Sub

End Module