using AccesoADatos;

namespace ManejadorTacos
{
    public class ManejadorLogin
    {
        ConexionLogin cl = new ConexionLogin();

        public bool validarUsuarios(string usuario, string contraseña)
        {
            return cl.IniciarSesion(usuario, contraseña);
        }
    }
}
