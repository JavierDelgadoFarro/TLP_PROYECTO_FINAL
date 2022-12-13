using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad_Carrito
    {
        public int idCarrito { get; set; }

        public Entidad_Cliente idCliente { get; set; }

        public Entidad_Producto idProducto { get; set; }
        public Entidad_Producto oProducto { get; set; }

        public int Car_cantidad { get; set; }
    }
}
