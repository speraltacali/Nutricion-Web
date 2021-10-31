using NA.IServicio.InformeCircunferencia.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.InformeCircunferencia
{
    public interface IInformeCircunferenciaServicio
    {
        InformeCiercunferenciaDto Agregar(InformeCiercunferenciaDto dto);

        InformeCiercunferenciaDto Modificar(InformeCiercunferenciaDto dto);

        void Eliminar(long id);

        IEnumerable<InformeCiercunferenciaDto> ObtenerTodo();

        IEnumerable<InformeCiercunferenciaDto> ObtenerPorAntropometrico(long id);

        InformeCiercunferenciaDto ObtenerPorId(long id);

        IEnumerable<InformeCiercunferenciaDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
