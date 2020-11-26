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
    public partial class frmProveedorAdd : Form
    {
        ManejadorProveedor mp = new ManejadorProveedor();
        EntidadProveedor ep;
        int id = 0;
        public frmProveedorAdd()
        {
            InitializeComponent();
        }
        public frmProveedorAdd(EntidadProveedor ep)
        {
            InitializeComponent();
            id = ep.FkIdUsuario;
            txtRfc.Text = ep.RFC;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                ep = new EntidadProveedor(id, txtRfc.Text);
                string r = mp.Modificar(ep);
                Close();
            }
            else
                try
                {
                    string resultado = mp.Guardar(new EntidadProveedor(int.Parse(txtId.Text), txtRfc.Text));
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error de dato");
                    txtId.Focus();
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
