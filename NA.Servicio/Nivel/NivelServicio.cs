﻿using NA.Dominio.Repositorio.Nivel;
using NA.Infraestructura.Repositorio.Nivel;
using NA.IServicio.Nivel;
using NA.IServicio.Nivel.Dto;
using NA.IServicio.Plan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.Nivel
{
    public class NivelServicio : INivelServicio
    {

        private readonly INivelRepositorio _nivelRepositorio = new NivelRepositorio();

        public NivelDto Agregar(NivelDto dto)
        {
            var nivel = new Dominio.Entidades.Entidades.Nivel
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Eliminado = dto.Eliminado,
                Imagen = dto.Imagen,
                LinkPago = dto.LinkPago,
                Precio = dto.Precio,
                PlanId = dto.PlanId
            };

            _nivelRepositorio.Agregar(nivel);
            Guardar();

            dto.Id = nivel.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _nivelRepositorio.Guardar();
        }

        public NivelDto Modificar(NivelDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NivelDto> ObtenerPorFiltro(string cadena)
        {
            return _nivelRepositorio.ObtenerPorFiltro(X => X.Titulo.Contains(cadena) ||
                                                        X.Descripcion.Contains(cadena))
                                            .Select(x => new NivelDto
                                            {
                                                Id = x.Id,
                                                Titulo = x.Titulo,
                                                Descripcion = x.Descripcion,
                                                Eliminado = x.Eliminado,
                                                Imagen = x.Imagen,
                                                LinkPago = x.LinkPago,
                                                Precio = x.Precio,
                                                PlanId = x.PlanId
                                            }).ToList();
        }

        public NivelDto ObtenerPorId(long id)
        {
            var plan = _nivelRepositorio.ObtenerPorId(id);

            if (plan != null)
            {
                return new NivelDto
                {
                    Id = plan.Id,
                    Titulo = plan.Titulo,
                    Descripcion = plan.Descripcion,
                    Eliminado = plan.Eliminado,
                    Imagen = plan.Imagen,
                    LinkPago = plan.LinkPago,
                    Precio = plan.Precio,
                    PlanId = plan.PlanId
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<NivelDto> ObtenerPorPlanId(long id)
        {
            return _nivelRepositorio.ObtenerPorFiltro(x => x.PlanId == id)
                                    .Select(x => new NivelDto
                                    {
                                        Id = x.Id,
                                        Titulo = x.Titulo,
                                        Descripcion = x.Descripcion,
                                        Eliminado = x.Eliminado,
                                        Imagen = x.Imagen,
                                        LinkPago = x.LinkPago,
                                        Precio = x.Precio,
                                        PlanId = x.PlanId
                                    }).ToList();
        }

        public IEnumerable<NivelDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
