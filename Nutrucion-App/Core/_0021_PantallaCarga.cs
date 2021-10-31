using NA.Dominio.Base.Helpers;
using Nutrucion_App.Properties;
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
    public partial class _0021_PantallaCarga : Form
    {
        private TipoCarga TipoCargas;

        public _0021_PantallaCarga(TipoCarga tipoCarga)
        {
            InitializeComponent();
            TipoCargas = tipoCarga;
        }

        private void timerOpen_Tick(object sender, EventArgs e)
        {

            if (this.Opacity < 1) this.Opacity += 0.05;
            CargaBar.Value += 1;
            CargaBar.Text = CargaBar.Value.ToString();
            if (CargaBar.Value == 100)
            {
                timerOpen.Stop();
                timerClose.Start();
            }
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timerClose.Stop();
                Close();
            }
        }

        private void _0021_PantallaCarga_Load(object sender, EventArgs e)
        {

            Grafico();

            this.Opacity = 0.0;

            CargaBar.Value = 0;
            CargaBar.Minimum = 0;
            CargaBar.Maximum = 100;

            timerOpen.Start();
        }

        public void Grafico()
        {
            if(TipoCargas == TipoCarga.Grafico)
            {
                picture01.BackgroundImage = Resources.imagen01;
                picture02.BackgroundImage = Resources.imagen02;
                picture03.BackgroundImage = Resources.imagen03;

                picture01.Width = 180;
                picture01.Height = 180;

                picture02.Width = 180;
                picture02.Height = 180;

                picture03.Width = 180;
                picture03.Height = 180;
            }
        }
    }
}
