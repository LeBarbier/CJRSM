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
    
    public partial class Activite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activite()
        {
            this.Membre = new HashSet<Membre>();
        }
    
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string MembreInscrit { get; set; }
        public string NbrMembreMaximum { get; set; }
        public string Jour { get; set; }
        public string DateDebut { get; set; }
        public string DateFin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Membre> Membre { get; set; }
    }
}
