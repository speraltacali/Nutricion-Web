using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.IServicio.Dieta.Dto;

namespace NA.IServicio.Dieta
{
    public interface IDietaServicio
    {
        DietaDto Agregar(DietaDto dto);

        DietaDto Modificar(DietaDto dto);

        void Eliminar(long id);

        IEnumerable<DietaDto> ObtenerTodo();

        DietaDto ObtenerPorInforme(long id);

        DietaDto ObtenerPorId(long id);

        IEnumerable<DietaDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
