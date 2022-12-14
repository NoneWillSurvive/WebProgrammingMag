using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class CreateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quaification = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CodeMKB = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<bool>(type: "boolean", nullable: false, comment: "true - М, false - Ж"),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    IllnessId = table.Column<long>(type: "bigint", nullable: true),
                    LevelAnxiety = table.Column<int>(type: "integer", nullable: false, comment: "Уровень тревоги"),
                    LevelDepression = table.Column<int>(type: "integer", nullable: false, comment: "Уровень депрессии"),
                    LevelHopelessness = table.Column<int>(type: "integer", nullable: false, comment: "Уровень безнадежности"),
                    LevelAsthenicSyndrome = table.Column<int>(type: "integer", nullable: false, comment: "Уровень астенического синдрома"),
                    NeedHospitalization = table.Column<bool>(type: "boolean", nullable: false, comment: "Есть ли зависимость"),
                    RecommendedDoctorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_RecommendedDoctorId",
                        column: x => x.RecommendedDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IllnessId",
                table: "Patients",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RecommendedDoctorId",
                table: "Patients",
                column: "RecommendedDoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Illnesses");
        }
    }
}
