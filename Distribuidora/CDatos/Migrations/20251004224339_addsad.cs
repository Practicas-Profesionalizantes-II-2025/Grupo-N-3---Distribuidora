using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class addsad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Persona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 2,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 3,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 4,
                column: "EstadoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 5,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 6,
                column: "EstadoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 7,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 8,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 9,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 10,
                column: "EstadoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 11,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persona",
                keyColumn: "Id",
                keyValue: 12,
                column: "EstadoId",
                value: 2);
        }
    }
}
