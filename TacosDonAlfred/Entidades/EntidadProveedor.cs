using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadProveedor
    {
        public int IdProveedor { get; set; }
        public string RFC { get; set; }

        public EntidadProveedor(int idProveedor, string rfc)
        {
            IdProveedor = idProveedor;
            RFC = rfc;
        }
    }
}
