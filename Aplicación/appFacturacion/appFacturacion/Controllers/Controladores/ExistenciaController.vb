Namespace Capadenegocio.Controller
    Public Class ExistenciaController
        Dim db As New CodeFirst

        Public Function BuscarProductoPorId(ByVal Id As String) As EXISTENCIA
            db = New CodeFirst()
            Return db.EXISTENCIAS.Where(Function(f) f.IDEXISTENCIA = Id And f.PRODUCTO.ACTIVO = "S").FirstOrDefault()
        End Function

        Public Function BuscarProductoPorCodigo(ByVal IdAlterno As String, ByVal IdBodega As String) As EXISTENCIA
            db = New CodeFirst()
            Return db.EXISTENCIAS.Where(Function(f) f.PRODUCTO.IDALTERNO = IdAlterno And f.IDBODEGA = IdBodega And f.PRODUCTO.ACTIVO = "S").FirstOrDefault()
        End Function

        Public Sub Dispose()
            db.Dispose()
        End Sub
    End Class
End Namespace