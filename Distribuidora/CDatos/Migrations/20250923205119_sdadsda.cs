using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class sdadsda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Distribuidor",
                columns: new[] { "Id", "CiudadId", "CuilCuit", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, 1, "46124922", "Direccion 1", "Distribuidor Uno", "Telefono 1" },
                    { 2, 2, "46136388", "Direccion 2", "Distribuidor Dos", "Telefono 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distribuidor");
        }
    }
}
