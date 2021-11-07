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
    public class LoginController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioDto dto)
        {
            if(_usuarioServicio.PuedeIngresar(dto))
            {
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CambiarPass()
        {
            return View();
        }
    }
}