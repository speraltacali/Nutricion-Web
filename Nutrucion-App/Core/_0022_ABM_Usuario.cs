using NA.Dominio.Base.Helpers;
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
    public partial class _0022_ABM_Usuario : _0002_ABM
    {
        public _0022_ABM_Usuario()
        {
            InitializeComponent();
        }

        public _0022_ABM_Usuario(TipoOperacion operacion , long? entidadId = null)
           :base(operacion,entidadId)
        {
            InitializeComponent();
        }

    }
}
