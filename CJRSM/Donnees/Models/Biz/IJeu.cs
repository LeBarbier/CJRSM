using System;
using System.ComponentModel.DataAnnotations;

namespace CJRSM.Models.DAL
{
    public interface IJeu : IEntite
    {
        new int Id { get; set; }

        [Display(Name = "Titre")]
        string Titre { get; set; }

        [Display(Name = "Difficulté")]
        int Difficulte { get; set; }

        [Display(Name = "Nombre de joueur minimal")]
        int NbrJoueurMin { get; set; }

        [Display(Name = "Nombre de joueur Maximal")]
        int NbrJoueurMax { get; set; }

        [Display(Name = "Temps minimal")]
        int TempsMin { get; set; }

        [Display(Name = "Temps maximal")]
        int TempsMax { get; set; }

        [Display(Name = "Date d'ajout")]
        DateTime DateAjout { get; set; }

        [Display(Name = "Identité du type de jeu")]
        string IdTypesJeu { get; set; }
        string IdLocationJeu { get; set; }

        void Modifier(IJeu document, IUnitOfWork contexte);
        void Supprimer(IJeu document, IUnitOfWork contexte);
    }
}
