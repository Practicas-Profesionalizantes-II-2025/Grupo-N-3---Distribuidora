using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class add2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TipoDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(2520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeVenta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra_Producto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 911, DateTimeKind.Local).AddTicks(231),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(7858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Distribuidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(5448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Ciudades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3185));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TipoDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(2367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(1264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeVenta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra_Producto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrdenesDeCompra",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(5000),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(6946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 911, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Distribuidores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(4014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Ciudades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 22, 55, 19, 515, DateTimeKind.Local).AddTicks(3185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 23, 32, 35, 910, DateTimeKind.Local).AddTicks(4537));
        }
    }
}
