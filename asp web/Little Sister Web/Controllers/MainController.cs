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
        [HttpGet]
        public ActionResult Rechercher(string name, string lastPosTime, string url, bool ghost, string mail)
        {
            ViewBag.name = name;
            ViewBag.url = url;
            ViewBag.ghost = ghost;
            ViewBag.lastPosTime = lastPosTime;
            ViewBag.mail = mail;
            return View();
        }
        public async Task<ActionResult> Verrouiller(string target)
        {
            var request = new RequestApi();
            User cible = await request.TrackUser(target);
            return View();
        }
    }
}