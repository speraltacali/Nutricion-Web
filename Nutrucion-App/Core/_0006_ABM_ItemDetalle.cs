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
using NA.IServicio.Item;
using NA.IServicio.ItemDetalle;
using NA.IServicio.ItemDetalle.Dto;
using NA.IServicio.Paciente;
using NA.Servicio.Item;
using NA.Servicio.ItemDetalle;
using NA.Servicio.Paciente;

namespace Nutrucion_App.Core
{
    public partial class _0006_ABM_ItemDetalle : _0002_ABM
    {
        private readonly IItemDetalleServicio _detalleServicio = new ItemDetalleServicio();
        private readonly IItemServicio _itemServicio = new ItemServicio();


        public _0006_ABM_ItemDetalle()
        {
            InitializeComponent();
        }

        public _0006_ABM_ItemDetalle(TipoOperacion operacion , long? entidadId = null)
        :base(operacion,entidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            CargarCombo();

            AgregarControlesObligatorios(txtDescripcion,"Descripcion");

            base.Inicializador();
        }

        public override void LimpiarControles()
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                txtDescripcion.Text = "";
            }
        }

        //*************************** CARGAR DATOS *******************************

        public override void CargarDatos(long? entidadId)
        {
            if(entidadId.HasValue)
            {
                var detalle = _detalleServicio.ObtenerPorId(entidadId.Value);

                cmdItem.SelectedValue = detalle.ItemId;
                txtDescripcion.Text = detalle.Descripcion;
            }
        }

        public void CargarCombo()
        {
            cmdItem.DataSource = _itemServicio.ObtenerPorFiltro(string.Empty);
            cmdItem.DisplayMember = "Nombre";
            cmdItem.ValueMember = "Id";
        }

        public void AgregarCombo()
        {
            var fAgregar = new _0005_ABM_Item(TipoOperacion.Agregar);
            fAgregar.ShowDialog();
            CargarCombo();
        }

        //*************************** OPERACIONES *******************************

        public override void EjecutarAgregar()
        {
            var detalle = new ItemDetalleDto
            {
                Descripcion = txtDescripcion.Text,
                ItemId = (long)cmdItem.SelectedValue,
                ItemNombre = cmdItem.Text,
                PacienteId = EntidadId.Value
            };

            _detalleServicio.Agregar(detalle);

            RealizoOperacion = true;
        }

        public override void EjecutarModificar()
        {
            try
            {
                var detalle = _detalleServicio.ObtenerPorId(EntidadId.Value);

                detalle.ItemId = (long)cmdItem.SelectedValue;
                detalle.Descripcion = txtDescripcion.Text;

                _detalleServicio.Modificar(detalle);

                RealizoOperacion = true;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCombo();
        }
    }
}
