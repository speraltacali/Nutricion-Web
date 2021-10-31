using System.Windows.Forms;
using NA.Dominio.Base.Helpers;
using NA.IServicio.Item;
using NA.Servicio.Item;

namespace Nutrucion_App.Core
{
    public partial class _0007_Consulta_Item : _0009_Consulta_Base
    {
        private IItemServicio _itemServicio = new ItemServicio();


        public _0007_Consulta_Item()
        :base("Items")
        {
            InitializeComponent();

            ActualizarDatos(string.Empty);
        }

        //******************************** CARGA Y FORMATEO DE GRILLA ***************************

        public override void ActualizarDatos(string empty)
        {
            dgvGrilla.DataSource = _itemServicio.ObtenerPorFiltro(empty);
            FormatiarGrilla(dgvGrilla);
        }

        public override void FormatiarGrilla(DataGridView dgv)
        {
            dgvGrilla.Columns["Id"].Visible = false;
            dgvGrilla.Columns["Eliminado"].Visible = false;

            dgvGrilla.Columns["Nombre"].Visible = true;
            dgvGrilla.Columns["Nombre"].HeaderText = @"Nombre Item";
            dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public override void Buscar(string cadena)
        {
            dgvGrilla.DataSource = _itemServicio.ObtenerPorFiltro(cadena);

            base.Buscar(cadena);
        }

        //******************************** OPERACIONES ****************************************

        public override bool EjecutarAgregarEntidad()
        {
            var fItem = new _0005_ABM_Item(TipoOperacion.Agregar);
            fItem.ShowDialog();
            return fItem.RealizoOperacion;
        }

        public override bool EjecutarModificarEntidad(long? EntidadId)
        {
            var fModificar = new _0005_ABM_Item(TipoOperacion.Modificar , EntidadId);
            fModificar.ShowDialog();
            return fModificar.RealizoOperacion;
        }

        public override bool EjecutarEliminarEntidad(long? EntidadId)
        {
            var item = _itemServicio.ObtenerPorId(EntidadId.Value);

            if (MessageBox.Show("Desea Eliminar el item : " + item.Nombre , "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                var fEliminar = new _0005_ABM_Item(TipoOperacion.Eliminar, EntidadId.Value);
                fEliminar.ShowDialog();
                FormatiarGrilla(dgvGrilla);

                return fEliminar.RealizoOperacion;
            }
            else
            {
                return false;
            }
        }

    }
}
