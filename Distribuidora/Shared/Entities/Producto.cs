﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public float PrecioProducto { get; set; }
        public int Stock = 0;
        // Plantear como poner foto
    }
}
