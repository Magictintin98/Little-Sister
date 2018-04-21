using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Little_Sister_Web.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Rechercher()
        {
            return View();
        }
        public ActionResult Verrouiller()
        {
            return View();
        }
    }
}