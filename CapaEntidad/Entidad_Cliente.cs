using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad_Cliente
    {
        public int idCliente { get; set; }

        public string Cli_nombres { get; set; }

        public string Cli_apellidos { get; set; }

        public string Cli_correo { get; set; }

        public string Cli_password { get; set; }
        public string Cli_confirmarPass { get; set; }

        public bool Cli_reestablecer { get; set; }

    }
}
