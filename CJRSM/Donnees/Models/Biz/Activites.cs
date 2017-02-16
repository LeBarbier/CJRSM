using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public class Activites
    {
        public int Id;
        private string MembreId;
        public string Titre;
        public string Jeu;
        public string Description;
        public int NbrMembreMin;
        public int NbrMembreMax;
        public int Jour;
        public DateTime HeureDebut;
        public bool Hebdomadaire;
        public DateTime DateDebut;
        public int NbrRepetition;
        public bool Accepte;
        private ArrayList Participant; 

        /****/
        Activites(string MembreId, string titre, string description, int jour, DateTime heureDebut, DateTime dateDebut){
            this.MembreId = MembreId;
            this.Titre = titre;
            this.Description = description;
            this.Jour = jour;
            this.HeureDebut = heureDebut;
            this.DateDebut = dateDebut;
            this.Hebdomadaire = false;
            this.Accepte = false;
            Participant = new ArrayList();
        }

        Activites(string membreId, string titre, string jeu, string description,
                int nbrMembreMin, int nbrMembreMax, int jour, DateTime heureDebut,
                bool hebdomadaire, DateTime dateDebut, int nbrRepetition){
            this.MembreId = membreId;
            this.Titre = titre;
            this.Jeu = jeu;
            this.Description = description;
            this.NbrMembreMin = nbrMembreMin;
            this.NbrMembreMax = nbrMembreMax;
            this.Jour = jour;
            this.HeureDebut = heureDebut;
            this.Hebdomadaire = hebdomadaire;
            this.DateDebut = dateDebut;
            this.NbrRepetition = nbrRepetition;
            this.Accepte = false;
            Participant = new ArrayList();
        }

        public string getMembreId()
        {
            return MembreId;
        }
        public void setMembreId(string MembreId)
        {
            this.MembreId = MembreId;
        }
        public ArrayList getParticipant()
        {
            return Participant;
        }
        public void AjouterParticipant(string MembreId)
        {
            Participant.Add(MembreId);
        }
        public void AccepteActivite()
        {
            this.Accepte = true;
        }
        /*public ArrayList getActivite()
        {
            return this;
        }*/
    }
}