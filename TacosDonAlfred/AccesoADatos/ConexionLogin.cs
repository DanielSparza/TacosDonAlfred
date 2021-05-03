using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Bases;
using System.Data;

namespace AccesoADatos
{
    public class ConexionLogin
    {

        
        //Metodo para comparar credenciales de inicio de sesión
        public bool IniciarSesion(string usuario, string contrasena)
        {
            Conectar c = new Conectar("bpg8c4dayi8gbqvpkbss-mysql.services.clever-cloud.com", "ugco6gfvngsb5zld", "eOZrzXzZp47tZ3ptfsEW", "bpg8c4dayi8gbqvpkbss");

            bool estado;
            DataTable dt = new DataTable();
            dt = c.Consultar(string.Format("select * from Empleados where NombreUsuario = '{0}' and Contraseña = md5('{1}') and Puesto = 'Administrador'",usuario,contrasena),"Empleados").Tables[0];
           if(dt.Rows.Count > 0)
            {
                MessageBox.Show("Entro True");
                estado = true;
            }
           else
            {
                MessageBox.Show("Entro False");
                estado = false;
            }
            return estado;
        }
    }
}
