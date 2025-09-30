using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class initaldb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acp",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "Cp",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Ciudad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Acp",
                table: "Ciudad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cp",
                table: "Ciudad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Ciudad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Ciudad",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Acp", "Cp", "EstadoId" },
                values: new object[] { "A1000", "1000", 1 });

            migrationBuilder.UpdateData(
                table: "Ciudad",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Acp", "Cp", "EstadoId" },
                values: new object[] { "B2000", "2000", 1 });
        }
    }
}
