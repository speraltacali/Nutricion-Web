using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Base.BaseDto;
using NA.Dominio.Base.Helpers;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("Paciente")]
    public  class Paciente : BaseEntity
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; } 

        public DateTime FechaNacimiento { get; set; }

        public PacienteSexo Sexo { get; set; }

        public bool Eliminado { get; set; }

        //******************************************************************//

        public virtual ICollection<ItemDetalle> ItemDetalles { get; set; }

        public virtual ICollection<InformeAntropometrico> InformeAntropometricos { get; set; }

        public virtual ICollection<ObraSocialPaciente> ObraSocialPacientes { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
