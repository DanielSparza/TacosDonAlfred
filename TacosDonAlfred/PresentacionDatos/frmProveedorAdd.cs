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
        int id = 0;
        ManejadorProveedor mp = new ManejadorProveedor();
        EntidadUsuarios eu = new EntidadUsuarios("", "", "", "", "", "");
        EntidadProveedor ep = new EntidadProveedor(0, "");
        public frmProveedorAdd()
        {
            InitializeComponent();
        }
        public frmProveedorAdd(EntidadProveedor ep, EntidadUsuarios eu)
        {
            InitializeComponent();
            id = ep.IdProveedor;
            txtNombre.Text = eu.Nombre;
            txtApellidoPaterno.Text = eu.ApellidoPaterno;
            txtApellidoMaterno.Text = eu.ApellidoMaterno;
            txtDireccion.Text = eu.Domicilio;
            txtTelefono.Text = eu.Telefono;
            txtRfc.Text = ep.RFC;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    string r = mp.ActualizarProveedor(new EntidadProveedor(id, txtRfc.Text));
                    r = mp.Actualizarusuario(new EntidadUsuarios(id.ToString(), txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtTelefono.Text, txtDireccion.Text));
                    Close();
                }
                else
                {
                    string r = mp.GuardarUsuarios(new EntidadUsuarios("", txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtTelefono.Text, txtDireccion.Text));
                    r = mp.GuardarProveedor(new EntidadProveedor(int.Parse(mp.ObtenerId(txtNombre.Text)), txtRfc.Text));
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
