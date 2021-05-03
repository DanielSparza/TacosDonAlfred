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
        bool c = false;
        bool a = false;
        bool x = false;
        ManejadorEmpleado me = new ManejadorEmpleado();
        EntidadEmpleados enu = new EntidadEmpleados(0, "", "", "");
        EntidadUsuarios eus = new EntidadUsuarios("", "", "", "", "", "");
        ManejadorValidar mv = new ManejadorValidar();

        public FrmEmpleadosAdd()
        {
            InitializeComponent();
            LlenarCombo();
            btnContraseña.ImageLocation = "Contraseña/ocultar.png";
            btnEditar.Enabled = false;
            id = 0;
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
            txtUsuario.Text = eu.Usuario;
            txtContraseña.Text = "123";
            enu = eu;
            eus = u;
            LlenarCombo();
            index = cmbPuesto.FindString(eu.Puesto);
            cmbPuesto.SelectedIndex = index;
            btnContraseña.ImageLocation = "Contraseña/ocultar.png";
            txtContraseña.Enabled = false;
            btnContraseña.Enabled = false;
        }

        public void LlenarCombo()
        {
            cmbPuesto.Items.Add("Taquero");
            cmbPuesto.Items.Add("Cajero");
            cmbPuesto.Items.Add("Tortillero");
            cmbPuesto.Items.Add("Mesero");
            cmbPuesto.Items.Add("Administrador");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Error1.Clear();
            try
            {
                if (mv.validarVacio(txtNombre) && mv.validarVacio(txtApellidoP) && mv.validarVacio(txtApellidoM) && mv.validarVacio(txtDireccion) && mv.validarNumeros(txtTelefono.Text) && mv.validarVacio(txtUsuario) && mv.validarVacio(txtContraseña) && mv.validarVacio(cmbPuesto.Text))
                {
                    if (id > 0)
                    { 
                        if (x == true)
                        {
                            
                            string p = me.ActualizarempleadoC(new EntidadEmpleados(id, cmbPuesto.Text, txtUsuario.Text, txtContraseña.Text));
                        }
                        else
                        {
                            
                            string s = me.Actualizarempleado(new EntidadEmpleados(id, cmbPuesto.Text, txtUsuario.Text, txtContraseña.Text));
                        }
                        string r = me.Actualizarusuario(new EntidadUsuarios(id.ToString(), txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtTelefono.Text, txtDireccion.Text));
                        Close();

                    }
                    else
                    {
                        string r = me.Guardarusuario(new EntidadUsuarios("", txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtTelefono.Text, txtDireccion.Text));
                        r = me.Guardarempleado(new EntidadEmpleados(int.Parse(me.obtenerId(txtNombre.Text)), cmbPuesto.Text, txtUsuario.Text, txtContraseña.Text));
                        Close();
                    }
                }
                else if (!mv.validarVacio(txtNombre))
                    Error1.SetError(txtNombre, "Error Nombre no puede ir vacío");
                else if (!mv.validarVacio(txtApellidoP))
                    Error1.SetError(txtApellidoP, "Error, Apellido Paterno no puede ir vacío");
                else if (!mv.validarVacio(txtApellidoM))
                    Error1.SetError(txtApellidoM, "Error, Apellido Materno no puede ir vacío");
                else if (!mv.validarVacio(txtDireccion))
                    Error1.SetError(txtDireccion, "Error, Direccción no puede ir vacío");
                else if (!mv.validarNumeros(txtTelefono.Text))
                    Error1.SetError(txtTelefono, "Error, Telefono no puede ir vacío y solo acepta numeros");
                else if (!mv.validarVacio(txtUsuario))
                    Error1.SetError(txtUsuario, "Error, Usuario no puede ir vacío");
                else if (!mv.validarVacio(txtContraseña))
                    Error1.SetError(txtContraseña, "Error Contraseña no puede ir vacío");
                else if (!mv.validarVacio(cmbPuesto.Text))
                    Error1.SetError(cmbPuesto, "Error, Debe seleccionar un puerto de trabajo");
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

        private void btnContraseña_Click(object sender, EventArgs e)
        {
            if (c == false)
            {
                btnContraseña.ImageLocation = "Contraseña/mostrar.png";
                txtContraseña.PasswordChar = '\0';
                c = true;
            }
            else
            {
                btnContraseña.ImageLocation = "Contraseña/ocultar.png";
                txtContraseña.PasswordChar = '*';
                c = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                txtContraseña.Enabled = true;
                btnContraseña.Enabled = true;
                txtContraseña.Clear();
                a = true;
                x = true;
            }
            else
            {
                txtContraseña.Enabled = false;
                btnContraseña.Enabled = false;
                txtContraseña.PasswordChar = '*';
                btnContraseña.ImageLocation = "Contraseña/ocultar.png";
                txtContraseña.Text = "123";
                a = false;
                x = false;
            }
        }
    }
}
