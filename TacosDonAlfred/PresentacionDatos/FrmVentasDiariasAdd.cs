using System;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;

namespace PresentacionDatos
{
    public partial class FrmVentasDiariasAdd : Form
    {
        EntidadVentasDiarias evd = new EntidadVentasDiarias("", 0, 0.0);
        ManejadorVentasDiarias mvd;

        public FrmVentasDiariasAdd()
        {
            InitializeComponent();
            mvd = new ManejadorVentasDiarias();
        }

        private void FrmVentasDiariasAdd_Load(object sender, EventArgs e)
        {
            llenarComboProductos();
        }

        private void llenarComboProductos()
        {
            mvd.llenarCombobox(cmbProducto);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (mvd.validarVacio(txtCantidad))
            {
                if (mvd.validarNumeros(txtCantidad.Text))
                {
                    string rs = mvd.GuardarVentasDiarias(new EntidadVentasDiarias(dtpFechaVenta.Text, int.Parse(mvd.obtenerId(cmbProducto.Text)), double.Parse(txtCantidad.Text)));
                    Close();
                }
                else
                {
                    MessageBox.Show("Solo se aceptan numeros en el campo cantidad");
                }
            }
            else
            {
                MessageBox.Show("No se puede dejar el campo vacio");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }
    }
}
