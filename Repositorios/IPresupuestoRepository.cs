using Presupuestos;
using Productos;

public interface IPresupuestoRepository
{
    public bool CrearPresupuesto(Presupuesto presupuesto);
    public bool ModificarPresupuesto (int idPresupuesto, int idProducto, int cantidad);
    public List<Presupuesto> SelectAllPresupuestos();
    public Presupuesto DetallesPresupuesto(int id);
    public bool EliminarPresupuesto(int id);
}