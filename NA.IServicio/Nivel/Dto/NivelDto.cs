using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Nivel.Dto
{
    public class NivelDto : BaseDto
    {
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public byte[] Imagen { get; set; }

        public bool Eliminado { get; set; }

        public decimal Precio { get; set; }

        public string LinkPago { get; set; }

        public long PlanId { get; set; }
    }
}
