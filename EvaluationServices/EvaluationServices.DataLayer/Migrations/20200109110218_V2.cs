using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationServices.DataLayer.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameDutch",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "NameEnglish",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "NameFrench",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Choices",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "NameDutch",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "NameEnglish",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "NameFrench",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FormResponse");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Responses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionPropositionId",
                table: "Response",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseProposition_QuestionPropositionId",
                table: "Response",
                column: "QuestionPropositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseProposition_QuestionProposition_QuestionPropositionId",
                table: "Response",
                column: "QuestionPropositionId",
                principalTable: "QuestionProposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseProposition_QuestionProposition_QuestionPropositionId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_ResponseProposition_QuestionPropositionId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "QuestionPropositionId",
                table: "Response");

            migrationBuilder.AddColumn<string>(
                name: "NameDutch",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEnglish",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameFrench",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Choices",
                table: "Response",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameDutch",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEnglish",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameFrench",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Response",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FormResponse",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
