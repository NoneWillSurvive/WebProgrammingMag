using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quaification",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Illnesses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Doctors",
                type: "text",
                nullable: true,
                comment: "Список квалификаций, описаны через запятую с пробелом");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Quaification",
                table: "Doctors",
                type: "text",
                nullable: true);
        }
    }
}
