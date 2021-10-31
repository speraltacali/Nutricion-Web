using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Base.Helpers;
using NA.Servicio.Base.BaseDto;

namespace NA.IServicio.Dieta.Dto
{
    public class DietaDto : BaseDto
    {
        public long IAntropometricoId { get; set; }

        public TipoPlan TipoPlan { get; set; }

        public decimal Calorias { get; set; }

        public int CantidadComidas { get; set; }

        public bool Eliminado { get; set; }
    }
}
