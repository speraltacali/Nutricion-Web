using NA.IServicio.InformeAntropometrico.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.InformeAntropometrico
{
    public interface IInformeAntropometricoServicio
    {
        InformeAntropometricoDto Agregar(InformeAntropometricoDto dto);

        InformeAntropometricoDto Modificar(InformeAntropometricoDto dto);

        void Eliminar(long id);

        IEnumerable<InformeAntropometricoDto> ObtenerTodo();

        IEnumerable<InformeAntropometricoDto> ObtenerPorFechaMayor(long id, long pacienteId);

        IEnumerable<InformeAntropometricoDto> ObtenerPorRangoFecha(long desde, long hasta , long pacienteId);

        InformeAntropometricoDto ObtenerPorId(long id);

        IEnumerable<InformeAntropometricoDto> ObtenerPorIdPaciente(long id);

        IEnumerable<InformeAntropometricoDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
