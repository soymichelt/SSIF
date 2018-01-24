Module NumeroALetra

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "Cien "
                                Else
                                    palabras = palabras & "Ciento "
                                End If
                            Case "2"
                                palabras = palabras & "Doscientos "
                            Case "3"
                                palabras = palabras & "Trescientos "
                            Case "4"
                                palabras = palabras & "Cuatrocientos "
                            Case "5"
                                palabras = palabras & "Quinientos "
                            Case "6"
                                palabras = palabras & "Seiscientos "
                            Case "7"
                                palabras = palabras & "Tetecientos "
                            Case "8"
                                palabras = palabras & "Ochocientos "
                            Case "9"
                                palabras = palabras & "Novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "Diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "Once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "Doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "Trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "Catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "Quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "Dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "Noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "Noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "Uno "
                                    Else
                                        palabras = palabras & "Un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "Dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "Tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "Cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "Cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "Seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "Siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "Ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "Nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "Mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "Millón "
                    Else
                        palabras = palabras & "Millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec & " Centavos"
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function
End Module
