using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("ObraSocial")]
    public class ObraSocial : BaseEntity 
    {
        public string Nombre { get; set; }

        public bool Eliminado { get; set; }

        //********************************************************//

        public virtual ICollection<ObraSocialPaciente> ObraSocialPacientes { get; set; }
    }
}
