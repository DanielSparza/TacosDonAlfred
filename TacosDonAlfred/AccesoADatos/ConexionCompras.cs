using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Bases;
using Entidades;

namespace AccesoADatos
{
  public  class ConexionCompras
    {
        Conectar c = new Conectar("bpg8c4dayi8gbqvpkbss-mysql.services.clever-cloud.com", "ugco6gfvngsb5zld", "eOZrzXzZp47tZ3ptfsEW", "bpg8c4dayi8gbqvpkbss");
        //metodo para insertar, modificar y eliminar
        public string Comando(string q)
        {
            return c.Comando(q);
        }
        //metodo para consultar
        public DataSet Mostrar(string q, string tabla)
        {
            return c.Consultar(q, tabla);
        }
        public string Guardar(EntidadCompras entidadCompras)
        {
            return Comando(string.Format("insert into Compras values(" + "null, '{0}','{1}','{2}','{3}','{4}')", entidadCompras.Fecha, entidadCompras.Cantidad, entidadCompras.Precio, entidadCompras.FkIdProveedor, entidadCompras.FkIdProducto));
        }
        public string Borrar(EntidadCompras entidadCompras)
        {
            return Comando(string.Format("delete from Compras where IdCompra={0}", entidadCompras.IdCompra));
        }
        public string Modificar(EntidadCompras entidadCompras)
        {
            return Comando(string.Format("update Compras set Fecha='{0}', Cantidad='{1}', Precio='{2}',FkIdProveedor='{3}',FkIdProducto='{4}'" + " where IdCompra='{5}'", entidadCompras.Fecha, entidadCompras.Cantidad, entidadCompras.Precio, entidadCompras.FkIdProveedor, entidadCompras.FkIdProducto, entidadCompras.IdCompra));
        }
        public DataSet Listado(string tabla)
        {
            return Mostrar(string.Format("select u.Nombre from Usuarios u, Proveedores p where u.IdUsuario = p.FkIdUsuario"), tabla);
        }
        public DataSet Mostrar(string nombre)
        {
            return Mostrar(string.Format("select c.IdCompra,c.Fecha,c.Cantidad,c.Precio,p.NombreProducto, u.Nombre from Compras c, Productos p, Usuarios u,Proveedores pr where c.FkIdProducto=p.IdProducto AND c.FkIdProveedor=pr.FkIdUsuario AND pr.FkIdUsuario=u.IdUsuario and  Fecha  like '%{0}%'", nombre), "Compras");
        }

    }
}

