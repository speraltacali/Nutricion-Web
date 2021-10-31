using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("ObraSocialPaciente")]
    public class ObraSocialPaciente : BaseEntity
    {
        [ForeignKey("Paciente")]
        public long PacienteId { get; set; }

        [ForeignKey("ObraSocial")]
        public long ObraSocialId { get; set; }

        public string NumeroAfiliado { get; set; }

        //********************************************************//

        public virtual Paciente Paciente { get; set; }

        public virtual ObraSocial ObraSocial { get; set; }
    }
}
