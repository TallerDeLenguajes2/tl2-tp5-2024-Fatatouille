using Microsoft.Data.Sqlite;
using Productos;

public class ProductoRepository : IProductoRepository
{
    private string _cadenaDeConexion;
    public ProductoRepository(string cadenaDeConexion)
    {
        _cadenaDeConexion = cadenaDeConexion;
    }

    public bool CrearProducto(Producto producto)
    {
        string query = "INSERT INTO Productos(Descripcion, Precio) VALUES (@Descripcion, @Precio)";

        int cantidad_filas = 0;

        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            cantidad_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cantidad_filas > 0;
    }
    public bool ModificarProducto (int id, Producto producto)
    {
        string query = "UPDATE Productos SET (Descripcion=@Descripcion, Precio=@Precio) WHERE idProducto = @Id";

        int cantidad_filas = 0;

        using (SqliteConnection conexion = new SqliteConnection (_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@Descipcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            command.Parameters.Add(new SqliteParameter("@Id", id));
            cantidad_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cantidad_filas > 0;
    }
    public List<Producto> SelectAllProductos()
    {
        string query = "SELECT * FROM Productos";
        List<Producto> productos = new();
        using (SqliteConnection conexion = new SqliteConnection (_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var producto = new Producto
                    {
                        IdProducto = Convert.ToInt32(reader["idProducto"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToInt32(reader["Precio"])
                    };
                    productos.Add(producto);
                }
            }
            conexion.Close();
        }
        return productos;
    }
    public Producto DetallesProducto(int id)
    {
        string query = "SELECT * FROM Productos WHERE idProducto=@id";
        Producto producto = null;

        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@id", id));

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    producto = new Producto
                    {
                        IdProducto= Convert.ToInt32(reader["idProducto"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToInt32(reader["Precio"])
                    };
                }
            }
            conexion.Close();
        }

        return producto;
    }
    public bool EliminarProducto(int id)
    {
        string query = "DELETE FROM Productos WHERE idProducto=@IdProducto";
        int cantidad_filas = 0;
        
        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion); 
            command.Parameters.Add(new SqliteParameter("@IdProducto", id));
            cantidad_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cantidad_filas >0;
    }
}