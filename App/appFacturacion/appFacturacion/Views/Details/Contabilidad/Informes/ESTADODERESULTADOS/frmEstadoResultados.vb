Imports Sadara.Models.V1.Database
Imports Sadara.Models.V1.POCO
'Imports System.Data.Entity

Public Class frmEstadoResultados
    Dim ds_estadoderesultado As New List(Of ESTADODERESULTADOS)
    Dim estadoderesultado As New ESTADODERESULTADOS
    Dim band As Boolean = False
    Public Sub llenar(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, Optional ByVal bodegap As String = "")
        Try
            Using db As New CodeFirst
                Dim venta As Decimal = 0
                Dim desc_venta As Decimal = 0
                Dim iva_venta As Decimal = 0
                Dim costo_venta As Decimal = 0
                Dim ventas = From ven In db.Ventas Join ser In db.Series On ven.IDSERIE Equals ser.IDSERIE Where ven.ANULADO = "N" And ven.FECHAFACTURA >= fecha1 And ven.FECHAFACTURA <= fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) Select ven
                If Not ventas Is Nothing Then
                    If ventas.Count() > 0 Then
                        venta = ventas.Sum(Function(f) f.TOTAL_C) : desc_venta = ventas.Sum(Function(f) f.DESCUENTO_DIN_C) : iva_venta = ventas.Sum(Function(f) f.IVA_DIN_C) : costo_venta = ventas.Sum(Function(f) f.COSTO_TOTAL)
                    End If
                End If
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "   Ventas" : estadoderesultado.COLUMNA2 = (venta + desc_venta).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Ventas" : estadoderesultado.COLUMNA1 = desc_venta.ToString("(- #,##0.00 )") : ds_estadoderesultado.Add(estadoderesultado)

                Dim devolucion_venta As Decimal = 0
                Dim desc_devolucion_venta As Decimal = 0
                Dim iva_devolucion As Decimal = 0
                Dim devoluciones_ventas = From dev In db.VentasDevoluciones Join ser In db.Series On dev.IDSERIE Equals ser.IDSERIE Where dev.ANULADO = "N" And dev.FECHADEVOLUCION >= fecha1 And dev.FECHADEVOLUCION <= fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) Select dev
                If Not devoluciones_ventas Is Nothing Then
                    If devoluciones_ventas.Count() > 0 Then
                        devolucion_venta = devoluciones_ventas.Sum(Function(f) f.TOTAL_C) : desc_devolucion_venta = devoluciones_ventas.Sum(Function(f) f.DESCUENTO_DIN_C) : iva_devolucion = devoluciones_ventas.Sum(Function(f) f.IVA_DIN_C)
                    End If
                End If
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Devoluciones de Ventas" : estadoderesultado.COLUMNA1 = devolucion_venta.ToString("(- #,##0.00 )") : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Devoluciones de Ventas" : estadoderesultado.COLUMNA1 = desc_devolucion_venta.ToString("(+ #,##0.00 )") : estadoderesultado.COLUMNA2 = (desc_devolucion_venta - (desc_venta + devolucion_venta)).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "" : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "Total en Ventas" : estadoderesultado.COLUMNA3 = (venta - (devolucion_venta - desc_devolucion_venta)).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "" : ds_estadoderesultado.Add(estadoderesultado)
                Dim venta_credito As Decimal = 0
                Dim desc_venta_credito As Decimal = 0
                Dim costo_venta_credito As Decimal = 0
                Dim iva_venta_credito As Decimal = 0
                ventas = ventas.Where(Function(f) f.CREDITO)
                If Not ventas Is Nothing Then
                    If ventas.Count() > 0 Then
                        venta_credito = ventas.Sum(Function(f) f.TOTAL_C) : desc_venta_credito = ventas.Sum(Function(f) f.DESCUENTO_DIN_C) : iva_venta_credito = ventas.Sum(Function(f) f.IVA_DIN_C) : costo_venta_credito = ventas.Sum(Function(f) f.COSTO_TOTAL)
                    End If
                End If
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "   Ventas de Crédito" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = (venta_credito + desc_venta_credito).ToString("(- #,##0.00 )") : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Ventas de Crédito" : estadoderesultado.COLUMNA1 = desc_devolucion_venta.ToString("(+ #,##0.00 )") : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)

                Dim recibo_venta As Decimal = 0
                Dim desc_recibo_venta As Decimal = 0
                Dim recibos_ventas = From rec In db.VentasRecibos Join ser In db.Series On rec.IDSERIE Equals ser.IDSERIE Where rec.ANULADO = "N" And rec.FECHARECIBO >= fecha1 And rec.FECHARECIBO <= fecha2 And ser.Bodega.IDBODEGA.Contains(bodegap) Select rec
                If Not recibos_ventas Is Nothing Then
                    If recibos_ventas.Count() > 0 Then
                        recibo_venta = recibos_ventas.Sum(Function(f) f.MONTOTOTAL_C) : desc_recibo_venta = recibos_ventas.Sum(Function(f) f.DESCUENTOTOTAL_C)
                    End If
                End If
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Abonos de Ventas de Crédito" : estadoderesultado.COLUMNA1 = recibo_venta.ToString("(+ #,##0.00 )") : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Abonos de Ventas de Crédito" : estadoderesultado.COLUMNA1 = desc_recibo_venta.ToString("(- #,##0.00 )") : estadoderesultado.COLUMNA2 = ((desc_devolucion_venta + recibo_venta) - desc_recibo_venta).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "Total en Ventas de Crédito" : estadoderesultado.COLUMNA3 = (recibo_venta - desc_recibo_venta - venta_credito).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "" : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "Ventas Netas" : estadoderesultado.COLUMNA4 = (venta - (devolucion_venta - desc_devolucion_venta) + (recibo_venta - desc_recibo_venta - venta_credito)).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "" : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "Costo de Venta" : estadoderesultado.COLUMNA4 = (costo_venta - costo_venta_credito).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "" : ds_estadoderesultado.Add(estadoderesultado)
                estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "Impuesto al Valor Agregado 15% (I.V.A)" : estadoderesultado.COLUMNA4 = (iva_venta - iva_devolucion - iva_venta_credito).ToString(Config.f_m) : ds_estadoderesultado.Add(estadoderesultado)
                Dim rpt As New rptEstadoderesultados
                Dim band As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.Section2.ReportObjects("txtPeriodo") : band.Text = "Período: Del " & fecha1.ToLongDateString() & " Al " & fecha2.ToLongDateString()
                If bodegap.Trim() <> "" Then
                    band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = ""
                Else
                    band = rpt.Section2.ReportObjects("txtSucursal") : band.Text = "%Todos%"
                End If
                band = rpt.Section4.ReportObjects("txtUtilidad") : band.Text = ((venta - (devolucion_venta - desc_devolucion_venta) + (recibo_venta - desc_recibo_venta - venta_credito)) - (iva_venta - iva_devolucion - iva_venta_credito) - (costo_venta - costo_venta_credito)).ToString(Config.f_m)
                rpt.SetDataSource(Me.ds_estadoderesultado)
                CrystalReportViewer1.ReportSource = rpt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error," & ex.Message)
        End Try
    End Sub

    Private Sub frmEstadoResultados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaInicial.Value = DateTime.Parse("01/01/" & DateTime.Now.Year.ToString())
        dtpFechaFinal.Value = DateTime.Parse("31/12/" & DateTime.Now.Year.ToString())
        CrystalReportViewer1.ReportSource = Nothing
    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged, dtpFechaFinal.ValueChanged
        llenar(Date.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), Date.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"))
    End Sub

    Private Sub frmEstadoResultados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        llenar(Date.Parse(dtpFechaInicial.Value.ToShortDateString() & " 00:00:00"), Date.Parse(dtpFechaFinal.Value.ToShortDateString() & " 23:59:59"))
    End Sub
End Class


'Dim compra As Decimal = 0
'Dim desc_compra As Decimal = 0
'Dim compras = From com In db.COMPRAS Join ser In db.SERIES On com.IDSERIE Equals ser.IDSERIE Where com.ANULADO = "N" And com.FECHACOMPRA >= fecha1 And com.FECHACOMPRA <= fecha2 And ser.BODEGA.IDBODEGA.Contains(bodegap) Select com
'If Not compras Is Nothing Then
'    If compras.Count() > 0 Then
'        compra = compras.Sum(Function(f) f.TOTAL) : desc_compra = compras.Sum(Function(f) f.DESCUENTO_DIN)
'    End If
'End If
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "   Compras" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = (compra + desc_compra).ToString(SESION.formato_moneda) : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Compras" : estadoderesultado.COLUMNA1 = desc_compra.ToString("(- #,##0.00 )") : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)

'Dim devolucion_compra As Decimal = 0
'Dim desc_devolucion_compra As Decimal = 0
'Dim devoluciones_compras = From dev In db.COMPRAS_DEVOLUCIONES Join ser In db.SERIES On dev.IDSERIE Equals ser.IDSERIE Where dev.ANULADO = "N" And dev.FECHADEVOLUCION >= fecha1 And dev.FECHADEVOLUCION <= fecha2 And ser.BODEGA.IDBODEGA.Contains(bodegap) Select dev
'If Not devoluciones_compras Is Nothing Then
'    If devoluciones_compras.Count() > 0 Then
'        devolucion_compra = devoluciones_compras.Sum(Function(f) f.TOTAL) : desc_devolucion_compra = devoluciones_compras.Sum(Function(f) f.DESCUENTO_DIN)
'    End If
'End If
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Devoluciones de Compras" : estadoderesultado.COLUMNA1 = devolucion_compra.ToString("(- #,##0.00 )") : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Devoluciones de Compras" : estadoderesultado.COLUMNA1 = desc_devolucion_compra.ToString("(+ #,##0.00 )") : estadoderesultado.COLUMNA2 = (desc_devolucion_compra - (desc_venta + devolucion_compra)).ToString(SESION.formato_moneda) : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)

'Dim compra_credito As Decimal = 0
'Dim desc_compra_credito As Decimal = 0
'compras = compras.Where(Function(f) f.CREDITO And f.SALDOCREDITO IsNot Nothing)
'If Not compras Is Nothing Then
'    If compras.Count() > 0 Then
'        compra_credito = compras.Sum(Function(f) f.TOTAL) : desc_compra_credito = compras.Sum(Function(f) f.DESCUENTO_DIN)
'    End If
'End If
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "   Compras de Crédito" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = (compra_credito + desc_compra_credito).ToString("(- #,##0.00 )") : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Comopras de Crédito" : estadoderesultado.COLUMNA1 = desc_devolucion_compra.ToString("(+ #,##0.00 )") : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)

'Dim recibo_compra As Decimal = 0
'Dim desc_recibo_compra As Decimal = 0
'Dim recibos_compras = From rec In db.COMPRAS_RECIBOS Join ser In db.SERIES On rec.IDSERIE Equals ser.IDSERIE Where rec.ANULADO = "N" And rec.FECHARECIBO >= fecha1 And rec.FECHARECIBO <= fecha2 And ser.BODEGA.IDBODEGA.Contains(bodegap) Select rec
'If Not recibos_compras Is Nothing Then
'    If recibos_compras.Count() > 0 Then
'        recibo_compra = recibos_compras.Sum(Function(f) f.MONTOTOTAL) : desc_recibo_compra = recibos_compras.Sum(Function(f) f.DESCUENTOTOTAL)
'    End If
'End If
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Abonos de Compras de Crédito" : estadoderesultado.COLUMNA1 = recibo_compra.ToString("(+ #,##0.00 )") : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "      Descuentos de Abonos de Compras de Crédito" : estadoderesultado.COLUMNA1 = desc_recibo_compra.ToString("(- #,##0.00 )") : estadoderesultado.COLUMNA2 = ((desc_devolucion_compra + recibo_compra) - desc_recibo_compra).ToString(SESION.formato_moneda) : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "Compras Netas" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = (compra - (devolucion_compra - desc_devolucion_compra) + (recibo_compra - desc_recibo_compra - compra_credito)).ToString(SESION.formato_moneda) : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)

'Dim entrada As Decimal = 0
'Dim entradas = From ent In db.ENTRADAS Join ser In db.SERIES On ent.IDSERIE Equals ser.IDSERIE Where ent.ANULADO = "N" And ent.FECHAENTRADA >= fecha1 And ent.FECHAENTRADA <= fecha2 And ser.BODEGA.IDBODEGA.Contains(bodegap) Select ent
'If Not entradas Is Nothing Then
'    If entradas.Count() > 0 Then
'        entrada = entradas.Sum(Function(f) f.TOTAL)
'    End If
'End If
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "   Entradas por Ajuste de Inventario" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = entrada.ToString(SESION.formato_moneda) : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)

'Dim salida As Decimal = 0
'Dim salidas = From sal In db.SALIDAS Join ser In db.SERIES On sal.IDSERIE Equals ser.IDSERIE Where sal.ANULADO = "N" And sal.FECHASALIDA >= fecha1 And sal.FECHASALIDA <= fecha2 And ser.BODEGA.IDBODEGA.Contains(bodegap) Select sal
'If Not salidas Is Nothing Then
'    If salidas.Count() > 0 Then
'        salida = salidas.Sum(Function(f) f.TOTAL)
'    End If
'End If
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "   Salidas por Ajuste de Inventario" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = salida.ToString(SESION.formato_moneda) : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "Totales de Ajustes de Inventario" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = (entrada - salida).ToString(SESION.formato_moneda) : ds_estadoderesultado.Add(estadoderesultado)
'estadoderesultado = New ESTADODERESULTADOS : estadoderesultado.CUENTA = "" : estadoderesultado.COLUMNA1 = "" : estadoderesultado.COLUMNA2 = "" : estadoderesultado.COLUMNA3 = "" : ds_estadoderesultado.Add(estadoderesultado)