using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AccesoADatos
{
    public class ConexionLogin
    {
        MySqlConnection con;

        public ConexionLogin()
        {
            con = new MySqlConnection("server=bpg8c4dayi8gbqvpkbss-mysql.services.clever-cloud.com; user=ugco6gfvngsb5zld; password=eOZrzXzZp47tZ3ptfsEW; database=bpg8c4dayi8gbqvpkbss");
            //con = new MySqlConnection("server=localhost; user=root; password=; database=Tacos");
        }

        //Metodo para comparar credenciales de inicio de sesión
        public bool IniciarSesion(string usuario, string contrasena)
        {
            bool estado;

            try
            {
                con.Open();

                MySqlCommand c = new MySqlCommand();
                MySqlConnection conectar = new MySqlConnection();
                c.Connection = con;
                c.CommandText = ("select * from empleados where NombreUsuario = '" + usuario + "' and Contrasena = md5('" + contrasena + "') and Puesto = 'Administrador'");

                MySqlDataReader leer = c.ExecuteReader();

                if (leer.Read())
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }
                con.Close();
            }
            catch (Exception)
            {
                estado = false;
            }
            return estado;
        }
    }
}
