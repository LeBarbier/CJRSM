using CJRSM.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJRSM.Models.DAL
{
    public interface ITypesJeu : IEntite
    {
        int Id { get; set; }
        int IdTypes { get; set; }
        int IdJeu { get; set; }
        
        ITypesJeu AjouterLienTypes(TypesJeu typesJeu, IUnitOfWork contexte);
    }
}
