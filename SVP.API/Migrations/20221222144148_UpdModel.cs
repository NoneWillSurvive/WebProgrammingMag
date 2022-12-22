using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class UpdModel : Migration
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
                    Qualification = table.Column<string>(type: "text", nullable: true, comment: "Список квалификаций, описаны через запятую с пробелом")
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
                    CodeMKB = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
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
                    Age = table.Column<byte>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IllnessId = table.Column<long>(type: "bigint", nullable: false),
                    LevelAnxiety = table.Column<byte>(type: "smallint", nullable: false, comment: "Уровень тревоги"),
                    LevelDepression = table.Column<byte>(type: "smallint", nullable: false, comment: "Уровень депрессии"),
                    LevelHopelessness = table.Column<byte>(type: "smallint", nullable: false, comment: "Уровень безнадежности"),
                    LevelAsthenicSyndrome = table.Column<byte>(type: "smallint", nullable: false, comment: "Уровень астенического синдрома"),
                    HasAddiction = table.Column<bool>(type: "boolean", nullable: false, comment: "Есть ли зависимость"),
                    NeedHospitalization = table.Column<bool>(type: "boolean", nullable: false, comment: "Нужна ли госпитализация"),
                    RecommendedDoctorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_RecommendedDoctorId",
                        column: x => x.RecommendedDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthData",
                columns: table => new
                {
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthData", x => x.Login);
                    table.ForeignKey(
                        name: "FK_AuthData_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthData_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthData_DoctorId",
                table: "AuthData",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthData_PatientId",
                table: "AuthData",
                column: "PatientId");

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
                name: "AuthData");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Illnesses");
        }
    }
}
