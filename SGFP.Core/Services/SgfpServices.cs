using SGFP.Core.Entities;
using SGFP.Core.Services.Interfaces;

namespace SGFP.Core.Services;

public class SgfpService : ISgfpService{
    private decimal[] montos = new decimal[100]; 
    private string[] descripciones = new string[100];
    private string[] conceptos = new string[100];
    private decimal saldoTotal = 0;
    private int contadorTransacciones = 0;

    public Sgfp ProcessSgfp(Person person){
       
        var sgft = new Sgfp();

        decimal dinero = person.Salario;

             while (true)
            {
                Console.WriteLine("\nRegistro o transacion:");
                Console.WriteLine("1. Ingresar Monto");
                Console.WriteLine("2. Consultar Saldo");
                Console.WriteLine("3. Retirar Dinero");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                       Console.WriteLine("Ingresa el monto a depositar: ");
                        decimal monto = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese la descripción de la transacción: ");
                        string descripcion = Console.ReadLine();
                        Console.WriteLine("Ingrese el concepto de la transacción: ");
                        string concepto = Console.ReadLine();

                        // Almacenar la transacción en los arreglos
                        montos[contadorTransacciones] = monto;
                        descripciones[contadorTransacciones] = descripcion;
                        conceptos[contadorTransacciones] = concepto;
                        saldoTotal += monto;

                        contadorTransacciones++;

                        break;
                   case "2":
              if (saldoTotal <= 0) {
                 Console.WriteLine("No hay montos ingresados todavía.");
                } else {
             Console.WriteLine($"Saldo actual: ${saldoTotal}");
                }
              break;
                   case "3":
    Console.WriteLine("Ingresa el Monto a retirar: ");
    decimal montoRetiro = decimal.Parse(Console.ReadLine());

    if (montoRetiro > saldoTotal) {
        Console.WriteLine("No hay saldo suficiente para el retiro.");
    } else {
        saldoTotal -= montoRetiro;
        Console.WriteLine($"Se retiraron ${montoRetiro} exitosamente");
    }
    break;
                    case "4":
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
