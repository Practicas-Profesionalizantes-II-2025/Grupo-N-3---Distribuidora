using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class adddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDeCompra_Proveedor_DistribuidorId",
                table: "OrdenDeCompra");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.RenameColumn(
                name: "DistribuidorId",
                table: "OrdenDeCompra",
                newName: "ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenDeCompra_DistribuidorId",
                table: "OrdenDeCompra",
                newName: "IX_OrdenDeCompra_ProveedorId");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Empleado",
                newName: "Contrasenia");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Empleado",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Admin", "Contrasenia" },
                values: new object[] { true, "8b5cc4df7eec7d32a7814eca4af047ae33b2d52342667715682e19c25b0b9faa" });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Admin", "Contrasenia" },
                values: new object[] { false, "ac0f09c0f8bf5e7a4b063d863255f16d8ce9abe600e288d934cf313bcbff63eb" });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Admin", "Contrasenia" },
                values: new object[] { true, "cef7fc13a38180936ffa2635489088778e059f07a5d1beda53f1719d35577631" });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Admin", "Contrasenia" },
                values: new object[] { false, "449777124b1466a8ed667d0dd4c0620993f59e20fb27b3fa8894e957f8762353" });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Admin", "Contrasenia" },
                values: new object[] { true, "43700797e2f9d4ad38ccf1355df3233453396bfcc8db8e424486e37bae42a9ec" });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Admin", "Contrasenia" },
                values: new object[] { false, "f33422b95e3b98310adedc93655de579f6e311120ea0c27c3e2317b5116d6afb" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompraProducto_OrdenDeCompraId",
                table: "OrdenDeCompraProducto",
                column: "OrdenDeCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeCompraProducto_ProductoId",
                table: "OrdenDeCompraProducto",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDeCompra_Proveedor_ProveedorId",
                table: "OrdenDeCompra",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDeCompraProducto_OrdenDeCompra_OrdenDeCompraId",
                table: "OrdenDeCompraProducto",
                column: "OrdenDeCompraId",
                principalTable: "OrdenDeCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDeCompraProducto_Productos_ProductoId",
                table: "OrdenDeCompraProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDeCompra_Proveedor_ProveedorId",
                table: "OrdenDeCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDeCompraProducto_OrdenDeCompra_OrdenDeCompraId",
                table: "OrdenDeCompraProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenDeCompraProducto_Productos_ProductoId",
                table: "OrdenDeCompraProducto");

            migrationBuilder.DropIndex(
                name: "IX_OrdenDeCompraProducto_OrdenDeCompraId",
                table: "OrdenDeCompraProducto");

            migrationBuilder.DropIndex(
                name: "IX_OrdenDeCompraProducto_ProductoId",
                table: "OrdenDeCompraProducto");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "OrdenDeCompra",
                newName: "DistribuidorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdenDeCompra_ProveedorId",
                table: "OrdenDeCompra",
                newName: "IX_OrdenDeCompra_DistribuidorId");

            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "Empleado",
                newName: "Foto");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: "");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: "");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Contrasenia", "EstadoId", "Nombre", "PersonaId" },
                values: new object[,]
                {
                    { 1, "admin123", 1, "admin", 1 },
                    { 2, "cliente123", 1, "cliente1", 7 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenDeCompra_Proveedor_DistribuidorId",
                table: "OrdenDeCompra",
                column: "DistribuidorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
