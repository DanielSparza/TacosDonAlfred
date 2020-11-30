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
    public partial class frmPrincipal : Form
    {
        public static int v = 0;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmLogin l = new frmLogin();
            l.Show();
            Hide();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    //ctrl.BackColor = Color.DarkOrange;
                    //ctrl.BackColor = Color.White;
                    ctrl.BackColor = Color.LightSlateGray;
                }
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (v == 0)
            {
                frmProveedor p = new frmProveedor();
                p.MdiParent = this;
                p.Show();
                v++;
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (v == 0)
            {
                FrmInventario f = new FrmInventario();
                f.MdiParent = this;
                f.Show();
                v++;
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            if (v == 0)
            {
                FrmEmpleados em = new FrmEmpleados();
                em.MdiParent = this;
                em.Show();
                v++;
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (v == 0)
            {
                
                //.MdiParent = this;
                //.Show();
                v++;
                //frmPrincipal.v = 0; poner en boton de regresar
            }
        }
    }
}
