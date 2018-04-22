using Little_Sister_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Little_Sister_Web.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public async Task<ActionResult> Index()
        {
            var request = new RequestApi();
            ViewBag.request = await request.GetAllUsers();
            return View();
        }
        public ActionResult Rechercher(string nom,string id, bool ghost)
        {
            ViewBag.name = nom;
            ViewBag.photo = id;
            ViewBag.ghost = ghost;
            return View();
        }
        public ActionResult Verrouiller()
        {
            return View();
        }
    }
}