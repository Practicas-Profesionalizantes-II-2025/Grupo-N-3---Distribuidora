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
        public DbSet<Empleado> Empleados { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<OrdenDeCompra> OrdenesDeCompra { get; set; } = null!;
        public DbSet<OrdenDeCompraProducto> OrdenesDeCompraProducto { get; set; } = null!;
        public DbSet<OrdenDeVenta> OrdenesDeVenta { get; set; } = null!;
        public DbSet<OrdenDeVentaProducto> OrdenesDeVentaProducto { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Proveedor> Proveedores { get; set; } = null!;
        public DbSet<Sector> Sectores { get; set; } = null!;
        public DbSet<TipoDocumento> TiposDocumento { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Estados
            modelBuilder.Entity<Estado>().HasData(
                new Estado { Id = 1, Descripcion = "Activo" },
                new Estado { Id = 2, Descripcion = "Inactivo" }
            );

            // TipoDocumento
            modelBuilder.Entity<TipoDocumento>().HasData(
                new TipoDocumento { Id = 1, NombreTipoDocumento = "DNI" },
                new TipoDocumento { Id = 2, NombreTipoDocumento = "Pasaporte" },
                new TipoDocumento { Id = 3, NombreTipoDocumento = "Libreta De Enrolamiento" }
            );

            // Ciudades
            modelBuilder.Entity<Ciudad>().HasData(
                new Ciudad { Id = 1, Nombre = "Ciudad A", Cp = "1000", Acp = "A1000", EstadoId = 1 },
                new Ciudad { Id = 2, Nombre = "Ciudad B", Cp = "2000", Acp = "B2000", EstadoId = 1 }
            );

            // Sectores
            modelBuilder.Entity<Sector>().HasData(
                new Sector { Id = 1, Nombre = "Ventas"          , EstadoId = 1 },
                new Sector { Id = 2, Nombre = "Administración"  , EstadoId = 1 }
            );

            // Proveedores
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor { Id = 1, Nombre = "Proveedor Uno", Direccion = "Direccion 1", Telefono = "Telefono 1", Email = "email1@dominio.com.ar", EstadoId = 1 },
                new Proveedor { Id = 2, Nombre = "Proveedor Dos", Direccion = "Direccion 2", Telefono = "Telefono 2", Email = "email2@dominio.com.ar", EstadoId = 1 }
            );

            // Categorias
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Bebidas", EstadoId = 1 },
                new Categoria { Id = 2, Nombre = "Alimentos", EstadoId = 1 },
                new Categoria { Id = 3, Nombre = "Congelados", EstadoId = 1 }
            );

            // Personas (12 instancias)
            modelBuilder.Entity<Persona>().HasData(
                // Empleados (Id 1-6)
                new Persona { Id = 1, Nombre = "Juan",      Apellido = "Pérez",     Tipo_DocId = 1, Nro_Doc = "12345678", CiudadId = 1, Email = "juan@mail.com",        Direccion = "Calle Falsa 123",      Telefono = "11111111", EstadoId = 1 },
                new Persona { Id = 2, Nombre = "Ana",       Apellido = "García",    Tipo_DocId = 2, Nro_Doc = "87654321", CiudadId = 1, Email = "ana@mail.com",         Direccion = "Av. Siempre Viva 742", Telefono = "22222222", EstadoId = 1 },
                new Persona { Id = 3, Nombre = "Luis",      Apellido = "Martínez",  Tipo_DocId = 3, Nro_Doc = "11223344", CiudadId = 2, Email = "luis@mail.com",        Direccion = "Calle Luna 45",        Telefono = "33333333", EstadoId = 1 },
                new Persona { Id = 4, Nombre = "María",     Apellido = "Rodríguez", Tipo_DocId = 1, Nro_Doc = "44332211", CiudadId = 2, Email = "maria@mail.com",       Direccion = "Av. Sol 99",           Telefono = "44444444", EstadoId = 2 },
                new Persona { Id = 5, Nombre = "Pedro",     Apellido = "Sánchez",   Tipo_DocId = 2, Nro_Doc = "55555555", CiudadId = 1, Email = "pedro@mail.com",       Direccion = "Calle Norte 10",       Telefono = "55555555", EstadoId = 1 },
                new Persona { Id = 6, Nombre = "Lucía",     Apellido = "Fernández", Tipo_DocId = 3, Nro_Doc = "66666666", CiudadId = 2, Email = "lucia@mail.com",       Direccion = "Av. Sur 20",           Telefono = "66666666", EstadoId = 2 },
                // Clientes (Id 7-12)
                new Persona { Id = 7, Nombre = "Carlos",    Apellido = "Ramírez",   Tipo_DocId = 1, Nro_Doc = "77777777", CiudadId = 1, Email = "carlos@mail.com",      Direccion = "Calle Este 30",        Telefono = "77777777", EstadoId = 1 },
                new Persona { Id = 8, Nombre = "Sofía",     Apellido = "López",     Tipo_DocId = 2, Nro_Doc = "88888888", CiudadId = 2, Email = "sofia@mail.com",       Direccion = "Av. Oeste 40",         Telefono = "88888888", EstadoId = 1 },
                new Persona { Id = 9, Nombre = "Miguel",    Apellido = "Torres",    Tipo_DocId = 3, Nro_Doc = "99999999", CiudadId = 1, Email = "miguel@mail.com",      Direccion = "Calle Sur 50",         Telefono = "99999999", EstadoId = 1 },
                new Persona { Id = 10, Nombre = "Valentina",Apellido = "Gómez",     Tipo_DocId = 1, Nro_Doc = "10101010", CiudadId = 2, Email = "valentina@mail.com",   Direccion = "Av. Norte 60",         Telefono = "10101010", EstadoId = 2 },
                new Persona { Id = 11, Nombre = "Diego",    Apellido = "Castro",    Tipo_DocId = 2, Nro_Doc = "11111112", CiudadId = 1, Email = "diego@mail.com",       Direccion = "Calle Central 70",     Telefono = "11111112", EstadoId = 1 },
                new Persona { Id = 12, Nombre = "Martina",  Apellido = "Vega",      Tipo_DocId = 3, Nro_Doc = "12121212", CiudadId = 2, Email = "martina@mail.com",     Direccion = "Av. Principal 80",     Telefono = "12121212", EstadoId = 2 }
            );

            // Empleados (6 instancias, PersonaId 1-6)
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado { Id = 1, PersonaId = 1, EstadoId = 1, SectorId = 1, Foto = "" },
                new Empleado { Id = 2, PersonaId = 2, EstadoId = 1, SectorId = 2, Foto = "" },
                new Empleado { Id = 3, PersonaId = 3, EstadoId = 1, SectorId = 1, Foto = "" },
                new Empleado { Id = 4, PersonaId = 4, EstadoId = 2, SectorId = 2, Foto = "" },
                new Empleado { Id = 5, PersonaId = 5, EstadoId = 1, SectorId = 1, Foto = "" },
                new Empleado { Id = 6, PersonaId = 6, EstadoId = 2, SectorId = 2, Foto = "" }
            );

            // Clientes (6 instancias, PersonaId 7-12)
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, PersonaId = 7,    EstadoId = 1 },
                new Cliente { Id = 2, PersonaId = 8,    EstadoId = 1 },
                new Cliente { Id = 3, PersonaId = 9,    EstadoId = 1 },
                new Cliente { Id = 4, PersonaId = 10,   EstadoId = 2 },
                new Cliente { Id = 5, PersonaId = 11,   EstadoId = 1 },
                new Cliente { Id = 6, PersonaId = 12,   EstadoId = 2 }
            );

            // Productos
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Televisor",    ProveedorId = 1, CategoriaId = 1, PrecioProducto = 10000,   Stock = 10 },
                new Producto { Id = 2, Nombre = "Celular",      ProveedorId = 1, CategoriaId = 1, PrecioProducto = 5000,    Stock = 20 },
                new Producto { Id = 3, Nombre = "Pan",          ProveedorId = 2, CategoriaId = 2, PrecioProducto = 100,     Stock = 100 }
            );

            // Ordenes de Compra
            modelBuilder.Entity<OrdenDeCompra>().HasData(
                new OrdenDeCompra { Id = 1, EmpleadoId = 1, DistribuidorId = 1, FechaOrden = new DateTime(2025, 8, 21) },
                new OrdenDeCompra { Id = 2, EmpleadoId = 2, DistribuidorId = 2, FechaOrden = new DateTime(2025, 8, 20) }
            );

            // Ordenes de Compra Producto
            modelBuilder.Entity<OrdenDeCompraProducto>().HasData(
                new OrdenDeCompraProducto { Id = 1, OrdenDeCompraId = 1, ProductoId = 1, CantidadProducto = 2 },
                new OrdenDeCompraProducto { Id = 2, OrdenDeCompraId = 1, ProductoId = 2, CantidadProducto = 1 },
                new OrdenDeCompraProducto { Id = 3, OrdenDeCompraId = 2, ProductoId = 3, CantidadProducto = 10 }
            );

            // Ordenes de Venta
            modelBuilder.Entity<OrdenDeVenta>().HasData(
                new OrdenDeVenta { Id = 1, Fecha = new DateTime(2025, 8, 21), FacturaId = 1, EmpleadoId = 1, ClienteId = 1, DistribuidorId = 1, EstadoId = 1 },
                new OrdenDeVenta { Id = 2, Fecha = new DateTime(2025, 8, 20), FacturaId = 2, EmpleadoId = 2, ClienteId = 2, DistribuidorId = 2, EstadoId = 2 }
            );

            // Ordenes de Venta Producto
            modelBuilder.Entity<OrdenDeVentaProducto>().HasData(
                new OrdenDeVentaProducto { Id = 1, OrdenVentaId = 1, ProductoId = 1, CantidadProducto = 1 },
                new OrdenDeVentaProducto { Id = 2, OrdenVentaId = 1, ProductoId = 2, CantidadProducto = 2 },
                new OrdenDeVentaProducto { Id = 3, OrdenVentaId = 2, ProductoId = 3, CantidadProducto = 5 }
            );

            // Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, NombreUsuario = "admin",      Contrasenia = "admin123",   PersonaId = 1, EstadoId = 1 },
                new Usuario { Id = 2, NombreUsuario = "cliente1",   Contrasenia = "cliente123", PersonaId = 7, EstadoId = 1 }
            );
        }
    }
}