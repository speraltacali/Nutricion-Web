using NA.IServicio.Usuario;
using NA.IServicio.Usuario.Dto;
using NA.Servicio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nutricion_App_Web.Controllers.Api
{
    public class LoginController : ApiController
    {
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();



    }
}
