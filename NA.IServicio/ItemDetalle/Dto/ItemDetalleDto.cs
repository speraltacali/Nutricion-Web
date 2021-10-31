using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.ItemDetalle.Dto
{
    public class ItemDetalleDto : BaseDto
    {
        public string ItemNombre { get; set; }

        public string Descripcion { get; set; }

        public long PacienteId { get; set; }

        public long ItemId { get; set; }
    }
}
