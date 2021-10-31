using NA.IServicio.Paciente;
using NA.IServicio.Paciente.Dto;
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
    public partial class _0019_Buscador : Form
    {
        private readonly IPacienteServicio _pacienteServicio = new PacienteServicio();

        public PacienteDto Paciente;

        public _0019_Buscador()
        {
            InitializeComponent();
            CargarGrilla(string.Empty);
        }

        public void CargarGrilla(string empty)
        {
            dgvGrilla.DataSource = _pacienteServicio.ObtenerPorFiltro(empty);
            FormatiarGrilla(dgvGrilla);
        }

        public void FormatiarGrilla(DataGridView dgv)
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
        }

        public bool RegistroSeleccionado()
        {
            return dgvGrilla.RowCount > 0;
        }

        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(RegistroSeleccionado())
            {
                var entidadId = (long)dgvGrilla["Id", e.RowIndex].Value;

                Paciente = _pacienteServicio.ObtenerPorId(entidadId);
                Close();
            }
        }
    }
}
