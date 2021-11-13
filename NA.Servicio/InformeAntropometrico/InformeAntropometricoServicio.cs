using NA.Dominio.Entidades.Entidades;
using NA.Dominio.Repositorio.InformeAntropometrico;
using NA.Infraestructura.Repositorio.InformeAntropometrico;
using NA.IServicio.InformeAntropometrico;
using NA.IServicio.InformeAntropometrico.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Repositorio.Paciente;
using NA.Infraestructura.Repositorio.Paciente;

namespace NA.Servicio.InformeAntropometrico
{
    public class InformeAntropometricoServicio : IInformeAntropometricoServicio
    {
        private readonly IInformeAntropometricoRepositorio _informeAntropometrico = new InformeAntripometricoRepositorio();
        private readonly IPacienteRepositorio _pacienteRepositorio = new PacienteRepositorio();

        public InformeAntropometricoDto Agregar(InformeAntropometricoDto dto)
        {
            var informe = new NA.Dominio.Entidades.Entidades.InformeAntropometrico
            {
                Numero = ObtenerSiguenteNumero(dto.PacienteId),
                Observacion = dto.Observacion,
                PorcentajeGrasa = dto.PorcentajeGrasa,
                PorcentajeMusculo = dto.PorcentajeMusculo,
                KilosGrasa = dto.KilosGrasa,
                KilosMusculo = dto.KilosMusculo,
                Eliminado = dto.Eliminado,
                Fecha = dto.Fecha,
                PacienteId = dto.PacienteId
            };

            _informeAntropometrico.Agregar(informe);

            _informeAntropometrico.Guardar();

            dto.Id = informe.Id;

            return dto;
        }

        public void Eliminar(long id)
        {
            //******** ELIMINADO LOGICO ********

            var obj = _informeAntropometrico.ObtenerPorId(id);

            if (obj != null)
            {
                obj.Eliminado = true;

                _informeAntropometrico.Modificar(obj);
                _informeAntropometrico.Guardar();
            }
        }

        public void Guardar()
        {
            _informeAntropometrico.Guardar();
        }

        public InformeAntropometricoDto Modificar(InformeAntropometricoDto dto)
        {
            var obj = _informeAntropometrico.ObtenerPorId(dto.Id);

            if (obj != null)
            {
                
                if(dto.Observacion != null)
                {
                    obj.Observacion = dto.Observacion;
                }

                if (dto.Fecha != null)
                {
                    obj.Fecha = dto.Fecha;
                }

                if (dto.PorcentajeGrasa != null && dto.PorcentajeMusculo!= null
                    && dto.KilosGrasa != null && dto.KilosMusculo != null)
                {
                    obj.PorcentajeGrasa = dto.PorcentajeGrasa;
                    obj.PorcentajeMusculo = dto.PorcentajeMusculo;
                    obj.KilosGrasa = dto.KilosGrasa;
                    obj.KilosMusculo = dto.KilosMusculo;
                }

                obj.PacienteId = dto.PacienteId;

                _informeAntropometrico.Modificar(obj);
                _informeAntropometrico.Guardar();

                return dto;
            }
            else
            {
                return null;
            }
        }


        public IEnumerable<InformeAntropometricoDto> ObtenerPorIdPaciente(long id)
        {
            return _informeAntropometrico.ObtenerPorFiltro(x => x.PacienteId == id && !x.Eliminado == true) 
                .Select(x => new InformeAntropometricoDto()
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    Observacion = x.Observacion,
                    PorcentajeGrasa = x.PorcentajeGrasa,
                    PorcentajeMusculo = x.PorcentajeMusculo,
                    KilosGrasa = x.KilosGrasa ,
                    KilosMusculo = x.KilosMusculo,
                    Eliminado = x.Eliminado,
                    Fecha = x.Fecha,
                    PacienteId = x.PacienteId
                }).OrderBy(x=>x.Fecha).ToList();
        }

        public IEnumerable<InformeAntropometricoDto> ObtenerPorFiltro(string cadena)
        {
            return _informeAntropometrico.ObtenerPorFiltro(x=>x.Fecha.ToString().Contains(cadena) && !x.Eliminado == true)
                .Select(x => new InformeAntropometricoDto()
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    Observacion = x.Observacion,
                    PorcentajeGrasa = x.PorcentajeGrasa,
                    PorcentajeMusculo = x.PorcentajeMusculo,
                    KilosGrasa = x.KilosGrasa,
                    KilosMusculo = x.KilosMusculo,
                    Eliminado = x.Eliminado,
                    Fecha = x.Fecha,
                    PacienteId = x.PacienteId
                }).ToList();
        }

        public InformeAntropometricoDto ObtenerPorId(long id)
        {
            var obj = _informeAntropometrico.ObtenerPorId(id);

            if (obj != null)
            {
                return new InformeAntropometricoDto()
                {
                    Id = obj.Id,
                    Numero = obj.Numero,
                    Observacion = obj.Observacion,
                    PorcentajeGrasa = obj.PorcentajeGrasa,
                    PorcentajeMusculo = obj.PorcentajeMusculo,
                    KilosGrasa = obj.KilosGrasa,
                    KilosMusculo = obj.KilosMusculo,
                    Eliminado = obj.Eliminado,
                    Fecha = obj.Fecha,
                    PacienteId = obj.PacienteId
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<InformeAntropometricoDto> ObtenerTodo()
        {
            return _informeAntropometrico.ObtenerTodo()
                .Select(x => new InformeAntropometricoDto()
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    Observacion = x.Observacion,
                    PorcentajeGrasa = x.PorcentajeGrasa,
                    PorcentajeMusculo = x.PorcentajeMusculo,
                    KilosGrasa = x.KilosGrasa,
                    KilosMusculo = x.KilosMusculo,
                    Eliminado = x.Eliminado,
                    Fecha = x.Fecha,
                    PacienteId = x.PacienteId
                }).ToList();
        }

        public int ObtenerSiguenteNumero(long id)
        {
            return _informeAntropometrico.ObtenerPorFiltro(x => x.PacienteId == id).Any()
                ? _informeAntropometrico.ObtenerPorFiltro(x=>x.PacienteId == id).Max(x => x.Numero) + 1 : 1;
        }

        public IEnumerable<InformeAntropometricoDto> ObtenerPorFechaMayor(long id , long pacienteId)
        {
            var informe = _informeAntropometrico.ObtenerPorId(id);

            return _informeAntropometrico.ObtenerPorFiltro(x=> x.Fecha > informe.Fecha && x.Fecha < DateTime.Now &&  x.Eliminado != true 
                && x.PacienteId == pacienteId )
                .Select(x => new InformeAntropometricoDto
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    Observacion = x.Observacion,
                    PorcentajeGrasa = x.PorcentajeGrasa,
                    PorcentajeMusculo = x.PorcentajeMusculo,
                    KilosGrasa = x.KilosGrasa,
                    KilosMusculo = x.KilosMusculo,
                    Eliminado = x.Eliminado,
                    Fecha = x.Fecha,
                    PacienteId = x.PacienteId
                }).ToList();
        }

        public IEnumerable<InformeAntropometricoDto> ObtenerPorRangoFecha(long desde, long hasta,long pacienteId)
        {
            var informeDesde = _informeAntropometrico.ObtenerPorId(desde);

            var informeHasta = _informeAntropometrico.ObtenerPorId(hasta);

            return _informeAntropometrico.ObtenerPorFiltro(x =>x.Eliminado != true && x.PacienteId == pacienteId
            && (x.PorcentajeGrasa.ToString() != string.Empty && x.PorcentajeMusculo.ToString() != string.Empty)
            && (x.Fecha >= informeDesde.Fecha && x.Fecha <= informeHasta.Fecha))
                .Select(x => new InformeAntropometricoDto
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    Observacion = x.Observacion,
                    PorcentajeGrasa = x.PorcentajeGrasa,
                    PorcentajeMusculo = x.PorcentajeMusculo,
                    KilosGrasa = x.KilosGrasa,
                    KilosMusculo = x.KilosMusculo,
                    Eliminado = x.Eliminado,
                    Fecha = x.Fecha,
                    PacienteId = x.PacienteId
                }).OrderBy(x=>x.Fecha).ToList();
        }

        public IEnumerable<InformeAntropometricoDto> ObtenerPorIdPacienteFecha(long id)
        {
            return _informeAntropometrico.ObtenerPorFiltro(x => x.PacienteId == id && x.Fecha < DateTime.Now && !x.Eliminado == true)
                .Select(x => new InformeAntropometricoDto()
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    Observacion = x.Observacion,
                    PorcentajeGrasa = x.PorcentajeGrasa,
                    PorcentajeMusculo = x.PorcentajeMusculo,
                    KilosGrasa = x.KilosGrasa,
                    KilosMusculo = x.KilosMusculo,
                    Eliminado = x.Eliminado,
                    Fecha = x.Fecha,
                    PacienteId = x.PacienteId
                }).OrderBy(x => x.Fecha).ToList();
        }
    }
}   
