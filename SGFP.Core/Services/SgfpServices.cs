using SGFP.Core.Entities;
using SGFP.Core.Services.Interfaces;

namespace SGFP.Core.Services;

public class SgfpService : ISgfpService
{
    private decimal[] montos = new decimal[100];
    private string[] descripciones = new string[100];
    private string[] conceptos = new string[100];

    List<string> conceptosMetas = new List<string>();
    List<decimal> MontosMetas = new List<decimal>();
    List<decimal> ahorroDiarios = new List<decimal>();

    private decimal saldoActual = 0;
    private decimal ingresos = 0;
    private decimal gastos = 0;

    private int contadorTransacciones = 0;

    public Sgfp RegistroSgfp(Person person)
    {
        var sgft = new Sgfp();

        decimal dinero = person.Salario;

        while (true)
        {
            Console.WriteLine("\nRegistro o transacion:");
            Console.WriteLine("1. Ingresar Monto");
            Console.WriteLine("2. Retirar Dinero");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingresa el monto a depositar: ");
                    decimal monto = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la categoría de la transacción: ");
                    string descripcion = Console.ReadLine();
                    Console.WriteLine("Ingrese el concepto de la transacción: ");
                    string concepto = Console.ReadLine();

                    // Almacenar la transacción en los arreglos
                    montos[contadorTransacciones] = monto;
                    descripciones[contadorTransacciones] = descripcion;
                    conceptos[contadorTransacciones] = concepto;
                    saldoActual += monto;
                    ingresos += monto;
                    contadorTransacciones++;
                    break;
                case "2":
                    Console.WriteLine("Ingresa el Monto a retirar: ");
                    decimal montoRetiro = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Ingresa el concepto del retiro: ");
                    string conceptoRetiro = Console.ReadLine();

                    if (montoRetiro > saldoActual)
                    {
                        Console.WriteLine("No hay saldo suficiente para el retiro.");
                    }
                    else
                    {
                        saldoActual -= montoRetiro;
                        gastos += montoRetiro;
                        Console.WriteLine(
                            $"Se retiraron ${montoRetiro} exitosamente. Concepto: {conceptoRetiro}."
                        );
                    }
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

    public Sgfp SeguimientoSgfp(Person person)
    {
        var sgft = new Sgfp();

        decimal dinero = person.Salario;

        while (true)
        {
            Console.WriteLine("\nSeguimiento de saldo y estado Financiero:");
            Console.WriteLine("1. Saldo Actual");
            Console.WriteLine("2. Resumen Financiero");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    if (saldoActual < 0)
                    {
                        Console.WriteLine("No hay montos ingresados todavía.");
                    }
                    else
                    {
                        Console.WriteLine($"Saldo actual: ${saldoActual}");
                        Console.WriteLine($"Ingresos: ${ingresos}");
                        Console.WriteLine($"Gastos: ${gastos}");
                    }
                    break;
                case "2":
                    Console.WriteLine("\n============ RESUMEN FINANCIERO =============");
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

    public Sgfp MetaSgfp(Person person)
    {
        var sgft = new Sgfp();

        decimal dinero = person.Salario;

        while (true)
        {
            Console.WriteLine("\n============ METAS Y PRESUPUESTOS =============");
            Console.WriteLine("1- Establecer una nueva meta financiera");
            Console.WriteLine("2- Ver mi historial de metas financieras");
            Console.WriteLine("3- Volver al menu principal");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingresa un concepto para la meta financiera: ");
                    string conceptoMeta = Console.ReadLine();

                    Console.Write("Ingresa la cantidad de ahorro para la meta: ");
                    decimal cantidadAhorroMeta = decimal.Parse(Console.ReadLine());

                    //Console.Write(
                    //  "Ingresa un lapso de tiempo en el cual quieres que tu meta se cumpla: "
                    //);
                    //decimal lapsoTiempo = decimal.Parse(Console.ReadLine());

                    if (cantidadAhorroMeta > 0)
                    {
                        conceptosMetas.Add(conceptoMeta);
                        MontosMetas.Add(cantidadAhorroMeta);
                        contadorTransacciones++;
                        //decimal ahorroDiario = cantidadAhorroMeta / lapsoTiempo;
                        //ahorroDiarios.Add(ahorroDiario);
                        Console.Write(
                            "\nMeta añadida!   Para ver más detalles sobre tu nueva meta ve a tu historial de metas\n"
                        );
                    }
                    else
                    {
                        Console.WriteLine("No puedes fijar una meta de $0. Pa eso mejor nadota.");
                    }

                    break;
                case "2":
                    for (int i = 0; i < MontosMetas.Count; i++)
                    {
                        if (saldoActual  >= MontosMetas[i])
                        {
                            Console.WriteLine("\n=========== {0} ============", conceptosMetas[i]);
                            Console.WriteLine(
                                "Tu meta de ahorro para " + conceptosMetas[i] + " es de ${0}",
                                MontosMetas[i] +" ( meta completada )"
                                
                            );
                        }
                        else
                        {
                            Console.WriteLine("\n=========== {0} ============", conceptosMetas[i]);
                            Console.WriteLine(
                                "Tu meta de ahorro para " + conceptosMetas[i] + " es de ${0}",
                                MontosMetas[i] +
                                " ( aún te faltan $" + (MontosMetas[i]-saldoActual) + " )"
                            );
                        }
                        //Console.WriteLine(
                        //"Para lograrla, debes ahorrar ${0} pesos al día.",
                        //ahorroDiarios[i].ToString("0.00")
                        //);
                    }
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
