using System;

namespace CJRSM.Models.DAL
{
    public interface IActivite : IEntite
    {
        new int Id { get; set; }
        string Titre { get; set; }
        string Description { get; set; }
        Nullable<int> NbrMembreMin { get; set; }
        Nullable<int> NbrMembreMax { get; set; }
        int Jour { get; set; }
        System.TimeSpan HeureDebut { get; set; }
        System.DateTime DateDebut { get; set; }
        Nullable<int> NbrRepetion { get; set; }
        bool Accepte { get; set; }
        string IdActiviteJeu { get; set; }
        
        Participant AjouterParticipant(Participant nouveauParticipant, IUnitOfWork contexte);
        Activite Ajout(Activite nouvelleActivite, IUnitOfWork contexte);
        void Modifier(IActivite activite, IUnitOfWork contexte);
        void Supprimer(IActivite activite, IUnitOfWork contexte);
    }
}
