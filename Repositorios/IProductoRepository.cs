using Productos;

public interface IProductoRepository
{
    public bool CrearProducto(Producto producto);
    public bool ModificarProducto (int id, Producto producto);
    public List<Producto> SelectAllProductos();
    public Producto DetallesProducto(int id);
    public bool EliminarProducto(int id);
}