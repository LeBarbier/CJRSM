using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace CJRSM.Controllers
{
    public class JeuController : Controller
    {
        private IGenericRepository<Jeu> repo;
        private IUnitOfWork contexte;
        Jeu jeu;

        public JeuController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Jeu;
        }

        public JeuController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Jeu;
        }

        public ActionResult Index(string ChercherTitre,
                                    int Difficulte = 0,
                                    int NbrJoueurMin = 0,
                                    int NbrJoueurMax = 0,
                                    int TempsMin = 0,
                                    int TempsMax = 0,
                                    int TypesId = 0)
        {
            // Création du dictionnaire
            Dictionary<int, Jeu> dictionnaireJeu = new Dictionary<int, Jeu>();
            IEnumerable<Jeu> iEnumJeu = repo.Get(j => j.Titre.Contains(""));
            IEnumerable<TypesJeu> iEnumTypesJeu = contexte.TypesJeu.Get(tj => tj.Id.ToString().Contains(""));
            List<Jeu> listeJeu = new List<Jeu>();
            List<TypesJeu> listeTypesJeu = new List<TypesJeu>();
            listeJeu = iEnumJeu.ToList();
            listeTypesJeu = iEnumTypesJeu.ToList();

            // Attribution de toutes les valeurs ainsi que des clefs au dicitonnaire
            for (int i = 0; i < iEnumJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }

            // Trie du dictionnaire selon l'utilisateur
            if (ChercherTitre != "" && ChercherTitre != null)
            {
                for (int i = 0; i < dictionnaireJeu.Count(); i++)
                {
                    if (!dictionnaireJeu[i].Titre.Contains(ChercherTitre))
                    {
                        dictionnaireJeu.Remove(i);
                    }
                }
            }
            listeJeu = dictionnaireJeu.Values.ToList();
            dictionnaireJeu = new Dictionary<int, Jeu>();
            for (int i = 0; i < listeJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }
            if (Difficulte != 0)
            {
                for (int i = 0; i < dictionnaireJeu.Count(); i++)
                {
                    if (dictionnaireJeu[i].Difficulte != Difficulte)
                    {
                        dictionnaireJeu.Remove(i);
                    }
                }
            }
            listeJeu = dictionnaireJeu.Values.ToList();
            dictionnaireJeu = new Dictionary<int, Jeu>();
            for (int i = 0; i < listeJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }
            if (NbrJoueurMin != 0)
            {
                for (int i = 0; i < dictionnaireJeu.Count(); i++)
                {
                    if (dictionnaireJeu[i].NbrJoueurMin < NbrJoueurMin)
                    {
                        dictionnaireJeu.Remove(i);
                    }
                }
            }
            listeJeu = dictionnaireJeu.Values.ToList();
            dictionnaireJeu = new Dictionary<int, Jeu>();
            for (int i = 0; i < listeJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }
            if (NbrJoueurMax != 0)
            {
                for (int i = 0; i < dictionnaireJeu.Count(); i++)
                {
                    if (dictionnaireJeu[i].NbrJoueurMax > NbrJoueurMax)
                    {
                        dictionnaireJeu.Remove(i);
                    }
                }
            }
            listeJeu = dictionnaireJeu.Values.ToList();
            dictionnaireJeu = new Dictionary<int, Jeu>();
            for (int i = 0; i < listeJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }
            if (TempsMin != 0)
            {
                for (int i = 0; i < dictionnaireJeu.Count(); i++)
                {
                    if (dictionnaireJeu[i].TempsMin < TempsMin)
                    {
                        dictionnaireJeu.Remove(i);
                    }
                }
            }
            listeJeu = dictionnaireJeu.Values.ToList();
            dictionnaireJeu = new Dictionary<int, Jeu>();
            for (int i = 0; i < listeJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }
            if (TempsMax != 0)
            {
                for (int i = 0; i < dictionnaireJeu.Count(); i++)
                {
                    if (dictionnaireJeu[i].TempsMax < TempsMax)
                    {
                        dictionnaireJeu.Remove(i);
                    }
                }
            }
            listeJeu = dictionnaireJeu.Values.ToList();
            dictionnaireJeu = new Dictionary<int, Jeu>();
            for (int i = 0; i < listeJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }
            if (TypesId != 0)
            {
                listeJeu = new List<Jeu>();
                for (int i = 0; i < listeTypesJeu.Count(); i++)
                {
                    if (TypesId == listeTypesJeu[i].IdTypes)
                    {
                        for (int j = 0; j < dictionnaireJeu.Count(); j++)
                        {
                            if (listeTypesJeu[i].IdJeu == dictionnaireJeu[j].Id)
                            {
                                listeJeu.Add(dictionnaireJeu[j]);
                            }
                        }
                    }
                }
            }
            dictionnaireJeu = new Dictionary<int, Jeu>();
            for (int i = 0; i < listeJeu.Count(); i++)
            {
                dictionnaireJeu.Add(i, listeJeu[i]);
            }

            // Retour du dictionnaire a un IEnumerable pour le retour a la page HTML
            iEnumJeu = dictionnaireJeu.Values;
            return View(iEnumJeu);
        }

        public ActionResult Modifier(int id)
        {
            jeu = contexte.Jeu.Find(id);
            return View(jeu);
        }

        //private Membre InfoDocumentModifier()
        //{
        //    document = new Document();
        //    document = document.Trouver(User.Identity.Name, contexte);
        //    Membre membreModifier = new Membre();
        //    membreModifier.Prenom = membre.Prenom;
        //    membreModifier.Nom = membre.Nom;
        //    membreModifier.Role = membre.Role;
        //    membreModifier.MDP = membre.MDP;
        //    return membreModifier;
        //}

        [HttpPost]
        public ActionResult Modifier(Jeu jeuModifier)
        {
            if (ModelState.IsValid)
            {
                jeu = new Jeu();
                jeu.Id = jeuModifier.Id;
                jeu.Titre = jeuModifier.Titre;
                jeu.Difficulte = jeuModifier.Difficulte;
                jeu.NbrJoueurMin = jeuModifier.NbrJoueurMin;
                jeu.NbrJoueurMax = jeuModifier.NbrJoueurMax;
                jeu.TempsMin = jeuModifier.TempsMin;
                jeu.TempsMax = jeuModifier.TempsMax;
                jeu.Modifier(jeu, contexte);
                return RedirectToAction("Index", "Jeu");
            }
            else
                return View(jeu);
        }

        public ActionResult Supprimer(int id)
        {
            jeu = contexte.Jeu.Find(id);
            return View(jeu);
        }

        [HttpPost]
        public ActionResult Supprimer(Jeu jeuSupprimer)
        {
            if (ModelState.IsValid)
            {
                jeuSupprimer.Supprimer(jeuSupprimer, contexte);

                return RedirectToAction("Index", "Jeu");
            }
            else
                return View(jeuSupprimer);
        }
    }
}