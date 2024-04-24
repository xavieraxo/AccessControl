using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CentroCostoModule.Data;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Service
{
    public class CentroCostoService : ICentroCostoService
    {
        private readonly ICentroCostoRepository _centroCostoRepository;

        public CentroCostoService(ICentroCostoRepository centroCostoRepository)
        {
            _centroCostoRepository = centroCostoRepository;
        }
        public List<CentroCosto> GetAll()
        {
            return _centroCostoRepository.GetAll().ToList();
        }

        public List<CentroCosto> GetByFilter(string filter)
        {
            var cadena = filter.ToUpper().Trim();
            return _centroCostoRepository.GetAsync(x => x.Descripcion.ToUpper().Trim().Contains(cadena) || x.Nombre.ToUpper().Trim().Contains(cadena) || x.Codigo.ToUpper().Trim().Contains(cadena)).Result.ToList();
        }

        public CentroCosto GetById(int ID)
        {
            return _centroCostoRepository.GetById(ID);
        }
    }
}
