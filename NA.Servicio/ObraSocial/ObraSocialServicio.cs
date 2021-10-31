using NA.Dominio.Entidades.Entidades;
using NA.Dominio.Repositorio.ObraSocial;
using NA.Dominio.Repositorio.ObraSocialPaciente;
using NA.Infraestructura.Repositorio.ObraSocial;
using NA.IServicio.ObraSocial;
using NA.IServicio.ObraSocial.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.ObraSocial
{
    public class ObraSocialServicio : IObraSocialServicio
    {
        private readonly IObraSocialRepositorio _obraSocialRepositorio = new ObraSocialRepositorio();

        ObraSocialDto IObraSocialServicio.Agregar(ObraSocialDto dto)
        {
            var obraSocial = new Dominio.Entidades.Entidades.ObraSocial
            {
                Nombre = dto.Nombre,
                Eliminado = dto.Eliminado
            };

            _obraSocialRepositorio.Agregar(obraSocial);
            _obraSocialRepositorio.Guardar();

            dto.Id = obraSocial.Id;
            return dto;
        }

        void IObraSocialServicio.Eliminar(long id)
        {
            var obraSocial = _obraSocialRepositorio.ObtenerPorId(id);

            if(obraSocial != null)
            {
                obraSocial.Eliminado = true;

                _obraSocialRepositorio.Modificar(obraSocial);
                _obraSocialRepositorio.Guardar();
            }
        }

        void IObraSocialServicio.Guardar()
        {
            _obraSocialRepositorio.Guardar();
        }

        ObraSocialDto IObraSocialServicio.Modificar(ObraSocialDto dto)
        {
            var obraSocial = _obraSocialRepositorio.ObtenerPorId(dto.Id);

            if (obraSocial != null)
            {
                obraSocial.Nombre = dto.Nombre;

                _obraSocialRepositorio.Modificar(obraSocial);
                _obraSocialRepositorio.Guardar();

                return dto;
            }
            else
            {
                return null;
            }
        }

        IEnumerable<ObraSocialDto> IObraSocialServicio.ObtenerPorFiltro(string cadena)
        {
            return _obraSocialRepositorio.ObtenerPorFiltro(x=>x.Nombre.Contains(cadena) && x.Eliminado != true)
              .Select(x => new ObraSocialDto
              {
                  Id = x.Id,
                  Nombre = x.Nombre,
                  Eliminado = x.Eliminado
              }).ToList();
        }

        ObraSocialDto IObraSocialServicio.ObtenerPorId(long id)
        {
            var obraSocial = _obraSocialRepositorio.ObtenerPorId(id);

            if (obraSocial != null)
            {
                return new ObraSocialDto
                {
                    Id = obraSocial.Id,
                    Nombre = obraSocial.Nombre,
                    Eliminado = obraSocial.Eliminado
                };
            }
            else
            {
                return null;
            }
        }

        IEnumerable<ObraSocialDto> IObraSocialServicio.ObtenerTodo()
        {
            return _obraSocialRepositorio.ObtenerTodo()
                .Select(x => new ObraSocialDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Eliminado = x.Eliminado
                }).ToList();
        }
    }
}
