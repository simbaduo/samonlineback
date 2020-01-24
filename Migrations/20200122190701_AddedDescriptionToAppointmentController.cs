using Microsoft.EntityFrameworkCore.Migrations;

namespace samonlineback.Migrations
{
    public partial class AddedDescriptionToAppointmentController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Appointment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Appointment");
        }
    }
}
