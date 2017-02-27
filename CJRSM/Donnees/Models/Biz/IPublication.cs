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
        Nullable<int> IdMembre { get; set; }

        Publication AjouterPublication(Publication nouvellePublication, IUnitOfWork contexte);
    }
}
