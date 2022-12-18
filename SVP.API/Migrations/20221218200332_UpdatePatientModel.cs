using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class UpdatePatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NeedHospitalization",
                table: "Patients",
                type: "boolean",
                nullable: false,
                comment: "Нужна ли госпитализация",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Есть ли зависимость");

            migrationBuilder.AddColumn<bool>(
                name: "HasAddiction",
                table: "Patients",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Есть ли зависимость");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAddiction",
                table: "Patients");

            migrationBuilder.AlterColumn<bool>(
                name: "NeedHospitalization",
                table: "Patients",
                type: "boolean",
                nullable: false,
                comment: "Есть ли зависимость",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Нужна ли госпитализация");
        }
    }
}
