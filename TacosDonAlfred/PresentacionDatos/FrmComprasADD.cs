using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;


namespace PresentacionDatos
{
    public partial class FrmComprasADD : Form
    {

        ManejadorCompras mc = new ManejadorCompras();
        EntidadCompras entidadCompras;

        int id = 0;
        public FrmComprasADD()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtfecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Compras_Click(object sender, EventArgs e)
        {

        }

        private void cmbproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                entidadCompras = new EntidadCompras(id, txtfecha.Text, double.Parse(txtcantidad.Text), double.Parse(txtprecio.Text), mc.GetIdProveedor(cmbproveedor.Text), mc.GetIdProductos(cmbProducto.Text));
                string r = mc.ModificarCompra(entidadCompras);
                Close();

            }
            else
            {
                try
                {
                    string rs = mc.GuardaCompra(new EntidadCompras(0, txtfecha.Text, double.Parse(txtcantidad.Text), double.Parse(txtprecio.Text), mc.GetIdProveedor(cmbproveedor.Text), mc.GetIdProductos(cmbProducto.Text)));

                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error de dato");

                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void FrmComprasADD_Load(object sender, EventArgs e)
        {
            mc.LlenarProveedor(cmbproveedor, "SELECT Nombre FROM usuarios", "Productos");
            mc.LlenarProductos(cmbProducto, "SELECT  NombreProducto FROM productos", "Productos");
        }

        public FrmComprasADD(EntidadCompras entidadCompras, string proveedor, string producto)
        {
            int indexproverdor = 0;
            int indexproducto = 0;
            InitializeComponent();
            id = entidadCompras.IdCompra;
            txtfecha.Text = entidadCompras.Fecha;
            txtcantidad.Text = entidadCompras.Cantidad.ToString();
            txtprecio.Text = entidadCompras.Precio.ToString();
            indexproverdor = cmbproveedor.FindString(proveedor);
            indexproducto = cmbProducto.FindString(producto);
            cmbproveedor.SelectedIndex = indexproducto;
            cmbProducto.SelectedIndex = indexproducto;


        }

    }
}
