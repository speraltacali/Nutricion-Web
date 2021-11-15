using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    public class ObraSocialPaciente : BaseEntity
    {
        public long PacienteId { get; set; }


        public long ObraSocialId { get; set; }

        public string NumeroAfiliado { get; set; }

        //********************************************************//


    }
}
