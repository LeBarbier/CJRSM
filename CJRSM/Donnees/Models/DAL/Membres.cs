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
    using System.Linq;

    public partial class Membres :IEntite, IMembre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Membres()
        {
            this.Activite = new HashSet<Activites>();
            this.Jeux = new HashSet<Jeux>();
            this.Livres = new HashSet<Documents>();
            this.Publication = new HashSet<Publications>();
        }
    
        public int Id { get; set; }
        public string NoDossier { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Role { get; set; }
        public string MDP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activites> Activite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jeux> Jeux { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documents> Livres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publications> Publication { get; set; }

        public void Modifier(IMembre membre, IUnitOfWork contexte)
        {
            Membres modifier = contexte.Membres.Find(membre.Id);
            modifier.MDP = membre.MDP;
            modifier.Nom = membre.Nom;
            modifier.Prenom = membre.Prenom;
            modifier.Role = membre.Role;
            contexte.Membres.Update(modifier);
            contexte.Membres.Save();
        }

        public void ModifierPremiereConnexion(IMembre membre, IUnitOfWork contexte){
            Membres modifier = contexte.Membres.Find(membre.Id);
            modifier.Activite = null;
            modifier.Jeux = null;
            modifier.Livres = null;
            modifier.Publication = null;
            modifier.MDP = membre.MDP;
            modifier.Nom = membre.Nom;
            modifier.Prenom = membre.Prenom;
            modifier.Role = membre.Role;
            contexte.Membres.Update(modifier);
            contexte.Membres.Save();
        }

        public IMembre Trouver(string NoDossier, IUnitOfWork contexte)
        {
            return contexte.Membres.Get(m => m.NoDossier.Contains(NoDossier)).First();
        }

        public Document AjouterDocument()
        {
            throw new NotImplementedException();
        }

        public Jeu AjouterJeu()
        {
            throw new NotImplementedException();
        }

        public Publication AjouterPublication()
        {
            throw new NotImplementedException();
        }
    }
}
