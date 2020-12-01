using System;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;

namespace PresentacionDatos
{
    public partial class FrmProductoAdd : Form
    {
        ManejadorInventario mi;
        EntidadProductos ep = new EntidadProductos(0, "", "", 0);

        public FrmProductoAdd()
        {
            InitializeComponent();
            mi = new ManejadorInventario();
        }

        private void llenarComboCategorias()
        {
            mi.llenarCombobox(cmbCategoria);
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

            if (mi.validarVacio(txtNombre) && mi.validarVacio(txtDescripcion) && mi.validarNumeros(fkid.ToString()))
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
        }

        public void guardarProducto(int fkid)
        {
            ep = new EntidadProductos(0, txtNombre.Text, txtDescripcion.Text, fkid);
            mi.guardarProducto(ep);
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        public void limpiarErrores()
        {
            errorProvider.SetError(txtNombre, "");
            errorProvider.SetError(txtDescripcion, "");
            errorProvider.SetError(cmbCategoria, "");
        }
    }
}
