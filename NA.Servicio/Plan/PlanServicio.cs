using NA.Dominio.Repositorio.Plan;
using NA.Infraestructura.Repositorio.Plan;
using NA.IServicio.Plan;
using NA.IServicio.Plan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.Plan
{
    public class PlanServicio : IPlanServicio
    {
        private readonly IPlanRepositorio _planRepositorio = new PlanRepositorio();

        public PlanDto Agregar(PlanDto dto)
        {
            var plan = new Dominio.Entidades.Entidades.Plan
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Eliminado = dto.Eliminado
            };

            _planRepositorio.Agregar(plan);
            Guardar();

            dto.Id = plan.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _planRepositorio.Guardar();
        }

        public PlanDto Modificar(PlanDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanDto> ObtenerPorFiltro(string cadena)
        {
            throw new NotImplementedException();
        }

        public PlanDto ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
