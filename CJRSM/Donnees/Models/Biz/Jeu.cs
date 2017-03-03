using System;

namespace CJRSM.Models.DAL
{
    public partial class Jeu : IJeu
    {
        public string IdTypesJeu
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        string IJeu.IdLocationJeu
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        // Modifie un jeu selon un utilisateur dans la base de donnée
        public void Modifier(IJeu jeu, IUnitOfWork contexte)
        {
            Jeu modifier = contexte.Jeu.Find(jeu.Id);
            modifier.Titre = jeu.Titre;
            modifier.Difficulte = jeu.Difficulte;
            modifier.NbrJoueurMin = jeu.NbrJoueurMin;
            modifier.NbrJoueurMax = jeu.NbrJoueurMax;
            modifier.TempsMin = jeu.TempsMin;
            modifier.TempsMax = jeu.TempsMax;
            contexte.Jeu.Update(modifier);
            contexte.Jeu.Save();
        }

        // Supprime un jeu sélectionné par utilisateur de la base de donnée
        public void Supprimer(IJeu jeu, IUnitOfWork contexte)
        {
            Jeu supprimer = contexte.Jeu.Find(jeu.Id);
            contexte.Jeu.Delete(supprimer.Id);
            contexte.Jeu.Save();
        }

    }
}