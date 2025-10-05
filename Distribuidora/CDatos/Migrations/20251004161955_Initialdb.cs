using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class Initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distribuidor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuilCuit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DistribuidorId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeVenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeVentaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenVentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeVentaProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo_DocId = table.Column<int>(type: "int", nullable: false),
                    Nro_Doc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    PrecioProducto = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompra_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompra_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeCompraProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenDeCompraId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeCompraProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompraProducto_OrdenDeCompra_OrdenDeCompraId",
                        column: x => x.OrdenDeCompraId,
                        principalTable: "OrdenDeCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDeCompraProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Bebidas" },
                    { 2, 1, "Alimentos" },
                    { 3, 1, "Congelados" }
                });

            migrationBuilder.InsertData(
                table: "Ciudad",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ciudad A" },
                    { 2, "Ciudad B" }
                });

            migrationBuilder.InsertData(
                table: "Distribuidor",
                columns: new[] { "Id", "CiudadId", "CuilCuit", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, 1, "46124922", "Direccion 1", "Distribuidor Uno", "Telefono 1" },
                    { 2, 2, "46136388", "Direccion 2", "Distribuidor Dos", "Telefono 2" }
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
                table: "OrdenDeVenta",
                columns: new[] { "Id", "ClienteId", "DistribuidorId", "EmpleadoId", "EstadoId", "FacturaId", "Fecha" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, 1, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, 2, 2, 2, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrdenDeVentaProducto",
                columns: new[] { "Id", "CantidadProducto", "OrdenVentaId", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 5, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Persona",
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
                columns: new[] { "Id", "CategoriaId", "Nombre", "PrecioProducto", "ProveedorId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Televisor", 10000f, 1, 10 },
                    { 2, 2, "Celular", 5000f, 1, 20 },
                    { 3, 3, "Pan", 100f, 2, 100 }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "Id", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Direccion 1", "email1@dominio.com.ar", "Proveedor Uno", "Telefono 1" },
                    { 2, "Direccion 2", "email2@dominio.com.ar", "Proveedor Dos", "Telefono 2" }
                });

            migrationBuilder.InsertData(
                table: "Sector",
                columns: new[] { "Id", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Ventas" },
                    { 2, 1, "Administración" }
                });

            migrationBuilder.InsertData(
                table: "TipoDocumento",
                columns: new[] { "Id", "NombreTipoDocumento" },
                values: new object[,]
                {
                    { 1, "DNI" },
                    { 2, "Pasaporte" },
                    { 3, "Libreta De Enrolamiento" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Contrasenia", "EstadoId", "Nombre", "PersonaId" },
                values: new object[,]
                {
                    { 1, "admin123", 1, "admin", 1 },
                    { 2, "cliente123", 1, "cliente1", 7 }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
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
                table: "Empleado",
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
                table: "OrdenDeCompra",
                columns: new[] { "Id", "EmpleadoId", "FechaOrden", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "OrdenDeCompraProducto",
                columns: new[] { "Id", "CantidadProducto", "OrdenDeCompraId", "ProductoId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 10, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PersonaId",
                table: "Cliente",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_PersonaId",
                table: "Empleado",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompra_EmpleadoId",
                table: "OrdenDeCompra",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompra_ProveedorId",
                table: "OrdenDeCompra",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompraProducto_OrdenDeCompraId",
                table: "OrdenDeCompraProducto",
                column: "OrdenDeCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompraProducto_ProductoId",
                table: "OrdenDeCompraProducto",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Distribuidor");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "OrdenDeCompraProducto");

            migrationBuilder.DropTable(
                name: "OrdenDeVenta");

            migrationBuilder.DropTable(
                name: "OrdenDeVentaProducto");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "OrdenDeCompra");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
