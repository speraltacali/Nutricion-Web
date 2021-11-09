using NA.IServicio.Usuario;
using NA.IServicio.Usuario.Dto;
using NA.Servicio.Token;
using NA.Servicio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

            var user = _usuarioServicio.PuedeIngresar(dto);

            if (user != null)
            {
                user.Token = GenerarToken.Token(user.User);

                _usuarioServicio.GuardarToken(user);

                FormsAuthentication.SetAuthCookie(user.User, false);

                Session["UserId"] = user.Id;
                Session["UserToken"] = user.Token;
                Session["User"] = user.User;
                Session["PacienteId"] = user.PacienteId;

                return RedirectToAction("Home", "Home", new { id = user.PacienteId});
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult CambiarPass()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}