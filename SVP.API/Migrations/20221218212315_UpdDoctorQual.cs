using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class UpdDoctorQual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "Qualification",
                table: "Doctors",
                type: "text[]",
                nullable: true,
                comment: "Список квалификаций",
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "Qualification",
                table: "Doctors",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true,
                oldComment: "Список квалификаций");
        }
    }
}
