using SGFP.Core.Entities;

namespace SGFP.Core.Managers.Interfaces;

public interface ISgfpManager{
    Sgfp GetSgfp (Person person);

}