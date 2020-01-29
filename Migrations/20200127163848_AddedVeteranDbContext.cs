using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace samonlineback.Migrations
{
    public partial class AddedVeteranDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veteran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Birthday = table.Column<string>(nullable: true),
                    MilitaryBranch = table.Column<string>(nullable: true),
                    YearsServed = table.Column<int>(nullable: false),
                    Rank = table.Column<string>(nullable: true),
                    Stationed = table.Column<string>(nullable: true),
                    Story = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veteran", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veteran");
        }
    }
}
