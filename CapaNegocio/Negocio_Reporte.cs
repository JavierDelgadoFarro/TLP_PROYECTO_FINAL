using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class Negocio_Reporte
    {
        private Datos_Reporte objCapaDato = new Datos_Reporte();

        public Entidad_DashBoard VerDashBoard()
        {
            return objCapaDato.VerDashBoard();
        }

    }
}
