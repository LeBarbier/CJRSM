﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class D75E5Entities : DbContext
    {
        public D75E5Entities()
            : base("name=D75E5Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activite> Activites { get; set; }
        public virtual DbSet<ActiviteJeu> ActiviteJeus { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Jeu> Jeus { get; set; }
        public virtual DbSet<LocationDocument> LocationDocuments { get; set; }
        public virtual DbSet<LocationJeu> LocationJeus { get; set; }
        public virtual DbSet<Membre> Membres { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<TypesJeu> TypesJeus { get; set; }
    }
}
