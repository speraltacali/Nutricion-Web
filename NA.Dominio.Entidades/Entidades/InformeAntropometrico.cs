using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Base.BaseDto;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("InformeAntropometrico")]
    public class InformeAntropometrico : BaseEntity
    {
        public int Numero { get; set; }

        public string Observacion { get; set; }

        public decimal PorcentajeGrasa { get; set; }

        public decimal PorcentajeMusculo { get; set; }

        public decimal KilosGrasa { get; set; }

        public decimal KilosMusculo { get; set; }

        public DateTime Fecha { get; set; }

        public bool Eliminado { get; set; }

        public long PacienteId { get; set; }

        //******************************************************//

        public virtual Paciente Paciente { get; set; }

        public virtual ICollection<InformeCircunferencia> InformeCircunferencia { get; set; }
    }
}
