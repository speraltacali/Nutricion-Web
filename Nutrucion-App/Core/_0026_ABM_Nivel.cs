using NA.Dominio.Base.Helpers;
using NA.Dominio.Base.Imagen;
using NA.IServicio.Nivel;
using NA.IServicio.Nivel.Dto;
using NA.IServicio.Plan;
using NA.Servicio.Nivel;
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
    public partial class _0026_ABM_Nivel : _0002_ABM
    {
        private readonly INivelServicio _nivelServicio = new NivelServicio();
        private readonly IPlanServicio _planServicio = new PlanServicio();

        public _0026_ABM_Nivel()
        {
            InitializeComponent();
        }

        public _0026_ABM_Nivel(TipoOperacion operacion , long? EntidadId = null)
            :base(operacion,EntidadId)
        {
            InitializeComponent();
            Inicializador();
            CargarDatos(EntidadId);
        }

        public override void Inicializador()
        {
            CargarCombo();

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(txtLinkPago, "Link de Pago");
            AgregarControlesObligatorios(txtTitulo, "Titulo");

        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var nivel = _nivelServicio.ObtenerPorId(entidadId.Value);

                cmdPlan.SelectedValue = nivel.PlanId;
                
                txtTitulo.Text = nivel.Titulo;
                txtDescripcion.Text = nivel.Descripcion;
                txtLinkPago.Text = nivel.LinkPago;
                pictureImagen.Image = Imagen.Convertir_Bytes_Imagen(nivel.Imagen);
                nupPrecio.Value = nivel.Precio;
            }
        }

        public override void LimpiarControles()
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                txtDescripcion.Text = "";
            }

            if (!string.IsNullOrEmpty(txtLinkPago.Text))
            {
                txtLinkPago.Text = "";
            }

            if (!string.IsNullOrEmpty(txtTitulo.Text))
            {
                txtTitulo.Text = "";
            }
        }

        public void CargarCombo()
        {
            cmdPlan.DataSource = _planServicio.ObtenerPorFiltro(string.Empty);
            cmdPlan.DisplayMember = "Titulo";
            cmdPlan.ValueMember = "Id";
        }


        public void AgregarPlanCombo()
        {
            var fPlan = new _0024_ABM_Plan(TipoOperacion.Agregar);
            fPlan.ShowDialog();
            CargarCombo();
        }

        //******************************** OPERACIONES ****************************************


        public override void EjecutarAgregar()
        {
            if(cmdPlan.Text != string.Empty)
            {
                var nivel = new NivelDto
                {
                    Titulo = txtTitulo.Text,
                    Descripcion = txtDescripcion.Text,
                    LinkPago = txtLinkPago.Text,
                    Imagen = Imagen.Convertir_Imagen_Bytes(pictureImagen.Image),
                    Precio = nupPrecio.Value,
                    PlanId = (long)cmdPlan.SelectedValue
                };

                _nivelServicio.Agregar(nivel);

                RealizoOperacion = true;
            }
            else
            {
                AgregarPlanCombo();
            }
        }

        public override void EjecutarModificar()
        {
            var plan = _nivelServicio.ObtenerPorId(EntidadId.Value);

            if(plan != null)
            {
                try
                {
                    plan.Titulo = txtTitulo.Text;
                    plan.Descripcion = txtDescripcion.Text;
                    plan.LinkPago = txtLinkPago.Text;
                    plan.Imagen = Imagen.Convertir_Imagen_Bytes(pictureImagen.Image);
                    plan.Precio = nupPrecio.Value;
                    plan.PlanId = (long)cmdPlan.SelectedValue;

                    _nivelServicio.Modificar(plan);

                    RealizoOperacion = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public override void EjecutarEliminar()
        {
            var nivel = _nivelServicio.ObtenerPorId(EntidadId.Value);

            if(nivel != null)
            {
                _nivelServicio.Eliminar(nivel.Id);
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureImagen.Image = !string.IsNullOrEmpty(open.FileName)
                    ? Image.FromFile(open.FileName)
                    : Properties.Resources.ImagenFondo;
            }
            else
            {
                pictureImagen.Image = Properties.Resources.ImagenFondo;
            }
        }
    }
}
