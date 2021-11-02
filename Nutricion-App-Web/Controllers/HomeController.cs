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
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Perfil()
        {
            ViewBag.Title = "Perfil Page";

            return View();
        }

        public ActionResult Informe()
        {
            ViewBag.Title = "Informe Page";

            return View();
        }

        public ActionResult Principal()
        {
            ViewBag.Title = "Principal page";

            return View("Principal", "_LayoutPrincipal");
        }
    }
}
