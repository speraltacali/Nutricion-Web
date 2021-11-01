using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Usuario.Dto
{
    public class UsuarioDto : BaseDto
    {
        public string User { get; set; }

        public string Password { get; set; }

        public bool Bloqueado { get; set; }

        public bool Eliminado { get; set; }

        public string Token { get; set; }

        public long PacienteId { get; set; }

    }
}
