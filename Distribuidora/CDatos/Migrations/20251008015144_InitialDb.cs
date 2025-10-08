using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
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
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
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
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "OrdenDeVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DistribuidorId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenDeVenta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenDeVenta_Distribuidor_DistribuidorId",
                        column: x => x.DistribuidorId,
                        principalTable: "Distribuidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenDeVenta_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "OrdenDeVentaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenVentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    OrdenDeVentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeVentaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenDeVentaProducto_OrdenDeVenta_OrdenDeVentaId",
                        column: x => x.OrdenDeVentaId,
                        principalTable: "OrdenDeVenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenDeVentaProducto_Productos_ProductoId",
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
                table: "Persona",
                columns: new[] { "Id", "Apellido", "CiudadId", "Direccion", "Email", "Nombre", "Nro_Doc", "Telefono", "Tipo_DocId" },
                values: new object[,]
                {
                    { 1, "Pérez", 1, "Calle Falsa 123", "juan@mail.com", "Juan", "12345678", "11111111", 1 },
                    { 2, "García", 1, "Av. Siempre Viva 742", "ana@mail.com", "Ana", "87654321", "22222222", 2 },
                    { 3, "Martínez", 2, "Calle Luna 45", "luis@mail.com", "Luis", "11223344", "33333333", 3 },
                    { 4, "Rodríguez", 2, "Av. Sol 99", "maria@mail.com", "María", "44332211", "44444444", 1 },
                    { 5, "Sánchez", 1, "Calle Norte 10", "pedro@mail.com", "Pedro", "55555555", "55555555", 2 },
                    { 6, "Fernández", 2, "Av. Sur 20", "lucia@mail.com", "Lucía", "66666666", "66666666", 3 },
                    { 7, "Ramírez", 1, "Calle Este 30", "carlos@mail.com", "Carlos", "77777777", "77777777", 1 },
                    { 8, "López", 2, "Av. Oeste 40", "sofia@mail.com", "Sofía", "88888888", "88888888", 2 },
                    { 9, "Torres", 1, "Calle Sur 50", "miguel@mail.com", "Miguel", "99999999", "99999999", 3 },
                    { 10, "Gómez", 2, "Av. Norte 60", "valentina@mail.com", "Valentina", "10101010", "10101010", 1 },
                    { 11, "Castro", 1, "Calle Central 70", "diego@mail.com", "Diego", "11111112", "11111112", 2 },
                    { 12, "Vega", 2, "Av. Principal 80", "martina@mail.com", "Martina", "12121212", "12121212", 3 }
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
                columns: new[] { "Id", "Admin", "Contrasenia", "EstadoId", "PersonaId" },
                values: new object[,]
                {
                    { 1, true, "8b5cc4df7eec7d32a7814eca4af047ae33b2d52342667715682e19c25b0b9faa", 1, 1 },
                    { 2, false, "ac0f09c0f8bf5e7a4b063d863255f16d8ce9abe600e288d934cf313bcbff63eb", 1, 2 },
                    { 3, true, "cef7fc13a38180936ffa2635489088778e059f07a5d1beda53f1719d35577631", 1, 3 },
                    { 4, false, "449777124b1466a8ed667d0dd4c0620993f59e20fb27b3fa8894e957f8762353", 2, 4 },
                    { 5, true, "43700797e2f9d4ad38ccf1355df3233453396bfcc8db8e424486e37bae42a9ec", 1, 5 },
                    { 6, false, "f33422b95e3b98310adedc93655de579f6e311120ea0c27c3e2317b5116d6afb", 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "OrdenDeVentaProducto",
                columns: new[] { "Id", "CantidadProducto", "OrdenDeVentaId", "OrdenVentaId", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1 },
                    { 2, 2, null, 1, 2 },
                    { 3, 5, null, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrdenDeCompra",
                columns: new[] { "Id", "EmpleadoId", "Estado", "FechaOrden", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, null, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "OrdenDeVenta",
                columns: new[] { "Id", "ClienteId", "DistribuidorId", "EmpleadoId", "Estado", "Fecha" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, 2, null, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeVenta_ClienteId",
                table: "OrdenDeVenta",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeVenta_DistribuidorId",
                table: "OrdenDeVenta",
                column: "DistribuidorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeVenta_EmpleadoId",
                table: "OrdenDeVenta",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeVentaProducto_OrdenDeVentaId",
                table: "OrdenDeVentaProducto",
                column: "OrdenDeVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeVentaProducto_ProductoId",
                table: "OrdenDeVentaProducto",
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
                name: "Estados");

            migrationBuilder.DropTable(
                name: "OrdenDeCompraProducto");

            migrationBuilder.DropTable(
                name: "OrdenDeVentaProducto");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "OrdenDeCompra");

            migrationBuilder.DropTable(
                name: "OrdenDeVenta");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Distribuidor");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
