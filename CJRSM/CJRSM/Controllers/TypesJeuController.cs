using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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

        //public ActionResult Index()
        //{
        //    return View(db.TypesJeus.ToList());
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TypesJeu typesJeu = db.TypesJeus.Find(id);
        //    if (typesJeu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(typesJeu);
        //}

        public ActionResult Ajout()
        {
            //Jeu jeu = new Jeu();
            //jeu = contexte.Jeu.Find(id);
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
        
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TypesJeu typesJeu = db.TypesJeus.Find(id);
        //    if (typesJeu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(typesJeu);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,IdTypes,IdJeu")] TypesJeu typesJeu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(typesJeu).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(typesJeu);
        //}
        
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TypesJeu typesJeu = db.TypesJeus.Find(id);
        //    if (typesJeu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(typesJeu);
        //}
        
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TypesJeu typesJeu = db.TypesJeus.Find(id);
        //    db.TypesJeus.Remove(typesJeu);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
