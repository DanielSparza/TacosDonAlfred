using System;
using System.Data;
using AccesoADatos;
using Entidades;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ManejadorTacos
{
    public class ManejadorInventario
    {
        ConexionInventario ci = new ConexionInventario();

        public string guardarProducto(EntidadProductos productos)
        {
            try
            {
                return ci.guardarProducto(productos);
                
            }
            catch (Exception e)
            {
                return "¡Error, no se guardaron los datos! " + e.Message;
            }
        }
        public string guardarAlmacen(string Nombre)
        {
            try
            {
                int id = ci.IDProducto(Nombre);
                return ci.guardarAlmacen(id);
            }
            catch (Exception e)
            {
                return "¡Error, no se guardaron los datos! " + e.Message;
            }
        }
        public string modificarProducto(EntidadProductos productos)
        {
            try
            {
                return ci.modificarProducto(productos);
            }
            catch (Exception e)
            {
                return "¡Error, no se modificaron los datos! " + e.Message;
            }
        }

        public string eliminarProducto(EntidadProductos productos)
        {
            try
            {
                string r = ci.eliminaralmacen(productos);
                return ci.eliminarProducto(productos);
            }
            catch (Exception e)
            {
                return "¡Error, no se eliminaron los datos! " + e.Message;
            }
        }

        public DataSet mostrarProductos(string busqueda)
        {
            return ci.mostrarProductos(busqueda);
        }

        public int obtenerId(string categoria)
        {
            return ci.obtenerIdCategoria(categoria);
        }

        public void llenarCombobox(ComboBox cmb)
        {
            cmb.DataSource = ci.mostrarCategorias().Tables[0];
            cmb.DisplayMember = "NombreCategoria";
        }

        public bool validarVacio(TextBox txt)
        {
            bool r;

            if (txt.Text.Length == 0 || txt.Text == null )
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
