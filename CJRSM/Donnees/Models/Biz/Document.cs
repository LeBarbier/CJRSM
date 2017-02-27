using System;

namespace CJRSM.Models.DAL
{
    public partial class Document : IDocument
    {
        int IDocument.IdLocationDocument
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Modifier(IDocument document, IUnitOfWork contexte)
        {
            Document modifier = contexte.Document.Find(document.Id);
            modifier.Titre = document.Titre;
            modifier.Auteur = document.Auteur;
            contexte.Document.Update(modifier);
            contexte.Document.Save();
        }

        public void Supprimer(IDocument document, IUnitOfWork contexte)
        {
            Document supprimer = contexte.Document.Find(document.Id);
            contexte.Document.Delete(supprimer.Id);
            contexte.Document.Save();
        }
    }
}