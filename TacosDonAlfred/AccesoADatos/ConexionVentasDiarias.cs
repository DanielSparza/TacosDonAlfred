using System.Data;
using Bases;
using Entidades;

namespace AccesoADatos
{
    public class ConexionVentasDiarias
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

        public string GuardarVentasDiarias(EntidadVentasDiarias evd)
        {
            return Comando(string.Format("insert into VentasDiarias values('{0}',{1},{2})",
                evd.Fecha, evd.FkIdProducto, evd.CantidadVendida));
        }

        public string EliminarVentaDiaria(EntidadVentasDiarias evd)
        {
            return Comando(string.Format("delete from VentasDiarias where FkIdProducto = {0} and Fecha = '{1}'",
                evd.FkIdProducto, evd.Fecha));
        }

        public DataSet Mostrar2(string nombre, string fecha)
        {
            return Mostrar(string.Format("select v.Fecha, p.NombreProducto as 'Producto', v.CantidadVendida as 'Cantidad Vendida', p.Medida as 'Unidad' from VentasDiarias v, Productos p where p.IdProducto = v.FkIdProducto and p.NombreProducto like '%{0}%' and v.Fecha like '%{1}%'", nombre, fecha), "ventasdiarias");
        }

        public DataSet mostrarProductos()
        {
            return c.Consultar("select NombreProducto from Productos", "productos");
        }

        public DataSet MostrarId(string nombre)
        {
            return Mostrar(string.Format("select p.IdProducto from Productos p where p.NombreProducto = '{0}'", nombre), "productos");
        }
    }
}
