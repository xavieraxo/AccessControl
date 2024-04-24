using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatentesModule.Data;

namespace AccessControlWebRazor.Modules.LecturaPatentesModule.Service
{
    public class LecturaPatenteService : ILecturaPatenteService
    {
        private readonly ILecturaPatenteRepository _repository;
        public List<LecturaPatente> GetAll()
        {
            var result = _repository.GetAll().ToList();
            var paginado = result.TakeLast(150);
            return paginado.ToList();
        }
    }
}
