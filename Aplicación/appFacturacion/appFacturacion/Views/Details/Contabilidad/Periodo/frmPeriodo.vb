Public Class frmPeriodo
    Dim idperiodo As String = ""
    Sub Limpiar()
        Try
            Using db As New CodeFirst
                Dim p = db.Periodos.Where(Function(f) f.ACTIVO = "S" And f.ACTUAL = "S").FirstOrDefault
                If Not p Is Nothing Then
                    Me.idperiodo = p.IDPERIODO
                    dtpInicio.Value = p.INICIO : dtpInicio.Enabled = False
                    dtpFinal.Value = p.FINAL : dtpFinal.Enabled = False
                    lblActual.Text = "Período Actual: Inicio " & p.INICIO.ToShortDateString & " Final " & p.FINAL.ToShortDateString & If(p.APERTURA IsNot Nothing, vbNewLine & " Aperturado " & p.APERTURA.Value.ToShortDateString, "")
                    btGuardar.Enabled = False
                    btAnular.Enabled = True
                    'Validacion de Botones
                    If p.APERTURA Is Nothing Then
                        btApertura.Enabled = True
                        btCierre.Enabled = False
                        btGuardar.Enabled = False
                        btAnular.Enabled = True
                    Else
                        btApertura.Enabled = False
                        If p.CIERRE Is Nothing Then
                            btCierre.Enabled = True
                            btGuardar.Enabled = False
                            btAnular.Enabled = True
                        Else
                            btCierre.Enabled = False
                            btGuardar.Enabled = True
                            btAnular.Enabled = True
                        End If
                    End If
                    'Fin
                    p = Nothing
                Else
                    Me.idperiodo = ""
                    dtpInicio.Value = DateTime.Parse("01/01/" & DateTime.Now.Year) : dtpInicio.Enabled = True
                    dtpFinal.Value = DateTime.Parse("31/12/" & DateTime.Now.Year) : dtpFinal.Enabled = True
                    lblActual.Text = "No hay ciclo actualmente"
                    btGuardar.Enabled = True
                    btAnular.Enabled = False
                    btApertura.Enabled = False
                    btCierre.Enabled = False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        Limpiar()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Try
            Dim Inicio As DateTime = dtpInicio.Value.ToShortDateString & " 00:00:00"
            Dim Final As DateTime = dtpFinal.Value.ToShortDateString & " 23:59:59"
            Using db As New CodeFirst
                If Not db.Periodos.Where(Function(f) f.ACTIVO.Equals("S") And f.ACTUAL.Equals("S") And f.CIERRE Is Nothing).Count > 0 Then
                    Dim c = db.Periodos.Where(Function(f) f.ACTIVO.Equals("S") And ((f.INICIO <= Inicio And f.FINAL >= Inicio) Or (f.INICIO <= Final And f.FINAL >= Final)))
                    If Not c Is Nothing Then
                        If c.Count = 0 Then
                            Dim p As New Periodo
                            p.IDPERIODO = Guid.NewGuid.ToString()
                            p.Reg = DateTime.Now
                            p.INICIO = DateTime.Parse(dtpInicio.Value.ToShortDateString & " 00:00:00")
                            p.FINAL = DateTime.Parse(dtpFinal.Value.ToShortDateString & " 23:59:59")
                            p.ACTUAL = "S" : p.ACTIVO = "S"
                            db.Periodos.Add(p)
                            db.SaveChanges()
                            lblActual.Text = "Período Actual: Inicio " & p.INICIO.ToShortDateString & " Final " & p.FINAL.ToShortDateString
                            btApertura.Enabled = True : btCierre.Enabled = False : btAnular.Enabled = True : btGuardar.Enabled = False : dtpInicio.Enabled = False : dtpFinal.Enabled = False
                            Config._Periodo = p : p = Nothing
                        Else
                            MessageBox.Show("El 'Período' debe estar en un rango de fecha distinto a los 'Períodos' anteriores.")
                        End If
                    Else
                        MessageBox.Show("El 'Período' debe estar en un rango de fecha distinto a los 'Períodos' anteriores.")
                    End If
                Else
                    MessageBox.Show("Existe un 'Período' actualmente al que no se le ha registrado el cierre.")
                    Limpiar()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btAnular_Click(sender As Object, e As EventArgs) Handles btAnular.Click
        If MessageBox.Show("¿Desea eliminar el actual 'Período'?", "Pregunta de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            Try
                Using db As New CodeFirst
                    Dim p = db.Periodos.Where(Function(f) f.ACTIVO = "S" And f.ACTUAL = "S").FirstOrDefault
                    If Not p Is Nothing Then
                        p.ACTUAL = "N"
                        p.ACTIVO = "N"
                        db.Entry(p).State = EntityState.Modified
                        db.SaveChanges()
                        MessageBox.Show("Período eliminado")
                        btGuardar.Enabled = True : btAnular.Enabled = False
                        btApertura.Enabled = False : btCierre.Enabled = False
                        dtpInicio.Enabled = True : dtpFinal.Enabled = True
                        lblActual.Text = "No hay ciclo actualmente"
                    Else
                        MessageBox.Show("No se encuentra el 'Período'.")
                        btGuardar.Enabled = True : dtpInicio.Enabled = True : dtpFinal.Enabled = True
                        btAnular.Enabled = False : btApertura.Enabled = False : btCierre.Enabled = False
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error, " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btApertura_Click(sender As Object, e As EventArgs) Handles btApertura.Click
        Try
            Using db As New CodeFirst
                Dim p = db.Periodos.Where(Function(f) f.ACTIVO = "S" And f.ACTUAL = "S").FirstOrDefault
                If Not p Is Nothing Then
                    If p.APERTURA Is Nothing Then
                        p.APERTURA = DateTime.Now
                        db.Entry(p).State = EntityState.Modified
                        db.SaveChanges()
                        dtpInicio.Enabled = False
                        dtpFinal.Enabled = False
                        btApertura.Enabled = False
                        btCierre.Enabled = True
                        Config._Periodo = p
                        frmPrincipal.txtInicio.Text = p.INICIO.ToShortDateString()
                        frmPrincipal.txtFinal.Text = p.FINAL.ToShortDateString()
                        p = Nothing
                    Else
                        btApertura.Enabled = False
                        btCierre.Enabled = True
                    End If
                    p = Nothing
                Else
                    MessageBox.Show("No existe período actualmente.")
                    Limpiar()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub btCierre_Click(sender As Object, e As EventArgs) Handles btCierre.Click
        Try
            Using db As New CodeFirst
                Dim p = db.Periodos.Where(Function(f) f.ACTIVO = "S" And f.ACTUAL = "S").FirstOrDefault
                If Not p Is Nothing Then
                    If Not p.APERTURA Is Nothing Then
                        If p.CIERRE Is Nothing Then
                            p.CIERRE = DateTime.Now
                            p.ACTUAL = "N"
                            db.Entry(p).State = EntityState.Modified
                            db.SaveChanges()
                        End If
                        dtpInicio.Enabled = True
                        dtpFinal.Enabled = True
                        btGuardar.Enabled = True
                        btAnular.Enabled = False
                        btApertura.Enabled = False
                        btCierre.Enabled = False
                        lblActual.Text = "No existe ciclo actualmente"
                        Config._Periodo = Nothing
                        frmPrincipal.txtInicio.Text = "S/E"
                        frmPrincipal.txtFinal.Text = "S/E"
                    Else
                        btApertura.Enabled = True
                        btCierre.Enabled = False
                        btAnular.Enabled = True
                        btGuardar.Enabled = False
                        lblActual.Text = "Período Actual: Inicio " & p.INICIO.ToShortDateString & " Final " & p.FINAL.ToShortDateString & If(p.APERTURA IsNot Nothing, vbNewLine & " Aperturado " & p.APERTURA.Value.ToShortDateString, "")
                    End If
                    p = Nothing
                Else
                    MessageBox.Show("No existe período actualmente.")
                    Limpiar()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error, " & ex.Message)
        End Try
    End Sub

    Private Sub frmPeriodo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    btNuevo_Click(Nothing, Nothing)
                Case Keys.G
                    If btGuardar.Enabled Then
                        btGuardar_Click(Nothing, Nothing)
                    End If
                Case Keys.Delete
                    If btAnular.Enabled Then
                        btAnular_Click(Nothing, Nothing)
                    End If
            End Select
        End If
    End Sub

End Class