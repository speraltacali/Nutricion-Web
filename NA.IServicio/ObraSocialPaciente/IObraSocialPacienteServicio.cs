using NA.IServicio.ObraSocialPaciente.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.ObraSocialPaciente
{
    public interface IObraSocialPacienteServicio
    {
        ObraSocialPacienteDto Agregar(ObraSocialPacienteDto dto);

        ObraSocialPacienteDto Modificar(ObraSocialPacienteDto dto);

        void Eliminar(long id);

        IEnumerable<ObraSocialPacienteDto> ObtenerTodo();

        IEnumerable<ObraSocialPacienteDto> ObtenerPorObraSocial(long id);

        ObraSocialPacienteDto ObtenerPorId(long id);

        IEnumerable<ObraSocialPacienteDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
