using NA.Dominio.Base.Helpers;
using NA.IServicio.Item;
using NA.IServicio.Item.Dto;
using NA.Servicio.Item;
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
    public partial class _0005_ABM_Item : _0002_ABM
    {
        private readonly IItemServicio _itemServicio = new ItemServicio();

        public _0005_ABM_Item()
        {
            InitializeComponent();
            Inicializador();
        }

        public _0005_ABM_Item(TipoOperacion operacion , long? entidadId = null)
            :base(operacion,entidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            this.txtItem.Focus();

            base.Inicializador();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var item = _itemServicio.ObtenerPorId(entidadId.Value);

                txtItem.Text = item.Nombre;

                if (TipoOperacion.Eliminar == Operacion)
                {
                    txtItem.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No se encuentro el item solicitado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void LimpiarControles()
        {
            if (!string.IsNullOrEmpty(txtItem.Text))
            {
                txtItem.Text = "";
            }

            base.LimpiarControles();
        }

        //************************* OPERACION EJECUTAR ************************

        public override void EjecutarAgregar()
        {
            try
            {
                var Item = new ItemDto
                {
                    Nombre = txtItem.Text.ToUpper(),
                    Eliminado = false
                };

                _itemServicio.Agregar(Item);

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
                var item = _itemServicio.ObtenerPorId(EntidadId.Value);

                if (item != null)
                {
                    item.Nombre = txtItem.Text;

                    _itemServicio.Modificar(item);

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
            var item = _itemServicio.ObtenerPorId(EntidadId.Value);

            if (item != null)
            {
                _itemServicio.Eliminar(item.Id);

            }
        }

    }
}
