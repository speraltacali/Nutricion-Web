using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Plan.Dto
{
    public class PlanDto : BaseDto
    {
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}
