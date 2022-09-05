using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW.Migrations
{
    public partial class Patientreworked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "Patient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordId",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
