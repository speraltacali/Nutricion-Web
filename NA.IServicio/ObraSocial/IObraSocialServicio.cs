using NA.IServicio.ObraSocial.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.ObraSocial
{
    public interface IObraSocialServicio
    {
        ObraSocialDto Agregar(ObraSocialDto dto);

        ObraSocialDto Modificar(ObraSocialDto dto);

        void Eliminar(long id);

        IEnumerable<ObraSocialDto> ObtenerTodo();

        ObraSocialDto ObtenerPorId(long id);


        IEnumerable<ObraSocialDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
