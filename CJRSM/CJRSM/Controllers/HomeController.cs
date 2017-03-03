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

        // Retourne la vue Index
        public ActionResult Index()
        {
            IEnumerable<Publication> listePublication = repo.Get(p => p.Titre.Contains(""));
            return View(listePublication);
        }

        // Retourne la vue détails avec la publication selectionné par l'utilisateur selon son ID
        public ActionResult Details(int id)
        {
            publication = contexte.Publication.Find(id);
            return View(publication);
        }

        // Retourne la vue modifier avec la publication selectionné par l'utilisateur selon son ID
        public ActionResult Modifier(int id)
        {
            publication = contexte.Publication.Find(id);
            return View(publication);
        }

        // Retourne la vue modifier avec la publication nouvellement modifié par l'utilisateur
        [HttpPost]
        public ActionResult Modifier(Publication publicationModifier)
        {
            if (ModelState.IsValid)
            {
                publication = new Publication();
                publication.Modifier(publicationModifier, contexte);
                return RedirectToAction("Index", "Home");
            }
            else
                return View(publication);
        }

        // Retourne la vue supprimer avec la publication selectionné par l'utilisateur selon son ID
        public ActionResult Supprimer(int id)
        {
            publication = contexte.Publication.Find(id);
            return View(publication);
        }

        // Retourne l'utilisateur a la liste de publication avec cette dernière nouvellement supprimé par l'utilisateur
        [HttpPost]
        public ActionResult Supprimer(Publication publicationSupprimer)
        {
            if (ModelState.IsValid)
            {
                publicationSupprimer.Supprimer(publicationSupprimer, contexte);

                return RedirectToAction("Index", "Home");
            }
            else
                return View(publicationSupprimer);
        }

        // Retourne la vue AjoutPublication
        public ActionResult AjoutPublication()
        {
            return View();
        }

        // Retourne la vue Details décrivant la nouvelle publication dont l'utlisateur a ajouté
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