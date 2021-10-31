using NA.Dominio.Base.Helpers;
using NA.IServicio.Circunferencia;
using NA.IServicio.Circunferencia.Dto;
using NA.IServicio.InformeCircunferencia;
using NA.IServicio.InformeCircunferencia.Dto;
using NA.Servicio.Circunferencia;
using NA.Servicio.InformeCircunferencia;
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
    public partial class _0013_ABM_ValorCircunferencia : _0002_ABM
    {
        private readonly ICircunferenciaServicio _circunferenciaServicio = new CircunferenciaServicio();
        private readonly IInformeCircunferenciaServicio _informeCircunferenciaServicio = new InformeCircunferenciaServicio();

        private List<CircunferenciaDto> ListaCircunferencia = new List<CircunferenciaDto>();

        public _0013_ABM_ValorCircunferencia()
        {
            InitializeComponent();
        }

        public _0013_ABM_ValorCircunferencia(TipoOperacion Operacion , long? EntidadId = null)
            :base(Operacion, EntidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            AgregarControlesObligatorios(txtValor ,"Valor");
            AgregarControlesObligatorios(cmbCircunferencia , "Circunferencia");
            
            CargarDatosCombo();

        }

        public override void LimpiarControles()
        {
            if(!string.IsNullOrEmpty(txtValor.Text))
            {
                txtValor.Text = "";
            }
        }

        //******************************** CARGAR COMBO ********************************

        public void CargarDatosCombo()
        {
            var informes = _informeCircunferenciaServicio.ObtenerPorAntropometrico(EntidadId.Value);

            var circunferencia = _circunferenciaServicio.ObtenerPorFiltro(string.Empty);

            if(informes.Count() > 0)
            {
                foreach (var circun in circunferencia)
                {
                    if (!informes.Any(x => x.CircunferenciaId == circun.Id))
                    {
                        ListaCircunferencia.Add(circun);

                        cmbCircunferencia.DataSource = ListaCircunferencia.ToList();
                        cmbCircunferencia.DisplayMember = "Nombre";
                        cmbCircunferencia.ValueMember = "Id";
                    }
                }
            }
            else
            {
                cmbCircunferencia.DataSource = circunferencia;
                cmbCircunferencia.DisplayMember = "Nombre";
                cmbCircunferencia.ValueMember = "Id";
            }

            txtValor.Focus();
        }

        public void AgregarCombo()
        {
            var fAgregar = new _0011_ABM_Circunferencia(TipoOperacion.Agregar);
            fAgregar.ShowDialog();
            CargarDatosCombo();
        }

        //******************************** OPERACION ********************************

        public override void EjecutarOperacion()
        {
            try
            {
                if(cmbCircunferencia.Text != string.Empty)
                {
                    var valor = new InformeCiercunferenciaDto()
                    {
                        AntropometricoId = EntidadId.Value,
                        CircunferenciaId = (long)cmbCircunferencia.SelectedValue,
                        Valor = Convert.ToDecimal(txtValor.Text)
                    };

                    _informeCircunferenciaServicio.Agregar(valor);

                    RealizoOperacion = true;

                    base.EjecutarOperacion();
                }
                else
                {
                    AgregarCombo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //************************************* VALIDACION NUMEROS *************************************

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCombo();
        }
    }
}
