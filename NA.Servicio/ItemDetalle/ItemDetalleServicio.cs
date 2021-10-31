using NA.Dominio.Entidades.Entidades;
using NA.Dominio.Repositorio.ItemDetalle;
using NA.Infraestructura.Repositorio.ItemDetalle;
using NA.IServicio.ItemDetalle;
using NA.IServicio.ItemDetalle.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography;

namespace NA.Servicio.ItemDetalle
{
    public class ItemDetalleServicio : IItemDetalleServicio
    {
        private readonly IItemDetalleRepositorio _itemDetalleRepositorio = new ItemDetalleRepositorio();

        public ItemDetalleDto Agregar(ItemDetalleDto dto)
        {
            var ItemDetalle = new NA.Dominio.Entidades.Entidades.ItemDetalle
            {
                Descripcion = dto.Descripcion,
                ItemId = dto.ItemId,
                PacienteId = dto.PacienteId
            };

            _itemDetalleRepositorio.Agregar(ItemDetalle);
            _itemDetalleRepositorio.Guardar();

            dto.Id = ItemDetalle.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            var detalle = _itemDetalleRepositorio.ObtenerPorId(id);

            if(detalle != null)
            {
                _itemDetalleRepositorio.Eliminar(id);
                Guardar();
            }
        }

        public void Guardar()
        {
            _itemDetalleRepositorio.Guardar();
        }

        public ItemDetalleDto Modificar(ItemDetalleDto dto)
        {
            var detalle = _itemDetalleRepositorio.ObtenerPorId(dto.Id);

            detalle.Descripcion = dto.Descripcion;
            detalle.PacienteId = dto.PacienteId;
            detalle.ItemId = dto.ItemId;

            _itemDetalleRepositorio.Modificar(detalle);
            Guardar();

            return dto;
        }

        public IEnumerable<ItemDetalleDto> ObtenerPacientePorId(long id)
        {

            return _itemDetalleRepositorio.ObtenerPorFiltro(x => x.PacienteId == id)
                                     .Select(x => new ItemDetalleDto
                                     {
                                         Id = x.Id,
                                         Descripcion = x.Descripcion,
                                         ItemId = x.ItemId,
                                         PacienteId = x.PacienteId
                                     }).ToList();
        }

        public IEnumerable<ItemDetalleDto> ObtenerPorFiltro(string cadena)
        {
            return _itemDetalleRepositorio.ObtenerPorFiltro(x=>x.Descripcion.Contains(cadena))
                                     .Select(x => new ItemDetalleDto
                                     {
                                         Id = x.Id,
                                         Descripcion = x.Descripcion,
                                         ItemId = x.ItemId,
                                         PacienteId = x.PacienteId
                                     }).ToList();
        }

        public ItemDetalleDto ObtenerPorId(long id)
        {
            var detalle = _itemDetalleRepositorio.ObtenerPorId(id);

            if(detalle != null)
            {
                return new ItemDetalleDto
                {
                    Id = detalle.Id,
                    Descripcion = detalle.Descripcion,
                    PacienteId = detalle.PacienteId,
                    ItemId = detalle.ItemId
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ItemDetalleDto> ObtenerTodo()
        {
            return _itemDetalleRepositorio.ObtenerTodo()
                .Select(x => new ItemDetalleDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    ItemId = x.ItemId,
                    PacienteId = x.PacienteId
                }).ToList();
        }
    }
}
