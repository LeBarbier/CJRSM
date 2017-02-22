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
        public int NbrJoueurMin;
        public int NbrJoueurMax;
        public int TempsMin;
        public int TempsMax;
        public DateTime DateAjout;
        public string IdTypesJeu;
        public string IdLocationJeu;

        Jeux()
        {

        }
        public ArrayList getActivite()
        {
            return null;
        }
    }
}