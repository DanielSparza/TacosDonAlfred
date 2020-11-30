using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos;
using Entidades;

namespace ManejadorTacos
{
    public class ManejadorCategoria
    {
        ConexionProveedor cp = new ConexionProveedor();

        public string Guardar(EntidadCategorias categoria)
        {
            return cp.Comando(string.Format($"INSERT INTO Categorias VALUES (null, '{categoria.NombreCategoria}')"));
        }

        public string Borrar(EntidadCategorias categoria)
        {
            return cp.Comando(string.Format($"DELETE FROM Categorias WHERE IdCategoria={categoria.IdCategoria}"));
        }

        public DataSet Listado(string q, string tabla)
        {
            return cp.Mostrar(q, tabla);
        }
    }
}
