using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class add1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TipoDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(2367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 141, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 141, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 141, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeVenta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra_Producto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5000),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Distribuidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Ciudades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(66));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TipoDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 141, DateTimeKind.Local).AddTicks(9264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 141, DateTimeKind.Local).AddTicks(8835),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 141, DateTimeKind.Local).AddTicks(8226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeVenta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(3105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra_Producto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(2651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(2173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(1747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(3619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(1331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Distribuidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Ciudades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 42, 40, 142, DateTimeKind.Local).AddTicks(66),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3185));
        }
    }
}
