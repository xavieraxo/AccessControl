using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        public ICentroCostoModelsRepository CentroCostoModels { get; private set; }
        public ILecturasGaritaLogModelsRepository LecturasGaritaLogModels { get; private set; }
        public IProcesamientoModelsRepository ProcesamientoModels { get; private set; }
        public IPersonalModelsRepository PersonalModels { get; private set; }
        public IPermisosRepository Permisos { get; private set; }
        public ITipoPersonasRepository TipoPersonas { get; private set; }
        public IUsuariosRepository Usuarios { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            CentroCostoModels = new CentroCostoModelsRepository(this._context);
            LecturasGaritaLogModels = new LecturasGaritaLogModelsRepository(this._context);
            ProcesamientoModels = new ProcesamientoModelsRepository(this._context);
            PersonalModels = new PersonalModelsRepository(this._context);
            Permisos = new PermisosRepository(this._context);
            TipoPersonas = new TipoPersonasRepository(this._context);
            Usuarios = new UsuariosRepository(this._context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
