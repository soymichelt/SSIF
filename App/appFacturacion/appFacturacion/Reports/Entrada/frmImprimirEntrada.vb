Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
Imports System.Data.Entity

Public Class frmImprimirEntrada

    Public identrada As String

    Private Async Sub frmImprimirEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Await Log.Instance.RegisterActivity(
            If(Config.currentBusiness IsNot Nothing, Config.currentBusiness.IdEmpresa, Guid.Empty),
            "ProductEntryPrintReport",
            "Load",
            "Load ProductEntryPrintReport",
            userId:=If(Config.currentUser IsNot Nothing, Guid.Parse(Config.currentUser.IDUsuario), Nothing)
        )

        Try
            Using db As New CodeFirst
                Dim entrada = db.Entradas.Where(Function(f) f.IDENTRADA = Me.identrada).FirstOrDefault
                If Not entrada Is Nothing Then
                    If entrada.ANULADO = "N" Then
                        Dim rpt As New rptImprimirEntrada
                        Config.CrystalTitle("ENTRADA DE INVENTARIO", rpt)
                        rpt.SetDataSource((From ent In db.Entradas Join det In db.EntradasDetalles On ent.IDENTRADA Equals det.IDENTRADA Join ser In db.Series On ent.IDSERIE Equals ser.IDSERIE Join exi In db.Existencias On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.Productos On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.Bodegas On exi.IDBODEGA Equals bod.IDBODEGA Where ent.IDENTRADA = Me.identrada Select IDCOMPRA = ent.IDENTRADA, BODEGA = bod.N_BODEGA & " " & bod.DESCRIPCION, SERIE = ser.NOMBRE, ent.CONSECUTIVO, FECHA = ent.FECHAENTRADA, N_EMPLEADO = ent.Empleado.N_TRABAJADOR, EMPLEADO = ent.Empleado.NOMBRES & " " & ent.Empleado.APELLIDOS, CONCEPTO = ent.OBSERVACION, pro.IDALTERNO, pro.DESCRIPCION, det.CANTIDAD, MONEDA = If(det.CMONEDA.Equals(Config.cordoba), "C$", "$ "), COSTOUNITARIO = det.COSTO, det.TOTAL, TOTAL_NETO = ent.TOTAL, REIMPRESION = If(ent.REIMPRESION.Equals("S"), "COPIA", "ORIGINAL")).ToList())
                        CrystalReportViewer1.ReportSource = rpt
                        If entrada.REIMPRESION <> "S" Then
                            entrada.REIMPRESION = "S" : db.Entry(entrada).State = EntityState.Modified : db.SaveChanges()
                        End If
                    Else
                        MessageBox.Show("Error, No se puede imprimir esta Entrada por que ha sido Anulada.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra esta Entrada.")
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