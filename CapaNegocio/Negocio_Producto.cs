using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Negocio_Producto
    {
        private Datos_Producto objCapaDato = new Datos_Producto();

        public List<Entidad_Producto> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Registrar(Entidad_Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Prod_nombre) || string.IsNullOrWhiteSpace(obj.Prod_nombre))
            {
                Mensaje = "El Nombre del producto no puede ser vacío";
            }else if (string.IsNullOrEmpty(obj.Prod_descripcion) || string.IsNullOrWhiteSpace(obj.Prod_descripcion))
            {
                Mensaje = "La descripción del producto no puede ser vacío";
            }
            else if (obj.oMarca.idMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }
            else if (obj.oCategoria.idCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría";
            }
            else if (obj.Prod_precio == 0)
            {
                Mensaje = "El precio del producto no puede ser vacío";
            }
            else if (obj.Prod_stock == 0)
            {
                Mensaje = "El stock del producto no puede ser vacío";
            } 
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }else
            {
                return 0;
            }
        }

        public bool Editar(Entidad_Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Prod_nombre) || string.IsNullOrWhiteSpace(obj.Prod_nombre))
            {
                Mensaje = "El Nombre del producto no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Prod_descripcion) || string.IsNullOrWhiteSpace(obj.Prod_descripcion))
            {
                Mensaje = "La descripción del producto no puede ser vacío";
            }
            else if (obj.oMarca.idMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }
            else if (obj.oCategoria.idCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría";
            }
            else if (obj.Prod_precio == 0)
            {
                Mensaje = "El precio del producto no puede ser vacío";
            }
            else if (obj.Prod_stock == 0)
            {
                Mensaje = "El stock del producto no puede ser vacío";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool GuardarDatosImagen(Entidad_Producto obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}