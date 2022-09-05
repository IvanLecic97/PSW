using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW.Migrations
{
    public partial class Adminapprovaladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminApproval",
                table: "ClinicFeedback",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminApproval",
                table: "ClinicFeedback");
        }
    }
}
