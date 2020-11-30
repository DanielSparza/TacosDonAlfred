using System;
using System.Windows.Forms;
using Entidades;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class FrmEmpleados : Form
    {
        EntidadUsuarios eu = new EntidadUsuarios("", "", "", "", "", "");
        EntidadEmpleados ee = new EntidadEmpleados(0, "");
        ManejadorEmpleado me;
        int fila = 0;
        string r;
        public FrmEmpleados()
        {
            InitializeComponent();
            me = new ManejadorEmpleado();
            Actualizar();
        }
        public void Actualizar()
        {
            dgvEmpleados.DataSource = me.Mostrar(txtNombre.Text).Tables[0];
        }

        public void Nuevo()
        {
            FrmEmpleadosAdd fea = new FrmEmpleadosAdd();
            fea.ShowDialog();
            Actualizar();
        }

        public void GenerarDatos(int fila)
        {
            eu.idUsuario = dgvEmpleados.Rows[fila].Cells[0].Value.ToString();
            eu.Nombre = dgvEmpleados.Rows[fila].Cells[1].Value.ToString();
            eu.ApellidoPaterno = dgvEmpleados.Rows[fila].Cells[2].Value.ToString();
            eu.ApellidoMaterno = dgvEmpleados.Rows[fila].Cells[3].Value.ToString();
            eu.Telefono = dgvEmpleados.Rows[fila].Cells[4].Value.ToString();
            eu.Domicilio = dgvEmpleados.Rows[fila].Cells[5].Value.ToString();
            ee.Puesto = dgvEmpleados.Rows[fila].Cells[6].Value.ToString();
            ee.IdUsuario = int.Parse(dgvEmpleados.Rows[fila].Cells[0].Value.ToString());
        }

        public void ActualizarDatos()
        {
            FrmEmpleadosAdd fea = new FrmEmpleadosAdd(ee, eu);
            fea.ShowDialog();
            Actualizar();
        }

        public void Eliminar()
        {
            DialogResult rs = MessageBox.Show("!Atención Estas seguro de eliminar el usuario " + eu.Nombre + " " + eu.ApellidoPaterno + " " + eu.ApellidoMaterno, "!Atencion", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                r = me.EliminarEmpleado(ee);
                r = me.Eliminarusuario(eu);
                Actualizar();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            GenerarDatos(fila);
        }

        private void PtbRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
