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
    public partial class _0020_Mensaje : Form
    {
        TipoOperacion Operacion;

        int cont = 0;

        public _0020_Mensaje(TipoOperacion operacion)
        {
            InitializeComponent();

            Operacion = operacion;
        }

        public void ValidarOperacion()
        {
            if(Operacion == TipoOperacion.Modificar)
            {
                lblOperacion.Text += "Modifico";
                pnlFondo.BackColor = Color.SandyBrown;
                pictureBox1.BackgroundImage = Resources.edit_simple;
            }
            if (Operacion == TipoOperacion.Eliminar)
            {
                lblOperacion.Text += "Elimino";
                pnlFondo.BackColor = Color.LightCoral;
                pictureBox1.BackgroundImage = Resources.delete_simple;
            }
            if (Operacion == TipoOperacion.Agregar)
            {
                lblOperacion.Text += "Agrego";
            }

        }

        private void TimerOpen_Tick(object sender, EventArgs e)
        {

            if (this.Opacity < 1)this.Opacity += 0.05;
            cont += 1;

            if(cont == 80)
            {
                TimerOpen.Stop();
                TimerClose.Start();
            }
        }

        private void TimerClose_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 1;
            if(this.Opacity == 0)
            {
                TimerClose.Stop();
                Close();
            }
        }

        private void _0020_Mensaje_Load(object sender, EventArgs e)
        {
            ValidarOperacion();

            this.Opacity = 0.0;
            TimerOpen.Start();
        }
    }
}
