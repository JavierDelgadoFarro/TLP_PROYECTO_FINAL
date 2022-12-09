using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Negocio_Marca
    {
        private Datos_Marca objCapaDato = new Datos_Marca();

        public List<Entidad_Marca> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Entidad_Marca obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Mar_descripcion) || string.IsNullOrWhiteSpace(obj.Mar_descripcion))
            {
                Mensaje = "La descripcion de la marca no puede ser vacío";
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

        public bool Editar(Entidad_Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Mar_descripcion) || string.IsNullOrWhiteSpace(obj.Mar_descripcion))
            {
                Mensaje = "La descripcion de la marca no puede ser vacío";
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