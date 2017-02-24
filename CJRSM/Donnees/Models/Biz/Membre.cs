using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public partial class Membre : IMembre
    {
        public Document AjouterDocument(Document nouveauDocument, IUnitOfWork contexte)
        {
            Document document = new Document();
            document.Titre = nouveauDocument.Titre;
            document.Auteur = nouveauDocument.Auteur;
            document.DateAjout = DateTime.Today;
            document.IdLocationDocument = null;
            contexte.Document.Add(document);
            contexte.Document.Save();
            return document;
        }

        public Jeu AjouterJeu(Jeu nouveauJeu, IUnitOfWork contexte)
        {
            Jeu jeu = new Jeu();
            jeu.Titre = nouveauJeu.Titre;
            jeu.Difficulte = nouveauJeu.Difficulte;
            jeu.NbrJoueurMin = nouveauJeu.NbrJoueurMin;
            jeu.NbrJoueurMax = nouveauJeu.NbrJoueurMax;
            jeu.TempsMin = nouveauJeu.TempsMin;
            jeu.TempsMax = nouveauJeu.TempsMax;
            jeu.DateAjout = DateTime.Today;
            jeu.TypesJeu = null;
            jeu.LocationJeu = null;
            contexte.Jeu.Add(jeu);
            contexte.Jeu.Save();
            return jeu;
        }

        public Publication AjouterPublication()
        {
            throw new NotImplementedException();
        }

        public void Modifier(IMembre membre, IUnitOfWork contexte)
        {
            Membre modifier = contexte.Membre.Find(membre.Id);
            modifier.Nom = membre.Nom;
            modifier.Prenom = membre.Prenom;
            modifier.MDP = membre.MDP;
            modifier.Role = membre.Role;
            contexte.Membre.Update(modifier);
            contexte.Membre.Save();
        }

        public void ModifierPremiereConnexion(IMembre membre, IUnitOfWork contexte)
        {
            throw new NotImplementedException();
        }

        public IMembre Trouver(string noDossier, IUnitOfWork contexte)
        {
            return contexte.Membre.Get(e => e.NoDossier.Contains(noDossier)).First();
        }
        public IMembre TrouverExecutif(string role, IUnitOfWork contexte)
        {
            try
            {
                return contexte.Membre.Get(e => e.Role.Contains(role)).First();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}