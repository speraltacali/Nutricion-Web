using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    public class Nivel : BaseEntity
    {
        public string Titulo { get; set; }

        public string Descripcion { get; set; }
            
        public byte[] Imagen { get; set; }

        public bool Eliminado { get; set; }

        public decimal Precio { get; set; }

        public string LinkPago { get; set; }

        public long PlanId { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual IEnumerable<Solicitud> Solicitud { get; set; }
    }
}
