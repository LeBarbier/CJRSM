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
    
    public partial class LocationDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LocationDocument()
        {
            this.Documents = new HashSet<Document>();
        }
    
        public int Id { get; set; }
        public System.DateTime DateEmprunt { get; set; }
        public System.DateTime DateRetour { get; set; }
        public Nullable<System.DateTime> DateEffective { get; set; }
        public string NoDossier { get; set; }
        public string IdDocument { get; set; }
        public Nullable<int> membre_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
