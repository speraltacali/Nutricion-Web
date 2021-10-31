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
    public partial class _0010_Consulta_Circunferencia : _0009_Consulta_Base
    {
        private readonly ICircunferenciaServicio _circunferenciaServicio = new CircunferenciaServicio();

        public _0010_Consulta_Circunferencia()
        :base("Circunferencia")
        {
            InitializeComponent();
            ActualizarDatos(string.Empty);
        }

        public override void ActualizarDatos(string empty)
        {
            this.dgvGrilla.DataSource = _circunferenciaServicio.ObtenerPorFiltro(empty);
            FormatiarGrilla(dgvGrilla);
        }

        public override void FormatiarGrilla(DataGridView dgv)
        {
            dgvGrilla.Columns["Id"].Visible = false;
            dgvGrilla.Columns["Eliminado"].Visible = false;

            dgvGrilla.Columns["Nombre"].HeaderText = @"Nombre";
            dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        
        //************************* OPERACION EJECUTAR ************************

        public override void EjecutarEventoLoad()
        {
            ActualizarDatos(string.Empty);
        }

        public override bool EjecutarAgregarEntidad()
        {
            var fEjecutar = new _0011_ABM_Circunferencia(TipoOperacion.Agregar);
            fEjecutar.ShowDialog();
            return fEjecutar.RealizoOperacion;
        }
            
        public override bool EjecutarModificarEntidad(long? EntidadId)
        {
            var fModificar = new _0011_ABM_Circunferencia(TipoOperacion.Modificar , EntidadId);
            fModificar.ShowDialog();
            return fModificar.RealizoOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? EntidadId)
        {
            var circunferencia = _circunferenciaServicio.ObtenerPorId(EntidadId.Value);

            if (MessageBox.Show("Desea Eliminar la circunferencia : " + circunferencia.Nombre, "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
            {
                var fEliminar = new _0011_ABM_Circunferencia(TipoOperacion.Eliminar, EntidadId.Value);
                fEliminar.ShowDialog();
                FormatiarGrilla(dgvGrilla);

                return fEliminar.RealizoOperacion;
            }
            else
            {
                return false;
            }
        }

        public override void Buscar(string cadena)
        {
            dgvGrilla.DataSource = _circunferenciaServicio.ObtenerPorFiltro(cadena);

            base.Buscar(cadena);
        }
    }
}
