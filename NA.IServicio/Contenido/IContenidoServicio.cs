using NA.IServicio.Contenido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Contenido
{
    public interface IContenidoServicio
    {
        ContenidoDto Agregar(ContenidoDto dto);

        ContenidoDto Modificar(ContenidoDto dto);

        void Eliminar(long id);

        IEnumerable<ContenidoDto> ObtenerTodo();

        ContenidoDto ObtenerPorId(long id);

        IEnumerable<ContenidoDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
