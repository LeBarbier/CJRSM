using System.Web.Mvc;
using CJRSM.Models.DAL;

namespace CJRSM.Controllers
{
    public class TypesJeuController : Controller
    {
        private IGenericRepository<TypesJeu> repo;
        private IUnitOfWork contexte;
        TypesJeu typesJeu;

        public TypesJeuController()
        {
            contexte = new UnitOfWork();
            repo = contexte.TypesJeu;
        }

        public TypesJeuController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.TypesJeu;
        }

        public ActionResult Ajout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajout(TypesJeu nouveaulien)
        {
            if (ModelState.IsValid)
            {
                typesJeu = new TypesJeu();
                return View("Details", typesJeu.AjouterLienTypes(nouveaulien, contexte));
            }else
                return View(typesJeu);
        }
    }
}
