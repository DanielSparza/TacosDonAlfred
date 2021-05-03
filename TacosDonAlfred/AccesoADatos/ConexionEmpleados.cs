using Entidades;
using Bases;
using System.Data;
using System.Windows.Forms;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

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
            string r = Comando(string.Format("insert into users values(null,'{0}','{1}@tacos.com',null,'{2}',null,null,null)", ee.Usuario, ee.Usuario, BCrypt.Net.BCrypt.HashPassword(ee.Contraseña,10)));
            return Comando(string.Format("insert into Empleados values('{0}','{1}', '{2}', md5('{3}'))", ee.IdUsuario, ee.Puesto, ee.Usuario, ee.Contraseña));
        }

        public string EliminarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("delete from Usuarios where IdUsuario = '{0}'", eu.idUsuario));
        }
        public string EliminarEmpleado(EntidadEmpleados ee)
        {
            string r = Comando(string.Format("delete from users where id = {0}", ee.IdUsuario));
            return Comando(string.Format("delete from Empleados where FkIdUsuario = '{0}'", ee.IdUsuario));
        }

        public string ActualizarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("update Usuarios set Nombre = '{0}', ApellidoPaterno = '{1}', ApellidoMaterno = '{2}', Telefono = '{3}', Direccion = '{4}' where IdUsuario = '{5}'",
                eu.Nombre, eu.ApellidoPaterno, eu.ApellidoMaterno, eu.Telefono, eu.Domicilio, eu.idUsuario));
        }

        public string ActualizarEmpleado(EntidadEmpleados ee)
        {
            MessageBox.Show(obtenerId(ee.Usuario).ToString());
            string r = Comando(string.Format("update users set name = '{0}', email = '{0}@tacos.com' where id = '{1}'",ee.Usuario, ee.IdUsuario));
            return Comando(string.Format("update Empleados set Puesto = '{0}', NombreUsuario = '{1}' where FkIdUsuario = '{2}'", ee.Puesto, ee.Usuario, ee.IdUsuario));
        }
        public string ActualizarEmpleadoC(EntidadEmpleados ee)
        {
            string r = Comando(string.Format("update users set name = '{0}', email = '{1}@tacos.com', password = '{2}' where id = {3}", ee.Usuario, ee.Usuario, BCrypt.Net.BCrypt.HashPassword(ee.Contraseña, 10), ee.IdUsuario));
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

        public int obtenerId(string usuario)
        {
            DataTable dt = new DataTable();
            dt = Mostrar(string.Format("select id from users where name = '{0}'", usuario), "users").Tables[0];
            DataRow r = dt.Rows[0];

            return int.Parse(r["id"].ToString());
        }
    }
}
