using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationServices.DataLayer.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SessionID = table.Column<int>(nullable: false),
                    AttendeeID = table.Column<int>(nullable: false),
                    FormQuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormResponse_FormQuestion_FormQuestionID",
                        column: x => x.FormQuestionID,
                        principalTable: "FormQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormQuestionId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    NameEnglish = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameDutch = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_FormQuestion_FormId",
                        column: x => x.FormId,
                        principalTable: "FormQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseFormId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    NameEnglish = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameDutch = table.Column<string>(nullable: true),
                    ResponseOpened = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_FormResponse_FormId",
                        column: x => x.FormId,
                        principalTable: "FormResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionProposition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    NameEnglish = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameDutch = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionProposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionProposition_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseId = table.Column<int>(nullable: false),
                    ResponsesId = table.Column<int>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    NameEnglish = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameDutch = table.Column<string>(nullable: true),
                    Choices = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseProposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseProposition_Responses_ResponsesId",
                        column: x => x.ResponsesId,
                        principalTable: "Responses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_FormQuestionID",
                table: "FormResponse",
                column: "FormQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionProposition_QuestionId",
                table: "QuestionProposition",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FormId",
                table: "Questions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseProposition_ResponsesId",
                table: "Response",
                column: "ResponsesId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_FormId",
                table: "Responses",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionProposition");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "FormResponse");

            migrationBuilder.DropTable(
                name: "FormQuestion");
        }
    }
}
