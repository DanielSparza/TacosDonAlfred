using System;
using System.Windows.Forms;
using Entidades;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class frmProveedor : Form
    {
        ManejadorProveedor mp;
        EntidadUsuarios eu = new EntidadUsuarios("", "", "", "", "", "");
        EntidadProveedor ep = new EntidadProveedor(0, "");
        int fila = 0;
        string r = "";

        public frmProveedor()
        {
            InitializeComponent();
            mp = new ManejadorProveedor();
            Actualizar();
        }

        void Actualizar()
        {
            try
            {
                dtgProveedores.DataSource = mp.Mostrar(txtNombre.Text).Tables[0];
            }
            catch (Exception)
            {
                FrmAlertaConexion fac = new FrmAlertaConexion();
                fac.ShowDialog();
            }
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                ep.IdProveedor = int.Parse(dtgProveedores.Rows[fila].Cells[0].Value.ToString());
                ep.RFC = dtgProveedores.Rows[fila].Cells[1].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void PtbRegresar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                eu.idUsuario = dtgProveedores.Rows[fila].Cells[0].Value.ToString();
                eu.Nombre = dtgProveedores.Rows[fila].Cells[1].Value.ToString();
                eu.ApellidoPaterno = dtgProveedores.Rows[fila].Cells[2].Value.ToString();
                eu.ApellidoMaterno = dtgProveedores.Rows[fila].Cells[3].Value.ToString();
                eu.Telefono = dtgProveedores.Rows[fila].Cells[4].Value.ToString();
                eu.Domicilio = dtgProveedores.Rows[fila].Cells[5].Value.ToString();
                ep.RFC = dtgProveedores.Rows[fila].Cells[6].Value.ToString();
                ep.IdProveedor = int.Parse(dtgProveedores.Rows[fila].Cells[0].Value.ToString());
            }
            catch (Exception)
            {

            }
        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            frmProveedorAdd fp = new frmProveedorAdd();
            fp.ShowDialog();
            Actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ep.IdProveedor > 0)
            {
                frmProveedorAdd fpa = new frmProveedorAdd(ep, eu);
                fpa.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Selecciona una fila que no este vacia");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (ep.IdProveedor > 0)
            {
                DialogResult rs = MessageBox.Show("¿Esta seguro de borrar el Proveedor " + eu.Nombre + " " + eu.ApellidoPaterno + "?", "!Atención!", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    r = mp.EliminarProveedor(ep);
                    r = mp.EliminarUsuario(eu);
                    ep.IdProveedor = 0;
                    fila = 0;
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila que no este vacia");
            }
        }
    }
}
