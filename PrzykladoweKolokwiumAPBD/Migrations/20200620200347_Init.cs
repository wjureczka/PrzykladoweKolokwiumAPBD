using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrzykladoweKolokwiumAPBD.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klients",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klients", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracowniks",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracowniks", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobCukierniczies",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 200, nullable: false),
                    CenaZaSztuke = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobCukierniczies", x => x.IdWyrobuCukierniczego);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienies",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true),
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienies", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienies_Klients_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klients",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienies_Pracowniks_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracowniks",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie_WyrobCukierniczies",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    IdZamowienia = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie_WyrobCukierniczies", x => new { x.IdWyrobuCukierniczego, x.IdZamowienia });
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczies_WyrobCukierniczies_IdWyrobuCukierniczego",
                        column: x => x.IdWyrobuCukierniczego,
                        principalTable: "WyrobCukierniczies",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczies_Zamowienies_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienies",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczies_IdZamowienia",
                table: "Zamowienie_WyrobCukierniczies",
                column: "IdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienies_IdKlient",
                table: "Zamowienies",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienies_IdPracownik",
                table: "Zamowienies",
                column: "IdPracownik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie_WyrobCukierniczies");

            migrationBuilder.DropTable(
                name: "WyrobCukierniczies");

            migrationBuilder.DropTable(
                name: "Zamowienies");

            migrationBuilder.DropTable(
                name: "Klients");

            migrationBuilder.DropTable(
                name: "Pracowniks");
        }
    }
}
