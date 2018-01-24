'Imports System.ComponentModel
'Imports System.Windows.Forms
'Imports System.Drawing
'Imports System.Drawing.Printing
'Imports System.IO

'Public Class TicketClass
'    Public LineasDeLaCabeza As ArrayList = New ArrayList()
'    Public LineasDeLaSubCabeza As ArrayList = New ArrayList()
'    Public Elementos As ArrayList = New ArrayList()
'    Public Totales As ArrayList = New ArrayList()
'    Public LineasDelPie As ArrayList = New ArrayList()
'    Private headerImagep As Image

'    Public contador As Integer = 0
'    Public MaxLine As Integer = 70
'    Public PosLine As Integer = 0

'    Public CaracteresMaximos As Integer = 34
'    Public CaracteresMaximosDescripcion As Integer = 34

'    Public imageHeight As Integer = 0

'    Public MargenIzquierdo As Double = 2
'    Public MargenSuperior As Double = 2

'    Public NombreDeLaFuente As String = "Lucida Console"
'    Public TamanoDeLaFuente As Integer = 8

'    Public FuenteImpresa As Font
'    Public ColorDeLaFuente As SolidBrush = New SolidBrush(Color.Black)

'    Public gfx As Graphics

'    Public CadenaPorEscribirEnLinea As String = ""
'    Private WithEvents DocumentoAImprimir As New PrintDocument

'    Public PaperHeight As Integer = 1300
'    Public PaperWidth As Integer = 450
'    Public Incremento As Integer = 400

'    Public Sub Ticket()



'    End Sub

'    Public Property HeaderImage() As Image
'        Get
'            Return headerImagep
'        End Get
'        Set(ByVal value As Image)
'            'If headerImagep.Width <> value.Width Then 

'            'End If 
'            headerImagep = value
'        End Set
'    End Property



'    Public Property MaximoCaracter() As Integer
'        Get
'            Return CaracteresMaximos
'        End Get
'        Set(ByVal value As Integer)
'            If (value <> CaracteresMaximosDescripcion) Then CaracteresMaximosDescripcion = value
'        End Set
'    End Property



'    Public Property MaximoCaracterDescripcion() As Integer
'        Get
'            Return CaracteresMaximosDescripcion
'        End Get
'        Set(ByVal value As Integer)
'            If (value <> CaracteresMaximosDescripcion) Then CaracteresMaximosDescripcion = value
'        End Set
'    End Property



'    Public Property TamanoLetra() As Integer
'        Get
'            Return TamanoDeLaFuente
'        End Get
'        Set(ByVal value As Integer)
'            If (value <> TamanoDeLaFuente) Then TamanoDeLaFuente = value
'        End Set
'    End Property


'    Public Property NombreLetra() As String
'        Get
'            Return NombreDeLaFuente
'        End Get
'        Set(ByVal value As String)
'            If (value <> NombreDeLaFuente) Then NombreDeLaFuente = value
'        End Set
'    End Property


'    Public Sub AnadirLineaCabeza(ByVal linea As String)
'        LineasDeLaCabeza.Add(linea)
'    End Sub

'    Public Sub AnadirLineaSubcabeza(ByVal linea As String)
'        LineasDeLaSubCabeza.Add(linea)
'    End Sub

'    Public Sub AnadirElemento(ByVal cantidad As String, ByVal elemento As String, ByVal precio As String)

'        Dim NuevoElemento As OrdenarElementos = New OrdenarElementos()
'        '''''items.Add(newitem. 
'        Dim temp As String = NuevoElemento.GenerarElemento(cantidad, elemento, precio)
'        Elementos.Add(temp)
'    End Sub

'    Public Sub AnadirElemento(ByVal elemento As String)
'        Elementos.Add(elemento)
'    End Sub

'    Public Sub AnadirTotal(ByVal Nombre As String, ByVal Precio As String)
'        Dim NuevoTotal As OrdernarTotal = New OrdernarTotal
'        ' OrderTotal(newtotal)
'        Totales.Add(NuevoTotal.GenerarTotal(Nombre, Precio))
'    End Sub

'    Public Sub AnadeLineaAlPie(ByVal linea As String)
'        LineasDelPie.Add(linea)
'    End Sub

'    Private Function AlineaTextoaLaDerecha(ByVal Izquierda As Integer) As String

'        Dim espacios As String = ""
'        'Dim spaces As Integer = MaximoCaracter() - Izquierda
'        For i As Integer = 1 To MaximoCaracter() - Izquierda
'            espacios += " "
'        Next
'        Return espacios
'    End Function

'    Private Function DottedLine() As String

'        Dim dotted As String = ""
'        'Dim x As Integer
'        'For x = 1 To MaximoCaracter()
'        '    dotted += "="
'        'Next
'        For i As Integer = 1 To MaximoCaracter()
'            dotted += "="
'        Next
'        Return dotted
'    End Function
'    Public Function ImpresoraExistente(ByVal impresora As String) As Boolean

'        For Each strPrinter As String In PrinterSettings.InstalledPrinters

'            If impresora = strPrinter Then
'                Return True
'            End If
'        Next strPrinter
'        Return False
'    End Function

'    Public Sub ImprimeTicket(ByVal impresora As String)
'        FuenteImpresa = New Font(NombreLetra, TamanoLetra, FontStyle.Regular)
'        DocumentoAImprimir.PrinterSettings.PrinterName = impresora
'        DocumentoAImprimir.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("Personal", Me.PaperWidth, Me.PaperHeight)
'        DocumentoAImprimir.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
'        DocumentoAImprimir.Print()
'    End Sub

'    Public Sub VistaPrevia()
'        Dim ptrPreview As New PrintPreviewDialog
'        ptrPreview.Document = DocumentoAImprimir
'        ptrPreview.Text = "Previsualizar Factura"
'        ptrPreview.ShowDialog()
'    End Sub

'    Private Sub DocumentoAImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocumentoAImprimir.PrintPage
'        e.Graphics.PageUnit = GraphicsUnit.Millimeter
'        gfx = e.Graphics

'        'DrawImage()
'        DibujaLaCabecera()
'        'DibujaEspacio()
'        DibujaLaSubCabecera()
'        'DibujaEspacio()
'        DibujaElementos()
'        'DibujaEspacio()
'        DibujaTotales()
'        DibujarPieDePagina()
'        'If (headerImagep.Width <> 0) Then
'        ' HeaderImage.Dispose()
'        'End If
'    End Sub

'    Private Function Renglon() As Double
'        Return MargenSuperior + (contador * FuenteImpresa.GetHeight(gfx) + imageHeight)
'    End Function

'    Private Sub DrawImage()
'        If (headerImagep.Width <> 0) Then
'            Try
'                gfx.DrawImage(HeaderImage, New Point(CInt(MargenIzquierdo), CInt(Renglon())))
'                Dim height As Double = (HeaderImage.Height / 58) * 15
'                imageHeight = CInt(Math.Round(height) + 3)
'            Catch ex As Exception

'            End Try
'        End If
'    End Sub

'    Private Sub DibujaLaCabecera()
'        For Each Cabecera As String In LineasDeLaCabeza
'            If Me.MaxLine > 0 Then
'                If (Cabecera.Length > MaximoCaracter()) Then
'                    Dim CaracterActual As Integer = 0
'                    Dim LongitudDeCabecera As Integer = Cabecera.Length
'                    While (LongitudDeCabecera > MaximoCaracter())
'                        CadenaPorEscribirEnLinea = Cabecera.Substring(CaracterActual, MaximoCaracter)
'                        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                        contador += 1
'                        CaracterActual += MaximoCaracter()
'                        LongitudDeCabecera -= MaximoCaracter()
'                    End While
'                    CadenaPorEscribirEnLinea = Cabecera
'                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                    contador += 1

'                    Me.MaxLine -= 1
'                Else
'                    CadenaPorEscribirEnLinea = Cabecera
'                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                    contador += 1

'                    Me.MaxLine -= 1
'                End If
'            Else
'                Me.MaxLine = 70
'                'DocumentoAImprimir.Print()
'            End If
'            'DibujaEspacio()
'        Next Cabecera
'        DibujaEspacio()
'    End Sub

'    Private Sub DibujaLaSubCabecera()

'        For Each SubCabecera As String In LineasDeLaSubCabeza

'            If (SubCabecera.Length > MaximoCaracter()) Then

'                Dim CaracterActual As Integer = 0
'                Dim LongitudSubcabecera As Integer = SubCabecera.Length

'                While (LongitudSubcabecera > MaximoCaracter())

'                    CadenaPorEscribirEnLinea = SubCabecera
'                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                    contador += 1
'                    CaracterActual += MaximoCaracter()
'                    LongitudSubcabecera -= MaximoCaracter()
'                End While
'                CadenaPorEscribirEnLinea = SubCabecera
'                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                contador += 1
'                'CadenaPorEscribirEnLinea = DottedLine()
'                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                'contador += 1
'            Else
'                CadenaPorEscribirEnLinea = SubCabecera
'                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                contador += 1
'                'CadenaPorEscribirEnLinea = DottedLine()
'                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                'contador += 1
'            End If
'            'DibujaEspacio()
'        Next SubCabecera
'        DibujaEspacio()
'    End Sub

'    Private Sub DibujaElementos()

'        Dim OrdenElemento As OrdenarElementos = New OrdenarElementos()
'        gfx.DrawString("**********************************", FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'        contador += 1
'        gfx.DrawString("*                                *", FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'        contador += 1
'        gfx.DrawString("*      DETALLE DEL DOCUMENTO     *", FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'        contador += 1
'        gfx.DrawString("*                                *", FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'        contador += 1
'        gfx.DrawString("**********************************", FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'        contador += 1
'        DibujaEspacio()

'        For Each Elemento As String In Elementos
'            gfx.DrawString(Elemento, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'            contador += 1
'            'CadenaPorEscribirEnLinea = OrdenElemento.ObtenerCantidadDeElementos(Elemento)

'            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'            'CadenaPorEscribirEnLinea = OrdenElemento.ObtenerPrecioElemento(Elemento)
'            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea

'            'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

'            'Dim Nombre As String = OrdenElemento.ObtenerNombreElemento(Elemento)

'            'MargenIzquierdo = 10
'            'If (Nombre.Length > MaximoCaracterDescripcion) Then

'            '    Dim CaracterActual As Integer = 0
'            '    Dim LongitudElemento As Integer = Nombre.Length

'            '    While (LongitudElemento > MaximoCaracterDescripcion)

'            '        CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
'            '        gfx.DrawString(" " + CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracterDescripcion), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

'            '        contador += 1
'            '        CaracterActual += MaximoCaracterDescripcion
'            '        LongitudElemento -= MaximoCaracterDescripcion
'            '    End While

'            '    CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
'            '    gfx.DrawString(" " + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon() + 10, New StringFormat())
'            '    contador += 1

'            'Else

'            '    gfx.DrawString(" " + OrdenElemento.ObtenerNombreElemento(Elemento), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

'            '    contador += 1
'            'End If
'            'DibujaEspacio()
'        Next Elemento

'        'MargenIzquierdo = 10
'        'CadenaPorEscribirEnLinea = DottedLine()

'        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

'        contador += 1
'        DibujaEspacio()
'    End Sub
'    Private Sub DibujaTotales()
'        Dim ordTot As OrdernarTotal = New OrdernarTotal()
'        For Each total As String In Totales
'            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalCantidad(total)
'            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea
'            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'            CadenaPorEscribirEnLinea = ordTot.ObtenerTotalNombre(total)
'            gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'            contador += 1
'            'DibujaEspacio()
'        Next total
'        DibujaEspacio()
'    End Sub

'    Private Sub DibujarPieDePagina()
'        For Each PieDePagina As String In LineasDelPie
'            If (PieDePagina.Length > MaximoCaracter()) Then
'                Dim currentChar As Integer = 0
'                Dim LongitudPieDePagina As Integer = PieDePagina.Length
'                While (LongitudPieDePagina > MaximoCaracter())
'                    CadenaPorEscribirEnLinea = PieDePagina
'                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                    contador += 1
'                    currentChar += MaximoCaracter()
'                    LongitudPieDePagina -= MaximoCaracter()
'                End While
'                CadenaPorEscribirEnLinea = PieDePagina
'                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, CadenaPorEscribirEnLinea.Length - currentChar), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                contador += 1
'            Else
'                CadenaPorEscribirEnLinea = PieDePagina
'                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
'                contador += 1
'            End If
'            DibujaEspacio()
'        Next PieDePagina
'        DibujaEspacio()
'    End Sub

'    Public Sub DibujaEspacio()

'        CadenaPorEscribirEnLinea = " "

'        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

'        contador += 1

'    End Sub

'    Public Sub New()

'    End Sub


'End Class




'Public Class OrdenarElementos

'    Public delimitador() As Char = " "


'    Public Sub OrdenarElementos(ByVal delimit As Char)
'        Dim delimitador As Char = delimit
'    End Sub


'    Public Function ObtenerCantidadDeElementos(ByVal orderItem As String) As String

'        Dim delimitado() As String = orderItem.Split(delimitador)
'        Return delimitado(0)
'    End Function

'    Public Function ObtenerNombreElemento(ByVal orderItem As String) As String

'        Dim delimitado() As String = orderItem.Split(delimitador)
'        Return delimitado(1)
'    End Function

'    Public Function ObtenerPrecioElemento(ByVal orderItem As String) As String

'        Dim delimitado() As String = orderItem.Split(delimitador)
'        Return delimitado(2)
'    End Function

'    Public Function GenerarElemento(ByVal cantidad As String, ByVal NombreElemento As String, ByVal Precio As String) As String

'        Return cantidad + delimitador(0) + NombreElemento + delimitador(0) + Precio
'    End Function
'End Class




'Public Class OrdernarTotal

'    Public delimitador() As Char = "+"

'    Public Sub OrdernarTotal(ByVal delimit As Char)

'        Dim delimitador As Char = delimit
'    End Sub

'    Public Function ObtenerTotalNombre(ByVal totalItem As String) As String

'        Dim delimitado() As String = totalItem.Split(delimitador)
'        Return delimitado(0)

'    End Function
'    Public Function ObtenerTotalCantidad(ByVal totalItem As String) As String

'        Dim delimitado() As String = totalItem.Split(delimitador)
'        Return delimitado(1)
'    End Function

'    Public Function GenerarTotal(ByVal totalName As String, ByVal price As String) As String

'        GenerarTotal = totalName + delimitador(0) + price
'    End Function

'End Class