using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Repositorio.Documento;
using NA.Repositorio;

namespace NA.Infraestructura.Repositorio.Documento
{
    public class DocumentoRepositorio : Repositorio<Dominio.Entidades.Entidades.Documento> , IDocumentoRepositorio
    {
    }
}
