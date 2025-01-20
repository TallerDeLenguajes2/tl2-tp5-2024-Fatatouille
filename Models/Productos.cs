namespace Productos{
    public class Producto{
        private int idproducto;
        private string descripcion;
        private int precio;

        public int IdProducto {get=>idproducto; set=>idproducto=value;}
        public string Descripcion {get=>descripcion; set=>descripcion=value; }
        public int Precio {get=>precio; set=>precio=value;}

        public Producto(){}
    }
}