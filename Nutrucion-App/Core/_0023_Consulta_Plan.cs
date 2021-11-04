using NA.Dominio.Base.Helpers;
using NA.IServicio.Plan;
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
    public partial class _0023_Consulta_Plan : _0009_Consulta_Base
    {
        private readonly IPlanServicio _planServicio = new PlanServicio();

        public _0023_Consulta_Plan()
            :base("Planes")
        {
            InitializeComponent();

            ActualizarDatos(string.Empty);
        }

        public override void ActualizarDatos(string empty)
        {
            dgvGrilla.DataSource = _planServicio.ObtenerPorFiltro(empty);

            FormatiarGrilla(dgvGrilla);
        }

        public override void FormatiarGrilla(DataGridView dgv)
        {
            dgvGrilla.Columns["Id"].Visible = false;
            dgvGrilla.Columns["Eliminado"].Visible = false;
            dgvGrilla.Columns["Descripcion"].Visible = false;

            dgvGrilla.Columns["Titulo"].Visible = true;
            dgvGrilla.Columns["Titulo"].HeaderText = @"Titulo del Plan";
            dgvGrilla.Columns["Titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public override void Buscar(string cadena)
        {                    
            dgvGrilla.DataSource = _planServicio.ObtenerPorFiltro(cadena);

            base.Buscar(cadena);
        }


        public override void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fNivel = new _0025_Consulta_Nivel();
            fNivel.planId = entidadId.Value;
            fNivel.ShowDialog();
        }

        //**************************************  OPERACIONES ***********************************

        public override bool EjecutarAgregarEntidad()
        {
            var fPlan = new _0024_ABM_Plan(TipoOperacion.Agregar);
            fPlan.ShowDialog();
            return fPlan.RealizoOperacion;
        }

        public override bool EjecutarModificarEntidad(long? EntidadId)
        {
            var fPlan = new _0024_ABM_Plan(TipoOperacion.Modificar , EntidadId);
            fPlan.ShowDialog();
            return fPlan.RealizoOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? EntidadId)
        {
            var plan = _planServicio.ObtenerPorId(EntidadId.Value);

            if (MessageBox.Show("Desea Eliminar el item : " + plan, "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                var fEliminar = new _0024_ABM_Plan(TipoOperacion.Eliminar, EntidadId.Value);
                fEliminar.ShowDialog();
                FormatiarGrilla(dgvGrilla);

                return fEliminar.RealizoOperacion;
            }
            else
            {
                return false;
            }
        }

    }
}
