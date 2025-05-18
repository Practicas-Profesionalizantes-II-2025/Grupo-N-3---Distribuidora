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
    public partial class DataContext : DbContext 
    {
        public DataContext() { }
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Distribuidoraxx;Integrated Security=True;TrustServerCertificate=true");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                     .HasName("PK_ID_PERSONA");

                entity.HasOne(p => p.Cliente)
                    .WithOne(c => c.Persona)
                    .HasForeignKey("IdPersona")
                    .IsRequired();


                entity.HasOne(p => p.Empleado)
                    .WithOne(e => e.Persona)
                    .HasForeignKey("IdPersona")
                    .IsRequired();

                // Persona pertenece a una Ciudad
                entity.HasOne(p => p.Ciudad)
                    .WithMany(c => c.Personas)
                    .HasForeignKey("CiudadId")
                    .IsRequired();

            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                     .HasName("PK_ID_EMPLEADO");

                entity.HasOne(e => e.Sector)
                    .WithMany(s => s.Empleados)
                    .HasForeignKey("SectorId")
                    .IsRequired();
            });

            modelBuilder.Entity<OrdenDeVenta>(entity =>
            {
                entity.HasKey(e => e.IdOrdenVenta)
                     .HasName("PK_ID_ORDENVENTA");

                entity.HasOne(ov => ov.Factura)
                    .WithOne(f => f.OrdenDeVenta)
                    .HasForeignKey("FacturaId")
                    .IsRequired();

                entity.HasOne(ov => ov.Empleado)
                    .WithMany(e => e.OrdenesDeVenta)
                    .HasForeignKey("EmpleadoId")
                    .IsRequired();

                entity.HasOne(ov => ov.Cliente)
                    .WithMany(c => c.OrdenesDeVenta)
                    .HasForeignKey("ClienteId")
                    .IsRequired();

                entity.HasOne(ov => ov.Distribuidor)
                    .WithMany(d => d.OrdenesDeVenta)
                    .HasForeignKey("DistribuidorId")
                    .IsRequired();
            });

            modelBuilder.Entity<OrdenDeCompra>(entity =>
            {
                entity.HasKey(e => e.IdOrdenCompra)
                     .HasName("PK_ID_ORDENCOMPRA");

                entity.HasOne(oc => oc.Factura)
                    .WithOne(f => f.OrdenDeCompra)
                    .HasForeignKey("FacturaId")
                    .IsRequired();

                entity.HasOne(oc => oc.Empleado)
                    .WithMany(e => e.OrdenesDeCompra)
                    .HasForeignKey("EmpleadoId")
                    .IsRequired();

                entity.HasOne(oc => oc.Distribuidor)
                    .WithMany()
                    .HasForeignKey("DistribuidorId")
                    .IsRequired();
            });

            modelBuilder.Entity<OrdenDeCompraProducto>(entity =>
            {
                entity.HasKey(e => e.IdOrdenCompraProd)
                     .HasName("PK_ID_OrdenCompraProd");

                entity.HasKey(x => x.IdOrdenCompraProd);

                entity.HasOne(x => x.Producto)
                    .WithMany()
                    .HasForeignKey("IdProducto")
                    .IsRequired();

                entity.HasOne(x => x.OrdenDeCompra)
                    .WithMany()
                    .HasForeignKey("IdOrdenDeCompra")
                    .IsRequired();
            });

            modelBuilder.Entity<OrdenDeVentaProducto>(entity =>
            {
                entity.HasKey(e => e.IdOrdenVentaProd)
                   .HasName("PK_ID_IdOrdenVentaProd");

                entity.HasKey(x => x.IdOrdenVentaProd);

                entity.HasOne(x => x.Producto)
                    .WithMany(p => p.OrdenDeVentaProductos)
                    .HasForeignKey("IdProducto")
                    .IsRequired();

                entity.HasOne(x => x.OrdenDeVenta)
                    .WithMany(o => o.OrdenDeVenta_Productos)
                    .HasForeignKey("IdOrdenDeVenta")
                    .IsRequired();
            });

            modelBuilder.Entity<Productos>(entity =>
            {

                entity.HasKey(e => e.IdProducto)
                   .HasName("PK_ID_PRODUCTO");

                entity.HasOne(p => p.Proveedor)
                    .WithMany(prov => prov.Productos)
                    .HasForeignKey("ProveedorId")
                    .IsRequired();

                entity.HasOne(p => p.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey("CategoriaId")
                    .IsRequired();
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {

                entity.HasKey(e => e.IdProveedor)
                   .HasName("PK_ID_PROVEEDOR");

                entity.HasOne(p => p.Ciudad)
                    .WithMany(c => c.Proveedores)
                    .HasForeignKey("IdCiudad")
                    .IsRequired();
            });

            modelBuilder.Entity<Distribuidores>(entity =>
            {
                entity.HasKey(e => e.IdDistribuidor)
                   .HasName("PK_ID_DISTRIBUIDOR");

                entity.HasOne(d => d.Ciudad)
                    .WithMany(c => c.Distribuidores)
                    .HasForeignKey("IdCiudad")
                    .IsRequired();
            });
            OnModelCreatingPartial(modelBuilder);

            //   DisableCascadingDelete(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

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
