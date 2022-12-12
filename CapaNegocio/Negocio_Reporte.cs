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

        public List<Entidad_Reportes> Ventas(string fechainicio, string fechafin, string Idtransaccion)
        {
            return objCapaDato.Ventas(fechainicio, fechafin, Idtransaccion);
        }


        public Entidad_DashBoard VerDashBoard()
        {
            return objCapaDato.VerDashBoard();
        }

    }
}
