using SGFP.Core.Entities;
using SGFP.Core.Services.Interfaces;

namespace SGFP.Core.Services;

public class SgfpService : ISgfpService{
    public Sgfp ProcessSgfp(Person person){

        var sgft = new Sgfp();

        decimal dinero = person.Salario;

             while (true)
            {
                Console.WriteLine("\nRegistro o transacion:");
                Console.WriteLine("1. Ingresar cantidad");
                Console.WriteLine("2. Retirar dinero");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Lógica para calcular el Impuesto sobre la Renta (ISR)
                        Console.WriteLine("Ingresa la cantidad a depositar ");
                        break;
                    case "2":
                        Console.WriteLine("Ingrese la cantidad a retirar");
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del Menú SgfpService...");
                        return sgft;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
        public Sgfp SeguimientoSgfp(Person person){

        var sgft = new Sgfp();

        decimal dinero = person.Salario;

             while (true)
            {
                Console.WriteLine("\nSeguimiento de saldo y estado Financiero:");
                Console.WriteLine("1. Ingresar cantidad");
                Console.WriteLine("2. Retirar dinero");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Lógica para calcular el Impuesto sobre la Renta (ISR)
                        Console.WriteLine("Ingresa la cantidad a depositar ");
                        break;
                    case "2":
                        Console.WriteLine("Ingrese la cantidad a retirar");
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del Menú SgfpService...");
                        return sgft;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
        public Sgfp MetaSgfp(Person person){

        var sgft = new Sgfp();

        decimal dinero = person.Salario;

             while (true)
            {
                Console.WriteLine("\nMeta:");
                Console.WriteLine("1. Ingresar cantidad");
                Console.WriteLine("2. Retirar dinero");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Lógica para calcular el Impuesto sobre la Renta (ISR)
                        Console.WriteLine("Ingresa la cantidad a depositar ");
                        break;
                    case "2":
                        Console.WriteLine("Ingrese la cantidad a retirar");
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del Menú SgfpService...");
                        return sgft;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
    }
