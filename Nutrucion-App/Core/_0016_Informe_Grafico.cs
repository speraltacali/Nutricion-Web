using NA.Dominio.Base.Helpers;
using NA.IServicio.ContexturaCorporal;
using NA.IServicio.ContexturaCorporal.Dto;
using NA.IServicio.InformeAntropometrico;
using NA.Servicio.ContexturaCorporal;
using NA.Servicio.InformeAntropometrico;
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
    public partial class _0016_Informe_Grafico : Form
    {
        private readonly IInformeAntropometricoServicio _informeAntropometricoServicio = new InformeAntropometricoServicio();
        private readonly IContexturaCorporalServicio _contexturaCorporalServicio = new ContexturaCorporalServicio();

        private List<ContexturaCorporalDto> ListaPeso = new List<ContexturaCorporalDto>();

        private long EntidadId;
        private long PacienteId;

        public _0016_Informe_Grafico(long pacienteId)
        {
            InitializeComponent();
            //EntidadId = entidadId;
            PacienteId = pacienteId;
            CargarDatosCombos();
        }

        public void CargarDatosCombos()
        {
            cmbFechaDesde.DataSource = _informeAntropometricoServicio.ObtenerPorIdPaciente(PacienteId);
            cmbFechaDesde.DisplayMember = "Fecha";
            cmbFechaDesde.ValueMember = "Id";
        }

        private void cmbFechaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbFechaDesde.Text) && cmbFechaDesde.SelectedValue != null)
            {
                try
                {
                    var informe = _informeAntropometricoServicio.ObtenerTodo().FirstOrDefault(x => x.Id == (long)cmbFechaDesde.SelectedValue);

                    cmbFechaHasta.DataSource = _informeAntropometricoServicio.ObtenerPorFechaMayor(informe.Id , PacienteId);
                    cmbFechaHasta.DisplayMember = "Fecha";
                    cmbFechaHasta.ValueMember = "Id";
                }
                catch (Exception)
                {
                    //MessageBox.Show("Pimero seleccione la Fecha Desde para habilitar la Fecha Hasta","Adverentencia",MessageBoxButtons.OK,MessageBoxIcon);
                }
            }
        }
        //*******************************  VALIDACIONES *******************************

        public bool ValidacionGrafico()
        {
            if(string.IsNullOrEmpty(cmbFechaHasta.Text))
            {
                MessageBox.Show("Selecione en Fecha Desde , para hablitar Fecha Hasta.", "Advertencia", MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        //*******************************  GENERAR GRAFICOS *******************************

        private void btnGenerarGrafico_Click(object sender, EventArgs e)
        {
            if(ValidacionGrafico())
            {
                var carga = new _0021_PantallaCarga(TipoCarga.Grafico);
                carga.ShowDialog();


                //this.chartPorcentaje.Series["Peso"].Points.Clear();
                ListaPeso.Clear();

                this.chartPeso.Series["Valores"].Points.Clear();
                this.chartPorcentaje.Series["Musculo"].Points.Clear();
                this.chartPorcentaje.Series["Grasa"].Points.Clear();

                var informeDesde = _informeAntropometricoServicio.ObtenerTodo().FirstOrDefault(x => x.Id == (long)cmbFechaDesde.SelectedValue);
                var informeHasta = _informeAntropometricoServicio.ObtenerTodo().FirstOrDefault(x => x.Id == (long)cmbFechaHasta.SelectedValue);

                GraficoPeso(informeDesde.Id, informeHasta.Id);
                GraficoGrasa(informeDesde.Id, informeHasta.Id);
                GraficoMusculo(informeDesde.Id, informeHasta.Id);
            }
        }

        public void GraficoPeso(long desde , long hasta)
        {
            var informesPeso = _informeAntropometricoServicio.ObtenerPorRangoFecha(desde , hasta , PacienteId);

            foreach (var informe in informesPeso)
            {
                var peso = _contexturaCorporalServicio.ObtenerPorInforme(informe.Id);

                if(peso != null)
                {
                    peso.FechaInforme = informe.Fecha;
                    ListaPeso.Add(peso);
                }
                else
                {
                    MessageBox.Show($"El Informe Antropologico numero : {informe.Numero.ToString()} no tiene los datos completos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }

            foreach (var peso in ListaPeso)
            {
                this.chartPeso.Series["Valores"].Points.AddXY(Convert.ToString(peso.FechaInforme.Date.Day + "/" + peso.FechaInforme.Date.Month + "/"
                    + peso.FechaInforme.Date.Year), peso.Peso);
            }

        }

        public void GraficoGrasa(long desde , long hasta)
        {

            var informeGrasa = _informeAntropometricoServicio.ObtenerPorRangoFecha(desde, hasta , PacienteId);

            foreach (var grasa in informeGrasa)
            {
                this.chartPorcentaje.Series["Grasa"].Points.AddXY(Convert.ToString(grasa.Fecha.Date.Day + "/" + grasa.Fecha.Date.Month + "/" + grasa.Fecha.Date.Year), grasa.PorcentajeGrasa);
            }

        }

        public void GraficoMusculo(long desde , long hasta)
        {
            var informeMusculo = _informeAntropometricoServicio.ObtenerPorRangoFecha(desde, hasta, PacienteId);

            foreach ( var musculo  in informeMusculo)
            {
                this.chartPorcentaje.Series["Musculo"].Points.AddXY(Convert.ToString(musculo.Fecha.Date.Day + "/" + musculo.Fecha.Date.Month + "/" + musculo.Fecha.Date.Year), musculo.PorcentajeMusculo);
            }
        }
    }
}
