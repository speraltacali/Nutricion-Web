using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Dominio.Entidades.Entidades
{
    public class Contenido : BaseEntity
    {
        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string Cuerpo { get; set; }

        public byte[] Imagen { get; set; }
        
        public bool Habilitado { get; set; }

        public bool Eliminado { get; set; }
    }
}
