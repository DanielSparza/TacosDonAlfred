using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class frmProveedor : Form
    {
        ManejadorProveedor mp;
        EntidadProveedor ep = new EntidadProveedor(0, "");
        int fila = 0;
        string r = "";
        public frmProveedor()
        {
            InitializeComponent();
            mp = new ManejadorProveedor();
        }
        void Actualizar()
        {
            dtgProveedores.DataSource = mp.Listado(string.Format("" +
                "select * from Proveedores where FkIdUsuario like '%{0}%'", txtBuscar.Text), "Proveedores").Tables[0];
            dtgProveedores.AutoResizeColumns();
            dtgProveedores.Columns[0].ReadOnly = true;
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmProveedorAdd fpa = new frmProveedorAdd(ep);
            fpa.ShowDialog();
            Actualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Atencion esta seguro de borrar el proveedor?" +
                ep.RFC, "Atencion", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                r = mp.Borrar(ep);
                Actualizar();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmProveedorAdd fp = new frmProveedorAdd();
            fp.ShowDialog();
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            ep.FkIdUsuario = int.Parse(dtgProveedores.Rows[fila].Cells[0].Value.ToString());
            ep.RFC = dtgProveedores.Rows[fila].Cells[1].Value.ToString();
        }
    }
}
