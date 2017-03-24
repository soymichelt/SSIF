Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index(Optional ByVal IdAlterno As String = "", Optional ByVal IdOriginal As String = "", Optional ByVal Descripcion As String = "", Optional ByVal Aplicacion As String = "") As ActionResult
        ViewData("Message") = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC."
        Dim sproducto As New ServicioProducto.ProductoClient
        'For Each c In sproducto.Listado(IdAlterno:=IdAlterno, IdOriginal:=IdOriginal, Descripcion:=Descripcion, Aplicacion:=Aplicacion)
        '    Dim prueba As String = "michel"
        '    prueba = c.IdAlterno
        '    Response.Write(prueba)
        'Next
        ViewData("Productos") = sproducto.Listado(IdAlterno:=IdAlterno, IdOriginal:=IdOriginal, Descripcion:=Descripcion, Aplicacion:=Aplicacion).ToList()
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Página de descripción de la aplicación."
        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Página de contacto."
        Return View()
    End Function
End Class
