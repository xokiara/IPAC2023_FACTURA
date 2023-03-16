using Entidades;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class FacturaDB
    {
        string cadena = "server=localhost; user=root; database=factura; password=valladaresk28";

        public bool Guardar(Factura factura, List<DetalleFactura> detalles)
        {
            bool inserto = false;
            int idFactura = 0;
            try
            {
                StringBuilder sqlFactura = new StringBuilder();
                sqlFactura.Append(" INSERT INTO factura VALUES (@Fecha, @IdentidadCliente, @CodigoUsuario, @ISV, @Descuento, @SubTotal, @Total); ");
                sqlFactura.Append(" SELECT LAST_INSERT_ID(); ");

                //Sentencia Guardar/insertar el detalle
                StringBuilder sqlDetalle = new StringBuilder();
                sqlDetalle.Append(" INSERT INTO detallefactura VALUES (@IdFactura, @CodigoProducto, @Precio, @Cantidad, @Total); ");

                StringBuilder sqlExistencia = new StringBuilder();
                sqlExistencia.Append(" UPDATE producto SET Existencia = Existencia - @Cantidad WHERE Codigo = @Codigo; ");

            }
            catch (System.Exception)
            {


            }
            return inserto;

        }
    }
}
