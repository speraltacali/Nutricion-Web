using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("InformeCircunferencia")]
    public class InformeCircunferencia : BaseEntity
    {
        [ForeignKey("InformeAntropometrico")]
        public long AntropometricoId { get; set; }

        [ForeignKey("Circunferencia")]
        public long CircunferenciaId { get; set; }

        public decimal Valor { get; set; }

        //***********************************************//

        public virtual InformeAntropometrico InformeAntropometrico { get; set; }

        public virtual Circunferencia Circunferencia { get; set; }
    }
}
