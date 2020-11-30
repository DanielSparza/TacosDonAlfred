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
    public partial class frmCategoriasAdd : Form
    {
        ManejadorCategoria mc = new ManejadorCategoria();

        public frmCategoriasAdd()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string rs = mc.Guardar(new EntidadCategorias(0, txtCategoria.Text));
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de dato");
                txtCategoria.Focus();
            }
        }
    }
}
