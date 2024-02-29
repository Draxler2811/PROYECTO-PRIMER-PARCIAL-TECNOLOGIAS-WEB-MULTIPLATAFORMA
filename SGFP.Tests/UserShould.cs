using SGFP.Core.Services;
using SGFP.Core.Services;

namespace SGFP.Test;

public class UserShould
{
    [Fact]
    public void Verificacion_Ingreso_De_Saldo()
    {
        //Arrange
        var service = new SgfpService();
        var ingreso = 500;
        

        //Act
        var result = service.saldoActual + ingreso;

        //Assert
        Assert.NotEqual(0, result);
    }
    
    [Fact]
    public void Verificacion_Retiro_De_Saldo()
    {
        //Arrange
        var service = new SgfpService();
        service.saldoActual = 500;
        var gastos = 300;
        

        //Act
        var result = service.saldoActual - gastos;

        //Assert
        Assert.Equal(200, result);
    }
    
    [Fact]
    public void Verificacion_Metas_Sin_Monto()
    {
        //Arrange
        var service = new SgfpService();

        //Act
        var result = service.MontosMetas;

        //Assert
        Assert.DoesNotContain(0, result);
    }
    
    [Fact]
    public void Verificacion_Calculo_Ingresos()
    {
        //Arrange
        var service = new SgfpService();
        service.saldoActual = 15;
        decimal saldoInicial = service.saldoActual + 20;

        //Act
        var result = service.saldoActual < saldoInicial;

        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Verificacion_Saldo_Mayor_Que_Gastos()
    {
        // Arrange
        var service = new SgfpService();
        service.saldoActual = 25;
        service.gastos = 15;

        // Act
        var result = service.saldoActual > service.gastos;
        
        // Assert
        Assert.True(result);
    }
}