using NA.IServicio.ItemDetalle.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.ItemDetalle
{
    public interface IItemDetalleServicio
    {
        ItemDetalleDto Agregar(ItemDetalleDto dto);

        ItemDetalleDto Modificar(ItemDetalleDto dto);

        void Eliminar(long id);

        IEnumerable<ItemDetalleDto> ObtenerTodo();

        ItemDetalleDto ObtenerPorId(long id);

        IEnumerable<ItemDetalleDto> ObtenerPacientePorId(long id);

        IEnumerable<ItemDetalleDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
