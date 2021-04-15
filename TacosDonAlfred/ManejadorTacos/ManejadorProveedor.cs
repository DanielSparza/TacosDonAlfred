using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using AccesoADatos;

namespace ManejadorTacos
{
    public class ManejadorProveedor
    {
        ConexionProveedor cp = new ConexionProveedor();
        public string GuardarUsuarios(EntidadUsuarios eu)
        {
            try
            {
                return cp.GuardarUsuario(eu);
            }
            catch (Exception)
            {
                return "Error al guardar el usuario";
            }
        }
        public string GuardarProveedor(EntidadProveedor ep)
        {
            try
            {
                return cp.GuardarProveedor(ep);
            }
            catch (Exception)
            {
                return "Error al guardar el proveedor";
            }
        }
        public string EliminarUsuario(EntidadUsuarios eu)
        {
            try
            {
                return cp.EliminarUsuario(eu);
            }
            catch (Exception)
            {
                return "Error al Eliminar el usuario";
            }
        }
        public string EliminarProveedor(EntidadProveedor ep)
        {
            try
            {
                return cp.EliminarProveedor(ep);
            }
            catch (Exception)
            {
                return "Error al Eliminar el proveedor";
            }
        }
        public string Actualizarusuario(EntidadUsuarios eu)
        {
            try
            {
                return cp.ActualizarUsuario(eu);
            }
            catch (Exception)
            {
                return "Error al Actualizar los Datos del usuario";
            }
        }
        public string ActualizarProveedor(EntidadProveedor ep)
        {
            try
            {
                return cp.ActualizarProveedor(ep);
            }
            catch (Exception)
            {
                return "Error al Actualizar los Datos del proveedor";
            }
        }
        public DataSet Mostrar(string nombre)
        {
            return cp.Mostrar(nombre);
        }
        public string ObtenerId(string nombre)
        {

            DataTable dt = new DataTable();
            dt = cp.MostrarId(nombre).Tables[0];
            DataRow r = dt.Rows[0];
            return r["IdUsuario"].ToString();
        }
    }
}
