using System;
using System.Linq;
using System.Web.Mvc;

namespace CJRSM.Models.DAL
{
    public partial class Membre : IMembre
    {
        // Ajoute un document entré par un membre de l'exécutif à la base de donnée
        [Authorize(Roles = "Trésorier, Interne, Externe, Bibliothécaire, Publiciste")]
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

        // Ajoute un jeu entré par un membre de l'exécutif à la base de donnée
        [Authorize(Roles = "Trésorier, Interne, Externe, Bibliothécaire, Publiciste")]
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
            jeu.LocationJeu = null;
            contexte.Jeu.Add(jeu);
            contexte.Jeu.Save();
            return jeu;
        }

        // Ajoute un membre entré par un membre de l'exécutif à la base de donnée
        [Authorize(Roles = "Trésorier, Interne, Externe, Bibliothécaire, Publiciste")]
        public Membre AjouterMembre(Membre nouveauMembre, IUnitOfWork contexte)
        {
            Membre membre = new Membre();
            membre.NoDossier = nouveauMembre.NoDossier;
            contexte.Membre.Add(membre);
            contexte.Membre.Save();
            return membre;
        }

        // Ajoute un type entré par un membre de l'exécutif à la base de donnée
        [Authorize(Roles = "Trésorier, Interne, Externe, Bibliothécaire, Publiciste")]
        public Type AjouterType(Type nouveauType, IUnitOfWork contexte)
        {
            Type type = new Type();
            type.Nom = nouveauType.Nom;
            contexte.Types.Add(type);
            contexte.Types.Save();
            return type;
        }

        // Modifie un membre selon ce dernier dans la base de donnée
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

        // Trouve et retourne un membre rechercher par son numéro de dossier
        public IMembre Trouver(string noDossier, IUnitOfWork contexte)
        {
            return contexte.Membre.Get(e => e.NoDossier.Contains(noDossier)).First();
        }

        // Trouve et retourne un membre de l'exécutif rechercher par son rôle
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