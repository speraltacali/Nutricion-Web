using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("Usuario")]
    public class Usuario : BaseEntity
    {
        public string User { get; set; }

        public string Password { get; set; }

        public bool Bloqueado { get; set; }

        public int Token { get; set; }

        public bool Eliminado { get; set; }

        public long PerfilId { get; set; }

        public long PacienteId { get; set; }


        public virtual Paciente Paciente { get; set; }
    }
}
