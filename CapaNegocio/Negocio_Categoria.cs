using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Negocio_Categoria
    {
        private Datos_Categoria objCapaDato = new Datos_Categoria();

        public List<Entidad_Categoria> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Entidad_Categoria obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Cat_descripcion) || string.IsNullOrWhiteSpace(obj.Cat_descripcion))
            {
                Mensaje = "La descripcion de la categoria no puede ser vacío";
            }
            
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Entidad_Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Cat_descripcion) || string.IsNullOrWhiteSpace(obj.Cat_descripcion))
            {
                Mensaje = "La descripcion de la categoria no puede ser vacío";
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

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}