using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CJRSM.Controllers
{
    public class JeuxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListeJeux()
        {
            return View();
        }
    }
}