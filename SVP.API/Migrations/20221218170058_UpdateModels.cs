using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SVP.API.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patients",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AuthData",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "AuthData",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthData_DoctorId",
                table: "AuthData",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthData_Doctors_DoctorId",
                table: "AuthData",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthData_Doctors_DoctorId",
                table: "AuthData");

            migrationBuilder.DropIndex(
                name: "IX_AuthData_DoctorId",
                table: "AuthData");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AuthData");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AuthData",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
