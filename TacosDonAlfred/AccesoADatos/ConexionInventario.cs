﻿using System;
using System.Data;
using Bases;
using Entidades;

namespace AccesoADatos
{
    public class ConexionInventario
    {
        Conectar c = new Conectar("localhost", "root", "", "tacos");

        public string guardarProducto(EntidadProductos productos)
        {
            return c.Comando(string.Format("insert into productos values(NULL, '{0}', '{1}', {2})",
                productos.Nombre, productos.Descripcion, productos.FkIdCategoria));
        }

        public string modificarProducto(EntidadProductos productos)
        {
            return c.Comando(string.Format("update productos set NombreProducto = '{0}', Descripcion = '{1}', FkIdCategoria = {2} where IdProducto = {3}",
                productos.Nombre, productos.Descripcion, productos.FkIdCategoria, productos.IdProducto));
        }

        public string eliminarProducto(EntidadProductos productos)
        {
            return c.Comando(string.Format("delete from productos where IdProducto = {0}", productos.IdProducto));
        }

        public DataSet mostrarProductos(string busqueda)
        {
            return c.Consultar(string.Format("select p.IdProducto as Id, p.NombreProducto as Producto, p.Descripcion as Descripción, c.NombreCategoria as Categoría from productos p, categorias c where p.FkIdCategoria = c.IdCategoria and p.NombreProducto like '%{0}%' order by(p.IdProducto) ASC;", busqueda), "productos");
        }

        public DataSet mostrarCategorias()
        {
            return c.Consultar("select NombreCategoria from categorias", "categorias");
        }

        public int obtenerIdCategoria(string categoria)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = c.Consultar(string.Format("select IdCategoria from categorias where NombreCategoria = '{0}'",
                    categoria), "categorias").Tables[0];

                DataRow r = dt.Rows[0];
                return int.Parse(r["IdCategoria"].ToString());
            }
            catch (IndexOutOfRangeException)
            {
                return  0;
            }
        }
    }
}