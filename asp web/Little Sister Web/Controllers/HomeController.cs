﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Little_Sister_Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.title = "Little Sister";
            ViewBag.titre = "Little Sister";
            return View();
        }
        public ActionResult Accueil()
        {
            ViewBag.title = "Little Sister";
            ViewBag.titre = "Accueil";
            return View();
        }
    }
}