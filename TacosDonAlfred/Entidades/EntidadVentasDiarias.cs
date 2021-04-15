namespace Entidades
{
    public class EntidadVentasDiarias
    {
        public string Fecha { get; set; }
        public int FkIdProducto { get; set; }
        public double CantidadVendida { get; set; }

        public EntidadVentasDiarias(string fecha, int fkidproducto, double cantidadvendida)
        {
            Fecha = fecha;
            FkIdProducto = fkidproducto;
            CantidadVendida = cantidadvendida;
        }
    }
}
