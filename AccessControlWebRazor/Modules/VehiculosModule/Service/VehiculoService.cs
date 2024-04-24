using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.VehiculosModule.Data;

namespace AccessControlWebRazor.Modules.VehiculosModule.Service
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository repository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
          repository = vehiculoRepository;
        }
        public List<Vehiculo> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Vehiculo GetByDominio(string dominio)
        {
            var result = repository.GetAsync(x => x.Dominio == dominio).Result.FirstOrDefault();
            return result;
        }

        public void  Sincronizacion(List<Vehiculo> vehiculo)
        {
            try
            {
                var vehiculosInDB = repository.GetAll().ToList();

                foreach (var item in vehiculo)
                {
                    if (!vehiculosInDB.Any(x=> x.Dominio == item.Dominio))
                    {
                        repository.Insert(item);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidateVehicle(string dominio)
        {
            return repository.GetAll().ToList().Any(x => x.Dominio == dominio);
        }
    }
}
