using SGFP.Core.Entities;
using SGFP.Core.Services.Interfaces;

namespace SGFP.Core.Services;

public class SgfpService : ISgfpService{
    public Sgfp ProcessSgfp(Person person){

        var sgft = new Sgfp();

        decimal dinero = person.Salario;

            var tablaISR = new[]
            {
                new { LimiteInferior = 0.01m, LimiteSuperior = 7735.00m, CuotaFija = 0m, Porcentaje = 1.92m },
                new { LimiteInferior = 7735.01m, LimiteSuperior = 65651.07m, CuotaFija = 148.51m, Porcentaje = 6.4m },
                new { LimiteInferior = 65651.08m, LimiteSuperior = 115375.90m, CuotaFija = 3855.14m, Porcentaje = 10.88m },
                new { LimiteInferior = 115375.91m, LimiteSuperior = 134119.41m, CuotaFija = 9265.20m, Porcentaje = 16.00m },
                new { LimiteInferior = 134119.42m, LimiteSuperior = 160577.65m, CuotaFija = 12164.16m, Porcentaje = 17.92m },
                new { LimiteInferior = 160577.66m, LimiteSuperior = 323862.00m, CuotaFija = 17005.47m, Porcentaje = 21.36m },
                new { LimiteInferior = 323862.01m, LimiteSuperior = 510451.00m, CuotaFija = 51883.01m, Porcentaje = 23.52m },
                new { LimiteInferior = 510451.01m, LimiteSuperior = 974535.03m, CuotaFija = 95768.74m, Porcentaje = 30.00m },
                new { LimiteInferior = 974535.04m, LimiteSuperior = 1299380.04m, CuotaFija = 234993.95m, Porcentaje = 32.00m },
                new { LimiteInferior = 1299380.05m, LimiteSuperior = 3898140.12m, CuotaFija = 338944.34m, Porcentaje = 34.00m },
                new { LimiteInferior = 3898140.13m, LimiteSuperior = decimal.MaxValue, CuotaFija = 1222522.76m, Porcentaje = 35.00m }
            };

var rango = tablaISR.FirstOrDefault(r => (decimal)dinero > r.LimiteInferior && (decimal)dinero <= r.LimiteSuperior);

            if (rango != null)
            {
                decimal baseISR = dinero - rango.LimiteInferior;
                decimal impuesto = (baseISR * rango.Porcentaje / 100) + rango.CuotaFija;
                sgft.Index = impuesto;
            }
            else
            {
                sgft.Index = 0;
            }
                        return sgft;
        }
    }