using System;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;

namespace PresentacionDatos
{
    public partial class FrmInventario : Form
    {
        ManejadorInventario mi;
        EntidadProductos ep = new EntidadProductos(0, "", "", 0, "");
        int fila, fkid;

        public FrmInventario()
        {
            InitializeComponent();
            mi = new ManejadorInventario();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            cargarDatos("");
        }

        public void cargarDatos(string busqueda)
        {
            dtgInventario.DataSource = mi.mostrarProductos(busqueda).Tables[0];
        }

        private void pbRegresar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmProductoAdd pa = new FrmProductoAdd();
            pa.ShowDialog();
            cargarDatos("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.Parse(ep.IdProducto.ToString()) > 0)
            {
                DialogResult rs = MessageBox.Show("¿Esta seguro de que desea borrar el producto " + ep.Nombre + " número " + ep.IdProducto + "?", "!ATENCIÓN¡", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    mi.eliminarProducto(ep);
                    cargarDatos("");
                    ep.IdProducto = 0;
                }
            }
            else
            {
                MessageBox.Show("Seleccione alguna fila para borrar");
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias c = new frmCategorias();
            c.ShowDialog();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            cargarDatos(txtBuscar.Text);
            //cargarDatos(txtBuscar.Text);
        }

        private void dtgInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                
                ep.IdProducto = int.Parse(dtgInventario.Rows[fila].Cells[0].Value.ToString());
                ep.Nombre = dtgInventario.Rows[fila].Cells[1].Value.ToString();
                ep.Descripcion = dtgInventario.Rows[fila].Cells[2].Value.ToString();
                fkid = mi.obtenerId(dtgInventario.Rows[fila].Cells[3].Value.ToString()); //obtiene la llave el IdCategoria a partir del nombre de la categoria
                ep.Medida = dtgInventario.Rows[fila].Cells[4].Value.ToString();
                ep.FkIdCategoria = fkid;
            }
            catch (FormatException)
            {
                MessageBox.Show("La fila seleccionada está vacía.");
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
    }
}
