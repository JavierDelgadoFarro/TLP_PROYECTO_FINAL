using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Negocio_Cliente
    {
        private Datos_Cliente objCapaDato = new Datos_Cliente();

        public List<Entidad_Cliente> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Entidad_Cliente obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Cli_nombres) || string.IsNullOrWhiteSpace(obj.Cli_nombres))
            {
                Mensaje = "El nombre del Cliente no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Cli_apellidos) || string.IsNullOrWhiteSpace(obj.Cli_apellidos))
            {
                Mensaje = "El apellido del Cliente no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Cli_correo) || string.IsNullOrWhiteSpace(obj.Cli_correo))
            {
                Mensaje = "El correo del Cliente no puede ser vacío";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                obj.Cli_password = CN_Recursos.ConvertirSha256(obj.Cli_nombres);
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Entidad_Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Cli_nombres) || string.IsNullOrWhiteSpace(obj.Cli_nombres))
            {
                Mensaje = "El nombre del Cliente no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Cli_apellidos) || string.IsNullOrWhiteSpace(obj.Cli_apellidos))
            {
                Mensaje = "El apellido del Cliente no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Cli_correo) || string.IsNullOrWhiteSpace(obj.Cli_correo))
            {
                Mensaje = "El correo del Cliente no puede ser vacío";
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
        public bool CambiarClave(int idCliente, string nuevaclave, out string Mensaje)
        {

            return objCapaDato.CambiarClave(idCliente, nuevaclave, out Mensaje);
        }

    }
}
