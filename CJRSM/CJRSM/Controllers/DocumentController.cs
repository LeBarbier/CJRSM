using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJRSM.Controllers
{
    public class DocumentController : Controller
    {
        private IGenericRepository<Document> repo;
        private IUnitOfWork contexte;
        Document document;

        public DocumentController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Document;
        }

        public DocumentController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Document;
        }

        public ActionResult Index(string ChercherTitre)
        {
            if (ChercherTitre == null)
                ChercherTitre = "";
            IEnumerable<Document> listeDocument = repo.Get(j => j.Titre.Contains(ChercherTitre)).Select(j => j);
            return View(listeDocument);
        }

        //public ActionResult Ajout()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Ajout(Document nouveauDocument)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        document = new Document();
        //        document.Titre = nouveauDocument.Titre;
        //        document.Auteur = nouveauDocument.Auteur;
        //        document.DateAjout = DateTime.Today;
        //        document.
        //    }
        //    return View();
        //}
    }
}