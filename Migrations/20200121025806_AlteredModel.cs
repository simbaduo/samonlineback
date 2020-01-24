using Microsoft.EntityFrameworkCore.Migrations;

namespace samonlineback.Migrations
{
    public partial class AlteredModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Appointments");
        }
    }
}
