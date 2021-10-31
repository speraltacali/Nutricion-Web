using NA.Dominio.Base.Helpers;
using NA.IServicio.ObraSocial;
using NA.IServicio.ObraSocialPaciente;
using NA.IServicio.Paciente;
using NA.IServicio.Paciente.Dto;
using NA.Servicio.ObraSocial;
using NA.Servicio.ObraSocialPaciente;
using NA.Servicio.Paciente;
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
    public partial class _0017_Afiliado_ObraSocial : _0009_Consulta_Base
    {
        private readonly IObraSocialServicio _obraSocialServicio = new ObraSocialServicio();
        private readonly IObraSocialPacienteServicio _obraSocialPacienteServicio = new ObraSocialPacienteServicio();
        private readonly IPacienteServicio _pacienteServicio = new PacienteServicio();

        List<PacienteDto> ListaPaciente = new List<PacienteDto>();

        public _0017_Afiliado_ObraSocial()
            : base("Afiliados")
        {
            InitializeComponent();
        }

        public override void ActualizarDatos(string empty)
        {
            this.cmbObraSocial.DataSource = _obraSocialServicio.ObtenerPorFiltro(empty);
            this.cmbObraSocial.DisplayMember = "Nombre";
            this.cmbObraSocial.ValueMember = "Id";

            CargarAfiliados();

            base.ActualizarDatos(empty);
        }

        public override void FormatiarGrilla(DataGridView dgv)
        {
            dgvGrilla.Columns["Id"].Visible = false;
            dgvGrilla.Columns["Apellido"].Visible = false;
            dgvGrilla.Columns["Nombre"].Visible = false;
            dgvGrilla.Columns["Sexo"].Visible = false;
            dgvGrilla.Columns["Dni"].Visible = false;
            dgvGrilla.Columns["FechaNacimiento"].Visible = false;
            dgvGrilla.Columns["Eliminado"].Visible = false;

            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            base.FormatiarGrilla(dgv);
        }

        public void CargarAfiliados()
        {
            ObtenerPacientesAfiliados((long)cmbObraSocial.SelectedValue);
            dgvGrilla.DataSource = ListaPaciente.ToList();
            FormatiarGrilla(dgvGrilla);
        }

        private void cmbObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListaPaciente.Clear();
                CargarAfiliados();
            }
            catch (Exception)
            {
               
            }
        }

        public void ObtenerPacientesAfiliados(long id)
        {
            var ListaAfiliados = _obraSocialPacienteServicio.ObtenerPorObraSocial(id);

            if(ListaAfiliados != null)
            {
                foreach (var afiliados in ListaAfiliados)
                {
                    var paciente = _pacienteServicio.ObtenerPorId(afiliados.PacienteId);

                    ListaPaciente.Add(paciente);
                }
            }
        }

        //****************************** OPERACION **********************************

        public override bool EjecutarAgregarEntidad()
        {
            var fAgregar = new _0018_ABM_Afiliado(TipoOperacion.Agregar, (long)cmbObraSocial.SelectedValue);
            fAgregar.ShowDialog();
            ActualizarDatos(string.Empty);
            return fAgregar.RealizoOperacion;
        }

        public override bool EjecutarModificarEntidad(long? EntidadId)
        {
            return base.EjecutarModificarEntidad(EntidadId);
        }
    }
}
