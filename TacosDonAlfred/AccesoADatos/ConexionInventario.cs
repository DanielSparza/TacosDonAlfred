using System;
using System.Data;
using Bases;
using Entidades;
using System.Windows.Forms;

namespace AccesoADatos
{
    public class ConexionInventario
    {
        Conectar c = new Conectar("bpg8c4dayi8gbqvpkbss-mysql.services.clever-cloud.com", "ugco6gfvngsb5zld", "eOZrzXzZp47tZ3ptfsEW", "bpg8c4dayi8gbqvpkbss");
        //Conectar c = new Conectar("localhost", "root", "", "Tacos");

        public string guardarProducto(EntidadProductos productos)
        {
            return c.Comando(string.Format("insert into Productos values(NULL, '{0}', '{1}', '{2}', '{3}')",
                productos.Nombre, productos.Descripcion, productos.Medida, productos.FkIdCategoria));
        }
        public string guardarAlmacen(int ID)
        {
            return c.Comando(string.Format("insert into Almacen values({0},0)",
              ID));
        }
        public string modificarProducto(EntidadProductos productos)
        {
            return c.Comando(string.Format("update Productos set NombreProducto = '{0}', Descripcion = '{1}', FkIdCategoria = {2}, Medida = '{3}' where IdProducto = {4}",
                productos.Nombre, productos.Descripcion, productos.FkIdCategoria, productos.Medida, productos.IdProducto));
        }

        public string eliminarProducto(EntidadProductos productos)
        {
            
            return c.Comando(string.Format("delete from Productos where IdProducto = {0}", productos.IdProducto));
        }
        public string eliminaralmacen(EntidadProductos productos)
        {
            return c.Comando(string.Format("delete from Almacen where FkIdproducto = {0}", productos.IdProducto));
        }
        public DataSet mostrarProductos(string busqueda)
        {
            return c.Consultar(string.Format("select p.IdProducto as Id, p.NombreProducto as Producto, p.Descripcion as Descripción, c.NombreCategoria as Categoría, p.Medida, a.CantidadExistente from Almacen a, Productos p, Categorias c where p.IdProducto = a.FkIdproducto and p.FkIdCategoria = c.IdCategoria and p.NombreProducto like '%{0}%' order by(p.IdProducto) ASC;", busqueda), "productos");
        }

        public DataSet mostrarCategorias()
        {
            return c.Consultar("select NombreCategoria from Categorias", "categorias");
        }

        public int obtenerIdCategoria(string categoria)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = c.Consultar(string.Format("select IdCategoria from Categorias where NombreCategoria = '{0}'",
                    categoria), "Categorias").Tables[0];

                DataRow r = dt.Rows[0];
                
                return int.Parse(r["IdCategoria"].ToString());
            }
            catch (IndexOutOfRangeException)
            {
                return  0;
            }
        }

        public int IDProducto(string nombre)
        {

            DataTable dt = new DataTable();

            dt = c.Consultar(string.Format("select IdProducto from Productos where NombreProducto = '{0}'", nombre), "productos").Tables[0];

            // DataRow r = dt.Rows[0];
            return int.Parse(dt.Rows[0]["IdProducto"].ToString());
        }
    }
}
