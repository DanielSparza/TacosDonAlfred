using System;
using System.Windows.Forms;
using ManejadorTacos;
using Entidades;

namespace PresentacionDatos
{
    public partial class frmCategoriasAdd : Form
    {
        ManejadorCategoria mc = new ManejadorCategoria();
        ManejadorValidar mv = new ManejadorValidar();

        public frmCategoriasAdd()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar(txtCategoria))
                {
                    try
                    {
                        string rs = mc.Guardar(new EntidadCategorias(0, txtCategoria.Text));
                        Close();
                    }
                    catch (Exception)
                    {
                        FrmAlertaConexion fac = new FrmAlertaConexion();
                        fac.ShowDialog();
                    }
                }
                else
                {
                    Error1.SetError(txtCategoria, "Error, No se puede dejar el campo vacío");
                    txtCategoria.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de dato");
                txtCategoria.Focus();
            }
        }

        private bool validar(TextBox txt)
        {
            bool r;

            if (txt.Text.Length > 0 && txt.Text != null)
            {
                r = true;
            }
            else
            {
                r = false;
            }

            return r;
        }
    }
}
