using NA.IServicio.Usuario;
using NA.Servicio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.Token
{
    public static class Validar
    {
        private static readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

        public static bool ValidarCookie(string token)
        {


            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            else
            {
                return _usuarioServicio.ValidarToken(token);
            }
        }
    }
}
