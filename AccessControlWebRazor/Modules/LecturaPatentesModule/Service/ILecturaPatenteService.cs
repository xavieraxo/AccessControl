using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.LecturaPatentesModule.Service
{
    public interface ILecturaPatenteService
    {
        List<LecturaPatente> GetAll();
    }
}
