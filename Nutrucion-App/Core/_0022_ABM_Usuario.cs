using NA.Dominio.Base.Helpers;
using NA.IServicio.Usuario;
using NA.Servicio.Base.Seguridad;
using NA.Servicio.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutrucion_App.Core
{
    public partial class _0022_ABM_Usuario : _0002_ABM
    {
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly Encriptar _encriptar = new Encriptar();

        public _0022_ABM_Usuario()
        {
            InitializeComponent();
        }

        public _0022_ABM_Usuario(TipoOperacion operacion , long? entidadId = null)
           :base(operacion,entidadId)
        {
            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            var user = _usuarioServicio.ObtenerPorIdPaciente(EntidadId.Value);

            txtUsuario.Text = user.User;
            txtPassword.Text = _encriptar.DesEncriptarPassword(user.Password);
        }

    }
}
