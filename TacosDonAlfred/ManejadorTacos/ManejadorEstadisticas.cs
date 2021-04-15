using System.Collections.Generic;
using System.Data;
using System.Linq;
using AccesoADatos;
using Entidades;
using System.Windows.Forms;

namespace ManejadorTacos
{
    public class ManejadorEstadisticas
    {
        ConexionEstadisticas ce = new ConexionEstadisticas();
        EntidadEstadisticas ee = new EntidadEstadisticas();

        public DataSet MostrarGastos(string fechaInicio, string fechaFin)
        {
            return ce.MostrarGastos(fechaInicio, fechaFin);
        }

        public string obtenerTotalGastos(string fechaInicio, string fechaFin)
        {
            DataTable dt = new DataTable();
            dt = ce.MostrarTotalGastos(fechaInicio, fechaFin).Tables[0];
            DataRow r = dt.Rows[0];
            return r["Total"].ToString();
        }

        public DataSet MostrarVentas(string fechaInicio, string fechaFin)
        {
            return ce.MostrarVentas(fechaInicio, fechaFin);
        }

        public string obtenerTotalVentas(string fechaInicio, string fechaFin)
        {
            DataTable dt = new DataTable();
            dt = ce.MostrarTotalVentas(fechaInicio, fechaFin).Tables[0];
            //DataRow r = dt.Rows[0];
            //return r["Total"].ToString();
            double x = 0.0;

            object[] datos = new object[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                datos[i] = dt.Rows[i]["Total"].ToString();
            }

            for (int i = 0; i < datos.Length; i++)
            {
                x += double.Parse(datos[i].ToString());
            }
            return x.ToString();
        }

        public DataSet MostrarAlmacen(string nombre)
        {
            return ce.MostrarAlmacen(nombre);
        }
    }
}
