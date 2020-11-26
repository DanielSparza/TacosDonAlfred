using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class EntidadProductos
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int FkIdCategoria { get; set; }
        public EntidadProductos(int idproducto, string nombre, string descripcion, int fkidcategoria)
        {
            IdProducto = idproducto;
            Nombre = nombre;
            Descripcion = descripcion;
            FkIdCategoria = fkidcategoria;
        }
    }
}
