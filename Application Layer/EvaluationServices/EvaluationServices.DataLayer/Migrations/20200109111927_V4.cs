using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationServices.DataLayer.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormResponse_FormQuestion_FormQuestionEFId",
                table: "FormResponse");

            migrationBuilder.DropIndex(
                name: "IX_FormResponse_FormQuestionEFId",
                table: "FormResponse");

            migrationBuilder.DropColumn(
                name: "FormQuestionEFId",
                table: "FormResponse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormQuestionEFId",
                table: "FormResponse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_FormQuestionEFId",
                table: "FormResponse",
                column: "FormQuestionEFId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormResponse_FormQuestion_FormQuestionEFId",
                table: "FormResponse",
                column: "FormQuestionEFId",
                principalTable: "FormQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
