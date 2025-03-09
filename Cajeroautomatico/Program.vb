Imports System

Module CajeAutomatico
    Sub Main()
        Dim usuarios() As String = {"David", "Jorge", "Mario", "Andrea"}
        Dim contrasenas() As String = {"1234", "1234", "1234", "1234"}
        Dim saldos() As Integer = {50000000, 20000000, 1500000, 35000000}

        Console.Write("<<<<Ingrese su nombre de usuario>>>>: ")
        Dim usuarioIngresado As String = Console.ReadLine()

        Dim indice As Integer = Array.IndexOf(usuarios, usuarioIngresado)
        If indice = -1 Then
            Console.WriteLine("<<<<El usuario no se encuntra registrado>>>.")
            Exit Sub
        End If

        Console.Write("<<<<Ingrese otro nombre de usuario para comparar>>>>: ")
        Dim otroUsuario As String = Console.ReadLine()
        If usuarioIngresado = otroUsuario Then
            Console.WriteLine("<<<<<<Los nombres de usuario son iguales>>>>>.")
        Else
            Console.WriteLine("<<<<Los nombres de usuario son diferentes>>>>.")
        End If

        Console.Write("<<<<Ingrese su contraseña>>>>: ")
        Dim contrasenaIngresada As String = Console.ReadLine()

        If contrasenaIngresada = contrasenas(indice) Then
            Console.WriteLine("<<<<<Acceso concedido.", "Bienvenido al Banco Davivienda>>>>")
            Console.WriteLine("<<<Saldo actual>>>: " & saldos(indice) & " USD")
            Console.Write("<<<Ingrese la cantidad a retirar (múltiplos de 5)>>>: ")
            Dim cantidadRetiro As Integer = Convert.ToInt32(Console.ReadLine())

            If cantidadRetiro Mod 5 = 0 And cantidadRetiro <= saldos(indice) Then
                saldos(indice) -= cantidadRetiro
                Console.WriteLine("<<<Retiro exitoso.Su nuevo saldo es>>>: " & saldos(indice) & " USD")
            Else
                Console.WriteLine("<<<<Error: La cantidad debe ser múltiplo de 5 y no mayor al saldo disponible.>>>>")
            End If
        Else
            Console.WriteLine("<<<Contraseña incorrecta>>>.")
        End If

        Console.WriteLine("<<<<Presione una tecla para salir>>>>...")
        Console.ReadKey()


    End Sub
End Module
