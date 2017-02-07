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
        private IGenericRepository<Jeux> repo;
        private IUnitOfWork contexte;

        public JeuController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Jeux;
        }

        public JeuController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Jeux;
        }

        public ActionResult Index(string ChercherTitre)
        {
            if (ChercherTitre == null)
                ChercherTitre = "";
            IEnumerable<Jeux> listeJeu = repo.Get(j => j.Titre.Contains("")).Select(j => j);
            listeJeu = listeJeu.Select(j => j);
            return View(listeJeu);
        }
        public ActionResult ListeJeux()
        {
            return View();
        }
    }
}