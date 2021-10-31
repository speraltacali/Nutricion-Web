using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Dominio.Repositorio.Documento;
using NA.Infraestructura.Repositorio.Documento;
using NA.IServicio.Documento;
using NA.IServicio.Documento.Dto;

namespace NA.Servicio.Documento
{
    public class DocumentoServicio : IDocumentoServicio
    {
        private readonly IDocumentoRepositorio _documentoRepositorio = new DocumentoRepositorio();

        public DocumentoDto Agregar(DocumentoDto dto)
        {
            var documento = new Dominio.Entidades.Entidades.Documento
            {
                Nombre = dto.Nombre,
                NombreReal = dto.NombreReal,
                Doc = dto.Doc,
                DietaId = dto.DietaId
            };

            _documentoRepositorio.Agregar(documento);
            _documentoRepositorio.Guardar();

            dto.Id = documento.Id;

            return dto;
        }

        public DocumentoDto Modificar(DocumentoDto dto)
        {
            var documento = _documentoRepositorio.ObtenerPorId(dto.Id);

            if (documento != null)
            {
                documento.Nombre = dto.Nombre;
                documento.NombreReal = dto.NombreReal;
                documento.Doc = dto.Doc;
                documento.DietaId = dto.DietaId;

                _documentoRepositorio.Modificar(documento);
                _documentoRepositorio.Guardar();

                return dto;
            }
            else
            {
                return null;
            }
        }

        public void Eliminar(long id)
        {
            var documento = _documentoRepositorio.ObtenerPorId(id);

            if (documento != null)
            {
                _documentoRepositorio.Eliminar(documento.Id);
                _documentoRepositorio.Guardar();
            }
        }

        public IEnumerable<DocumentoDto> ObtenerTodo()
        {
            return _documentoRepositorio.ObtenerTodo()
                .Select(x => new DocumentoDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Doc = x.Doc,
                    NombreReal = x.NombreReal,
                    DietaId = x.DietaId
                }).ToList();
        }

        public DocumentoDto ObtenerPorId(long id)
        {
            var documento = _documentoRepositorio.ObtenerPorId(id);

            if (documento != null)
            {
                return new DocumentoDto()
                {
                    Id = documento.Id,
                    Nombre = documento.Nombre,
                    Doc = documento.Doc,
                    NombreReal = documento.NombreReal,
                    DietaId = documento.DietaId
                };
            }
            else
            {
                return null;
            }
        }

        public DocumentoDto ObtenerPorDieta(long id)
        {
            var documento = _documentoRepositorio.ObtenerTodo()
                .FirstOrDefault(x => x.DietaId == id);

            if (documento != null)
            {
                return new DocumentoDto()
                {
                    Id = documento.Id,
                    Nombre = documento.Nombre,
                    Doc = documento.Doc,
                    NombreReal = documento.NombreReal,
                    DietaId = documento.DietaId
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<DocumentoDto> ObtenerPorFiltro(string cadena)
        {
            return _documentoRepositorio.ObtenerPorFiltro(x=>x.Nombre.Contains(cadena))
                .Select(x => new DocumentoDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Doc = x.Doc,
                    NombreReal = x.NombreReal,
                    DietaId = x.DietaId
                }).ToList();
        }

        public void Guardar()
        {
            _documentoRepositorio.Guardar();
        }
    }
}
