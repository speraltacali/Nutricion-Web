using NA.Dominio.Base.Helpers;
using NA.IServicio.ObraSocial;
using NA.IServicio.ObraSocial.Dto;
using NA.Servicio.ObraSocial;
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
    public partial class _0015_ABM_ObraSocial : _0002_ABM
    {
        private readonly IObraSocialServicio _obraSocialServicio = new ObraSocialServicio();

        public _0015_ABM_ObraSocial()
        {
            InitializeComponent();
        }

        public _0015_ABM_ObraSocial(TipoOperacion Operacion, long? EntidadId = null)
            : base(Operacion, EntidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            AgregarControlesObligatorios(txtObraSocial, "Nombre Obra Social");

            txtObraSocial.Focus();

            base.Inicializador();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var obraSocial = _obraSocialServicio.ObtenerPorId(entidadId.Value);

                txtObraSocial.Text = obraSocial.Nombre;

                if(TipoOperacion.Eliminar == Operacion)
                {
                    txtObraSocial.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No se encuentro la obra social solicitado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //**************************** OPERACIONES *************************

        public override void EjecutarAgregar()
        {
            try
            {
                var obraSocial = new ObraSocialDto
                {
                    Nombre = txtObraSocial.Text
                };

                _obraSocialServicio.Agregar(obraSocial);
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
                var obraSocial = _obraSocialServicio.ObtenerPorId(EntidadId.Value);

                if (obraSocial != null)
                {
                    obraSocial.Nombre = txtObraSocial.Text;

                    _obraSocialServicio.Modificar(obraSocial);
                    RealizoOperacion = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Algunos de los valores ingresados es invalido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void EjecutarEliminar()
        {
            var obraSocial = _obraSocialServicio.ObtenerPorId(EntidadId.Value);

            if (obraSocial != null)
            {
                _obraSocialServicio.Eliminar(obraSocial.Id);
                RealizoOperacion = true;
            }
        }
    }
}
