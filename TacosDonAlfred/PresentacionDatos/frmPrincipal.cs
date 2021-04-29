using System;
using System.Drawing;
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
            v = 0;
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
            DesmarcarBotones();
            btnProveedores.Checked = true;
            if (v == 0)
            {
                v++;
                frmProveedor p = new frmProveedor();
                p.MdiParent = this;
                p.Show();            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            btnInventario.Checked = true;
            if (v == 0)
            {
                v++;
                FrmInventario f = new FrmInventario();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            btnEmpleados.Checked = true;
            if (v == 0)
            {
                v++;
                FrmEmpleados em = new FrmEmpleados();
                em.MdiParent = this;
                em.Show();
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            btnCompras.Checked = true;
            if (v == 0)
            {
                v++;
                FrmCompras em = new FrmCompras();
                em.MdiParent = this;
                em.Show();
            }
        }

        private void tsbPlatillos_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            tsbPlatillos.Checked = true;
            if (v == 0)
            {
                v++;
                FrmPlatillos fp = new FrmPlatillos();
                fp.MdiParent = this;
                fp.Show();
            }
        }

        private void tsbVentasDiarias_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            tsbVentasDiarias.Checked = true;
            if (v == 0)
            {
                v++;
                FrmVentasDiarias fvd = new FrmVentasDiarias();
                fvd.MdiParent = this;
                fvd.Show();
            }
        }

        private void tsbEstadisticas_Click(object sender, EventArgs e)
        {
            DesmarcarBotones();
            tsbEstadisticas.Checked = true;
            if (v == 0)
            {
                v++;
                FrmEstadisticas fe = new FrmEstadisticas();
                fe.MdiParent = this;
                fe.Show();
            }
        }

        private void DesmarcarBotones()
        {
            btnProveedores.Checked = false;
            btnInventario.Checked = false;
            btnEmpleados.Checked = false;
            btnCompras.Checked = false;
            tsbPlatillos.Checked = false;
            tsbVentasDiarias.Checked = false;
            tsbEstadisticas.Checked = false;
        }
    }
}
