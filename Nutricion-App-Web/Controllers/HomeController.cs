using NA.IServicio.Usuario;
using NA.IServicio.Usuario.Dto;
using NA.Servicio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nutricion_App_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

        [HttpPost]
        public ActionResult Index(UsuarioDto dto)
        {
            ViewBag.Title = "Home Page";

            var Existe = _usuarioServicio.PuedeIngresar(dto);

            if (Existe) 
            {
                return View("Perfil", "_Layout");
            }
            else
            {
                return View("Principal", "_LayoutPrincipal");
            }

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

        public ActionResult PrincipalIndex()
        {
            return View();
        }
    }
}
