using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Circunferencia.Dto
{
    public class CircunferenciaDto : BaseDto
    {
        public string Nombre { get; set; }

        public bool Eliminado { get; set; }
    }
}
