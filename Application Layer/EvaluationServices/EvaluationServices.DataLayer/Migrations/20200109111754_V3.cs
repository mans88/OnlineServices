using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationServices.DataLayer.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormResponse_FormQuestion_FormQuestionID",
                table: "FormResponse");

            migrationBuilder.DropIndex(
                name: "IX_FormResponse_FormQuestionID",
                table: "FormResponse");

            migrationBuilder.DropColumn(
                name: "FormQuestionID",
                table: "FormResponse");

            migrationBuilder.AddColumn<int>(
                name: "FormQuestionEFId",
                table: "FormResponse",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "FormQuestionID",
                table: "FormResponse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_FormQuestionID",
                table: "FormResponse",
                column: "FormQuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_FormResponse_FormQuestion_FormQuestionID",
                table: "FormResponse",
                column: "FormQuestionID",
                principalTable: "FormQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
