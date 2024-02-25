using SGFP.Core.Entities;

namespace SGFP.Core.Services.Interfaces;

public interface ISgfpService{
    Sgfp RegistroSgfp (Person person); 
    Sgfp SeguimientoSgfp (Person person); 
    Sgfp MetaSgfp (Person person); 

}