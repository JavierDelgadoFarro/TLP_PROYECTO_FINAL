using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public string Usu_nombres { get; set; }

        public string Usu_apellidos { get; set; }

        public string Usu_correo { get; set; }

        public string contrasena { get; set; }

        public bool Usu_reestablecer { get; set; }

        public bool Usu_estado { get; set; }
}
}
