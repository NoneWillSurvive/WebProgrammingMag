using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "LevelHopelessness",
                table: "Patients",
                type: "smallint",
                nullable: false,
                comment: "Уровень безнадежности",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Уровень безнадежности");

            migrationBuilder.AlterColumn<byte>(
                name: "LevelDepression",
                table: "Patients",
                type: "smallint",
                nullable: false,
                comment: "Уровень депрессии",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Уровень депрессии");

            migrationBuilder.AlterColumn<byte>(
                name: "LevelAsthenicSyndrome",
                table: "Patients",
                type: "smallint",
                nullable: false,
                comment: "Уровень астенического синдрома",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Уровень астенического синдрома");

            migrationBuilder.AlterColumn<byte>(
                name: "LevelAnxiety",
                table: "Patients",
                type: "smallint",
                nullable: false,
                comment: "Уровень тревоги",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Уровень тревоги");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "text",
                nullable: true,
                comment: "true - М, false - Ж",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "true - М, false - Ж");

            migrationBuilder.AlterColumn<byte>(
                name: "Age",
                table: "Patients",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LevelHopelessness",
                table: "Patients",
                type: "integer",
                nullable: false,
                comment: "Уровень безнадежности",
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldComment: "Уровень безнадежности");

            migrationBuilder.AlterColumn<int>(
                name: "LevelDepression",
                table: "Patients",
                type: "integer",
                nullable: false,
                comment: "Уровень депрессии",
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldComment: "Уровень депрессии");

            migrationBuilder.AlterColumn<int>(
                name: "LevelAsthenicSyndrome",
                table: "Patients",
                type: "integer",
                nullable: false,
                comment: "Уровень астенического синдрома",
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldComment: "Уровень астенического синдрома");

            migrationBuilder.AlterColumn<int>(
                name: "LevelAnxiety",
                table: "Patients",
                type: "integer",
                nullable: false,
                comment: "Уровень тревоги",
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldComment: "Уровень тревоги");

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Patients",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "true - М, false - Ж",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "true - М, false - Ж");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Patients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");
        }
    }
}
