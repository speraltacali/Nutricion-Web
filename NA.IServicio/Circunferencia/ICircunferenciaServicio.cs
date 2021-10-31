using NA.IServicio.Circunferencia.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Circunferencia
{
    public interface ICircunferenciaServicio
    {
        CircunferenciaDto Agregar(CircunferenciaDto dto);

        CircunferenciaDto Modificar(CircunferenciaDto dto);

        void Eliminar(long id);

        IEnumerable<CircunferenciaDto> ObtenerTodo();

        CircunferenciaDto ObtenerPorId(long id);

        IEnumerable<CircunferenciaDto> ObtenerPorFiltro(string cadena);


        void Guardar();
    }
}
