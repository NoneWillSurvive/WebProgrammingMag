using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "text",
                nullable: true,
                comment: "true - М, false - Ж",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "true - М, false - Ж");
        }
    }
}
