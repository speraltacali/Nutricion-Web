using NA.Dominio.Base.Helpers;
using NA.IServicio.Nivel;
using NA.IServicio.Plan;
using NA.Servicio.Nivel;
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
    public partial class _0026_ABM_Nivel : _0002_ABM
    {
        private readonly INivelServicio _nivelServicio = new NivelServicio();
        private readonly IPlanServicio _planServicio = new PlanServicio();

        public _0026_ABM_Nivel()
        {
            InitializeComponent();
        }

        public _0026_ABM_Nivel(TipoOperacion operacion , long? EntidadId = null)
            :base(operacion,EntidadId)
        {
            InitializeComponent();
            Inicializador();
        }

        public override void Inicializador()
        {
            CargarCombo();

        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);
        }

        public override void LimpiarControles()
        {
            base.LimpiarControles();
        }

        public void CargarCombo()
        {

        }
    }
}
