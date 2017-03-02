using System;
using CJRSM.Models.DAL;

namespace CJRSM.Models.DAL
{
    public partial class Publication : IPublication
    {
        public Publication AjouterPublication(Publication nouvellePublication, IUnitOfWork contexte)
        {
            Publication publication = new Publication();
            publication.Id = nouvellePublication.Id;
            publication.Titre = nouvellePublication.Titre;
            publication.Contenu = nouvellePublication.Contenu;
            publication.IdMembre = nouvellePublication.IdMembre;
            publication.Membre = nouvellePublication.Membre;
            contexte.Publication.Add(publication);
            contexte.Publication.Save();
            return publication;
        }

        public void Modifier(Publication publication, IUnitOfWork contexte)
        {
            Publication modifier = contexte.Publication.Find(publication.Id);
            modifier.Id = publication.Id;
            modifier.Titre = publication.Titre;
            modifier.Contenu = publication.Contenu;
            modifier.IdMembre = publication.IdMembre;
            contexte.Publication.Update(modifier);
            contexte.Publication.Save();
        }

        public void Supprimer(Publication publication, IUnitOfWork contexte)
        {
            Publication supprimer = contexte.Publication.Find(publication.Id);
            contexte.Publication.Delete(supprimer.Id);
            contexte.Publication.Save();
        }
    }
}