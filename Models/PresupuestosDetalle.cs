using Productos;

namespace PresupuestosDetalles
{
    public class PresupuestosDetalle
    {
        private Producto producto;
        private int cantidad;

        public Producto Proucto {get=>producto; set=>producto=value;}
        public int Cantidad {get=>cantidad; set=>cantidad=value;}
    }    
}