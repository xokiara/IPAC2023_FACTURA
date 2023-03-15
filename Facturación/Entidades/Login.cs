namespace Entidades
{
    public class Login
    {
        //Propiedades
        public string CodigoUsuario { get; set; }
        public string Contraseña { get; set; }

        //Constructor vacio (no seleccionar nada) hecho con herramienta rápida
        public Login()
        {
        }

        //Constructor con todas las propiedades
        public Login(string codigoUsuario, string contraseña)
        {
            CodigoUsuario = codigoUsuario;
            Contraseña = contraseña;
        }
    }
}
