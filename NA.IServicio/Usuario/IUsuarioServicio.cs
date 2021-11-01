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


        IEnumerable<UsuarioDto> ObtenerPorFiltro(string cadena);

        void Guardar();
    }
}
