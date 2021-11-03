using NA.IServicio.Solicitud.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Solicitud
{
    public interface ISolicitudServicio
    {
        SolicitudDto Agregar(SolicitudDto dto);

        SolicitudDto Modificar(SolicitudDto dto);

        void Eliminar(long id);

        IEnumerable<SolicitudDto> ObtenerTodo();

        SolicitudDto ObtenerPorId(long id);

        IEnumerable<SolicitudDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
