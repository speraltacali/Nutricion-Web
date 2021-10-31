using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("Item")]
    public class Item : BaseEntity
    {
        public string Nombre { get; set; }

        public bool Eliminado { get; set; }

        //************************************************//

        public virtual ICollection<ItemDetalle> ItemDetalles { get; set; }
    }
}
