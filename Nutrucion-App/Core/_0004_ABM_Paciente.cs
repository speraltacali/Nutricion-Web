using NA.Dominio.Base.Helpers;
using NA.IServicio.Paciente;
using NA.IServicio.Paciente.Dto;
using NA.Servicio.Paciente;
using System;
using System.Windows.Forms;
using NA.IServicio.ItemDetalle;
using NA.Servicio.ItemDetalle;
using NA.IServicio.Item;
using NA.Servicio.Item;

namespace Nutrucion_App.Core
{
    public partial class _0004_ABM_Paciente : _0002_ABM
    {
        private readonly IPacienteServicio _pacienteServicio = new PacienteServicio();
        private readonly IItemDetalleServicio _detalleServicio = new ItemDetalleServicio();
        private readonly IItemServicio _itemServicio = new ItemServicio();


        public _0004_ABM_Paciente()
        {
            InitializeComponent();
            Inicializador();
        }

        public _0004_ABM_Paciente(TipoOperacion operacion , long? entidadId = null)
            :base(operacion,entidadId)
        {
            InitializeComponent();
            Inicializador();
        }


        public override void Inicializador()
        {
            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");

            cmdSexo.DataSource = Enum.GetValues(typeof(PacienteSexo));

            this.txtApellido.Focus();

            base.Inicializador();
        }

        //**************************** CARGAR DATOS ************************************

        public override void CargarDatos(long? entidadId)
        {
            if(entidadId.HasValue)
            {
                var entidad = _pacienteServicio.ObtenerPorId(entidadId.Value);

                this.txtApellido.Text = entidad.Apellido;
                this.txtDni.Text = entidad.Dni;
                this.txtNombre.Text = entidad.Nombre;
                this.dtpNacimiento.Value = entidad.FechaNacimiento;
                this.cmdSexo.SelectedItem = entidad.Sexo;

                if(TipoOperacion.Eliminar == Operacion)
                {
                    this.txtApellido.Enabled = false;
                    this.txtDni.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.dtpNacimiento.Enabled = false;
                    this.cmdSexo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No se encuentro el paciente solicitado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**************************** LIMPIAR ************************************

        public override void LimpiarControles()
        {
            if(!string.IsNullOrEmpty(txtApellido.Text))
            {
                txtApellido.Text = "";
            }

            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Text = "";
            }

            if (!string.IsNullOrEmpty(txtDni.Text))
            {
                txtDni.Text = "";
            }

            dtpNacimiento.Value = DateTime.Now;

        }



        //**************************** OPERACION ************************************

        public override void EjecutarAgregar()
        {
            try
            {
                var Paciente = new PacienteDto
                {
                    Apellido = txtApellido.Text,
                    Nombre = txtNombre.Text,
                    Dni = txtDni.Text,
                    FechaNacimiento = dtpNacimiento.Value,
                    Sexo = (PacienteSexo)cmdSexo.SelectedValue,
                    Eliminado = false
                };

                var pacienteId = _pacienteServicio.Agregar(Paciente);
                EntidadId = pacienteId.Id;

                RealizoOperacion = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public override void EjecutarModificar()
        {
            try
            {
                var Paciente = new PacienteDto
                {
                    Id = EntidadId.Value,
                    Apellido = txtApellido.Text,
                    Nombre = txtNombre.Text,
                    Dni = txtDni.Text,
                    FechaNacimiento = dtpNacimiento.Value,
                    Sexo = (PacienteSexo)cmdSexo.SelectedValue,
                };

                RealizoOperacion = true;

                var pacienteId = _pacienteServicio.Modificar(Paciente);
            }
            catch (Exception)
            {
                MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public override void EjecutarEliminar()
        {
            _pacienteServicio.Eliminar(EntidadId.Value);
        }

        //**************************** CONTOLES ITEMS  ************************************


        private void _0004_ABM_Paciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            LimpiarControles();
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
