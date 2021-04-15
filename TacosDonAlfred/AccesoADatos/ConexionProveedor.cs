using System.Data;
using Bases;
using Entidades;

namespace AccesoADatos
{
    public class ConexionProveedor
    {
        Conectar c = new Conectar("bpg8c4dayi8gbqvpkbss-mysql.services.clever-cloud.com", "ugco6gfvngsb5zld", "eOZrzXzZp47tZ3ptfsEW", "bpg8c4dayi8gbqvpkbss");
        //Conectar c = new Conectar("localhost", "root", "", "Tacos");
        //metodo para insertar, modificar y eliminar
        public string Comando(string q)
        {
            return c.Comando(q);
        }
        //metodo para consultar
        public DataSet Mostrar(string q, string tabla)
        {
            return c.Consultar(q, tabla);
        }
        //cambioos
        public string GuardarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("insert into Usuarios values(null,'{0}','{1}','{2}','{3}','{4}')",
                eu.Nombre, eu.ApellidoPaterno, eu.ApellidoMaterno, eu.Telefono, eu.Domicilio));
        }
        public string GuardarProveedor(EntidadProveedor ep)
        {
            //aqui agregar datos para los usuarios
            return Comando(string.Format("insert into Proveedores values({0}, '{1}')", ep.IdProveedor, ep.RFC));
        }
        public string EliminarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("delete from Usuarios where IdUsuario = {0}", eu.idUsuario));
        }
        public string EliminarProveedor(EntidadProveedor ep)
        {
            return Comando(string.Format("delete from Proveedores where FkIdUsuario = {0}", ep.IdProveedor));
        }
        public string ActualizarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("update Usuarios set Nombre = '{0}', ApellidoPaterno = '{1}', ApellidoMaterno = '{2}', Telefono = '{3}', Direccion = '{4}' where IdUsuario = '{5}'",
                eu.Nombre, eu.ApellidoPaterno, eu.ApellidoMaterno, eu.Telefono, eu.Domicilio, eu.idUsuario));
        }
        public string ActualizarProveedor(EntidadProveedor ep)
        {
            return Comando(string.Format("update Proveedores set RFC = '{0}' where FkIdUsuario = {1}", ep.RFC, ep.IdProveedor));
        }
        public DataSet Mostrar(string nombre)
        {
            return Mostrar(string.Format("select u.*, p.RFC from Usuarios u, Proveedores p where u.IdUsuario = p.FkIdUsuario and u.Nombre like '%{0}%'", nombre), "proveedores");
        }
        public DataSet MostrarId(string nombre)
        {
            return Mostrar(string.Format("select u.IdUsuario from Usuarios u where u.Nombre = '{0}'", nombre), "usuarios");
        }
    }
}
