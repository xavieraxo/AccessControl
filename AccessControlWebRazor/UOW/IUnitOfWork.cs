using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        ICentroCostoModelsRepository CentroCostoModels { get; }
        ILecturasGaritaLogModelsRepository LecturasGaritaLogModels { get; }
        IProcesamientoModelsRepository ProcesamientoModels { get; }
        IPersonalModelsRepository PersonalModels { get; }
        IPermisosRepository Permisos { get; }
        ITipoPersonasRepository TipoPersonas { get; }
        IUsuariosRepository Usuarios { get; }
        public int Save();
    }
}
