using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private D75E5Entities contexte;
        private GenericRepository<Activite> activite;
        private GenericRepository<ActiviteJeu> activiteJeu;
        private GenericRepository<Document> document;
        private GenericRepository<Jeu> jeu;
        private GenericRepository<LocationDocument> locationDocument;
        private GenericRepository<LocationJeu> locationJeu;
        private GenericRepository<Membre> membre;
        private GenericRepository<Participant> participants;
        private GenericRepository<Publication> publication;
        private GenericRepository<Type> types;
        private GenericRepository<TypesJeu> typesJeu;
        private bool disposed = false;

        public UnitOfWork()
        {
            contexte = new D75E5Entities();
        }

        public IGenericRepository<Activite> Activite
        {
            get
            {

                if (activite == null)
                {
                    activite = new GenericRepository<Activite>(contexte);
                }
                return activite;
            }

        }

        public IGenericRepository<ActiviteJeu> ActiviteJeu
        {
            get
            {

                if (activiteJeu == null)
                {
                    activiteJeu = new GenericRepository<ActiviteJeu>(contexte);
                }
                return activiteJeu;
            }

        }

        public IGenericRepository<Document> Document
        {
            get
            {
                if (document == null)
                {
                    document = new GenericRepository<Document>(contexte);
                }
                return document;
            }
        }

        public IGenericRepository<Jeu> Jeu
        {
            get
            {
                if (jeu == null)
                {
                    jeu = new GenericRepository<Jeu>(contexte);
                }
                return jeu;
            }
        }

        public IGenericRepository<LocationDocument> LocationDocument
        {
            get
            {

                if (locationDocument == null)
                {
                    locationDocument = new GenericRepository<LocationDocument>(contexte);
                }
                return locationDocument;
            }

        }

        public IGenericRepository<LocationJeu> LocationJeu
        {
            get
            {

                if (LocationJeu == null)
                {
                    locationJeu = new GenericRepository<LocationJeu>(contexte);
                }
                return locationJeu;
            }

        }

        public IGenericRepository<Membre> Membre
        {
            get
            {
                if (membre == null)
                {
                    membre = new GenericRepository<Membre>(contexte);
                }
                return membre;
            }
        }

        public IGenericRepository<Participant> Participants
        {
            get
            {

                if (participants == null)
                {
                    participants = new GenericRepository<Participant>(contexte);
                }
                return participants;
            }

        }

        public IGenericRepository<Publication> Publication
        {
            get
            {
                if (publication == null)
                {
                    publication = new GenericRepository<Publication>(contexte);
                }
                return publication;
            }
        }

        public IGenericRepository<Type> Types
        {
            get
            {

                if (types == null)
                {
                    types = new GenericRepository<Type>(contexte);
                }
                return types;
            }

        }

        public IGenericRepository<TypesJeu> TypesJeu
        {
            get
            {

                if (typesJeu == null)
                {
                    typesJeu = new GenericRepository<TypesJeu>(contexte);
                }
                return typesJeu;
            }

        }

        public int Save()
        {
            return contexte.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contexte.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}