using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class UpdDoctorQual1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Qualification",
                table: "Doctors",
                type: "text",
                nullable: true,
                comment: "Список квалификаций, описаны через запятую",
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true,
                oldComment: "Список квалификаций");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "Qualification",
                table: "Doctors",
                type: "text[]",
                nullable: true,
                comment: "Список квалификаций",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Список квалификаций, описаны через запятую");
        }
    }
}
