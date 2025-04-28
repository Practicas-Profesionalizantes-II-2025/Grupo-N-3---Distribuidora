using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class add3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TipoDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(3168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(2745),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(1906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeVenta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(7107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra_Producto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(6607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(6173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(5597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(7602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 911, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(5178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Distribuidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(4823),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(4318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Ciudades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(3970),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4537));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TipoDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(3168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(2520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeVenta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra_Producto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(5597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 911, DateTimeKind.Local).AddTicks(231),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(7858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Distribuidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(5448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Ciudades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 34, 36, 683, DateTimeKind.Local).AddTicks(3970));
        }
    }
}
