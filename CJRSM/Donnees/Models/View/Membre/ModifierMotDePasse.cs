using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CJRSM.Models.View.Membre
{
    public class ModifierMotDePasse
    {
        [Required]
        [Display(Name = "Ancien mot de passe.")]
        [DataType(DataType.Password)]
        public String AncienMDP { get; set; }
        [Required]
        [Display(Name = "Nouveau mot de passe.")]
        [DataType(DataType.Password)]
        public String NouveauMDP { get; set; }
        [Required]
        [Display(Name = "Confirmer le nouveau mot de passe.")]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength = 6)]
        [Compare("NouveauMDP")]
        public String ConfirmerMDP { get; set; }
    }
}