using System;

namespace CJRSM.Models.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Activite> Activite { get; }
        IGenericRepository<ActiviteJeu> ActiviteJeu { get; }
        IGenericRepository<Document> Document { get; }
        IGenericRepository<Jeu> Jeu { get; }
        IGenericRepository<LocationDocument> LocationDocument { get; }
        IGenericRepository<LocationJeu> LocationJeu { get; }
        IGenericRepository<Membre> Membre { get; }
        IGenericRepository<Participant> Participant { get; }
        IGenericRepository<Publication> Publication { get; }
        IGenericRepository<Type> Types { get; }
        IGenericRepository<TypesJeu> TypesJeu { get; }
        int Save();
    }
}