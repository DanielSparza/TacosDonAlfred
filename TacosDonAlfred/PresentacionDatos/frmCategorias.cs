using System;
using System.Windows.Forms;
using Entidades;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class frmCategorias : Form
    {
        ManejadorCategoria mc;
        EntidadCategorias ec = new EntidadCategorias(0, "");
        int fila = 0;
        string r = "";

        public frmCategorias()
        {
            InitializeComponent();
            mc = new ManejadorCategoria();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriasAdd ca = new frmCategoriasAdd();
            ca.ShowDialog();
            Actualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show($"¿Estas seguro de borrar los datos?\n\nCategoria: {ec.NombreCategoria}",
                "¡ATENCION!", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                r = mc.Borrar(ec);
                Actualizar();
            }
        }

        void Actualizar()
        {
            try
            {
                dgvCategorias.DataSource = mc.Listado(string.Format(
               $"SELECT * FROM Categorias"), "Categorias").Tables[0];
                dgvCategorias.AutoResizeColumns();
                dgvCategorias.Columns[0].ReadOnly = true;
            }
            catch (Exception)
            {
                FrmAlertaConexion fac = new FrmAlertaConexion();
                fac.ShowDialog();
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                ec.IdCategoria = int.Parse(dgvCategorias.Rows[fila].Cells[0].Value.ToString());
                ec.NombreCategoria = dgvCategorias.Rows[fila].Cells[1].Value.ToString();
            }
            catch (Exception)
            {

            }

        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
