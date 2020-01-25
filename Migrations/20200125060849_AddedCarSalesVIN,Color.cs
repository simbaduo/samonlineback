using Microsoft.EntityFrameworkCore.Migrations;

namespace samonlineback.Migrations
{
    public partial class AddedCarSalesVINColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CarSales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "CarSales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CarSales");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "CarSales");
        }
    }
}
