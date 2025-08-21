using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class add10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distribuidores");

            migrationBuilder.DropTable(
                name: "FacturasCabeceras");

            migrationBuilder.DropColumn(
                name: "UnidadesProducto",
                table: "Productos");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Proveedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "OrdenesDeVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Ciudades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Bebidas" },
                    { 2, 1, "Alimentos" },
                    { 3, 1, "Congelados" }
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Acp", "Cp", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "A1000", "1000", 1, "Ciudad A" },
                    { 2, "B2000", "2000", 1, "Ciudad B" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "EstadoId", "PersonaId" },
                values: new object[,]
                {
                    { 1, 1, 7 },
                    { 2, 1, 8 },
                    { 3, 1, 9 },
                    { 4, 2, 10 },
                    { 5, 1, 11 },
                    { 6, 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "EstadoId", "Foto", "PersonaId", "SectorId" },
                values: new object[,]
                {
                    { 1, 1, "", 1, 1 },
                    { 2, 1, "", 2, 2 },
                    { 3, 1, "", 3, 1 },
                    { 4, 2, "", 4, 2 },
                    { 5, 1, "", 5, 1 },
                    { 6, 2, "", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "OrdenesDeCompra",
                columns: new[] { "Id", "DistribuidorId", "EmpleadoId", "FechaOrden" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrdenesDeCompraProducto",
                columns: new[] { "Id", "CantidadProducto", "OrdenDeCompraId", "ProductoId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 10, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrdenesDeVenta",
                columns: new[] { "Id", "ClienteId", "DistribuidorId", "EmpleadoId", "EstadoId", "FacturaId", "Fecha" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, 1, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, 2, 2, 2, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrdenesDeVentaProducto",
                columns: new[] { "Id", "CantidadProducto", "OrdenVentaId", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 5, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "CiudadId", "Direccion", "Email", "EstadoId", "Nombre", "Nro_Doc", "Telefono", "Tipo_DocId" },
                values: new object[,]
                {
                    { 1, "Pérez", 1, "Calle Falsa 123", "juan@mail.com", 1, "Juan", "12345678", "11111111", 1 },
                    { 2, "García", 1, "Av. Siempre Viva 742", "ana@mail.com", 1, "Ana", "87654321", "22222222", 2 },
                    { 3, "Martínez", 2, "Calle Luna 45", "luis@mail.com", 1, "Luis", "11223344", "33333333", 3 },
                    { 4, "Rodríguez", 2, "Av. Sol 99", "maria@mail.com", 2, "María", "44332211", "44444444", 1 },
                    { 5, "Sánchez", 1, "Calle Norte 10", "pedro@mail.com", 1, "Pedro", "55555555", "55555555", 2 },
                    { 6, "Fernández", 2, "Av. Sur 20", "lucia@mail.com", 2, "Lucía", "66666666", "66666666", 3 },
                    { 7, "Ramírez", 1, "Calle Este 30", "carlos@mail.com", 1, "Carlos", "77777777", "77777777", 1 },
                    { 8, "López", 2, "Av. Oeste 40", "sofia@mail.com", 1, "Sofía", "88888888", "88888888", 2 },
                    { 9, "Torres", 1, "Calle Sur 50", "miguel@mail.com", 1, "Miguel", "99999999", "99999999", 3 },
                    { 10, "Gómez", 2, "Av. Norte 60", "valentina@mail.com", 2, "Valentina", "10101010", "10101010", 1 },
                    { 11, "Castro", 1, "Calle Central 70", "diego@mail.com", 1, "Diego", "11111112", "11111112", 2 },
                    { 12, "Vega", 2, "Av. Principal 80", "martina@mail.com", 2, "Martina", "12121212", "12121212", 3 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Nombre", "PrecioProducto", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 1, "Televisor", 10000f, 1 },
                    { 2, 1, "Celular", 5000f, 1 },
                    { 3, 2, "Pan", 100f, 2 }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Id", "Direccion", "Email", "EstadoId", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Direccion 1", "email1@dominio.com.ar", 1, "Proveedor Uno", "Telefono 1" },
                    { 2, "Direccion 2", "email2@dominio.com.ar", 1, "Proveedor Dos", "Telefono 2" }
                });

            migrationBuilder.InsertData(
                table: "Sectores",
                columns: new[] { "Id", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Ventas" },
                    { 2, 1, "Administración" }
                });

            migrationBuilder.InsertData(
                table: "TiposDocumento",
                columns: new[] { "Id", "NombreTipoDocumento" },
                values: new object[,]
                {
                    { 1, "DNI" },
                    { 2, "Pasaporte" },
                    { 3, "Libreta De Enrolamiento" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contrasenia", "EstadoId", "NombreUsuario", "PersonaId" },
                values: new object[,]
                {
                    { 1, "admin123", 1, "admin", 1 },
                    { 2, "cliente123", 1, "cliente1", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrdenesDeCompra",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrdenesDeCompra",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrdenesDeCompraProducto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrdenesDeCompraProducto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrdenesDeCompraProducto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrdenesDeVenta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrdenesDeVenta",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrdenesDeVentaProducto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrdenesDeVentaProducto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrdenesDeVentaProducto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sectores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposDocumento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposDocumento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposDocumento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "OrdenesDeVenta");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Ciudades");

            migrationBuilder.AddColumn<int>(
                name: "UnidadesProducto",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Distribuidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturasCabeceras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasCabeceras", x => x.Id);
                });
        }
    }
}
