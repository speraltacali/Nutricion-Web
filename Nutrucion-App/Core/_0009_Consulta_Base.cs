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
    public partial class _0009_Consulta_Base : Form
    {
        private long? entidadId;
        protected object ObjetoSeleccionado;
        private string _titulo;


        public _0009_Consulta_Base()
        {
            InitializeComponent();
        }

        public _0009_Consulta_Base(string titulo)
        {
            InitializeComponent();
            _titulo = titulo;
        }

        private void _0009_Consulta_Base_Load(object sender, EventArgs e)
        {
            EjecutarEventoLoad();
            lblTitulo.Text = $"Listado de {_titulo}";

            this.Opacity = 0.0;
            TimerOpen.Start();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (EjecutarAgregarEntidad())
            {
                ActualizarDatos(string.Empty);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatosCargados())
            {
                if (VerificarSiSeleccionoAlgunRegistro())
                {
                    if (EjecutarModificarEntidad(entidadId))
                    {
                        ActualizarDatos(string.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro valido.", "Advertencia", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay datos Cargados.", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatosCargados())
            {
                if (VerificarSiSeleccionoAlgunRegistro())
                {
                    if (EjecutarEliminarEntidad(entidadId))
                    {
                        ActualizarDatos(string.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro valido.", "Advertencia", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay datos Cargados.", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);

            txtBuscar.Text = string.Empty;
            txtBuscar.Focus();
        }


        //******************************************************************//


        public virtual void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (VerificarSiExistenDatosCargados())
            {
                entidadId = (long) dgvGrilla["Id", e.RowIndex].Value;
                ObjetoSeleccionado = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                entidadId = null;
                ObjetoSeleccionado = null;
            }
        }


        public virtual void FormatiarGrilla(DataGridView dgv)
        {

        }

        //******************************************************************//

        public virtual void EjecutarEventoLoad()
        {
            ActualizarDatos(string.Empty);
        }

        public virtual bool VerificarSiSeleccionoAlgunRegistro()
        {
            return entidadId.HasValue;
        }

        public virtual bool VerificarSiExistenDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }


        public virtual void ActualizarDatos(string empty)
        {

        }

        public virtual bool EjecutarAgregarEntidad()
        {
            return false;
        }

        public virtual bool EjecutarModificarEntidad(long? EntidadId)
        {
            return false;
        }

        public virtual bool EjecutarEliminarEntidad(long? EntidadId)
        {
            return false;
        }

        public virtual void Buscar(string cadena)
        {

        }

        //**********************************************************************//

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar(txtBuscar.Text);

                txtBuscar.Text = string.Empty;
                txtBuscar.Focus();
            }
        }


        //**********************************************************************//

        private void btnAgregar_MouseHover(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.PaleVioletRed;
        }

        private void btnModificar_MouseHover(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.PaleVioletRed;
        }

        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.PaleVioletRed;
        }

        private void btnVolver_MouseHover(object sender, EventArgs e)
        {
            btnVolver.BackColor = Color.PaleVioletRed;
        }

        //*********************************************************************//

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.LightPink;
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.LightPink;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.LightPink;
        }

        private void btnVolver_MouseLeave(object sender, EventArgs e)
        {
            btnVolver.BackColor = Color.LightPink;
        }

        private void TimerOpen_Tick(object sender, EventArgs e)
        {
            int cont = 0;

            if (this.Opacity < 1) this.Opacity += 0.05;
            cont += 1;

            if (cont == 100)
            {
                TimerOpen.Stop();
            }
        }
    }
}
