using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Shared.Entities;

namespace CDatos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Ciudad> Ciudades { get; set; } = null!;
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Distribuidor> Distribuidores { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<FacturaCabecera> FacturasCabeceras { get; set; } = null!;
        public DbSet<OrdenDeCompra> OrdenesDeCompra { get; set; } = null!;
        public DbSet<OrdenDeCompraProducto> OrdenesDeCompraProducto { get; set; } = null!;
        public DbSet<OrdenDeVenta> OrdenesDeVenta { get; set; } = null!;
        public DbSet<OrdenDeVentaProducto> OrdenesDeVentaProducto { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Proveedor> Proveedores { get; set; } = null!;
        public DbSet<Sector> Sectores { get; set; } = null!;
        public DbSet<TipoDocumento> TiposDocumento { get; set; } = null!;
    }
}
