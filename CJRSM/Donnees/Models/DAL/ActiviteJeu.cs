//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CJRSM.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActiviteJeu
    {
        public int Id { get; set; }
        public string IdJeu { get; set; }
        public string IdActivite { get; set; }
    
        public virtual Jeu JeuId { get; set; }
        public virtual Activite ActiviteId { get; set; }
    }
}
