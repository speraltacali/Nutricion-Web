using NA.Dominio.Repositorio.Paciente;
using NA.Infraestructura.Repositorio.Paciente;
using NA.IServicio.Paciente;
using NA.IServicio.Paciente.Dto;
using System;
using System.Collections.Generic;
using NA.Dominio.Entidades.Entidades;
using System.Linq;

namespace NA.Servicio.Paciente
{
    public class PacienteServicio : IPacienteServicio
    {
        private IPacienteRepositorio _pacienteRepositorio = new PacienteRepositorio();

        public PacienteDto Agregar(PacienteDto dto)
        {
            var paciente = new Dominio.Entidades.Entidades.Paciente
            {
                Apellido = dto.Apellido,
                Nombre = dto.Nombre,
                Dni = dto.Dni,
                Sexo = dto.Sexo,
                FechaNacimiento = dto.FechaNacimiento,
                Eliminado = dto.Eliminado
                
            };

            _pacienteRepositorio.Agregar(paciente);
            _pacienteRepositorio.Guardar();

            dto.Id = paciente.Id;
            return dto;
        }

        public void Eliminar(long id)
        {
            var paciente = _pacienteRepositorio.ObtenerPorId(id);

            if(paciente != null)
            {
                paciente.Eliminado = true;

                _pacienteRepositorio.Modificar(paciente);
                Guardar();
            }
        }

        public void Guardar()
        {
            _pacienteRepositorio.Guardar();
        }

        public PacienteDto Modificar(PacienteDto dto)
        {
            var paciente = _pacienteRepositorio.ObtenerPorId(dto.Id);

            // Seguir Programando el modificar 

            if (paciente != null)
            {
                paciente.Apellido = dto.Apellido;
                paciente.Nombre = dto.Nombre;
                paciente.Dni = dto.Dni;
                paciente.FechaNacimiento = dto.FechaNacimiento;
                paciente.Sexo = dto.Sexo;


                _pacienteRepositorio.Modificar(paciente);
                _pacienteRepositorio.Guardar();

                dto.Id = paciente.Id;
            }


            return dto;
        }

        public PacienteDto ObtenerPacientePorUserId(long id)
        {
            var paciente = _pacienteRepositorio.ObtenerTodo().FirstOrDefault(x => x.Id == id);

            if(paciente != null)
            {
                return new PacienteDto
                {
                    Id = paciente.Id,
                    Apellido = paciente.Apellido,
                    Nombre = paciente.Nombre,
                    Dni = paciente.Dni,
                    FechaNacimiento = paciente.FechaNacimiento,
                    Sexo = paciente.Sexo
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<PacienteDto> ObtenerPorFiltro(string cadena)
        {
            return _pacienteRepositorio.ObtenerPorFiltro(x => x.Eliminado != true && (x.Apellido.Contains(cadena) ||
                                            x.Nombre.Contains(cadena) || x.Dni.Contains(cadena)))
                                .Select(x => new PacienteDto
                                {
                                    Id = x.Id,
                                    Apellido = x.Apellido,
                                    Nombre = x.Nombre,
                                    Dni = x.Dni,
                                    FechaNacimiento = x.FechaNacimiento,
                                    Eliminado = x.Eliminado,
                                    Sexo = x.Sexo
                                });
        }

        public PacienteDto ObtenerPorId(long id)
        {
            var paciente = _pacienteRepositorio.ObtenerPorId(id);

            if (paciente != null)
            {
                return new PacienteDto
                {
                    Id = paciente.Id,
                    Apellido = paciente.Apellido,
                    Nombre = paciente.Nombre,
                    Dni = paciente.Dni,
                    FechaNacimiento = paciente.FechaNacimiento,
                    Sexo = paciente.Sexo
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<PacienteDto> ObtenerTodo()
        {
            return _pacienteRepositorio.ObtenerTodo()
                .Select(x => new PacienteDto
            {
                Id = x.Id,
                Apellido = x.Apellido,
                Nombre = x.Nombre,
                Dni = x.Dni,
                FechaNacimiento = x.FechaNacimiento,
                Sexo = x.Sexo
            }).ToList();
        }
    }
}
