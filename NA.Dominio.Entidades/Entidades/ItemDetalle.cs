using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("ItemDetalle")]
    public class ItemDetalle : BaseEntity
    {
        public string Descripcion { get; set; }

        [ForeignKey("Paciente")]
        public long PacienteId { get; set; }

        [ForeignKey("Item")]
        public long ItemId { get; set; }

        //*************************************************//

        public virtual Item Item { get; set; }

        public virtual Paciente Paciente { get; set; }

    }
}
