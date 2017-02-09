using System.Web.Mvc;

namespace CJRSM.Models.DAL
{
    public interface IMembre : IEntite
    {
        new int Id { get; set; }
        string NoDossier { get; set; }
        string Prenom { get; set; }
        string Nom { get; set; }
        string Role { get; set; }
        string MDP { get; set; }

        void Modifier(IMembre membre, IUnitOfWork contexte);
        void ModifierPremiereConnexion(IMembre membre, IUnitOfWork contexte);
        IMembre Trouver(string NoDossier, IUnitOfWork contexte);
        [Authorize(Roles = "trésorier, interne, externe, bibliothécaire, publiciste")]
        Document AjouterDocument();
        [Authorize(Roles = "trésorier, interne, externe, bibliothécaire, publiciste")]
        Jeu AjouterJeu();
        Publication AjouterPublication();
    }
}