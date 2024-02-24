using System;
using SGFP.Core.Entities;
using SGFP.Core.Managers;
using SGFP.Core.Services;


namespace SGFP.App;

public static class Program{

    public static void Main(String[] args ){
        decimal monto = 0;
        decimal dinero = 0;

        SgfpService sgfpService = new SgfpService();

      Console.WriteLine("Bienvenido al Sistema de Cálculo de Financiero1");

            while (true)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Registro de Transaciones");
                Console.WriteLine("2. Seguimiento de saldo y Estado Financiero");
                Console.WriteLine("3. Meta");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        sgfpService.ProcessSgfp(new Person { Monto = monto });
                        break;
                        break;
                    case "2":
                        sgfpService.SeguimientoSgfp(new Person { Salario = dinero });                        
                        break;
                     case "3":
                        sgfpService.MetaSgfp(new Person { Salario = dinero }); 
                        break;
                     case "4":
                        Console.WriteLine("Gracias por usar nuestro servicio. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
    }
    
