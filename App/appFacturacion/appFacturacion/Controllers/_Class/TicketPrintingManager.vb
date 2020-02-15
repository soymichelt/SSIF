Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

#Region "Principal"
Public Class TicketPrintingManager

    Public ListElement As New ArrayList()
    Public contador As Integer = 0
    Public PosLine As Integer = 0
    Public CaracteresMaximos As Integer = 34
    Public CaracteresMaximosDescripcion As Integer = 34
    Public imageHeight As Integer = 0
    Public MargenIzquierdo As Double = 2
    Public MargenSuperior As Double = 2
    Public NombreDeLaFuente As String = "Lucida Console"
    Public TamanoDeLaFuente As Integer = 8
    Public FuenteImpresa As Font
    Public ColorDeLaFuente As SolidBrush = New SolidBrush(Color.Black)
    Public gfx As Graphics
    Public CadenaPorEscribirEnLinea As String = ""
    Private WithEvents DocumentoAImprimir As New PrintDocument
    Public PaperHeight As Integer = 800 ' Impresora es 1170
    Public PaperWidth As Integer = 254 ' Impresora es 300
    Public Incremento As Integer = 0

    Public Property MaximoCaracter() As Integer
        Get
            Return CaracteresMaximos
        End Get
        Set(ByVal value As Integer)
            If (value <> CaracteresMaximosDescripcion) Then CaracteresMaximosDescripcion = value
        End Set
    End Property

    Public Property MaximoCaracterDescripcion() As Integer
        Get
            Return CaracteresMaximosDescripcion
        End Get
        Set(ByVal value As Integer)
            If (value <> CaracteresMaximosDescripcion) Then CaracteresMaximosDescripcion = value
        End Set
    End Property

    Public Property TamanoLetra() As Integer
        Get
            Return TamanoDeLaFuente
        End Get
        Set(ByVal value As Integer)
            If (value <> TamanoDeLaFuente) Then TamanoDeLaFuente = value
        End Set
    End Property

    Public Property NombreLetra() As String
        Get
            Return NombreDeLaFuente
        End Get
        Set(ByVal value As String)
            If (value <> NombreDeLaFuente) Then NombreDeLaFuente = value
        End Set
    End Property

    Public Sub AnadirEspacio()
        Me.ListElement.Add("")
    End Sub

    Dim l As Integer = 0
    Dim lc As Integer = 0
    Dim list As List(Of String)

    Public Function ListString(ByVal linea As String, Optional ByVal maxChar As Integer = 0) As List(Of String)
        list = New List(Of String)
        Dim max As Integer = If(maxChar > 0, maxChar, MaximoCaracter())
        If linea.Length > max Then
            l = 0 : lc = linea.Length
            While (lc > max)
                CadenaPorEscribirEnLinea = linea.Substring(l, max)
                list.Add(CadenaPorEscribirEnLinea)
                l += max
                lc -= max
            End While
            CadenaPorEscribirEnLinea = linea
            list.Add(CadenaPorEscribirEnLinea.Substring(l, CadenaPorEscribirEnLinea.Length - l))
        Else
            list.Add(linea)
        End If
        Return list
    End Function

    Public Sub AnadirLineaCabeza(ByVal linea As String)
        For Each c In ListString(linea)
            ListElement.Add(c)
        Next
    End Sub

    Public Sub AnadirLineaSubcabeza(ByVal linea As String)
        For Each c In ListString(linea)
            ListElement.Add(c)
        Next
    End Sub

    Public Sub AnadirElemento(ByVal cantidad As String, ByVal elemento As String, ByVal precio As String)
        Dim NuevoElemento As OrdenarElementos = New OrdenarElementos()
        Dim temp As String = NuevoElemento.GenerarElemento(cantidad, elemento, precio)
        ListElement.Add(temp)
    End Sub

    Public Sub AnadirElementoTotal(ByVal Nombre As String, ByVal Valor As String)
        ListElement.Add(Nombre & AlineaTextoaLaDerecha(Nombre.Length + Valor.Length) & Valor)
    End Sub

    Public Sub DetalleSeparador()
        With ListElement
            AnadirEspacio()
            .Add(Linea1)
            .Add("*                                *")
            .Add("*     DETALLE DEL DOCUMENTO      *")
            .Add("*                                *")
            .Add(Linea1)
            AnadirEspacio()
        End With
    End Sub

    Public Sub AnadirTitulo(ByVal Titulo As String, ByVal SubTitulo As String, ByVal SubSubTitulo As String)
        With ListElement
            .Add(Linea4)
            .Add("•                                •")
            .Add(Centrar(Titulo, "•", "•"))
            If SubTitulo.Trim() <> "" Then
                .Add(Centrar(SubTitulo, "•", "•"))
            End If
            If SubSubTitulo.Trim <> "" Then
                .Add(Centrar(SubSubTitulo, "•", "•"))
            End If
            .Add("•                                •")
            .Add(Linea4)
            AnadirEspacio()
        End With
    End Sub

    Public Function Linea1() As String
        Return ("**********************************")
    End Function
    Public Function Linea2() As String
        Return ("..................................")
    End Function
    Public Function Linea3() As String
        Return ("__________________________________")
    End Function

    Public Function Linea4() As String
        Return ("••••••••••••••••••••••••••••••••••")
    End Function

    Public Function Linea5() As String
        Return ("----------------------------------")
    End Function

    Public Function Linea6() As String
        Return ("==================================")
    End Function

    Public Function Centrar(ByVal Texto As String, ByVal Inicio As String, ByVal Final As String) As String
        Dim c As String = ""
        For i As Integer = 0 To ((Me.MaximoCaracter / 2) - Inicio.Length - Final.Length - (Texto.Length / 2))
            c += " "
        Next
        Return Inicio & c & Texto & If(Texto.Length Mod 2 = 0, c, If(c.Length > 0, c.Substring(1, c.Length - 1), c)) & Final
    End Function

    Public Function AlinearElementos(ByVal val1 As String, ByVal val2 As String)
        Return val1 & AlineaTextoaLaDerecha(val1.Length + val2.Length) & val2
    End Function

    Public Sub EncabezadoPredefinido(Optional ByVal TextoAdicional1 As String = "", Optional ByVal TextoAdicional2 As String = "")
        With ListElement
            .Add(Me.Linea4())
            .Add(Me.Centrar("", "•", "•"))
            'agregando nombre
            For Each c In ListString(Config.businessName, MaximoCaracter - 2)
                .Add(Me.Centrar(c, "•", "•"))
            Next
            'agregando direccion
            For Each c In ListString(Config.businessAddress, MaximoCaracter - 2)
                .Add(Me.Centrar(c, "•", "•"))
            Next

            .Add(Me.Centrar(Config.businessRUC, "•", "•"))
            .Add(Me.Centrar(Config.businessPhone1 & " / " & Config.businessPhone2 & " ", "•", "•"))
            .Add(Me.Centrar("", "•", "•"))
            .Add(Me.Linea4())
            .Add(Me.Centrar(TextoAdicional1, "•", "•"))
            .Add(Me.Centrar(TextoAdicional2, "•", "•"))
            .Add(Me.Linea4())
            AnadirEspacio()
        End With
    End Sub

    Public Sub AnadirElemento(ByVal linea As String)
        For Each c In ListString(linea)
            ListElement.Add(c)
        Next
    End Sub

    Public Sub AnadirElementoTotales(ByVal Precio As String, ByVal Cantidad As String, ByVal Total As String)
        If Precio.Length + Cantidad.Length + Total.Length < Me.MaximoCaracter Then
            If Precio.Length + Cantidad.Length + Total.Length <= 30 Then
                Dim c = ""
                If Precio.Length <= 10 Then
                    For i As Integer = 1 To 10 - Precio.Length
                        c += " "
                    Next
                    c = c & Precio
                Else
                    c = Precio & " "
                End If
                If Cantidad.Length <= 9 Then
                    For i As Integer = 1 To 9 - Cantidad.Length
                        c += " "
                    Next
                    c = c & Cantidad
                Else
                    c = Cantidad & " "
                End If
                If Total.Length <= 10 Then
                    For i As Integer = 1 To 10 - Total.Length
                        c += " "
                    Next
                    c = c & Total
                Else
                    c = Total
                End If
                ListElement.Add("     " & c)
            Else
                ListElement.Add(Precio & " " & Precio & " " & Total)
            End If
        Else
            ListElement.Add(Precio & " " & Precio & " " & Total)
        End If
    End Sub

    Public Sub AnadirTotal(ByVal Nombre As String, ByVal Precio As String)
        ListElement.Add(Nombre & AlineaTextoaLaDerecha(Nombre.Length + Precio.Length) & Precio)
    End Sub


    Public Sub AnadeLineaAlPie(ByVal linea As String)
        For Each c In ListString(linea)
            ListElement.Add(c)
        Next
    End Sub

    Private Function AlineaTextoaLaDerecha(ByVal Izquierda As Integer) As String
        Dim esp As String = ""
        For i As Integer = 1 To MaximoCaracter() - Izquierda
            esp += " "
        Next
        Return esp
    End Function


    Private Function DottedLine() As String
        Dim dotted As String = ""
        For i As Integer = 1 To MaximoCaracter()
            dotted += "="
        Next
        Return dotted
    End Function

    Public Function ImpresoraExistente(ByVal impresora As String) As Boolean
        For Each strPrinter As String In PrinterSettings.InstalledPrinters
            If impresora = strPrinter Then
                Return True
            End If
        Next strPrinter
        Return False
    End Function

    Public Sub ImprimeTicket(ByVal impresora As String)
        FuenteImpresa = New Font(NombreLetra, TamanoLetra, FontStyle.Regular)
        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
        DocumentoAImprimir.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("Personal", Me.PaperWidth, Me.PaperHeight)
        DocumentoAImprimir.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        DocumentoAImprimir.Print()
    End Sub

    Private Sub DocumentoAImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocumentoAImprimir.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        gfx = e.Graphics
        For i = Me.PosLine To Me.ListElement.Count - 1
            If Me.contador <= 70 Then
                gfx.DrawString(Me.ListElement.Item(i), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat)
                Me.contador += 1
                'Me.MaxLine += 1
                Me.PosLine += 1
            Else
                e.HasMorePages = True
                Me.contador = 0
                Exit For
            End If
        Next
        'Reiniciar
        If Not e.HasMorePages Then
            Me.PosLine = 0
            Me.contador = 0
        End If
    End Sub

    Public Sub DibujaEspacio()
        CadenaPorEscribirEnLinea = " "
        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
        contador += 1
    End Sub

    Private Function Renglon() As Double
        Return MargenSuperior + (contador * FuenteImpresa.GetHeight(gfx) + imageHeight)
    End Function

End Class
#End Region

#Region "Ordenar Elementos"
Public Class OrdenarElementos
    Public delimitador() As Char = " "

    Public Sub OrdenarElementos(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub
    Public Function ObtenerCantidadDeElementos(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(0)
    End Function
    Public Function ObtenerNombreElemento(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(1)
    End Function
    Public Function ObtenerPrecioElemento(ByVal orderItem As String) As String
        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(2)
    End Function
    Public Function GenerarElemento(ByVal cantidad As String, ByVal NombreElemento As String, ByVal Precio As String) As String
        Return cantidad + delimitador(0) + NombreElemento + delimitador(0) + Precio
    End Function
End Class
#End Region

#Region "Ordenar Totales"
Public Class OrdernarTotal
    Public delimitador() As Char = "+"
    Public Sub OrdernarTotal(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub
    Public Function ObtenerTotalNombre(ByVal totalItem As String) As String
        Dim delimitado() As String = totalItem.Split(delimitador)
        Return delimitado(0)
    End Function
    Public Function ObtenerTotalCantidad(ByVal totalItem As String) As String
        Dim delimitado() As String = totalItem.Split(delimitador)
        Return delimitado(1)
    End Function
    Public Function GenerarTotal(ByVal totalName As String, ByVal price As String) As String
        GenerarTotal = totalName + delimitador(0) + price
    End Function
End Class
#End Region