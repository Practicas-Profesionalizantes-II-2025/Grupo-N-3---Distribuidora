using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;
using MVC.Models.DTOs;

namespace MVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.Models.Entities.Ciudad> Ciudad { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Usuario> Usuario { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Empleado> Empleado { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Categoria> Categoria { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Cliente> Cliente { get; set; } = default!;
        public DbSet<MVC.Models.DTOs.FacturaCabeceraDTO> FacturaCabeceraDTO { get; set; } = default!;
        public DbSet<MVC.Models.Entities.OrdenDeCompra> OrdenDeCompra { get; set; } = default!;
        public DbSet<MVC.Models.Entities.OrdenDeCompraProducto> OrdenDeCompraProducto { get; set; } = default!;
        public DbSet<MVC.Models.Entities.OrdenDeVenta> OrdenDeVenta { get; set; } = default!;
        public DbSet<MVC.Models.Entities.OrdenDeVentaProducto> OrdenDeVentaProducto { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Persona> Persona { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Producto> Producto { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<MVC.Models.Entities.Sector> Sector { get; set; } = default!;
        public DbSet<MVC.Models.Entities.TipoDocumento> TipoDocumento { get; set; } = default!;
    }
}
