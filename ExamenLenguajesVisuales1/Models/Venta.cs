using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenLenguajesVisuales1.Models
{

    public class Venta
    {
        public int VentaId { get; set; }
        public int VendedorId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Vendedor Vendedor { get; set; }
    }

}
