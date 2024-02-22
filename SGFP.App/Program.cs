using System;
using SGFP.Core.Entities;
using SGFP.Core.Managers;
using SGFP.Core.Services;


namespace SGFP.App;

public static class Program{

    public static void Main(String[] args ){
        decimal dinero = 0;

        System.Console.WriteLine("Ingresa tu dinero: ");
        Decimal.TryParse(System.Console.ReadLine(), out dinero);

    
        // var bmi = new Bmi();
        var salario = new Person{Salario = dinero};

        var service = new SgfpService();
        var managers = new SgfpManager(service);

        Sgfp sgfp = managers.GetSgfp(salario);

        System.Console.WriteLine($"Tu Isr es: {sgfp.Index}");
    }
}


