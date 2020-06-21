using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzykladoweKolokwiumAPBD.Migrations
{
    public partial class NullableDataRealizacji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRealizacji",
                table: "Zamowienies",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRealizacji",
                table: "Zamowienies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
