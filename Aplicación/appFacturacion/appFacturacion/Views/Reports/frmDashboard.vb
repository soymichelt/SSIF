Public Class frmDashboard 

    Public Function DatosVentasMensuales() As List(Of XYDiagramDTO)

        Dim lista As New List(Of XYDiagramDTO)

        'contexto db
        Using db As New CodeFirst

            'obteniendo datos


        End Using

        'retornando datos
        Return lista

    End Function

    Private Sub VentasMensuales()

        'try para controlar errores
        Try

            'definiendo listado de datos
            Dim Ventas = Me.DatosVentasMensuales()

        Catch ex As Exception

            'mensaje de error

        End Try

    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub







End Class