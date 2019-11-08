using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMP229_301044056_Assignment02.Migrations
{
    public partial class Measures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientLine_Ingredients_IngredientID",
                table: "IngredientLine");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientLine_Recipes_RecipeID",
                table: "IngredientLine");

            migrationBuilder.DropIndex(
                name: "IX_IngredientLine_IngredientID",
                table: "IngredientLine");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "IngredientLine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IngredientID",
                table: "IngredientLine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasureID",
                table: "IngredientLine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    MeasureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeasureDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.MeasureID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientLine_Recipes_RecipeID",
                table: "IngredientLine",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientLine_Recipes_RecipeID",
                table: "IngredientLine");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropColumn(
                name: "MeasureID",
                table: "IngredientLine");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "IngredientLine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IngredientID",
                table: "IngredientLine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_IngredientLine_IngredientID",
                table: "IngredientLine",
                column: "IngredientID");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientLine_Ingredients_IngredientID",
                table: "IngredientLine",
                column: "IngredientID",
                principalTable: "Ingredients",
                principalColumn: "IngredientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientLine_Recipes_RecipeID",
                table: "IngredientLine",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
