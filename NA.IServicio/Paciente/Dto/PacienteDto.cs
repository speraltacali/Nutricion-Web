using NA.Dominio.Base.Helpers;
using NA.Servicio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Paciente.Dto
{
    public class PacienteDto : BaseDto
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public PacienteSexo Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public bool Eliminado { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";
    }
}
