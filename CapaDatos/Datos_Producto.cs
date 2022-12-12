using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace CapaDatos
{
    public class Datos_Producto
    {
        public List<Entidad_Producto> Listar()
        {
            List<Entidad_Producto> lista = new List<Entidad_Producto>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Entidad_Producto()
                                {
                                    idProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Prod_nombre = dr["Prod_nombre"].ToString(),
                                    Prod_descripcion = dr["Prod_descripcion"].ToString(),
                                    Prod_estado = Convert.ToBoolean(dr["Prod_estado"]),
                                    oMarca = new Entidad_Marca() { idMarca = Convert.ToInt32(dr["IdMarca"]), Mar_descripcion = dr["DesMarca"].ToString() },
                                    oCategoria = new Entidad_Categoria() { idCategoria = Convert.ToInt32(dr["idCategoria"]), Cat_descripcion = dr["DesCategoria"].ToString() },
                                    Prod_precio = Convert.ToDecimal(dr["Prod_precio"], new CultureInfo("es-PE")),
                                    Prod_stock = Convert.ToInt32(dr["Prod_stock"]),
                                    Prod_rutaImagen = dr["Prod_rutaImagen"].ToString(),
                                    Prod_nombreImagen = dr["Prod_nombreImagen"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Entidad_Producto>();
            }
            return lista;
        }


        public int Registrar(Entidad_Producto obj, out string Mensaje)
        {
            int idAutogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarProducto", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Prod_nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Prod_descripcion);
                    cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.idMarca);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("Precio", obj.Prod_precio);
                    cmd.Parameters.AddWithValue("Stock", obj.Prod_stock);
                    cmd.Parameters.AddWithValue("Activo", obj.Prod_estado);
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

        public bool Editar(Entidad_Producto obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarProducto", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.idProducto);
                    cmd.Parameters.AddWithValue("Nombre", obj.Prod_nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Prod_descripcion);
                    cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.idMarca);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("Precio", obj.Prod_precio);
                    cmd.Parameters.AddWithValue("Stock", obj.Prod_stock);
                    cmd.Parameters.AddWithValue("Activo", obj.Prod_estado);
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
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oconexion);
                    cmd.Parameters.AddWithValue("idProducto", id);
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

        public bool GuardarDatosImagen(Entidad_Producto obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = String.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarImagen", oconexion);
                    cmd.Parameters.AddWithValue("@Rutaimagen", obj.Prod_rutaImagen);
                    cmd.Parameters.AddWithValue("@Nombreimagen", obj.Prod_nombreImagen);
                    cmd.Parameters.AddWithValue("@IdProducto", obj.idProducto);

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        Mensaje = "No se pudo actualizar imagen";
                    }
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
