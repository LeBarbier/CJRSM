using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJRSM.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<Publication> repo;
        private IUnitOfWork contexte;
        Publication publication;

        public HomeController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Publication;
        }

        public HomeController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Publication;
        }

        public ActionResult Index()
        {
            IEnumerable<Publication> listePublication = repo.Get(p => p.Titre.Contains(""));
            return View(listePublication);
        }

        public ActionResult Details(int id)
        {
            publication = contexte.Publication.Find(id);
            return View(publication);
        }

        public ActionResult AjoutPublication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjoutPublication(Publication nouvellePublication)
        {
            if (ModelState.IsValid)
            {
                publication = new Publication();
                IMembre membreConnecter = new Membre();
                membreConnecter = membreConnecter.Trouver(User.Identity.Name, contexte);

                nouvellePublication.IdMembre = membreConnecter.Id;
                nouvellePublication.Membre = (Membre) membreConnecter;
                return View("Details", publication.AjouterPublication(nouvellePublication, contexte));
            }
            else
                return View();
        }
    }
}