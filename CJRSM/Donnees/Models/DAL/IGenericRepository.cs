using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CJRSM.Models.DAL
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Find(int id);
        IEnumerable<TEntity> Get(
                Expression<Func<TEntity, bool>> filtre = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordre = null,
                string includes = "");
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filtre);
        void Add(TEntity entite);
        void Delete(int id);
        void Update(TEntity entite);
        int Save();
    }
}
