﻿using NA.IServicio.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.IServicio.Usuario
{
    public interface IUsuarioServicio
    {
        UsuarioDto Agregar(UsuarioDto dto);

        UsuarioDto Modificar(UsuarioDto dto);

        void Eliminar(long id);

        IEnumerable<UsuarioDto> ObtenerTodo();

        UsuarioDto ObtenerPorId(long id);
            
        UsuarioDto ObtenerPorIdPaciente (long id);

        IEnumerable<UsuarioDto> ObtenerPorFiltro(string cadena);

        string GenerarNombreUsuario(string nombre, string apellido);

        UsuarioDto PuedeIngresar(UsuarioDto dto);

        bool ValidarSiExiste(string user);

        UsuarioDto ObtenerPorNombre(string user);

        UsuarioDto CambiarPassword(UsuarioDto dto);

        UsuarioDto GuardarToken(UsuarioDto dto);

        bool ValidarToken(string token);

        bool ValidarHabilitado(string user);

        bool BloquearUsuario(long id);

        bool DesBloquearUsuario(long id);

        bool TieneClaveGenerica(long id);

        void Guardar();
    }
}
