using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleVenta
    {
        public int idDetalleventa { get; set; }

        public int idVenta { get; set; }

        public Producto idProducto { get; set; }

        public int DV_Cantidad { get; set; }

        public decimal DV_Total { get; set; }

        public string idTransaccion { get; set; }
    }
}
