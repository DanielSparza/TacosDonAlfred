using System;
using System.Windows.Forms;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class frmLogin : Form
    {
        frmPrincipal p = new frmPrincipal();
        ManejadorLogin ml;
        bool c = false;

        public frmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
            btnContraseña.ImageLocation = "Contraseña/ocultar.png";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            p.Close();
            Application.Exit();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ml.validarUsuarios(txtUsuario.Text, txtContraseña.Text))
            {
                p.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("El nombre de usuario o la contraseña no coinciden con los de un Administrador, revise sus datos y permisos.", "¡ERROR DE INICIO DE SESIÓN!");
            }
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
