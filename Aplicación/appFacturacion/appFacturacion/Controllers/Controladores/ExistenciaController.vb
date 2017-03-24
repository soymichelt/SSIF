Namespace Capadenegocio.Controller
    Public Class ExistenciaController
        Dim db As New CodeFirst

        Public Function BuscarProductoPorId(ByVal Id As String) As Existencia
            db = New CodeFirst()
            Return db.Existencias.Where(Function(f) f.IDEXISTENCIA = Id And f.Producto.ACTIVO = "S").FirstOrDefault()
        End Function

        Public Function BuscarProductoPorCodigo(ByVal IdAlterno As String, ByVal IdBodega As String) As Existencia
            db = New CodeFirst()
            Return db.Existencias.Where(Function(f) f.Producto.IDALTERNO = IdAlterno And f.IDBODEGA = IdBodega And f.Producto.ACTIVO = "S").FirstOrDefault()
        End Function

        Public Sub Dispose()
            db.Dispose()
        End Sub
    End Class
End Namespace