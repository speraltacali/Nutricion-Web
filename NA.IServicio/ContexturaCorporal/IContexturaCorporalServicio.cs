using NA.IServicio.ContexturaCorporal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.ContexturaCorporal
{
    public interface IContexturaCorporalServicio
    {
        ContexturaCorporalDto Agregar(ContexturaCorporalDto dto);

        ContexturaCorporalDto Modificar(ContexturaCorporalDto dto);

        void Eliminar(long id);

        IEnumerable<ContexturaCorporalDto> ObtenerTodo();

        ContexturaCorporalDto ObtenerPorId(long id);

        ContexturaCorporalDto ObtenerPorInforme(long id);

        IEnumerable<ContexturaCorporalDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
