using NA.Dominio.Repositorio.ObraSocialPaciente;
using NA.Infraestructura.Repositorio.ObraSocialPaciente;
using NA.IServicio.ObraSocialPaciente;
using NA.IServicio.ObraSocialPaciente.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.ObraSocialPaciente
{
    public class ObraSocialPacienteServicio : IObraSocialPacienteServicio
    {
        private readonly IObraSocialPacienteRepositorio _obraSocialPacienteRepositorio = new ObraSocialPacienteRepositorio();

        public ObraSocialPacienteDto Agregar(ObraSocialPacienteDto dto)
        {
            var afiliado = new Dominio.Entidades.Entidades.ObraSocialPaciente
            {
                ObraSocialId = dto.ObraSocialId,
                PacienteId = dto.PacienteId,
                NumeroAfiliado = dto.NumeroAfiliado
            };

            _obraSocialPacienteRepositorio.Agregar(afiliado);
            _obraSocialPacienteRepositorio.Guardar();

            dto.Id = afiliado.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            var afiliado = _obraSocialPacienteRepositorio.ObtenerPorId(id);

            if(afiliado != null)
            {
                _obraSocialPacienteRepositorio.Eliminar(afiliado.Id);
                _obraSocialPacienteRepositorio.Guardar();
            }
        }

        public void Guardar()
        {
            _obraSocialPacienteRepositorio.Guardar();
        }

        public ObraSocialPacienteDto Modificar(ObraSocialPacienteDto dto)
        {
            var afiliado = _obraSocialPacienteRepositorio.ObtenerPorId(dto.Id);

            if (afiliado != null)
            {

                afiliado.ObraSocialId = dto.ObraSocialId;
                afiliado.PacienteId = dto.PacienteId;
                afiliado.NumeroAfiliado = dto.NumeroAfiliado;

                _obraSocialPacienteRepositorio.Modificar(afiliado);
                _obraSocialPacienteRepositorio.Guardar();

                return dto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ObraSocialPacienteDto> ObtenerPorFiltro(string cadena)
        {
            return _obraSocialPacienteRepositorio.ObtenerTodo()
               .Select(x => new ObraSocialPacienteDto
               {
                   Id = x.Id,
                   ObraSocialId = x.ObraSocialId,
                   PacienteId = x.PacienteId,
                   NumeroAfiliado = x.NumeroAfiliado
               }).ToList();
        }

        public ObraSocialPacienteDto ObtenerPorId(long id)
        {
            var afiliado = _obraSocialPacienteRepositorio.ObtenerPorId(id);

            if(afiliado != null)
            {
                return new ObraSocialPacienteDto
                {
                    Id = afiliado.Id,
                    ObraSocialId = afiliado.ObraSocialId,
                    PacienteId = afiliado.PacienteId,
                    NumeroAfiliado = afiliado.NumeroAfiliado
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ObraSocialPacienteDto> ObtenerPorObraSocial(long id)
        {
            return _obraSocialPacienteRepositorio.ObtenerPorFiltro(x=> x.ObraSocialId == id)
               .Select(x => new ObraSocialPacienteDto
               {
                   Id = x.Id,
                   ObraSocialId = x.ObraSocialId,
                   PacienteId = x.PacienteId,
                   NumeroAfiliado = x.NumeroAfiliado
               }).ToList();
        }

        public IEnumerable<ObraSocialPacienteDto> ObtenerTodo()
        {
            return _obraSocialPacienteRepositorio.ObtenerTodo()
                .Select(x => new ObraSocialPacienteDto
                {
                    Id = x.Id,
                    ObraSocialId = x.ObraSocialId,
                    PacienteId = x.PacienteId,
                    NumeroAfiliado = x.NumeroAfiliado
                }).ToList();
        }
    }
}
