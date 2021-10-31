using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NA.Dominio.Base.Helpers;
using NA.IServicio.Circunferencia;
using NA.IServicio.ContexturaCorporal;
using NA.IServicio.Dieta;
using NA.IServicio.Documento;
using NA.IServicio.InformeAntropometrico;
using NA.IServicio.InformeCircunferencia;
using NA.Servicio.Circunferencia;
using NA.Servicio.ContexturaCorporal;
using NA.Servicio.Dieta;
using NA.Servicio.Documento;
using NA.Servicio.InformeAntropometrico;
using NA.Servicio.InformeCircunferencia;

namespace Nutrucion_App.Core
{
    public partial class _0008_InformeAntropometrico : Form
    {
        private readonly IInformeAntropometricoServicio _informeAntropometrico = new InformeAntropometricoServicio();
        private readonly IInformeCircunferenciaServicio _informeCircunferencia = new InformeCircunferenciaServicio();
        private readonly ICircunferenciaServicio _circunferenciaServicio = new CircunferenciaServicio();

        private readonly IDietaServicio _dietaServicio = new DietaServicio();
        private readonly IContexturaCorporalServicio _contexturaCorporal = new ContexturaCorporalServicio();
        private readonly IDocumentoServicio _documentoServicio = new DocumentoServicio();



        private static long antropometricoId;
        private long? InformeCircunferenciaId;
        private object ObjetoSeleccionado;

        public _0008_InformeAntropometrico(long AntropometricoId)
        {
            InitializeComponent();
            antropometricoId = AntropometricoId;
            Inicializador();
        }

        public void Inicializador()
        {
            ValidarDieta();
            CargarDatos(antropometricoId);
        }

        public void ValidarDieta()
        {
            var dieta = _dietaServicio.ObtenerPorInforme(antropometricoId);

            if (dieta != null)
            {
                btnDieta.Text = "El Plan ya se encuentra cargado.";
                btnDieta.Enabled = false;
                pnlDatosPlan.Visible = true;
            }
            else
            {
                btnDieta.Visible = true;
                pnlDatosPlan.Visible = false;
            }
        }

        public void CargarDatos(long id)
        {
            var contextura = _contexturaCorporal.ObtenerPorInforme(id);

            var dieta = _dietaServicio.ObtenerPorInforme(id);

            var informe = _informeAntropometrico.ObtenerPorId(antropometricoId);

            dtmFecha.Value = informe.Fecha; 

            if(informe.Observacion != null)
            {
                txtObservacion.Text = informe.Observacion;
            }

            if (informe.PorcentajeGrasa != null && informe.KilosGrasa != null)
            {
                txtPorcentajeGrasa.Text = informe.PorcentajeGrasa.ToString();
                txtGrasa.Text = informe.KilosGrasa.ToString();
            }

            if (informe.PorcentajeMusculo != null && informe.KilosMusculo != null)
            {
                txtPorcentajeMusculo.Text = informe.PorcentajeMusculo.ToString();
                txtMusculo.Text = informe.KilosMusculo.ToString();
            }


            CargarValorCircunferencia();

            if (contextura != null)
            {
                txtPeso.Text = contextura.Peso.ToString();
                txtAltura.Text = contextura.Altura.ToString();
            }

            if (dieta != null)
            {
                txtCalorias.Text = dieta.Calorias.ToString();
                txtTipoPlan.Text = dieta.TipoPlan.ToString();
                txtComidas.Text = dieta.CantidadComidas.ToString();

            }

        }

        //************************** MOSTRAR DOCUMENTO ******************************

        public void MostrarDocumento(long id)
        {
            var dieta = _dietaServicio.ObtenerPorInforme(id);

            var documento = _documentoServicio.ObtenerPorDieta(dieta.Id);

            if(documento != null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string folder = path + "/temp/";
                string fullFilePath = folder + documento.Nombre;

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (File.Exists(fullFilePath))
                {
                    //Directory.Delete(fullFilePath);
                    File.Delete(fullFilePath);
                }

                File.WriteAllBytes(fullFilePath, documento.Doc);

                Process.Start(fullFilePath);
            }
            else
            {
                if(MessageBox.Show("No se cargo el documento de la dieta , desea cargar en este momento?","Advertencia",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var modificar = new _0012_ABM_Dieta(TipoOperacion.Modificar, antropometricoId);
                    modificar.ShowDialog();
                }
            }

        }

        //************************** ASIGNAR NOMBRE ******************************

        public void CargarValorCircunferencia()
        {
            var informe = _informeCircunferencia.ObtenerPorAntropometrico(antropometricoId);

            foreach (var info in informe)
            {
                var circunferencia = _circunferenciaServicio.ObtenerPorId(info.CircunferenciaId);

                info.NombreCircunferencia = circunferencia.Nombre;
            }

            dgvGrilla.DataSource = informe;

            FormatiarGrilla();
        }

        public void FormatiarGrilla()
        {
            dgvGrilla.Columns["Id"].Visible = false;
            dgvGrilla.Columns["AntropometricoId"].Visible = false;
            dgvGrilla.Columns["CircunferenciaId"].Visible = false;

            dgvGrilla.Columns["NombreCircunferencia"].HeaderText = @"Circunferencia";
            dgvGrilla.Columns["NombreCircunferencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvGrilla.Columns["Valor"].HeaderText = @"Valor";
            dgvGrilla.Columns["Valor"].Width = 120;
        }

        //************************** BOTONES DEL PLAN ******************************

        private void btnDieta_Click(object sender, EventArgs e)
        {
            var fAgregar = new _0012_ABM_Dieta(TipoOperacion.Agregar , antropometricoId);
            fAgregar.ShowDialog();
            ValidarDieta();
            CargarDatos(antropometricoId);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var fModificar = new _0012_ABM_Dieta(TipoOperacion.Modificar , antropometricoId);
            fModificar.ShowDialog();
            CargarDatos(antropometricoId);
        }


        private void btnDocumento_Click(object sender, EventArgs e)
        {
            MostrarDocumento(antropometricoId);
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            var informe = _informeAntropometrico.ObtenerPorId(antropometricoId);

            informe.Observacion = txtObservacion.Text;

            _informeAntropometrico.Modificar(informe);

            MessageBox.Show("Guardado Exitoso", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //*********************** Valores de circunferencia *************************

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var fAgregar = new _0013_ABM_ValorCircunferencia(TipoOperacion.Agregar , antropometricoId);
            fAgregar.ShowDialog();
            CargarValorCircunferencia();

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            var InformeCircunferencia = _informeCircunferencia.ObtenerPorId(InformeCircunferenciaId.Value);

            var circunferencia = _circunferenciaServicio.ObtenerPorId(InformeCircunferencia.CircunferenciaId);

            if(MessageBox.Show($"Desa quitar el registro {circunferencia.Nombre} ?","Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                _informeCircunferencia.Eliminar(InformeCircunferenciaId.Value);
                CargarValorCircunferencia();
            }
        }

        //*********************** Seleccion de listado *************************

        public bool VerificarDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }

        public bool VerificarDatoSeleccionado()
        {
            return InformeCircunferenciaId.HasValue;
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(VerificarDatosCargados())
            {
                InformeCircunferenciaId = (long)dgvGrilla["Id", e.RowIndex].Value;
                ObjetoSeleccionado = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
                
            }
            else
            {
                InformeCircunferenciaId = null;
                ObjetoSeleccionado = null;
            }
        }

        //*********************** Porcentajes y Kilos *************************

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAltura.Text) || !string.IsNullOrEmpty(txtGrasa.Text)
                || !string.IsNullOrEmpty(txtMusculo.Text))
            {
                try
                {
                    var informe = _informeAntropometrico.ObtenerPorId(antropometricoId);

                    informe.PorcentajeMusculo = Convert.ToDecimal(txtPorcentajeMusculo.Text);
                    informe.PorcentajeGrasa = Convert.ToDecimal(txtPorcentajeGrasa.Text);
                    informe.KilosGrasa = Convert.ToDecimal(txtGrasa.Text);
                    informe.KilosMusculo = Convert.ToDecimal(txtMusculo.Text);

                    _informeAntropometrico.Modificar(informe);

                    //MessageBox.Show("Los registros se guardaron correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var Mensaje = new _0020_Mensaje(TipoOperacion.Agregar);

                    Mensaje.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Los datos ingresados son invalidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

            else
            {
                MessageBox.Show("Verificar que los tres campos se encuentren completos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnFecha_Click(object sender, EventArgs e)
        {
            var informe = _informeAntropometrico.ObtenerPorId(antropometricoId);

            informe.Fecha = dtmFecha.Value;

            _informeAntropometrico.Modificar(informe);

            MessageBox.Show("Los registros se guardaron correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPorcentajeGrasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }



        //***********************************************************************************************//
    }
}
