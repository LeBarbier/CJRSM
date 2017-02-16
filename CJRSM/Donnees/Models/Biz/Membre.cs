using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJRSM.Models.DAL
{
    public partial class Membre : IMembre
    {
        public Document AjouterDocument()
        {
            throw new NotImplementedException();
        }

        public Jeu AjouterJeu()
        {
            throw new NotImplementedException();
        }

        public Publication AjouterPublication()
        {
            throw new NotImplementedException();
        }

        public void Modifier(IMembre membre, IUnitOfWork contexte)
        {
            throw new NotImplementedException();
        }

        public void ModifierPremiereConnexion(IMembre membre, IUnitOfWork contexte)
        {
            throw new NotImplementedException();
        }

        public IMembre Trouver(string NoDossier, IUnitOfWork contexte)
        {
            throw new NotImplementedException();
        }
    }
}