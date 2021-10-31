using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.InformeAntropometrico.Dto
{
    public class InformeAntropometricoDto : BaseDto
    {
        public int Numero { get; set; }

        public string Observacion { get; set; }

        public decimal PorcentajeGrasa { get; set;}

        public decimal PorcentajeMusculo{ get; set; }

        public decimal KilosGrasa { get; set; }

        public decimal KilosMusculo { get; set; }

        public DateTime Fecha { get; set; }

        public bool Eliminado { get; set; }

        public long PacienteId { get; set; }
    }
}
