using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NA.Dominio.Base.Helpers;
using NA.IServicio.Circunferencia;
using NA.IServicio.Circunferencia.Dto;
using NA.Servicio.Circunferencia;

namespace Nutrucion_App.Core
{
    public partial class _0011_ABM_Circunferencia : _0002_ABM
    {
        private readonly ICircunferenciaServicio _circunferenciaServicio = new CircunferenciaServicio();


        public _0011_ABM_Circunferencia(TipoOperacion operacion , long? entidadId = null)
        :base(operacion,entidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            AgregarControlesObligatorios(txtNombre,"Nombre de la Circunferencia");

            this.txtNombre.Focus();

            base.Inicializador();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var circunferencia = _circunferenciaServicio.ObtenerPorId(entidadId.Value);

                txtNombre.Text = circunferencia.Nombre;

                if(TipoOperacion.Eliminar == Operacion)
                {
                    txtNombre.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No se encuentro la circunferencia solicitado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //**************************** LIMPIAR ************************************


        public override void LimpiarControles()
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Text = "";
            }
        }

        //**************************** OPERACION ************************************

        public override void EjecutarAgregar()
        {
            try
            {
                var Circunferencia = new CircunferenciaDto
                {
                    Nombre = txtNombre.Text,
                    Eliminado = false
                };

                _circunferenciaServicio.Agregar(Circunferencia);

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
                var circunferencia = _circunferenciaServicio.ObtenerPorId(EntidadId.Value);

                if (circunferencia != null)
                {
                    circunferencia.Nombre = txtNombre.Text;

                    _circunferenciaServicio.Modificar(circunferencia);
                }

                RealizoOperacion = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override void EjecutarEliminar()
        {
            var circunferencia = _circunferenciaServicio.ObtenerPorId(EntidadId.Value);

            if (circunferencia != null)
            {
                _circunferenciaServicio.Eliminar(circunferencia.Id);
            }
        }
    }
}
