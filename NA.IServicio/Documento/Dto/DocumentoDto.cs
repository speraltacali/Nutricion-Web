using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Servicio.Base.BaseDto;

namespace NA.IServicio.Documento.Dto
{
    public class DocumentoDto : BaseDto
    {
        public string Nombre { get; set; }

        public string NombreReal { get; set; }

        public byte[] Doc { get; set; }

        public long DietaId { get; set; }
    }
}
