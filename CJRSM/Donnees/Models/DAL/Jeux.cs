//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Donnees.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Jeux
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jeux()
        {
<<<<<<< HEAD
            this.Activite = new HashSet<Activites>();
            this.Type = new HashSet<Type>();
=======
            this.Activite = new HashSet<Activite>();
>>>>>>> defb080538b62100585d77ff091871497249917d
        }
    
        public int Id { get; set; }
        public string Titre { get; set; }
<<<<<<< HEAD
        public int Difficulte { get; set; }
        public int NbrJoueurMin { get; set; }
        public int NbrJoueurMax { get; set; }
        public int TempsMin { get; set; }
        public int TempsMax { get; set; }
        public bool Disponible { get; set; }
        public int MembreId { get; set; }
        public System.DateTime DateAjout { get; set; }
    
        public virtual Membres Membre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activites> Activite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type> Type { get; set; }
=======
        public string Difficulte { get; set; }
        public string Type { get; set; }
        public string NbrJoueurMin { get; set; }
        public string NbrJoueurMax { get; set; }
        public string TempsMin { get; set; }
        public string TempsMax { get; set; }
        public string Disponible { get; set; }
        public int MembreId { get; set; }
        public string DateAjout { get; set; }
    
        public virtual Membre Membre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activite> Activite { get; set; }
>>>>>>> defb080538b62100585d77ff091871497249917d
    }
}
