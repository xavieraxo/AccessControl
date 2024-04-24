using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Models;
using System.Linq.Expressions;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class LecturaPatenteModelsRepository : GenericRepository<LecturaPatente>, ILecturasPatenteModelsRepository
    {
        public LecturaPatenteModelsRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<LecturasGaritaLog>> GetAsync(Expression<Func<LecturasGaritaLog, bool>> filter = null, Func<IQueryable<LecturasGaritaLog>, IOrderedQueryable<LecturasGaritaLog>> orderBy = null, string includeProperties = "", int first = 0, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public LecturasGaritaLog Insert(LecturasGaritaLog obj)
        {
            throw new NotImplementedException();
        }

        public LecturasGaritaLog Update(LecturasGaritaLog obj)
        {
            throw new NotImplementedException();
        }

        ICollection<LecturasGaritaLog> Infraestructura.IGenericRepository<LecturasGaritaLog>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<LecturasGaritaLog> Infraestructura.IGenericRepository<LecturasGaritaLog>.GetAllAsNoTracking()
        {
            throw new NotImplementedException();
        }

        LecturasGaritaLog Infraestructura.IGenericRepository<LecturasGaritaLog>.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
