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
    }
}