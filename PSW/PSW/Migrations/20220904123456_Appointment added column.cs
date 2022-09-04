using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW.Migrations
{
    public partial class Appointmentaddedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorType",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorType",
                table: "Appointment");
        }
    }
}
