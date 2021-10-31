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
    [Table("ContexturaCorporal")]
    public class ContexturaCorporal : BaseEntity
    {
        [ForeignKey("InformeAntropometrico")]
        public long IAntropometricoId { get; set; }

        public decimal Peso { get; set; }

        public decimal Altura { get; set; }

        public bool Eliminado { get; set; }


        //***********************************************//

        public virtual InformeAntropometrico InformeAntropometrico { get; set; }

    }
}
