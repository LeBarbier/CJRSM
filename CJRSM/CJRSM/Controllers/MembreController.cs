using CJRSM.Models.Biz;
using CJRSM.Models.DAL;
using CJRSM.Models.View.Membre;
using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CJRSM.Controllers
{
    public class MembreController : Controller
    {
        private IGenericRepository<Membres> repo;
        private IUnitOfWork contexte;
        IMembre membre;

        public MembreController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Membres;
        }

        public MembreController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Membres;
        }

        public ActionResult PremiereConnexion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PremiereConnexion(PremiereConnexion NewMembre, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                membre = FabriqueMembre.RetourneMembre(NewMembre.NoDossier);
                membre = membre.Trouver(NewMembre.NoDossier, contexte);
                if (membre.NoDossier == NewMembre.NoDossier)
                {
                    membre.Nom = NewMembre.Nom;
                    membre.Prenom = NewMembre.Prenom;
                    membre.MDP = FaireHashage(NewMembre.MDP, 5);
                    membre.Modifier(membre, contexte);
                    if (returnUrl != null)
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }else
                {
                    ModelState.AddModelError("", "La première connexion à déjà été effectuer avec ce numéro de dossier.");
                    return View(NewMembre);
                }
            }else
            {
                ModelState.AddModelError("", "Les données sont erronées");
                return View(NewMembre);
            }
        }

        public ActionResult Connexion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Connexion(Connexion modele, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (identiteValide(modele.NoDossier, modele.MDP))
                {
                    membre = (IMembre) new Membres();
                    membre = membre.Trouver(modele.NoDossier, contexte);
                    FormsAuthentication.SetAuthCookie(modele.NoDossier, modele.Persistant);
                    if (returnUrl != null)
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Le numéro de dossier ou le mot de passe n'est pas valide.");
                return View(modele);
            }
            return View(modele);
        }

        private string FaireHashage(string MDP, int num)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            String MDPHacher = encoder.Encode(MDP);
            String MDPSaleHacher = getSalage(num) + MDPHacher;
            return MDPSaleHacher;
        }

        private string getSalage(int num)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[num];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public bool identiteValide(string p1, string p2)
        {
            try
            {
                membre = (IMembre)new Membres();
                membre = membre.Trouver(p1, contexte);

                if (CompareMDP(membre.MDP, p2) == true)
                    return true;
                else
                    return false;
            }
            catch (Exception e) {
                return false;
            }
        }

        private bool CompareMDP(string mdP, string p2)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            try
            {
                if (encoder.Compare(p2, mdP.Substring(8)))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }


        }
    }
}