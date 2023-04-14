using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVSec.Data.Migrations
{
    public partial class numbertwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    InterventionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.InterventionId);
                });

            migrationBuilder.CreateTable(
                name: "Inventaire",
                columns: table => new
                {
                    CodeVin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixAchat = table.Column<float>(type: "real", nullable: false),
                    PrixVente = table.Column<float>(type: "real", nullable: false),
                    DateVente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVente = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaire", x => x.CodeVin);
                });

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    ReparationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventaireId = table.Column<int>(type: "int", nullable: false),
                    DateDisponibilite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoutReparation = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.ReparationId);
                    table.ForeignKey(
                        name: "FK_Reparations_Inventaire_InventaireId",
                        column: x => x.InventaireId,
                        principalTable: "Inventaire",
                        principalColumn: "CodeVin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterventionsReparations",
                columns: table => new
                {
                    IntervetionsReparationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntervetionsId = table.Column<int>(type: "int", nullable: false),
                    ReparationsId = table.Column<int>(type: "int", nullable: false),
                    InterventionsInterventionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterventionsReparations", x => x.IntervetionsReparationsId);
                    table.ForeignKey(
                        name: "FK_InterventionsReparations_Interventions_InterventionsInterventionId",
                        column: x => x.InterventionsInterventionId,
                        principalTable: "Interventions",
                        principalColumn: "InterventionId");
                    table.ForeignKey(
                        name: "FK_InterventionsReparations_Reparations_ReparationsId",
                        column: x => x.ReparationsId,
                        principalTable: "Reparations",
                        principalColumn: "ReparationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterventionsReparations_InterventionsInterventionId",
                table: "InterventionsReparations",
                column: "InterventionsInterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_InterventionsReparations_ReparationsId",
                table: "InterventionsReparations",
                column: "ReparationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_InventaireId",
                table: "Reparations",
                column: "InventaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterventionsReparations");

            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropTable(
                name: "Inventaire");
        }
    }
}
