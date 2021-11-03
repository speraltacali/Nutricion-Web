using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    public class Plan : BaseEntity
    {
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public virtual IEnumerable<Nivel> Nivel { get; set; }
    }
}
