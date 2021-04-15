using System;
using AccesoADatos;
using Entidades;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ManejadorTacos
{
    public class ManejadorVentasDiarias
    {
        ConexionVentasDiarias cvd = new ConexionVentasDiarias();

        public string GuardarVentasDiarias(EntidadVentasDiarias evd)
        {
            try
            {
                return cvd.GuardarVentasDiarias(evd);
            }
            catch (Exception)
            {
                return "Error al Guardar";
            }
        }

        public string EliminarVentasDiarias(EntidadVentasDiarias evd)
        {
            try
            {
                return cvd.EliminarVentaDiaria(evd);
            }
            catch (Exception)
            {
                return "Error al Eliminar";
            }
        }

        public DataSet Mostrar(string nombre, string fecha)
        {
            return cvd.Mostrar2(nombre, fecha); 
        }

        public string obtenerId(string nombre)
        {

            DataTable dt = new DataTable();
            dt = cvd.MostrarId(nombre).Tables[0];
            DataRow r = dt.Rows[0];
            return r["IdProducto"].ToString();
        }

        public void llenarCombobox(ComboBox cmb)
        {
            cmb.DataSource = cvd.mostrarProductos().Tables[0];
            cmb.DisplayMember = "NombreProducto";
        }

        public bool validarVacio(TextBox txt)
        {
            bool r;

            if (txt.Text.Length == 0 || txt.Text == null)
            {
                r = false;
            }
            else
            {
                r = true;
            }
            return r;
        }

        public bool validarNumeros(string texto)
        {
            bool r;
            Match m, n;
            string numeros = @"\b^[1-9][0-9]*$\b";
            string decimales = @"\b^[0-9][0-9]*.[0-9][0-9]*$\b";

            m = Regex.Match(texto, numeros);
            n = Regex.Match(texto, decimales);
            if (m.Success)
            {
                r = true;
            }
            else if (n.Success)
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
