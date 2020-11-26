using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadCategorias
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public EntidadCategorias(int idcategoria, string nombrecategoria)
        {
            IdCategoria = idcategoria;
            NombreCategoria = nombrecategoria;
        }
    }
}
