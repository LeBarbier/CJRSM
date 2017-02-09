using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CJRSM.Models.View.Membre
{
    public class PremiereConnexion
    {
        [Display(Name = "Numéro de Dossier"), StringLength(7)]
        public string NoDossier { get; set; }

        [Display(Name = "Prénom"), StringLength(50, MinimumLength = 2)]
        public string Prenom { get; set; }

        [Display(Name = "Nom"), StringLength(50, MinimumLength = 2)]
        public string Nom { get; set; }

        [Display(Name = "Mot de Passe"), DataType(DataType.Password), StringLength(20, MinimumLength = 6)]
        public string MDP { get; set; }

        [Display(Name = "Confirmer le Mot de passe"), DataType(DataType.Password), StringLength(20, MinimumLength = 6), Required, Compare("MDP")]
        public string ConfirmerMDP { get; set; }
    }
}