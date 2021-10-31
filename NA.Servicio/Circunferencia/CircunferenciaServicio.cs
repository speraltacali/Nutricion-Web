using NA.IServicio.Circunferencia;
using NA.IServicio.Circunferencia.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Repositorio.Circunferencia;
using NA.Infraestructura.Repositorio.Circunferencia;

namespace NA.Servicio.Circunferencia
{
    public class CircunferenciaServicio : ICircunferenciaServicio
    {
        private readonly ICircunferenciaRepositorio _circunferencia = new CircunferenciaRepositorio();

        public CircunferenciaDto Agregar(CircunferenciaDto dto)
        {
            var obj = new Dominio.Entidades.Entidades.Circunferencia
            {
                Nombre = dto.Nombre,
                Eliminado = dto.Eliminado
            };

            _circunferencia.Agregar(obj);
            _circunferencia.Guardar();

            dto.Id = obj.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            //******* ELIMINADO LOGICO ********

            var obj = _circunferencia.ObtenerPorId(id);

            if (obj != null)
            {
                obj.Eliminado = true;

                _circunferencia.Modificar(obj);
                _circunferencia.Guardar();
            }

        }

        public void Guardar()
        {
            _circunferencia.Guardar();
        }

        public CircunferenciaDto Modificar(CircunferenciaDto dto)
        {
            var obj = _circunferencia.ObtenerPorId(dto.Id);

            if (obj != null)
            {
                obj.Nombre = dto.Nombre;


                _circunferencia.Modificar(obj);
                _circunferencia.Guardar();

                return dto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<CircunferenciaDto> ObtenerPorFiltro(string cadena)
        {
            return _circunferencia.ObtenerPorFiltro(x=>x.Eliminado != true && x.Nombre.Contains(cadena))
                .Select(x => new CircunferenciaDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public CircunferenciaDto ObtenerPorId(long id)
        {
            var obj = _circunferencia.ObtenerPorId(id);

            if (obj != null)
            {
                return new CircunferenciaDto()
                {
                    Id = obj.Id,
                    Nombre = obj.Nombre,
                    Eliminado = obj.Eliminado
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<CircunferenciaDto> ObtenerTodo()
        {
            return _circunferencia.ObtenerTodo(x=>x.Eliminado == false)
                .Select(x => new CircunferenciaDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Eliminado = x.Eliminado
                }).ToList();
        }
    }
}
