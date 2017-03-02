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

        //public ActionResult Index(string ChercherTitre)
        //{
        //    if (ChercherTitre == null)
        //        ChercherTitre = "";
        //    IEnumerable<Document> listeDocument = repo.Get(j => j.Titre.Contains(ChercherTitre)).Select(j => j);
        //    return View(listeDocument);
        //}

        public ActionResult Index(string ChercherTitre, string Auteur, int id = 0)
        {
            // Création du dictionnaire
            Dictionary<int, Document> dictionnaireDocument = new Dictionary<int, Document>();
            IEnumerable<Document> iEnumDocument = repo.Get(j => j.Titre.Contains(""));
            List<Document> listeDocument = new List<Document>();
            listeDocument = iEnumDocument.ToList();

            // Attribution de toutes les valeurs ainsi que des clefs au dicitonnaire
            for (int i = 0; i < iEnumDocument.Count(); i++)
            {
                dictionnaireDocument.Add(i, listeDocument[i]);
            }

            // Trie du dictionnaire selon l'utilisateur
            if (ChercherTitre != "" && ChercherTitre != null)
            {
                for (int i = 0; i < dictionnaireDocument.Count(); i++)
                {
                    if (!dictionnaireDocument[i].Titre.Contains(ChercherTitre))
                    {
                        dictionnaireDocument.Remove(i);
                    }
                }
            }
            listeDocument = dictionnaireDocument.Values.ToList();
            dictionnaireDocument = new Dictionary<int, Document>();
            for (int i = 0; i < listeDocument.Count(); i++)
            {
                dictionnaireDocument.Add(i, listeDocument[i]);
            }
            if (id != 0)
            {
                dictionnaireDocument = new Dictionary<int, Document>();
                document = contexte.Document.Find(id);
                dictionnaireDocument.Add(1, document);
            }
            listeDocument = dictionnaireDocument.Values.ToList();
            dictionnaireDocument = new Dictionary<int, Document>();
            for (int i = 0; i < listeDocument.Count(); i++)
            {
                dictionnaireDocument.Add(i, listeDocument[i]);
            }
            if (Auteur != "" && Auteur != null)
            {
                for (int i = 0; i < dictionnaireDocument.Count(); i++)
                {
                    if (!dictionnaireDocument[i].Auteur.Contains(Auteur))
                    {
                        dictionnaireDocument.Remove(i);
                    }
                }
            }

            // Retour du dictionnaire a un IEnumerable pour le retour a la page HTML
            iEnumDocument = dictionnaireDocument.Values;
            return View(iEnumDocument);
        }

        public ActionResult Modifier(int id)
        {
            document = contexte.Document.Find(id);
            return View(document);
        }

        [HttpPost]
        public ActionResult Modifier(Document documentModifier)
        {
            if (ModelState.IsValid)
            {
                document = new Document();
                document.Id = documentModifier.Id;
                document.Titre = documentModifier.Titre;
                document.Auteur = documentModifier.Auteur;
                document.Modifier(document, contexte);
                return RedirectToAction("Index", "Document");
            }
            else
                return View(document);
        }

        public ActionResult Supprimer(int id)
        {
            document = contexte.Document.Find(id);
            return View(document);
        }

        [HttpPost]
        public ActionResult Supprimer(Document documentSupprimer)
        {
            if (ModelState.IsValid)
            {
                documentSupprimer.Supprimer(documentSupprimer, contexte);
                return RedirectToAction("Index", "Document");
            }else
                return View(documentSupprimer);
        }
    }
}