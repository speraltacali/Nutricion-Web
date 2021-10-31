using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Base.Helpers;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("Dieta")]
    public class Dieta : BaseEntity
    {
        [ForeignKey("InformeAntropometrico")]
        public long IAntropometricoId { get; set; }

        public TipoPlan TipoPlan { get; set; }

        public decimal Calorias { get; set; }

        public int CantidadComidas { get; set; }

        public bool Eliminado { get; set; }

        //***********************************************//

        public virtual InformeAntropometrico InformeAntropometrico { get; set; }
    }
}
