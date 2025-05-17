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

        //   modelBuilder.Entity<Persona>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<Productos>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<TipoDocumento>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<Estado>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<Ciudades>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<Clientes>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<Distribuidores>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<Empleados>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<Facturas>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<OrdenDeCompra>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<OrdenDeCompraProducto>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
        //    modelBuilder.Entity<OrdenDeVenta>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha

            DisableCascadingDelete(modelBuilder);

        }

        public override int SaveChanges()
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

    }
}
