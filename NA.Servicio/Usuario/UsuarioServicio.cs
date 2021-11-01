using NA.Dominio.Repositorio.Usuario;
using NA.Infraestructura.Repositorio.Usuario;
using NA.IServicio.Usuario;
using NA.IServicio.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Servicio.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();

        public UsuarioDto Agregar(UsuarioDto dto)
        {
            var usuario = new Dominio.Entidades.Entidades.Usuario
            {
                User = dto.User,
                Password = dto.Password,
                Bloqueado = dto.Bloqueado,
                Eliminado = dto.Eliminado,
                Token = dto.Token,
                PacienteId = dto.PacienteId
            };

            _usuarioRepositorio.Agregar(usuario);
            Guardar();

            dto.Id = usuario.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            _usuarioRepositorio.Guardar();
        }

        public UsuarioDto Modificar(UsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioDto> ObtenerPorFiltro(string cadena)
        {
            throw new NotImplementedException();
        }

        public UsuarioDto ObtenerPorId(long id)
        {
            var dto = _usuarioRepositorio.ObtenerPorId(id);

            if (dto == null) throw new Exception("El Usuario solicitado no se encuentra.");

            return new UsuarioDto
            {
                Id = dto.Id,
                User = dto.User,
                Password = dto.Password,
                Bloqueado = dto.Bloqueado,
                Eliminado = dto.Eliminado,
                Token = dto.Token,
                PacienteId = dto.PacienteId
            };
        }

        public UsuarioDto ObtenerPorIdPaciente(long id)
        {
            var dto = _usuarioRepositorio.ObtenerTodo().FirstOrDefault(x=>x.PacienteId == id);

            if (dto != null)
            {
                return new UsuarioDto
                {
                    Id = dto.Id,
                    User = dto.User,
                    Password = dto.Password,
                    Bloqueado = dto.Bloqueado,
                    Eliminado = dto.Eliminado,
                    Token = dto.Token,
                    PacienteId = dto.PacienteId
                };
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<UsuarioDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
