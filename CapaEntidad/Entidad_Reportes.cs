using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad_Reportes
    {
        public string Ven_fechaVenta { get; set; }
        public string Cliente { get; set; }
        public string Prod_nombre { get; set; }
        public decimal Prod_precio { get; set; }
        public int DV_Cantidad { get; set; }
        public decimal DV_Total { get; set; }
        public string IdTransaccion { get; set; }
    }
}
