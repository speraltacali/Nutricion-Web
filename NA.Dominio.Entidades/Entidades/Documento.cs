using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Base.BaseDto;

namespace NA.Dominio.Entidades.Entidades
{
    [Table("Documento")]
    public class Documento : BaseEntity
    {
        public string Nombre { get; set; }

        public string NombreReal { get; set; }

        public byte[] Doc { get; set; }

        [ForeignKey("Dieta")]
        public long DietaId { get; set; }

        //**************************************************//

        public virtual Dieta Dieta { get; set; }

    }
}
