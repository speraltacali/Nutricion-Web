using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.ObraSocialPaciente.Dto
{
    public class ObraSocialPacienteDto : BaseDto
    {
        public long PacienteId { get; set; }

        public long ObraSocialId { get; set; }

        public string NumeroAfiliado { get; set; }
    }
}
