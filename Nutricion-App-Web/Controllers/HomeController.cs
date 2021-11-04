using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nutricion_App_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Index Page";

            return View();
        }
        public ActionResult Home()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";

            return View();
        }

        public ActionResult Presentacion()
        {
            ViewBag.Title = "Presentacion Page";

            return View();
        }
    }
}
