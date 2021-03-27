using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadEmpleados
    {
        public int IdUsuario { get; set; }
        public string Puesto { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public EntidadEmpleados(int idusuario, string puesto, string usuario, string contraseña)
        {
            IdUsuario = idusuario;
            Puesto = puesto;
            Usuario = usuario;
            Contraseña = contraseña;
        }
    }
}
