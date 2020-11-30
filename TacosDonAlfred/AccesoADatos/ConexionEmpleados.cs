using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Bases;
using System.Data;

namespace AccesoADatos
{
    public class ConexionEmpleados
    {
        Conectar c = new Conectar("localhost", "root", "", "Tacos");
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
            return Comando(string.Format("insert into usuarios values(null,'{0}','{1}','{2}','{3}','{4}')",
                eu.Nombre, eu.ApellidoPaterno, eu.ApellidoMaterno, eu.Telefono, eu.Domicilio));

        }
        public string GuardarEmpleado(EntidadEmpleados ee)
        {
            return Comando(string.Format("insert into empleados values('{0}','{1}')", ee.IdUsuario, ee.Puesto));
        }

        public string EliminarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("delete from usuarios where idusuario = '{0}'", eu.idUsuario));
        }
        public string EliminarEmpleado(EntidadEmpleados ee)
        {
            return Comando(string.Format("delete from empleados where fkidusuario = '{0}'", ee.IdUsuario));
        }

        public string ActualizarUsuario(EntidadUsuarios eu)
        {
            return Comando(string.Format("update usuarios set Nombre = '{0}', ApellidoPaterno = '{1}', ApellidoMaterno = '{2}', Telefono = '{3}', Direccion = '{4}' where idusuario = '{5}'",
                eu.Nombre, eu.ApellidoPaterno, eu.ApellidoMaterno, eu.Telefono, eu.Domicilio, eu.idUsuario));
        }
        public string ActualizarEmpleado(EntidadEmpleados ee)
        {
            return Comando(string.Format("update empleados set puesto = '{0}' where fkidusuario = '{1}'", ee.Puesto, ee.IdUsuario));
        }

        public DataSet Mostrar(string nombre)
        {
            return Mostrar(string.Format("select u.*, e.puesto from usuarios u, empleados e where u.idusuario = e.fkidusuario and u.nombre like '%{0}%'", nombre), "empleados");
        }
        public DataSet MostrarId(string nombre)
        {
            return Mostrar(string.Format("select u.idusuario from usuarios u where u.nombre = '{0}'", nombre), "usuarios");
        }
    }
}
