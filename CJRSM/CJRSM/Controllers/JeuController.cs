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

        public ActionResult Index(string ChercherTitre)
        {
            if (ChercherTitre == null)
                ChercherTitre = "";
            IEnumerable<Jeu> listeJeu = repo.Get(j => j.Titre.Contains("")).Select(j => j);
            listeJeu = listeJeu.Select(j => j);
            return View(listeJeu);
        }
    }
}