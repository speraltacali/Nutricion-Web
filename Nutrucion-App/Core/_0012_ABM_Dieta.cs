using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NA.Dominio.Base.Helpers;
using NA.IServicio.ContexturaCorporal;
using NA.IServicio.ContexturaCorporal.Dto;
using NA.IServicio.Dieta;
using NA.IServicio.Dieta.Dto;
using NA.IServicio.Documento;
using NA.IServicio.Documento.Dto;
using NA.Servicio.ContexturaCorporal;
using NA.Servicio.Dieta;
using NA.Servicio.Documento;

namespace Nutrucion_App.Core
{
    public partial class _0012_ABM_Dieta : _0002_ABM
    {
        private readonly IDocumentoServicio _documentoServicio = new DocumentoServicio();
        private readonly IDietaServicio _dietaServicio = new DietaServicio();
        private readonly IContexturaCorporalServicio _contexturaCorporal = new ContexturaCorporalServicio();

        private bool SeleccionArchivo = false;

        public _0012_ABM_Dieta()
        {
            InitializeComponent();
        }

        public _0012_ABM_Dieta(TipoOperacion Operacion , long? EntidadId = null)
        :base(Operacion,EntidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            AgregarControlesObligatorios(txtAltura,"Altura");
            AgregarControlesObligatorios(txtCaloria,"Caloreias");
            AgregarControlesObligatorios(txtComida,"Cantidad de Comidas");
            AgregarControlesObligatorios(txtPeso,"Peso");

            cmbTipoPlan.DataSource = Enum.GetValues(typeof(TipoPlan));

            cmbTipoPlan.Focus();

            base.Inicializador();
        }

        public override void CargarDatos(long? entidadId)
        { 
            if(entidadId.HasValue)
            {
                var dieta = _dietaServicio.ObtenerPorInforme(entidadId.Value);
                var contextura = _contexturaCorporal.ObtenerPorInforme(entidadId.Value);
                var documento = _documentoServicio.ObtenerPorDieta(dieta.Id);

                txtAltura.Text = contextura.Altura.ToString();
                txtPeso.Text = contextura.Peso.ToString();

                txtCaloria.Text = dieta.Calorias.ToString();
                txtComida.Text = dieta.CantidadComidas.ToString();

                if(documento != null)
                {
                    txtDocumento.Text = documento.Nombre.ToString();
                }

                cmbTipoPlan.SelectedItem = (TipoPlan)dieta.TipoPlan;
            }
            else
            {
                MessageBox.Show("No se encuentro el plan solicitado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            base.CargarDatos(entidadId);
        }

        public override void LimpiarControles()
        {
            if (!string.IsNullOrEmpty(txtCaloria.Text))
            {
                txtCaloria.Text = "";
            }

            if (!string.IsNullOrEmpty(txtAltura.Text))
            {
                txtAltura.Text = "";
            }

            if (!string.IsNullOrEmpty(txtComida.Text))
            {
                txtComida.Text = "";
            }

            if (!string.IsNullOrEmpty(txtPeso.Text))
            {
                txtPeso.Text = "";
            }


            base.LimpiarControles();
        }


        //******************** OPERACION ********************************/

        public override void EjecutarAgregar()
        {

            try
            {
                var corporal = new ContexturaCorporalDto
                {
                    Peso = Convert.ToDecimal(txtPeso.Text),
                    Altura = Convert.ToDecimal(txtAltura.Text),
                    IAntropometricoId = EntidadId.Value
                };

                var dieta = new DietaDto
                {
                    TipoPlan = (TipoPlan)cmbTipoPlan.SelectedValue,
                    Calorias = Convert.ToDecimal(txtCaloria.Text),
                    CantidadComidas = Convert.ToInt32(txtComida.Text),
                    IAntropometricoId = EntidadId.Value
                };

                _contexturaCorporal.Agregar(corporal);

                var dietaId = _dietaServicio.Agregar(dieta);

                GuardarDocumento(dietaId.Id);

                RealizoOperacion = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            base.EjecutarAgregar();
        }

        public override void EjecutarModificar()
        {
            var dieta = _dietaServicio.ObtenerPorInforme(EntidadId.Value);

            var contextura = _contexturaCorporal.ObtenerPorInforme(EntidadId.Value);

            if(dieta != null)
            {
                try
                {
                    dieta.Calorias = Convert.ToDecimal(txtCaloria.Text);
                    dieta.CantidadComidas = Convert.ToInt32(txtComida.Text);
                    dieta.TipoPlan = (TipoPlan)cmbTipoPlan.SelectedItem;

                    contextura.Altura = Convert.ToDecimal(txtAltura.Text);
                    contextura.Peso = Convert.ToDecimal(txtPeso.Text);

                    _dietaServicio.Modificar(dieta);
                    _contexturaCorporal.Modificar(contextura);

                    var documento = _documentoServicio.ObtenerPorDieta(dieta.Id);

                    if (documento == null)
                    {
                        GuardarDocumento(dieta.Id);
                    }
                    else
                    {
                        ModificarDocumento(dieta.Id);
                    }

                    RealizoOperacion = true;

                }
                catch (Exception)
                {
                    MessageBox.Show("Uno o mas de los datos ingresados son invalidos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            base.EjecutarModificar();
        }

        //****************************  OPERACION DOCUMENTO ********************************

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDocumento.Text = openFileDialog1.FileName;
                SeleccionArchivo = true;
            }
        }

        public void GuardarDocumento(long dietaId)
        {
            if (txtDocumento.Text.Trim().Equals(""))
            {
                //MessageBox.Show("Debe seleccionar el archivo que contiene el plan.", "Advertencia",
                //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            byte[] file = null;

            Stream myStream = openFileDialog1.OpenFile();

            using (MemoryStream ms = new MemoryStream())
            {
                myStream.CopyTo(ms);
                file = ms.ToArray();
            }

            var documento = new DocumentoDto()
            {
                Nombre = openFileDialog1.SafeFileName,
                Doc = file,
                DietaId = dietaId
            };

            _documentoServicio.Agregar(documento);
        }

        public void ModificarDocumento(long dietaId)
        {
            if(SeleccionArchivo)
            {
                var dieta = _dietaServicio.ObtenerPorId(dietaId);

                var documento = _documentoServicio.ObtenerPorDieta(dietaId);

                byte[] file = null;

                Stream myStream = openFileDialog1.OpenFile();

                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    file = ms.ToArray();
                }

                documento.Nombre = openFileDialog1.SafeFileName;
                documento.Doc = file;

                _documentoServicio.Modificar(documento);
            } 

        }

        //****************************  VALIDACION NUMERO ********************************

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
