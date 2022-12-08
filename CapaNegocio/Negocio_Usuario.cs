using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class Negocio_Usuario
    {
        private Datos_Usuario objCapaDato = new Datos_Usuario();

        public List<Entidad_Usuario> Listar() {

            return objCapaDato.Listar();
        }

        public int Registrar(Entidad_Usuario obj, out string Mensaje){

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Usu_nombres) || string.IsNullOrWhiteSpace(obj.Usu_nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacío";
            }
            else if(string.IsNullOrEmpty(obj.Usu_apellidos) || string.IsNullOrWhiteSpace(obj.Usu_apellidos))
            {
                Mensaje = "El apellido del usuario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Usu_correo) || string.IsNullOrWhiteSpace(obj.Usu_correo))
            {
                Mensaje = "El correo del usuario no puede ser vacío";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                string clave = CN_Recursos.GenerarClave();
                obj.Usu_password = CN_Recursos.ConvertirSha256(clave);

                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }

            
        }

        public bool Editar(Entidad_Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Usu_nombres) || string.IsNullOrWhiteSpace(obj.Usu_nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Usu_apellidos) || string.IsNullOrWhiteSpace(obj.Usu_apellidos))
            {
                Mensaje = "El apellido del usuario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Usu_correo) || string.IsNullOrWhiteSpace(obj.Usu_correo))
            {
                Mensaje = "El correo del usuario no puede ser vacío";
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
