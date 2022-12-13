﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Datos_Carrito
    {
        public bool ExisteCarrito(int idcliente, int idproducto)
        {
            bool resultado = true;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_ExisteCarrito", oconexion);
                    cmd.Parameters.AddWithValue("@IdCliente", idcliente);
                    cmd.Parameters.AddWithValue("@IdProducto", idproducto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }

            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }

        public bool OperacionCarrito(int idcliente, int idproducto, bool sumar, out string Mensaje)
        {
            bool resultado = true;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_OperacionCarrito", oconexion);
                    cmd.Parameters.AddWithValue("@IdCliente", idcliente);
                    cmd.Parameters.AddWithValue("@IdProducto", idproducto);
                    cmd.Parameters.AddWithValue("@Sumar", sumar);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
            //
        }

        public int CantidadEnCarrito(int idcliente)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT (*) FROM Carrito WHERE Car_idCliente =@idCliente", oconexion);
                    cmd.Parameters.AddWithValue("@idCliente", idcliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
            }
            return resultado;
        }
    }
}