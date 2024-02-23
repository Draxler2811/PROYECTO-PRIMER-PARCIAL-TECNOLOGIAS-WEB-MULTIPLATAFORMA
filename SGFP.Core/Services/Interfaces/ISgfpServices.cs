using SGFP.Core.Entities;

namespace SGFP.Core.Services.Interfaces;

public interface ISgfpService{
    Sgfp ProcessSgfp (Person person); 
    Sgfp SeguimientoSgfp (Person person); 
    Sgfp MetaSgfp (Person person); 

}