Imports CapaDeDatosORM
' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Producto" en el código, en svc y en el archivo de configuración a la vez.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Producto.svc o Producto.svc.vb en el Explorador de soluciones e inicie la depuración.
Public Class Producto
    Implements IProducto
    Dim db As MODELODEDATOS

    Public Function Listado(ByVal IdAlterno As String, ByVal IdOriginal As String, ByVal Descripcion As String, ByVal Aplicacion As String) As List(Of CatalogoProducto) Implements IProducto.Listado
        Try
            Using db As New MODELODEDATOS
                Return (From pro In db.PRODUCTOS Join mar In db.MARCAS On pro.IDMARCA Equals mar.IDMARCA Join uni In db.UNIDADES_DE_MEDIDAS On pro.IDUNIDAD Equals uni.IDUNIDAD Join pre In db.PRESENTACIONES On pro.IDPRESENTACION Equals pre.IDPRESENTACION Join lab In db.LABORATORIOS On pro.IDLABORATORIO Equals lab.IDLABORATORIO Where pro.ACTIVO = "S" Select New CatalogoProducto With {.IdProducto = pro.IDPRODUCTO, .IdAlterno = pro.IDALTERNO, .IdOriginal = pro.IDORIGINAL, .Descripcion = pro.DESCRIPCION, .Marca = If(mar.ACTIVO.Equals("S"), mar.DESCRIPCION, "SIN ESPECIFICAR"), .Modelo = pro.MODELO, .Aplicacion = pro.APLICACION, .Observacion = pro.OBSERVACION, .UnidadDeMedida = If(uni.ACTIVO.Equals("S"), uni.DESCRIPCION, "SIN ESPECIFICAR"), .Contiene = pro.CONTIENE, .Presentacion = If(pre.ACTIVO.Equals("S"), pre.DESCRIPCION, "SIN ESPECIFICAR"), .Laboratorio = If(lab.ACTIVO.Equals("S"), lab.DESCRIPCION, "SIN ESPECIFICAR"), .Precio1 = pro.PRECIO1, .Precio2 = pro.PRECIO2, .Precio3 = pro.PRECIO3, .Precio4 = pro.PRECIO4, .ImageName = pro.IMAGENAME, .Iva = pro.IVA}).ToList()
            End Using
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Nuevo() As Boolean Implements IProducto.Nuevo
        Using db As New CapaDeDatosORM.MODELODEDATOS
            Return True
        End Using
    End Function

End Class