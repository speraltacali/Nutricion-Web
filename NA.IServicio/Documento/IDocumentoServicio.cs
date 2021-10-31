using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.IServicio.Documento.Dto;

namespace NA.IServicio.Documento
{
    public interface IDocumentoServicio
    {
        DocumentoDto Agregar(DocumentoDto dto);

        DocumentoDto Modificar(DocumentoDto dto);

        void Eliminar(long id);

        IEnumerable<DocumentoDto> ObtenerTodo();


        DocumentoDto ObtenerPorId(long id);

        DocumentoDto ObtenerPorDieta(long id);

        IEnumerable<DocumentoDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
