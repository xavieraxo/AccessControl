using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.CertronicModule.Data
{
    public class MaquinariaRepository : GenericRepository<Maquinaria>, IMaquinariaRepository
    {
        public MaquinariaRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
