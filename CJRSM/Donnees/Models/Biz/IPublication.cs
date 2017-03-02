using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJRSM.Models.DAL
{
    interface IPublication : IEntite
    {
        new int Id { get; set; }
        string Titre { get; set; }
        string Contenu { get; set; }
        Nullable<int> IdMembre { get; set; }

        Publication AjouterPublication(Publication nouvellePublication, IUnitOfWork contexte);
        void Modifier(Publication publication, IUnitOfWork contexte);
        void Supprimer(Publication publication, IUnitOfWork contexte);
    }
}
