using System;
using System.Data;
using AccesoADatos;
using Entidades;
using System.Windows.Forms;

namespace ManejadorTacos
{
    public class ManejadorEmpleado
    {
        ConexionEmpleados ce = new ConexionEmpleados();
        public string Guardarusuario(EntidadUsuarios eu)
        {
            try
            {
                return ce.GuardarUsuarios(eu);
            }
            catch (Exception)
            {
                return "Error al Guardar";
            }
        }
        public string Guardarempleado(EntidadEmpleados ee)
        {
            try
            {
                if (ce.verificarUsuario(ee.Usuario))
                {
                    return ce.GuardarEmpleado(ee);
                }
                else
                {
                    MessageBox.Show("El nombre de usuario ya existe, ingrese uno diferente", "Error");
                    return "";
                }
            }
            catch (Exception)
            {
                return "Error al Guardar";
            }
        }

        public string Eliminarusuario(EntidadUsuarios eu)
        {
            try
            {
                return ce.EliminarUsuario(eu);
            }
            catch (Exception)
            {
                return "Error al Eliminar";
            }
        }

        public string EliminarEmpleado(EntidadEmpleados ee)
        {
            try
            {
                return ce.EliminarEmpleado(ee);
            }
            catch (Exception)
            {
                return "Error al Eliminar";
            }
        }

        public string Actualizarusuario(EntidadUsuarios eu)
        {
            try
            {
                return ce.ActualizarUsuario(eu);
            }
            catch (Exception)
            {
                return "Error al Actualizar los Datos";
            }
        }
        public string Actualizarempleado(EntidadEmpleados ee)
        {
            try
            {
               
                return ce.ActualizarEmpleado(ee);
            }
            catch (Exception ex)
            {
               
                return "Error al Actualizar los Datos";
            }
        }
        public string ActualizarempleadoC(EntidadEmpleados ee)
        {
            try
            {
                return ce.ActualizarEmpleadoC(ee);
            }
            catch (Exception)
            {
                return "Error al Actualizar los Datos";
            }
        }
        public DataSet Mostrar(string nombre)
        {
            return ce.Mostrar(nombre);
        }

        public string obtenerId(string nombre)
        {
            DataTable dt = new DataTable();
            dt = ce.MostrarId(nombre).Tables[0];
            DataRow r = dt.Rows[0];
            return r["IdUsuario"].ToString();
        }
    }
}
