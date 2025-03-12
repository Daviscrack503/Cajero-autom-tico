Imports System

Module CajeAutomatico
    Sub Main()
        Dim usuarios() As String = {"David", "Jorge", "Mario", "Andrea"}
        Dim contrasenas() As String = {"1234", "1234", "1234", "1234"}
        Dim saldos() As Integer = {50000, 2000, 1500, 35000}
        Dim intentos As Integer = 0
        Dim indice As Integer = -1


        Do
            Console.Write("<<<<Ingrese su nombre de usuario>>>>: ")
            Dim usuarioIngresado As String = Console.ReadLine()
            indice = Array.IndexOf(usuarios, usuarioIngresado)

            If indice = -1 Then
                Console.WriteLine("<<<<El usuario no se encuentra registrado>>>>.")
                intentos += 1
            Else
                Exit Do
            End If
        Loop While intentos < 3

        If intentos = 3 Then
            Console.WriteLine("<<<<Ha superado el límite de intentos>>>>.")
            Exit Sub
        End If

        intentos = 0
        Dim accesoConcedido As Boolean = False

        Do
            Console.Write("<<<<Ingrese su PIN>>>>: ")
            Dim contrasenaIngresada As String = Console.ReadLine()

            If contrasenaIngresada = contrasenas(indice) Then
                accesoConcedido = True
                Exit Do
            Else
                Console.WriteLine("<<<PIN incorrecto>>>.")
                intentos += 1
            End If
        Loop While intentos < 3

        If Not accesoConcedido Then
            Console.WriteLine("<<<<Ha superado el límite de intentos>>>>.")
            Exit Sub
        End If

        Dim opcion As Integer
        Do
            Console.WriteLine(vbCrLf & "<<<Bienvenido a THE DAVEBANK>>")
            Console.WriteLine("1. Consultar saldo")
            Console.WriteLine("2. Retirar dinero")
            Console.WriteLine("3. Salir")
            Console.Write("Seleccione una opcion valida: ")
            Integer.TryParse(Console.ReadLine(), opcion)

            Select Case opcion
                Case 1
                    Console.WriteLine("<<<Su saldo actual es>>>: " & saldos(indice) & " USD")
                Case 2
                    Console.Write("<<<Ingrese la cantidad a retirar (multiplos de 5)>>>: ")
                    Dim cantidadRetiro As Integer
                    If Integer.TryParse(Console.ReadLine(), cantidadRetiro) AndAlso cantidadRetiro Mod 5 = 0 Then
                        If cantidadRetiro <= saldos(indice) Then
                            saldos(indice) -= cantidadRetiro
                            Console.WriteLine("<<<Retiro exitoso. Su nuevo saldo es>>>: " & saldos(indice) & " USD")
                        Else
                            Console.WriteLine("<<<<Error: Saldo insuficiente>>>>.")
                        End If
                    Else
                        Console.WriteLine("<<<<Error: La cantidad debe ser multiplo de 5>>>>.")
                    End If
                Case 3
                    Console.WriteLine("<<<Gracias por usar nuestro servicios>>>.")
                Case Else
                    Console.WriteLine("<<<<Opcion no valida>>>>.")
            End Select

        Loop While opcion <> 3

        Console.WriteLine("<<<<Presione una tecla para salir>>>>...")
        Console.ReadKey()


    End Sub
End Module
