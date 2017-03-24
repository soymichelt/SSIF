Namespace Capadenegocio.Controller
    Public Class ProductoController
        Dim db As New CodeFirst

        Public Function BuscarPorId(ByVal Id As String) As Producto
            Return db.Productos.Where(Function(f) f.IDPRODUCTO = Id And f.ACTIVO = "S").FirstOrDefault()
        End Function

        Public Function BuscarPorCodigo(ByVal IdAlterno As String) As Producto
            Return db.Productos.Where(Function(f) f.IDALTERNO = IdAlterno And f.ACTIVO = "S").FirstOrDefault()
        End Function

        Public Function Lista(Optional ByVal Codigo As String = "", Optional ByVal Descripcion As String = "", Optional ByVal Aplicacion As String = "", Optional ByVal IdOriginal As String = "")
            Return db.Productos.Where(Function(f) f.ACTIVO = "S" And f.IDALTERNO.Contains(Codigo) And f.DESCRIPCION.Contains(Descripcion) And f.APLICACION.Contains(Aplicacion) And f.IDORIGINAL.Contains(IdOriginal))
        End Function

    End Class
End Namespace