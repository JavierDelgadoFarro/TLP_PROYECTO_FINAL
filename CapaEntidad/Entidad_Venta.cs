using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad_Venta
    {
        public int idVenta { get; set; }

        public int idCliente { get; set; }

        public int Ven_totalProducto { get; set; }

        public decimal Ven_montoTotal { get; set; }

        public string Ven_contacto { get; set; }

        public string Ven_telefono { get; set; }

        public string Ven_direccion { get; set; }

        public string idTransaccion { get; set; }

        public List<Entidad_DetalleVenta> DetalleVenta { get; set; }
    }
}
