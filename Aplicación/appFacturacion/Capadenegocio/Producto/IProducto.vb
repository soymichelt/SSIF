Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IProducto" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface IProducto

    <OperationContract()>
    Function Listado(ByVal IdAlterno As String, ByVal IdOriginal As String, ByVal Descripcion As String, ByVal Aplicacion As String) As List(Of CatalogoProducto)

    <OperationContract()>
    Function Nuevo() As Boolean
End Interface