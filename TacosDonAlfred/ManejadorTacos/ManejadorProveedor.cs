using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using AccesoADatos;

namespace ManejadorTacos
{
    public class ManejadorProveedor
    {
        ConexionProveedor cp = new ConexionProveedor();

        public string Guardar(EntidadProveedor ep)
        {
            return cp.Comando(string.Format("insert into Proveedores values(" + " {0}, '{1}')", ep.FkIdUsuario, ep.RFC));
        }
        public string Borrar(EntidadProveedor ep)
        {
            return cp.Comando(string.Format("delete from Proveedores where FkIdUsuario = {0}", ep.FkIdUsuario));
        }
        public string Modificar(EntidadProveedor ep)
        {
            return cp.Comando(string.Format("update Proveedores set RFC = '{0}'", ep.RFC));
        }
        public DataSet Listado(string q, string tabla)
        {
            return cp.Mostrar(q, tabla);
        }
    }
}
