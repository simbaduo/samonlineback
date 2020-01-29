using Microsoft.EntityFrameworkCore.Migrations;

namespace samonlineback.Migrations
{
    public partial class UpdatedAppointmentDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Addressed",
                table: "Appointment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addressed",
                table: "Appointment");
        }
    }
}
