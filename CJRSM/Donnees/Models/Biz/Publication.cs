namespace CJRSM.Models.DAL
{
    public partial class Publication : IPublication
    {
        // Ajoute la nouvelle publication proposé par un membre à la base de donnée
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

        // Modifie une publication selon un utilisateur dans la base de donnée
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

        // Supprime une publication sélectionné par utilisateur de la base de donnée
        public void Supprimer(Publication publication, IUnitOfWork contexte)
        {
            Publication supprimer = contexte.Publication.Find(publication.Id);
            contexte.Publication.Delete(supprimer.Id);
            contexte.Publication.Save();
        }
    }
}