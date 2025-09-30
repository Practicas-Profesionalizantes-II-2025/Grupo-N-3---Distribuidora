using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProveedorId { get; set; }
        [ValidateNever]
        public string NombreProveedor { get; set; }
        public int CategoriaId { get; set; }
        [ValidateNever]
        public string NombreCategoria { get; set; }
        public float PrecioProducto { get; set; }
        public int Stock { get; set; } = 0;
    }
}
