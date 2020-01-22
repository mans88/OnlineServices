using Microsoft.EntityFrameworkCore.Migrations;

namespace MealServices.DataLayer.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Ingredient_MealId",
                table: "MealIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Meal_MealId",
                table: "MealIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Meal",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Meal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Ingredient",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_SupplierId",
                table: "Meal",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Supplier_SupplierId",
                table: "Meal",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Ingredient_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Meal_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Supplier_SupplierId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Ingredient_MealId",
                table: "MealIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Meal_MealId",
                table: "MealIngredients");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.DropIndex(
                name: "IX_Meal_SupplierId",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Meal",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Ingredient",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Ingredient_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Meal_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
