using NA.IServicio.Usuario;
using NA.IServicio.Usuario.Dto;
using NA.Servicio.Usuario;
using NA.Servicio.Token;
using System.Net;
using System.Web.Http;
using System.Threading;

namespace Nutricion_App_Web.Controllers.Api
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();


        [HttpGet]
        public IHttpActionResult Usuario()
        {
            var user = Thread.CurrentPrincipal.Identity;

            return Ok($" IPrincipal-user: {user.Name} - IsAuthenticated: {user.IsAuthenticated}");
        }

        [HttpPost]
        public IHttpActionResult Login(UsuarioDto dto)
        {
            if(dto == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (_usuarioServicio.PuedeIngresar(dto) != null)
            {
                var token = GenerarToken.Token(dto.User);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
