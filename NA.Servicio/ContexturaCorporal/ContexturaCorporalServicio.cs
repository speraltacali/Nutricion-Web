using NA.IServicio.ContexturaCorporal;
using NA.IServicio.ContexturaCorporal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Repositorio.ContexturaCorporal;
using NA.Infraestructura.Repositorio.ContextoCorporal;

namespace NA.Servicio.ContexturaCorporal
{
    public class ContexturaCorporalServicio : IContexturaCorporalServicio
    {

        private readonly IContexturaCorporalRepositorio _contexturaCorporal = new ContexturaCorporalRepositorio();

        public ContexturaCorporalDto Agregar(ContexturaCorporalDto dto)
        {
            var obj = new Dominio.Entidades.Entidades.ContexturaCorporal()
            {
                IAntropometricoId = dto.IAntropometricoId,
                Peso = dto.Peso,
                Altura = dto.Altura,
                Eliminado = dto.Eliminado
            };

            _contexturaCorporal.Agregar(obj);
            _contexturaCorporal.Guardar();

            dto.Id = obj.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            //******* ELIMINADO LOGICO *******

            var obj = _contexturaCorporal.ObtenerPorId(id);

            if (obj != null)
            {
                obj.Eliminado = true;

                _contexturaCorporal.Modificar(obj);
                _contexturaCorporal.Guardar();
            }

        }

        public void Guardar()
        {
            _contexturaCorporal.Guardar();
        }

        public ContexturaCorporalDto Modificar(ContexturaCorporalDto dto)
        {
            var obj = _contexturaCorporal.ObtenerPorId(dto.Id);

            if (obj != null)
            {
                obj.IAntropometricoId = dto.IAntropometricoId;
                obj.Altura = dto.Altura;
                obj.Peso = dto.Peso;

                _contexturaCorporal.Modificar(obj);
                _contexturaCorporal.Guardar();

                return dto;
            }
            else
            {
                return null;
            }
        }

        public ContexturaCorporalDto ObtenerPorInforme(long id)
        {
            var obj = _contexturaCorporal.ObtenerTodo()
                .FirstOrDefault(x => x.IAntropometricoId == id);

            if (obj != null)
            {
                return new ContexturaCorporalDto()
                {
                    Id = obj.Id,
                    IAntropometricoId = obj.IAntropometricoId,
                    Peso = obj.Peso,
                    Altura = obj.Altura,
                    Eliminado = obj.Eliminado
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ContexturaCorporalDto> ObtenerPorFiltro(string cadena)
        {
            return _contexturaCorporal.ObtenerPorFiltro(x=>x.Peso.ToString().Contains(cadena) ||
                                                           x.Altura.ToString().Contains(cadena))
                .Select(x => new ContexturaCorporalDto()
                {
                    Id = x.Id,
                    IAntropometricoId = x.IAntropometricoId,
                    Peso = x.Peso,
                    Altura = x.Altura,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public ContexturaCorporalDto ObtenerPorId(long id)
        {
            var obj = _contexturaCorporal.ObtenerPorId(id);

            if (obj != null)
            {
                return new ContexturaCorporalDto()
                {
                    Id = obj.Id,
                    IAntropometricoId = obj.IAntropometricoId,
                    Peso = obj.Peso,
                    Altura = obj.Altura,
                    Eliminado = obj.Eliminado
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ContexturaCorporalDto> ObtenerTodo()
        {
            return _contexturaCorporal.ObtenerTodo()
                .Select(x => new ContexturaCorporalDto()
                {
                    Id = x.Id,
                    IAntropometricoId = x.IAntropometricoId,
                    Peso = x.Peso,
                    Altura = x.Altura,
                    Eliminado = x.Eliminado
                }).ToList();
        }

    }
}
