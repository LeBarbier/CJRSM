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

        // Retourne la vue Index
        public ActionResult Index(string chercherTitre = "")
        {
            if (chercherTitre == null)
                chercherTitre = "";
            IEnumerable<Activite> listeActivite = repo.Get(a => a.Titre.Contains(chercherTitre)).Select(a => a);
            return View(listeActivite);
        }

        // Retourne la vue Index trier selon les parametres passé par l'utilisateur
        [HttpPost]
        public ActionResult Index(DateTime? heure = null,
                                int id = 0,
                                string chercherTitre = "",
                                int nbrPlaceRestante = 0,
                                int jour = 0,
                                int recursif = 0)
        {
            // Création du dictionnaire
            Dictionary<int, Activite> dictionnaireActivite = new Dictionary<int, Activite>();
            IEnumerable<Activite> iEnumActivite = repo.Get(j => j.Titre.Contains(""));
            List<Activite> listeActivite = new List<Activite>();
            listeActivite = iEnumActivite.ToList();
            IEnumerable<Participant> iEnumParticipant = contexte.Participant.Get(j => j.Id.ToString().Contains(""));
            List<Participant> listeParticipant = iEnumParticipant.ToList();

            // Attribution de toutes les valeurs ainsi que des clefs au dicitonnaire
            for (int i = 0; i < iEnumActivite.Count(); i++)
            {
                dictionnaireActivite.Add(i, listeActivite[i]);
            }

            // Trie du dictionnaire selon l'utilisateur
            if (chercherTitre != "" && chercherTitre != null)
            {
                for (int i = 0; i <= dictionnaireActivite.Count(); i++)
                {
                    if (!dictionnaireActivite[i].Titre.Contains(chercherTitre))
                    {
                        dictionnaireActivite.Remove(i);
                    }
                }
            }
            listeActivite = dictionnaireActivite.Values.ToList();
            dictionnaireActivite = new Dictionary<int, Activite>();
            for (int i = 0; i < listeActivite.Count(); i++)
            {
                dictionnaireActivite.Add(i, listeActivite[i]);
            }
            if (id != 0)
            {
                dictionnaireActivite = new Dictionary<int, Activite>();
                activite = contexte.Activite.Find(id);
                dictionnaireActivite.Add(1, activite);
            }

            listeActivite = dictionnaireActivite.Values.ToList();
            dictionnaireActivite = new Dictionary<int, Activite>();
            for (int i = 0; i < listeActivite.Count(); i++)
            {
                dictionnaireActivite.Add(i, listeActivite[i]);
            }
            if (nbrPlaceRestante != 0)
            {
                for (int i = 0; i <= dictionnaireActivite.Count(); i++)
                {
                    int nbrPlaceRestanteCount = listeParticipant.Count();
                    for (int j = 0; j < listeParticipant.Count(); j++)
                    {
                        if (listeParticipant[j].IdActivite == activite.Id)
                        {
                            nbrPlaceRestante--;
                        }
                    }
                    if (nbrPlaceRestanteCount <= nbrPlaceRestante)
                    {
                        dictionnaireActivite.Remove(i);
                    }
                }
            }
            listeActivite = dictionnaireActivite.Values.ToList();
            dictionnaireActivite = new Dictionary<int, Activite>();
            for (int i = 0; i < listeActivite.Count(); i++)
            {
                dictionnaireActivite.Add(i, listeActivite[i]);
            }
            if (jour != 0)
            {
                for (int i = 0; i <= dictionnaireActivite.Count(); i++)
                {
                    if (dictionnaireActivite[i].Jour != jour)
                    {
                        dictionnaireActivite.Remove(i);
                    }
                }
            }
            listeActivite = dictionnaireActivite.Values.ToList();
            dictionnaireActivite = new Dictionary<int, Activite>();
            for (int i = 0; i < listeActivite.Count(); i++)
            {
                dictionnaireActivite.Add(i, listeActivite[i]);
            }
            if (recursif != 0)
            {
                for (int i = 0; i <= dictionnaireActivite.Count(); i++)
                {
                    if (dictionnaireActivite[i].NbrRepetion != recursif)
                    {
                        dictionnaireActivite.Remove(i);
                    }
                }
            }
            listeActivite = dictionnaireActivite.Values.ToList();
            dictionnaireActivite = new Dictionary<int, Activite>();
            for (int i = 0; i < listeActivite.Count(); i++)
            {
                dictionnaireActivite.Add(i, listeActivite[i]);
            }
            if (heure != null)
            {
                for (int i = 0; i <= dictionnaireActivite.Count(); i++)
                {
                    if (!(dictionnaireActivite[i].HeureDebut.Equals(heure)))
                    {
                        dictionnaireActivite.Remove(i);
                    }
                }
            }
            // Retour du dictionnaire a un IEnumerable pour le retour a la page HTML
            iEnumActivite = dictionnaireActivite.Values;
            return View(iEnumActivite);
        }

        // Retourne la vue détails avec l'activité selectionné par l'utilisateur selon son ID
        public ActionResult Details(int id)
        {
            activite = contexte.Activite.Find(id);
            return View(activite);
        }

        // Retourne la vue Ajout
        public ActionResult Ajout()
        {
            return View();
        }

        // Retourne la vue ajout avec l'activité nouvellement créer par l'utilisateur
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

        // Retourne la vue modifier avec l'activité selectionné par l'utilisateur selon son ID
        public ActionResult Modifier(int id)
        {
            activite = contexte.Activite.Find(id);
            return View(activite);
        }

        // Retourne la vue modifier avec l'activité nouvellement modifier par l'utilisateur
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

        // Retourne la vue participant
        public ActionResult AjouterParticipant()
        {
            return View();
        }

        // Retourne la vue details avec le nouveau participant ajouté a l'activité
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