﻿using System.Linq.Expressions;

namespace AccessControlWebRazor.Infraestructura
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAllAsNoTracking();
        ICollection<T> GetAll();
        T GetById(object id);
        T Insert(T obj);
        T Update(T obj);
        void Delete(object id);
        void Save();
        public Task<IEnumerable<T>> GetAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "",
           int first = 0, int offset = 0);
    }
}
