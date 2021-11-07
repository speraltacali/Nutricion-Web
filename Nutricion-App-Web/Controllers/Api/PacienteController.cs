using NA.IServicio.Paciente;
using NA.Servicio.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nutricion_App_Web.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/Pacientes")]
    public class PacienteController : ApiController
    {
        private readonly IPacienteServicio _pacienteServicio = new PacienteServicio();

        [HttpGet]
        public IHttpActionResult ObtenerTodo()
        {
            var pacientes = _pacienteServicio.ObtenerPorFiltro(string.Empty);

            return Ok(pacientes);
        }
    }
}
