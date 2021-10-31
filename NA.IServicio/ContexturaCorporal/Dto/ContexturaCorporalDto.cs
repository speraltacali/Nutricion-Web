using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.ContexturaCorporal.Dto
{
    public class ContexturaCorporalDto : BaseDto
    {
        public long IAntropometricoId { get; set; }

        public decimal Peso { get; set; }

        public decimal Altura { get; set; }

        public DateTime FechaInforme { get; set; }

        public bool Eliminado { get; set; }

    }
}
