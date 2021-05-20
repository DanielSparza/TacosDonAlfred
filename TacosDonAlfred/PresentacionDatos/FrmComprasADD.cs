using System;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;


namespace PresentacionDatos
{
    public partial class FrmComprasADD : Form
    {
        ManejadorCompras mc = new ManejadorCompras();
        ManejadorValidar mv = new ManejadorValidar();
        EntidadCompras entidadCompras;

        int id = 0;
        public FrmComprasADD()
        {
            InitializeComponent();

        }
        
        private void btnguardar_Click(object sender, EventArgs e)
        {
            Error1.Clear();
            if (mv.validarVacio(txtcantidad) && mv.validarVacio(txtprecio))
            {
                if (id > 0)
                {
                    entidadCompras = new EntidadCompras(id, dtpFecha.Text, double.Parse(txtcantidad.Text), double.Parse(txtprecio.Text), mc.GetIdProveedor(cmbproveedor.Text), mc.GetIdProductos(cmbProducto.Text));
                    string r = mc.ModificarCompra(entidadCompras);
                    Close();
                }
                else
                {
                    try
                    {
                        string rs = mc.GuardaCompra(new EntidadCompras(0, dtpFecha.Text, double.Parse(txtcantidad.Text), double.Parse(txtprecio.Text), mc.GetIdProveedor(cmbproveedor.Text), mc.GetIdProductos(cmbProducto.Text)));

                        Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error de dato");

                    }
                }
            }
            else if (!mv.validarVacio(txtcantidad))
                Error1.SetError(txtcantidad, "Error, Cantidad no puede ir vacio");
            else if (!mv.validarVacio(txtprecio))
                Error1.SetError(txtprecio, "Error Precio no puede ir vacio");
            
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }

        private void FrmComprasADD_Load(object sender, EventArgs e)
        {
            try
            {
                mc.LlenarProveedor(cmbproveedor, "Usuarios");
                mc.LlenarProductos(cmbProducto, "SELECT  NombreProducto FROM Productos", "Productos");
            }
            catch (Exception)
            {
                FrmAlertaConexion fac = new FrmAlertaConexion();
                fac.ShowDialog();
            }
        }

        public FrmComprasADD(EntidadCompras entidadCompras, string proveedor, string producto)
        {
            int indexproverdor = 0;
            int indexproducto = 0;
            InitializeComponent();
            id = entidadCompras.IdCompra;
            dtpFecha.Text = entidadCompras.Fecha;
            txtcantidad.Text = entidadCompras.Cantidad.ToString();
            txtprecio.Text = entidadCompras.Precio.ToString();
            indexproverdor = cmbproveedor.FindString(proveedor);
            indexproducto = cmbProducto.FindString(producto);
            cmbproveedor.SelectedIndex = indexproducto;
            cmbProducto.SelectedIndex = indexproducto;
        }
    }
}
