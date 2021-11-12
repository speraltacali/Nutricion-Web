using NA.Dominio.Base.Helpers;
using NA.IServicio.Item;
using NA.IServicio.ItemDetalle;
using NA.IServicio.Paciente;
using NA.Servicio.Item;
using NA.Servicio.ItemDetalle;
using NA.Servicio.Paciente;
using Nutrucion_App.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NA.IServicio.InformeAntropometrico;
using NA.IServicio.InformeAntropometrico.Dto;
using NA.Servicio.InformeAntropometrico;
using NA.Servicio.Usuario;
using NA.IServicio.Usuario;
using NA.IServicio.Usuario.Dto;

namespace Nutrucion_App.Core
{
    public partial class _0003_Perfil : Form
    {
        private readonly IPacienteServicio _pacienteServicio = new PacienteServicio();
        private readonly IItemDetalleServicio _detalleServicio = new ItemDetalleServicio();
        private readonly IItemServicio _itemServicio = new ItemServicio();
        private readonly IInformeAntropometricoServicio _informeAntropometrico = new InformeAntropometricoServicio();
        private readonly IUsuarioServicio _usuarioServicio = new UsuarioServicio();

        private static long PacienteId;
        private static long EntidadId;
        private long itemId;
        private long informeId;
        protected object ObjetoItem;
        protected object ObjetoInforme;

        public _0003_Perfil()
        {
            InitializeComponent();
        }

        public _0003_Perfil(long entidadId)
        {
            InitializeComponent();
            EntidadId = entidadId;
            CargarDatos(EntidadId);
        }

        //************************* CARGAR DATOS ***********************//

        public void CargarDatos(long id)
        {
            var obj = _pacienteServicio.ObtenerPorId(id);

            this.txtApellido.Text = obj.Apellido;
            this.txtNombre.Text = obj.Nombre;
            this.txtSexo.Text = obj.Sexo.ToString();
            this.txtEdad.Text = CalcularEdad(obj.Id).ToString();

            PacienteId = EntidadId;

            CargarImg(obj.Sexo);

            CargarDatosItem();

            CargarDatosInforme(PacienteId);

            dgvGrillaItem.Focus();
        }

        public void CargarDatosItem()
        {
            var detalles = _detalleServicio.ObtenerPacientePorId(PacienteId);

            foreach (var detalle in detalles)
            {
                var item = _itemServicio.ObtenerPorId(detalle.ItemId);

                detalle.ItemNombre = item.Nombre;
            }

            dgvGrillaItem.DataSource = detalles.ToList();

            FormatiarGrillaItem(dgvGrillaItem);
        }

        public void CargarDatosInforme(long id)
        {
            dgvGrilla.DataSource = _informeAntropometrico.ObtenerPorIdPaciente(id);

            FormatiarGrillaInforme(dgvGrilla);
        }

        //******************* FORMATIAR GRILLA ***********************

        public void FormatiarGrillaItem(DataGridView dgv)
        {
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["PacienteId"].Visible = false;
            dgv.Columns["ItemId"].Visible = false;

            dgv.Columns["ItemNombre"].HeaderText = @"Item";
            dgv.Columns["ItemNombre"].Width = 120;

            dgv.Columns["Descripcion"].HeaderText = @"Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void FormatiarGrillaInforme(DataGridView dgv)
        {
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["PacienteId"].Visible = false;
            dgv.Columns["Eliminado"].Visible = false;
            dgv.Columns["Observacion"].Visible = false;
            dgv.Columns["PorcentajeGrasa"].Visible = false;
            dgv.Columns["PorcentajeMusculo"].Visible = false;
            dgv.Columns["KilosGrasa"].Visible = false;
            dgv.Columns["KilosMusculo"].Visible = false;
            dgv.Columns["Numero"].Visible = false;



            dgv.Columns["Fecha"].HeaderText = @"Fecha del nuevo Informe";
            dgv.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgv.Columns["Numero"].Width = 120;
            //dgv.Columns["Numero"].HeaderText = @"Numero";
        }


        //************** METODOS DE CALCULOS ESTATICOS ************

        public int CalcularEdad(long id)
        {
            var obj = _pacienteServicio.ObtenerPorId(id);

            var edad = DateTime.Now.Year - obj.FechaNacimiento.Year;

            edad--;

            if(DateTime.Now.Month >= obj.FechaNacimiento.Month)
            {
                if(DateTime.Now.Month >= obj.FechaNacimiento.Month)
                {
                    edad++;
                }
            }


            return edad;
        }

        public void CargarImg(PacienteSexo sexo)
        {
            if(sexo == PacienteSexo.Femenino)
            {
                pixImagenSexo.BackgroundImage = Resources.Mujer02;
            }
            else
            {
                pixImagenSexo.BackgroundImage = Resources.Hombre02;
            }
        }

        //************** OPERACIONES DE INFORME ************

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea agregar un nuevo informe.", "Nuevo Informe", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                var informe = new InformeAntropometricoDto
                {
                    Eliminado = false,
                    Fecha = DateTime.Now.Date,
                    PacienteId = PacienteId
                };

                var carga = new _0021_PantallaCarga(TipoCarga.Informe);
                carga.ShowDialog();

                _informeAntropometrico.Agregar(informe);

                var agregado = new _0020_Mensaje(TipoOperacion.Agregar);
                agregado.ShowDialog();

                CargarDatosInforme(PacienteId);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (VerificarDatoSeleccionadoInforme() && informeId != null)
            {
                var detalle = new _0008_InformeAntropometrico(informeId);
                detalle.ShowDialog();
                CargarDatosInforme(PacienteId);
            }
            else
            {
                MessageBox.Show("Seleccione un Informe valido para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VerificarDatoSeleccionadoInforme())
            {
                if (MessageBox.Show("Desea quita el informe seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                   == DialogResult.Yes)
                {
                    if (EntidadId != 0)
                    {
                        _informeAntropometrico.Eliminar(EntidadId);

                        var eliminar = new _0020_Mensaje(TipoOperacion.Eliminar);
                        eliminar.ShowDialog();

                        CargarDatosInforme(PacienteId);
                    }
                    else
                    {
                        MessageBox.Show("Error al seleccionar registro , seleccione registro valido.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (VerificarDatoSeleccionadoInforme())
            {
                informeId = (long)dgvGrilla["Id", e.RowIndex].Value;
                ObjetoInforme = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
        }

        //************** LISTADO DE ITEMS DETALLE ************

        public bool VerificarDatoSeleccionadoItem()
        {
            return dgvGrillaItem.RowCount > 0;
        }

        public bool VerificarDatoSeleccionadoInforme()
        {
            return dgvGrilla.RowCount > 0;
        }


        //************************* OPERACION ITEMS ******************************//

        private void dgvGrillaItem_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (VerificarDatoSeleccionadoItem())
            {
                itemId = (long)dgvGrillaItem["Id", e.RowIndex].Value;
                ObjetoItem = dgvGrillaItem.Rows[e.RowIndex].DataBoundItem;
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            FormularioItem(TipoOperacion.Agregar);
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (VerificarDatoSeleccionadoItem())
            {
                if (MessageBox.Show("Desea quita el item seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    if (itemId != 0)
                    {
                        var obj = _detalleServicio.ObtenerPorId(itemId);
                        _detalleServicio.Eliminar(obj.Id);
                    }
                    else
                    {
                        MessageBox.Show("Error al seleccionar registro , seleccione registro valido.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    CargarDatosItem();
                }
            }
            else
            {
                MessageBox.Show("No se encuentra ningun registro para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //************************************ DOBLE CLICK *********************************

        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (VerificarDatoSeleccionadoInforme() && EntidadId != null)
            {
                FormularioInforme();
            }
            else
            {
                MessageBox.Show("Seleccione un Informe valido para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvGrillaItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(VerificarDatoSeleccionadoItem())
            {
                FormularioItem(TipoOperacion.Modificar);
            }
            else
            {
                MessageBox.Show("Seleccione un Item valido para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        //************************************ FORMULARIOS *****************************

        public void FormularioInforme()
        {
            var detalle = new _0008_InformeAntropometrico(informeId);
            detalle.ShowDialog();
            CargarDatosInforme(PacienteId);
        }

        public void FormularioItem(TipoOperacion operacion)
        {
            if(operacion == TipoOperacion.Agregar)
            {
                var fAgregar= new _0006_ABM_ItemDetalle(operacion, PacienteId);
                fAgregar.ShowDialog();
                CargarDatosItem();
            }
            else
            {
                var fModificar = new _0006_ABM_ItemDetalle(operacion, itemId);
                fModificar.ShowDialog();
                CargarDatosItem();
            }
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            var fGrafico = new _0016_Informe_Grafico(PacienteId);
            fGrafico.ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            var usuario = _usuarioServicio.ObtenerPorIdPaciente(PacienteId);

            if(usuario != null)
            {
                var fUsuario = new _0022_ABM_Usuario(TipoOperacion.Modificar , PacienteId);
                fUsuario.ShowDialog();
            }
            else
            {
                if(MessageBox.Show("El paciente seleccionado no tiene usuario , desea generarlo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    var paciente = _pacienteServicio.ObtenerPorId(PacienteId);

                    var user = _usuarioServicio.GenerarNombreUsuario(paciente.Nombre, paciente.Apellido);

                    var crear = new UsuarioDto
                    {
                        User = user,
                        Password = "Nutricion" + DateTime.Now.Year,
                        Bloqueado = false,
                        Eliminado = false,
                        PacienteId = paciente.Id
                    };

                    _usuarioServicio.Agregar(crear);

                    var agregar = new _0020_Mensaje(TipoOperacion.Agregar);
                    agregar.ShowDialog();
                }
            }

        }
    }
}
