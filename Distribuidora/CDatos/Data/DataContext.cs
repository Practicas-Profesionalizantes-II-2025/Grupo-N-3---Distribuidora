using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace CDatos.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Distribuidores> Distribuidores { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<OrdenDeCompra> OrdenesDeCompra { get; set; }
        public DbSet<OrdenDeCompraProducto> OrdenesDeCompra_Producto { get; set; }
        public DbSet<OrdenDeVenta> OrdenesDeVenta { get; set; }
        public DbSet<OrdenDeVentaProducto> OrdenesDeVenta_Producto { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Sectores> Sectores { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Persona>()
            .HasOne(p => p.Cliente)
            .WithOne(c => c.Persona)
            .HasForeignKey<Clientes>(c => c.PersonaId);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Empleado)
                .WithOne(e => e.Persona)
                .HasForeignKey<Empleados>(e => e.PersonaId);

            // Persona pertenece a una Ciudad
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Ciudad)
                .WithMany(c => c.Personas)
                .HasForeignKey(p => p.CiudadId);

            // Empleado pertenece a un Sector
            modelBuilder.Entity<Empleados>()
                .HasOne(e => e.Sector)
                .WithMany(s => s.Empleados)
                .HasForeignKey(e => e.SectorId);

            // OrdenDeVenta con Factura 1:1
            modelBuilder.Entity<OrdenDeVenta>()
                .HasOne(ov => ov.Factura)
                .WithOne(f => f.OrdenDeVenta)
                .HasForeignKey<OrdenDeVenta>(ov => ov.FacturaId);

            // OrdenDeCompra con Factura 1:1
            modelBuilder.Entity<OrdenDeCompra>()
                .HasOne(oc => oc.Factura)
                .WithOne(f => f.OrdenDeCompra)
                .HasForeignKey<OrdenDeCompra>(oc => oc.FacturaId);

            // OrdenDeCompra Producto (n:n explícito)
            modelBuilder.Entity<OrdenDeCompraProducto>()
                .HasKey(x => x.IdOrdenCompraProd);

            modelBuilder.Entity<OrdenDeCompraProducto>()
                .HasOne(x => x.Producto)
                .WithMany()
                .HasForeignKey(x => x.IdProducto);

            modelBuilder.Entity<OrdenDeCompraProducto>()
                .HasOne(x => x.OrdenDeCompra)
                .WithMany()
                .HasForeignKey(x => x.IdOrdenDeCompra);

            // OrdenDeVenta Producto (n:n explícito)
            modelBuilder.Entity<OrdenDeVentaProducto>()
                .HasKey(x => x.IdOrdenVentaProd);

            modelBuilder.Entity<OrdenDeVentaProducto>()
                .HasOne(x => x.Producto)
                .WithMany(p => p.OrdenDeVentaProductos)
                .HasForeignKey(x => x.IdProducto);

            modelBuilder.Entity<OrdenDeVentaProducto>()
                .HasOne(x => x.OrdenDeVenta)
                .WithMany(o => o.OrdenDeVenta_Productos)
                .HasForeignKey(x => x.IdOrdenDeVenta);

            // Producto tiene un Proveedor y una Categoria
            modelBuilder.Entity<Productos>()
                .HasOne(p => p.Proveedor)
                .WithMany(prov => prov.Productos)
                .HasForeignKey(p => p.ProveedorId);

            modelBuilder.Entity<Productos>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            // Proveedor tiene una ciudad
            modelBuilder.Entity<Proveedores>()
                .HasOne(p => p.Ciudad)
                .WithMany(c => c.Proveedores)
                .HasForeignKey(p => p.IdCiudad);

            // Distribuidor tiene una ciudad
            modelBuilder.Entity<Distribuidores>()
                .HasOne(d => d.Ciudad)
                .WithMany(c => c.Distribuidores)
                .HasForeignKey(d => d.IdCiudad);

            // Orden de Venta relaciones
            modelBuilder.Entity<OrdenDeVenta>()
                .HasOne(ov => ov.Empleado)
                .WithMany(e => e.OrdenesDeVenta)
                .HasForeignKey(ov => ov.EmpleadoId);

            modelBuilder.Entity<OrdenDeVenta>()
                .HasOne(ov => ov.Cliente)
                .WithMany(c => c.OrdenesDeVenta)
                .HasForeignKey(ov => ov.ClienteId);

            modelBuilder.Entity<OrdenDeVenta>()
                .HasOne(ov => ov.Distribuidor)
                .WithMany(d => d.OrdenesDeVenta)
                .HasForeignKey(ov => ov.DistribuidorId);

            // Orden de Compra relaciones
            modelBuilder.Entity<OrdenDeCompra>()
                .HasOne(oc => oc.Empleado)
                .WithMany(e => e.OrdenesDeCompra)
                .HasForeignKey(oc => oc.EmpleadoId);

            modelBuilder.Entity<OrdenDeCompra>()
                .HasOne(oc => oc.Distribuidor)
                .WithMany()
                .HasForeignKey("DistribuidorId");

        //   DisableCascadingDelete(modelBuilder);

        }

     /*   public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.DoCustomEntityPreparations();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        )
        {
            this.DoCustomEntityPreparations();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void DoCustomEntityPreparations()
        {
            // Cuando el estado de la entidad es Modified, en ese momento le asigno la fecha de la actualizacion
            var modifiedEntitiesWithTrackDate = this
                .ChangeTracker.Entries()
                .Where(c => c.State == EntityState.Modified);
            foreach (var entityEntry in modifiedEntitiesWithTrackDate)
            {
                if (entityEntry.Properties.Any(c => c.Metadata.Name == "UpdatedDate"))
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder
                .Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        */
    }
}
