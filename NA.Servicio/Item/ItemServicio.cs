using NA.Dominio.Entidades.Entidades;
using NA.Dominio.Repositorio.Item;
using NA.Infraestructura.Repositorio.Item;
using NA.IServicio.Item;
using NA.IServicio.Item.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.Item
{
    public class ItemServicio : IItemServicio
    {
        private readonly IItemRepositorio _itemRepositorio = new ItemRepositorio();

        public ItemDto Agregar(ItemDto dto)
        {
            var Item = new NA.Dominio.Entidades.Entidades.Item
            {
                Nombre = dto.Nombre,
                Eliminado = dto.Eliminado
            };

            _itemRepositorio.Agregar(Item);
            _itemRepositorio.Guardar();

            dto.Id = Item.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            //***** ELIMINADO LOGICO *********

            var item = _itemRepositorio.ObtenerPorId(id);

            if(item != null)
            {
                item.Eliminado = true;

                _itemRepositorio.Modificar(item);
                Guardar();
            }
        }

        public void Guardar()
        {
            _itemRepositorio.Guardar();
        }

        public ItemDto Modificar(ItemDto dto)
        {
            var item = _itemRepositorio.ObtenerPorId(dto.Id);

            item.Nombre = dto.Nombre;

            _itemRepositorio.Modificar(item);
            Guardar();

            return dto;
        }

        public IEnumerable<ItemDto> ObtenerPorFiltro(string cadena)
        {
            return _itemRepositorio.ObtenerPorFiltro(x=>x.Nombre.Contains(cadena) && x.Eliminado != true)
                .Select(x => new ItemDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public ItemDto ObtenerPorId(long id)
        {
            var item = _itemRepositorio.ObtenerPorId(id);

            if(item != null)
            {
                return new ItemDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Eliminado = item.Eliminado
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ItemDto> ObtenerTodo()
        {
            return _itemRepositorio.ObtenerTodo(x=>x.Eliminado == false)
                .Select(x => new ItemDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Eliminado = x.Eliminado
                }).ToList();
        }
    }
}
