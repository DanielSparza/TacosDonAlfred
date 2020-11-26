using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Bases;

namespace AccesoADatos
{
    public class ConexionProveedor
    {
        Conectar c = new Conectar("localhost", "root", "", "Tacos");
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
    }
}
