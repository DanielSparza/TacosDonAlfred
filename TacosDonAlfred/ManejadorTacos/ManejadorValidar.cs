using System;
using System.Data;
using AccesoADatos;
using Entidades;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ManejadorTacos
{
    public class ManejadorValidar
    {
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
        public bool validarVacio(string text)
        {
            bool r;

            if (text.Length == 0 || text == null)
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
