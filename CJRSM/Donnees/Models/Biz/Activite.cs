using System;
using System.Collections.Generic;
namespace CJRSM.Models.DAL
{
    public partial class Activite : IActivite
    {
        /****/
        //Activites(string MembreId, string titre, string description, int jour, DateTime heureDebut, DateTime dateDebut){
        //    this.MembreId = MembreId;
        //    this.Titre = titre;
        //    this.Description = description;
        //    this.Jour = jour;
        //    this.HeureDebut = heureDebut;
        //    this.DateDebut = dateDebut;
        //    this.Hebdomadaire = false;
        //    this.Accepte = false;
        //    Participant = new ArrayList();
        //}

        //Activites(string membreId, string titre, string jeu, string description,
        //        int nbrMembreMin, int nbrMembreMax, int jour, DateTime heureDebut,
        //        bool hebdomadaire, DateTime dateDebut, int nbrRepetition){
        //    this.MembreId = membreId;
        //    this.Titre = titre;
        //    this.Jeu = jeu;
        //    this.Description = description;
        //    this.NbrMembreMin = nbrMembreMin;
        //    this.NbrMembreMax = nbrMembreMax;
        //    this.Jour = jour;
        //    this.HeureDebut = heureDebut;
        //    this.Hebdomadaire = hebdomadaire;
        //    this.DateDebut = dateDebut;
        //    this.NbrRepetition = nbrRepetition;
        //    this.Accepte = false;
        //    Participant = new ArrayList();
        //}

        //public ArrayList getParticipant()
        //{
        //    return Participant;
        //}
        //public void AjouterParticipant(string MembreId)
        //{
        //    Participant.Add(MembreId);
        //}
        //public void AccepteActivite()
        //{
        //    this.Accepte = true;
        //}

        public IEnumerable<Activite> ActiviteNonAccepte(IUnitOfWork contexte)
        {
            try
            {
                return contexte.Activite.Get(e => e.Accepte.Equals(false));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Activite Ajout(Activite nouvelleActivite, IUnitOfWork contexte)
        {
            Activite activite = new Activite();
            activite.Titre = nouvelleActivite.Titre;
            activite.Description = nouvelleActivite.Description;
            activite.NbrMembreMin = nouvelleActivite.NbrMembreMin;
            activite.NbrMembreMax = nouvelleActivite.NbrMembreMax;
            activite.Jour = nouvelleActivite.Jour;
            activite.HeureDebut = nouvelleActivite.HeureDebut;
            activite.DateDebut = nouvelleActivite.DateDebut;
            activite.NbrRepetion = nouvelleActivite.NbrRepetion;
            activite.Accepte = false;
            activite.IdActiviteJeu = nouvelleActivite.IdActiviteJeu;
            contexte.Activite.Add(activite);
            contexte.Activite.Save();
            return activite;
        }

        public void Modifier(IActivite activite, IUnitOfWork contexte)
        {
            Activite modifier = contexte.Activite.Find(activite.Id);
            modifier.Id = activite.Id;
            modifier.Titre = activite.Titre;
            modifier.Description = activite.Description;
            modifier.NbrMembreMin = activite.NbrMembreMin;
            modifier.NbrMembreMax = activite.NbrMembreMax;
            modifier.Jour = activite.Jour;
            modifier.HeureDebut = activite.HeureDebut;
            modifier.DateDebut = activite.DateDebut;
            modifier.NbrRepetion = activite.NbrRepetion;
            modifier.Accepte = activite.Accepte;
            contexte.Activite.Update(modifier);
            contexte.Activite.Save();
        }

        public void Supprimer(IActivite activite, IUnitOfWork contexte)
        {
            Activite supprimer = contexte.Activite.Find(activite.Id);
            contexte.Activite.Delete(supprimer.Id);
            contexte.Activite.Save();
        }

        public Participant AjouterParticipant(Participant nouveauParticipant, IUnitOfWork contexte)
        {
            Participant participant = new Participant();
            participant.IdActivite = nouveauParticipant.IdActivite;
            participant.IdMembre = nouveauParticipant.IdMembre;
            contexte.Participant.Add(participant);
            contexte.Participant.Save();
            return participant;
        }
    }
}