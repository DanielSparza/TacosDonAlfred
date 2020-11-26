using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadCompras
    {
        public int IdCompra { get; set; }
        public string Fecha { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public int FkIdProveedor { get; set; }
        public int FkIdProducto { get; set; }
        public EntidadCompras(int idcompra, string fecha, double cantidad, double precio, int fkidproveedor, int fkidproducto)
        {
            IdCompra = idcompra;
            Fecha = fecha;
            Cantidad = cantidad;
            Precio = precio;
            FkIdProveedor = fkidproveedor;
            FkIdProducto = fkidproducto;
        }
    }
}
