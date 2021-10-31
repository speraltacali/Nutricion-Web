using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Item.Dto
{
    public class ItemDto : BaseDto
    {
        public string Nombre { get; set; }

        public bool Eliminado { get; set; }
    }
}
