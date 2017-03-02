using CJRSM.Models.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJRSM.Controllers
{
    public class ActiviteController : Controller
    {
        private IGenericRepository<Activite> repo;
        private IUnitOfWork contexte;
        Activite activite;

        public ActiviteController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Activite;
        }

        public ActiviteController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Activite;
        }

        public ActionResult Index(string chercherTitre)
        {
            if (chercherTitre == null)
                chercherTitre = "";
            IEnumerable<Activite> listeActivite = repo.Get(a => a.Titre.Contains(chercherTitre)).Select(a => a);
            return View(listeActivite);
        }

        public ActionResult Details(int id)
        {
            activite = contexte.Activite.Find(id);
            return View(activite);
        }

        public ActionResult Ajout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajout(Activite nouvelleActivite)
        {
            if (ModelState.IsValid)
            {
                activite = new Activite();
                return View("Details", activite.Ajout(nouvelleActivite, contexte));
            }else
                return View();
        }

        public ActionResult Modifier(int id)
        {
            activite = contexte.Activite.Find(id);
            return View(activite);
        }

        [HttpPost]
        public ActionResult Modifier(Activite activiteModifier)
        {
            if (ModelState.IsValid)
            {
                activite = new Activite();
                activite.Modifier(activiteModifier, contexte);
                return RedirectToAction("Index", "Activite");
            }
            else
                return View(activite);
        }

        public ActionResult AjouterParticipant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterParticipant(Participant nouveauParticipant)
        {
            if (ModelState.IsValid)
            {
                activite = new Activite();
                return RedirectToAction("Details", "Participants", activite.AjouterParticipant(nouveauParticipant, contexte));
            }
            else
                return View();
        }
    }
}