using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AccesoADatos;
using Entidades;

namespace ManejadorTacos
{
    public class ManejadorPlatillos
    {
        ConexionPlatillos cp = new ConexionPlatillos();

        public string GuardarPlatillo(EntidadPlatillos ep)
        {
            try
            {
                return cp.GuardarPlatillos(ep);
            }
            catch (Exception)
            {
                return "Error al Guardar";
            }
        }

        public string EliminarPlatillo(EntidadPlatillos ep)
        {
            try
            {
                return cp.EliminarPlatillo(ep);
            }
            catch (Exception)
            {
                return "Error al Eliminar";
            }
        }
        public string ActualizarPlatillo(EntidadPlatillos ep)
        {
            try
            {
                return cp.ActualizarPlatillo(ep);
            }
            catch (Exception)
            {
                return "Error al Actualizar los Datos";
            }
        }

        public DataSet Mostrar(string nombre)
        {
            return cp.Mostrar(nombre);
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

        public bool validarNumeros(string fkid)
        {
            bool r;
            Match m;
            string numeros = @"\b^[1-9][0-9]*$\b";

            m = Regex.Match(fkid, numeros);
            if (m.Success)
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
