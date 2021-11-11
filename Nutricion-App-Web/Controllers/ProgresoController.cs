using NA.IServicio.ContexturaCorporal;
using NA.IServicio.InformeAntropometrico;
using NA.Servicio.ContexturaCorporal;
using NA.Servicio.InformeAntropometrico;
using NA.Servicio.Token;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Nutricion_App_Web.Controllers
{
    public class ProgresoController : Controller
    {
        private readonly IInformeAntropometricoServicio _informeAntropometrico = new InformeAntropometricoServicio();
        private readonly IContexturaCorporalServicio _contexturaCorporalServicio = new ContexturaCorporalServicio();

        // GET: Progreso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Progreso()
        {
            var obtenerCookie = Request.Cookies["usuario"];

            if (Validar.ValidarCookie(obtenerCookie == null ? "" : obtenerCookie["token"]))
            {
               var pacienteId = Convert.ToInt64(obtenerCookie["pacienteId"]);
               var informes = _informeAntropometrico.ObtenerPorIdPaciente(pacienteId);

                List<string> fechas = new List<string>();
                List<int> porcentajeMusculo = new List<int>();
                List<int> porcentajeGrasa = new List<int>();
                List<string> peso = new List<string>();

                foreach (var item in informes)
                {
                    fechas.Add(item.Fecha.ToShortDateString());
                    porcentajeMusculo.Add(Convert.ToInt32(item.PorcentajeMusculo));
                    porcentajeGrasa.Add(Convert.ToInt32(item.PorcentajeGrasa));                    
                }             
               

                ViewData["InformesFechas"] = fechas;
                ViewData["InformesPorcentajeMusculo"] = porcentajeMusculo;
                ViewData["InformesPorcentajeGrasa"] = porcentajeGrasa;

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}