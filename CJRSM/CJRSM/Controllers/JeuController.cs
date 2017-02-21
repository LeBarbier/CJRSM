using CJRSM.Models.DAL;
using CJRSM.Models.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJRSM.Controllers
{
    public class JeuController : Controller
    {
        private IGenericRepository<Jeu> repo;
        private IUnitOfWork contexte;

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
                                    string Types,
                                    //DateTime DateAjout,
                                    int Difficulte = 0,
                                    int NbrJoueurMin = 0,
                                    int NbrJoueurMax = 0,
                                    int TempsMin = 0,
                                    int TempsMax = 0)
        {
            if (ChercherTitre == null)
                ChercherTitre = "";
            //if (Difficulte == null)
            //    Difficulte = 0;
            //if (NbrJoueurMin == 0)
            //    NbrJoueurMin = 0;
            //if (NbrJoueurMax == 0)
            //    NbrJoueurMax = 0;
            //if (TempsMin == null)
            //    TempsMin = "";
            //if (TempsMax == null)
            //    TempsMax = "";
            //if (DateAjout == null)
            //    DateAjout = "";
            if (Types == null)
                Types = "";
            IEnumerable<Jeu> listeJeu = repo.Get(j => j.Titre.Contains(ChercherTitre) && 
                                                        j.Difficulte.Equals(Difficulte)).Select(j => j);
            return View(listeJeu);
        }
    }
}