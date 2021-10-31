using NA.Dominio.Base.Helpers;
using NA.IServicio.ObraSocialPaciente;
using NA.IServicio.ObraSocialPaciente.Dto;
using NA.IServicio.Paciente.Dto;
using NA.Servicio.ObraSocialPaciente;
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
    public partial class _0018_ABM_Afiliado : _0002_ABM
    {
        private readonly IObraSocialPacienteServicio _obraSocialPacienteServicio = new ObraSocialPacienteServicio();

        private PacienteDto Paciente;

        public _0018_ABM_Afiliado(TipoOperacion Operacion , long? EntidadId = null)
            :base(Operacion,EntidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            AgregarControlesObligatorios(txtAfiliado, "N° Afiliado");
            AgregarControlesObligatorios(txtPaciente, "Paciente");

            txtAfiliado.Focus();

            base.Inicializador();
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);
        }

        public void CargarPaciente()
        {
            txtPaciente.Text = Paciente.ApyNom;
        }

        //*************************** TIPO DE OPERACION ****************************

        public override void EjecutarAgregar()
        {
            try
            {
                var afiliado = new ObraSocialPacienteDto
                {
                    ObraSocialId = EntidadId.Value,
                    PacienteId = Paciente.Id,
                    NumeroAfiliado = txtAfiliado.Text
                };

                _obraSocialPacienteServicio.Agregar(afiliado);
                RealizoOperacion = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        public override void EjecutarModificar()
        {
            base.EjecutarModificar();
        }


        //********************************* BUSCAR PACIENTE *************************

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var fBuscar = new _0019_Buscador();
            fBuscar.ShowDialog();
            Paciente = fBuscar.Paciente;
            CargarPaciente();
        }
    }
}
