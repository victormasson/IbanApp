using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbanApp.Repository.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformationBancaires",
                columns: table => new
                {
                    IdInformationBancaire = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdSalarie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomBanque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitulaireCompte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAjout = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationBancaires", x => x.IdInformationBancaire);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationBancaires");
        }
    }
}
