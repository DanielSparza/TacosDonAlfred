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
    public partial class FrmEmpleadosAdd : Form
    {
        int index;
        int id = 0;
        ManejadorEmpleado me = new ManejadorEmpleado();
        EntidadEmpleados enu = new EntidadEmpleados(0, "");
        EntidadUsuarios eus = new EntidadUsuarios("", "", "", "", "", "");
        public FrmEmpleadosAdd()
        {
            InitializeComponent();
            LlenarCombo();
        }
        public FrmEmpleadosAdd(EntidadEmpleados eu, EntidadUsuarios u)
        {
            InitializeComponent();
            id = eu.IdUsuario;
            txtNombre.Text = u.Nombre;
            txtApellidoP.Text = u.ApellidoPaterno;
            txtApellidoM.Text = u.ApellidoMaterno;
            txtDireccion.Text = u.Domicilio;
            txtTelefono.Text = u.Telefono;
            enu = eu;
            eus = u;
            LlenarCombo();
            index = cmbPuesto.FindString(eu.Puesto);
            cmbPuesto.SelectedIndex = index;
        }
        public void LlenarCombo()
        {
            cmbPuesto.Items.Add("Taquero");
            cmbPuesto.Items.Add("Cajero");
            cmbPuesto.Items.Add("Tortillero");
            cmbPuesto.Items.Add("Mesero");
            cmbPuesto.Items.Add("Administradors");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    string r = me.Actualizarempleado(new EntidadEmpleados(id, cmbPuesto.Text));
                    r = me.Actualizarusuario(new EntidadUsuarios(id.ToString(), txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtTelefono.Text, txtDireccion.Text));
                    Close();
                }
                else
                {
                    string r = me.Guardarusuario(new EntidadUsuarios("", txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtTelefono.Text, txtDireccion.Text));
                    r = me.Guardarempleado(new EntidadEmpleados(int.Parse(me.obtenerId(txtNombre.Text)), cmbPuesto.Text));
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de dato");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
