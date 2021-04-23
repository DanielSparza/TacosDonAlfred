using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos;
using Entidades;
using System.Data;
using System.Windows.Forms;

namespace ManejadorTacos
{
   public class ManejadorCompras
    {
        ConexionCompras mc = new ConexionCompras();


        public string GuardaCompra(EntidadCompras entidadCompras)
        {
            try
            {
                return mc.Guardar(entidadCompras);
            }
            catch (Exception)
            {
                return "Error al Guardar";
            }
        }

        public string ModificarCompra(EntidadCompras entidadCompras)
        {
            try
            {
                return mc.Modificar(entidadCompras);
            }
            catch (Exception)
            {
                return "Error al Guardar";
            }
        }
        public string EliminarCompra(EntidadCompras entidadCompras)
        {
            try
            {
                return mc.Borrar(entidadCompras);
            }
            catch (Exception)
            {
                return "Error al Guardar";
            }
        }



        public void LlenarProveedor(ComboBox combo, string tabla)
        {
            combo.DataSource = mc.Listado(tabla).Tables[0];
            combo.DisplayMember = "Nombre";
        }

        public int GetIdProveedor(string eu)
        {
            DataTable dt = new DataTable();
            dt = mc.Mostrar($"SELECT IdUsuario FROM Usuarios WHERE Nombre='{eu}'", "Usuarios").Tables[0];
            DataRow r = dt.Rows[0];

            return int.Parse(r["IdUsuario"].ToString());
        }


        public void LlenarProductos(ComboBox combo, string q, string tabla)
        {
            combo.DataSource = mc.Mostrar(q, tabla).Tables[0];
            combo.DisplayMember = "NombreProducto";
        }

        public int GetIdProductos(string pr)
        {
            DataTable dt = new DataTable();
            dt = mc.Mostrar($"SELECT IdProducto FROM Productos WHERE NombreProducto='{pr}'", "Productos").Tables[0];
            DataRow r = dt.Rows[0];

            return int.Parse(r["IdProducto"].ToString());
        }

        public DataSet Mostrar(string producto, string fi, string ff)
        {
            return mc.Mostrar(producto,fi,ff);
        }
    }
}
