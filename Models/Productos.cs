namespace Producto{
    class Productos{
        private int idproducto;
        private string descripcion;
        private int precio;

        public int idProducto {get=>idproducto;}
        public string Descripcion {get=>descripcion;}
        public int Precio {get=>precio;}

        public Productos(int id, string descripcion, int precio){
            this.idproducto = id;
            this.descripcion = descripcion;
            this.precio = precio;
        }
    }
}