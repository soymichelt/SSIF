Public Class frmImprimirEntrada
    Public identrada As String
    Private Sub frmImprimirEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                Dim entrada = db.ENTRADAS.Where(Function(f) f.IDENTRADA = Me.identrada).FirstOrDefault
                If Not entrada Is Nothing Then
                    If entrada.ANULADO = "N" Then
                        Dim rpt As New rptImprimirEntrada
                        Config.CrystalTitle("ENTRADA DE INVENTARIO", rpt)
                        rpt.SetDataSource((From ent In db.ENTRADAS Join det In db.DETALLES_ENTRADAS On ent.IDENTRADA Equals det.IDENTRADA Join ser In db.SERIES On ent.IDSERIE Equals ser.IDSERIE Join exi In db.EXISTENCIAS On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.PRODUCTOS On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod In db.BODEGAS On exi.IDBODEGA Equals bod.IDBODEGA Where ent.IDENTRADA = Me.identrada Select IDCOMPRA = ent.IDENTRADA, BODEGA = bod.N_BODEGA & " " & bod.DESCRIPCION, SERIE = ser.NOMBRE, ent.CONSECUTIVO, FECHA = ent.FECHAENTRADA, N_EMPLEADO = ent.EMPLEADO.N_TRABAJADOR, EMPLEADO = ent.EMPLEADO.NOMBRES & " " & ent.EMPLEADO.APELLIDOS, CONCEPTO = ent.OBSERVACION, pro.IDALTERNO, pro.DESCRIPCION, det.CANTIDAD, MONEDA = If(det.CMONEDA.Equals(Config.cordoba), "C$", "$ "), COSTOUNITARIO = det.COSTO, det.TOTAL, TOTAL_NETO = ent.TOTAL, REIMPRESION = If(ent.REIMPRESION.Equals("S"), "COPIA", "ORIGINAL")).ToList())
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