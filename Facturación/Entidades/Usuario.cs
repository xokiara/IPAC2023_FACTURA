using System;

namespace Entidades
{
    public class Usuario
    {
        //Propiedades
        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EstaActivo { get; set; }

        //Constructor vacio
        public Usuario()
        {
        }

        //Constructor lleno
        public Usuario(string codigoUsuario, string nombre, string contraseña, string correo, string rol, DateTime fechaCreacion, bool estaActivo)
        {
            CodigoUsuario = codigoUsuario;
            Nombre = nombre;
            Contraseña = contraseña;
            Correo = correo;
            Rol = rol;
            FechaCreacion = fechaCreacion;
            EstaActivo = estaActivo;
        }






    }
}
