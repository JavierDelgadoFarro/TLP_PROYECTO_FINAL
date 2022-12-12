using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace CapaDatos
{
    public class Datos_Reporte
    {

        public List<Entidad_Reportes> Ventas(string fechainicio, string fechafin, string Idtransaccion)
        {
            List<Entidad_Reportes> lista = new List<Entidad_Reportes>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.Parameters.AddWithValue("@Idtransaccion", Idtransaccion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Entidad_Reportes()
                                {
                                    Ven_fechaVenta = dr["Ven_fechaVenta"].ToString(),
                                    Cliente = dr["Cliente"].ToString(),
                                    Prod_nombre = dr["Prod_nombre"].ToString(),
                                    Prod_precio = Convert.ToDecimal(dr["Prod_precio"], new CultureInfo("es-PE")),
                                    DV_Cantidad = Convert.ToInt32(dr["DV_Cantidad"].ToString()),
                                    DV_Total = Convert.ToDecimal(dr["DV_Total"], new CultureInfo("es-PE")),
                                    IdTransaccion = dr["Idtransaccion"].ToString()
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Entidad_Reportes>();
            }
            return lista;
        }

        public Entidad_DashBoard VerDashBoard()
        {
            Entidad_DashBoard objeto = new Entidad_DashBoard();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_ReporteDashboard", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Entidad_DashBoard()
                            {
                                TotalCliente = Convert.ToInt32(dr["TotalCliente"]),
                                TotalVenta = Convert.ToInt32(dr["TotalVenta"]),
                                TotalProducto = Convert.ToInt32(dr["TotalProducto"]),
                            };
                        }
                    }
                }
            }
            catch
            {
                objeto = new Entidad_DashBoard();
            }
            return objeto;
        }
    }
}
