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
                List<int> peso = new List<int>();
                List<string> fechasPeso = new List<string>();

                foreach (var item in informes)
                {
                    var pesos = _contexturaCorporalServicio.ObtenerPorInforme(item.Id);

                    if(pesos != null)
                    {
                        peso.Add(Convert.ToInt32(pesos.Peso));
                        fechasPeso.Add(item.Fecha.ToShortDateString());
                    }

                    fechas.Add(item.Fecha.ToShortDateString());
                    porcentajeMusculo.Add(Convert.ToInt32(item.PorcentajeMusculo));
                    porcentajeGrasa.Add(Convert.ToInt32(item.PorcentajeGrasa));                    
                }             
               

                ViewData["InformesFechas"] = fechas;
                ViewData["InformesPorcentajeMusculo"] = porcentajeMusculo;
                ViewData["InformesPorcentajeGrasa"] = porcentajeGrasa;
                ViewData["PesoCorporal"] = peso;
                ViewData["FechaPeso"] = fechasPeso;



                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}