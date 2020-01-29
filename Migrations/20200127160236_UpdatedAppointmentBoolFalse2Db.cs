using Microsoft.EntityFrameworkCore.Migrations;

namespace samonlineback.Migrations
{
    public partial class UpdatedAppointmentBoolFalse2Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBeenAddressed",
                table: "Appointment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBeenAddressed",
                table: "Appointment");
        }
    }
}
