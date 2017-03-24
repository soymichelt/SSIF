Module SESION
    'datos de la bodega
    Public bodega As String
    Public nom_bodega As String
    Public tazadecambio As Decimal
    Public iva As Decimal

    'objetos
    Public _Bodega As BODEGA
    Public _Taza As TAZA
    Public _Iva As IVA

    'datos de usuario
    Public Usuario As USUARIO
    Public Privilegios As New List(Of USUARIO_PRIVILEGIO)

    'datos del tema
    Public tema_ribon_dev As New DevComponents.DotNetBar.StyleManager
    Public tema_form_style_klik As New Klik.Windows.Forms.v1.Common.KStyleManager
    Public fondo_principal As New Color


    ''''''''''''''''''''''''''''''''''''''''''
    Public formato_fecha As String = "dd/MM/yyyy"
    Public formato_moneda As String = "#,##0.00"


    '''''''''''''''''''''''''''''''''''''''''
    Public nombre_empresa As String = "NOMBRE DE LA EMPRESA"
    Public direccion As String = ""
    Public RUC As String = ""
    Public telefono As String = ""
    Public fax As String = ""

    Public Sub MetodoPromedio(ByVal producto As PRODUCTO)
        Using db As New MODELODEDATOS
            If producto.EXISTENCIAS.Count > 0 Then
                Dim kardexs = From kar In db.KARDEXS Join exi In db.EXISTENCIAS On kar.IDEXISTENCIA Equals exi.IDEXISTENCIA Where exi.IDPRODUCTO = producto.IDPRODUCTO And kar.ACTIVO = "S" Select SALDO = kar.DEBER - kar.HABER
                Dim costo_promedio As Decimal = 0
                If kardexs.Count() > 0 Then
                    costo_promedio = kardexs.Sum() / producto.EXISTENCIAS.Sum(Function(f) f.BODEGA.ACTIVO = "S" And f.CANTIDAD + f.CONSIGNADO)
                End If
            End If
        End Using
    End Sub

    'impresora por defecto
    'Public impresora As String = "Microsoft XPS Document Writer"
    Public impresora As String = "Foxit Reader PDF Printer"

    Public cordoba As String = "C"
    Public dolar As String = "D"
End Module