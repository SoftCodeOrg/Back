using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakaton.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class addSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Tests",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTestProgresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Progress = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTestProgresses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTestProgresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestProgresses_SubjectId",
                table: "UserTestProgresses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestProgresses_UserId",
                table: "UserTestProgresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Subjects_SubjectId",
                table: "Tests",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Subjects_SubjectId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "UserTestProgresses");

            migrationBuilder.DropIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Tests");
        }
    }
}
