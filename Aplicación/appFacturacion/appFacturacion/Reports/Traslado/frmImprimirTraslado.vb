Public Class frmImprimirTraslado

    Public ID As String

    Private Sub frmImprimirEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                Dim traslado = db.TRASLADOS.Where(Function(f) f.IDTRASLADO = Me.ID).FirstOrDefault
                If Not traslado Is Nothing Then
                    If traslado.ANULADO = "N" Then
                        Dim rpt As New rptImprimirTraslado
                        Config.CrystalTitle("TRASLADO DE MERCANCÍA", rpt)
                        rpt.SetDataSource((From tra In db.TRASLADOS Join det In db.DETALLES_TRASLADOS On tra.IDTRASLADO Equals det.IDTRASLADO Join ser In db.SERIES On tra.IDSERIE Equals ser.IDSERIE Join exi In db.EXISTENCIAS On det.IDEXISTENCIA Equals exi.IDEXISTENCIA Join pro In db.PRODUCTOS On exi.IDPRODUCTO Equals pro.IDPRODUCTO Join bod_sal In db.BODEGAS On tra.IDBODEGA Equals bod_sal.IDBODEGA Join bod_ent In db.BODEGAS On bod_ent.IDBODEGA Equals exi.IDBODEGA Where tra.IDTRASLADO = Me.ID Select IDCOMPRA = tra.IDTRASLADO, BODEGA_SALE = bod_sal.N_BODEGA & " | " & bod_sal.DESCRIPCION, BODEGA_ENTRA = bod_ent.N_BODEGA & " | " & bod_ent.DESCRIPCION, SERIE = ser.NOMBRE, tra.CONSECUTIVO, FECHA = tra.FECHATRASLADO, N_EMPLEADO = tra.EMPLEADO.N_TRABAJADOR, EMPLEADO = tra.EMPLEADO.NOMBRES & " " & tra.EMPLEADO.APELLIDOS, tra.CONCEPTO, tra.REFERENCIA, pro.IDALTERNO, pro.DESCRIPCION, det.CANTIDAD, MONEDA = If(det.CMONEDA.Equals(Config.cordoba), "C$", "$ "), COSTOUNITARIO = det.COSTO, det.TOTAL, TOTAL_NETO = tra.TOTAL, REIMPRESION = If(tra.REIMPRESION.Equals("S"), "COPIA", "ORIGINAL")).ToList())
                        CrystalReportViewer1.ReportSource = rpt
                        If traslado.REIMPRESION <> "S" Then
                            traslado.REIMPRESION = "S" : db.Entry(traslado).State = EntityState.Modified : db.SaveChanges()
                        End If
                    Else
                        MessageBox.Show("Error, No se puede imprimir este Traslado por que ha sido Anulada.")
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra este Traslado.")
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