using CJRSM.Models.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJRSM.Controllers
{
    public class ActiviteController : Controller
    {
        private IGenericRepository<Activite> repo;
        private IUnitOfWork contexte;
        Activite activite;

        public ActiviteController()
        {
            contexte = new UnitOfWork();
            repo = contexte.Activite;
        }

        public ActiviteController(IUnitOfWork contexte)
        {
            this.contexte = contexte;
            repo = contexte.Activite;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}