using Bases;
using System.Data;
using Entidades;

namespace AccesoADatos
{
    public class ConexionPlatillos
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

        public string GuardarPlatillos(EntidadPlatillos ep)
        {
            return Comando(string.Format("insert into menus values(null,'{0}','{1}',{2},'{3}')",
                ep.Nombre, ep.Descripcion, ep.Precio, ep.Imagen));

        }

        public string EliminarPlatillo(EntidadPlatillos ep)
        {
            return Comando(string.Format("delete from menus where IdPlatillo = '{0}'", ep.IdPlatillo));
        }

        public string ActualizarPlatillo(EntidadPlatillos ep)
        {
            return Comando(string.Format("update menus set Nombre = '{0}', Descripcion = '{1}', Precio = {2}, Imagen = '{3}' where IdPlatillo = {4}",
                ep.Nombre, ep.Descripcion, ep.Precio, ep.Imagen, ep.IdPlatillo));
        }

        public DataSet Mostrar(string nombre)
        {
            return Mostrar(string.Format("select p.IdPlatillo as 'ID', p.Nombre as 'Platillo', p.Descripcion as 'Descripción', p.Precio, p.Imagen from menus p where p.Nombre like '%{0}%'", nombre), "menu");
        }
    }
}
