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
        ManejadorValidar mv = new ManejadorValidar();
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
                Error1.Clear();
                if (mv.validarVacio(txtNombre) && mv.validarVacio(txtApellidoPaterno) && mv.validarVacio(txtApellidoMaterno) && mv.validarVacio(txtDireccion) && mv.validarNumeros(txtTelefono.Text) && mv.validarVacio(txtRfc))
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
                else if (!mv.validarVacio(txtNombre))
                    Error1.SetError(txtNombre, "Error Nombre no puede ir vacio");
                else if(!mv.validarVacio(txtApellidoPaterno))
                    Error1.SetError(txtApellidoPaterno, "Error Apellido Paterno no puede ir vacio");
                else if (!mv.validarVacio(txtApellidoMaterno))
                    Error1.SetError(txtApellidoMaterno, "Error Apellido Materno no puede ir vacio");
                else if (!mv.validarVacio(txtDireccion))
                    Error1.SetError(txtDireccion, "Error Dirección no puede ir vacio");
                else if (!mv.validarVacio(txtRfc))
                    Error1.SetError(txtRfc, "Error RFC no puede ir vacio");
                else if (!mv.validarNumeros(txtTelefono.Text))
                    Error1.SetError(txtTelefono, "Error Telefono solo acepta numeros");

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
