using AccessControlWebRazor.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DataContext _dbContext;
        private DbSet<T> table;

        public GenericRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
        }
        public IEnumerable<T> GetAllAsNoTracking()
        {
            return table.AsNoTracking();
        }

        public ICollection<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public T Insert(T obj)
        {
            var entidad = table.Add(obj).Entity;
            _dbContext.SaveChanges();
            return entidad;
            
        }

        public int InsertRange(IEnumerable<T> lista) 
        {
            table.AddRange(lista);
            return _dbContext.SaveChanges();

        }
        public T Update(T obj)
        {
            table.Attach(obj);
            //table.Update(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return obj;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            _dbContext.SaveChanges();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "",
           int first = 0, int offset = 0)
        {
            IQueryable<T> query = table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (offset > 0)
            {
                query = query.Skip(offset);
            }
            if (first > 0)
            {
                query = query.Take(first);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
