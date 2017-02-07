using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private CJRSMContainer contexte;
        private GenericRepository<Activites> activites;
        private GenericRepository<Documents> documents;
        private GenericRepository<Jeux> jeux;
        private GenericRepository<Membres> membres;
        private GenericRepository<Publications> publications;
        private bool disposed = false;

        public UnitOfWork()
        {
            contexte = new CJRSMContainer();
        }
        public IGenericRepository<Activites> Activites
        {
            get
            {

                if (activites == null)
                {
                    activites = new GenericRepository<Activites>(contexte);
                }
                return activites;
            }

        }

        public IGenericRepository<Documents> Documents
        {
            get
            {
                if (documents == null)
                {
                    documents = new GenericRepository<Documents>(contexte);
                }
                return documents;
            }
        }

        public IGenericRepository<Jeux> Jeux
        {
            get
            {
                if (jeux == null)
                {
                    jeux = new GenericRepository<Jeux>(contexte);
                }
                return jeux;
            }
        }

        public IGenericRepository<Membres> Membres
        {
            get
            {
                if (membres == null)
                {
                    membres = new GenericRepository<Membres>(contexte);
                }
                return membres;
            }
        }

        public IGenericRepository<Publications> Publications
        {
            get
            {
                if (publications == null)
                {
                    publications = new GenericRepository<Publications>(contexte);
                }
                return publications;
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