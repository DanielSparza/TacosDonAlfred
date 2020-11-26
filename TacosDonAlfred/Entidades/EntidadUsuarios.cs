using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadUsuarios
    {
        public string idUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public EntidadUsuarios(string idusuario, string nombre, string apellidopaterno, string apellidomaterno, string telefono, string domicilio)
        {
            idUsuario = idusuario;
            Nombre = nombre;
            ApellidoPaterno = apellidopaterno;
            ApellidoMaterno = apellidomaterno;
            Telefono = telefono;
            Domicilio = domicilio;
        }
    }
}
