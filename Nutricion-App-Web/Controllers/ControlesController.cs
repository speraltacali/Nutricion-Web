using NA.IServicio.InformeAntropometrico;
using NA.Servicio.InformeAntropometrico;
using NA.Servicio.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nutricion_App_Web.Controllers
{
    //[Authorize]
    public class ControlesController : Controller
    {
        private readonly IInformeAntropometricoServicio _informeAntropometrico = new InformeAntropometricoServicio();
        // GET: Controles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Controles(long pacienteId)
        {
            var obtenerCookie = Request.Cookies["usuario"];

            if (Validar.ValidarCookie(obtenerCookie == null ? "" : obtenerCookie["token"]))
            {
                pacienteId = Convert.ToInt64(obtenerCookie["pacienteId"]);
                var informes = _informeAntropometrico.ObtenerPorIdPaciente(pacienteId);

                ViewData["Informes"] = informes;

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}