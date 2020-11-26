using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadProveedor
    {
        public int FkIdUsuario { get; set; }
        public string RFC { get; set; }
        public EntidadProveedor(int idusuario, string rfc)
        {
            FkIdUsuario = idusuario;
            RFC = rfc;
        }
    }
}
