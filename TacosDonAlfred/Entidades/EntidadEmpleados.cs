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
        public EntidadEmpleados(int idusuario, string puesto)
        {
            IdUsuario = idusuario;
            Puesto = puesto;
        }
    }
}
