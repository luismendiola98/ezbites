using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPrepAPICore.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCol",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "Recipes",
                newName: "RecipeSteps");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedCostID",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServingSizeID",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstimatedCost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatedCost", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServingSize",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServingSize", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_EstimatedCostID",
                table: "Recipes",
                column: "EstimatedCostID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ServingSizeID",
                table: "Recipes",
                column: "ServingSizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_EstimatedCost_EstimatedCostID",
                table: "Recipes",
                column: "EstimatedCostID",
                principalTable: "EstimatedCost",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_ServingSize_ServingSizeID",
                table: "Recipes",
                column: "ServingSizeID",
                principalTable: "ServingSize",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_EstimatedCost_EstimatedCostID",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_ServingSize_ServingSizeID",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "EstimatedCost");

            migrationBuilder.DropTable(
                name: "ServingSize");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_EstimatedCostID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ServingSizeID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "EstimatedCostID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ServingSizeID",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipeSteps",
                table: "Recipes",
                newName: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "TestCol",
                table: "Recipes",
                type: "nvarchar(250)",
                nullable: true);
        }
    }
}
