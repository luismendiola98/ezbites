using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPrepAPICore.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestCol",
                table: "Recipes",
                type: "nvarchar(250)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCol",
                table: "Recipes");
        }
    }
}
