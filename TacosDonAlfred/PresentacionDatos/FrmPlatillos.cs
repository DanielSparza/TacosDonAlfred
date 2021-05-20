using System;
using System.Windows.Forms;
using Entidades;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class FrmPlatillos : Form
    {
        EntidadPlatillos ep = new EntidadPlatillos(0, "", "", 0.0, "");
        ManejadorPlatillos mp;
        int fila = 0;
        string r;

        public FrmPlatillos()
        {
            InitializeComponent();
            mp = new ManejadorPlatillos();
            Actualizar();
        }

        public void Actualizar()
        {
            try
            {
                dtgPlatillos.DataSource = mp.Mostrar(txtBuscar.Text).Tables[0];
            }
            catch (Exception)
            {
                FrmAlertaConexion fac = new FrmAlertaConexion();
                fac.ShowDialog();
            }
        }

        public void Nuevo()
        {
            FrmPlatillosAdd fpa = new FrmPlatillosAdd();
            fpa.ShowDialog();
            Actualizar();
        }

        public void GenerarDatos(int fila)
        {
            try
            {
                ep.IdPlatillo = int.Parse(dtgPlatillos.Rows[fila].Cells[0].Value.ToString());
                ep.Nombre = dtgPlatillos.Rows[fila].Cells[1].Value.ToString();
                ep.Descripcion = dtgPlatillos.Rows[fila].Cells[2].Value.ToString();
                ep.Precio = double.Parse(dtgPlatillos.Rows[fila].Cells[3].Value.ToString());
                ep.Imagen = dtgPlatillos.Rows[fila].Cells[4].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        public void ActualizarDatos()
        {
            FrmPlatillosAdd fpa = new FrmPlatillosAdd(ep);
            fpa.ShowDialog();
            Actualizar();
        }

        public void Eliminar()
        {
            if (ep.IdPlatillo > 0)
            {
                DialogResult rs = MessageBox.Show("¿Estas seguro de eliminar el platillo " + ep.Nombre+"?", "!Atencion!", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    r = mp.EliminarPlatillo(ep);
                    ep.IdPlatillo = 0;
                    fila = 0;
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila que no este vacia");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ep.IdPlatillo > 0)
            {
                ActualizarDatos();
            }
            else
            {
                MessageBox.Show("Selecciona una fila que no este vacia");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void dtgPlatillos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            GenerarDatos(fila);
        }

        private void PtbRegresar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }
    }
}
