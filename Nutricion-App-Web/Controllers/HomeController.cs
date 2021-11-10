using NA.IServicio.Nivel;
using NA.IServicio.Paciente;
using NA.IServicio.Plan;
using NA.Servicio.Nivel;
using NA.Servicio.Paciente;
using NA.Servicio.Plan;
using NA.Servicio.Token;
using System.Dynamic;
using System.Web.Mvc;

namespace Nutricion_App_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanServicio _planServicio = new PlanServicio();
        private readonly INivelServicio _nivelServicio = new NivelServicio();
        private readonly IPacienteServicio _pacienteServicio = new PacienteServicio();

        public ActionResult Index()
        {
            ViewBag.Title = "Index Page";

            var planes = _planServicio.ObtenerPorFiltro(string.Empty);


            return View(planes);
        }

        //[Authorize]
        public ActionResult Home()
        {
            var obtenerCookie = Request.Cookies["usuario"];

            if (Validar.ValidarCookie(obtenerCookie == null ? "" : obtenerCookie["token"]))
            {
                ViewBag.Title = "Home Page";

                return View();
            }
            return RedirectToAction("Login", "Login");

        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";

            var planes = _planServicio.ObtenerPorFiltro(string.Empty);

            return View(planes);
        }

        public ActionResult Presentacion()
        {
            ViewBag.Title = "Presentacion Page";

            return View();
        }
        public ActionResult Plan(long planId)
        {
            ViewBag.Title = "Plan Page";

            var plan = _planServicio.ObtenerPorId(planId);
            var niveles = _nivelServicio.ObtenerPorPlanId(planId);

            ViewData["PlanTitulo"] = plan.Titulo;
            ViewData["PlanDescripcion"] = plan.Descripcion;
            ViewData["Niveles"] = niveles;

            return View();
        }
    }
}
