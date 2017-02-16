using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public class Jeux
    {
        public int Id;
        public string Titre;
        public int Difficulte;
        public ArrayList Type;
        public int NbrJoueurMin;
        public int NbrJoueurMax;
        public int TempsMin;
        public int TempsMax;
        public bool Disponible;
        private string MembreId;
        public DateTime DateAjout;

        Jeux()
        {

        }

        public string getMembreId()
        {
            return MembreId;
        }
        public void setMembreId(string MembreId)
        {
            this.MembreId = MembreId;
        }
        public ArrayList getActivite()
        {
            return null;
        }
    }
}