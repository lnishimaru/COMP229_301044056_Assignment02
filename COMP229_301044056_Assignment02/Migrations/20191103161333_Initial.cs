using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMP229_301044056_Assignment02.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Cuisine = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IngredientLine",
                columns: table => new
                {
                    IngredientLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    RecipeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientLine", x => x.IngredientLineID);
                    table.ForeignKey(
                        name: "FK_IngredientLine_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientLine_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientLine_IngredientID",
                table: "IngredientLine",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientLine_RecipeID",
                table: "IngredientLine",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientLine");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
