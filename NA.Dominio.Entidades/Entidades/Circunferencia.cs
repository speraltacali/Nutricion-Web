using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Base.BaseDto;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("Circunferencia")]
    public class Circunferencia : BaseEntity
    {
        public string Nombre { get; set; }

        public bool Eliminado { get; set; }

        //***********************************************//

        public virtual ICollection<InformeCircunferencia> InformeCircunferencia { get; set; }

    }
}
