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

        // Retourne la vue Ajout
        public ActionResult Ajout()
        {
            return View();
        }

        // Retourne la vue details après avoir créer le nouveau lien de
        //      TypesJeu entre le jeu et le type sélectionné
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
