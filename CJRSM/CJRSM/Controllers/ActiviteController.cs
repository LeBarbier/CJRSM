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
                activite.Id = activiteModifier.Id;
                activite.Titre = activiteModifier.Titre;
                activite.Description = activiteModifier.Description;
                activite.NbrMembreMin = activiteModifier.NbrMembreMin;
                activite.NbrMembreMax = activiteModifier.NbrMembreMax;
                activite.Jour = activiteModifier.Jour;
                activite.HeureDebut = activiteModifier.HeureDebut;
                activite.DateDebut = activiteModifier.DateDebut;
                activite.NbrRepetion = activiteModifier.NbrRepetion;
                activite.Accepte = activiteModifier.Accepte;
                activite.Modifier(activite, contexte);
                return RedirectToAction("Index", "Activite");
            }
            else
                return View(activite);
        }
    }
}