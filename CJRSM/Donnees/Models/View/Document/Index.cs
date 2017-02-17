using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CJRSM.Models.View.Document
{
    public class Index
    {
        [Display(Name = "Titre"), StringLength(7)]
        public string Titre { get; set; }

        [Display(Name = "Auteur-e"), DataType(DataType.Password), StringLength(20, MinimumLength = 6)]
        public string Auteur { get; set; }

        [Display(Name = "Date d'ajout")]
        public bool DateAjout { get; set; }
    }
}