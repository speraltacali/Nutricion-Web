using NA.IServicio.Plan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Plan
{
    public interface IPlanServicio
    {
        PlanDto Agregar(PlanDto dto);

        PlanDto Modificar(PlanDto dto);

        void Eliminar(long id);

        IEnumerable<PlanDto> ObtenerTodo();

        PlanDto ObtenerPorId(long id);

        IEnumerable<PlanDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
