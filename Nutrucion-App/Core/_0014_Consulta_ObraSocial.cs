using NA.Dominio.Base.Helpers;
using NA.IServicio.ObraSocial;
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
    public partial class _0014_Consulta_ObraSocial : _0009_Consulta_Base
    {
        private readonly IObraSocialServicio _obraSocialServicio = new ObraSocialServicio();

        public _0014_Consulta_ObraSocial()
            : base("Obra Social")
        {
            InitializeComponent();
        }

        public override void ActualizarDatos(string empty)
        {
            dgvGrilla.DataSource = _obraSocialServicio.ObtenerPorFiltro(empty);
            FormatiarGrilla(dgvGrilla);
        }

        //******************************** CARGA Y FORMATEO DE GRILLA ***************************

        public override void FormatiarGrilla(DataGridView dgv)
        {
            dgvGrilla.Columns["Id"].Visible = false;
            dgvGrilla.Columns["Eliminado"].Visible = false;

            dgvGrilla.Columns["Nombre"].Visible = true;
            dgvGrilla.Columns["Nombre"].HeaderText = @"Nombre Obra Social";
            dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public override void Buscar(string cadena)
        {
            dgvGrilla.DataSource = _obraSocialServicio.ObtenerPorFiltro(cadena);

            base.Buscar(cadena);
        }

        //******************************** OPERACIONES ****************************************

        public override bool EjecutarAgregarEntidad()
        {
            var fAgregar = new _0015_ABM_ObraSocial(TipoOperacion.Agregar);
            fAgregar.ShowDialog();
            ActualizarDatos(string.Empty);
            return fAgregar.RealizoOperacion;
        }

        public override bool EjecutarModificarEntidad(long? EntidadId)
        {
            var fModificar = new _0015_ABM_ObraSocial(TipoOperacion.Modificar, EntidadId);
            fModificar.ShowDialog();
            ActualizarDatos(string.Empty);
            return fModificar.RealizoOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? EntidadId)
        {
            var obraSocial = _obraSocialServicio.ObtenerPorId(EntidadId.Value);

            if(MessageBox.Show($"Esta seguro que quiere eliminar a {obraSocial.Nombre}","Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                var fEliminar = new _0015_ABM_ObraSocial(TipoOperacion.Eliminar, EntidadId);
                fEliminar.ShowDialog();
                ActualizarDatos(string.Empty);
                return fEliminar.RealizoOperacion;
            }
            else
            {
                return false;
            }
        }
    }
}
