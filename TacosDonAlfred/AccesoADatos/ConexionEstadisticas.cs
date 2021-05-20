using System.Data;
using Bases;

namespace AccesoADatos
{
    public class ConexionEstadisticas
    {
        Conectar c = new Conectar("bpg8c4dayi8gbqvpkbss-mysql.services.clever-cloud.com", "ugco6gfvngsb5zld", "eOZrzXzZp47tZ3ptfsEW", "bpg8c4dayi8gbqvpkbss");
        //Conectar c = new Conectar("localhost", "root", "", "Tacos");

        public string Comando(string q)
        {
            return c.Comando(q);
        }

        public DataSet Mostrar(string q, string tabla)
        {
            return c.Consultar(q, tabla);
        }

        public DataSet MostrarGastos(string fechaInicio, string fechaFin)
        {
            return Mostrar(string.Format("SELECT p.NombreProducto as 'Producto', SUM(c.Precio) as 'Gasto' FROM Compras c, Productos p WHERE c.FkIdProducto = p.IdProducto AND c.Fecha BETWEEN '{0}' AND '{1}' GROUP BY c.FkIdProducto;", fechaInicio, fechaFin), "compras");
        }

        public DataSet MostrarTotalGastos(string fechaInicio, string fechaFin)
        {
            return Mostrar(string.Format("SELECT SUM(Precio) AS 'Total' FROM Compras WHERE Fecha BETWEEN '{0}' AND '{1}';", fechaInicio, fechaFin), "compras");
        }

        public DataSet MostrarVentas(string fechaInicio, string fechaFin)
        {
            return Mostrar(string.Format("SELECT m.Nombre AS 'Producto', SUM(d.Cantidad) * m.Precio AS 'Total' FROM menus m, detalles_ventas d, ventas v WHERE d.FkIdPlatillo = m.IdPlatillo AND d.FkIdVenta = v.id AND v.Fecha BETWEEN '{0}' AND '{1}' GROUP BY d.FkIdPlatillo;", fechaInicio, fechaFin), "detalles_ventas");
        }

        public DataSet MostrarTotalVentas(string fechaInicio, string fechaFin)
        {
            return Mostrar(string.Format("SELECT SUM(d.Cantidad * m.Precio) AS 'Total' FROM detalles_ventas d, menus m, ventas v WHERE d.FkIdPlatillo = m.IdPlatillo AND d.FkIdVenta = v.id AND v.Fecha BETWEEN '{0}' AND '{1}' GROUP BY d.FkIdPlatillo;", fechaInicio, fechaFin), "detalles_ventas");
        }

        public DataSet MostrarAlmacen(string nombre)
        {
            return Mostrar(string.Format("SELECT p.NombreProducto AS 'Producto', a.CantidadExistente AS 'Cantidad Existente' FROM Almacen a, Productos p WHERE a.FkIdproducto = p.IdProducto GROUP BY a.FkIdproducto;"), "Almacen");
        }
    }
}
