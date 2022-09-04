using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW.Migrations
{
    public partial class Clinicfeedbackaddedcolumnemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientUsername",
                table: "ClinicFeedback",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientUsername",
                table: "ClinicFeedback");
        }
    }
}
