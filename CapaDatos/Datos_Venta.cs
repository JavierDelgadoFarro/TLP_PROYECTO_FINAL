using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Datos_Venta
    {
        public bool Registrar(Entidad_Venta obj,DataTable DetalleVenta ,out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarVenta", oconexion);
                    cmd.Parameters.AddWithValue("idCliente", obj.idCliente);
                    cmd.Parameters.AddWithValue("totalProducto", obj.Ven_totalProducto);
                    cmd.Parameters.AddWithValue("montoTotal", obj.Ven_montoTotal);
                    cmd.Parameters.AddWithValue("contacto", obj.Ven_contacto);
                    cmd.Parameters.AddWithValue("telefono", obj.Ven_telefono);
                    cmd.Parameters.AddWithValue("direccion", obj.Ven_direccion);
                    cmd.Parameters.AddWithValue("idTransaccion", obj.idTransaccion);
                    cmd.Parameters.AddWithValue("detalleVenta", DetalleVenta);                  
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
