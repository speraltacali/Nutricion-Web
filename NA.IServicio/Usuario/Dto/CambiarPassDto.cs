using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Usuario.Dto
{
    public class CambiarPassDto
    {
        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string RepetirPassword { get; set; }
    }
}
