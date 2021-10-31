using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Repositorio.Dieta;
using NA.Infraestructura.Repositorio.Dieta;
using NA.IServicio.Dieta;
using NA.IServicio.Dieta.Dto;

namespace NA.Servicio.Dieta
{
    public class DietaServicio : IDietaServicio
    {
        private readonly IDietaRepositorio _dietaRepositorio = new DietaRepositorio();

        public DietaDto Agregar(DietaDto dto)
        {
            var dieta = new Dominio.Entidades.Entidades.Dieta
            {
                IAntropometricoId = dto.IAntropometricoId,
                TipoPlan = dto.TipoPlan,
                Calorias = dto.Calorias,
                CantidadComidas = dto.CantidadComidas,
                Eliminado = dto.Eliminado
            };

            _dietaRepositorio.Agregar(dieta);
            _dietaRepositorio.Guardar();

            dto.Id = dieta.Id;

            return dto;
        }

        public DietaDto Modificar(DietaDto dto)
        {
            var dieta = _dietaRepositorio.ObtenerPorId(dto.Id);

            if (dieta != null)
            {
                dieta.TipoPlan = dto.TipoPlan;
                dieta.Calorias = dto.Calorias;
                dieta.CantidadComidas = dto.CantidadComidas;

                _dietaRepositorio.Modificar(dieta);
                _dietaRepositorio.Guardar();

            }

            return dto;
        }

        public void Eliminar(long id)
        {
            //*************** ELIMINADO LOGICO *******************

            var dieta = _dietaRepositorio.ObtenerPorId(id);

            if (dieta != null)
            {
                dieta.Eliminado = true;

                _dietaRepositorio.Modificar(dieta);
                _dietaRepositorio.Guardar();
            }
        }

        public IEnumerable<DietaDto> ObtenerTodo()
        {
            return _dietaRepositorio.ObtenerTodo()
                .Select(x => new DietaDto()
                {
                    Id = x.Id,
                    TipoPlan = x.TipoPlan,
                    Calorias = x.Calorias,
                    CantidadComidas = x.CantidadComidas,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public DietaDto ObtenerPorInforme(long id)
        {
            var dieta = _dietaRepositorio.ObtenerTodo()
                .FirstOrDefault(x => x.IAntropometricoId == id);

            if (dieta != null)
            {
                return new DietaDto()
                {
                    Id = dieta.Id,
                    TipoPlan = dieta.TipoPlan,
                    Calorias = dieta.Calorias,
                    CantidadComidas = dieta.CantidadComidas,
                    Eliminado = dieta.Eliminado
                };
            }
            else
            {
                return null;
            }
        }

        public DietaDto ObtenerPorId(long id)
        {
            var dieta = _dietaRepositorio.ObtenerPorId(id);

            if (dieta != null)
            {
                return new DietaDto()
                {
                    Id = dieta.Id,
                    TipoPlan = dieta.TipoPlan,
                    Calorias = dieta.Calorias,
                    CantidadComidas = dieta.CantidadComidas,
                    Eliminado = dieta.Eliminado
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<DietaDto> ObtenerPorFiltro(string cadena)
        {
            return _dietaRepositorio.ObtenerPorFiltro(x=>x.TipoPlan.ToString().Contains(cadena))
                .Select(x => new DietaDto()
                {
                    Id = x.Id,
                    TipoPlan = x.TipoPlan,
                    Calorias = x.Calorias,
                    CantidadComidas = x.CantidadComidas,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public void Guardar()
        {
            _dietaRepositorio.Guardar();
        }
    }
}
