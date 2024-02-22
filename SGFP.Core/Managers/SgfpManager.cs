using SGFP.Core.Entities;
using SGFP.Core.Managers.Interfaces;
using SGFP.Core.Services.Interfaces;

namespace SGFP.Core.Managers;

public class SgfpManager : ISgfpManager{
    private readonly ISgfpService _service;

    public SgfpManager(ISgfpService service){
        _service = service;
    }

    public Sgfp GetSgfp(Person person){
        return _service.ProcessSgfp(person);
    }
}