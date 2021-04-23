using System;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;

namespace PresentacionDatos
{
    public partial class FrmVentasDiarias : Form
    {
        EntidadVentasDiarias evd = new EntidadVentasDiarias("", 0, 0.0);
        ManejadorVentasDiarias mvd;
        int fila = 0;
        string r;

        public FrmVentasDiarias()
        {
            InitializeComponent();
            mvd = new ManejadorVentasDiarias();
            Actualizar();
        }

        public void Actualizar()
        {
            dtgVentasDiarias.DataSource = mvd.Mostrar(txtProducto.Text, dtpFechaFiltro.Text,dtpFechaFin.Text).Tables[0];
        }

        public void Nuevo()
        {
            FrmVentasDiariasAdd fvda = new FrmVentasDiariasAdd();
            fvda.ShowDialog();
            Actualizar();
        }

        public void GenerarDatos(int fila)
        {
            try
            {
                evd.Fecha = separarFecha(dtgVentasDiarias.Rows[fila].Cells[0].Value.ToString());
                evd.FkIdProducto = int.Parse(mvd.obtenerId(dtgVentasDiarias.Rows[fila].Cells[1].Value.ToString()));
                evd.CantidadVendida = double.Parse(dtgVentasDiarias.Rows[fila].Cells[2].Value.ToString());
            }
            catch (Exception)
            {

            }
        }

        public void Eliminar()
        {
            if (evd.FkIdProducto > 0)
            {
                DialogResult rs = MessageBox.Show("¿Estas seguro de eliminar el registro?", "!Atención!", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    r = mvd.EliminarVentasDiarias(evd);
                    Actualizar();
                    evd.FkIdProducto = 0;
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila que no este vacia");
            }
        }

        public string separarFecha(string fecha)
        {
            string f = "";
            string s;
            string[] x;
            string[] y;
            try
            {
                x = fecha.Split(' ');
                s = x[0];
                y = s.Split('/');

                f = y[2] + "-" + y[1] + "-" + y[0]; //Reacomoda la fecha al formato requerido en la bd
            }
            catch (Exception)
            {
                MessageBox.Show("Error con el formato de fecha");
            }
            return f;
        }


        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void dtgVentasDiarias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            GenerarDatos(fila);
        }

        private void PtbRegresar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }

        private void FrmVentasDiarias_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
