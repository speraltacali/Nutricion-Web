using NA.IServicio.Paciente.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Paciente
{
    public interface IPacienteServicio
    {
        PacienteDto Agregar(PacienteDto dto);

        PacienteDto Modificar(PacienteDto dto);

        void Eliminar(long id);

        IEnumerable<PacienteDto> ObtenerTodo();

        PacienteDto ObtenerPorId(long id);

        IEnumerable<PacienteDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
