using NA.Dominio.Base.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutrucion_App.Core
{
    public partial class _0002_ABM : Form
    {
        protected TipoOperacion Operacion;

        protected long? EntidadId;

        public bool RealizoOperacion;

        private readonly List<ControlObligatorioDto> _listaControlesObligatorio;

        public _0002_ABM()
        {
            InitializeComponent();

            RealizoOperacion = false;
            _listaControlesObligatorio = new List<ControlObligatorioDto>();
        }

        public _0002_ABM(TipoOperacion operacion, long? entidadId)
            :this()
        {
            Operacion = operacion;
            EntidadId = entidadId;
        }

        //****************************************************************************//

        public virtual void EjecutarOperacion()
        {
            switch (Operacion)
            {
                case TipoOperacion.Agregar:
                    if (VerificarDatosObligatorios())
                    {
                        EjecutarAgregar();
                        LimpiarControles();
                        if(RealizoOperacion)
                        {
                            var agregar = new _0020_Mensaje(TipoOperacion.Agregar);
                            agregar.ShowDialog();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Faltan Datos Obligatorios" , "Advertencia", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                    }
                    break;

                case TipoOperacion.Modificar:
                    if (VerificarDatosObligatorios())
                    {
                        EjecutarModificar();
                        if (RealizoOperacion)
                        {
                            var modificar = new _0020_Mensaje(TipoOperacion.Modificar);
                            modificar.ShowDialog();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Faltan Datos Obligatorios", "Advertencia" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case TipoOperacion.Eliminar:
                    EjecutarEliminar();
                    RealizoOperacion = true;

                    var eliminar = new _0020_Mensaje(TipoOperacion.Eliminar);
                    eliminar.ShowDialog();
                    Close();

                    break;

            }
        }

        public virtual void EjecutarAgregar()
        {

        }

        public virtual void EjecutarModificar()
        {

        }
        
        public virtual void EjecutarEliminar()
        {

        }

        //****************************************************************************//

        public virtual void Inicializador()
        {
            switch (Operacion)
            {
                case TipoOperacion.Agregar:
                    lblTitulo.Text = "Agregar";
                    break;
                case TipoOperacion.Modificar:
                    lblTitulo.Text = "Modificar";
                    CargarDatos(EntidadId);
                    break;
                case TipoOperacion.Eliminar:
                    lblTitulo.Text = "Eliminar";
                    CargarDatos(EntidadId);
                    break;
            }
        }

        public virtual void LimpiarControles()
        {

        }

        public virtual void CargarDatos(long? entidadId)
        {

        }

        //****************************************************************************//

        public virtual void AgregarControlesObligatorios(object control , string nombreControl)
        {
            _listaControlesObligatorio.Add(new ControlObligatorioDto
            {
                Control = control,
                NombreControl = nombreControl
            });
        }


        public virtual bool VerificarDatosObligatorios()
        {
            foreach (var objeto in _listaControlesObligatorio)
            {
                if(objeto.Control is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)objeto.Control).Text))
                    {
                        return false;
                    }
                }

                if (objeto.Control is RichTextBox)
                {
                    if (string.IsNullOrEmpty(((RichTextBox)objeto.Control).Text))
                    {
                        return false;
                    }
                }

                if (objeto.Control is NumericUpDown)
                {
                    if (string.IsNullOrEmpty(((NumericUpDown)objeto.Control).Text))
                    {
                        return false;
                    }
                }

                if (objeto.Control is ComboBox)
                {
                    if (string.IsNullOrEmpty(((ComboBox)objeto.Control).Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }




        private void pixEjecutar_Click(object sender, EventArgs e)
        {
            EjecutarOperacion();
        }

        private void pixLimpiar_Click(object sender, EventArgs e)
        {
            if (VerificarDatosObligatorios() && Operacion != TipoOperacion.Eliminar)
            {
                if (MessageBox.Show("Hay Datos sin guardar. Desea Limpiar los controles?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    LimpiarControles();
                }
            }
            else
            {
                LimpiarControles();
            }
        }

        private void pixCancelar_Click(object sender, EventArgs e)
        {
            if (VerificarDatosObligatorios() && Operacion != TipoOperacion.Eliminar)
            {
                if (MessageBox.Show("Hay Datos sin guardar. Desea Salir de la operacion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                if (MessageBox.Show("Desea Salir de la operacion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        //**********************************************************************//

        private void pixLimpiar_MouseHover(object sender, EventArgs e)
        {
            pixLimpiar.BackColor = Color.Plum;
        }

        private void pixEjecutar_MouseHover(object sender, EventArgs e)
        {
            pixEjecutar.BackColor = Color.Plum;
        }

        private void pixCancelar_MouseHover(object sender, EventArgs e)
        {
            pixCancelar.BackColor = Color.Plum;
        }

        //*********************************************************************//

        private void pixLimpiar_MouseLeave(object sender, EventArgs e)
        {
            pixLimpiar.BackColor = Color.Thistle;
        }

        private void pixEjecutar_MouseLeave(object sender, EventArgs e)
        {
            pixEjecutar.BackColor = Color.Thistle;
        }

        private void pixCancelar_MouseLeave(object sender, EventArgs e)
        {
            pixCancelar.BackColor = Color.Thistle;
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

        private void _0002_ABM_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;

            TimerOpen.Start();
        }
    }
}
