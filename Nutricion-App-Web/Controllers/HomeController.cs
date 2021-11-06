using NA.IServicio.Nivel;
using NA.IServicio.Plan;
using NA.Servicio.Nivel;
using NA.Servicio.Plan;
using System.Web.Mvc;

namespace Nutricion_App_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanServicio _planServicio = new PlanServicio();
        private readonly INivelServicio _nivelServicio = new NivelServicio();
        public ActionResult Index()
        {
            ViewBag.Title = "Index Page";

            var planes = _planServicio.ObtenerPorFiltro(string.Empty);


            return View(planes);
        }
        public ActionResult Home()
        {
            ViewBag.Title = "Home Page";

            return View();
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

            var plan = _planServicio.ObtenerPorId(planId);  /*hay que pasarle el titulo del plan a la vista ¿?*/
            var niveles = _nivelServicio.ObtenerPorPlanId(planId);


            return View(niveles);
        }
    }
}
