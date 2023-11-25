using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakaton.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class uerfuh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Subjects_SubjectId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Tests");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Questions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Questions");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Tests",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Subjects_SubjectId",
                table: "Tests",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
