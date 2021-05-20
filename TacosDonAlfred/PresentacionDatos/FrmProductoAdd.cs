using System;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;

namespace PresentacionDatos
{
    public partial class FrmProductoAdd : Form
    {
        ManejadorInventario mi;
        EntidadProductos ep = new EntidadProductos(0, "", "", 0, "");

        public FrmProductoAdd()
        {
            InitializeComponent();
            mi = new ManejadorInventario();
        }

        private void llenarComboCategorias()
        {
            try
            {
                mi.llenarCombobox(cmbCategoria);
            }
            catch (Exception)
            {
                FrmAlertaConexion fac = new FrmAlertaConexion();
                fac.ShowDialog();
            }
        }

        private void FrmProductoAdd_Load(object sender, EventArgs e)
        {
            llenarComboCategorias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int fkid = mi.obtenerId(cmbCategoria.Text);

            if (mi.validarVacio(txtNombre) && mi.validarVacio(txtDescripcion) && mi.validarNumeros(fkid.ToString()) && mi.validarVacio(txtMedida))
            {
                guardarProducto(fkid);
                MessageBox.Show("Registro añadido correctamente");
                limpiarErrores();
            }
            else if (!mi.validarVacio(txtNombre))
            {
                errorProvider.SetError(txtNombre, "No se puede dejar el campo Nombre vacío");
            }
            else if (!mi.validarVacio(txtDescripcion))
            {
                errorProvider.SetError(txtDescripcion, "No se puede dejar el campo Descripción vacío");
            }
            else if (!mi.validarNumeros(fkid.ToString()))
            {
                errorProvider.SetError(cmbCategoria, "Seleccione una categoría");
            }
            else if (!mi.validarVacio(txtMedida))
            {
                errorProvider.SetError(txtMedida, "No se puede dejar el campo Medida vacío");
            }
        }

        public void guardarProducto(int fkid)
        {
            ep = new EntidadProductos(0, txtNombre.Text, txtDescripcion.Text, fkid, txtMedida.Text);
            mi.guardarProducto(ep);
            mi.guardarAlmacen(txtNombre.Text);
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMedida.Clear();
        }

        public void limpiarErrores()
        {
            errorProvider.SetError(txtNombre, "");
            errorProvider.SetError(txtDescripcion, "");
            errorProvider.SetError(cmbCategoria, "");
            errorProvider.SetError(txtMedida, "");
        }
    }
}
