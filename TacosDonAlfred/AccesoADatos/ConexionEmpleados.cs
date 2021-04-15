using Entidades;
using Bases;
using System.Data;
using System;

namespace AccesoADatos
{
    public class ConexionEmpleados
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

        public string GuardarUsuarios(EntidadUsuarios eu)
        {
            return Comando(string.Format("insert into Usuarios values(null,'{0}','{1}','{2}','{3}','{4}')",
                eu.Nombre, eu.ApellidoPaterno, eu.ApellidoMaterno, eu.Telefono, eu.Domicilio));

        }
        public string GuardarEmpleado(EntidadEmpleados ee)
        {
            return Comando(string.Format("insert into Empleados values('{0}','{1}', '{2}', md5('{3}'))", ee.IdUsuario, ee.Puesto, ee.Usuario, ee.Contraseña));
        }

        public string EliminarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("delete from Usuarios where IdUsuario = '{0}'", eu.idUsuario));
        }
        public string EliminarEmpleado(EntidadEmpleados ee)
        {
            return Comando(string.Format("delete from Empleados where FkIdUsuario = '{0}'", ee.IdUsuario));
        }

        public string ActualizarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("update Usuarios set Nombre = '{0}', ApellidoPaterno = '{1}', ApellidoMaterno = '{2}', Telefono = '{3}', Direccion = '{4}' where IdUsuario = '{5}'",
                eu.Nombre, eu.ApellidoPaterno, eu.ApellidoMaterno, eu.Telefono, eu.Domicilio, eu.idUsuario));
        }
        public string ActualizarEmpleado(EntidadEmpleados ee)
        {
            return Comando(string.Format("update Empleados set Puesto = '{0}', NombreUsuario = '{1}', Contraseña = md5('{2}') where FkIdUsuario = '{3}'", ee.Puesto, ee.Usuario, ee.Contraseña, ee.IdUsuario));
        }

        public DataSet Mostrar(string nombre)
        {
            return Mostrar(string.Format("select u.*, e.Puesto, e.NombreUsuario from Usuarios u, Empleados e where u.IdUsuario = e.FkIdUsuario and u.Nombre like '%{0}%'", nombre), "empleados");
        }
        public DataSet MostrarId(string nombre)
        {
            return Mostrar(string.Format("select u.IdUsuario from Usuarios u where u.Nombre = '{0}'", nombre), "usuarios");
        }
    }
}
