using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CJRSM.Models.View.Membre
{
    public class Connexion
    {
        [Display(Name ="NoDossier"), StringLength(7)]
        public string NoDossier { get; set; }

        [Display(Name = "MDP"), DataType(DataType.Password), StringLength(20, MinimumLength = 6)]
        public string MDP { get; set; }

        [Display(Name = "Persistant")]
        public bool Persistant { get; set; }

        [Display(Name = "Role")]
        public string role { get; set; }
    }
}