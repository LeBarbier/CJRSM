using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.Biz
{
    public class Membre
    {
        public int Id;
        private string NoDossier;
        public string Prenom;
        public string Nom;
        public string Role;
        public string MDP;

        Membre()
        {

        }

        public string getNoDossier()
        {
            return NoDossier;
        }
        public void setNoDossier(string NoDossier)
        {
            this.NoDossier = NoDossier;
        }
    }
}