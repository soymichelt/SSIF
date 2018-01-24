Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmImprimirSalida
    Public idsalida As String
    Private Sub frmImprimirEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                Dim salida = db.Salidas.Where(Function(f) f.IDSALIDA = Me.idsalida).FirstOrDefault
                If Not salida Is Nothing Then
                    If salida.ANULADO = "N" Then
                        Dim rpt As New rptImprimirSalida
                        Config.CrystalTitle("SALIDA DE INVENTARIO", rpt)
                        rpt.SetDataSource((From sal In db.Salidas Join det In db.SalidasDetalles On sal.IDSALIDA Equals det.IDSALIDA Join ser In db.Series On sal.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where sal.IDSALIDA = Me.idsalida Select IDCOMPRA = sal.IDSALIDA, BODEGA = bod.N_BODEGA & " " & bod.DESCRIPCION, SERIE = ser.NOMBRE, sal.CONSECUTIVO, FECHA = sal.FECHASALIDA, N_EMPLEADO = sal.Empleado.N_TRABAJADOR, EMPLEADO = sal.Empleado.NOMBRES & " " & sal.Empleado.APELLIDOS, CONCEPTO = sal.OBSERVACION, pro.IDALTERNO, pro.DESCRIPCION, det.CANTIDAD, MONEDA = If(det.CMONEDA.Equals(Config.cordoba), "C$", "$ "), COSTOUNITARIO = det.COSTO, det.TOTAL, TOTAL_NETO = sal.TOTAL, REIMPRESION = If(sal.REIMPRESION.Equals("S"), "COPIA", "ORIGINAL")).ToList())
                        CrystalReportViewer1.ReportSource = rpt
                        If salida.REIMPRESION <> "S" Then
                            salida.REIMPRESION = "S" : db.Entry(salida).State = EntityState.Modified : db.SaveChanges()
                        End If
                    Else
                        MessageBox.Show("Error, No se puede imprimir esta Salida por que ha sido Anulada.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta Salida.")
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub frmImprimirEntrada_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class