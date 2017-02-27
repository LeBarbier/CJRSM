using System;
using System.ComponentModel.DataAnnotations;

namespace CJRSM.Models.DAL
{
    public interface IDocument : IEntite
    {
        new int Id { get; set; }
        [Display(Name = "Titre")]
        string Titre { get; set; }
        [Display(Name = "Auteur-e")]
        string Auteur { get; set; }
        //bool Disponible { get; set; }
        [Display(Name = "Date d'ajout")]
        DateTime DateAjout { get; set; }
        int IdLocationDocument { get; set; }

        void Modifier(IDocument document, IUnitOfWork contexte);
        void Supprimer(IDocument document, IUnitOfWork contexte);
    }
}