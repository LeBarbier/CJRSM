using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CJRSM.Models.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private CJRSMContainer contexte;
        private bool disposed = false;
        private DbSet<TEntity> dbSet;

        public GenericRepository(CJRSMContainer context)
        {
            contexte = context;
            dbSet = contexte.Set<TEntity>();
        }

        public void Add(TEntity entite)
        {
            dbSet.Add(entite);
        }

        public void Delete(int id)
        {
            TEntity entite = dbSet.Find(id);
            dbSet.Remove(entite);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    contexte.Dispose();
            }
            this.disposed = true;
        }
        
        public TEntity Find(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filtre = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordre = null, string includes = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filtre != null)
                query = query.Where(filtre);

            foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (ordre != null)
                return ordre(query).ToList();
            else
                return query.ToList();
        }

        public int Save()
        {
            //return contexte.SaveChanges();
            try
            {
                return contexte.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filtre)
        {
            return dbSet.SingleOrDefault(filtre);
        }

        public void Update(TEntity entite)
        {
            contexte.Entry(entite).State = EntityState.Modified;
        }
    }
}