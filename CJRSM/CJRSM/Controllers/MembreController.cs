using CJRSM.Models.DAL;
using CJRSM.Models.View.Membre;
using Scrypt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.Security;

namespace CJRSM.Controllers
{
    public class MembreController : Controller
    {
        private IGenericRepository<Membre> repo;
        private IUnitOfWork contexte;
        IMembre membre;

        public MembreController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Membre;
        }

        public MembreController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Membre;
        }

        // Retourne une ArrayList de tout les membres de l'exécutif
        //      c'est-à-dire la liste de tout les Membres dans la base de donné dont le rôle
        //      est différent de membre ou qui correspond au rôle précis.
        public ArrayList TrouverExecutif()
        {
            ArrayList listeExecutif = new ArrayList();
            membre = new Membre();
            membre = membre.TrouverExecutif("Bibliothecaire", contexte);
            if (membre != null)
                listeExecutif.Add(membre.Nom+", "+membre.Prenom);
            else
                listeExecutif.Add("Aucun bibliothécaire.");

            membre = new Membre();
            membre = membre.TrouverExecutif("Externe", contexte);
            if (membre != null)
                listeExecutif.Add(membre.Nom + ", " + membre.Prenom);
            else
                listeExecutif.Add("Aucun externe.");

            membre = new Membre();
            membre = membre.TrouverExecutif("Interne", contexte);
            if (membre != null)
                listeExecutif.Add(membre.Nom + ", " + membre.Prenom);
            else
                listeExecutif.Add("Aucun interne.");

            membre = new Membre();
            membre = membre.TrouverExecutif("Publiciste", contexte);
            if (membre != null)
                listeExecutif.Add(membre.Nom + ", " + membre.Prenom);
            else
                listeExecutif.Add("Aucun publiciste.");

            membre = new Membre();
            membre = membre.TrouverExecutif("Tresorier", contexte);
            if (membre != null)
                listeExecutif.Add(membre.Nom + ", " + membre.Prenom);
            else
                listeExecutif.Add("Aucun trésorier.");

            return listeExecutif;
        }

        // Retourne la vue Executif
        public ActionResult Executif()
        {
            IEnumerable<Activite> listeActivite;
            listeActivite = contexte.Activite.Get(a => a.Titre.Contains(""));
            return View(listeActivite);
        }

        // Retourne la vue PremiereConnexion
        public ActionResult PremiereConnexion()
        {
            return View();
        }

        // Retourne la vue index ou le dernier url, après avoir ajouté
        //      l'utilisateur qui vient de se créer un compte à la base de donnée.
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
                    membre.Role = "Membre";
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

        // Retourne la vue Connexion
        public ActionResult Connexion()
        {
            return View();
        }

        // Retourne la vue index ou le dernier url, après avoir confirmer
        //      les informations de l'utilisateur et de l'avoir connecté.
        [HttpPost]
        public ActionResult Connexion(Connexion modele, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (identiteValide(modele.NoDossier, modele.MDP))
                {
                    membre = new Membre();
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

        // Retourne la vue details
        public ActionResult Details()
        {
            return View(InfoMembreModifier());
        }

        // Retourne la vue Modifier
        public ActionResult Modifier()
        {
            return View(InfoMembreModifier());
        }

        // Cette méthode permet de retrouver un membre connecté pour ensuite le modifier et le retourner
        private Membre InfoMembreModifier()
        {
            membre = FabriqueMembre.RetourneMembre(User.Identity.Name);
            membre = membre.Trouver(User.Identity.Name, contexte);
            Membre membreModifier = new Membre();
            membreModifier.Prenom = membre.Prenom;
            membreModifier.Nom = membre.Nom;
            membreModifier.Role = membre.Role;
            membreModifier.MDP = membre.MDP;
            return membreModifier;
        }

        // Retourne la vue modifier avec le membre nouvellement modifié par ce dernier
        [HttpPost]
        public ActionResult Modifier(Membre membreModifier)
        {
            membre = FabriqueMembre.RetourneMembre(User.Identity.Name);
            membre = membre.Trouver(User.Identity.Name, contexte);
            if (ModelState.IsValid)
            {
                membre.Nom = membreModifier.Nom;
                membre.Prenom = membreModifier.Prenom;
                membre.Modifier(membre, contexte);
                return RedirectToAction("Details", "Membre");
            }
            else
                return View(membre);
        }
        
        // Retourne la vue modifierMotDePasse
        public ActionResult ModifierMotDePasse()
        {
            return View();
        }

        // Retourne la vue modifierMotDePasse avec le mot de passe nouvellement modifié par ce l'utilisateur
        [HttpPost]
        public ActionResult ModifierMotDePasse(ModifierMotDePasse mdp)
        {
            if (ModelState.IsValid)
            {
                membre = FabriqueMembre.RetourneMembre(User.Identity.Name);
                membre = membre.Trouver(User.Identity.Name, contexte);
                membre.MDP = FaireHashage(mdp.NouveauMDP, 5);
                membre.Modifier(membre, contexte);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(mdp);
            }
        }

        // Déconnecte l'utilisateur et le retourne a l'index ou le dernier url connu
        public ActionResult Deconnexion(string returnUrl)
        {
            FormsAuthentication.SignOut();
            return Redirect(returnUrl);
        }

        // Méthode faisant le hashage du mot de passe
        private string FaireHashage(string MDP, int num)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            String MDPHacher = encoder.Encode(MDP);
            String MDPSaleHacher = getSalage(num) + MDPHacher;
            return MDPSaleHacher;
        }

        // Méthode pour avoir le salage du mot de passe
        private string getSalage(int num)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[num];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }

        // Méthode servant a vérifier l'identité de l'utilisateur connecté par rapport a la base donnée
        public bool identiteValide(string p1, string p2)
        {
            try
            {
                membre = new Membre();
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

        // Méthode servant a la comparaison du mot de passe entre le mot de passe
        //      fournit par l'utilisateur et celui présent dans la base de donné qui correspond au même utilisateur.
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

        // Retourne la vue AjoutMembre
        public ActionResult AjoutMembre()
        {
            return View();
        }

        // Retourne la vue AjoutMembre après avoir ajouté le nouveau membre à la base de donnée
        [HttpPost]
        public ActionResult AjoutMembre(Membre nouveauMembre)
        {
            if (ModelState.IsValid)
            {
                membre = new Membre();
                membre.AjouterMembre(nouveauMembre, contexte);
                return View("AjoutMembre");
            }
            else
                return View(true);
        }

        // Retourne la vue ajoutDocument
        public ActionResult AjoutDocument()
        {
            return View();
        }

        // Retourne la vue ajoutDocument après avoir ajouté le nouveau document à la base de donnée
        [HttpPost]
        public ActionResult AjoutDocument(Document nouveauDocument)
        {
            if (ModelState.IsValid)
            {
                membre = new Membre();
                return View("DocumentAjoute", membre.AjouterDocument(nouveauDocument, contexte));
            } else
                return View();
        }

        // Retourne la vue AjoutJeu
        public ActionResult AjoutJeu()
        {
            return View();
        }

        // Retourne la vue AjoutJeu après avoir ajouté le nouveau jeu à la base de donnée
        [HttpPost]
        public ActionResult AjoutJeu(Jeu nouveauJeu)
        {
            if (ModelState.IsValid)
            {
                membre = new Membre();
                return View("JeuAjoute", membre.AjouterJeu(nouveauJeu, contexte));
            }
            else
                return View();
        }

        // Retourne la vue AjoutType
        public ActionResult AjoutType()
        {
            return View();
        }

        // Retourne la vue AjoutType après avoir ajouté le nouveau type à la base de donnée
        [HttpPost]
        public ActionResult AjoutType(Models.DAL.Type nouveauType)
        {
            if (ModelState.IsValid)
            {
                membre = new Membre();
                return View("TypeAjoute", membre.AjouterType(nouveauType, contexte));
            }
            else
                return View();
        }
    }
}