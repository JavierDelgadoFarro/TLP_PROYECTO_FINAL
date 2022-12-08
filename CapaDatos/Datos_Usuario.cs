using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CapaDatos
{
    public class Datos_Usuario
    {
        

        public List<Entidad_Usuario> Listar()
        {
            List<Entidad_Usuario> lista = new List<Entidad_Usuario>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarUsuario", oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Entidad_Usuario()
                                {
                                    idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                    Usu_nombres = dr["Usu_nombres"].ToString(),
                                    Usu_apellidos = dr["Usu_apellidos"].ToString(),
                                    Usu_correo = dr["Usu_correo"].ToString(),
                                    Usu_password = dr["Usu_password"].ToString(),
                                    Usu_reestablecer = Convert.ToBoolean(dr["Usu_reestablecer"]),
                                    Usu_estado = Convert.ToBoolean(dr["Usu_estado"])
                                }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Entidad_Usuario>();
            }
            return lista;
        }

        public int Registrar(Entidad_Usuario obj, out string Mensaje)
        {
            int idAutogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("@nombres", obj.Usu_nombres);
                    cmd.Parameters.AddWithValue("@apellidos", obj.Usu_apellidos);
                    cmd.Parameters.AddWithValue("@correo", obj.Usu_correo);
                    cmd.Parameters.AddWithValue("@clave", obj.Usu_password);
                    cmd.Parameters.AddWithValue("@estado", obj.Usu_estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idAutogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return idAutogenerado;
        }


        public bool Editar(Entidad_Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("idUsuario", obj.idUsuario);
                    cmd.Parameters.AddWithValue("@nombres", obj.Usu_nombres);
                    cmd.Parameters.AddWithValue("@apellidos", obj.Usu_apellidos);
                    cmd.Parameters.AddWithValue("@correo", obj.Usu_correo);
                    cmd.Parameters.AddWithValue("@estado", obj.Usu_estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
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
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", id);
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
        }
    }
}
