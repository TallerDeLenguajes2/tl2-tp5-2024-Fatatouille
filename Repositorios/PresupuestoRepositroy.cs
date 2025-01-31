using Microsoft.Data.Sqlite;
using Productos;
using Presupuestos;

public class PresupuestoRepository : IPresupuestoRepository
{
    private string _cadenaDeConexion;
    public PresupuestoRepository(string cadenaDeConexion)
    {
        _cadenaDeConexion = cadenaDeConexion;
    }

    public bool CrearPresupuesto(Presupuesto presupuesto)
    {
        string query = "INSERT INTO Presupuestos(NombreDestinatario, FechaCreacion) VALUES (@Nombre, @Fecha)";

        int cantidad_filas = 0;
        string fecha = DateTime.Now.ToString();

        using (SqliteConnection conexion = new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);
            command.Parameters.Add(new SqliteParameter("@Nombre", presupuesto.NombreDestinatario));
            command.Parameters.Add(new SqliteParameter("@Fecha", fecha));
            cantidad_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cantidad_filas > 0;
    }
    public bool ModificarPresupuesto (int idPresupuesto, int idProducto, int cantidad)
    {
        string query = "INSERT INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad) VALUES (@idPresupuesto, @idProducto, @cantidad)";

        int cantidad_filas = 0;

        using (SqliteConnection conexion = new SqliteConnection (_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);

            command.Parameters.Add(new SqliteParameter("@cantidad", cantidad));
            command.Parameters.Add(new SqliteParameter("@idPresupuesto", idPresupuesto));
            command.Parameters.Add(new SqliteParameter("@idProducto", idProducto));
            
            cantidad_filas = command.ExecuteNonQuery();
            conexion.Close();
        }
        return cantidad_filas > 0;
    }
    public List<Presupuesto> SelectAllPresupuestos()
    {
        string query = "SELECT * FROM Presupuestos";
        List<Presupuesto> presupuestos = new();
        using (SqliteConnection conexion = new SqliteConnection (_cadenaDeConexion))
        {
            conexion.Open();
            SqliteCommand command = new SqliteCommand(query, conexion);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var presupuesto = new Presupuesto
                    {
                        IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]),
                        NombreDestinatario = reader["NombreDestinatario"].ToString(),
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