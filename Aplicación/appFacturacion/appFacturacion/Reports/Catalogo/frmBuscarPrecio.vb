Public Class frmBuscarPrecio
    Public idproducto As String
    Public taza As Decimal

    Public frm_return As Integer = 0
    Private Sub frmTipoPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Using db As New CodeFirst
                Dim p = db.Productos.Where(Function(f) f.IDPRODUCTO = Me.idproducto And f.ACTIVO = "S" And f.Marca.ACTIVO = "S").FirstOrDefault()
                If Not p Is Nothing Then
                    If p.MARGEN Then
                        If p.CMONEDA.Equals(Config.cordoba) Then
                            Dim costo As Decimal
                            costo = p.COSTO + (p.COSTO * p.PRECIO1 / 100)
                            lvPrecio.Items(0).SubItems.Add((costo / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(0).SubItems.Add(costo.ToString(Config.f_m))
                            costo = p.COSTO + (p.COSTO * p.PRECIO2 / 100)
                            lvPrecio.Items(1).SubItems.Add((costo / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(1).SubItems.Add(costo.ToString(Config.f_m))
                            costo = p.COSTO + (p.COSTO * p.PRECIO3 / 100)
                            lvPrecio.Items(2).SubItems.Add((costo / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(2).SubItems.Add(costo.ToString(Config.f_m))
                            costo = p.COSTO + (p.COSTO * p.PRECIO4 / 100)
                            lvPrecio.Items(3).SubItems.Add((costo / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(3).SubItems.Add(costo.ToString(Config.f_m))


                        Else
                            lvPrecio.Items(0).SubItems.Add(p.COSTO + ((p.COSTO * p.PRECIO1 / 100)).ToString(Config.f_m)) : lvPrecio.Items(0).SubItems.Add((Decimal.Parse(lvPrecio.Items(0).SubItems(1).Text) * Me.taza).ToString(Config.f_m))
                        lvPrecio.Items(1).SubItems.Add(p.COSTO + ((p.COSTO * p.PRECIO2 / 100)).ToString(Config.f_m)) : lvPrecio.Items(1).SubItems.Add((Decimal.Parse(lvPrecio.Items(1).SubItems(1).Text) * Me.taza).ToString(Config.f_m))
                        lvPrecio.Items(2).SubItems.Add(p.COSTO + ((p.COSTO * p.PRECIO3 / 100)).ToString(Config.f_m)) : lvPrecio.Items(2).SubItems.Add((Decimal.Parse(lvPrecio.Items(2).SubItems(1).Text) * Me.taza).ToString(Config.f_m))
                        lvPrecio.Items(3).SubItems.Add(p.COSTO + ((p.COSTO * p.PRECIO4 / 100)).ToString(Config.f_m)) : lvPrecio.Items(3).SubItems.Add((Decimal.Parse(lvPrecio.Items(3).SubItems(1).Text) * Me.taza).ToString(Config.f_m))
                    End If
                Else
                        If p.CMONEDA.Equals(Config.cordoba) Then
                            lvPrecio.Items(0).SubItems.Add((p.PRECIO1 / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(0).SubItems.Add((p.PRECIO1).ToString(Config.f_m))
                            lvPrecio.Items(1).SubItems.Add((p.PRECIO2 / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(1).SubItems.Add((p.PRECIO2).ToString(Config.f_m))
                            lvPrecio.Items(2).SubItems.Add((p.PRECIO3 / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(2).SubItems.Add((p.PRECIO3).ToString(Config.f_m))
                            lvPrecio.Items(3).SubItems.Add((p.PRECIO4 / Me.taza).ToString(Config.f_m)) : lvPrecio.Items(3).SubItems.Add((p.PRECIO4).ToString(Config.f_m))
                        Else
                            lvPrecio.Items(0).SubItems.Add((p.PRECIO1).ToString(Config.f_m)) : lvPrecio.Items(0).SubItems.Add((p.PRECIO1 * Me.taza).ToString(Config.f_m))
                            lvPrecio.Items(1).SubItems.Add((p.PRECIO2).ToString(Config.f_m)) : lvPrecio.Items(1).SubItems.Add((p.PRECIO2 * Me.taza).ToString(Config.f_m))
                            lvPrecio.Items(2).SubItems.Add((p.PRECIO3).ToString(Config.f_m)) : lvPrecio.Items(2).SubItems.Add((p.PRECIO3 * Me.taza).ToString(Config.f_m))
                            lvPrecio.Items(3).SubItems.Add((p.PRECIO4).ToString(Config.f_m)) : lvPrecio.Items(3).SubItems.Add((p.PRECIO4 * Me.taza).ToString(Config.f_m))
                        End If
                    End If
                Else
                    MessageBox.Show("Error, No se encuentra este producto. Probablemente ha sido eliminada.")
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
        If lvPrecio.Items.Count > 0 Then
            lvPrecio.Items(0).Selected = True
        End If
    End Sub

    Private Sub lvPrecio_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPrecio.DoubleClick
        If lvPrecio.SelectedItems.Count > 0 Then
            Select Case frm_return
                Case 1
                    If frmVenta.rdCordoba.Checked Then
                        frmVenta.txtPrecio.Text = lvPrecio.SelectedItems(0).SubItems(2).Text
                    Else
                        frmVenta.txtPrecio.Text = lvPrecio.SelectedItems(0).SubItems(1).Text
                    End If
                    frmVenta.txtCantidad.Focus()
                Case 2
                    If frmCotizacion.rdCordoba.Checked Then
                        frmCotizacion.txtPrecio.Text = lvPrecio.SelectedItems(0).SubItems(2).Text
                    Else
                        frmCotizacion.txtPrecio.Text = lvPrecio.SelectedItems(0).SubItems(1).Text
                    End If
                    frmCotizacion.txtCantidad.Focus()
                Case 3
                    If frmNotaDevolucion.rdCordoba.Checked Then
                        frmNotaDevolucion.txtPrecio.Text = lvPrecio.SelectedItems(0).SubItems(2).Text
                    Else
                        frmNotaDevolucion.txtPrecio.Text = lvPrecio.SelectedItems(0).SubItems(1).Text
                    End If
                    frmNotaDevolucion.txtCantidad.Focus()
            End Select
            Me.Close()
        End If
    End Sub

    Private Sub lvPrecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPrecio.KeyPress
        If e.KeyChar = ChrW(13) And lvPrecio.SelectedItems.Count > 0 Then
            lvPrecio_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmBuscarPrecio_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class