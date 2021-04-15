namespace Entidades
{
    public class EntidadPlatillos
    {
        public int IdPlatillo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }

        public EntidadPlatillos(int idplatillo, string nombre, string descripcion, double precio, string imagen)
        {
            IdPlatillo = idplatillo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Imagen = imagen;
        }
    }
}
