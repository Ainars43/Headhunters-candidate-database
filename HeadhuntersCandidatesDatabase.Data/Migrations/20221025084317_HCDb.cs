using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadhuntersCandidatesDatabase.Data.Migrations
{
    public partial class HCDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompaniesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatesData_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPositions",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    CompanyPositionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPositions", x => new { x.CompaniesId, x.CompanyPositionsId });
                    table.ForeignKey(
                        name: "FK_CompanyPositions_CompaniesData_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "CompaniesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPositions_Positions_CompanyPositionsId",
                        column: x => x.CompanyPositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCompany",
                columns: table => new
                {
                    CandidatesId = table.Column<int>(type: "int", nullable: false),
                    CompaniesAppliedForId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCompany", x => new { x.CandidatesId, x.CompaniesAppliedForId });
                    table.ForeignKey(
                        name: "FK_CandidateCompany_CandidatesData_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "CandidatesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_CompaniesData_CompaniesAppliedForId",
                        column: x => x.CompaniesAppliedForId,
                        principalTable: "CompaniesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_CandidatesData_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "CandidatesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_CompaniesAppliedForId",
                table: "CandidateCompany",
                column: "CompaniesAppliedForId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesData_PositionsId",
                table: "CandidatesData",
                column: "PositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositions_CompanyPositionsId",
                table: "CompanyPositions",
                column: "CompanyPositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CandidateId",
                table: "Skill",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCompany");

            migrationBuilder.DropTable(
                name: "CompanyPositions");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "CompaniesData");

            migrationBuilder.DropTable(
                name: "CandidatesData");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
