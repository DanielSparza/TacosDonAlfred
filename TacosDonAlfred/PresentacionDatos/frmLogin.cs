using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionDatos
{
    public partial class frmLogin : Form
    {
        frmPrincipal p = new frmPrincipal();
        bool c = false;

        public frmLogin()
        {
            InitializeComponent();
            btnContraseña.ImageLocation = "Contraseña/ocultar.png";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            p.Close();
            Application.Exit();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin")
            {
                if (txtContraseña.Text == "123")
                {
                    p.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("\t   ¡ERROR!\n\n\tContraseña incorrecta        \n\n\t Intentar de nuevo        ");
                }
            }
            else
            {
                MessageBox.Show("\t   ¡ERROR!\n\n\tUsuario incorrecto        \n\n\tIntentar de nuevo        ");
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
