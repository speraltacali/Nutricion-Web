using NA.Dominio.Repositorio.Nivel;
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
            var nivel = _nivelRepositorio.ObtenerPorId(id);

            if(nivel != null)
            {
                nivel.Eliminado = true;

                _nivelRepositorio.Modificar(nivel);
                Guardar();
            }
        }

        public void Guardar()
        {
            _nivelRepositorio.Guardar();
        }

        public NivelDto Modificar(NivelDto dto)
        {
            var nivel = _nivelRepositorio.ObtenerPorId(dto.Id);

            if(nivel != null)
            {
                nivel.Titulo = dto.Titulo;
                nivel.Descripcion = dto.Descripcion;
                nivel.Eliminado = dto.Eliminado;
                nivel.Imagen = dto.Imagen;
                nivel.LinkPago = dto.LinkPago;
                nivel.Precio = dto.Precio;
                nivel.PlanId = dto.PlanId;

                _nivelRepositorio.Modificar(nivel);

                Guardar();

                return dto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<NivelDto> ObtenerPorFiltro(string cadena)
        {
            return _nivelRepositorio.ObtenerPorFiltro(x => x.Titulo.Contains(cadena) ||
                                                        x.Descripcion.Contains(cadena)
                                                        && x.Eliminado != true)
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
            return _nivelRepositorio.ObtenerPorFiltro(x => x.PlanId == id && x.Eliminado != true)
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
