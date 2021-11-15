using NA.IServicio.Paciente;
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
using NA.IServicio.Paciente.Dto;
using Nutrucion_App.Core;
using NA.Dominio.Base.Helpers;
using System.Security.Cryptography.X509Certificates;
using System.Media;

namespace NutricionApp
{
    public partial class _0001_Consulta : Form
    {
        private IPacienteServicio _pacienteServicio = new PacienteServicio();


        public long? _entidadId;

        protected object ObjetoSeleccionado;

        public _0001_Consulta()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormatearGrilla(dgvGrilla);

            ContadorPaciente();

            this.Opacity = 0.0;
            TimeOpen.Start();
        }

        public void FormatearGrilla(DataGridView dgv)
        {
            CargarGrilla(string.Empty);

            dgvGrilla.Columns["Id"].Visible = false;
            dgvGrilla.Columns["Apellido"].Visible = false;
            dgvGrilla.Columns["Nombre"].Visible = false;
            dgvGrilla.Columns["Sexo"].Visible = false;
            dgvGrilla.Columns["Dni"].Visible = false;
            dgvGrilla.Columns["FechaNacimiento"].Visible = false;
            dgvGrilla.Columns["Eliminado"].Visible = false;

            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].AutoSizeMode =  DataGridViewAutoSizeColumnMode.Fill;

        }

        public void CargarGrilla(string cadena)
        {
            OrderAcendente(cadena);
        }

        public void OrderAcendente(string cadena)
        {
            dgvGrilla.DataSource = _pacienteServicio.ObtenerPorFiltro(cadena).OrderBy(x => x.Apellido).ToList();
        }

        public void OrderDecendente(string cadena)
        {
            dgvGrilla.DataSource = _pacienteServicio.ObtenerPorFiltro(cadena).OrderByDescending(x => x.Apellido).ToList();
        }

        //**************************** OPERACION ************************************

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var Agregar = new _0004_ABM_Paciente(TipoOperacion.Agregar);
            Agregar.ShowDialog();
            FormatearGrilla(dgvGrilla);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(VerificarDatosCargados())
            {
                if(VerificarSeleccionRegirstro())
                {
                    var Modificar = new _0004_ABM_Paciente(TipoOperacion.Modificar, _entidadId);
                    Modificar.ShowDialog();
                    FormatearGrilla(dgvGrilla);
                }
                else
                {
                    MessageBox.Show("Seleccione el registro que desea modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay datos registrados para modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            var Items = new _0007_Consulta_Item();
            Items.ShowDialog();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.Rows.Count != 0)
            {
                var perfil = new _0003_Perfil(_entidadId.Value);
                perfil.ShowDialog();
            }
        }

        private void btnCircunferencia_Click(object sender, EventArgs e)
        {
            var fCircunferencia = new _0010_Consulta_Circunferencia();
            fCircunferencia.ShowDialog();
        }

        //**************************** VERIFICAR DATOS ************************************

        public bool VerificarDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }

        public bool VerificarSeleccionRegirstro()
        {
            return _entidadId.HasValue;
        }

        //**************************** DATO SELECCIONADO ************************************

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(VerificarDatosCargados())
            {
                _entidadId = (long)dgvGrilla["Id", e.RowIndex].Value;
                ObjetoSeleccionado = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                _entidadId = null;
                ObjetoSeleccionado = null;
            }
        }

        //**************************** Operaciones Perfil ************************************

        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var perfil = new _0003_Perfil(_entidadId.Value);
            perfil.ShowDialog();
        }

        //**************************** Items ************************************
        
        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Items = new _0007_Consulta_Item();
            Items.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Items = new _0005_ABM_Item(TipoOperacion.Agregar);
            Items.ShowDialog();
        }

        //**************************** Circunferencia ************************************

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fCircunferencia = new _0010_Consulta_Circunferencia();
            fCircunferencia.ShowDialog();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fCircunferencia = new _0011_ABM_Circunferencia(TipoOperacion.Agregar );
            fCircunferencia.ShowDialog();
        }

        //**************************** Obra Social ************************************

        private void consultaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fConsulta = new _0014_Consulta_ObraSocial();
            fConsulta.ShowDialog();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fAgregar = new _0015_ABM_ObraSocial(TipoOperacion.Agregar);
            fAgregar.ShowDialog();
        }

        private void afiliadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fAfiliado = new _0017_Afiliado_ObraSocial();
            fAfiliado.ShowDialog();
        }

        //**************************** Opcion de form ************************************

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea salir del sistema de gestion ","Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Close();
            }
        }

        //****************************  ************************************

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var paciente = _pacienteServicio.ObtenerPorId(_entidadId.Value);

            if(MessageBox.Show("Desea Eliminar al paciente : "+ paciente.ApyNom ,"Eliminar Registro",MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                var fEliminar = new _0004_ABM_Paciente(TipoOperacion.Eliminar, _entidadId.Value);
                fEliminar.ShowDialog();
                FormatearGrilla(dgvGrilla);
            }
        }

        //**************************** Busqueda ************************************

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerBusqueda(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ObtenerBusqueda(txtBuscar.Text);
            }
        }

        public void ObtenerBusqueda(string cadena)
        {

            if (!string.IsNullOrEmpty(txtBuscar.Text))                                              
            {
                var paciente = _pacienteServicio.ObtenerPorFiltro(cadena);

                dgvGrilla.DataSource = paciente.ToList();


                txtBuscar.Text = string.Empty;
                txtBuscar.Focus();
            }
            else
            {
                FormatearGrilla(dgvGrilla);
            }

            ContadorPaciente();
        }

        public void ContadorPaciente()
        {
            this.txtCantidad.Text = dgvGrilla.Rows.Count.ToString();
        }

        private void TimeOpen_Tick(object sender, EventArgs e)
        {
            int cont = 0;

            if (this.Opacity < 1) this.Opacity += 0.05;
            cont += 1;

            if(cont == 100)
            {
                TimeOpen.Stop();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAcendente_Click(object sender, EventArgs e)
        {
            OrderAcendente(string.Empty);
        }

        private void btnDecendente_Click(object sender, EventArgs e)
        {
            OrderDecendente(string.Empty);
        }

        private void ItemPlanesConsulta_Click(object sender, EventArgs e)
        {
            var fPlanConsulta = new _0023_Consulta_Plan();
            fPlanConsulta.ShowDialog();
        }



        //private void dgvGrilla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        dgvGrilla.CurrentCell = dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex];

        //        ContextMenuStrip menu = new ContextMenuStrip();

        //        menu.Items.Add("Agregar").Name = "AGREGAR";
        //        menu.Items.Add("Modificar").Name = "MODIFICAR";
        //        menu.Items.Add("Eliminar").Name = "ELIMINAR";

        //        Rectangle coordenada = dgvGrilla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

        //        int anchoCelda = coordenada.Location.X;
        //        int AltoCelda = coordenada.Location.Y;

        //        int X = anchoCelda + dgvGrilla.Location.X;
        //        int Y = AltoCelda + dgvGrilla.Location.Y +15;

        //        menu.Show(dgvGrilla, new Point(X, Y));
        //    }
        //}
    }
}
