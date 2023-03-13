namespace Entidades
{
    public class Producto
    {
        //Propiedades
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }

        //Constructor vacio
        public Producto()
        {
        }

        //Constructor 
        public Producto(string codigo, string descripcion, int existencia, decimal precio, byte[] imagen)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Existencia = existencia;
            Precio = precio;
            Imagen = imagen;
        }
    }
}
