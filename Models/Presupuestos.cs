using PresupuestosDetalles;

namespace Presupuestos
{
    public class Presupuesto
    {
        private int idPresupuesto;
        private string nombreDestinatario;
        private List<PresupuestosDetalle> detalle;
        
        public int IdPresupuesto {get=>idPresupuesto; set=>idPresupuesto=value;}
        public string NombreDestinatario {get=>nombreDestinatario; set=>nombreDestinatario=value;}
        public List<PresupuestosDetalle> Detalle {get=>detalle; set=>detalle=value;}

        public Presupuesto()
        {
            this.detalle = new List<PresupuestosDetalle>();
        }


    }
}