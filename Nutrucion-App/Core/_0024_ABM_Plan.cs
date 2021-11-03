using NA.Dominio.Base.Helpers;
using NA.IServicio.Plan;
using NA.IServicio.Plan.Dto;
using NA.Servicio.Plan;
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
    public partial class _0024_ABM_Plan : _0002_ABM
    {
        private readonly IPlanServicio _planServicio = new PlanServicio();

        public _0024_ABM_Plan()
        {
            InitializeComponent();
        }

        public _0024_ABM_Plan(TipoOperacion operacion , long? entidadId = null)
            : base(operacion,entidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            AgregarControlesObligatorios(txtTitulo, "Titulo del Plan");

            AgregarControlesObligatorios(txtDescripcion, "Descripcion del Plan");

            txtTitulo.Focus();

            base.Inicializador();
        }

        public override void CargarDatos(long? entidadId)
        {
            if(entidadId.HasValue)
            {

                var plan = _planServicio.ObtenerPorId(entidadId.Value);

                txtTitulo.Text = plan.Titulo;
                txtDescripcion.Text= plan.Descripcion;

                if(TipoOperacion.Eliminar == Operacion)
                {
                    txtTitulo.Enabled = false;
                    txtDescripcion.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No se encuentro el Plan solicitado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            base.CargarDatos(entidadId);
        }

        //*********************************************** OPERACIONES ********************************************

        public override void EjecutarAgregar()
        {
            try
            {
                var plan = new PlanDto
                {
                    Titulo = txtTitulo.Text,
                    Descripcion = txtDescripcion.Text,
                    Eliminado = false
                };

                _planServicio.Agregar(plan);
                RealizoOperacion = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Algunos de los valores ingresados es invalido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        public override void EjecutarModificar()
        {
            try
            {
                var plan = _planServicio.ObtenerPorId(EntidadId.Value);

                plan.Titulo = txtTitulo.Text;
                plan.Descripcion = txtDescripcion.Text;

                _planServicio.Modificar(plan);

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
            base.EjecutarEliminar();
        }
    }
}
