﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad_Producto
    {
        public int idProducto { get; set; }

        public string Prod_nombre { get; set; }

        public string Prod_descripcion { get; set; }

        public Entidad_Marca idMarca { get; set; }

        public Entidad_Categoria idCategoria { get; set; }

        public decimal Prod_precio { get; set; }

        public int Prod_stock { get; set; }

        public string Prod_rutaImagen { get; set; }

        public string Prod_nombreImagen { get; set; }

        public bool Prod_estado { get; set; }

    }
}

