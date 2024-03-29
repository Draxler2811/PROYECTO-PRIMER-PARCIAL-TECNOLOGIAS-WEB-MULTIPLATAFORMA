using SGFP.Core.Entities;
using SGFP.Core.Services.Interfaces;

namespace SGFP.Core.Services;

public class SgfpService : ISgfpService
{
    List<decimal> montos = new List<decimal>();
    List<string> conceptos = new List<string>();
    List<decimal> montosRetiros = new List<decimal>();
    List<string> conceptosRetiros = new List<string>();
    List<string> descripciones = new List<string>();
  
    List<string> conceptosMetas = new List<string>();
    public List<decimal> MontosMetas = new List<decimal>();
    List<decimal> presupuestoMetas = new List<decimal>();
    List<decimal> metasCompletadas = new List<decimal>();
    List<decimal> ahorroDiarios = new List<decimal>();

    public decimal saldoActual = 0;
    public decimal ingresos = 0;
    public decimal gastos = 0;

    public Sgfp RegistroSgfp(Person person)
    {
        var sgft = new Sgfp();

        decimal dinero = person.Salario;
        bool entradaValida;

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
                    entradaValida = false;
                    do
                    {
                        try
                        {
                            Console.WriteLine("Ingresa el monto a depositar: ");
                            decimal monto = decimal.Parse(Console.ReadLine());
                            Console.WriteLine(
                                "Ingrese la categoría de la transacción (alimentacion,transporte, vivienda, entretenimiento): "
                            );
                            string categoria = Console.ReadLine();

                            if (
                                categoria != "alimentacion"
                                && categoria != "transporte"
                                && categoria != "vivienda"
                                && categoria != "entretenimiento"
                            )
                            {
                                Console.WriteLine(
                                    "Categoría inválida. Por favor, elige una de las opciones proporcionadas."
                                );
                                continue;
                            }
                            Console.WriteLine("Ingrese el concepto de la transacción: ");
                            string concepto = Console.ReadLine();

                            montos.Add(monto);
                            descripciones.Add(categoria);
                            conceptos.Add(concepto);
                            saldoActual += monto;
                            ingresos += monto;

                            entradaValida = true;
                            Console.WriteLine("\nTransacción realizada con éxito!");
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Cantidad no válida");
                        }
                    } while (!entradaValida);
                    break;
                case "2":
                    entradaValida = false;
                    do
                    {
                        try
                        {
                            Console.WriteLine("Ingresa el Monto a retirar: ");
                            decimal montoRetiro = decimal.Parse(Console.ReadLine());
                            if (montoRetiro > saldoActual)
                            {
                                Console.WriteLine("No hay saldo suficiente para el retiro.");
                            }
                            else
                            {
                                Console.WriteLine("Ingresa el concepto del retiro: ");
                                string conceptoRetiro = Console.ReadLine();
                                saldoActual -= montoRetiro;
                                gastos += montoRetiro;
                                montosRetiros.Add(montoRetiro);
                                conceptosRetiros.Add(conceptoRetiro);
                                entradaValida = true;
                                Console.WriteLine(
                                    $"Se retiró ${montoRetiro} exitosamente. Concepto: {conceptoRetiro}."
                                );
                            }
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Cantidad no válida");
                        }
                    } while (!entradaValida);

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
                    Console.WriteLine(
                        "\n============ Transacciones relaizadas (Ingresos) =============="
                    );
                    for (int i = 0; i < montos.Count; i++)
                    {
                        Console.WriteLine(
                            "Ingreso de $"
                                + montos[i]
                                + " con categoría de "
                                + descripciones[i]
                                + " y con un concepto de "
                                + conceptos[i]
                        );
                    }
                    Console.WriteLine($"Total de ingresos: ${ingresos}");

                    Console.WriteLine(
                        "\n============ Transacciones relaizadas (Retiros) =============="
                    );
                    for (int i = 0; i < montosRetiros.Count; i++)
                    {
                        Console.WriteLine(
                            "Retiro de $"
                                + montosRetiros[i]
                                + " con concepto de "
                                + conceptosRetiros[i]
                        );
                    }
                    Console.WriteLine($"Total de gastos: ${gastos}");

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
        bool entradaValida;

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
                    entradaValida = false;
                    Console.Write("Ingresa un concepto para la meta financiera: ");
                    string conceptoMeta = Console.ReadLine();

                    do
                    {
                        try
                        {
                            Console.Write("Ingresa la cantidad total de ahorro para la meta: ");
                            decimal cantidadAhorroMeta = decimal.Parse(Console.ReadLine());

                            if (cantidadAhorroMeta > 0)
                            {
                                Console.Write("Ingresa el presupuesto disponible para la meta: ");
                                decimal presupuestoMeta = decimal.Parse(Console.ReadLine());
                                conceptosMetas.Add(conceptoMeta);
                                MontosMetas.Add(cantidadAhorroMeta);
                                metasCompletadas.Add(presupuestoMeta);
                                presupuestoMetas.Add(presupuestoMeta);
                                entradaValida = true;

                                Console.Write(
                                    "\nMeta añadida!   Para ver más detalles sobre tu nueva meta ve a tu historial de metas\n"
                                );
                            }
                            else
                            {
                                Console.WriteLine(
                                    "No puedes fijar una meta de $0. Pa eso mejor nadota."
                                );
                            }
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Cantidad no válida");
                        }
                    } while (!entradaValida);

                    break;
                case "2":

                    for (int i = 0; i < MontosMetas.Count; i++)
                    {
                        if (
                            metasCompletadas[i] >= MontosMetas[i]
                            && (presupuestoMetas[i] + saldoActual) < MontosMetas[i]
                        )
                        {
                            Console.WriteLine("\n=========== {0} ============", conceptosMetas[i]);
                            Console.WriteLine(
                                "Tu meta de ahorro para "
                                    + conceptosMetas[i]
                                    + " tiene un costo total de $"
                                    + MontosMetas[i]
                                    + " y cuentas con un presupuesto de $"
                                    + presupuestoMetas[i]
                                    + ", con un saldo en tu cuenta de $"
                                    + saldoActual
                                    + " ( meta completada )"
                            );
                        }
                        else if ((presupuestoMetas[i] + saldoActual) >= MontosMetas[i])
                        {
                            metasCompletadas[i] += saldoActual;
                            Console.WriteLine("\n=========== {0} ============", conceptosMetas[i]);
                            Console.WriteLine(
                                "Tu meta de ahorro para "
                                    + conceptosMetas[i]
                                    + " tiene un costo total de $"
                                    + MontosMetas[i]
                                    + " y cuentas con un presupuesto de $"
                                    + presupuestoMetas[i]
                                    + ", con un saldo en tu cuenta de $"
                                    + saldoActual
                                    + " ( meta completada )"
                            );
                        }
                        else
                        {
                            Console.WriteLine("\n=========== {0} ============", conceptosMetas[i]);
                            Console.WriteLine(
                                "Tu meta de ahorro para "
                                    + conceptosMetas[i]
                                    + " tiene un costo total de $"
                                    + MontosMetas[i]
                                    + " y cuentas con un presupuesto de $"
                                    + presupuestoMetas[i]
                                    + ", con un saldo en tu cuenta de $"
                                    + saldoActual
                                    + " ( aún te faltan $"
                                    + (MontosMetas[i] - presupuestoMetas[i] - saldoActual)
                                    + " )"
                            );
                        }
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
