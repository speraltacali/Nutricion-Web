using NA.Dominio.Base.Helpers;
using NA.IServicio.Paciente;
using NA.IServicio.Usuario;
using NA.Servicio.Base.Seguridad;
using NA.Servicio.Paciente;
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
        private readonly IPacienteServicio _pacienteServicio = new PacienteServicio();
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
            CargarDatos(entidadId);
        }

        public override void CargarDatos(long? entidadId)
        {
            if(entidadId.HasValue)
            {
                var user = _usuarioServicio.ObtenerPorIdPaciente(entidadId.Value);

                txtUsuario.Text = user.User;
                txtPassword.Text = _encriptar.DesEncriptarPassword(user.Password);
            }
            else
            {
                MessageBox.Show("No se encuentro el usuario solicitado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimpiarControles()
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Text = string.Empty;
            }
        }

        public override void EjecutarModificar()
        {
            try
            {
                var paciente = _pacienteServicio.ObtenerPorId(EntidadId.Value);
                var usuario = _usuarioServicio.ObtenerPorIdPaciente(paciente.Id);

                if(usuario != null)
                {
                    usuario.User = txtUsuario.Text;
                    usuario.Password = txtPassword.Text;
                }

                RealizoOperacion = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
