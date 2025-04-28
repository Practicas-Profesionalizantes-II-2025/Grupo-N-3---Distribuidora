using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options)

            : base(options) { }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Distribuidores> Distribuidores { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<OrdenesDeCompra> OrdenesDeCompra { get; set; }
        public DbSet<OrdenesDeCompra_Producto> OrdenesDeCompra_Producto { get; set; }
        public DbSet<OrdenesDeVenta> OrdenesDeVenta { get; set; }
        public DbSet<OrdenesDeVenta_Producto> OrdenesDeVenta_Producto { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Sectores> Sectores { get; set; }
        public DbSet<TipoDocumento> TipoDocumento   { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Personas>().HasIndex(x => x.Nombre);

            modelBuilder.Entity<Personas>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Productos>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<TipoDocumento>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Estados>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Ciudades>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Clientes>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Distribuidores>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Empleados>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Facturas>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<OrdenesDeCompra>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<OrdenesDeCompra_Producto>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<OrdenesDeVenta>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha
            modelBuilder.Entity<Estados>().Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now); // Cuando se crea el registro, se asigna la fecha

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

            // Cuando el estado de la entidad es Modified, en ese momento le asigno la fecha de la actualizacion
            //var addedEntitiesWithTrackDate = this
            //    .ChangeTracker.Entries()
            //    .Where(c => c.State == EntityState.Added);
            //foreach (var entityEntry in addedEntitiesWithTrackDate)
            //{
            //    if (entityEntry.Properties.Any(c => c.Metadata.Name == "CreatedDate"))
            //    {
            //        entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            //    }
            //}

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
