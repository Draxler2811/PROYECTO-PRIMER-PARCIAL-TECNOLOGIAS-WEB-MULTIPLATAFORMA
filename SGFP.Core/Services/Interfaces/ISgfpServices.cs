using SGFP.Core.Entities;

namespace SGFP.Core.Services.Interfaces;

public interface ISgfpService{
    Sgfp ProcessSgfp (Person person); 
}