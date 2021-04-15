using System;
using System.Windows.Forms;
using Entidades;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class FrmPlatillosAdd : Form
    {
        EntidadPlatillos epd = new EntidadPlatillos(0, "", "", 0.0, "");
        ManejadorPlatillos mp = new ManejadorPlatillos();
        int id = 0;

        public FrmPlatillosAdd()
        {
            InitializeComponent();
        }

        public FrmPlatillosAdd(EntidadPlatillos ep)
        {
            InitializeComponent();

            id = ep.IdPlatillo;
            txtNombre.Text = ep.Nombre;
            txtDescripción.Text = ep.Descripcion;
            txtPrecio.Text = ep.Precio.ToString();
            txtURLImagen.Text = ep.Imagen;
            epd = ep;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (comprobar())
            {
                try
                {
                    if (id > 0)
                    {
                        string r = mp.ActualizarPlatillo(new EntidadPlatillos(id, txtNombre.Text, txtDescripción.Text, double.Parse(txtPrecio.Text), txtURLImagen.Text));
                        Close();
                    }
                    else
                    {
                        string r = mp.GuardarPlatillo(new EntidadPlatillos(0, txtNombre.Text, txtDescripción.Text, double.Parse(txtPrecio.Text), txtURLImagen.Text));
                        Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error de dato");
                }
            }
            else
            {
                MessageBox.Show("Error, no se pudieron guardar los datos");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool comprobar()
        {
            bool r;

            if (mp.validarVacio(txtNombre))
            {
                if (mp.validarVacio(txtDescripción))
                {
                    if (mp.validarVacio(txtPrecio))
                    {
                        if (mp.validarNumeros(txtPrecio.Text))
                        {
                            if (mp.validarVacio(txtURLImagen))
                            {
                                r = true;
                            }
                            else
                            {
                                ep1.SetError(txtURLImagen, "No se puede dejar el campo vacío");
                                r = false;
                            }
                        }
                        else
                        {
                            ep1.SetError(txtPrecio, "Solo se permiten numeros en este campo");
                            r = false;
                        }
                    }
                    else
                    {
                        ep1.SetError(txtPrecio, "No se puede dejar el campo vacío");
                        r = false;
                    }
                }
                else
                {
                    ep1.SetError(txtDescripción, "No se puede dejar el campo vacío");
                    r = false;
                }
            }
            else
            {
                ep1.SetError(txtNombre, "No se puede dejar el campo vacío");
                r = false;
            }
            return r;
        }
    }
}
