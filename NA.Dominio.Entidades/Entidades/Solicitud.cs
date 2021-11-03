using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    public class Solicitud : BaseEntity
    {
        public int Numero { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public decimal Peso { get; set; }

        public decimal Altura { get; set; }

        public int Edad { get; set; }

        public string Objetivo { get; set; }

        public string Alimentacion { get; set; }

        public string Enfermedad { get; set; }

        public string Suplemento { get; set; }

        public string Gustos { get; set; }

        public string ActFisica { get; set; }

        public string Comentariio { get; set; }

        public byte[] Comprobante { get; set; }

        public bool Realizado { get; set; }

        public long NivelId { get; set; }

        public virtual Nivel Nivel { get; set; }

    }
}
