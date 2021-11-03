using NA.IServicio.Nivel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Nivel
{
    public interface INivelServicio
    {
        NivelDto Agregar(NivelDto dto);

        NivelDto Modificar(NivelDto dto);

        void Eliminar(long id);

        IEnumerable<NivelDto> ObtenerTodo();

        NivelDto ObtenerPorId(long id);

        IEnumerable<NivelDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
