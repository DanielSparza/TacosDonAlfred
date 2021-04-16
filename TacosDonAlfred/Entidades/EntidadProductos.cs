namespace Entidades
{
    public class EntidadProductos
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int FkIdCategoria { get; set; }
        public string Medida { get; set; }
        
        public EntidadProductos(int idproducto, string nombre, string descripcion, int fkidcategoria, string medida)
        {
            IdProducto = idproducto;
            Nombre = nombre;
            Descripcion = descripcion;
            FkIdCategoria = fkidcategoria;
            Medida = medida;
           
        }
    }
}
