using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.InformeCircunferencia.Dto
{
    public class InformeCiercunferenciaDto : BaseDto
    {
        public long AntropometricoId { get; set; }

        public long CircunferenciaId { get; set; }

        public string NombreCircunferencia { get; set; }

        public decimal Valor { get; set; }

    }
}
