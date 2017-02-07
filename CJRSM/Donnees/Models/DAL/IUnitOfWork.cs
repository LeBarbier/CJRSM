using System;

namespace CJRSM.Models.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Activites> Activites { get; }
        IGenericRepository<Documents> Documents { get; }
        IGenericRepository<Jeux> Jeux { get; }
        IGenericRepository<Membres> Membres { get; }
        IGenericRepository<Publications> Publications { get; }
        int Save();
    }
}