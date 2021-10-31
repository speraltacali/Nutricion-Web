using NA.IServicio.Item.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Item
{
    public interface IItemServicio
    {
        ItemDto Agregar(ItemDto dto);

        ItemDto Modificar(ItemDto dto);

        void Eliminar(long id);

        IEnumerable<ItemDto> ObtenerTodo();

        ItemDto ObtenerPorId(long id);

        IEnumerable<ItemDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
