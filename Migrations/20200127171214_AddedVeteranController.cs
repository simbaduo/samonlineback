using Microsoft.EntityFrameworkCore.Migrations;

namespace samonlineback.Migrations
{
    public partial class AddedVeteranController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBeenAddressed",
                table: "Appointment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBeenAddressed",
                table: "Appointment",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
