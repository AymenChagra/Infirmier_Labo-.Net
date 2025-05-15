using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class siteLabo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laboratoires",
                columns: table => new
                {
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseLabo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratoires", x => x.LaboratoireId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    CodePatient = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.CodePatient);
                });

            migrationBuilder.CreateTable(
                name: "Infirmiers",
                columns: table => new
                {
                    InfirmierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<int>(type: "int", nullable: false),
                    LaboratoireFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infirmiers", x => x.InfirmierId);
                    table.ForeignKey(
                        name: "FK_Infirmiers_laboratoires_LaboratoireFK",
                        column: x => x.LaboratoireFK,
                        principalTable: "laboratoires",
                        principalColumn: "LaboratoireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilans",
                columns: table => new
                {
                    DatePrelevement = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CodePatient = table.Column<int>(type: "int", nullable: false),
                    CodeInfirmier = table.Column<int>(type: "int", nullable: false),
                    EmailMedecin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paye = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilans", x => new { x.CodeInfirmier, x.CodePatient, x.DatePrelevement });
                    table.ForeignKey(
                        name: "FK_Bilans_Infirmiers_CodeInfirmier",
                        column: x => x.CodeInfirmier,
                        principalTable: "Infirmiers",
                        principalColumn: "InfirmierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilans_Patients_CodePatient",
                        column: x => x.CodePatient,
                        principalTable: "Patients",
                        principalColumn: "CodePatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    AnalyseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DureeResultat = table.Column<int>(type: "int", nullable: false),
                    PrixAnalyse = table.Column<double>(type: "float", nullable: false),
                    TypeAnalyse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValeurAnalyse = table.Column<float>(type: "real", nullable: false),
                    ValeurMaxNormale = table.Column<float>(type: "real", nullable: false),
                    ValeurMinNormale = table.Column<float>(type: "real", nullable: false),
                    CodeInfirmier = table.Column<int>(type: "int", nullable: false),
                    CodePatient = table.Column<int>(type: "int", nullable: false),
                    DatePrelevement = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.AnalyseId);
                    table.ForeignKey(
                        name: "FK_Analyses_Bilans_CodeInfirmier_CodePatient_DatePrelevement",
                        columns: x => new { x.CodeInfirmier, x.CodePatient, x.DatePrelevement },
                        principalTable: "Bilans",
                        principalColumns: new[] { "CodeInfirmier", "CodePatient", "DatePrelevement" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_CodeInfirmier_CodePatient_DatePrelevement",
                table: "Analyses",
                columns: new[] { "CodeInfirmier", "CodePatient", "DatePrelevement" });

            migrationBuilder.CreateIndex(
                name: "IX_Bilans_CodePatient",
                table: "Bilans",
                column: "CodePatient");

            migrationBuilder.CreateIndex(
                name: "IX_Infirmiers_LaboratoireFK",
                table: "Infirmiers",
                column: "LaboratoireFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "Bilans");

            migrationBuilder.DropTable(
                name: "Infirmiers");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "laboratoires");
        }
    }
}
