using NA.IServicio.InformeCircunferencia;
using NA.IServicio.InformeCircunferencia.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Repositorio.InformeCircunferencia;
using NA.Infraestructura.Repositorio.InformeCircunferencia;
using NA.IServicio.InformeAntropometrico.Dto;

namespace NA.Servicio.InformeCircunferencia
{
    public class InformeCircunferenciaServicio : IInformeCircunferenciaServicio
    {
        private readonly IInformeCircunferenciaRepositorio _informeCircunferencia = new InformeCircunferenciaRepositorio();

        public InformeCiercunferenciaDto Agregar(InformeCiercunferenciaDto dto)
        {
            var informe = new Dominio.Entidades.Entidades.InformeCircunferencia()
            {
                AntropometricoId = dto.AntropometricoId,
                CircunferenciaId = dto.CircunferenciaId,
                Valor = dto.Valor
            };

            _informeCircunferencia.Agregar(informe);
            _informeCircunferencia.Guardar();

            dto.Id = informe.Id;

            return dto;
        }

        public void Eliminar(long id)
        {
            var informe = _informeCircunferencia.ObtenerPorId(id);

            if (informe != null)
            {
                _informeCircunferencia.Eliminar(id);
                _informeCircunferencia.Guardar();
            }
        }

        public void Guardar()
        {
            _informeCircunferencia.Guardar();
        }

        public InformeCiercunferenciaDto Modificar(InformeCiercunferenciaDto dto)
        {
            var informe = _informeCircunferencia.ObtenerPorId(dto.Id);

            if (informe != null)
            {
                informe.CircunferenciaId = dto.CircunferenciaId;
                informe.AntropometricoId = dto.AntropometricoId;
                informe.Valor = dto.Valor;

                _informeCircunferencia.Modificar(informe);
                _informeCircunferencia.Guardar();
            }

            return dto;
        }

        public IEnumerable<InformeCiercunferenciaDto> ObtenerPorAntropometrico(long id)
        {
            return _informeCircunferencia.ObtenerPorFiltro(x => x.AntropometricoId == id)
                .Select(x => new InformeCiercunferenciaDto()
                {
                    Id = x.Id,
                    AntropometricoId = x.AntropometricoId,
                    CircunferenciaId = x.CircunferenciaId,
                    Valor = x.Valor
                }).ToList();
        }

        public IEnumerable<InformeCiercunferenciaDto> ObtenerPorFiltro(string cadena)
        {
            return _informeCircunferencia.ObtenerPorFiltro(x=>x.Circunferencia.Nombre.Contains(cadena))
                .Select(x => new InformeCiercunferenciaDto()
                {
                    Id = x.Id,
                    AntropometricoId = x.AntropometricoId,
                    CircunferenciaId = x.CircunferenciaId,
                    Valor = x.Valor
                }).ToList();
        }

        public InformeCiercunferenciaDto ObtenerPorId(long id)
        {
            var informe = _informeCircunferencia.ObtenerPorId(id);

            if (informe != null)
            {
                return new InformeCiercunferenciaDto()
                {
                    Id = informe.Id,
                    AntropometricoId = informe.AntropometricoId,
                    CircunferenciaId = informe.CircunferenciaId,
                    Valor = informe.Valor
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<InformeCiercunferenciaDto> ObtenerTodo()
        {
            return _informeCircunferencia.ObtenerTodo()
                .Select(x => new InformeCiercunferenciaDto()
                {
                    Id = x.Id,
                    AntropometricoId = x.AntropometricoId,
                    CircunferenciaId = x.CircunferenciaId,
                    Valor = x.Valor
                }).ToList();
        }
    }
}
